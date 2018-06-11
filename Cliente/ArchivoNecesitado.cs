using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente
{
    class ArchivoNecesitado
    {
        public static int TamañoParte = 1000;
        private static string bnArchivosNecesitados = Configuracion.bitNode + @"\ArchivosNecesitados";
        public int TamañoUltimaParte { get; set; }
        public string Nombre { get; set; }
        public long Tamaño { get; set; }
        public bool[] Partes { get; set; }
        public string RutaDesarga { get; set; }
        public int ID { get; set; }
        public string MD5 { get; set; }
        public int CantidadPartes { get; set; }
        public ArchivoNecesitado() { }
        public ArchivoNecesitado(Archivo AN)
        {
            new Thread(() =>
            {
                RutaDesarga = new Configuracion().Leer().rutaDescarga + "\\" + AN.Nombre.Split('.')[0] + ".bnp";
                FileStream output = new FileStream(RutaDesarga, FileMode.Append);
                output.SetLength(AN.Tamaño);//Seteo de tamaño de archivo en disco
                output.Close();
                output.Dispose();
                //Datos descarga
                Nombre = AN.Nombre;
                Tamaño = AN.Tamaño;
                CantidadPartes = (int)AN.Tamaño / TamañoParte + (AN.Tamaño % TamañoParte != 0 ? 1 : 0);
                TamañoUltimaParte = (int)AN.Tamaño % TamañoParte;
                ID = Controlador.archivosNecesitados.Count + 1;
                MD5 = AN.ArchivoMD5;
                Partes = new bool[CantidadPartes];
                RellenarBytes();
                //-----------------------
                Guardar();
                Controlador.archivosNecesitados.Add(this);
            }).Start();
        }
        public void Guardar() => File.WriteAllText(bnArchivosNecesitados + "\\" + Nombre.Split('.')[0] + ".json", JsonConvert.SerializeObject(this));
        public List<ArchivoNecesitado> Leer()
        {
            if (!Directory.Exists(bnArchivosNecesitados))
                Directory.CreateDirectory(bnArchivosNecesitados);

            List<ArchivoNecesitado> archivoNecesitados = new List<ArchivoNecesitado>();
            foreach (var file in new DirectoryInfo(bnArchivosNecesitados).GetFiles())
            {
                ArchivoNecesitado an = JsonConvert.DeserializeObject<ArchivoNecesitado>(File.ReadAllText(bnArchivosNecesitados + "\\" + file.Name));
                if (!File.Exists(an.RutaDesarga + "\\" + an.Nombre.Split('.')[0] + ".bnp"))
                {
                    FileStream output = new FileStream(an.RutaDesarga, FileMode.Append);
                    output.SetLength(an.Tamaño);//Seteo de tamaño de archivo en disco
                    output.Close();
                    output.Dispose();
                    an.Partes = new bool[an.CantidadPartes];
                    an.RellenarBytes();
                    an.Guardar();
                }
                archivoNecesitados.Add(an);
            }
            return archivoNecesitados;
        }
        public void RellenarBytes()
        {
            for (int i = 0; i < Partes.Length; i++)
                Partes[i] = false;
        }
        private Random r = new Random();
        //-----------------------------------------------------------
        public void SolicitarPartes()
        {
            for (int i = 0; i < Partes.Length; i++)
            {
                if (!Partes[i])
                {
                    foreach (Archivo aux in Controlador.ArchivosCompartidosVecinos)
                    {

                        if (Archivo.CompararMD5(MD5, aux.ArchivoMD5))
                        {
                            new Controlador().EnviarUDP(aux.IPPropietario[r.Next(0, aux.IPPropietario.Count)], "bitNode@SAD@" + MD5 + "|" + ID + "|" + i);
                            Controlador.SolicitudesActivas--;
                            return;
                        }
                    }
                }
            }
        }
    }
}