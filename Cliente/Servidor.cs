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
    class Servidor
    {
        //----------------------------------------------------------------------------------------------Variables y atributos
        public static SocketUDP SUDP;
        Ping pingSender = new Ping();
        public static List<IPAddress> IPSVecinas = new List<IPAddress>();
        public static List<string> Solicitudes = new List<string>();
        public static List<Archivo> ArchivosCompartidosVecinos = new List<Archivo>();
        Thread EscucharUDP;
        private static System.Timers.Timer temporizadorPing;
        public static event EventHandler informarSolicitud;
        //----------------------------------------------------------------------------------------------Funciones
        //-----------------------------------------------Server
        public void IniciarEjecuciones()
        {
            SUDP = new SocketUDP();
            EscucharUDP = new Thread(() => { SUDP.RecibirUDP(); });
            EscucharUDP.Start();
            temporizadorPing = new System.Timers.Timer(60000) { AutoReset = true, Enabled = true };
            temporizadorPing.Elapsed += bitNodersVivos;
           // temporizadorPing.Start();
            EnviarUDP(IPAddress.Broadcast, "bitNode@PPING@"); //Primer ping
        }
        public static IPAddress ObtenerIPLocal()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var IP in host.AddressList)
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    return IP;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public void AgregarIP(IPAddress ip)
        {
            if (!IPSVecinas.Exists(x => x.Equals(ip)))
            {
                IPSVecinas.Add(ip);
                EnviarArchivosCompartidos(ip);
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
            for (int i = 0; i < aux.Count; i++)
            {
                EnviarUDP(aux[i], "bitNode@PING@");
            }
        }
        public void FrenarEjecuciones()
        {
            SUDP.FrenarEscucha();
            temporizadorPing.Stop();
            temporizadorPing.Dispose();
        }
        public static void InformarSolicitud() => informarSolicitud?.Invoke(null, null);
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
        public void AgregarArchivosCompartidos(Archivo a)
        {
                ArchivosCompartidosVecinos.Add(a);
        }
        public bool EliminarArchivosCompartidosDeIP(IPAddress ip)
        {
            for (int i = 0; i < ArchivosCompartidosVecinos.Count; i++)
            {
                if (ArchivosCompartidosVecinos[i].IPPropietario.Equals(ip))
                {
                    ArchivosCompartidosVecinos.RemoveAt(i);
                    i = 0;
                }
            }
            return true;
        }
        public void EnviarArchivosCompartidos(IPAddress iPAddress)
        {
            if (iPAddress == null)
            {
                foreach (IPAddress ip in IPSVecinas)
                {
                    foreach (Archivo a in frmCliente.archivosCompartidos)
                    {
                        if (a.Activo)
                        {
                            string sa = "bitNode@AACV@" + JsonConvert.SerializeObject(a);
                            EnviarUDP(ip, sa);
                        }
                    }
                }
            }
            else
            {
                foreach (Archivo a in frmCliente.archivosCompartidos)
                {
                    if (a.Activo)
                    {
                        string sa = "bitNode@AACV@" + JsonConvert.SerializeObject(a);
                        EnviarUDP(iPAddress, sa);
                    }
                }
            }
        }
        //-----------------------------------------------TCP
    }
}