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
        //-----------------------------------------------Contructor
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
        //-----------------------------------------------Atributos
        private static string bnArchivosNecesitados = Configuracion.bitNode + @"\ArchivosNecesitados";
        private static Random r = new Random();
        private static object locker = new object();
        public static int TamañoParte = 8192;
        //----------
        public string Nombre { get; set; }
        public string MD5 { get; set; }
        public uint CantidadPartes { get; set; }
        public bool[] Partes { get; set; }
        public uint PartesDescargadas { get; set; } = 0;
        public long Tamaño { get; set; }
        public int TamañoUltimaParte { get; set; }
        public string RutaDesarga { get; set; }
        public bool Estado { get; set; } = false;
        public List<IPAddress> IPsPropietarios = new List<IPAddress>();
        //-----------------------------------------------Metodos
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
        } //Lee la lista de archivos de la carpeta
        public void SolicitarPartes()
        {
            if (!Estado)
            {
                int partes = 0;
                for (int i = partes; i < Partes.Length; i++)
                {
                    if (!Partes[i] && IPsPropietarios.Count > 0)
                    {
                        new Controlador().EnviarUDP(IPsPropietarios[r.Next(0, IPsPropietarios.Count)], "bitNode@SAD@" + MD5 + "|" + i);
                        if (++partes % 10 == 0)
                            break;
                    }
                }
                Thread.Sleep(100);
            }
        } //Solicita partes faltantes a los bitNoders
        public void agregarIP(IPAddress ip, string MD5)
        {
            if (Archivo.CompararMD5(MD5, this.MD5))
                if (!IPsPropietarios.Exists(x => (x.Equals(ip))))
                    IPsPropietarios.Add(ip);
        }  //Agrega una IP nueva al archivo
        public void DescargaCompleta()
        {
            if (PartesDescargadas >= CantidadPartes)
            {
                //constrolar partes descargadas arreglo de bool
                string ruta = RutaDesarga.Split('.')[0] + "." + Nombre.Split('.')[1];
                if (!File.Exists(ruta))
                    File.Move(RutaDesarga, @ruta);
                else
                {
                    ruta = RutaDesarga.Split('.')[0] + "(bN-" + r.Next(0, 999) + ")." + Nombre.Split('.')[1];
                    File.Move(RutaDesarga, @ruta);
                }
                Hacer(this, "CE", null);
            }
            Controlador.InformarEstadoDescarga(0);
        } //Verifica si la descarga fue completada e elimina basura
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
        } //Elimina basura
        public static int Hacer(object AN, string hacer, object dato)
        {
            lock (locker)
            {
                int c = 0;
                for (int i = 0; i < archivosNecesitados.Count; i++)
                {
                    if (!archivosNecesitados[i].Estado)
                        c++;
                }
                switch (hacer)
                {
                    case "ADD": //Añadir
                        {
                            archivosNecesitados.Add((ArchivoNecesitado)AN);
                            Controlador.InformarEstadoDescarga(1);
                            break;
                        }
                    case "DEL": //Eliminar
                        {
                            //((ArchivoNecesitado)AN).Eliminar();
                            archivosNecesitados[(int)AN].Eliminar();
                            break;
                        }
                    case "CE": //CambiarEstado
                        {
                            ((ArchivoNecesitado)AN).Estado = true;
                            break;
                        }
                    case "DELIP": //EliminarIP
                        {
                            archivosNecesitados.ForEach(an => an.IPsPropietarios.Remove((IPAddress)dato));
                            break;
                        }
                    case "ADDIP": //EliminarIP
                        {
                            archivosNecesitados.ForEach(x => x.agregarIP((IPAddress)dato, (string)AN));
                            break;
                        }
                    case "SAVE": //Guardar
                        {
                            archivosNecesitados.ForEach(x => { x.IPsPropietarios.Clear(); x.Guardar(); });
                            break;
                        }
                    case "EXIST": //Existe
                        {
                            return (archivosNecesitados.Exists(x => Archivo.CompararMD5(x.MD5, (string)AN)) ? 1 : 0);
                        }
                    case "L": //Longitud
                        {
                            return c;
                        }
                    case "LC": //LongitudCompleta
                        {
                            return archivosNecesitados.Count;
                        }
                    case "SP": //SolicitarParte
                        {
                            if (c > 0)
                            {
                                archivosNecesitados[r.Next(0, archivosNecesitados.Count)].SolicitarPartes();
                            }
                        }
                        break;
                    case "VE": //SolicitarParte
                        {
                            for (int i = 0; i < archivosNecesitados.Count; i++)
                            {
                                if (!archivosNecesitados[i].Estado)
                                    return 0;
                            }
                            return 1;
                        }
                    case "EAN":
                        {
                            if (Controlador.PermitirSolicitar && c > 0)
                            {
                                Controlador controlador = new Controlador();
                                string archivos = string.Empty;
                                archivosNecesitados.ForEach(x => { if (!x.Estado) archivos += ("|" + x.MD5); });
                                if (AN != null)
                                    controlador.EnviarUDP((IPAddress)dato, "bitNode@TEA@" + archivos);
                                else
                                    Controlador.IPSVecinas.ForEach(x => controlador.EnviarUDP(x, "bitNode@TEA@" + archivos));
                            }
                            break;
                        }
                }
                return 1; //True
            }
        } //HACE TODAS LAS FUNCIONES
    }
}