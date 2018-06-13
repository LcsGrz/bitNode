using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Cliente
{
    class SocketUDP
    {
        //Variables
        public static bool PermitirRecibir = true;
        private ManualResetEvent TodoHecho = new ManualResetEvent(true);
        public int puerto = 420;
        Controlador controlador = new Controlador();
        //Clase
        class StateObject
        {
            public Socket socket = null;
            public const int TamañoBuffer = 1024;
            public byte[] buffer = new byte[TamañoBuffer];
        }
        //Metodos
        public void EnviarMSJ_UDP(IPAddress ip, string msj)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep1 = new IPEndPoint(ip, puerto);
            //---
            // Console.WriteLine("ENVIE: -IP: " + ip + " -MSJ: " + msj);
            //---
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(Encoding.UTF8.GetBytes(msj), iep1);
            socket.Close();
        }
        public void RecibirUDP()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, puerto);
            try
            {
                EndPoint ep = iep;
                socket.Bind(iep);
                while (PermitirRecibir)
                {
                    TodoHecho.Reset();
                    StateObject SO = new StateObject() { socket = socket };

                    socket.BeginReceiveFrom(SO.buffer, 0, StateObject.TamañoBuffer, 0, ref ep, new AsyncCallback(cbRecibir), SO);
                    TodoHecho.WaitOne();
                }
            }
            catch (Exception e)
            {
                new frmMensaje(e.ToString()).ShowDialog();
            }
        }
        private void cbRecibir(IAsyncResult ar)
        {
            TodoHecho.Set();

            StateObject SO = (StateObject)ar.AsyncState;
            Socket s = SO.socket;
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, puerto);
            EndPoint tempRemoteEP = sender;

            int read = s.EndReceiveFrom(ar, ref tempRemoteEP);
            IPAddress IPRecibida = IPAddress.Parse(tempRemoteEP.ToString().Split(':')[0]);
            if (!IPRecibida.Equals(Controlador.ObtenerIPLocal()))
            {
                byte[] data = new byte[1024];
                string[] stringData = Encoding.UTF8.GetString(SO.buffer, 0, read).Split('@');

                if (stringData[0] == "bitNode")
                {
                    //---
                    //    Console.WriteLine("RECIBI: -IP: " + IPRecibida + " -MSJ: " + Encoding.UTF8.GetString(SO.buffer, 0, read));
                    //---
                    bool primeraVez = controlador.AgregarIP(IPRecibida);

                    //--------------- Solicitar archivos a descargar
                    if (primeraVez)
                        controlador.EnviarArchivosNecesitados(IPRecibida);
                    bool sync = new Configuracion().Leer().SyncActiva;
                    //--------------------------------------
                    switch (stringData[1])
                    {
                        case "PPING": // PrimerPing
                            {

                                string[] msj = stringData[2].Split('|');
                                if (msj[0] == "OK")
                                {
                                    if (bool.Parse(msj[1])) //true
                                        EnviarMSJ_UDP(IPRecibida, "bitNode@ETACV@");
                                    else if (!(Controlador.RecivirACV && primeraVez && sync))
                                        EnviarMSJ_UDP(IPRecibida, "bitNode@PONG@");
                                }
                                else //IPFIJA
                                {
                                    controlador.EnviarListaIPS(IPRecibida);
                                    if (bool.Parse(msj[1])) //true
                                        EnviarMSJ_UDP(IPRecibida, "bitNode@ETACV@");
                                }

                                if (Controlador.RecivirACV && primeraVez && sync)
                                    EnviarMSJ_UDP(IPRecibida, "bitNode@PPING@OK|true");

                                break;
                            }
                        //------------------------------------------------------------------------------
                        case "PING": //Estoy vivo?
                            {
                                EnviarMSJ_UDP(IPRecibida, "bitNode@PONG@");
                                break;
                            }
                        case "SOLICITAR": //Hay una solicitud
                            {
                                Controlador.Solicitudes.Add(stringData[2]);
                                Controlador.InformarSolicitud();
                                break;
                            }
                        case "ETACV": // EliminarTodosLosArchivosCompartidosVecinos
                            {
                                if (Controlador.RecivirACV)
                                {
                                    controlador.EliminarArchivosCompartidosDeIP(IPRecibida);
                                    controlador.EnviarUDP(IPRecibida, "bitNode@CEACV@");
                                }
                                break;
                            }
                        case "CEACV": // ConfirmadoEliminoArchivosCompartidosVecinos
                            {
                                controlador.EnviarListaArchivosCompartidos(IPRecibida);
                                break;
                            }
                        case "SAD": // Solicitar Archivo a Descargar
                            {
                                string[] msj = stringData[2].Split('|');
                                ArchivoSolicitado AS = new ArchivoSolicitado() { IPDestino = IPRecibida, MD5 = msj[0], ParteArchivo = Convert.ToInt32(msj[1])};
                                controlador.agregarSolicitud(AS);
                                break;
                            }
                        case "IPV": // Añadir IPVecinas
                            {
                                if (controlador.AgregarIP(IPAddress.Parse(stringData[2])))
                                    EnviarMSJ_UDP(IPAddress.Parse(stringData[2]), "bitNode@PPING@OK|" + Controlador.RecivirACV);
                                break;
                            }
                        case "BYE": // Se desconecto un bitNoder
                            {
                                controlador.EliminarIP(IPRecibida);
                                controlador.EliminarArchivosCompartidosDeIP(IPRecibida);
                                controlador.EliminarPeticiones(IPRecibida);
                                break;
                            }
                        case "SAC": // SolicitarArchivosCompartidos
                            {
                                EnviarMSJ_UDP(IPRecibida, "bitNode@ETACV@");
                                break;
                            }
                        case "ASNULL": // ArchivoSolicitado NULL - no existe
                            {
                                new frmMensaje(stringData[2] + " : " + Idioma.StringResources.msjASNULL).ShowDialog();
                                break;
                            }
                        case "AAC": // AgregarArchivoCompartido
                            {
                                if (Controlador.RecivirACV && sync)
                                    controlador.AgregarArchivoCompartido(JsonConvert.DeserializeObject<Archivo>(stringData[2]), IPRecibida);
                                break;
                            }
                        case "EAC": // EliminarArchivoCompartido
                            {
                                if (Controlador.RecivirACV)
                                    controlador.EliminarArchivosCompartidosDeMD5(stringData[2], IPRecibida);
                                break;
                            }
                        case "SACTAG": //SolicitarArchivosCompartidos por TAG
                            {
                                controlador.EnviarListaArchivosCompartidosTAG(IPRecibida, stringData[2]);
                                break;
                            }
                        case "AACT": // AgregarArchivoCompartido por TAGub
                            {
                                if (Controlador.RecivirACV && !sync)
                                    controlador.AgregarArchivoCompartido(JsonConvert.DeserializeObject<Archivo>(stringData[2]), IPRecibida);
                                break;
                            }
                        case "TEA": // TENES ESTE ARCHIVO
                            {
                                controlador.EnviarArchivosMD5(IPRecibida, stringData[2]);
                                break;
                            }
                        case "AAS": // AgregarArchivoSolicitadoIP
                            {
                                controlador.AgregarIPArchivosNecesitados(IPRecibida, JsonConvert.DeserializeObject<Archivo>(stringData[2]).ArchivoMD5);
                                break;
                            }
                        case "EAS": // EliminarArchivoSolicitado
                            {
                                ArchivoNecesitado.Hacer(null, "DELIP", IPRecibida);
                                break;
                            }
                    }
                }
            }
        }
        public void FrenarEscucha()
        {
            PermitirRecibir = false;
            TodoHecho.Set();
        }
    }
}