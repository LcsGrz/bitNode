using Cliente.Controles;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
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
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        Image[] ImagenesArchivos = { Properties.Resources.SwitchON, Properties.Resources.SwitchOFF, Properties.Resources.Cancelar, Properties.Resources.Compartir };
        PrivateFontCollection pfc = Configuracion.Tipografia();
        Configuracion configuracion = new Configuracion().Leer();
        bool cerrar, TransparenciaFull, clickTags, clickDescripcion, ArchivosNecesitadosRecibidos = false;
        int tagAnterior = 0;
        Archivo archivoNuevo;
        Controlador controlador = new Controlador();
        List<Panel> panelesMenu, panelesVistas;
        public static List<Archivo> archivosCompartidos = Archivo.LeerArchivos();
        //----------------------------------------------------------------------------------------------Constructor del form
        public frmCliente() //Constructor del Form - Aplica configuraciones y etc
        {
            InitializeComponent();
            ArchivoNecesitado.archivosNecesitados = new ArchivoNecesitado().Leer();

            CargarListas();
            CargarFuentes();
            CargarConfiguracion();
            AplicarIdioma();
            AplicarTema();
            CargarListaDescargas();

            Archivo.ArchivoGuardado += new EventHandler((object sender, EventArgs e) => { this.Invoke(new Action(() => { CargarArchivosCompatidos(); })); controlador.EnviarUnicoArchivoCompartido((Archivo)sender); });
            Controlador.informarSolicitud += new EventHandler((object sender, EventArgs e) => { this.Invoke(new Action(() => { CargarSolicitudes(); })); });
            NetworkChange.NetworkAddressChanged += new NetworkAddressChangedEventHandler((object sender, EventArgs e) =>
            {
                this.Invoke(new Action(() =>
                {
                    tbVistaConfiguracionIP.Text = "255.255.255.255";
                    lblVistaConfiguracionMiIP.Text = Idioma.StringResources.miIP + Controlador.ObtenerIPLocal();
                    Reconectar(null, null);
                }));
            });
            Controlador.informarBitNoders += new EventHandler((object sender, EventArgs e) => { this.Invoke(new Action(() => { lblVistaConfiguracionBitNoders.Text = Controlador.IPSVecinas.Count + Idioma.StringResources.lblVistaConfiguracionBitNoders; })); });
            Controlador.informarArchivo += new EventHandler((object sender, EventArgs e) => { if (tagAnterior == 1) { this.Invoke(new Action(() => { CargarArchivosCompartidosVecinos(null); })); } });
            Controlador.informarEstadoDescarga += new EventHandler((object sender, EventArgs e) =>
            {
                ArchivosNecesitadosRecibidos = true;
                if (tagAnterior == 0 && ((int)sender) == 1)
                    CargarListaDescargas();
                if (ArchivoNecesitado.Hacer(null, "VE", null) == 1)
                    FinalizaronDescargas();
            });
            controlador.IniciarEjecuciones();
        }
        //----------------------------------------------------------------------------------------------Funciones de form
        private void MoverForm(object sender, MouseEventArgs e) //Mover form
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
            cerrar = ((sender as Control).Name == "pbCerrar");
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
        private void TBSinFoco(object sender, EventArgs e) => pbTitulo.Focus();//Saca de seleccion el TB de about
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

            if (tagNuevo == 0 && ArchivosNecesitadosRecibidos && !tmrModificarAN.Enabled)
                tmrModificarAN.Start();
            if (tagNuevo != 0 && tmrModificarAN.Enabled)
                tmrModificarAN.Stop();

            if (tagNuevo == 1)
            {
                if (!configuracion.SyncActiva)
                    Controlador.ArchivosCompartidosVecinos.Clear();
                if (!Controlador.RecivirACV && configuracion.SyncActiva)
                    controlador.EnviarUDP(null, "bitNode@SAC@");

                Controlador.RecivirACV = true;
                tbVistaExplorarBuscar.Text = Idioma.StringResources.tbVistaExplorarBuscar;
                TBSinFoco(null, null);
                CargarArchivosCompartidosVecinos(null);
            }
            if (tagNuevo == 3)
                pbMenuSolicitar.Image = Properties.Resources.SolictarOFF;

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
                        pnlRojoMenu.Location = new Point(0, nY);
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
                            pnlMenu.Invoke(new Action(() =>
                            {
                                for (int i = 0; i <= 210; i += 1)
                                {
                                    panelesMenu[tagViejo].Controls[0].Location = new Point(i, 58);
                                    panelesMenu[tagNuevo].Controls[0].Width = i;

                                    if (i % 20 == 0)
                                        this.Refresh(); //Thread.Sleep(1);
                                }
                                panelesMenu[tagViejo].Controls[0].BackColor = configuracion.colorMenu;
                            }));
                        }).Start();
                    }
                    else
                    {
                        panelesMenu[tagViejo].Controls[0].Location = new Point(210, 58);
                        panelesMenu[tagNuevo].Controls[0].Width = 210;
                    }
                }

                panelesMenu[tagAnterior].BackColor = configuracion.colorMenu;
                panelesVistas[tagAnterior].Visible = false;
                //------------------------------------------------------------------
                panelesMenu[tagNuevo].BackColor = configuracion.colorMenuSeleccion;
                panelesMenu[tagNuevo].Controls[0].BackColor = (pnlRojoMenu.Visible) ? Color.Transparent : configuracion.colorDetalles;

                panelesVistas[tagNuevo].Visible = true;
                tagAnterior = tagNuevo;
            }
        }
        private void bitNodeClosing(object sender, FormClosingEventArgs e) => controlador.FrenarEjecuciones(); //Evento de cerrado del form
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

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                HotkeyPrefix = HotkeyPrefix.None,
                FormatFlags = StringFormatFlags.NoWrap
            };
            e.Graphics.DrawString(e.ToolTipText, diezR, Brushes.White, e.Bounds, sf);
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
                case 15:
                    {
                        configuracion.SyncActiva = (sender as botonSwitch).Activo;
                        lblVistaExplorarArchivosCompartidosVecinos.Text = (configuracion.SyncActiva) ? Idioma.StringResources.lblVistaExplorarSyncON : Idioma.StringResources.lblVistaExplorarSyncOFF;
                        Controlador.ArchivosCompartidosVecinos.Clear();
                        Controlador.RecivirACV = false;
                        new frmMensaje((configuracion.SyncActiva) ? Idioma.StringResources.msjSyncON : Idioma.StringResources.msjSyncOFF).ShowDialog();
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
            bsVistaConfiguracionBuscar.Activo = configuracion.SyncActiva;
            bsVistaConfiguracionLatino.Activo = configuracion.latino;
            bsVistaConfiguracionEfectoFade.Activo = configuracion.InicioFadeDeluxe;
            bsVistaConfiguracionEfectoBotones.Activo = configuracion.BotonSlideDeluxe;
            bsVistaConfiguracionEfectoMenu.Activo = configuracion.MenuSlideDeluxe;
            bsVistaConfiguracionTema.Activo = configuracion.temaOscuro;
            bnudVistaConfiguracionLimiteSubida.valor = configuracion.limiteSubida;
            bnudVistaConfiguracionLimiteBajada.valor = configuracion.limiteBajada;
            bnudVistaConfiguracionDescargasSimultaneas.valor = configuracion.limiteDesacargas;
            ttAyuda.SetToolTip(pbVistaConfiguracionCarpetaDescarga, configuracion.rutaDescarga);
            tbVistaConfiguracionIP.Text = configuracion.IPConeccion;
        }
        private void CargarFuentes() //Carga las fuentes y las aplica a los componentes
        {
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
            dgvVistaDescargas.ColumnHeadersDefaultCellStyle.Font = catorceR;
            dgvVistaDescargas.DefaultCellStyle.Font = doceR;
            //Explorar
            lblVistaExplorarArchivosCompartidosVecinos.Font = veintiunoR;
            tbVistaExplorarBuscar.Font = doceR;
            dgvVistaExplorarArchivosCompartidosVecinos.ColumnHeadersDefaultCellStyle.Font = catorceR;
            dgvVistaExplorarArchivosCompartidosVecinos.DefaultCellStyle.Font = doceR;
            //Compartir
            lblVistaCompartirSeleccionar.Font = dieciseisR;
            lblVistaCompartirNombreArchivo.Font = dieciseisR;
            lblVistaCompartirTamañoArchivo.Font = dieciseisR;
            tbVistaCompartirDescripcionArchivo.Font = doceR;
            tbVistaCompartirTags.Font = doceR;
            lblVistaCompartirVerArchivos.Font = veintiunoR;
            dgvVistaCompartirArchivos.ColumnHeadersDefaultCellStyle.Font = catorceR;
            dgvVistaCompartirArchivos.DefaultCellStyle.Font = doceR;
            //Solicitar
            lblVistaSolicitarInformacion.Font = dieciseisR;
            tbVistaSolicitarDescripcion.Font = doceR;
            lblVistaSolicitarNuevasSolicitudes.Font = veintiunoR;
            dgvVistaSolicitar.ColumnHeadersDefaultCellStyle.Font = catorceR;
            dgvVistaSolicitar.DefaultCellStyle.Font = doceR;
            //Configuracion
            lblVistaConfiguracionGeneral.Font = veinticuatroR;
            lblVistaConfiguracionIniciarConWindows.Font = catorceR;
            lblVistaConfiguracionMinimizarBanjeda.Font = catorceR;
            lblVistaConfiguracionNombre.Font = catorceR;
            tbVistaConfiguracionNombre.Font = catorceR;
            lblVistaConfiguracionSyncAuto.Font = catorceR;
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
            lblVistaConfiguracionIP.Font = catorceR;
            tbVistaConfiguracionIP.Font = catorceR;
            lblVistaConfiguracionBitNoders.Font = catorceR;
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
            ttAyuda.SetToolTip(pbVistaDescargarStart, Idioma.StringResources.ttDescargar);
            ttAyuda.SetToolTip(pbVistaDescargarStop, Idioma.StringResources.ttDetener);
            lblVistaDescargarExplorar.Text = Idioma.StringResources.lblVistaDescargarExplorar;
            dgvVistaDescargas.Columns.Clear();
            foreach (string n in Idioma.StringResources.CabecerasDGVDescargar.Split('-'))
                dgvVistaDescargas.Columns.Add(n, n);
            dgvVistaDescargas.Columns.Add(new DataGridViewImageColumn() { Name = Idioma.StringResources.CabecerasDGVArchivoCompartidoEliminar });
            //Explorar
            lblVistaExplorarArchivosCompartidosVecinos.Text = (configuracion.SyncActiva) ? Idioma.StringResources.lblVistaExplorarSyncON : Idioma.StringResources.lblVistaExplorarSyncOFF;
            tbVistaExplorarBuscar.Text = Idioma.StringResources.tbVistaExplorarBuscar;
            dgvVistaExplorarArchivosCompartidosVecinos.Columns.Clear();
            foreach (string n in Idioma.StringResources.CabecerasDGVArchivoCompartidoArreglo.Split('-'))
                dgvVistaExplorarArchivosCompartidosVecinos.Columns.Add(n, n);
            dgvVistaExplorarArchivosCompartidosVecinos.Columns.Add(new DataGridViewImageColumn() { Name = Idioma.StringResources.lblMenuDescargar });
            //Compartir
            tbVistaCompartirDescripcionArchivo.Text = Idioma.StringResources.tbVistaCompartirDescripcionArchivo;
            tbVistaCompartirTags.Text = Idioma.StringResources.tbVistaCompartirTags;
            lblVistaCompartirSeleccionar.Text = Idioma.StringResources.lblVistaCompartirSeleccionar;
            lblVistaCompartirVerArchivos.Text = Idioma.StringResources.lblVistaCompartirVerArchivos;
            dgvVistaCompartirArchivos.Columns.Clear();
            foreach (string n in Idioma.StringResources.CabecerasDGVArchivoCompartidoArreglo.Split('-'))
                dgvVistaCompartirArchivos.Columns.Add(n, n);
            dgvVistaCompartirArchivos.Columns.Add(new DataGridViewImageColumn() { Name = Idioma.StringResources.CabecerasDGVArchivoCompartidoActivo });
            dgvVistaCompartirArchivos.Columns.Add(new DataGridViewImageColumn() { Name = Idioma.StringResources.CabecerasDGVArchivoCompartidoEliminar });
            CargarArchivosCompatidos();
            //Solicitar
            lblVistaSolicitarInformacion.Text = Idioma.StringResources.lblVistaSolicitarInformacion;
            tbVistaSolicitarDescripcion.Text = Idioma.StringResources.tbVistaCompartirDescripcionArchivo;
            lblVistaSolicitarNuevasSolicitudes.Text = Idioma.StringResources.lblVistaSolicitarNuevasSolicitudes;
            dgvVistaSolicitar.Columns.Clear();
            foreach (string n in Idioma.StringResources.CabecerasDGVSolcitarArreglo.Split('-'))
                dgvVistaSolicitar.Columns.Add(n, n);
            dgvVistaSolicitar.Columns.Add(new DataGridViewImageColumn() { Name = Idioma.StringResources.CabecerasDGVSolicitarCompartir });
            dgvVistaSolicitar.Columns.Add(new DataGridViewImageColumn() { Name = Idioma.StringResources.CabecerasDGVArchivoCompartidoEliminar });
            //Configuracion
            lblVistaConfiguracionGeneral.Text = Idioma.StringResources.lblVistaConfiguracionGeneral;
            lblVistaConfiguracionIniciarConWindows.Text = Idioma.StringResources.lblVistaConfiguracionIniciarConWindows;
            lblVistaConfiguracionMinimizarBanjeda.Text = Idioma.StringResources.lblVistaConfiguracionMinimizarBanjeda;
            lblVistaConfiguracionNombre.Text = Idioma.StringResources.lblVistaConfiguracionNombre;
            lblVistaConfiguracionSyncAuto.Text = Idioma.StringResources.lblVistaConfiguracionSyncAuto;
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
            lblVistaConfiguracionIP.Text = Idioma.StringResources.lblVistaConfiguracionIP;
            ttAyuda.SetToolTip(pbVistaConfiguracionReconectar, Idioma.StringResources.ttReconectar);
            lblVistaConfiguracionMiIP.Text = Idioma.StringResources.miIP + Controlador.ObtenerIPLocal();
            lblVistaConfiguracionBitNoders.Text = Controlador.IPSVecinas.Count + Idioma.StringResources.lblVistaConfiguracionBitNoders;
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
            if ((sender as TextBox).Name == "tbVistaCompartirDescripcionArchivo" && !clickDescripcion)
                clickDescripcion = true;
            else if ((sender as TextBox).Name == "tbVistaCompartirTags" && !clickTags)
                clickTags = true;
        }
        private void SeleccionarArchivoCompartir(object sender, EventArgs e) //Selecciona el archivo que quiere compartir y muestra sus datos
        {
            if (ofdArchivo.ShowDialog() == DialogResult.OK && ofdArchivo.OpenFile() != null)
            {
                archivoNuevo = new Archivo(ofdArchivo);
                lblVistaCompartirNombreArchivo.Text = archivoNuevo.Nombre;
                lblVistaCompartirTamañoArchivo.Text = Archivo.KB_GB_MB(archivoNuevo.Tamaño);
                tbVistaCompartirDescripcionArchivo.Text = Idioma.StringResources.tbVistaCompartirDescripcionArchivo;

                pnlVistaCompartirGuardarArchivo.Visible = !(pnlVistaCompartirSeleccionarArchivo.Visible = false);
            }
        }
        private void CompartirCancelarArchivo(object sender, EventArgs e) //Comparte o cancela el archivo
        {
            if (Convert.ToInt32((sender as PictureBox).Tag) == 1)
            {
                if (tbVistaCompartirDescripcionArchivo.TextLength == 0 || !clickDescripcion)
                {
                    new frmMensaje(Idioma.StringResources.msjDescripcion).ShowDialog();
                    return;
                }

                string[] lista = tbVistaCompartirTags.Text.Split(' ');
                archivoNuevo.tags = new List<string>();
                for (int i = 0; i < lista.Length; i++)
                {
                    if (lista[i] != string.Empty)
                        archivoNuevo.tags.Add(lista[i]);
                }
                if (tbVistaCompartirTags.TextLength == 0 || !clickTags || archivoNuevo.tags.Count < 5)
                {
                    new frmMensaje(Idioma.StringResources.msjTagNull).ShowDialog();
                    return;
                }

                archivoNuevo.Descripcion = tbVistaCompartirDescripcionArchivo.Text;
                archivoNuevo.GuardarArchivo();
            }
            else
            {
                archivoNuevo = null;
            }
            tbVistaCompartirDescripcionArchivo.Text = Idioma.StringResources.tbVistaCompartirDescripcionArchivo;
            tbVistaCompartirTags.Text = Idioma.StringResources.tbVistaCompartirTags;
            pnlVistaCompartirSeleccionarArchivo.Visible = !(pnlVistaCompartirGuardarArchivo.Visible = false);
            TBSinFoco(null, null);
            clickTags = false;
            clickDescripcion = false;
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
            pnlVistaDescargarContenedor.BackColor = configuracion.colorPanelesInternosVistas;
            //-----------------------------------------------------------------------------------
            dgvVistaDescargas.DefaultCellStyle.BackColor = configuracion.colorPanelesInternosVistas;
            dgvVistaDescargas.DefaultCellStyle.SelectionBackColor = configuracion.colorPanelesInternosVistas;
            dgvVistaDescargas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 153, 153, 153);
            dgvVistaDescargas.DefaultCellStyle.ForeColor = Color.FromArgb(255, 153, 153, 153);
            dgvVistaDescargas.ColumnHeadersDefaultCellStyle.BackColor = configuracion.colorFondo;
            dgvVistaDescargas.ColumnHeadersDefaultCellStyle.ForeColor = configuracion.colorDetalles;
            dgvVistaDescargas.BackgroundColor = configuracion.colorPanelesInternosVistas;
            dgvVistaDescargas.GridColor = configuracion.colorFondo;
            //Explorar
            pnlVistaExplorarDGV.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaExploarBuscar.BackColor = configuracion.colorPanelesInternosVistas;
            tbVistaExplorarBuscar.BackColor = configuracion.colorMenuSeleccion;
            //-----------------------------------------------------------------------------------
            dgvVistaExplorarArchivosCompartidosVecinos.DefaultCellStyle.BackColor = configuracion.colorPanelesInternosVistas;
            dgvVistaExplorarArchivosCompartidosVecinos.DefaultCellStyle.SelectionBackColor = configuracion.colorPanelesInternosVistas;
            dgvVistaExplorarArchivosCompartidosVecinos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 153, 153, 153);
            dgvVistaExplorarArchivosCompartidosVecinos.DefaultCellStyle.ForeColor = Color.FromArgb(255, 153, 153, 153);
            dgvVistaExplorarArchivosCompartidosVecinos.ColumnHeadersDefaultCellStyle.BackColor = configuracion.colorFondo;
            dgvVistaExplorarArchivosCompartidosVecinos.ColumnHeadersDefaultCellStyle.ForeColor = configuracion.colorDetalles;
            dgvVistaExplorarArchivosCompartidosVecinos.BackgroundColor = configuracion.colorPanelesInternosVistas;
            dgvVistaExplorarArchivosCompartidosVecinos.GridColor = configuracion.colorFondo;
            //Compartir
            pnlVistaCompartirSeleccionarArchivo.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaCompartirGuardarArchivo.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaCompartirMostarArchivos.BackColor = configuracion.colorPanelesInternosVistas;
            tbVistaCompartirDescripcionArchivo.BackColor = configuracion.colorMenuSeleccion;
            tbVistaCompartirTags.BackColor = configuracion.colorMenuSeleccion;
            pnlVistaCompartirSeparador.BackColor = configuracion.colorFondo;
            //-----------------------------------------------------------------------------------
            dgvVistaCompartirArchivos.DefaultCellStyle.BackColor = configuracion.colorPanelesInternosVistas;
            dgvVistaCompartirArchivos.DefaultCellStyle.SelectionBackColor = configuracion.colorPanelesInternosVistas;
            dgvVistaCompartirArchivos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 153, 153, 153);
            dgvVistaCompartirArchivos.DefaultCellStyle.ForeColor = Color.FromArgb(255, 153, 153, 153);
            dgvVistaCompartirArchivos.ColumnHeadersDefaultCellStyle.BackColor = configuracion.colorFondo;
            dgvVistaCompartirArchivos.ColumnHeadersDefaultCellStyle.ForeColor = configuracion.colorDetalles;
            dgvVistaCompartirArchivos.BackgroundColor = configuracion.colorPanelesInternosVistas;
            dgvVistaCompartirArchivos.GridColor = configuracion.colorFondo;
            //Solicitar
            pnlVistaSolicitarCompartirSolicitud.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaSolicitarVerSolicitudes.BackColor = configuracion.colorPanelesInternosVistas;
            tbVistaSolicitarDescripcion.BackColor = configuracion.colorMenuSeleccion;
            //-----------------------------------------------------------------------------------
            dgvVistaSolicitar.DefaultCellStyle.BackColor = configuracion.colorPanelesInternosVistas;
            dgvVistaSolicitar.DefaultCellStyle.SelectionBackColor = configuracion.colorPanelesInternosVistas;
            dgvVistaSolicitar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 153, 153, 153);
            dgvVistaSolicitar.DefaultCellStyle.ForeColor = Color.FromArgb(255, 153, 153, 153);
            dgvVistaSolicitar.ColumnHeadersDefaultCellStyle.BackColor = configuracion.colorFondo;
            dgvVistaSolicitar.ColumnHeadersDefaultCellStyle.ForeColor = configuracion.colorDetalles;
            dgvVistaSolicitar.BackgroundColor = configuracion.colorPanelesInternosVistas;
            dgvVistaSolicitar.GridColor = configuracion.colorFondo;
            //Configuracion
            pnlVistaComfiguracionGeneral.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaComfiguracionInterfaz.BackColor = configuracion.colorPanelesInternosVistas;
            pnlVistaConfiguracionTransferencias.BackColor = configuracion.colorPanelesInternosVistas;
            tbVistaConfiguracionNombre.BackColor = configuracion.colorFondo;
            tbVistaConfiguracionIP.BackColor = configuracion.colorFondo;
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
        private void CambiarCursorDGV(object sender, DataGridViewCellMouseEventArgs e) //Cambiar de cursor en DGV
        {
            switch ((sender as DataGridView).Tag.ToString())
            {
                case "D":
                    {
                        dgvVistaDescargas.Cursor = (e.ColumnIndex.Equals(4) && e.RowIndex != -1) ? Cursors.Hand : Cursors.Arrow;
                        break;
                    }
                case "E":
                    {
                        dgvVistaExplorarArchivosCompartidosVecinos.Cursor = (e.ColumnIndex.Equals(3) && e.RowIndex != -1) ? Cursors.Hand : Cursors.Arrow;
                        break;
                    }
                case "C":
                    {
                        dgvVistaCompartirArchivos.Cursor = ((e.ColumnIndex.Equals(3) || e.ColumnIndex.Equals(4)) && e.RowIndex != -1) ? Cursors.Hand : Cursors.Arrow;
                        break;
                    }
                case "S":
                    {
                        dgvVistaSolicitar.Cursor = ((e.ColumnIndex.Equals(2) || e.ColumnIndex.Equals(3)) && e.RowIndex != -1) ? Cursors.Hand : Cursors.Arrow;
                        break;
                    }
            }

        }
        private void SolicitarArchivo(object sender, EventArgs e) //Enviar solicitud de archivo
        {
            controlador.EnviarUDP(null, "bitNode@SOLICITAR@" + configuracion.nombre + "|" + tbVistaSolicitarDescripcion.Text);
            new frmMensaje(Idioma.StringResources.msgSolicitarArchivo).ShowDialog();
            tbVistaSolicitarDescripcion.Text = Idioma.StringResources.tbVistaCompartirDescripcionArchivo;
            TBSinFoco(null, null);
        }
        private void CargarSolicitudes() //Carga las solicitudes en la vista
        {
            dgvVistaSolicitar.Visible = !(lblVistaSolicitarNuevasSolicitudes.Visible = (Controlador.Solicitudes.Count == 0));
            pbMenuSolicitar.Image = (Controlador.Solicitudes.Count > 0) ? Properties.Resources.SolicitarON : Properties.Resources.SolictarOFF;
            if (Controlador.Solicitudes.Count > 0)
            {
                //Datos
                dgvVistaSolicitar.Rows.Clear();
                for (int i = 0; i < Controlador.Solicitudes.Count; i++)
                {
                    string[] S = Controlador.Solicitudes[i].Split('|');
                    dgvVistaSolicitar.Rows.Insert(i, S[0], S[1], ImagenesArchivos[3], ImagenesArchivos[2]);
                }
                //Vista
                dgvVistaSolicitar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVistaSolicitar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVistaSolicitar.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaSolicitar.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVistaSolicitar.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaSolicitar.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void ActivoBorrarArchivo(object sender, DataGridViewCellEventArgs e) //Click en Activo-Eliminar DGVCompatir
        {
            if (dgvVistaCompartirArchivos.CurrentCell != null && dgvVistaCompartirArchivos.CurrentCell.Value != null && e.RowIndex != -1)
            {
                if (e.ColumnIndex.Equals(3)) //Activo = 3
                {
                    archivosCompartidos[e.RowIndex].Activo = !archivosCompartidos[e.RowIndex].Activo;
                    dgvVistaCompartirArchivos.CurrentCell.Value = ImagenesArchivos[(archivosCompartidos[e.RowIndex].Activo) ? 0 : 1];
                    archivosCompartidos[e.RowIndex].CambiarEstado();
                    MessageBox.Show(archivosCompartidos[e.RowIndex].Activo.ToString());
                    if (archivosCompartidos[e.RowIndex].Activo)
                        controlador.EnviarUnicoArchivoCompartido(archivosCompartidos[e.RowIndex]);
                    else
                        controlador.EnviarUDP(null, "bitNode@EAC@" + archivosCompartidos[e.RowIndex].ArchivoMD5);
                }
                else if (e.ColumnIndex.Equals(4))//Borrar = 4
                {
                    controlador.EnviarUDP(null, "bitNode@EAC@" + archivosCompartidos[e.RowIndex].ArchivoMD5);
                    archivosCompartidos[e.RowIndex].EliminarArchivo(e.RowIndex);
                    dgvVistaCompartirArchivos.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        private void CompartirBorrarSolicitud(object sender, DataGridViewCellEventArgs e) //Click en Compartir-Eliminar DGVSolicitar
        {
            if (dgvVistaSolicitar.CurrentCell != null && dgvVistaSolicitar.CurrentCell.Value != null && e.RowIndex != -1)
            {
                if (e.ColumnIndex.Equals(2)) //Compartir = 2
                {
                    ClickMenu(new Control() { Tag = 3 }, null);
                }
                Controlador.Solicitudes.RemoveAt(e.RowIndex);
                CargarSolicitudes();
            }
            TBSinFoco(null, null);
        }
        private void DescargarArchivo(object sender, DataGridViewCellEventArgs e) //Click en descargar archivo
        {
            if (dgvVistaExplorarArchivosCompartidosVecinos.CurrentCell != null && dgvVistaExplorarArchivosCompartidosVecinos.CurrentCell.Value != null && e.RowIndex != -1)
                if (e.ColumnIndex.Equals(3)) //Activo = 3
                    controlador.InicializarArchivo(e.RowIndex);
        }
        private void Reconectar(object sender, EventArgs e) //Iniciar la reconeccion
        {
            if (IPAddress.TryParse(tbVistaConfiguracionIP.Text, out IPAddress ip))
            {
                configuracion.IPConeccion = tbVistaConfiguracionIP.Text;
                configuracion.Guardar();
                Controlador.RecivirACV = (tagAnterior == 1);
                controlador.VaciarIPS();
                controlador.VaciarACV();
                dgvVistaExplorarArchivosCompartidosVecinos.Rows.Clear();
                lblVistaConfiguracionBitNoders.Text = "0" + Idioma.StringResources.lblVistaConfiguracionBitNoders;
                controlador.EnviarUDP(ip, "bitNode@PPING@" + (IPAddress.Broadcast.Equals(IPAddress.Parse(configuracion.IPConeccion)) ? "OK" : "IPFIJA") + "|" + (Controlador.RecivirACV && configuracion.SyncActiva));
            }
            else
            {
                tbVistaConfiguracionIP.Text = IPAddress.Broadcast.ToString();
                new frmMensaje(Idioma.StringResources.mensajeErrorIP).ShowDialog();
            }
            TBSinFoco(null, null);
        }
        private void IPaPortapapeles(object sender, EventArgs e) //Copiar direccion IP propia a portapapeles
        {
            Clipboard.SetDataObject(Controlador.ObtenerIPLocal().ToString());
            new frmMensaje(Idioma.StringResources.msjIPPortapapeles).ShowDialog();
        }

        private void IniciarDescargas(object sender, EventArgs e) //Inicia las descargas
        {
            if (!Controlador.PermitirSolicitar)
            {
                pbVistaDescargarStart.Image = Properties.Resources.PlayON;
                pbVistaDescargarStop.Image = Properties.Resources.StopOFF;
                Controlador.PermitirSolicitar = true;
                ArchivoNecesitado.archivosNecesitados = new ArchivoNecesitado().Leer();
                ArchivoNecesitado.Hacer(null, "EAN", null);
                controlador.ManejadorNecesitados();
            }
        }

        private void FrenarDescargas(object sender, EventArgs e) //Frena las descargas
        {
            if (Controlador.PermitirSolicitar)
            {
                pbVistaDescargarStart.Image = Properties.Resources.PlayOFF;
                pbVistaDescargarStop.Image = Properties.Resources.StopON;
                Controlador.PermitirSolicitar = false;
                ArchivoNecesitado.Hacer(null, "SAVE", null);
                // ArchivoNecesitado.archivosNecesitados.Clear();
                controlador.EnviarUDP(null, "bitNode@EAS@");
            }
        }
        private void CargarListaDescargas()
        {
            int ANC = ArchivoNecesitado.Hacer(null, "LC", null);
            dgvVistaDescargas.Visible = !(lblVistaDescargarExplorar.Visible = (ANC == 0));
            if (ANC > 0)
            {
                //Datos
                dgvVistaDescargas.Rows.Clear();
                for (int i = 0; i < ANC; i++)
                {
                    ArchivoNecesitado A = ArchivoNecesitado.archivosNecesitados[i];
                    long tamaño = (A.Estado) ? A.Tamaño : (ArchivoNecesitado.TamañoParte < A.Tamaño) ? A.PartesDescargadas * ArchivoNecesitado.TamañoParte : A.Tamaño;
                    dgvVistaDescargas.Rows.Insert(i, A.Nombre, Archivo.KB_GB_MB(tamaño), Archivo.KB_GB_MB(A.Tamaño), (A.PartesDescargadas * 100) / A.CantidadPartes + "%", ImagenesArchivos[2]);
                    if (A.Estado)
                    {
                        dgvVistaDescargas[0, i].Style.ForeColor = configuracion.colorDetalles;
                        dgvVistaDescargas[0, i].Style.SelectionForeColor = configuracion.colorDetalles;
                        dgvVistaDescargas[3, i].Style.ForeColor = configuracion.colorDetalles;
                        dgvVistaDescargas[3, i].Style.SelectionForeColor = configuracion.colorDetalles;
                    }
                }
                //Vista
                dgvVistaDescargas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVistaDescargas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVistaDescargas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVistaDescargas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaDescargas.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaDescargas.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaDescargas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        } //Carga la lista de descargas en la vista

        private void EliminarDescarga(object sender, DataGridViewCellEventArgs e) //Elimina la descarga Activa/No
        {
            if (dgvVistaDescargas.CurrentCell != null && dgvVistaDescargas.CurrentCell.Value != null && e.RowIndex != -1)
                if (e.ColumnIndex.Equals(4))//Activo = 3
                {
                    ArchivoNecesitado.Hacer(e.RowIndex, "DEL", null);
                    CargarListaDescargas();
                }
        }

        private void BuscarArchivoPorTag(object sender, EventArgs e) //Busca archivos por tags
        {
            TBSinFoco(null, null);

            string[] lista = tbVistaExplorarBuscar.Text.Split(' ');
            string msj = string.Empty;
            for (int i = 0; i < lista.Length; i++)
            {
                if (lista[i] != string.Empty)
                    msj += lista[i];
            }
            //------------------------------------------------------------
            if (configuracion.SyncActiva)
                CargarArchivosCompartidosVecinos((msj == string.Empty) ? null : Archivo.TagArchivo(Controlador.ArchivosCompartidosVecinos, msj));
            else
            {
                dgvVistaExplorarArchivosCompartidosVecinos.Rows.Clear();
                Controlador.ArchivosCompartidosVecinos.Clear();
                controlador.EnviarUDP(null, "bitNode@SACTAG@" + ((msj == string.Empty) ? "NOTAG" : msj));
            }
        }
        private void CargarArchivosCompatidos() //Carga los archivos compartidos en la vista
        {
            dgvVistaCompartirArchivos.Visible = !(lblVistaCompartirVerArchivos.Visible = (archivosCompartidos.Count == 0));
            if (archivosCompartidos.Count > 0)
            {
                //Datos
                dgvVistaCompartirArchivos.Rows.Clear();
                for (int i = 0; i < archivosCompartidos.Count; i++)
                {
                    Archivo A = archivosCompartidos[i];
                    dgvVistaCompartirArchivos.Rows.Insert(i, A.Nombre, Archivo.KB_GB_MB(A.Tamaño), A.Descripcion, ImagenesArchivos[(A.Activo) ? 0 : 1], ImagenesArchivos[2]);
                }
                //Vista
                dgvVistaCompartirArchivos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVistaCompartirArchivos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVistaCompartirArchivos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaCompartirArchivos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaCompartirArchivos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVistaCompartirArchivos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaCompartirArchivos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void CargarArchivosCompartidosVecinos(List<Archivo> lista) //Carga los archivos en la vista Explorar
        {
            List<Archivo> archivos = lista ?? Controlador.ArchivosCompartidosVecinos;
            dgvVistaExplorarArchivosCompartidosVecinos.Rows.Clear();
            lblVistaExplorarArchivosCompartidosVecinos.Text = (configuracion.SyncActiva) ? Idioma.StringResources.lblVistaExplorarSyncON : Idioma.StringResources.lblVistaExplorarSyncOFF;
            dgvVistaExplorarArchivosCompartidosVecinos.Visible = !(lblVistaExplorarArchivosCompartidosVecinos.Visible = (Controlador.ArchivosCompartidosVecinos.Count == 0));
            if (archivos.Count > 0)
            {
                //Datos
                for (int i = 0; i < archivos.Count; i++)
                {
                    Archivo A = archivos[i];
                    dgvVistaExplorarArchivosCompartidosVecinos.Rows.Insert(i, A.Nombre, Archivo.KB_GB_MB(A.Tamaño), A.Descripcion, Properties.Resources.Descargar);
                }
                //Vista
                dgvVistaExplorarArchivosCompartidosVecinos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVistaExplorarArchivosCompartidosVecinos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVistaExplorarArchivosCompartidosVecinos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaExplorarArchivosCompartidosVecinos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvVistaExplorarArchivosCompartidosVecinos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvVistaExplorarArchivosCompartidosVecinos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
        private void CargarNuevosValoresDescargados(object sender, EventArgs e)//Actualiza los valores de la vista 'descargas'
        {
            ArchivosNecesitadosRecibidos = false;
            int ANC = ArchivoNecesitado.Hacer(null, "LC", null);
            dgvVistaDescargas.Visible = !(lblVistaDescargarExplorar.Visible = (ANC == 0));
            if (ANC > 0)
            {
                for (int i = 0; i < ANC; i++)
                {
                    ArchivoNecesitado A = ArchivoNecesitado.archivosNecesitados[i];
                    long tamaño = (A.Estado) ? A.Tamaño : (ArchivoNecesitado.TamañoParte < A.Tamaño) ? A.PartesDescargadas * ArchivoNecesitado.TamañoParte : A.Tamaño;
                    dgvVistaDescargas[1, i].Value = Archivo.KB_GB_MB(tamaño);
                    dgvVistaDescargas[3, i].Value = (A.PartesDescargadas * 100) / A.CantidadPartes + "%";
                    if (A.Estado)
                    {
                        dgvVistaDescargas[0, i].Style.ForeColor = configuracion.colorDetalles;
                        dgvVistaDescargas[0, i].Style.SelectionForeColor = configuracion.colorDetalles;
                        dgvVistaDescargas[3, i].Style.ForeColor = configuracion.colorDetalles;
                        dgvVistaDescargas[3, i].Style.SelectionForeColor = configuracion.colorDetalles;
                    }
                }
            }
        }
        private void FinalizaronDescargas() //Ejecutar funcion especial cuando finaliza la descarga
        {
            tmrModificarAN.Stop();
            switch (Configuracion.FinalizoDescarga)
            {
                case 1:
                    {
                        Close();
                        break;
                    }
                case 2:
                    {
                        Application.SetSuspendState(PowerState.Suspend, true, true);
                        break;
                    }
                case 3:
                    {
                        Application.SetSuspendState(PowerState.Hibernate, true, true);
                        break;
                    }
                case 4:
                    {

                        Process.Start("shutdown", "/s /t 0");
                        break;
                    }
            }
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
