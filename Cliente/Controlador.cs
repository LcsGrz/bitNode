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
        private static SocketUDP SUDP;
        private static SocketTCP STCP;
        public static List<IPAddress> IPSVecinas = new List<IPAddress>();
        public static List<string> Solicitudes = new List<string>();
        public static List<Archivo> ArchivosCompartidosVecinos = new List<Archivo>();
        Thread EscucharUDP;
        Thread EscucharTCP;
        private Configuracion configuracion = new Configuracion().Leer();
        private static System.Timers.Timer temporizadorPing;
        public static event EventHandler informarSolicitud;
        public static event EventHandler informarBitNoders;
        public static event EventHandler informarArchivo;
        public static bool RecivirACV = false;
        private Random random = new Random();
        //---------------------------------
        public static Queue<ArchivoSolicitado> archivosSolicitados = new Queue<ArchivoSolicitado>();
        public static ManualResetEvent PermitirEnviarSolicitud = new ManualResetEvent(true);
        public bool PermitirEnviarSolicitudes = true;
        public static int EnviosActivos = 0;
        //----------------------------------------------------------------------------------------------Funciones
        //-----------------------------------------------Server
        public void IniciarEjecuciones()
        {
            SUDP = new SocketUDP();
            EscucharUDP = new Thread(() => { SUDP.RecibirUDP(); });
            EscucharUDP.Start();
            STCP = new SocketTCP();
            EscucharTCP = new Thread(() => { STCP.RecibirTCP(); });
            temporizadorPing = new System.Timers.Timer(60000) { AutoReset = true, Enabled = true };
            temporizadorPing.Elapsed += bitNodersVivos;
            temporizadorPing.Start();
            IPAddress ConectarmeIP = IPAddress.Parse(configuracion.IPConeccion);
            EnviarUDP(ConectarmeIP, "bitNode@PPING@" + (IPAddress.Broadcast.Equals(ConectarmeIP) ? "OK" : "IPFIJA") + "|" + (RecivirACV && configuracion.SyncActiva)); //Primer ping      
            ManejadorSolicitudes();
        }
        public static IPAddress ObtenerIPLocal()
        {
            foreach (var IP in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                    return IP;
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
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
        }
        private void bitNodersVivos(Object source, ElapsedEventArgs e)
        {
            List<IPAddress> aux = new List<IPAddress>();
            IPSVecinas.ForEach(ip => aux.Add(ip));
            IPSVecinas.Clear();
            informarBitNoders?.Invoke(null, null);
            aux.ForEach(ip => EnviarUDP(ip, "bitNode@PING@"));
        }
        public void FrenarEjecuciones()
        {
            EnviarUDP(null, "bitNode@BYE@");
            SUDP.FrenarEscucha();
            STCP.Frenar();
            PermitirEnviarSolicitudes = false;
            PermitirEnviarSolicitud.Set();
            temporizadorPing.Stop();
            temporizadorPing.Dispose();
        }
        public void VaciarIPS() => IPSVecinas.Clear();
        public void VaciarACV() => ArchivosCompartidosVecinos.Clear();
        public static void InformarSolicitud() => informarSolicitud?.Invoke(null, null);
        public void EliminarIP(IPAddress ip)
        {
            IPSVecinas.Remove(ip);
            informarBitNoders?.Invoke(null, null);
        }
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
        public void EnviarListaIPS(IPAddress ip) => IPSVecinas.ForEach(x => EnviarUDP(ip, "bitNode@IPV@" + x.ToString()));
        public void EnviarListaArchivosCompartidosTAG(IPAddress ip, string strArchivos)
        {
            if (strArchivos == "NOTAG")
                frmCliente.archivosCompartidos.ForEach(a => EnviarUDP(ip, "bitNode@AACT@" + JsonConvert.SerializeObject(a)));
            else
                Archivo.TagArchivo(frmCliente.archivosCompartidos, strArchivos).ForEach(a => EnviarUDP(ip, "bitNode@AACT@" + JsonConvert.SerializeObject(a)));
        }
        //-----------------------------------------------TCP
        public void SolicitarArchivo(int index)
        {
            /*Descargas solicitar = new Descargas();
            solicitar.AgregarArchivos(ArchivosCompartidosVecinos[index]);
            solicitar.SolicitarPartes();*/
        }
        public void ManejadorSolicitudes()
        {
            while (PermitirEnviarSolicitudes)
            {
                PermitirEnviarSolicitud.Reset();

                if (archivosSolicitados.Count > 0 && EnviosActivos <= 12)
                {
                    ArchivoSolicitado AS = archivosSolicitados.Dequeue();
                    int PosicionArchivo = Archivo.PosicionArchivo(AS.MD5);
                    new Thread(() =>
                    {
                        if (PosicionArchivo > -1)
                        {
                            EnviosActivos++;
                            STCP.EnviarSolicitud(AS);
                            return;
                        }
                        else
                            EnviarUDP(AS.IPDestino, "bitNode@ASNULL@" + frmCliente.archivosCompartidos[PosicionArchivo].Nombre);
                    }).Start();
                }
                else
                    PermitirEnviarSolicitud.WaitOne();
            }
        }
    }
}