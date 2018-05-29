using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Timers;

namespace Cliente
{
    class Servidor
    {
        //----------------------------------------------------------------------------------------------Variables y atributos
        SocketUDP SUDP = new SocketUDP();
        Ping pingSender = new Ping();
        public static List<IPAddress> IPSVecinas = new List<IPAddress>();
        public static List<string> Solicitudes = new List<string>();
        public static List<Archivo> ArchivosCompartidosVecinos = new List<Archivo>();
        Thread EscucharUDP;
        private static System.Timers.Timer temporizador;
        public static event EventHandler informarSolicitud;
        //----------------------------------------------------------------------------------------------Funciones
        //-----------------------------------------------Server
        public void IniciarEjecuciones()
        {
            EscucharUDP = new Thread(() => { SUDP.RecibirUDP(); });
            EscucharUDP.Start();
            temporizador = new System.Timers.Timer(60000) { AutoReset = true, Enabled = true };
            temporizador.Elapsed += bitNodersVivos;
            temporizador.Start();
            EnviarUDP(IPAddress.Broadcast, "bitNode@PING@");
            EnviarArchivosCompartidos();
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
                IPSVecinas.Add(ip);
        }
        private void bitNodersVivos(Object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < IPSVecinas.Count; i++)
            {
                if (pingSender.Send(IPSVecinas[i]).Status != IPStatus.Success)
                {
                    IPSVecinas.RemoveAt(i); //tendria que hacer ping desde udp por que si la persona cierra el cliente, va estar activo igual
                }
            }
        }
        public void FrenarEjecuciones()
        {
            SUDP.FrenarEscucha();
            temporizador.Stop();
            temporizador.Dispose();
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
            if (!ArchivosCompartidosVecinos.Exists(x => (Archivo.CompararMD5(x.ArchivoMD5,a.ArchivoMD5) && x.IPPropietario.Equals(a.IPPropietario))))
                ArchivosCompartidosVecinos.Add(a);
        }
        public void EliminarArchivosCompartidosDeIP(IPAddress ip)
        {
            for (int i = 0; i < ArchivosCompartidosVecinos.Count; i++)
            {
                if (ArchivosCompartidosVecinos[i].IPPropietario == ip)
                {
                    ArchivosCompartidosVecinos.RemoveAt(i);
                    i = 0;
                }
            }
        }
        public void EnviarArchivosCompartidos()
        {
            foreach (IPAddress ip in IPSVecinas)
            {
                foreach (Archivo a in frmCliente.archivosCompartidos)
                {
                    if (a.Activo) {
                        string sa = "bitNode@ACV@" + JsonConvert.SerializeObject(a);
                        EnviarUDP(ip, sa);
                    }
                }
            }
        }
        //-----------------------------------------------TCP
    }
}