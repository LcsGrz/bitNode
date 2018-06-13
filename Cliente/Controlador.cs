using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace Cliente
{
    class Controlador
    {
        //----------------------------------------------------------------------------------------------Variables y atributos
        private Configuracion configuracion = new Configuracion().Leer();
        Random r = new Random();
        public static List<IPAddress> IPSVecinas = new List<IPAddress>();
        public static List<string> Solicitudes = new List<string>(); //Solicitud de archivo - vista 'Solicitar'
        public static List<Archivo> ArchivosCompartidosVecinos = new List<Archivo>();
        private static System.Timers.Timer temporizadorPing;
        public static bool RecivirACV = false;
        //------------TCP
        private static SocketTCP STCP;
        Thread EscucharTCP;
        public static ManualResetEvent PermitirEnviarSolicitud = new ManualResetEvent(true);
        public bool PermitirEnviarSolicitudes = true;
        //------------UDP
        private static SocketUDP SUDP;
        Thread EscucharUDP;
        public static bool PermitirSolicitar = true;
        //----------------------------------------------------------------------------------------------Eventos
        public static event EventHandler informarSolicitud;
        public static event EventHandler informarBitNoders;
        public static event EventHandler informarArchivo;
        public static event EventHandler informarEstadoDescarga;
        //----------------------------------------------------------------------------------------------Funciones
        //-----------------------------------------------Server
        public void IniciarEjecuciones()
        {
            SUDP = new SocketUDP();
            STCP = new SocketTCP();
            EscucharUDP = new Thread(() => { SUDP.RecibirUDP(); });
            EscucharUDP.Start();
            EscucharTCP = new Thread(() => { STCP.RecibirTCP(); });
            EscucharTCP.Start();
            temporizadorPing = new System.Timers.Timer(60000) { AutoReset = true, Enabled = true };
            temporizadorPing.Elapsed += bitNodersVivos;
            temporizadorPing.Start();
            IPAddress ConectarmeIP = IPAddress.Parse(configuracion.IPConeccion);
            ManejadorSolicitudes();
            ManejadorNecesitados();
            EnviarUDP(ConectarmeIP, "bitNode@PPING@" + (IPAddress.Broadcast.Equals(ConectarmeIP) ? "OK" : "IPFIJA") + "|" + (RecivirACV && configuracion.SyncActiva)); //Primer ping      
        } //Inicia todas las ejecuciones del servidor
        public void FrenarEjecuciones()
        {
            EnviarUDP(null, "bitNode@BYE@");
            SUDP.FrenarEscucha();
            STCP.Frenar();
            PermitirSolicitar = false;
            PermitirEnviarSolicitudes = false;
            PermitirEnviarSolicitud.Set();
            temporizadorPing.Stop();
            temporizadorPing.Dispose();
            GuardarTodosArchivosNecesitados();
        } //Frena todas las ejecuciones activas
        public static IPAddress ObtenerIPLocal()
        {
            foreach (var IP in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                    return IP;
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        } //Retorna la IP 
        public bool AgregarIP(IPAddress ip)
        {
            if (!ip.Equals(ObtenerIPLocal()))
            {
                if (!IPSVecinas.Exists(x => x.Equals(ip)))
                {
                    IPSVecinas.Add(ip);
                    informarBitNoders?.Invoke(null, null);
                    return true;
                }
            }
            return false;
        }  //Agrega bitNoders
        private void bitNodersVivos(Object source, ElapsedEventArgs e)
        {
            List<IPAddress> aux = new List<IPAddress>();
            IPSVecinas.ForEach(ip => aux.Add(ip));
            IPSVecinas.Clear();
            informarBitNoders?.Invoke(null, null);
            aux.ForEach(ip => EnviarUDP(ip, "bitNode@PING@"));
        } //Ping a bitNoders
        public void VaciarIPS() => IPSVecinas.Clear();
        public void VaciarACV() => ArchivosCompartidosVecinos.Clear();
        public static void InformarSolicitud() => informarSolicitud?.Invoke(null, null);
        public static void InformarEstadoDescarga(object valor) => informarEstadoDescarga?.Invoke(valor, null);
        public void EliminarIP(IPAddress ip)
        {
            IPSVecinas.Remove(ip);
            ArchivoNecesitado.Hacer(null, "DELIP", ip);
            informarBitNoders?.Invoke(null, null);
        } //Se desconecto un bitNoder
        public void InicializarArchivo(int index)
        {
            if (ArchivoNecesitado.Hacer(ArchivosCompartidosVecinos[index].ArchivoMD5, "EXIST", null) == 0)
                new ArchivoNecesitado(ArchivosCompartidosVecinos[index]);

            new frmMensaje(Idioma.StringResources.msjArchivoEnLista).ShowDialog();
        } //Prepara el archivoNecesitado 
        public void agregarSolicitud(ArchivoSolicitado AS)
        {
            ArchivoSolicitado.Hacer(AS, "ADD", null);
        } //Agrega nuevas solicitudes de archivos a la lista
        public void GuardarTodosArchivosNecesitados() => ArchivoNecesitado.Hacer(null, "SAVE", null);
        //-----------------------------------------------UDP
        public void EnviarUDP(IPAddress ip, string msj)
        {
            if (ip != null)
                SUDP.EnviarMSJ_UDP(ip, msj);
            else
                IPSVecinas.ForEach(ipv => SUDP.EnviarMSJ_UDP(ipv, msj));
        }
        public void AgregarArchivoCompartido(Archivo a, IPAddress ip)
        {
            for (int i = 0; i < ArchivosCompartidosVecinos.Count; i++)
            {
                if (Archivo.CompararMD5(ArchivosCompartidosVecinos[i].ArchivoMD5, a.ArchivoMD5))
                {
                    if (!ArchivosCompartidosVecinos[i].IPPropietario.Exists(x => x.Equals(ip)))
                        ArchivosCompartidosVecinos[i].IPPropietario.Add(ip);
                    informarArchivo?.Invoke(null, null);
                    return;
                }
            }
            a.IPPropietario = new List<IPAddress>() { ip };
            ArchivosCompartidosVecinos.Add(a);
            informarArchivo?.Invoke(null, null);
        }
        public void EliminarArchivosCompartidosDeIP(IPAddress ip)
        {
            for (int i = 0; i < ArchivosCompartidosVecinos.Count; i++)
            {
                ArchivosCompartidosVecinos[i].IPPropietario.Remove(ip);
                if (ArchivosCompartidosVecinos[i].IPPropietario.Count == 0)
                {
                    ArchivosCompartidosVecinos.RemoveAt(i);
                    i = -1;
                }
            }
            informarArchivo?.Invoke(null, null);
        }
        public void EliminarArchivosCompartidosDeMD5(string MD5, IPAddress ip)
        {
            for (int i = 0; i < ArchivosCompartidosVecinos.Count; i++)
            {
                if (Archivo.CompararMD5(ArchivosCompartidosVecinos[i].ArchivoMD5, MD5))
                {
                    ArchivosCompartidosVecinos[i].IPPropietario.Remove(ip);
                    if (ArchivosCompartidosVecinos[i].IPPropietario.Count == 0)
                    {
                        ArchivosCompartidosVecinos.RemoveAt(i);
                        break;
                    }
                }
            }
            informarArchivo?.Invoke(null, null);
        }
        public void EnviarListaArchivosCompartidos(IPAddress ip)
        {
            foreach (Archivo a in frmCliente.archivosCompartidos)
            {
                if (a.Activo)
                {
                    if (ip == null)
                        IPSVecinas.ForEach(ipv => EnviarUDP(ipv, "bitNode@AAC@" + JsonConvert.SerializeObject(a)));
                    else
                        EnviarUDP(ip, "bitNode@AAC@" + JsonConvert.SerializeObject(a));
                }
            }
        }
        public void EnviarUnicoArchivoCompartido(Archivo a) => IPSVecinas.ForEach(x => EnviarUDP(x, "bitNode@AAC@" + JsonConvert.SerializeObject(a)));
        public void EnviarListaIPS(IPAddress ip) => IPSVecinas.ForEach(x => EnviarUDP(ip, "bitNode@IPV@" + x.ToString())); //Envio lista de ip 'IPFIJA'
        public void EnviarListaArchivosCompartidosTAG(IPAddress ip, string strArchivos)
        {
            if (strArchivos == "NOTAG")
                frmCliente.archivosCompartidos.ForEach(a => EnviarUDP(ip, "bitNode@AACT@" + JsonConvert.SerializeObject(a)));
            else
                Archivo.TagArchivo(frmCliente.archivosCompartidos, strArchivos).ForEach(a => EnviarUDP(ip, "bitNode@AACT@" + JsonConvert.SerializeObject(a)));
        } //Busco coincidencias de mis AC con los tags recividos y los envio
        public void EnviarArchivosMD5(IPAddress ip, string MD5Archivos)
        {
            string[] archivos = MD5Archivos.Split('|');
            for (int i = 0; i < archivos.Length; i++)
            {
                for (int x = 0; x < frmCliente.archivosCompartidos.Count; x++)
                {
                    if (Archivo.CompararMD5(frmCliente.archivosCompartidos[x].ArchivoMD5, archivos[i]))
                    {
                        EnviarUDP(ip, "bitNode@AAS@" + JsonConvert.SerializeObject(frmCliente.archivosCompartidos[x]));
                        break;
                    }
                }
            }
        } //Envio archivos == MD5
        public void AgregarIPArchivosNecesitados(IPAddress ip, string MD5) => ArchivoNecesitado.Hacer(MD5, "ADDIP", ip);
        public void EnviarArchivosNecesitados(IPAddress ip) => ArchivoNecesitado.Hacer(null, "EAN", ip);
        //-----------------------------------------------TCP
        public void ManejadorNecesitados() =>
            new Thread(() =>
            {
                while (PermitirSolicitar)
                {
                    ArchivoNecesitado.Hacer(null,"SP",null);
                }
            }).Start(); //Se encarga de solicitar las partes de los archivos
        public void ManejadorSolicitudes() =>
            new Thread(() =>
            {
                while (PermitirEnviarSolicitudes)
                {
                    PermitirEnviarSolicitud.Reset();

                    if (ArchivoSolicitado.Hacer(null, "L", null) > 0)
                    {
                        ArchivoSolicitado AS = ArchivoSolicitado.archivosSolicitados[0];
                        ArchivoSolicitado.Hacer(null, "DEL", 0);
                        AS.posicionLista = Archivo.PosicionArchivo(AS.MD5);

                        if (AS.posicionLista > -1)
                        {
                            STCP.EnviarSolicitud(AS);
                            PermitirEnviarSolicitud.WaitOne();
                            Thread.Sleep(100);
                        }
                    }
                    else
                        Thread.Sleep(2000);
                }
            }).Start(); //Se encarga de enviar las partes solicitadas
        public void EliminarPeticiones(IPAddress ip) => ArchivoSolicitado.Hacer(null, "DELIP", ip); //Elimina solicitudes cuando un bitNoder se desconecta
    }
}