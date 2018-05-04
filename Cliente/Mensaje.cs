using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cliente
{
    public partial class ConfiguracionesRapidas : Form
    {
        //----------------------------------------------------------------------------------------------Variables
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        PrivateFontCollection pfc = Configuracion.Tipografia();
        Configuracion configuracion = new Configuracion().Leer();
        //----------------------------------------------------------------------------------------------Constructor del form
        public ConfiguracionesRapidas(string mensaje)
        {
            InitializeComponent();
            AplicarTema();

            pbCheck.Click += new EventHandler((object sender, EventArgs e) => { this.Close(); });

            lblMensaje.Font = new Font(pfc.Families[0], 12);
            lblMensaje.Text = mensaje;

            if (lblMensaje.Width >= 300)
                this.Size = new Size((lblMensaje.Size.Width + 40), 105);

            //lblMensaje.Location = new Point(((pnlMensaje.Size.Width - lblMensaje.Size.Width) / 2), 31);
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
            pnlMensaje.BackColor = (configuracion.temaOscuro) ? configuracion.colorVistaFondo : configuracion.colorVistaFondo;
            pnlBarra.BackColor = (configuracion.temaOscuro) ? Color.FromArgb(255, 153, 153, 153) : Color.FromArgb(255, 197, 33, 35);
            this.BackColor = (configuracion.temaOscuro) ? configuracion.colorFondo : configuracion.colorPanelesInternosVistas;
            panel1.BackColor = (configuracion.temaOscuro) ? configuracion.colorFondo : configuracion.colorPanelesInternosVistas;
            panel2.BackColor = (configuracion.temaOscuro) ? configuracion.colorFondo : configuracion.colorPanelesInternosVistas;
            panel3.BackColor = (configuracion.temaOscuro) ? configuracion.colorFondo : configuracion.colorPanelesInternosVistas;
        }
    }
}