using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public class Archivo
    {
        //Atributos de clase privados
        public static string rutaBN = Configuracion.bitNode + "\\ArchivosCompartidos";
        //Eventos
        public static event EventHandler ArchivoGuardado;
        //Constructor
        public Archivo(OpenFileDialog ofd)
        {
            this.Nombre = ofd.SafeFileName;
            this.Ruta = ofd.FileName;
            this.Tamaño = new FileInfo(ofd.FileName).Length;
        }
        public Archivo() { }
        //Atributos
        public string Nombre { get; set; }
        public string Ruta { get; set; }
        public string Descripcion { get; set; }
        public long Tamaño { get; set; }
        public string ArchivoMD5 { get; set; } = null;
        public bool Activo { get; set; } = true;
        public List<string> tags;
        public List<IPAddress> IPPropietario;
        //Funciones
        public static string KB_GB_MB(long peso)
        {
            if (peso >= 1073741824)
            {
                return Math.Round((peso / Math.Pow(1024, 3)), 2).ToString() + " gb";
            }
            else if (peso >= 1048576)
            {
                return Math.Round((peso / Math.Pow(1024, 2)), 2).ToString() + " mb";
            }
            else
            {
                return Math.Round((peso / 1024F), 2).ToString() + " kb";
            }
        }
        public static string ObtenerMD5(string direccion)
        {
            if (!File.Exists(direccion))
                return string.Empty;

            MD5 md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(File.OpenRead(direccion));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString());
            }
            return sBuilder.ToString();
        }
        public static bool CompararMD5(string MD5A1, string MD5A2) => (StringComparer.OrdinalIgnoreCase.Compare(MD5A1, MD5A2) == 0);
        public static List<Archivo> LeerArchivos()
        {
            List<Archivo> Archivos = new List<Archivo>();

            if (!Directory.Exists(rutaBN))
                Directory.CreateDirectory(rutaBN);

            foreach (var file in new DirectoryInfo(rutaBN).GetFiles())
            {
                Archivo a = JsonConvert.DeserializeObject<Archivo>(File.ReadAllText(rutaBN + "\\" + file.Name));
                if (File.Exists(a.Ruta))
                {
                    Archivos.Add(a);
                }
                else
                {
                    File.Delete(rutaBN + "\\" + a.Nombre.Split('.')[0] + ".json");
                }
            }
            return Archivos;
        }
        public void GuardarArchivo() => new Thread(() =>
        {
            ArchivoMD5 = ArchivoMD5 ?? ObtenerMD5(Ruta);
            if (ArchivoMD5 != string.Empty)
            {
                bool existe = false;
                File.WriteAllText(rutaBN + "\\" + Nombre.Split('.')[0] + ".json", JsonConvert.SerializeObject(this));
                frmCliente.archivosCompartidos.ForEach(x =>
                {
                    if (CompararMD5(x.ArchivoMD5, ArchivoMD5))
                    {
                        existe = true;
                        x = this;
                    }
                });
                if (!existe)
                    frmCliente.archivosCompartidos.Add(this);
                ArchivoGuardado?.Invoke(this, null);
                new frmMensaje(Idioma.StringResources.mensajeExitoCompartirArchivo).ShowDialog();
                return;
            }
            new frmMensaje(Idioma.StringResources.mensajeErrorCompartirArchivo).ShowDialog();
        }).Start();
        public void EliminarArchivo(int index)
        {
            if (File.Exists(rutaBN + "\\" + Nombre.Split('.')[0] + ".json"))
                File.Delete(rutaBN + "\\" + Nombre.Split('.')[0] + ".json");
            frmCliente.archivosCompartidos.RemoveAt(index);
        }
        public void CambiarEstado() => File.WriteAllText(rutaBN + "\\" + Nombre.Split('.')[0] + ".json", JsonConvert.SerializeObject(this));
        public static bool ArchivoEnDisco(string ruta) => File.Exists(ruta);
    }
}
