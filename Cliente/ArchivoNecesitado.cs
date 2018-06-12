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
        public static List<ArchivoNecesitado> archivosNecesitados;
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
                Partes = new bool[CantidadPartes];
                //-----------------------
                Guardar();
                Hacer(this, "ADD", null);
            }).Start();
        //Atributos
        public static int TamañoParte = 2100;
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
        public void DescargaCompleta()
        {
            if (PartesDescargadas == CantidadPartes)
            {
                //constrolar partes descargadas arreglo de bool
                string ruta = RutaDesarga.Split('.')[0] + "." + Nombre.Split('.')[1];
                if (!File.Exists(ruta))
                    File.Move(RutaDesarga, @ruta);
                else
                {
                    ruta = RutaDesarga.Split('.')[0] + "(bN-" + r.Next(0, 100) + ")." + Nombre.Split('.')[1];
                    File.Move(RutaDesarga, @ruta);
                }
                Hacer(this, "DEL", null);
            }
        }
        public void Eliminar()
        {
            for (int i = 0; i < archivosNecesitados.Count; i++)
            {
                if (Archivo.CompararMD5(archivosNecesitados[i].MD5, MD5))
                {
                    archivosNecesitados.RemoveAt(i);
                    break;
                }
            }
            if (File.Exists(RutaDesarga))
                File.Delete(RutaDesarga);
            if (File.Exists(bnArchivosNecesitados + "\\" + Nombre.Split('.')[0] + ".json"))
                File.Delete(bnArchivosNecesitados + "\\" + Nombre.Split('.')[0] + ".json");
        }
        private static object locker = new object();
        public static int Hacer(object AS, string hacer, object dato)
        {
            lock (locker)
            {
                switch (hacer)
                {
                    case "ADD": //Añadir
                        {
                            archivosNecesitados.Add((ArchivoNecesitado)AS);
                            break;
                        }
                    case "DEL": //Eliminar
                        {
                            ((ArchivoNecesitado)AS).Eliminar();
                            break;
                        }
                    case "DELIP": //EliminarIP
                        {
                            archivosNecesitados.ForEach(an => an.IPsPropietarios.Remove((IPAddress)dato));
                            break;
                        }
                    case "ADDIP": //EliminarIP
                        {
                            archivosNecesitados.ForEach(x => x.agregarIP((IPAddress)dato, (string)AS));
                            break;
                        }
                    case "SAVE": //Guardar
                        {
                            archivosNecesitados.ForEach(x => x.Guardar());
                            break;
                        }
                    case "EXIST": //Existe
                        {
                            return (archivosNecesitados.Exists(x => Archivo.CompararMD5(x.MD5, (string)AS)) ? 1 : 0);
                        }
                    case "L": //Longitud
                        {
                            return archivosNecesitados.Count;
                        }
                    case "EAN":
                        {
                            if (archivosNecesitados.Count > 0)
                            {
                                string archivos = string.Empty;
                                archivosNecesitados.ForEach(x => archivos += ("|" + x.MD5));
                                new Controlador().EnviarUDP((IPAddress)dato, "bitNode@TEA@" + archivos);
                            }
                            break;
                        }
                }
                return 1; //True
            }
        }
    }
}