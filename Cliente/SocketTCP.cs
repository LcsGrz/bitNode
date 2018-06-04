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
        //Cliente
        private byte[] arregloBytes(int n)
        {
            byte[] arreglo = Encoding.UTF8.GetBytes(n.ToString());
            return arreglo;
        }
        public void EnviarArchivo(string filename, IPAddress ip, int offset, int port)
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
                        byte[] sendB = new byte[size + 2];
                        loadedFile.Read(sendB, 0, sendB.Length - 2);
                        sendB.Concat(arregloBytes(i));
                        client.Send(sendB);
                    }
                    if (loadedFile.Length % size != 0)
                    {
                        byte[] sendB = new byte[(loadedFile.Length % size) + 2];
                        loadedFile.Read(sendB, 0, sendB.Length - 2);
                        sendB.Concat(arregloBytes((int)partes * size));
                        client.Send(sendB);
                    }

                    loadedFile.Close();
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
                catch (Exception e)
                {
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }).Start();
        }
        //Servidor
        bool puertoAbierto = true;
        TcpClient client;

        public void recibeFile(Archivo archivo, int port)
        {
            new Thread(() =>
            {
                var listener = new TcpListener(IPAddress.Any, portSolicitar);
                listener.Start();
                try
                {
                    while (puertoAbierto)
                    {
                        using (var client = listener.AcceptTcpClient())
                        using (var stream = client.GetStream())
                        using (var output = File.Create(new Configuracion().rutaDescarga + "\\" + archivo.Nombre.Split('.')[0] + ".bnp"))
                        {
                            var buffer = new byte[size + 2];
                            int bytesRead;
                            int partes = (int)archivo.Tamaño / size + (archivo.Tamaño % size != 0 ? 1 : 0);
                            int contador = 0;
                            //Reconstruccion del archivo
                            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                // bytesRead; //BytesDescargados                                     
                                char index = Convert.ToChar(new byte[] { buffer[size], buffer[size + 1] });
                                //MessageBox.Show(bytesRead + "" + index);
                                output.Write(buffer, Convert.ToInt32(index), bytesRead - 2);
                                contador++; //ultimo paquete recibido 
                            }
                        }
                    }
                    client.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //File.Create(Configuracion.bitNode + "\\Descargas\\"); // guardar archivo para continuacion ?
                    client.Close();
                    client.Dispose();
                    puertoAbierto = false;
                    Console.Write("errr :v" + e.Message);
                }
            }).Start();
        }
        //Otros remplazar        
    }
}
