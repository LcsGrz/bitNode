using System.Collections.Generic;
using System.Net;

namespace Cliente
{
    public class ArchivoSolicitado
    {
        public static List<ArchivoSolicitado> archivosSolicitados = new List<ArchivoSolicitado>();
        public IPAddress IPDestino { get; set; }
        public int ParteArchivo { get; set; }
        public int IDPosicion { get; set; }
        public string MD5 { get; set; }
        public int posicionLista { get; set; }
        public static object locker = new object();
        public static int Hacer(object AS, string hacer, object dato)
        {
            lock (locker)
            {
                switch (hacer)
                {
                    case "ADD": //Añadir
                        {
                            ArchivoSolicitado ASAUX = (ArchivoSolicitado)AS;
                            if (!archivosSolicitados.Exists(x => (Archivo.CompararMD5(x.MD5, ASAUX.MD5) && ASAUX.IDPosicion == x.IDPosicion && ASAUX.ParteArchivo == x.ParteArchivo)))
                                archivosSolicitados.Add(ASAUX);
                            break;
                        }
                    case "DEL": //Eliminar
                        {
                            archivosSolicitados.RemoveAt((int)dato);
                            break;
                        }
                    case "DELIP": //Existe
                        {
                            for (int i = 0; i < archivosSolicitados.Count; i++)
                            {
                                if (archivosSolicitados[i].IPDestino.Equals((IPAddress)dato))
                                {
                                    archivosSolicitados.RemoveAt(i);
                                    i = -1;
                                }
                            }
                            break;
                        }
                    case "L":
                        {
                            return archivosSolicitados.Count;
                        }
                }
                return 1; //true
            }
        }
    }
}