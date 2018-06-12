using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        public static List<string> Solicitudes = new List<string>();
        public static List<Archivo> ArchivosCompartidosVecinos = new List<Archivo>();
        private static System.Timers.Timer temporizadorPing;
        public static bool RecivirACV = false;
        //------------TCP
        private static SocketTCP STCP;
        Thread EscucharTCP;
        public static List<ArchivoSolicitado> archivosSolicitados = new List<ArchivoSolicitado>();
        public static ManualResetEvent PermitirEnviarSolicitud = new ManualResetEvent(true);
        public bool PermitirEnviarSolicitudes = true;
        //------------UDP
        private static SocketUDP SUDP;
        Thread EscucharUDP;
        private bool PermitirSolicitar = true;
        //----------------------------------------------------------------------------------------------Eventos
        public static event EventHandler informarSolicitud;
        public static event EventHandler informarBitNoders;
        public static event EventHandler informarArchivo;
        //----------------------------------------------------------------------------------------------Funciones
        //-----------------------------------------------Server
        public void IniciarEjecuciones()
        {
            ArchivoNecesitado.archivosNecesitados = new ArchivoNecesitado().Leer();
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
            PermitirSolicitar = false;
            PermitirEnviarSolicitudes = false;
            PermitirEnviarSolicitud.Set();
            temporizadorPing.Stop();
            temporizadorPing.Dispose();
            GuardarTodosArchivosNecesitados();
        }
        public void VaciarIPS() => IPSVecinas.Clear();
        public void VaciarACV() => ArchivosCompartidosVecinos.Clear();
        public static void InformarSolicitud() => informarSolicitud?.Invoke(null, null);
        public void EliminarIP(IPAddress ip)
        {
            IPSVecinas.Remove(ip);
            ArchivoNecesitado.Hacer(null,"DELIP",ip);
            informarBitNoders?.Invoke(null, null);
        }
        public void InicializarArchvio(int index) //mejorar
        {
                if (ArchivoNecesitado.Hacer(ArchivosCompartidosVecinos[index].ArchivoMD5, "EXIST",null) == 0)
                    new ArchivoNecesitado(ArchivosCompartidosVecinos[index]);

            new frmMensaje(Idioma.StringResources.msjArchivoEnLista).ShowDialog();
        }
        public void agregarSolicitud(ArchivoSolicitado AS)
        {
            if (!archivosSolicitados.Exists(x => (Archivo.CompararMD5(x.MD5, AS.MD5) && AS.IDPosicion == x.IDPosicion && AS.ParteArchivo == x.ParteArchivo)))
                archivosSolicitados.Add(AS);
        }
        public void GuardarTodosArchivosNecesitados() => ArchivoNecesitado.Hacer(null,null,null);
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
        }
        public void AgregarIPArchivosNecesitados(IPAddress ip, string MD5) => ArchivoNecesitado.Hacer(MD5,"ADDIP",ip);
        public void EnviarArchivosNecesitados(IPAddress ip) => ArchivoNecesitado.Hacer(null, "EAN", ip);
        //-----------------------------------------------TCP
        public void ManejadorNecesitados() =>
            new Thread(() =>
            {
                while (PermitirSolicitar)
                {
                    Thread.Sleep(1000);
                    int ASCount = ArchivoNecesitado.Hacer(null, "L", null);
                    if (ASCount > 0)
                        ArchivoNecesitado.archivosNecesitados[r.Next(0, ASCount)].SolicitarPartes();
                }
            }).Start();
        public void ManejadorSolicitudes() =>
            new Thread(() =>
            {
                while (PermitirEnviarSolicitudes)
                {
                    PermitirEnviarSolicitud.Reset();

                    if (archivosSolicitados.Count > 0)
                    {
                        ArchivoSolicitado AS = archivosSolicitados[0];
                        archivosSolicitados.RemoveAt(0);
                        AS.posicionLista = Archivo.PosicionArchivo(AS.MD5);

                        if (AS.posicionLista > -1)
                        {
                            STCP.EnviarSolicitud(AS);
                            PermitirEnviarSolicitud.WaitOne();
                            Thread.Sleep(100);
                        }
                        else
                            EnviarUDP(AS.IPDestino, "bitNode@ASNULL@" + frmCliente.archivosCompartidos[AS.posicionLista].Nombre);
                    }
                    else
                        Thread.Sleep(2000);
                }
            }).Start();
        public void EliminarPeticiones(IPAddress ip)
        {
            for (int i = 0; i < archivosSolicitados.Count; i++)
            {
                if (archivosSolicitados[i].IPDestino.Equals(ip))
                {
                    archivosSolicitados.RemoveAt(i);
                    i = -1;
                }
            }
        }
        
    }
}