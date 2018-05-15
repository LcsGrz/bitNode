using Cliente.Idioma;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public partial class frmSplash : Form
    {
        Configuracion configuracion = new Configuracion().Leer();
        public frmSplash()
        {
            InitializeComponent();
            this.BackColor = configuracion.colorVistaFondo;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo((configuracion.latino) ? "ES-AR" : "EN-US");
            pnlEstado.BackColor = configuracion.colorDetalles;
            //LeerArchivos();
            tCierre.Start();
            lblTextoCarga.Text = "paco";
        }

        private void tCierre_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LeerArchivos() {
            lblTextoCarga.Text = Idioma.StringResources.splashCargandoArchivos;
            frmCliente.archivosCompartidos = Archivo.LeerArchivos();
            Thread.Sleep(2000);
           // lblTextoCarga.Text = "paco";
        }

        private void frmSplash_Activated(object sender, EventArgs e)
        {
            LeerArchivos();
            lblTextoCarga.Text = "paco";
        }
    }
}