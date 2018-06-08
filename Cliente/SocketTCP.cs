using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public class SocketTCP
    {
        int portSolicitar = 666;
        int size = 2000; //tamaño de division del archivo
        int posicion = 5;
        //Cliente
        private void llenarBytes(ref byte[] sendB, int n)
        {
            byte[] arreglo = Encoding.UTF8.GetBytes(n.ToString());
            int contador = 0;
            foreach (byte aux in arreglo)
            {
                sendB[sendB.Length - posicion + contador] = aux;
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
                        byte[] sendB = new byte[size + posicion];
                        int size1 = sendB.Length;
                        loadedFile.Read(sendB, 0, (sendB.Length - posicion));
                        int size2 = sendB.Length;
                        llenarBytes(ref sendB, i);
                        client.Send(sendB);
                    }
                    if (loadedFile.Length % size != 0)
                    {
                        byte[] sendB = new byte[(loadedFile.Length % size) + posicion];
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
                            var buffer = new byte[size + posicion];
                            int bytesRead;
                            int partes = (int)archivo.Tamaño / size + (archivo.Tamaño % size != 0 ? 1 : 0);
                            int contador = 0;
                            //Reconstruccion del archivo
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                string index = "0";

                                for (int x = 0; x < posicion; x++)
                                {
                                    int result = buffer[(buffer.Length) - 1 + x];
                                    if (result != 0)
                                    {
                                        index += Convert.ToChar(result).ToString();
                                    }
                                }
                                output.Write(buffer, 0, bytesRead - posicion);
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
