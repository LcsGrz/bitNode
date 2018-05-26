﻿using System;
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
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, puerto);
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
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, puerto);
            EndPoint tempRemoteEP = sender;

            int read = s.EndReceiveFrom(ar, ref tempRemoteEP);
            IPAddress IPRecibida = IPAddress.Parse(tempRemoteEP.ToString().Split(':')[0]);
            if (!IPRecibida.Equals(Configuracion.ObtenerIPLocal()))
            {
                byte[] data = new byte[1024];
                string stringData = Encoding.ASCII.GetString(SO.buffer, 0, read);
                if (stringData.Split('@')[0] == "bitNode")
                {
                    new Servidor().AgregarIP(IPRecibida);
                    //--------------------------------------
                    if (stringData.Split('@')[1] == "PING")
                    {
                        EnviarMSJ_UDP(IPRecibida, "bitNode@PONG@");
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