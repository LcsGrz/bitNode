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
        const int portSolicitar = 666;
        const int size = 2000; //tamaño de division del archivo
        const int maxThreadON = 12;
        int Nposicion = 6;
        //-----------------------------------------------------------------------------------------------------------RECIBIR
        public void RecibirTCP() //Recibir archivos solicitados
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, portSolicitar);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Bind(iep);
                socket.Listen(maxThreadON);
                while (PermitirRecibir)
                {
                    TodoHecho.Reset();

                    socket.BeginAccept(new AsyncCallback(cbRecibir), socket);

                    TodoHecho.WaitOne();
                }
            }
            catch (Exception e)
            {
                new frmMensaje(e.ToString()).ShowDialog();
            }
        }
        //----
        public class StateObject
        {
            // Client  socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 1024;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }
        int c = 0;
        private void cbRecibir(IAsyncResult ar)
        {
            TodoHecho.Set();

            Socket listener = (Socket)ar.AsyncState;
            Console.WriteLine(++c + "port:" );
   
            Socket handler = listener.EndAccept(ar);


            // Create the state object.  
            StateObject state = new StateObject{ workSocket = handler };
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
            /*new Thread(() => {
               
            }).Start();*/
        }

        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
           int bytesRead = handler.EndReceive(ar);

            Console.WriteLine("la concha de sy hermanaaaa ----" + c);
        }

        //-----------------------------------------------------------------------------------------------------------ENVIAR
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        public void EnviarSolicitud(ArchivoSolicitado AS)
        {

            IPEndPoint remoteEP = new IPEndPoint(AS.IPDestino, portSolicitar);
            Socket  client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var loadedFile = new FileStream(frmCliente.archivosCompartidos[AS.posicionLista].Ruta, FileMode.Open, FileAccess.Read);
            try
            {
                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,new AsyncCallback(cbConectar), client);
                connectDone.WaitOne();
                // Send test data to the remote device.  
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.ASCII.GetBytes("pepe");

                // Begin sending the data to the remote device.  
                client.BeginSend(byteData, 0, byteData.Length, 0,new AsyncCallback(cbEnviar), client);
                sendDone.WaitOne();
                // Write the response to the console.  

                // Release the socket.  
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                client.Close();
                client.Dispose();
                loadedFile.Close();
                loadedFile.Dispose();
                Console.WriteLine("Cerre cliente");
            }
            finally
            {
            }
        }
        public void cbConectar(IAsyncResult ar) {
            Socket client = (Socket)ar.AsyncState;

            // Complete the connection.  
            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());
            connectDone.Set();
        }

        public void cbEnviar(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Signal that all bytes have been sent.  
                sendDone.Set();
                
                Controlador.PermitirEnviarSolicitud.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void Frenar() //Frenar ejecuciones
        {
            PermitirRecibir = false;
            TodoHecho.Set();
        }


        //---------------------------------------------------------------------------------------------------------

        //Cliente
        private void llenarBytes(ref byte[] sendB, int n)
        {
            byte[] arreglo = Encoding.UTF8.GetBytes(n.ToString());
            int contador = 0;
            foreach (byte aux in arreglo)
            {
                sendB[sendB.Length - Nposicion + contador] = aux;
                contador++;
            }
        }
        public void EnviarArchivo(string filename, IPAddress ip, int nPc, int port, int nIps)
        {
            new Thread(() =>
            {
                IPEndPoint ipEndPoint = new IPEndPoint(ip, portSolicitar);
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                FileStream loadedFile;
                try
                {
                    loadedFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    client.Connect(ipEndPoint);
                    long partes = loadedFile.Length / size;
                    for (int i = 0; i < partes; i++)
                    {
                        byte[] sendB = new byte[size + Nposicion];
                        int size1 = sendB.Length;
                        loadedFile.Read(sendB, 0, (sendB.Length - Nposicion));
                        int size2 = sendB.Length;
                        llenarBytes(ref sendB, i);
                        client.Send(sendB);
                    }
                    if (loadedFile.Length % size != 0)
                    {
                        byte[] sendB = new byte[(loadedFile.Length % size) + Nposicion];
                        loadedFile.Read(sendB, 0, sendB.Length);
                        llenarBytes(ref sendB, (int)partes);
                        client.Send(sendB);
                    }

                    loadedFile.Close();
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "----" + e.Source + "-----");
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }).Start();
        }
        //Servidor
        bool puertoAbierto = true;
        TcpClient client;

        public void recibeFile(Archivo archivo, int port, int offset)
        {
            new Thread(() =>
            {
                var listener = new TcpListener(IPAddress.Any, portSolicitar);
                listener.Start();

                //try
                {
                    //while (puertoAbierto)
                    {
                        var client = listener.AcceptTcpClient();
                        using (var stream = client.GetStream())
                        //using (var output = File.Create(new Configuracion().rutaDescarga + "\\" + archivo.Nombre.Split('.')[0] + ".bnp"))  
                        using (FileStream output = new FileStream(new Configuracion().rutaDescarga + "\\" + archivo.Nombre.Split('.')[0] + ".bnp", FileMode.Append))
                        {
                            output.SetLength(archivo.Tamaño);
                            //----------------------------------------------
                            var buffer = new byte[size + Nposicion];
                            int bytesRead;
                            int partes = (int)archivo.Tamaño / size + (archivo.Tamaño % size != 0 ? 1 : 0);
                            int contador = 0;
                            //Reconstruccion del archivo
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                string index = "0";

                                for (int x = 0; x < Nposicion; x++)
                                {
                                    int result = buffer[(buffer.Length) - 1 + x];
                                    if (result != 0)
                                    {
                                        index += Convert.ToChar(result).ToString();
                                    }
                                }
                                output.Write(buffer, 0, bytesRead - Nposicion);
                                contador++;
                            }

                        }
                        client.Close();
                    }

                }
                /*
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "----" + e.Source + "-----");
                    client.Close();
                    client.Dispose();
                    puertoAbierto = false;
                }
                */
            }).Start();
        }
    }
}
