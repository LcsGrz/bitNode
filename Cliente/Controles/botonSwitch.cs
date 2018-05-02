using System;
using System.Windows.Forms;

namespace Cliente.Controles
{
    public partial class botonSwitch : UserControl
    {
        private bool activo = true;
        public event EventHandler Clickaso;

        public bool Activo
        {
            get { return activo; }
            set
            {
                activo = value;
                pbON.Visible = (value) ? true : false;
                pbOFF.Visible = (value) ? false : true;
            }
        }

        public botonSwitch()
        {
            InitializeComponent();
        }
        private void CambiarEstado(object sender, EventArgs e)
        {
            activo = !activo;
            pbON.Visible = !pbON.Visible;
            pbOFF.Visible = !pbOFF.Visible;

            if (Clickaso != null)
                Clickaso.Invoke(this, e);
        }
    }
}