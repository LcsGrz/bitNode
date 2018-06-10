using System;
using System.Windows.Forms;

namespace Cliente
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
            BackColor = new Configuracion().Leer().colorVistaFondo;
            tCierre.Start();
        }

        private void tCierre_Tick(object sender, EventArgs e) => this.Close();
    }
}