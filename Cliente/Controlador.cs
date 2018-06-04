using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Cliente
{
    class Controlador
    {
        //----------------------------------------------------------------------------------------------Variables y atributos
        public static SocketUDP SUDP;
        public static SocketTCP STCP;
        Ping pingSender = new Ping();
        public static List<IPAddress> IPSVecinas = new List<IPAddress>();
        public static List<string> Solicitudes = new List<string>();
        public static List<Archivo> ArchivosCompartidosVecinos = new List<Archivo>();
        Thread EscucharUDP;
        public Configuracion configuracion = new Configuracion().Leer();
        // Thread EscucharTCP;
        private static System.Timers.Timer temporizadorPing;
        public static event EventHandler informarSolicitud;
        public static event EventHandler informarBitNoders;
        public static bool RecivirACV = false;
        private Random random = new Random();
        //----------------------------------------------------------------------------------------------Funciones
        //-----------------------------------------------Server
        public void IniciarEjecuciones()
        {
            Archivo.EnviarArchivo += new EventHandler((object sender, EventArgs e) => { EnviarUDP(null, "bitNode@EACV@"); });
            SUDP = new SocketUDP();
            EscucharUDP = new Thread(() => { SUDP.RecibirUDP(); });
            EscucharUDP.Start();
            STCP = new SocketTCP();
            // EscucharTCP = new Thread(() => { SUDP.RecibirUDP(); });
            temporizadorPing = new System.Timers.Timer(60000) { AutoReset = true, Enabled = true };
            temporizadorPing.Elapsed += bitNodersVivos;
            temporizadorPing.Start();
            IPAddress ConectarmeIP = IPAddress.Parse(configuracion.IPConeccion);
            EnviarUDP(ConectarmeIP, "bitNode@PPING@" + (IPAddress.Broadcast.Equals(ConectarmeIP) ? "BROADCAST" : "IPFIJA") + "|" + RecivirACV); //Primer ping      
        }
        public static IPAddress ObtenerIPLocal()
        {
            foreach (var IP in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    return IP;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public void AgregarIP(IPAddress ip, bool sync)
        {
            if (!ip.Equals(ObtenerIPLocal()))
            {
                if (!IPSVecinas.Exists(x => x.Equals(ip)))
                {
                    IPSVecinas.Add(ip);
                    informarBitNoders?.Invoke(null, null);
                    if (sync)
                        EnviarUDP(ip, "bitNode@EACV@");
                }
            }
        }
        private void bitNodersVivos(Object source, ElapsedEventArgs e)
        {
            List<IPAddress> aux = new List<IPAddress>();
            foreach (IPAddress ip in IPSVecinas)
            {
                aux.Add(ip);
            }
            IPSVecinas.Clear();
            informarBitNoders?.Invoke(null, null);
            foreach (IPAddress ip in aux)
            {
                EnviarUDP(ip, "bitNode@PING@");
            }
        }
        public void FrenarEjecuciones()
        {
            EnviarUDP(null, "bitNode@BYE@");
            SUDP.FrenarEscucha();
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
            {
                SUDP.EnviarMSJ_UDP(ip, msj);
            }
            else
            {
                foreach (IPAddress ipv in IPSVecinas)
                {
                    SUDP.EnviarMSJ_UDP(ipv, msj);
                }
            }
        }
        public void AgregarArchivosCompartidos(Archivo a) => ArchivosCompartidosVecinos.Add(a);
        public void EliminarArchivosCompartidosDeIP(IPAddress ip)
        {
            for (int i = 0; i < ArchivosCompartidosVecinos.Count; i++)
            {
                if (ArchivosCompartidosVecinos[i].IPPropietario.Equals(ip))
                {
                    ArchivosCompartidosVecinos.RemoveAt(i);
                    i = -1;
                }
            }
        }
        public void EnviarArchivosCompartidos(IPAddress iPAddress)
        {
            foreach (Archivo a in frmCliente.archivosCompartidos)
            {
                if (a.Activo)
                {
                    if (iPAddress == null)
                    {
                        foreach (IPAddress ip in IPSVecinas)
                        {
                            string sa = "bitNode@AACV@" + JsonConvert.SerializeObject(a);
                            EnviarUDP(ip, sa);
                        }
                    }
                    else
                    {
                        string sa = "bitNode@AACV@" + JsonConvert.SerializeObject(a);
                        EnviarUDP(iPAddress, sa);
                    }
                }
            }
        }
        public void EnviarListaIPS(IPAddress ip)
        {
            if (IPSVecinas.Count > 0)
            {
                foreach (IPAddress mip in IPSVecinas)
                {
                    EnviarUDP(ip, "bitNode@IPV@" + mip.ToString());
                }
            }
        }
        //-----------------------------------------------TCP
        public void SolicitarArchivo(int index)
        {
            int puerto = random.Next(100, 6500);
            STCP.recibeFile(ArchivosCompartidosVecinos[index], puerto); //abriendo puerto para recibir archivo
            EnviarUDP(ArchivosCompartidosVecinos[index].IPPropietario, "bitNode@SAD@" + ArchivosCompartidosVecinos[index].ArchivoMD5 + "|" + puerto); //SolicitarArchivo
        }
        public void EnviarArchivoSolicitado(IPAddress ip, int puerto, string MD5, int offset)
        {
            foreach (Archivo a in frmCliente.archivosCompartidos)
            {
                if (Archivo.CompararMD5(a.ArchivoMD5, MD5))
                {
                    if (!Archivo.ArchivoEnDisco(a.Ruta))
                        EnviarUDP(ip, "bitNode@ASNULL@");
                    else
                        STCP.EnviarArchivo(a.Ruta, ip, offset, puerto);
                    return;
                }
            }
        }
    }
}