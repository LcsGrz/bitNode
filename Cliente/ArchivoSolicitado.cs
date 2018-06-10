using System.Net;

namespace Cliente
{
    public class ArchivoSolicitado
    {
        public IPAddress IPDestino { get; set; }
        public int ParteArchivo { get; set; }
        public int IDPosicion { get; set; }
        public string MD5 { get; set; }
        public int posicionLista { get; set; }
    }
}