﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
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

        PrivateFontCollection pfc;
        Configuracion configuracion = new Configuracion().Leer();
        bool cerrar, TransparenciaFull = false;
        int tagAnterior = 0;

        List<Panel> panelesMenu, panelesVistas;
        //----------------------------------------------------------------------------------------------Constructor del form
        public frmCliente()
        {
            InitializeComponent();

            CargarListas();
            CargarFuentes();
            AplicarIdioma();

            tmrFader.Start();
        }
        //----------------------------------------------------------------------------------------------Funciones de form
        private void pnlBarra_MouseDown(object sender, MouseEventArgs e) //Mover form
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void TimerOn(object sender, EventArgs e) // Inicia el timer para efecto FADE
        {
            cerrar = ((sender as Control).Name == "pbCerrar") ? true : false;
            tmrFader.Start();
        }
        private void ExpandirMenu(object sender, EventArgs e) //Inicia la funcion de expandir el menu Lite - Deluxe
        {
            pnlRojoMenu.Visible = !pnlRojoMenu.Visible;
            panelesMenu[tagAnterior].Controls[0].BackColor = (pnlRojoMenu.Visible) ?configuracion.colorMenuSeleccion : configuracion.colorDetalles;

            if (pnlMenu.Width == 210) //Expandido
            {
                if (configuracion.MenuSlideDeluxe)
                {
                    new Thread(() =>
                    {
                        pnlMenu.Invoke(new Action(() =>
                        {
                            for (int i = 210; i > 65; i -= 3)
                            {
                                pnlMenu.Width = i;

                            }
                            pnlMenu.Width = 65;
                        }));
                    }).Start();
                }
                else
                {
                    pnlMenu.Width = 65;
                }
            }
            else if (pnlMenu.Width == 65) //Contraido
            {
                panelesMenu[tagAnterior].Controls[0].Location = new Point(0, 58); // Lo pongo en su posicion de arranque
                panelesMenu[tagAnterior].Controls[0].Width = 210; // le doy ancho 0
                if (configuracion.MenuSlideDeluxe)
                {
                    new Thread(() =>
                    {
                        pnlMenu.Invoke(new Action(() =>
                        {
                            for (int i = 65; i < 210; i += 9)
                            {
                                pnlMenu.Width = i;
                                pnlMenu.Refresh();
                            }
                            pnlMenu.Width = 210;
                        }));
                    }).Start();
                }
                else
                {
                    pnlMenu.Width = 210;
                }
            }
        }
        private void TBSinFoco(object sender, EventArgs e) //Saca de seleccion el TB de about
        {
            pbTitulo.Focus();
        }
        private void tmrFader_Tick(object sender, EventArgs e) //Faded
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
        private void ClickMenu(object sender, EventArgs e) //Click en los paneles de menu
        {
            int tagNuevo = Convert.ToInt32((sender as Control).Tag) - 1;

            if (tagAnterior != tagNuevo)
            {
                if (pnlMenu.Size.Width == 65)
                {
                    panelesMenu[tagAnterior].Controls[0].BackColor = configuracion.colorFondo;

                    int vY = pnlRojoMenu.Location.Y;
                    int nY = panelesMenu[tagNuevo].Location.Y;
                    if (configuracion.BotonSlideDeluxe)
                    {
                        new Thread(() =>
                        {
                            pnlRojoMenu.Invoke(new Action(() =>
                            {
                                while (vY != nY)
                                {
                                    pnlRojoMenu.Location = new Point(0, (nY > vY) ? ++vY : --vY);
                                }
                            }));
                        }).Start();
                    }
                    else
                    {
                        pnlRojoMenu.Location = new Point(0, nY);
                    }
                }
                else
                {
                    pnlRojoMenu.Location = new Point(0, panelesMenu[tagNuevo].Location.Y); //Mantengo la localizacion del panel rojo vertical
                    panelesMenu[tagNuevo].Controls[0].BackColor = configuracion.colorDetalles; //Le doy el color rojo
                    panelesMenu[tagNuevo].Controls[0].Location = new Point(0, 58); // Lo pongo en su posicion de arranque
                    panelesMenu[tagNuevo].Controls[0].Width = 0; // le doy ancho 0

                    int tagViejo = tagAnterior; // Mantengo tag

                    if (configuracion.BotonSlideDeluxe)
                    {
                        new Thread(() =>
                        {
                            for (int i = 0; i <= 210; i += 1)
                            {
                                pnlMenu.Invoke(new Action(() =>
                                {
                                    panelesMenu[tagViejo].Controls[0].Location = new Point(i, 58);
                                    panelesMenu[tagNuevo].Controls[0].Width = i;
                                }));

                                if (i % 8 == 0)
                                    Thread.Sleep(1);
                            }
                        }).Start();
                    }
                    else
                    {
                        panelesMenu[tagViejo].Controls[0].Location = new Point(210, 58);
                        panelesMenu[tagNuevo].Controls[0].Width = 210;
                    }
                }

                panelesMenu[tagAnterior].BackColor = configuracion.colorFondo;
                panelesVistas[tagAnterior].Visible = false;
                //------------------------------------------------------------------
                panelesMenu[tagNuevo].BackColor = configuracion.colorMenuSeleccion;
                panelesVistas[tagNuevo].Visible = true;
                tagAnterior = tagNuevo;
            }
        }
        //----------------------------------------------------------------------------------------------Funciones
        private void MostrarInformacionPersonal(object sender, EventArgs e) //Mostrar GITHUB - MAIL propio
        {
            string TAG = (sender as PictureBox).Tag.ToString();
            Clipboard.SetDataObject((TAG == "L") ? "lucas.gerez@gmail.com" : "juliomanzano1996@gmail.com");
            System.Diagnostics.Process.Start((TAG == "L") ? "https://github.com/LcsGrz" : "https://github.com/altars99");
            new frmMensaje(Idioma.StringResources.mensajeEmail).ShowDialog();
        }
        private void CargarListas() //Carga las listas de paneles
        {
            panelesMenu = new List<Panel>() { pnlMenuDescargar, pnlMenuExplorar, pnlMenuCompartir, pnlMenuSolicitar, pnlMenuConfiguracion, pnlMenuAbout };
            panelesVistas = new List<Panel>() { pnlVistaDescargar, pnlVistaExplorar, pnlVistaCompartir, pnlVistaSolicitar, pnlVistaConfiguracion, pnlVistaAbout };
        }
        private void CargarFuentes() //Carga las fuentes y las aplica a los componentes
        {
            pfc = Configuracion.Tipografia();

            Font catorceR = new Font(pfc.Families[0], 14);
            Font veintiunoR = new Font(pfc.Families[0], 21);
            //Menu
            foreach (Panel p in panelesMenu)
            {
                p.Controls[1].Font = catorceR;
            }
            //Descargar
            //Explorar
            //Compartir
            //Solicitar
            //Configuracion
            //About
            tbVistaAboutDescripcion.Font = veintiunoR;
        }
        private void AplicarIdioma() //Cambiar de idioma la aplicacion
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo((configuracion.latino) ? "ES-AR" : "EN-US");

            //Menu
            lblMenuDescargar.Text = Idioma.StringResources.lblMenuDescargar;
            lblMenuCompartir.Text = Idioma.StringResources.lblMenuCompartir;
            lblMenuExplorar.Text = Idioma.StringResources.lblMenuExplorar;
            lblMenuSolicitar.Text = Idioma.StringResources.lblMenuSolicitar;
            lblMenuConfiguracion.Text = Idioma.StringResources.lblMenuConfiguracion;
            lblMenuAbout.Text = Idioma.StringResources.lblMenuAbout;
            //Descargar
            //Explorar
            //Compartir
            //Solicitar
            //Configuracion
            //About
            tbVistaAboutDescripcion.Text = Idioma.StringResources.tbVistaAboutDescripcion;
        }
    }
}
/*
 https://stackoverflow.com/questions/2079813/c-sharp-put-pc-to-sleep-or-hibernate
 https://www.codeproject.com/Tips/480049/Shut-Down-Restart-Log-off-Lock-Hibernate-or-Sleep     

  bugs:
     -
    mejoras:
     ver si puedo resumir mas los efectos
  */
