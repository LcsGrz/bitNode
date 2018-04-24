using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente.Controles
{
    public partial class botonSwitch : UserControl
    {
      private Configuracion configuracion;
        private bool activo = true;
        public Color ColorDetalle
        {
            get { return pbActivado.BackColor; }
            set { pbActivado.BackColor = value; }
        }
        public bool Activo
        {
            get { return activo; }
            set
            {
                activo = value;
                pbActivado.Visible = (value) ? true : false;
                pbDesactivado.Visible = (value) ? false : true;
            }
        }
       
        public botonSwitch()
        {
            InitializeComponent();
            ActualizarColor();
        }
        //Puto el que lee
        private void CambiarEstado(object sender, EventArgs e)
        {
            activo = !activo;
            pbActivado.Visible = !pbActivado.Visible;
            pbDesactivado.Visible = !pbDesactivado.Visible;

        }
        //Y mas puto el que sigue leyendo
        public void ActualizarColor()
        {
           configuracion = new Configuracion().Leer();
         //   this.BackColor = configuracion.colorVistaFondo;
        }
    }
}
//puedo hacer que el valor la toque directamente desde configuracion, convendra?, si putito escucha a tu corazon/