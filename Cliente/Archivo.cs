using Newtonsoft.Json;
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
    public class Archivo
    {
        //Atributos de clase privados
        public static string rutaBN = Configuracion.bitNode + "\\ArchivosCompartidos";
        //Eventos
        public static event EventHandler ArchivoGuardado;
        //Constructor
        public Archivo(OpenFileDialog ofd)
        {
            this.nombre = ofd.SafeFileName;
            this.ruta = ofd.FileName;
            this.tamaño = new FileInfo(ofd.FileName).Length;
        }
        public Archivo() { }
        //Atributos
        public string nombre { get; set; }
        public string ruta { get; set; }
        public string descripcion { get; set; }
        public long tamaño { get; set; }
        public string archivoMD5 { get; set; } = null;
        public bool activo { get; set; } = true;
        //Funciones
        public static string KB_GB_MB(long peso)
        {
            string calculado = "";
            if (peso >= 1073741824)
            {
                calculado = Math.Round((peso / Math.Pow(1024, 3)), 2).ToString() + " gb";
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
        public static bool CompararMD5(string archivo1, string archivo2)
        {
            StringComparer comparador = StringComparer.OrdinalIgnoreCase;
            return (comparador.Compare(ObtenerMD5(archivo1), ObtenerMD5(archivo2)) == 0);
        }
        public static List<Archivo> LeerArchivos()
        {
            List<Archivo> Archivos = new List<Archivo>();

            if (!Directory.Exists(rutaBN))
                Directory.CreateDirectory(rutaBN);

            foreach (var file in new DirectoryInfo(rutaBN).GetFiles())
            {
                Archivos.Add(JsonConvert.DeserializeObject<Archivo>(File.ReadAllText(rutaBN + "\\" + file.Name)));
            }
            return Archivos;
        }
        public void GuardarArchivo()
        {
            new Thread(() =>
            {
                archivoMD5 = archivoMD5 ?? ObtenerMD5(ruta);
                if (archivoMD5 != string.Empty)
                {
                    File.WriteAllText(rutaBN + "\\" + nombre.Split('.')[0] + ".json", JsonConvert.SerializeObject(this));
                    if (!frmCliente.archivosCompartidos.Exists(x => x.archivoMD5.Contains(archivoMD5)))
                        frmCliente.archivosCompartidos.Add(this);
                    ArchivoGuardado?.Invoke(null, null);
                    new frmMensaje(Idioma.StringResources.mensajeExitoCompartirArchivo).ShowDialog();
                    return;
                }
                new frmMensaje(Idioma.StringResources.mensajeErrorCompartirArchivo).ShowDialog();
            }).Start();
        }
        public void EliminarArchivo(int index)
        {
            if (File.Exists(rutaBN + "\\" + nombre.Split('.')[0] + ".json"))
                File.Delete(rutaBN + "\\" + nombre.Split('.')[0] + ".json");
            frmCliente.archivosCompartidos.RemoveAt(index);
            ArchivoGuardado?.Invoke(null, null);
        }
        public void CambiarEstado()
        {
            File.WriteAllText(rutaBN + "\\" + nombre.Split('.')[0] + ".json", JsonConvert.SerializeObject(this));
        }
    }
}

/*
 https://msdn.microsoft.com/es-es/library/system.security.cryptography.md5(v=vs.110).aspx
 calcular y ccomparar md5
     */
