using Cliente.Controles;
using System;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Cliente
{
    public partial class frmConfigRapidas : Form
    {
        //----------------------------------------------------------------------------------------------Variables
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        PrivateFontCollection pfc = Configuracion.Tipografia();
        Configuracion configuracion = new Configuracion().Leer();

        private botonSwitch bsAnterior;
        //----------------------------------------------------------------------------------------------Constructor del form
        public frmConfigRapidas()
        {
            InitializeComponent();
            bsAnterior = bsNoHacerNada;
            AplicarIdioma();
            AplicarTema();
            pbOk.Click += new EventHandler((object sender, EventArgs e) => { this.Close(); });
        }
        //----------------------------------------------------------------------------------------------Funciones
        private void MoverForm(object sender, MouseEventArgs e) //Mover formulario
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AplicarTema()
        {
            this.BackColor = configuracion.colorFondo;
            pnlContenedor.BackColor = configuracion.colorVistaFondo;
        }
        private void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo((configuracion.latino) ? "ES-AR" : "EN-US");
            lblTitulo.Text = Idioma.StringResources.lblConfiguracionesRapidasTitulo;
            lblDeseo.Text = Idioma.StringResources.lblConfiguracionesRapidasDeseo;
            lblNoHacerNada.Text = Idioma.StringResources.lblConfiguracionesRapidasNoHacerNada;
            lblCerrarApp.Text = Idioma.StringResources.lblConfiguracionesRapidasCerrarApp;
            lblSuspender.Text = Idioma.StringResources.lblConfiguracionesRapidasSuspender;
            lblHibernar.Text = Idioma.StringResources.lblConfiguracionesRapidasHibernar;
            lblApagar.Text = Idioma.StringResources.lblConfiguracionesRapidasApagar;
            lblDescripcion.Text = Idioma.StringResources.lblConfiguracionesRapidasDescripcion;
        }
        private void botonSwitch3_Clickaso(object sender, EventArgs e)
        {
            bsAnterior.Activo = false;
            bsAnterior = (botonSwitch)sender;
            bsAnterior.Activo = true;
            Configuracion.FinalizoDescarga = Convert.ToInt32(bsAnterior.Tag);
        }

        private void frmConfigRapidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                this.Close();
        }
    }
}