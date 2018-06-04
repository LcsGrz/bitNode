using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    class SocketUDP
    {
        //Variables
        public static bool PermitirRecibir = true;
        private ManualResetEvent TodoHecho = new ManualResetEvent(true);
        public int puerto { get; set; } = 420;
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

            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            socket.SendTo(Encoding.UTF8.GetBytes(msj), iep1);
            socket.Close();
        }
        public void RecibirUDP()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 420);
            EndPoint ep = iep;
            socket.Bind(iep);
            try
            {
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
                MessageBox.Show(e.ToString());
            }
        }
        private void cbRecibir(IAsyncResult ar)
        {
            TodoHecho.Set();

            StateObject SO = (StateObject)ar.AsyncState;
            Socket s = SO.socket;
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 420);
            EndPoint tempRemoteEP = sender;

            int read = s.EndReceiveFrom(ar, ref tempRemoteEP);
            IPAddress IPRecibida = IPAddress.Parse(tempRemoteEP.ToString().Split(':')[0]);
            if (!IPRecibida.Equals(Controlador.ObtenerIPLocal()))
            {
                byte[] data = new byte[1024];
                string[] stringData = Encoding.UTF8.GetString(SO.buffer, 0, read).Split('@');
                if (stringData[0] == "bitNode")
                {
                    controlador.AgregarIP(IPRecibida,(stringData[1] != "PING" && stringData[1] != "PONG"));
                    //--------------------------------------
                    switch (stringData[1])
                    {
                        case "PPING": // PrimerPing
                            {
                                string[] msj = stringData[2].Split('|');
                                if (msj[0] == "BROADCAST")
                                {
                                    if (bool.Parse(msj[1]))
                                    {
                                        EnviarMSJ_UDP(IPRecibida, "bitNode@EACV@");
                                    }
                                    else
                                    {
                                        EnviarMSJ_UDP(IPRecibida, "bitNode@PONG@");
                                    }
                                }
                                else //IPFIJA
                                {
                                    controlador.EnviarListaIPS(IPRecibida);
                                }
                                break;
                            }
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
                        case "AACV": // AgregarArchivosCompartidosVecinos
                            {
                                Archivo a = JsonConvert.DeserializeObject<Archivo>(stringData[2]);
                                //a.IPPropietario.Add(IPRecibida);
                                a.IPPropietario = IPRecibida;
                                controlador.AgregarArchivosCompartidos(a);
                                break;
                            }
                        case "EACV": // EliminarArchivosCompartidosVecinos
                            {
                                if (Controlador.RecivirACV) {
                                    controlador.EliminarArchivosCompartidosDeIP(IPRecibida);
                                    controlador.EnviarUDP(IPRecibida, "bitNode@CEACV@");
                                }
                                break;
                            }
                        case "CEACV": // ConfirmadoEliminoArchivosCompartidosVecinos
                            {
                                controlador.EnviarArchivosCompartidos(IPRecibida);
                                break;
                            }
                        case "SAD": // Solicitar Archivo a Descargar
                            {
                                string[] msj = stringData[2].Split('|');
                                controlador.EnviarArchivoSolicitado(IPRecibida, Convert.ToInt32(msj[1]), msj[0], 0);
                                break;
                            }
                        case "IPV": // Añadir IPVecinas
                            {
                                controlador.AgregarIP(IPAddress.Parse(stringData[2]),true);
                                break;
                            }
                        case "BYE": // Se desconecto un bitNoder
                            {
                                controlador.EliminarIP(IPRecibida);
                                controlador.EliminarArchivosCompartidosDeIP(IPRecibida);
                                break;
                            }
                        case "SAC": // SolicitarArchivosCompartidos
                            {
                                EnviarMSJ_UDP(IPRecibida, "bitNode@EACV@");
                                break;
                            }
                        case "ASNULL": // ArchivoSolicitado NULL - no existe
                            {
                                new frmMensaje(Idioma.StringResources.msjASNULL).ShowDialog();
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