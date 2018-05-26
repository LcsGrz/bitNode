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
        private ManualResetEvent TodoHecho = new ManualResetEvent(false);
        public int puerto { get; set; } = 420;
        Servidor server = new Servidor();
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
            socket.SendTo(Encoding.ASCII.GetBytes(msj), iep1);
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
            StateObject SO = (StateObject)ar.AsyncState;
            Socket s = SO.socket;
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 420);
            EndPoint tempRemoteEP = sender;

            int read = s.EndReceiveFrom(ar, ref tempRemoteEP);
            IPAddress IPRecibida = IPAddress.Parse(tempRemoteEP.ToString().Split(':')[0]);
            if (!IPRecibida.Equals(Servidor.ObtenerIPLocal()))
            {
                byte[] data = new byte[1024];
                string[] stringData = Encoding.ASCII.GetString(SO.buffer, 0, read).Split('@');
                if (stringData[0] == "bitNode")
                {
                    server.AgregarIP(IPRecibida);
                    //--------------------------------------
                    switch (stringData[1])
                    {
                        case "PING":
                            {
                                EnviarMSJ_UDP(IPRecibida, "bitNode@PONG@");
                                break;
                            }
                        case "SOLICITAR":
                            {
                                Servidor.Solicitudes.Add(stringData[2]);
                                Servidor.InformarSolicitud();
                                break;
                            }
                        case "ACV":
                            {
                                server.EliminarArchivosCompartidosDeIP(IPRecibida);
                                Archivo a = JsonConvert.DeserializeObject<Archivo>(stringData[2]);
                                a.IPPropietario = IPRecibida;
                                server.AgregarArchivosCompartidos(a);
                                break;
                            }
                    }
                }
            }
            TodoHecho.Set();
        }
        public void FrenarEscucha()
        {
            PermitirRecibir = false;
            TodoHecho.Set();
        }
    }
}