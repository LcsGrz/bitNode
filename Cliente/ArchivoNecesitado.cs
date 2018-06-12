using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace Cliente
{
    class ArchivoNecesitado
    {
        //Contructor
        public ArchivoNecesitado() { }
        public ArchivoNecesitado(Archivo AN) =>
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
                CantidadPartes = (uint)(AN.Tamaño / TamañoParte + (AN.Tamaño % TamañoParte != 0 ? 1 : 0));
                TamañoUltimaParte = (int)AN.Tamaño % TamañoParte;
                MD5 = AN.ArchivoMD5;
                Partes = new bool[CantidadPartes] ;
                //-----------------------
                Guardar();
                Controlador.archivosNecesitados.Add(this);
            }).Start();
        //Atributos
        public static int TamañoParte = 100;
        private static string bnArchivosNecesitados = Configuracion.bitNode + @"\ArchivosNecesitados";
        public int TamañoUltimaParte { get; set; }
        public string Nombre { get; set; }
        public long Tamaño { get; set; }
        public bool[] Partes { get; set; }
        public string RutaDesarga { get; set; }
        public string MD5 { get; set; }
        public uint CantidadPartes { get; set; }
        public uint PartesDescargadas { get; set; } = 0;

        public List<IPAddress> IPsPropietarios = new List<IPAddress>();
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
                    an.Guardar();
                }
                an.IPsPropietarios = new List<IPAddress>();
                archivoNecesitados.Add(an);
            }
            return archivoNecesitados;
        }
        private Random r = new Random();
        //Metodos
        public void SolicitarPartes()
        {
            int partes = 0;
            for (int i = 0; i < Partes.Length; i++)
            {
                if (!Partes[i] && IPsPropietarios.Count > 0)
                {
                    new Controlador().EnviarUDP(IPsPropietarios[r.Next(0, IPsPropietarios.Count)], "bitNode@SAD@" + MD5 + "|" + i);
                    if (++partes == 10)
                        break;
                }
            }
        }
        public void agregarIP(IPAddress ip, string MD5)
        {
            if (Archivo.CompararMD5(MD5, this.MD5))
                if (!IPsPropietarios.Exists(x => (x.Equals(ip))))
                    IPsPropietarios.Add(ip);
        }
    }
}