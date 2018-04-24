using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class frmCliente : Form
    {
        //----------------------------------------------------------------------------------------------Variables
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        bool cerrar, TransparenciaFull = false;
        //----------------------------------------------------------------------------------------------Constructor del form
        public frmCliente()
        {
            //puto el que lo encuentra
            InitializeComponent();
            tmrFader.Start();
            pbCerrar.Click += new EventHandler((object sender, EventArgs e) => {
                cerrar = true;
                tmrFader.Start();
            });
            pbMinimizar.Click += new EventHandler((object sender, EventArgs e) => { tmrFader.Start(); });
        }
        //----------------------------------------------------------------------------------------------Funciones de form


        private void pnlBarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmCliente_SizeChanged(object sender, EventArgs e)
        {
            tmrFader.Start();
        }

        private void tmrFader_Tick(object sender, EventArgs e)
        {
            if (TransparenciaFull)
            {
                this.Opacity -= .07;
                if (this.Opacity <= 0)
                {
                    TransparenciaFull = false;
                    if (cerrar)
                    {
                        this.Close();
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                    tmrFader.Stop();
                }
            }
            else
            {
                this.Opacity += .03;
                if (this.Opacity >= 1)
                {
                    TransparenciaFull = true;
                    this.WindowState = FormWindowState.Normal;
                    tmrFader.Stop();
                }
            }
        }
        //----------------------------------------------------------------------------------------------Funciones
    }
}
