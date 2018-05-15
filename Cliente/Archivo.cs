using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    class Archivo
    {
        //Constructor
        public Archivo(OpenFileDialog ofd)
        {
            this.nombre = ofd.SafeFileName;
            this.ruta = ofd.FileName;
            this.tamaño = new FileInfo(ofd.FileName).Length;
        }
        //Atributos
        public string nombre { get; set; }
        public string ruta { get; set; }
        public string descripcion { get; set; }
        public long tamaño { get; set; }
        public string archivoMD5 { get; set; }
        public bool activo { get; set; } = true;
        //Funciones
        public static string KB_GB_MB(long peso)
        {
            string calculado = "";
            if (peso >= 1073741824)
            {
                calculado = Math.Round((peso / Math.Pow(1024, 3)),2).ToString() + " gb";
            }
            else if (peso >= 1048576)
            {
                calculado = Math.Round((peso / Math.Pow(1024, 2)), 2).ToString() + " mb";
            }
            else
            {
                calculado = Math.Round((peso / 1024F), 2).ToString() + " kb";
            }
            return calculado;
        }
        public static string ObtenerMD5(string direccion)
        {
            MD5 md5Hash = MD5.Create();
            if (!File.Exists(direccion))
                return string.Empty;

            new Thread(() => {
                byte[] data = md5Hash.ComputeHash(File.OpenRead(direccion));
                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString());
                }
                //return sBuilder.ToString();
            }).Start(); 

            return "";
        }
        public static bool CompararMD5(string archivo1,string archivo2)
        {
            StringComparer comparador = StringComparer.OrdinalIgnoreCase;

            if (0 == comparador.Compare(ObtenerMD5(archivo1), ObtenerMD5(archivo2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

/*
 https://msdn.microsoft.com/es-es/library/system.security.cryptography.md5(v=vs.110).aspx
 calcular y ccomparar md5
     */
