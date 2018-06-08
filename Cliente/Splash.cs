using System;
using System.Windows.Forms;

namespace Cliente
{
    public partial class frmSplash : Form
    {
        Configuracion configuracion = new Configuracion().Leer();
        public frmSplash()
        {
            InitializeComponent();
            BackColor = configuracion.colorVistaFondo;
            tCierre.Start();
        }

        private void tCierre_Tick(object sender, EventArgs e) => this.Close();
    }
}