using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public class TCP
    {
        int portFile = 420;
        int portSolicitar = 666;
        int size = 10000; //tamaño de division del archivo
        //Cliente
        public void EnviarArchivo(string filename, IPAddress ip,int offset )
        {
            IPEndPoint ipEndPoint = new IPEndPoint(ip, portSolicitar);
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            FileStream loadedFile;
            try
            {
                loadedFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
                client.Connect(ipEndPoint);
                int partes = (int)loadedFile.Length / size;
                
                for (int i = 0; i < partes; i++)
                {
                    byte[] sendB = new byte[size];

                    loadedFile.Read(sendB,0, sendB.Length);
                    client.Send(sendB);
                }
                if (loadedFile.Length % size != 0)
                {
                    byte[] sendB = new byte[(loadedFile.Length % size)];
                    loadedFile.Read(sendB, 0, sendB.Length);
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
        }
        //Servidor
        bool puertoAbierto = true;
        TcpClient client;
        
        public void recibeFile(Archivo archivo)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[1];
            var listener = new TcpListener(ipAddress, portSolicitar);
            
            listener.Start();

            client = listener.AcceptTcpClient();
            try
            { 
                using (var stream = client.GetStream())
                    while (puertoAbierto)                        
                    {                       
                        using (var output = File.Create(new Configuracion().rutaDescarga + "\\" + archivo.Nombre))
                        {
                            var buffer = new byte[1024];
                            int bytesRead=0;
                            int partes = (int)archivo.Tamaño / size + (archivo.Tamaño % size != 0 ? 1 : 0);
                            int contador = 0;
                            //Reconstruccion del archivo
                            while ((bytesRead += stream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                               // bytesRead; //BytesDescargados                                
                                output.Write(buffer, 0, bytesRead);
                                contador++; //ultimo paquete recibido 
                            }
                        }
                    }
            }
            catch (Exception e)
            {
                File.Create(Configuracion.bitNode + "\\Descargas\\" ); // guardar archivo para continuacion ?
                client.Close();
                client.Dispose();
                puertoAbierto = false;
                Console.Write("errr :v" + e.Message);
            }
        }
        //Otros remplazar
        Random r = new Random();
        private string GenerarNombre() //Genera nombre aleatorio a la maquina
        {
            string ABC = "Q W E R T Y U I O P A S D F G H J K L Ñ Z X C V B N M K";
            return (ABC.Split(' ')[r.Next(0, 28)] + ABC.Split(' ')[r.Next(0, 28)] + ABC.Split(' ')[r.Next(0, 28)] + r.Next(100, 999)).ToString();
        }
        public string KB_GB_MB(long peso)
        {
            if (peso >= 1073741824)
            {
                return Math.Round((peso / Math.Pow(1024, 3)), 2).ToString() + " gb";
            }
            else if (peso >= 1048576)
            {
                return Math.Round((peso / Math.Pow(1024, 2)), 2).ToString() + " mb";
            }
            return Math.Round((peso / 1024F), 2).ToString() + " kb";            
        }
    }
}
