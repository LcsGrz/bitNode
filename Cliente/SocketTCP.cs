using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public class SocketTCP
    {
        public static bool PermitirRecibir = true;
        private ManualResetEvent TodoHecho = new ManualResetEvent(false);
        int port = 666;
        int maxThreadON = 12;
        int Nposicion = 6;
        //-----------------------------------------------
        // ManualResetEvent instances signal completion.  
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);

        // The response from the remote device.  
        private String response = String.Empty;

        //-----------------------------------------------------------------------------------------------------------Enviar
        public void EnviarSolicitud(ArchivoSolicitado AS)
        {
            IPEndPoint remoteEP = new IPEndPoint(AS.IPDestino, port);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {

                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();

                Send(client, frmCliente.archivosCompartidos[AS.IDPosicion].Ruta, AS.IDPosicion, AS.ParteArchivo);
                sendDone.WaitOne();

                client.Shutdown(SocketShutdown.Both);
                client.Close();
                Controlador.PermitirEnviarSolicitud.Set();
            }
            catch (Exception e)
            {
                client.Close();
                client.Dispose();
                Console.WriteLine("StartClient Error: " + e.ToString());
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndConnect(ar);
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void Send(Socket client, String filename, int id, int Nparte)
        {
            FileStream loadedFile;
            try
            {
                loadedFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
                long partes = loadedFile.Length / StateObject.size;

                byte[] byteId = new byte[StateObject.Nid];
                byte[] byteParte = new byte[StateObject.Npartes];

                byteId = Encoding.ASCII.GetBytes(id.ToString());
                byte[] byteAux = Encoding.ASCII.GetBytes(Nparte.ToString());

                for (int i = 0; i < byteAux.Length; i++) // Rellenar espacios con ceros
                {
                    byteParte[i] = byteAux[i];
                }

                byte[] byteData = new byte[StateObject.size];

                loadedFile.Position = Nparte * StateObject.size;
                loadedFile.Read(byteData, 0, byteData.Length);

                byte[] sendB = new byte[StateObject.Nid + StateObject.Npartes + byteData.Length];

                byteId.CopyTo(sendB, 0);
                byteParte.CopyTo(sendB, byteId.Length);
                byteData.CopyTo(sendB, (byteId.Length + byteParte.Length));

                client.BeginSend(sendB, 0, sendB.Length, 0,
                    new AsyncCallback(SendCallback), client);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Send: " + e.Message);
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                int bytesSent = client.EndSend(ar);

                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine("Send CallbackEroor: " + e.ToString());
            }
        }
        //-----------------------------------------------------------------------------------------------------------Enviar

        //-----------------------------------------------------------------------------------------------------------Recibir
        public ManualResetEvent allDone = new ManualResetEvent(false);

        public void RecibirTCP()
        {
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, port);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(sender);
                listener.Listen(100);

                while (PermitirRecibir)
                {
                    allDone.Reset();

                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                    allDone.WaitOne();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error al conectarrr " +e.ToString());
                MessageBox.Show(e.ToString());
            }
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            allDone.Set();

            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);
            state.byteLeidos += bytesRead;
            if (bytesRead > 0)
            {
                //state.manejarArchivo(bytesRead);
                if (state.byteLeidos < 100)
                {
                    Console.WriteLine("Recibiendo... 2: " + bytesRead);
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state); //Leer mas datos
                }
                else {
                    Console.WriteLine("Tenemos un archivo completo: " + bytesRead + "---" + state.byteLeidos);
                }

            }
        }
        //Clase Auxiliar
        public class StateObject
        {
            public int byteLeidos=0;
            public static int Nid = 1;
            public static int Npartes = 6;
            public static int size = 100;
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 64;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();


        }
        public void Frenar()
        {
            PermitirRecibir = false;
            allDone.Set();
        }
    }
}