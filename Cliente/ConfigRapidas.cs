using Cliente.Controles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            AplicarTema();
            pbOk.Click += new EventHandler((object sender, EventArgs e) => { this.Close(); });
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo((configuracion.latino) ? "ES-AR" : "EN-US");

        }
        //----------------------------------------------------------------------------------------------Funciones
        private void MoverForm(object sender, MouseEventArgs e) //Mover formulario
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void AplicarTema()
        {
            configuracion.CambiarTema();
            this.BackColor = (configuracion.temaOscuro) ? configuracion.colorFondo : configuracion.colorPanelesInternosVistas;
        }

        private void botonSwitch3_Clickaso(object sender, EventArgs e)
        {
            bsAnterior.Activo = false;
            bsAnterior = (botonSwitch)sender;
            bsAnterior.Activo = true;
            Configuracion.FinalizoDescarga = Convert.ToInt32(bsAnterior.Tag);
        }
    }
}
