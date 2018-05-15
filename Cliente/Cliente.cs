using Cliente.Controles;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
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
        Archivo archivoNuevo;

        List<Panel> panelesMenu, panelesVistas;
        public static List<Archivo> archivosCompartidos = Archivo.LeerArchivos();
        //----------------------------------------------------------------------------------------------Constructor del form
        public frmCliente() //Constructor del Form - Aplica configuraciones y etc
        {
            InitializeComponent();

            CargarListas();
            CargarFuentes();
            CargarConfiguracion();
            CargarArchivosCompatidos();
            AplicarIdioma();
            AplicarTema();

            Archivo.ArchivoGuardado += new EventHandler((object sender, EventArgs e) => { this.Invoke(new Action(() => { CargarArchivosCompatidos(); })); });
        }
        //----------------------------------------------------------------------------------------------Funciones de form
        private void pnlBarra_MouseDown(object sender, MouseEventArgs e) //Mover form
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Maximizar(object sender, EventArgs e) //Maximizar de bandeja de entrada
        {
            this.Show();
            niMinimizar.Visible = false;
            if (configuracion.InicioFadeDeluxe)
            {
                tmrFader.Start();
                return;
            }
            this.Opacity = 1;
            TransparenciaFull = true;
            this.WindowState = FormWindowState.Normal;
        }
        private void TimerOn(object sender, EventArgs e) // Inicia el timer para efecto FADE
        {
            cerrar = ((sender as Control).Name == "pbCerrar") ? true : false;
            tmrFader.Start();
        }
        private void ExpandirMenu(object sender, EventArgs e) //Inicia la funcion de expandir el menu Lite - Deluxe
        {
            pnlRojoMenu.Visible = !pnlRojoMenu.Visible;
            panelesMenu[tagAnterior].Controls[0].BackColor = (pnlRojoMenu.Visible) ? Color.Transparent : configuracion.colorDetalles;

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
                if (!configuracion.InicioFadeDeluxe)
                    this.Opacity = 0;
            }
            else
            {
                this.Opacity += .03;
                if (!configuracion.InicioFadeDeluxe)
                    this.Opacity = 1;
            }
            if (this.Opacity == 0)
            {
                TransparenciaFull = false;
                if (cerrar)
                {
                    this.Close();
                }
                else if (!configuracion.minimizarBandeja)
                {
                    this.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    this.Hide();
                    niMinimizar.Visible = true;
                }
                tmrFader.Stop();
            }
            else if (this.Opacity == 1)
            {
                TransparenciaFull = true;
                this.WindowState = FormWindowState.Normal;
                tmrFader.Stop();
            }
        }
        private void ClickMenu(object sender, EventArgs e) //Click en los paneles de menu
        {
            int tagNuevo = Convert.ToInt32((sender as Control).Tag) - 1;

            if (tagAnterior != tagNuevo)
            {
                if (pnlMenu.Size.Width == 65)
                {
                    panelesMenu[tagAnterior].Controls[0].BackColor = configuracion.colorMenu;

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

                panelesMenu[tagAnterior].BackColor = configuracion.colorMenu;
                panelesMenu[tagAnterior].Controls[0].BackColor = configuracion.colorMenu;

                panelesVistas[tagAnterior].Visible = false;
                //------------------------------------------------------------------
                panelesMenu[tagNuevo].BackColor = configuracion.colorMenuSeleccion;
                panelesMenu[tagNuevo].Controls[0].BackColor = (pnlRojoMenu.Visible) ? Color.Transparent : configuracion.colorDetalles;

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
            panelesVistas = new List<Panel>() { pnlVistaDescargar, pnlVistaExplorar, pnlVistaCompartir, pnlVistaSolicitar, pnlVistaConfiguracionGeneral, pnlVistaAbout };
        }
        private void SeleccionarCarpetaDescargas(object sender, EventArgs e) //Selecciona la carpeta de descargas
        {
            fbdNavegador.SelectedPath = configuracion.rutaDescarga;
            if (fbdNavegador.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbdNavegador.SelectedPath))
            {
                configuracion.rutaDescarga = fbdNavegador.SelectedPath;
                ttAyuda.SetToolTip(pbVistaConfiguracionCarpetaDescarga, configuracion.rutaDescarga);
                configuracion.Guardar();
            }
        }
        private void ttAyuda_Draw(object sender, DrawToolTipEventArgs e) //Dibuja el tooltip
        {
            Font diezR = new Font(pfc.Families[0], 10); //fuente personalizada
            ttAyuda.BackColor = configuracion.colorFondo;
            e.DrawBackground();
            e.DrawBorder();

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            sf.FormatFlags = StringFormatFlags.NoWrap;
            e.Graphics.DrawString(e.ToolTipText, diezR, Brushes.White, e.Bounds, sf);
            // e.Graphics.DrawString(e.ToolTipText, diezR, Brushes.White, new PointF(2, 2));
        }
        private void ttAyuda_Popup(object sender, PopupEventArgs e) //Dibuja el tooltip
        {
            Font diezR = new Font(pfc.Families[0], 10);
            e.ToolTipSize = TextRenderer.MeasureText(ttAyuda.GetToolTip(e.AssociatedControl), diezR);
            e.ToolTipSize = Size.Add(e.ToolTipSize, new Size(4, 4));
        }
        private void CambiarConfiguracion(object sender, EventArgs e) //Cambia la configuracion de la clase y aplica algunas al form
        {
            switch (Convert.ToInt32((sender as Control).Tag))
            {
                case 11:
                    {
                        configuracion.iniciarConWindows = (sender as botonSwitch).Activo;
                        IniciarConWindows();
                        break;
                    }
                case 12:
                    {
                        configuracion.minimizarBandeja = (sender as botonSwitch).Activo;
                        break;
                    }
                case 13:
                    {
                        configuracion.latino = (sender as botonSwitch).Activo;
                        AplicarIdioma();
                        break;
                    }
                case 14:
                    {
                        configuracion.nombre = (sender as TextBox).Text;
                        break;
                    }
                case 21:
                    {
                        configuracion.InicioFadeDeluxe = (sender as botonSwitch).Activo;
                        break;
                    }
                case 22:
                    {
                        configuracion.BotonSlideDeluxe = (sender as botonSwitch).Activo;
                        break;
                    }
                case 23:
                    {
                        configuracion.MenuSlideDeluxe = (sender as botonSwitch).Activo;
                        break;
                    }
                case 24:
                    {
                        configuracion.temaOscuro = (sender as botonSwitch).Activo;
                        AplicarTema();
                        break;
                    }
                case 31:
                    {
                        configuracion.limiteBajada = (sender as botonNUD).valor;
                        break;
                    }
                case 32:
                    {
                        configuracion.limiteSubida = (sender as botonNUD).valor;
                        break;
                    }
                case 33:
                    {
                        configuracion.limiteDesacargas = (sender as botonNUD).valor;
                        break;
                    }
            }
            configuracion.Guardar();
        }
        private void CargarConfiguracion() //Carga la configuracion de la clase a los controles
        {
            bsVistaConfiguracionIniciarConWindows.Activo = configuracion.iniciarConWindows;
            bsVistaConfiguracionMinimizarBandeja.Activo = configuracion.minimizarBandeja;
            tbVistaConfiguracionNombre.Text = configuracion.nombre;
            bsVistaConfiguracionLatino.Activo = configuracion.latino;
            bsVistaConfiguracionEfectoFade.Activo = configuracion.InicioFadeDeluxe;
            bsVistaConfiguracionEfectoBotones.Activo = configuracion.BotonSlideDeluxe;
            bsVistaConfiguracionEfectoMenu.Activo = configuracion.MenuSlideDeluxe;
            bsVistaConfiguracionTema.Activo = configuracion.temaOscuro;
            bnudVistaConfiguracionLimiteSubida.valor = configuracion.limiteSubida;
            bnudVistaConfiguracionLimiteBajada.valor = configuracion.limiteBajada;
            bnudVistaConfiguracionDescargasSimultaneas.valor = configuracion.limiteDesacargas;
            ttAyuda.SetToolTip(pbVistaConfiguracionCarpetaDescarga, configuracion.rutaDescarga);
        }
        private void CargarFuentes() //Carga las fuentes y las aplica a los componentes
        {
            pfc = Configuracion.Tipografia();

            Font ochoR = new Font(pfc.Families[0], 8);
            Font diezR = new Font(pfc.Families[0], 10);
            Font doceR = new Font(pfc.Families[0], 12);
            Font catorceR = new Font(pfc.Families[0], 14);
            Font dieciseisR = new Font(pfc.Families[0], 16);
            Font veintiunoR = new Font(pfc.Families[0], 21);
            Font veinticuatroR = new Font(pfc.Families[0], 24);
            //Menu
            foreach (Panel p in panelesMenu)
            {
                p.Controls[1].Font = catorceR;
            }
            lblMenuConfiguracionesR.Font = doceR;
            lblMenuCRapidas.Font = doceR;
            //Descargar
            //Explorar
            //Compartir
            lblVistaCompartirSeleccionar.Font = dieciseisR;
            lblVistaCompartirNombreArchivo.Font = dieciseisR;
            lblVistaCompartirTamañoArchivo.Font = dieciseisR;
            tbVistaCompartirDescripcionArchivo.Font = doceR;
            lblVistaCompartirVerArchivos.Font = veintiunoR;
            //Solicitar
            //Configuracion
            lblVistaConfiguracionGeneral.Font = veinticuatroR;
            lblVistaConfiguracionIniciarConWindows.Font = catorceR;
            lblVistaConfiguracionMinimizarBanjeda.Font = catorceR;
            lblVistaConfiguracionNombre.Font = catorceR;
            tbVistaConfiguracionNombre.Font = doceR;
            lblVistaConfiguracionIdioma.Font = catorceR;
            lblVistaConfiguracionIngles.Font = catorceR;
            lblVistaConfiguracionEspañol.Font = catorceR;
            lblVistaConfiguracionInterfaz.Font = veinticuatroR;
            lblVistaConfiguracionEfectoFade.Font = catorceR;
            lblVistaConfiguracionEfectoBotones.Font = catorceR;
            lblVistaConfiguracionMovimientoMenu.Font = catorceR;
            lblVistaConfiguracionTema.Font = catorceR;
            lblVistaConfiguracionTemaClaro.Font = catorceR;
            lblVistaConfiguracionTemaOscuro.Font = catorceR;
            lblVistaConfiguracionTranseferecias.Font = veinticuatroR;
            lblVistaConfiguracionLimiteSubida.Font = catorceR;
            lblVistaConfiguracionLimiteBajada.Font = catorceR;
            lblVistaConfiguracionKbpsSubida.Font = catorceR;
            lblVistaConfiguracionKbpsBajada.Font = catorceR;
            lblVistaConfiguracionLimiteDescargas.Font = catorceR;
            lblVistaConfiguracionRutaDescarga.Font = catorceR;
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
            lblMenuConfiguracionesR.Text = Idioma.StringResources.lblMenuConfiguracionesR;
            lblMenuCRapidas.Text = Idioma.StringResources.lblMenuCRapidas;
            //Descargar
            //Explorar
            //Compartir
            tbVistaCompartirDescripcionArchivo.Text = Idioma.StringResources.tbVistaCompartirDescripcionArchivo;
            lblVistaCompartirSeleccionar.Text = Idioma.StringResources.lblVistaCompartirSeleccionar;
            lblVistaCompartirVerArchivos.Text = Idioma.StringResources.lblVistaCompartirVerArchivos;
            //Solicitar
            //Configuracion
            lblVistaConfiguracionGeneral.Text = Idioma.StringResources.lblVistaConfiguracionGeneral;
            lblVistaConfiguracionIniciarConWindows.Text = Idioma.StringResources.lblVistaConfiguracionIniciarConWindows;
            lblVistaConfiguracionMinimizarBanjeda.Text = Idioma.StringResources.lblVistaConfiguracionMinimizarBanjeda;
            lblVistaConfiguracionNombre.Text = Idioma.StringResources.lblVistaConfiguracionNombre;
            lblVistaConfiguracionIdioma.Text = Idioma.StringResources.lblVistaConfiguracionIdioma;
            lblVistaConfiguracionIngles.Text = Idioma.StringResources.lblVistaConfiguracionIngles;
            lblVistaConfiguracionEspañol.Text = Idioma.StringResources.lblVistaConfiguracionEspañol;
            lblVistaConfiguracionInterfaz.Text = Idioma.StringResources.lblVistaConfiguracionInterfaz;
            lblVistaConfiguracionEfectoFade.Text = Idioma.StringResources.lblVistaConfiguracionEfectoFade;
            lblVistaConfiguracionEfectoBotones.Text = Idioma.StringResources.lblVistaConfiguracionEfectoBotones;
            lblVistaConfiguracionMovimientoMenu.Text = Idioma.StringResources.lblVistaConfiguracionMovimientoMenu;
            lblVistaConfiguracionTema.Text = Idioma.StringResources.lblVistaConfiguracionTema;
            lblVistaConfiguracionTemaClaro.Text = Idioma.StringResources.lblVistaConfiguracionTemaClaro;
            lblVistaConfiguracionTemaOscuro.Text = Idioma.StringResources.lblVistaConfiguracionTemaOscuro;
            lblVistaConfiguracionTranseferecias.Text = Idioma.StringResources.lblVistaConfiguracionTranseferecias;
            lblVistaConfiguracionLimiteSubida.Text = Idioma.StringResources.lblVistaConfiguracionLimiteSubida;
            lblVistaConfiguracionLimiteBajada.Text = Idioma.StringResources.lblVistaConfiguracionLimiteBajada;
            lblVistaConfiguracionLimiteDescargas.Text = Idioma.StringResources.lblVistaConfiguracionLimiteDescargas;
            lblVistaConfiguracionRutaDescarga.Text = Idioma.StringResources.lblVistaConfiguracionRutaDescarga;
            //About
            tbVistaAboutDescripcion.Text = Idioma.StringResources.tbVistaAboutDescripcion;
        }
        private void AbrirConfigRapidas(object sender, EventArgs e) //Abre el form de configuraciones rapidas
        {
            new frmConfigRapidas().ShowDialog();
        }
        private void BorrarTB(object sender, EventArgs e)//Borrar TextBox
        {
            (sender as TextBox).Clear();
        }
        private void SeleccionarArchivoCompartir(object sender, EventArgs e) //Selecciona el archivo que quiere compartir y muestra sus datos
        {
            if (ofdArchivo.ShowDialog() == DialogResult.OK && ofdArchivo.OpenFile() != null)
            {
                archivoNuevo = new Archivo(ofdArchivo);
                lblVistaCompartirNombreArchivo.Text = archivoNuevo.nombre;
                lblVistaCompartirTamañoArchivo.Text = Archivo.KB_GB_MB(archivoNuevo.tamaño);
                tbVistaCompartirDescripcionArchivo.Text = Idioma.StringResources.tbVistaCompartirDescripcionArchivo;

                pnlVistaCompartirSeleccionarArchivo.Visible = false;
                pnlVistaCompartirGuardarArchivo.Visible = true;
            }
        }
        private void CompartirCancelarArchivo(object sender, EventArgs e) //Comparte o cancela el archivo
        {
            if (Convert.ToInt32((sender as PictureBox).Tag) == 1)
            {
                archivoNuevo.descripcion = tbVistaCompartirDescripcionArchivo.Text;
                archivoNuevo.GuardarArchivo();
                CargarArchivosCompatidos();
            }
            else
            {
                archivoNuevo = null;
            }
            tbVistaCompartirDescripcionArchivo.Text = Idioma.StringResources.tbVistaCompartirDescripcionArchivo;
            pnlVistaCompartirSeleccionarArchivo.Visible = !(pnlVistaCompartirGuardarArchivo.Visible = false);
            TBSinFoco(null, null);
        }
        private void AplicarTema() //Aplica el tema seleccionado 
        {
            configuracion.CambiarTema();
            //HUD
            pnlBarra.BackColor = configuracion.colorFondo;
            pnlBarraGris1Px.BackColor = (configuracion.temaOscuro) ? Color.FromArgb(255, 153, 153, 153) : Color.FromArgb(255, 197, 33, 35);
            pnlMenu.BackColor = configuracion.colorMenu;
            for (int i = 0; i < 6; i++)
            {
                panelesMenu[i].BackColor = (tagAnterior == i) ? configuracion.colorMenuSeleccion : configuracion.colorMenu;
                panelesMenu[i].Controls[0].BackColor = Color.Transparent;
                panelesVistas[i].BackColor = configuracion.colorVistaFondo;
            }
            panelesMenu[tagAnterior].Controls[0].BackColor = (pnlMenu.Width == 65) ? Color.Transparent : configuracion.colorDetalles;
            //Descargar
            //Explorar
            //Compartir
            pnlVistaCompartirSeleccionarArchivo.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaCompartirGuardarArchivo.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaCompartirMostarArchivos.BackColor = configuracion.colorPanelesInternosVistas;
            //Solicitar
            //Configuracion
            pnlVistaComfiguracionGeneral.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaComfiguracionInterfaz.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaConfiguracionTransferencias.BackColor = configuracion.colorPanelesInternosVistas;
            tbVistaConfiguracionNombre.BackColor = configuracion.colorVistaFondo;
            //About
            tbVistaAboutDescripcion.BackColor = configuracion.colorVistaFondo;
        }
        private void IniciarConWindows() //Iniciar con windows
        {
            string nombre = Path.GetFileName(Application.ExecutablePath);
            string ruta = Path.GetFullPath(nombre);
            try
            {
                if (configuracion.iniciarConWindows)
                {
                    Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true).SetValue(ruta, nombre);
                }
                else
                {
                    Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true).DeleteValue(ruta, false);
                }
            }
            catch (Exception)
            {
                configuracion.iniciarConWindows = !configuracion.iniciarConWindows;
                new frmMensaje(Idioma.StringResources.MensajeIniciarConWindows).ShowDialog();
                bsVistaConfiguracionIniciarConWindows.Activo = configuracion.iniciarConWindows;
            }
        }
        private void CargarArchivosCompatidos() //Carga los archivos compartidos en la vista
        {
            dgvVistaCompartirArchivos.Visible = !(lblVistaCompartirVerArchivos.Visible = (archivosCompartidos.Count == 0));
            dgvVistaCompartirArchivos.DataSource = null;
            dgvVistaCompartirArchivos.DataSource = (archivosCompartidos.Count > 0) ? archivosCompartidos : null;
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
     ir agregando fonts a cargar guentes
  */
