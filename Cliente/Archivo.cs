using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Archivo
    {
        public string nombre { get; set; }
        public string ruta { get; set; }
        public string descripcion { get; set; }
        public double tamaño { get; set; }
        public double MD5 { get; set; }
        public bool activo { get; set; }
    }
}
