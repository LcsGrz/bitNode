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
        int portSolicitar = 666;
        int size = 2000; //tamaño de division del archivo
        int maxThreadON = 12;
        int Nposicion = 6;
        //-----------------------------------------------------------------------------------------------------------RECIBIR
        public void RecibirTCP() //Recibir archivos solicitados
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, portSolicitar);
            EndPoint ep = iep;
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
        private void cbRecibir(IAsyncResult ar)
        {
            Console.WriteLine("etoy en al coneccicooonn");
            new Thread(() => {

                Console.WriteLine("etoy en al coneccicooonn");
                TodoHecho.Set();
            }).Start();
        }
        //-----------------------------------------------------------------------------------------------------------ENVIAR
        public void EnviarSolicitud(ArchivoSolicitado AS)
        {

            IPEndPoint remoteEP = new IPEndPoint(AS.IPDestino, portSolicitar);
            Socket  client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var loadedFile = new FileStream(frmCliente.archivosCompartidos[AS.posicionLista].Ruta, FileMode.Open, FileAccess.Read);
            try
            {
                // Connect to the remote endpoint.  
                client.BeginConnect(remoteEP,new AsyncCallback(cbConectar), client);

                // Send test data to the remote device.  
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.ASCII.GetBytes("pepe");

                // Begin sending the data to the remote device.  
                client.BeginSend(byteData, 0, byteData.Length, 0,new AsyncCallback(cbEnviar), client);

                // Write the response to the console.  

                // Release the socket.  
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                client.Shutdown(SocketShutdown.Both);
                client.Close();
                loadedFile.Close();
                loadedFile.Dispose();
            }
            finally
            {
                Controlador.EnviosActivos--;
                Controlador.PermitirEnviarSolicitud.Set();
            }
        }
        public void cbConectar(IAsyncResult ar) {
            Socket client = (Socket)ar.AsyncState;

            // Complete the connection.  
            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());
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
