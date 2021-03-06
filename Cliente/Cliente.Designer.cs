﻿namespace Cliente
{
    partial class frmCliente
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.pbCerrar = new System.Windows.Forms.PictureBox();
            this.pbMinimizar = new System.Windows.Forms.PictureBox();
            this.pbTitulo = new System.Windows.Forms.PictureBox();
            this.pbIcono = new System.Windows.Forms.PictureBox();
            this.tmrFader = new System.Windows.Forms.Timer(this.components);
            this.pnlBarraGris1Px = new System.Windows.Forms.Panel();
            this.pnlVistaContenedor = new System.Windows.Forms.Panel();
            this.pnlVistaDescargar = new System.Windows.Forms.Panel();
            this.pnlVistaDescargarContenedor = new System.Windows.Forms.Panel();
            this.pbVistaDescargarStop = new System.Windows.Forms.PictureBox();
            this.pbVistaDescargarStart = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVistaDescargarExplorar = new System.Windows.Forms.Label();
            this.dgvVistaDescargas = new System.Windows.Forms.DataGridView();
            this.NombreArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descargado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TamañoArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BorraraArchivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlVistaExplorar = new System.Windows.Forms.Panel();
            this.pnlVistaExploarBuscar = new System.Windows.Forms.Panel();
            this.pbVistaExplorarBuscar = new System.Windows.Forms.PictureBox();
            this.tbVistaExplorarBuscar = new System.Windows.Forms.TextBox();
            this.pnlVistaExplorarDGV = new System.Windows.Forms.Panel();
            this.lblVistaExplorarArchivosCompartidosVecinos = new System.Windows.Forms.Label();
            this.dgvVistaExplorarArchivosCompartidosVecinos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlVistaCompartir = new System.Windows.Forms.Panel();
            this.pnlVistaCompartirMostarArchivos = new System.Windows.Forms.Panel();
            this.lblVistaCompartirVerArchivos = new System.Windows.Forms.Label();
            this.dgvVistaCompartirArchivos = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamaño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlVistaCompartirGuardarArchivo = new System.Windows.Forms.Panel();
            this.pnlVistaCompartirSeparador = new System.Windows.Forms.Panel();
            this.tbVistaCompartirTags = new System.Windows.Forms.TextBox();
            this.tbVistaCompartirDescripcionArchivo = new System.Windows.Forms.TextBox();
            this.pbVistaCompartirCancelar = new System.Windows.Forms.PictureBox();
            this.pbVistaCompartirArchivo = new System.Windows.Forms.PictureBox();
            this.lblVistaCompartirTamañoArchivo = new System.Windows.Forms.Label();
            this.lblVistaCompartirNombreArchivo = new System.Windows.Forms.Label();
            this.pnlVistaCompartirSeleccionarArchivo = new System.Windows.Forms.Panel();
            this.lblVistaCompartirSeleccionar = new System.Windows.Forms.Label();
            this.pbVistaCompartirSeleccionarArchivo = new System.Windows.Forms.PictureBox();
            this.pnlVistaSolicitar = new System.Windows.Forms.Panel();
            this.pnlVistaSolicitarVerSolicitudes = new System.Windows.Forms.Panel();
            this.lblVistaSolicitarNuevasSolicitudes = new System.Windows.Forms.Label();
            this.dgvVistaSolicitar = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlVistaSolicitarCompartirSolicitud = new System.Windows.Forms.Panel();
            this.lblVistaSolicitarInformacion = new System.Windows.Forms.Label();
            this.tbVistaSolicitarDescripcion = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlVistaConfiguracionGeneral = new System.Windows.Forms.Panel();
            this.lblVistaConfiguracionSyncAuto = new System.Windows.Forms.Label();
            this.bsVistaConfiguracionBuscar = new Cliente.Controles.botonSwitch();
            this.lblVistaConfiguracionBitNoders = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionMiIP = new System.Windows.Forms.Label();
            this.pbVistaConfiguracionReconectar = new System.Windows.Forms.PictureBox();
            this.tbVistaConfiguracionIP = new System.Windows.Forms.TextBox();
            this.lblVistaConfiguracionIP = new System.Windows.Forms.Label();
            this.tbVistaConfiguracionNombre = new System.Windows.Forms.TextBox();
            this.lblVistaConfiguracionNombre = new System.Windows.Forms.Label();
            this.bnudVistaConfiguracionDescargasSimultaneas = new Cliente.Controles.botonNUD();
            this.bnudVistaConfiguracionLimiteBajada = new Cliente.Controles.botonNUD();
            this.bnudVistaConfiguracionLimiteSubida = new Cliente.Controles.botonNUD();
            this.lblVistaConfiguracionEfectoBotones = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionMovimientoMenu = new System.Windows.Forms.Label();
            this.pnlVistaComfiguracionInterfaz = new System.Windows.Forms.Panel();
            this.lblVistaConfiguracionInterfaz = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionEfectoFade = new System.Windows.Forms.Label();
            this.pnlVistaConfiguracionTransferencias = new System.Windows.Forms.Panel();
            this.lblVistaConfiguracionTranseferecias = new System.Windows.Forms.Label();
            this.bsVistaConfiguracionEfectoFade = new Cliente.Controles.botonSwitch();
            this.bsVistaConfiguracionIniciarConWindows = new Cliente.Controles.botonSwitch();
            this.bsVistaConfiguracionEfectoMenu = new Cliente.Controles.botonSwitch();
            this.pnlVistaComfiguracionGeneral = new System.Windows.Forms.Panel();
            this.lblVistaConfiguracionGeneral = new System.Windows.Forms.Label();
            this.bsVistaConfiguracionEfectoBotones = new Cliente.Controles.botonSwitch();
            this.bsVistaConfiguracionMinimizarBandeja = new Cliente.Controles.botonSwitch();
            this.pbVistaConfiguracionCarpetaDescarga = new System.Windows.Forms.PictureBox();
            this.lblVistaConfiguracionMinimizarBanjeda = new System.Windows.Forms.Label();
            this.bsVistaConfiguracionTema = new Cliente.Controles.botonSwitch();
            this.lblVistaConfiguracionIniciarConWindows = new System.Windows.Forms.Label();
            this.bsVistaConfiguracionLatino = new Cliente.Controles.botonSwitch();
            this.lblVistaConfiguracionTema = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionRutaDescarga = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionKbpsBajada = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionKbpsSubida = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionLimiteSubida = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionLimiteBajada = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionLimiteDescargas = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionTemaClaro = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionIngles = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionTemaOscuro = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionEspañol = new System.Windows.Forms.Label();
            this.lblVistaConfiguracionIdioma = new System.Windows.Forms.Label();
            this.pnlVistaAbout = new System.Windows.Forms.Panel();
            this.tbVistaAboutDescripcion = new System.Windows.Forms.TextBox();
            this.pbVistaAboutBotonJulio = new System.Windows.Forms.PictureBox();
            this.pbVistaBotonLcs = new System.Windows.Forms.PictureBox();
            this.pbVistaAbout = new System.Windows.Forms.PictureBox();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenuConfiguracionesRapidas = new System.Windows.Forms.Panel();
            this.lblMenuCRapidas = new System.Windows.Forms.Label();
            this.lblMenuConfiguracionesR = new System.Windows.Forms.Label();
            this.pbMenuConfiguracionesRapidas = new System.Windows.Forms.PictureBox();
            this.pnlRojoMenu = new System.Windows.Forms.Panel();
            this.pnlMenuExpandir = new System.Windows.Forms.Panel();
            this.pbMenuExpandir = new System.Windows.Forms.PictureBox();
            this.pnlMenuAbout = new System.Windows.Forms.Panel();
            this.pnlMenuRojoAbout = new System.Windows.Forms.Panel();
            this.lblMenuAbout = new System.Windows.Forms.Label();
            this.pbMenuAbout = new System.Windows.Forms.PictureBox();
            this.pnlMenuConfiguracion = new System.Windows.Forms.Panel();
            this.pnlMenuRojoConfiguracion = new System.Windows.Forms.Panel();
            this.lblMenuConfiguracion = new System.Windows.Forms.Label();
            this.pbMenuConfiguracion = new System.Windows.Forms.PictureBox();
            this.pnlMenuSolicitar = new System.Windows.Forms.Panel();
            this.pnlMenuRojoSolicitar = new System.Windows.Forms.Panel();
            this.lblMenuSolicitar = new System.Windows.Forms.Label();
            this.pbMenuSolicitar = new System.Windows.Forms.PictureBox();
            this.pnlMenuCompartir = new System.Windows.Forms.Panel();
            this.pnlMenuRojoCompartir = new System.Windows.Forms.Panel();
            this.lblMenuCompartir = new System.Windows.Forms.Label();
            this.pbMenuCompartir = new System.Windows.Forms.PictureBox();
            this.pnlMenuExplorar = new System.Windows.Forms.Panel();
            this.pnlMenuRojoExplorar = new System.Windows.Forms.Panel();
            this.lblMenuExplorar = new System.Windows.Forms.Label();
            this.pbMenuExplorar = new System.Windows.Forms.PictureBox();
            this.pnlMenuDescargar = new System.Windows.Forms.Panel();
            this.pnlMenuRojoDescargar = new System.Windows.Forms.Panel();
            this.lblMenuDescargar = new System.Windows.Forms.Label();
            this.pbMenuDescargar = new System.Windows.Forms.PictureBox();
            this.fbdNavegador = new System.Windows.Forms.FolderBrowserDialog();
            this.ttAyuda = new System.Windows.Forms.ToolTip(this.components);
            this.niMinimizar = new System.Windows.Forms.NotifyIcon(this.components);
            this.ofdArchivo = new System.Windows.Forms.OpenFileDialog();
            this.tmrModificarAN = new System.Windows.Forms.Timer(this.components);
            this.pnlBarra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).BeginInit();
            this.pnlVistaContenedor.SuspendLayout();
            this.pnlVistaDescargar.SuspendLayout();
            this.pnlVistaDescargarContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaDescargarStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaDescargarStart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaDescargas)).BeginInit();
            this.pnlVistaExplorar.SuspendLayout();
            this.pnlVistaExploarBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaExplorarBuscar)).BeginInit();
            this.pnlVistaExplorarDGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaExplorarArchivosCompartidosVecinos)).BeginInit();
            this.pnlVistaCompartir.SuspendLayout();
            this.pnlVistaCompartirMostarArchivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaCompartirArchivos)).BeginInit();
            this.pnlVistaCompartirGuardarArchivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaCompartirCancelar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaCompartirArchivo)).BeginInit();
            this.pnlVistaCompartirSeleccionarArchivo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaCompartirSeleccionarArchivo)).BeginInit();
            this.pnlVistaSolicitar.SuspendLayout();
            this.pnlVistaSolicitarVerSolicitudes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaSolicitar)).BeginInit();
            this.pnlVistaSolicitarCompartirSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlVistaConfiguracionGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaConfiguracionReconectar)).BeginInit();
            this.pnlVistaComfiguracionInterfaz.SuspendLayout();
            this.pnlVistaConfiguracionTransferencias.SuspendLayout();
            this.pnlVistaComfiguracionGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaConfiguracionCarpetaDescarga)).BeginInit();
            this.pnlVistaAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaAboutBotonJulio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaBotonLcs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaAbout)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuConfiguracionesRapidas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuConfiguracionesRapidas)).BeginInit();
            this.pnlMenuExpandir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuExpandir)).BeginInit();
            this.pnlMenuAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuAbout)).BeginInit();
            this.pnlMenuConfiguracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuConfiguracion)).BeginInit();
            this.pnlMenuSolicitar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuSolicitar)).BeginInit();
            this.pnlMenuCompartir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuCompartir)).BeginInit();
            this.pnlMenuExplorar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuExplorar)).BeginInit();
            this.pnlMenuDescargar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuDescargar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.pnlBarra.Controls.Add(this.pbCerrar);
            this.pnlBarra.Controls.Add(this.pbMinimizar);
            this.pnlBarra.Controls.Add(this.pbTitulo);
            this.pnlBarra.Controls.Add(this.pbIcono);
            this.pnlBarra.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 0);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(1100, 30);
            this.pnlBarra.TabIndex = 0;
            this.pnlBarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // pbCerrar
            // 
            this.pbCerrar.BackColor = System.Drawing.Color.Transparent;
            this.pbCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCerrar.Image = ((System.Drawing.Image)(resources.GetObject("pbCerrar.Image")));
            this.pbCerrar.Location = new System.Drawing.Point(1072, 4);
            this.pbCerrar.Name = "pbCerrar";
            this.pbCerrar.Size = new System.Drawing.Size(22, 22);
            this.pbCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCerrar.TabIndex = 4;
            this.pbCerrar.TabStop = false;
            this.pbCerrar.Click += new System.EventHandler(this.TimerOn);
            // 
            // pbMinimizar
            // 
            this.pbMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.pbMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("pbMinimizar.Image")));
            this.pbMinimizar.Location = new System.Drawing.Point(1044, 4);
            this.pbMinimizar.Name = "pbMinimizar";
            this.pbMinimizar.Size = new System.Drawing.Size(22, 22);
            this.pbMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMinimizar.TabIndex = 3;
            this.pbMinimizar.TabStop = false;
            this.pbMinimizar.Click += new System.EventHandler(this.TimerOn);
            // 
            // pbTitulo
            // 
            this.pbTitulo.BackColor = System.Drawing.Color.Transparent;
            this.pbTitulo.Image = ((System.Drawing.Image)(resources.GetObject("pbTitulo.Image")));
            this.pbTitulo.Location = new System.Drawing.Point(509, 5);
            this.pbTitulo.Name = "pbTitulo";
            this.pbTitulo.Size = new System.Drawing.Size(83, 20);
            this.pbTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTitulo.TabIndex = 1;
            this.pbTitulo.TabStop = false;
            this.pbTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // pbIcono
            // 
            this.pbIcono.BackColor = System.Drawing.Color.Transparent;
            this.pbIcono.Image = ((System.Drawing.Image)(resources.GetObject("pbIcono.Image")));
            this.pbIcono.Location = new System.Drawing.Point(7, 7);
            this.pbIcono.Name = "pbIcono";
            this.pbIcono.Size = new System.Drawing.Size(16, 17);
            this.pbIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbIcono.TabIndex = 1;
            this.pbIcono.TabStop = false;
            // 
            // tmrFader
            // 
            this.tmrFader.Interval = 1;
            this.tmrFader.Tick += new System.EventHandler(this.tmrFader_Tick);
            // 
            // pnlBarraGris1Px
            // 
            this.pnlBarraGris1Px.BackColor = System.Drawing.Color.Gray;
            this.pnlBarraGris1Px.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraGris1Px.Location = new System.Drawing.Point(0, 30);
            this.pnlBarraGris1Px.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBarraGris1Px.Name = "pnlBarraGris1Px";
            this.pnlBarraGris1Px.Size = new System.Drawing.Size(1100, 1);
            this.pnlBarraGris1Px.TabIndex = 1;
            this.pnlBarraGris1Px.Tag = "1";
            // 
            // pnlVistaContenedor
            // 
            this.pnlVistaContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlVistaContenedor.Controls.Add(this.pnlVistaConfiguracionGeneral);
            this.pnlVistaContenedor.Controls.Add(this.pnlVistaAbout);
            this.pnlVistaContenedor.Controls.Add(this.pnlVistaDescargar);
            this.pnlVistaContenedor.Controls.Add(this.pnlVistaExplorar);
            this.pnlVistaContenedor.Controls.Add(this.pnlVistaCompartir);
            this.pnlVistaContenedor.Controls.Add(this.pnlVistaSolicitar);
            this.pnlVistaContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVistaContenedor.Location = new System.Drawing.Point(65, 31);
            this.pnlVistaContenedor.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVistaContenedor.Name = "pnlVistaContenedor";
            this.pnlVistaContenedor.Size = new System.Drawing.Size(1035, 619);
            this.pnlVistaContenedor.TabIndex = 12;
            this.pnlVistaContenedor.Tag = "0";
            // 
            // pnlVistaDescargar
            // 
            this.pnlVistaDescargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlVistaDescargar.Controls.Add(this.pnlVistaDescargarContenedor);
            this.pnlVistaDescargar.Controls.Add(this.panel1);
            this.pnlVistaDescargar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVistaDescargar.Location = new System.Drawing.Point(0, 0);
            this.pnlVistaDescargar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVistaDescargar.Name = "pnlVistaDescargar";
            this.pnlVistaDescargar.Size = new System.Drawing.Size(1035, 619);
            this.pnlVistaDescargar.TabIndex = 18;
            this.pnlVistaDescargar.Tag = "1";
            // 
            // pnlVistaDescargarContenedor
            // 
            this.pnlVistaDescargarContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaDescargarContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaDescargarContenedor.Controls.Add(this.pbVistaDescargarStop);
            this.pnlVistaDescargarContenedor.Controls.Add(this.pbVistaDescargarStart);
            this.pnlVistaDescargarContenedor.Location = new System.Drawing.Point(37, 23);
            this.pnlVistaDescargarContenedor.Name = "pnlVistaDescargarContenedor";
            this.pnlVistaDescargarContenedor.Size = new System.Drawing.Size(960, 46);
            this.pnlVistaDescargarContenedor.TabIndex = 9;
            // 
            // pbVistaDescargarStop
            // 
            this.pbVistaDescargarStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaDescargarStop.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaDescargarStop.Image")));
            this.pbVistaDescargarStop.Location = new System.Drawing.Point(53, 11);
            this.pbVistaDescargarStop.Name = "pbVistaDescargarStop";
            this.pbVistaDescargarStop.Size = new System.Drawing.Size(25, 25);
            this.pbVistaDescargarStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaDescargarStop.TabIndex = 0;
            this.pbVistaDescargarStop.TabStop = false;
            this.ttAyuda.SetToolTip(this.pbVistaDescargarStop, "Detener");
            this.pbVistaDescargarStop.Click += new System.EventHandler(this.FrenarDescargas);
            // 
            // pbVistaDescargarStart
            // 
            this.pbVistaDescargarStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaDescargarStart.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaDescargarStart.Image")));
            this.pbVistaDescargarStart.Location = new System.Drawing.Point(14, 9);
            this.pbVistaDescargarStart.Name = "pbVistaDescargarStart";
            this.pbVistaDescargarStart.Size = new System.Drawing.Size(25, 28);
            this.pbVistaDescargarStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaDescargarStart.TabIndex = 0;
            this.pbVistaDescargarStart.TabStop = false;
            this.ttAyuda.SetToolTip(this.pbVistaDescargarStart, "Descargar");
            this.pbVistaDescargarStart.Click += new System.EventHandler(this.IniciarDescargas);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.lblVistaDescargarExplorar);
            this.panel1.Controls.Add(this.dgvVistaDescargas);
            this.panel1.Location = new System.Drawing.Point(37, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 508);
            this.panel1.TabIndex = 8;
            // 
            // lblVistaDescargarExplorar
            // 
            this.lblVistaDescargarExplorar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaDescargarExplorar.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaDescargarExplorar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblVistaDescargarExplorar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaDescargarExplorar.Location = new System.Drawing.Point(203, 51);
            this.lblVistaDescargarExplorar.Name = "lblVistaDescargarExplorar";
            this.lblVistaDescargarExplorar.Size = new System.Drawing.Size(554, 43);
            this.lblVistaDescargarExplorar.TabIndex = 5;
            this.lblVistaDescargarExplorar.Text = "¡Explora para descargar!";
            this.lblVistaDescargarExplorar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvVistaDescargas
            // 
            this.dgvVistaDescargas.AllowUserToAddRows = false;
            this.dgvVistaDescargas.AllowUserToDeleteRows = false;
            this.dgvVistaDescargas.AllowUserToResizeColumns = false;
            this.dgvVistaDescargas.AllowUserToResizeRows = false;
            this.dgvVistaDescargas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVistaDescargas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.dgvVistaDescargas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVistaDescargas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVistaDescargas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVistaDescargas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistaDescargas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreArchivo,
            this.Descargado,
            this.TamañoArchivo,
            this.Progreso,
            this.BorraraArchivo});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVistaDescargas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVistaDescargas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVistaDescargas.EnableHeadersVisualStyles = false;
            this.dgvVistaDescargas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.dgvVistaDescargas.Location = new System.Drawing.Point(0, 0);
            this.dgvVistaDescargas.MultiSelect = false;
            this.dgvVistaDescargas.Name = "dgvVistaDescargas";
            this.dgvVistaDescargas.ReadOnly = true;
            this.dgvVistaDescargas.RowHeadersVisible = false;
            this.dgvVistaDescargas.Size = new System.Drawing.Size(960, 508);
            this.dgvVistaDescargas.TabIndex = 6;
            this.dgvVistaDescargas.Tag = "D";
            this.dgvVistaDescargas.Visible = false;
            this.dgvVistaDescargas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EliminarDescarga);
            this.dgvVistaDescargas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CambiarCursorDGV);
            // 
            // NombreArchivo
            // 
            this.NombreArchivo.HeaderText = "Nombre";
            this.NombreArchivo.Name = "NombreArchivo";
            this.NombreArchivo.ReadOnly = true;
            // 
            // Descargado
            // 
            this.Descargado.HeaderText = "Tamaño descargado";
            this.Descargado.Name = "Descargado";
            this.Descargado.ReadOnly = true;
            // 
            // TamañoArchivo
            // 
            this.TamañoArchivo.HeaderText = "Tamaño total";
            this.TamañoArchivo.Name = "TamañoArchivo";
            this.TamañoArchivo.ReadOnly = true;
            // 
            // Progreso
            // 
            this.Progreso.HeaderText = "Progreso";
            this.Progreso.Name = "Progreso";
            this.Progreso.ReadOnly = true;
            // 
            // BorraraArchivo
            // 
            this.BorraraArchivo.HeaderText = "Borrar";
            this.BorraraArchivo.Name = "BorraraArchivo";
            this.BorraraArchivo.ReadOnly = true;
            // 
            // pnlVistaExplorar
            // 
            this.pnlVistaExplorar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlVistaExplorar.Controls.Add(this.pnlVistaExploarBuscar);
            this.pnlVistaExplorar.Controls.Add(this.pnlVistaExplorarDGV);
            this.pnlVistaExplorar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVistaExplorar.Location = new System.Drawing.Point(0, 0);
            this.pnlVistaExplorar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVistaExplorar.Name = "pnlVistaExplorar";
            this.pnlVistaExplorar.Size = new System.Drawing.Size(1035, 619);
            this.pnlVistaExplorar.TabIndex = 17;
            this.pnlVistaExplorar.Tag = "2";
            this.pnlVistaExplorar.Visible = false;
            // 
            // pnlVistaExploarBuscar
            // 
            this.pnlVistaExploarBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaExploarBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaExploarBuscar.Controls.Add(this.pbVistaExplorarBuscar);
            this.pnlVistaExploarBuscar.Controls.Add(this.tbVistaExplorarBuscar);
            this.pnlVistaExploarBuscar.Location = new System.Drawing.Point(37, 23);
            this.pnlVistaExploarBuscar.Name = "pnlVistaExploarBuscar";
            this.pnlVistaExploarBuscar.Size = new System.Drawing.Size(960, 46);
            this.pnlVistaExploarBuscar.TabIndex = 8;
            // 
            // pbVistaExplorarBuscar
            // 
            this.pbVistaExplorarBuscar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbVistaExplorarBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaExplorarBuscar.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaExplorarBuscar.Image")));
            this.pbVistaExplorarBuscar.Location = new System.Drawing.Point(688, 9);
            this.pbVistaExplorarBuscar.Name = "pbVistaExplorarBuscar";
            this.pbVistaExplorarBuscar.Size = new System.Drawing.Size(28, 28);
            this.pbVistaExplorarBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaExplorarBuscar.TabIndex = 6;
            this.pbVistaExplorarBuscar.TabStop = false;
            this.pbVistaExplorarBuscar.Tag = "1";
            this.pbVistaExplorarBuscar.Click += new System.EventHandler(this.BuscarArchivoPorTag);
            // 
            // tbVistaExplorarBuscar
            // 
            this.tbVistaExplorarBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVistaExplorarBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(9)))), ((int)(((byte)(17)))));
            this.tbVistaExplorarBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbVistaExplorarBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbVistaExplorarBuscar.Location = new System.Drawing.Point(245, 9);
            this.tbVistaExplorarBuscar.MaxLength = 128;
            this.tbVistaExplorarBuscar.Multiline = true;
            this.tbVistaExplorarBuscar.Name = "tbVistaExplorarBuscar";
            this.tbVistaExplorarBuscar.Size = new System.Drawing.Size(430, 28);
            this.tbVistaExplorarBuscar.TabIndex = 5;
            this.tbVistaExplorarBuscar.Tag = "";
            this.tbVistaExplorarBuscar.Text = "Ingresa el nombre del archivo.";
            this.tbVistaExplorarBuscar.Click += new System.EventHandler(this.BorrarTB);
            // 
            // pnlVistaExplorarDGV
            // 
            this.pnlVistaExplorarDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaExplorarDGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaExplorarDGV.Controls.Add(this.lblVistaExplorarArchivosCompartidosVecinos);
            this.pnlVistaExplorarDGV.Controls.Add(this.dgvVistaExplorarArchivosCompartidosVecinos);
            this.pnlVistaExplorarDGV.Location = new System.Drawing.Point(37, 88);
            this.pnlVistaExplorarDGV.Name = "pnlVistaExplorarDGV";
            this.pnlVistaExplorarDGV.Size = new System.Drawing.Size(960, 508);
            this.pnlVistaExplorarDGV.TabIndex = 7;
            // 
            // lblVistaExplorarArchivosCompartidosVecinos
            // 
            this.lblVistaExplorarArchivosCompartidosVecinos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaExplorarArchivosCompartidosVecinos.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaExplorarArchivosCompartidosVecinos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblVistaExplorarArchivosCompartidosVecinos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaExplorarArchivosCompartidosVecinos.Location = new System.Drawing.Point(147, 51);
            this.lblVistaExplorarArchivosCompartidosVecinos.Name = "lblVistaExplorarArchivosCompartidosVecinos";
            this.lblVistaExplorarArchivosCompartidosVecinos.Size = new System.Drawing.Size(666, 43);
            this.lblVistaExplorarArchivosCompartidosVecinos.TabIndex = 5;
            this.lblVistaExplorarArchivosCompartidosVecinos.Text = "No hay archivos disponibles para descargar";
            this.lblVistaExplorarArchivosCompartidosVecinos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvVistaExplorarArchivosCompartidosVecinos
            // 
            this.dgvVistaExplorarArchivosCompartidosVecinos.AllowUserToAddRows = false;
            this.dgvVistaExplorarArchivosCompartidosVecinos.AllowUserToDeleteRows = false;
            this.dgvVistaExplorarArchivosCompartidosVecinos.AllowUserToResizeColumns = false;
            this.dgvVistaExplorarArchivosCompartidosVecinos.AllowUserToResizeRows = false;
            this.dgvVistaExplorarArchivosCompartidosVecinos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVistaExplorarArchivosCompartidosVecinos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.dgvVistaExplorarArchivosCompartidosVecinos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVistaExplorarArchivosCompartidosVecinos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVistaExplorarArchivosCompartidosVecinos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVistaExplorarArchivosCompartidosVecinos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistaExplorarArchivosCompartidosVecinos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVistaExplorarArchivosCompartidosVecinos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVistaExplorarArchivosCompartidosVecinos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVistaExplorarArchivosCompartidosVecinos.EnableHeadersVisualStyles = false;
            this.dgvVistaExplorarArchivosCompartidosVecinos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.dgvVistaExplorarArchivosCompartidosVecinos.Location = new System.Drawing.Point(0, 0);
            this.dgvVistaExplorarArchivosCompartidosVecinos.MultiSelect = false;
            this.dgvVistaExplorarArchivosCompartidosVecinos.Name = "dgvVistaExplorarArchivosCompartidosVecinos";
            this.dgvVistaExplorarArchivosCompartidosVecinos.ReadOnly = true;
            this.dgvVistaExplorarArchivosCompartidosVecinos.RowHeadersVisible = false;
            this.dgvVistaExplorarArchivosCompartidosVecinos.Size = new System.Drawing.Size(960, 508);
            this.dgvVistaExplorarArchivosCompartidosVecinos.TabIndex = 6;
            this.dgvVistaExplorarArchivosCompartidosVecinos.Tag = "E";
            this.dgvVistaExplorarArchivosCompartidosVecinos.Visible = false;
            this.dgvVistaExplorarArchivosCompartidosVecinos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DescargarArchivo);
            this.dgvVistaExplorarArchivosCompartidosVecinos.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CambiarCursorDGV);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "tamaño";
            this.dataGridViewTextBoxColumn6.HeaderText = "Tamaño";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "descripcion";
            this.dataGridViewTextBoxColumn7.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "activo";
            this.dataGridViewTextBoxColumn8.HeaderText = "Descargar";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // pnlVistaCompartir
            // 
            this.pnlVistaCompartir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlVistaCompartir.Controls.Add(this.pnlVistaCompartirMostarArchivos);
            this.pnlVistaCompartir.Controls.Add(this.pnlVistaCompartirGuardarArchivo);
            this.pnlVistaCompartir.Controls.Add(this.pnlVistaCompartirSeleccionarArchivo);
            this.pnlVistaCompartir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVistaCompartir.Location = new System.Drawing.Point(0, 0);
            this.pnlVistaCompartir.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVistaCompartir.Name = "pnlVistaCompartir";
            this.pnlVistaCompartir.Size = new System.Drawing.Size(1035, 619);
            this.pnlVistaCompartir.TabIndex = 16;
            this.pnlVistaCompartir.Tag = "3";
            this.pnlVistaCompartir.Visible = false;
            // 
            // pnlVistaCompartirMostarArchivos
            // 
            this.pnlVistaCompartirMostarArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaCompartirMostarArchivos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaCompartirMostarArchivos.Controls.Add(this.lblVistaCompartirVerArchivos);
            this.pnlVistaCompartirMostarArchivos.Controls.Add(this.dgvVistaCompartirArchivos);
            this.pnlVistaCompartirMostarArchivos.Location = new System.Drawing.Point(37, 156);
            this.pnlVistaCompartirMostarArchivos.Name = "pnlVistaCompartirMostarArchivos";
            this.pnlVistaCompartirMostarArchivos.Size = new System.Drawing.Size(960, 436);
            this.pnlVistaCompartirMostarArchivos.TabIndex = 6;
            // 
            // lblVistaCompartirVerArchivos
            // 
            this.lblVistaCompartirVerArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaCompartirVerArchivos.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaCompartirVerArchivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblVistaCompartirVerArchivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaCompartirVerArchivos.Location = new System.Drawing.Point(203, 15);
            this.lblVistaCompartirVerArchivos.Name = "lblVistaCompartirVerArchivos";
            this.lblVistaCompartirVerArchivos.Size = new System.Drawing.Size(554, 43);
            this.lblVistaCompartirVerArchivos.TabIndex = 5;
            this.lblVistaCompartirVerArchivos.Text = "No hay archivos compartidos";
            this.lblVistaCompartirVerArchivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvVistaCompartirArchivos
            // 
            this.dgvVistaCompartirArchivos.AllowUserToAddRows = false;
            this.dgvVistaCompartirArchivos.AllowUserToDeleteRows = false;
            this.dgvVistaCompartirArchivos.AllowUserToResizeColumns = false;
            this.dgvVistaCompartirArchivos.AllowUserToResizeRows = false;
            this.dgvVistaCompartirArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVistaCompartirArchivos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.dgvVistaCompartirArchivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVistaCompartirArchivos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVistaCompartirArchivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVistaCompartirArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistaCompartirArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.tamaño,
            this.descripcion,
            this.activo,
            this.borrar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVistaCompartirArchivos.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVistaCompartirArchivos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVistaCompartirArchivos.EnableHeadersVisualStyles = false;
            this.dgvVistaCompartirArchivos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.dgvVistaCompartirArchivos.Location = new System.Drawing.Point(0, 0);
            this.dgvVistaCompartirArchivos.MultiSelect = false;
            this.dgvVistaCompartirArchivos.Name = "dgvVistaCompartirArchivos";
            this.dgvVistaCompartirArchivos.ReadOnly = true;
            this.dgvVistaCompartirArchivos.RowHeadersVisible = false;
            this.dgvVistaCompartirArchivos.Size = new System.Drawing.Size(960, 436);
            this.dgvVistaCompartirArchivos.TabIndex = 6;
            this.dgvVistaCompartirArchivos.Tag = "C";
            this.dgvVistaCompartirArchivos.Visible = false;
            this.dgvVistaCompartirArchivos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ActivoBorrarArchivo);
            this.dgvVistaCompartirArchivos.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CambiarCursorDGV);
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // tamaño
            // 
            this.tamaño.DataPropertyName = "tamaño";
            this.tamaño.HeaderText = "Tamaño";
            this.tamaño.Name = "tamaño";
            this.tamaño.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // activo
            // 
            this.activo.DataPropertyName = "activo";
            this.activo.HeaderText = "Activo";
            this.activo.Name = "activo";
            this.activo.ReadOnly = true;
            // 
            // borrar
            // 
            this.borrar.DataPropertyName = "borrar";
            this.borrar.HeaderText = "Borrar";
            this.borrar.Name = "borrar";
            this.borrar.ReadOnly = true;
            // 
            // pnlVistaCompartirGuardarArchivo
            // 
            this.pnlVistaCompartirGuardarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaCompartirGuardarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaCompartirGuardarArchivo.Controls.Add(this.pnlVistaCompartirSeparador);
            this.pnlVistaCompartirGuardarArchivo.Controls.Add(this.tbVistaCompartirTags);
            this.pnlVistaCompartirGuardarArchivo.Controls.Add(this.tbVistaCompartirDescripcionArchivo);
            this.pnlVistaCompartirGuardarArchivo.Controls.Add(this.pbVistaCompartirCancelar);
            this.pnlVistaCompartirGuardarArchivo.Controls.Add(this.pbVistaCompartirArchivo);
            this.pnlVistaCompartirGuardarArchivo.Controls.Add(this.lblVistaCompartirTamañoArchivo);
            this.pnlVistaCompartirGuardarArchivo.Controls.Add(this.lblVistaCompartirNombreArchivo);
            this.pnlVistaCompartirGuardarArchivo.Location = new System.Drawing.Point(37, 26);
            this.pnlVistaCompartirGuardarArchivo.Name = "pnlVistaCompartirGuardarArchivo";
            this.pnlVistaCompartirGuardarArchivo.Size = new System.Drawing.Size(960, 100);
            this.pnlVistaCompartirGuardarArchivo.TabIndex = 1;
            this.pnlVistaCompartirGuardarArchivo.Visible = false;
            // 
            // pnlVistaCompartirSeparador
            // 
            this.pnlVistaCompartirSeparador.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlVistaCompartirSeparador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.pnlVistaCompartirSeparador.Location = new System.Drawing.Point(905, 9);
            this.pnlVistaCompartirSeparador.Name = "pnlVistaCompartirSeparador";
            this.pnlVistaCompartirSeparador.Size = new System.Drawing.Size(2, 80);
            this.pnlVistaCompartirSeparador.TabIndex = 5;
            // 
            // tbVistaCompartirTags
            // 
            this.tbVistaCompartirTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVistaCompartirTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(9)))), ((int)(((byte)(17)))));
            this.tbVistaCompartirTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbVistaCompartirTags.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbVistaCompartirTags.Location = new System.Drawing.Point(436, 60);
            this.tbVistaCompartirTags.MaxLength = 255;
            this.tbVistaCompartirTags.Name = "tbVistaCompartirTags";
            this.tbVistaCompartirTags.Size = new System.Drawing.Size(463, 26);
            this.tbVistaCompartirTags.TabIndex = 4;
            this.tbVistaCompartirTags.Tag = "";
            this.tbVistaCompartirTags.Text = "Ingrese minimo 5 tags separados por un espacio";
            this.tbVistaCompartirTags.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVistaCompartirTags.Click += new System.EventHandler(this.BorrarTB);
            // 
            // tbVistaCompartirDescripcionArchivo
            // 
            this.tbVistaCompartirDescripcionArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVistaCompartirDescripcionArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(9)))), ((int)(((byte)(17)))));
            this.tbVistaCompartirDescripcionArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbVistaCompartirDescripcionArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbVistaCompartirDescripcionArchivo.Location = new System.Drawing.Point(436, 14);
            this.tbVistaCompartirDescripcionArchivo.MaxLength = 50;
            this.tbVistaCompartirDescripcionArchivo.Name = "tbVistaCompartirDescripcionArchivo";
            this.tbVistaCompartirDescripcionArchivo.Size = new System.Drawing.Size(463, 26);
            this.tbVistaCompartirDescripcionArchivo.TabIndex = 4;
            this.tbVistaCompartirDescripcionArchivo.Tag = "";
            this.tbVistaCompartirDescripcionArchivo.Text = "Breve descripcion del archivo.";
            this.tbVistaCompartirDescripcionArchivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVistaCompartirDescripcionArchivo.Click += new System.EventHandler(this.BorrarTB);
            // 
            // pbVistaCompartirCancelar
            // 
            this.pbVistaCompartirCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbVistaCompartirCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaCompartirCancelar.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaCompartirCancelar.Image")));
            this.pbVistaCompartirCancelar.Location = new System.Drawing.Point(912, 54);
            this.pbVistaCompartirCancelar.Name = "pbVistaCompartirCancelar";
            this.pbVistaCompartirCancelar.Size = new System.Drawing.Size(38, 38);
            this.pbVistaCompartirCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaCompartirCancelar.TabIndex = 3;
            this.pbVistaCompartirCancelar.TabStop = false;
            this.pbVistaCompartirCancelar.Tag = "0";
            this.pbVistaCompartirCancelar.Click += new System.EventHandler(this.CompartirCancelarArchivo);
            // 
            // pbVistaCompartirArchivo
            // 
            this.pbVistaCompartirArchivo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbVistaCompartirArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaCompartirArchivo.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaCompartirArchivo.Image")));
            this.pbVistaCompartirArchivo.Location = new System.Drawing.Point(912, 9);
            this.pbVistaCompartirArchivo.Name = "pbVistaCompartirArchivo";
            this.pbVistaCompartirArchivo.Size = new System.Drawing.Size(37, 37);
            this.pbVistaCompartirArchivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaCompartirArchivo.TabIndex = 3;
            this.pbVistaCompartirArchivo.TabStop = false;
            this.pbVistaCompartirArchivo.Tag = "1";
            this.pbVistaCompartirArchivo.Click += new System.EventHandler(this.CompartirCancelarArchivo);
            // 
            // lblVistaCompartirTamañoArchivo
            // 
            this.lblVistaCompartirTamañoArchivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVistaCompartirTamañoArchivo.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaCompartirTamañoArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaCompartirTamañoArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaCompartirTamañoArchivo.Location = new System.Drawing.Point(160, 56);
            this.lblVistaCompartirTamañoArchivo.Name = "lblVistaCompartirTamañoArchivo";
            this.lblVistaCompartirTamañoArchivo.Size = new System.Drawing.Size(120, 34);
            this.lblVistaCompartirTamañoArchivo.TabIndex = 2;
            this.lblVistaCompartirTamañoArchivo.Text = "Tamaño";
            this.lblVistaCompartirTamañoArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVistaCompartirNombreArchivo
            // 
            this.lblVistaCompartirNombreArchivo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVistaCompartirNombreArchivo.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaCompartirNombreArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaCompartirNombreArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaCompartirNombreArchivo.Location = new System.Drawing.Point(11, 11);
            this.lblVistaCompartirNombreArchivo.Name = "lblVistaCompartirNombreArchivo";
            this.lblVistaCompartirNombreArchivo.Size = new System.Drawing.Size(419, 34);
            this.lblVistaCompartirNombreArchivo.TabIndex = 2;
            this.lblVistaCompartirNombreArchivo.Text = "Nombre";
            this.lblVistaCompartirNombreArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlVistaCompartirSeleccionarArchivo
            // 
            this.pnlVistaCompartirSeleccionarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaCompartirSeleccionarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaCompartirSeleccionarArchivo.Controls.Add(this.lblVistaCompartirSeleccionar);
            this.pnlVistaCompartirSeleccionarArchivo.Controls.Add(this.pbVistaCompartirSeleccionarArchivo);
            this.pnlVistaCompartirSeleccionarArchivo.Location = new System.Drawing.Point(37, 26);
            this.pnlVistaCompartirSeleccionarArchivo.Name = "pnlVistaCompartirSeleccionarArchivo";
            this.pnlVistaCompartirSeleccionarArchivo.Size = new System.Drawing.Size(960, 100);
            this.pnlVistaCompartirSeleccionarArchivo.TabIndex = 4;
            // 
            // lblVistaCompartirSeleccionar
            // 
            this.lblVistaCompartirSeleccionar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVistaCompartirSeleccionar.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaCompartirSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVistaCompartirSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaCompartirSeleccionar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaCompartirSeleccionar.Location = new System.Drawing.Point(245, 62);
            this.lblVistaCompartirSeleccionar.Name = "lblVistaCompartirSeleccionar";
            this.lblVistaCompartirSeleccionar.Size = new System.Drawing.Size(470, 25);
            this.lblVistaCompartirSeleccionar.TabIndex = 2;
            this.lblVistaCompartirSeleccionar.Text = "Seleccione el archivo que quiera compartir";
            this.lblVistaCompartirSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVistaCompartirSeleccionar.Click += new System.EventHandler(this.SeleccionarArchivoCompartir);
            // 
            // pbVistaCompartirSeleccionarArchivo
            // 
            this.pbVistaCompartirSeleccionarArchivo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbVistaCompartirSeleccionarArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaCompartirSeleccionarArchivo.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaCompartirSeleccionarArchivo.Image")));
            this.pbVistaCompartirSeleccionarArchivo.Location = new System.Drawing.Point(453, 14);
            this.pbVistaCompartirSeleccionarArchivo.Name = "pbVistaCompartirSeleccionarArchivo";
            this.pbVistaCompartirSeleccionarArchivo.Size = new System.Drawing.Size(55, 42);
            this.pbVistaCompartirSeleccionarArchivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaCompartirSeleccionarArchivo.TabIndex = 3;
            this.pbVistaCompartirSeleccionarArchivo.TabStop = false;
            this.pbVistaCompartirSeleccionarArchivo.Click += new System.EventHandler(this.SeleccionarArchivoCompartir);
            // 
            // pnlVistaSolicitar
            // 
            this.pnlVistaSolicitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlVistaSolicitar.Controls.Add(this.pnlVistaSolicitarVerSolicitudes);
            this.pnlVistaSolicitar.Controls.Add(this.pnlVistaSolicitarCompartirSolicitud);
            this.pnlVistaSolicitar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVistaSolicitar.Location = new System.Drawing.Point(0, 0);
            this.pnlVistaSolicitar.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVistaSolicitar.Name = "pnlVistaSolicitar";
            this.pnlVistaSolicitar.Size = new System.Drawing.Size(1035, 619);
            this.pnlVistaSolicitar.TabIndex = 15;
            this.pnlVistaSolicitar.Tag = "4";
            this.pnlVistaSolicitar.Visible = false;
            // 
            // pnlVistaSolicitarVerSolicitudes
            // 
            this.pnlVistaSolicitarVerSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaSolicitarVerSolicitudes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaSolicitarVerSolicitudes.Controls.Add(this.lblVistaSolicitarNuevasSolicitudes);
            this.pnlVistaSolicitarVerSolicitudes.Controls.Add(this.dgvVistaSolicitar);
            this.pnlVistaSolicitarVerSolicitudes.Location = new System.Drawing.Point(37, 156);
            this.pnlVistaSolicitarVerSolicitudes.Name = "pnlVistaSolicitarVerSolicitudes";
            this.pnlVistaSolicitarVerSolicitudes.Size = new System.Drawing.Size(960, 436);
            this.pnlVistaSolicitarVerSolicitudes.TabIndex = 7;
            // 
            // lblVistaSolicitarNuevasSolicitudes
            // 
            this.lblVistaSolicitarNuevasSolicitudes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaSolicitarNuevasSolicitudes.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaSolicitarNuevasSolicitudes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblVistaSolicitarNuevasSolicitudes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaSolicitarNuevasSolicitudes.Location = new System.Drawing.Point(203, 15);
            this.lblVistaSolicitarNuevasSolicitudes.Name = "lblVistaSolicitarNuevasSolicitudes";
            this.lblVistaSolicitarNuevasSolicitudes.Size = new System.Drawing.Size(554, 43);
            this.lblVistaSolicitarNuevasSolicitudes.TabIndex = 5;
            this.lblVistaSolicitarNuevasSolicitudes.Text = "No hay nuevas solicitudes";
            this.lblVistaSolicitarNuevasSolicitudes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvVistaSolicitar
            // 
            this.dgvVistaSolicitar.AllowUserToAddRows = false;
            this.dgvVistaSolicitar.AllowUserToDeleteRows = false;
            this.dgvVistaSolicitar.AllowUserToResizeColumns = false;
            this.dgvVistaSolicitar.AllowUserToResizeRows = false;
            this.dgvVistaSolicitar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVistaSolicitar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.dgvVistaSolicitar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVistaSolicitar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVistaSolicitar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVistaSolicitar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVistaSolicitar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVistaSolicitar.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVistaSolicitar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVistaSolicitar.EnableHeadersVisualStyles = false;
            this.dgvVistaSolicitar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.dgvVistaSolicitar.Location = new System.Drawing.Point(0, 0);
            this.dgvVistaSolicitar.MultiSelect = false;
            this.dgvVistaSolicitar.Name = "dgvVistaSolicitar";
            this.dgvVistaSolicitar.ReadOnly = true;
            this.dgvVistaSolicitar.RowHeadersVisible = false;
            this.dgvVistaSolicitar.Size = new System.Drawing.Size(960, 436);
            this.dgvVistaSolicitar.TabIndex = 6;
            this.dgvVistaSolicitar.Tag = "S";
            this.dgvVistaSolicitar.Visible = false;
            this.dgvVistaSolicitar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CompartirBorrarSolicitud);
            this.dgvVistaSolicitar.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CambiarCursorDGV);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nombre";
            this.dataGridViewTextBoxColumn1.HeaderText = "Usuario";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "descripcion";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "activo";
            this.dataGridViewTextBoxColumn4.HeaderText = "Compartir";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "borrar";
            this.dataGridViewTextBoxColumn5.HeaderText = "Borrar";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // pnlVistaSolicitarCompartirSolicitud
            // 
            this.pnlVistaSolicitarCompartirSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaSolicitarCompartirSolicitud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaSolicitarCompartirSolicitud.Controls.Add(this.lblVistaSolicitarInformacion);
            this.pnlVistaSolicitarCompartirSolicitud.Controls.Add(this.tbVistaSolicitarDescripcion);
            this.pnlVistaSolicitarCompartirSolicitud.Controls.Add(this.pictureBox2);
            this.pnlVistaSolicitarCompartirSolicitud.Location = new System.Drawing.Point(37, 26);
            this.pnlVistaSolicitarCompartirSolicitud.Name = "pnlVistaSolicitarCompartirSolicitud";
            this.pnlVistaSolicitarCompartirSolicitud.Size = new System.Drawing.Size(960, 100);
            this.pnlVistaSolicitarCompartirSolicitud.TabIndex = 2;
            // 
            // lblVistaSolicitarInformacion
            // 
            this.lblVistaSolicitarInformacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaSolicitarInformacion.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaSolicitarInformacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblVistaSolicitarInformacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaSolicitarInformacion.Location = new System.Drawing.Point(203, 7);
            this.lblVistaSolicitarInformacion.Name = "lblVistaSolicitarInformacion";
            this.lblVistaSolicitarInformacion.Size = new System.Drawing.Size(554, 33);
            this.lblVistaSolicitarInformacion.TabIndex = 6;
            this.lblVistaSolicitarInformacion.Text = "¡Solicita el archivo que necesites!";
            this.lblVistaSolicitarInformacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbVistaSolicitarDescripcion
            // 
            this.tbVistaSolicitarDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVistaSolicitarDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(9)))), ((int)(((byte)(17)))));
            this.tbVistaSolicitarDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbVistaSolicitarDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbVistaSolicitarDescripcion.Location = new System.Drawing.Point(21, 44);
            this.tbVistaSolicitarDescripcion.MaxLength = 128;
            this.tbVistaSolicitarDescripcion.Multiline = true;
            this.tbVistaSolicitarDescripcion.Name = "tbVistaSolicitarDescripcion";
            this.tbVistaSolicitarDescripcion.Size = new System.Drawing.Size(867, 50);
            this.tbVistaSolicitarDescripcion.TabIndex = 4;
            this.tbVistaSolicitarDescripcion.Tag = "";
            this.tbVistaSolicitarDescripcion.Text = "Breve descripcion del archivo.";
            this.tbVistaSolicitarDescripcion.Click += new System.EventHandler(this.BorrarTB);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(902, 50);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "1";
            this.pictureBox2.Click += new System.EventHandler(this.SolicitarArchivo);
            // 
            // pnlVistaConfiguracionGeneral
            // 
            this.pnlVistaConfiguracionGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionSyncAuto);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bsVistaConfiguracionBuscar);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionBitNoders);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionMiIP);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.pbVistaConfiguracionReconectar);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.tbVistaConfiguracionIP);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionIP);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.tbVistaConfiguracionNombre);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionNombre);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bnudVistaConfiguracionDescargasSimultaneas);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bnudVistaConfiguracionLimiteBajada);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bnudVistaConfiguracionLimiteSubida);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionEfectoBotones);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionMovimientoMenu);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.pnlVistaComfiguracionInterfaz);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionEfectoFade);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.pnlVistaConfiguracionTransferencias);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bsVistaConfiguracionEfectoFade);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bsVistaConfiguracionIniciarConWindows);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bsVistaConfiguracionEfectoMenu);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.pnlVistaComfiguracionGeneral);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bsVistaConfiguracionEfectoBotones);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bsVistaConfiguracionMinimizarBandeja);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.pbVistaConfiguracionCarpetaDescarga);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionMinimizarBanjeda);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bsVistaConfiguracionTema);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionIniciarConWindows);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.bsVistaConfiguracionLatino);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionTema);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionRutaDescarga);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionKbpsBajada);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionKbpsSubida);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionLimiteSubida);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionLimiteBajada);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionLimiteDescargas);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionTemaClaro);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionIngles);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionTemaOscuro);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionEspañol);
            this.pnlVistaConfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionIdioma);
            this.pnlVistaConfiguracionGeneral.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnlVistaConfiguracionGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVistaConfiguracionGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlVistaConfiguracionGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVistaConfiguracionGeneral.Name = "pnlVistaConfiguracionGeneral";
            this.pnlVistaConfiguracionGeneral.Size = new System.Drawing.Size(1035, 619);
            this.pnlVistaConfiguracionGeneral.TabIndex = 14;
            this.pnlVistaConfiguracionGeneral.Tag = "5";
            this.pnlVistaConfiguracionGeneral.Visible = false;
            // 
            // lblVistaConfiguracionSyncAuto
            // 
            this.lblVistaConfiguracionSyncAuto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVistaConfiguracionSyncAuto.AutoSize = true;
            this.lblVistaConfiguracionSyncAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionSyncAuto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionSyncAuto.Location = new System.Drawing.Point(167, 167);
            this.lblVistaConfiguracionSyncAuto.Name = "lblVistaConfiguracionSyncAuto";
            this.lblVistaConfiguracionSyncAuto.Size = new System.Drawing.Size(211, 24);
            this.lblVistaConfiguracionSyncAuto.TabIndex = 18;
            this.lblVistaConfiguracionSyncAuto.Text = "Sincronizacion continua";
            // 
            // bsVistaConfiguracionBuscar
            // 
            this.bsVistaConfiguracionBuscar.Activo = true;
            this.bsVistaConfiguracionBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bsVistaConfiguracionBuscar.BackColor = System.Drawing.Color.Transparent;
            this.bsVistaConfiguracionBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsVistaConfiguracionBuscar.Location = new System.Drawing.Point(126, 169);
            this.bsVistaConfiguracionBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.bsVistaConfiguracionBuscar.Name = "bsVistaConfiguracionBuscar";
            this.bsVistaConfiguracionBuscar.Size = new System.Drawing.Size(36, 18);
            this.bsVistaConfiguracionBuscar.TabIndex = 17;
            this.bsVistaConfiguracionBuscar.Tag = "15";
            this.bsVistaConfiguracionBuscar.Clickaso += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // lblVistaConfiguracionBitNoders
            // 
            this.lblVistaConfiguracionBitNoders.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionBitNoders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionBitNoders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblVistaConfiguracionBitNoders.Location = new System.Drawing.Point(662, 167);
            this.lblVistaConfiguracionBitNoders.Name = "lblVistaConfiguracionBitNoders";
            this.lblVistaConfiguracionBitNoders.Size = new System.Drawing.Size(216, 23);
            this.lblVistaConfiguracionBitNoders.TabIndex = 16;
            this.lblVistaConfiguracionBitNoders.Text = "X bitNoders activos";
            this.lblVistaConfiguracionBitNoders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVistaConfiguracionMiIP
            // 
            this.lblVistaConfiguracionMiIP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionMiIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVistaConfiguracionMiIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionMiIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionMiIP.Location = new System.Drawing.Point(683, 584);
            this.lblVistaConfiguracionMiIP.Name = "lblVistaConfiguracionMiIP";
            this.lblVistaConfiguracionMiIP.Size = new System.Drawing.Size(220, 23);
            this.lblVistaConfiguracionMiIP.TabIndex = 15;
            this.lblVistaConfiguracionMiIP.Text = "Mi IP: \"255.255.255.255\"";
            this.lblVistaConfiguracionMiIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVistaConfiguracionMiIP.Click += new System.EventHandler(this.IPaPortapapeles);
            // 
            // pbVistaConfiguracionReconectar
            // 
            this.pbVistaConfiguracionReconectar.BackColor = System.Drawing.Color.Transparent;
            this.pbVistaConfiguracionReconectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaConfiguracionReconectar.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaConfiguracionReconectar.Image")));
            this.pbVistaConfiguracionReconectar.Location = new System.Drawing.Point(374, 585);
            this.pbVistaConfiguracionReconectar.Name = "pbVistaConfiguracionReconectar";
            this.pbVistaConfiguracionReconectar.Size = new System.Drawing.Size(20, 20);
            this.pbVistaConfiguracionReconectar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaConfiguracionReconectar.TabIndex = 14;
            this.pbVistaConfiguracionReconectar.TabStop = false;
            this.ttAyuda.SetToolTip(this.pbVistaConfiguracionReconectar, "Reconectar");
            this.pbVistaConfiguracionReconectar.Click += new System.EventHandler(this.Reconectar);
            // 
            // tbVistaConfiguracionIP
            // 
            this.tbVistaConfiguracionIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.tbVistaConfiguracionIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVistaConfiguracionIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbVistaConfiguracionIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbVistaConfiguracionIP.Location = new System.Drawing.Point(241, 585);
            this.tbVistaConfiguracionIP.MaxLength = 15;
            this.tbVistaConfiguracionIP.Name = "tbVistaConfiguracionIP";
            this.tbVistaConfiguracionIP.Size = new System.Drawing.Size(127, 19);
            this.tbVistaConfiguracionIP.TabIndex = 13;
            this.tbVistaConfiguracionIP.Tag = "14";
            this.tbVistaConfiguracionIP.Text = "255.255.255.255";
            this.tbVistaConfiguracionIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblVistaConfiguracionIP
            // 
            this.lblVistaConfiguracionIP.AutoSize = true;
            this.lblVistaConfiguracionIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionIP.Location = new System.Drawing.Point(89, 584);
            this.lblVistaConfiguracionIP.Name = "lblVistaConfiguracionIP";
            this.lblVistaConfiguracionIP.Size = new System.Drawing.Size(147, 24);
            this.lblVistaConfiguracionIP.TabIndex = 12;
            this.lblVistaConfiguracionIP.Text = "IP de coneccion";
            // 
            // tbVistaConfiguracionNombre
            // 
            this.tbVistaConfiguracionNombre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbVistaConfiguracionNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.tbVistaConfiguracionNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVistaConfiguracionNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbVistaConfiguracionNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbVistaConfiguracionNombre.Location = new System.Drawing.Point(751, 132);
            this.tbVistaConfiguracionNombre.MaxLength = 12;
            this.tbVistaConfiguracionNombre.Name = "tbVistaConfiguracionNombre";
            this.tbVistaConfiguracionNombre.Size = new System.Drawing.Size(127, 19);
            this.tbVistaConfiguracionNombre.TabIndex = 9;
            this.tbVistaConfiguracionNombre.Tag = "14";
            this.tbVistaConfiguracionNombre.Text = "NOMBRE";
            this.tbVistaConfiguracionNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVistaConfiguracionNombre.Click += new System.EventHandler(this.BorrarTB);
            this.tbVistaConfiguracionNombre.TextChanged += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // lblVistaConfiguracionNombre
            // 
            this.lblVistaConfiguracionNombre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblVistaConfiguracionNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVistaConfiguracionNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionNombre.Location = new System.Drawing.Point(647, 131);
            this.lblVistaConfiguracionNombre.Name = "lblVistaConfiguracionNombre";
            this.lblVistaConfiguracionNombre.Size = new System.Drawing.Size(93, 23);
            this.lblVistaConfiguracionNombre.TabIndex = 8;
            this.lblVistaConfiguracionNombre.Text = "Nombre";
            this.lblVistaConfiguracionNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bnudVistaConfiguracionDescargasSimultaneas
            // 
            this.bnudVistaConfiguracionDescargasSimultaneas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bnudVistaConfiguracionDescargasSimultaneas.BackColor = System.Drawing.Color.Transparent;
            this.bnudVistaConfiguracionDescargasSimultaneas.Location = new System.Drawing.Point(848, 479);
            this.bnudVistaConfiguracionDescargasSimultaneas.Margin = new System.Windows.Forms.Padding(4);
            this.bnudVistaConfiguracionDescargasSimultaneas.maxValor = 5;
            this.bnudVistaConfiguracionDescargasSimultaneas.minValor = 0;
            this.bnudVistaConfiguracionDescargasSimultaneas.Name = "bnudVistaConfiguracionDescargasSimultaneas";
            this.bnudVistaConfiguracionDescargasSimultaneas.Size = new System.Drawing.Size(65, 35);
            this.bnudVistaConfiguracionDescargasSimultaneas.TabIndex = 6;
            this.bnudVistaConfiguracionDescargasSimultaneas.Tag = "33";
            this.bnudVistaConfiguracionDescargasSimultaneas.UpDown = 1;
            this.bnudVistaConfiguracionDescargasSimultaneas.valor = 0;
            this.bnudVistaConfiguracionDescargasSimultaneas.CambioDeValor += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // bnudVistaConfiguracionLimiteBajada
            // 
            this.bnudVistaConfiguracionLimiteBajada.BackColor = System.Drawing.Color.Transparent;
            this.bnudVistaConfiguracionLimiteBajada.Location = new System.Drawing.Point(251, 532);
            this.bnudVistaConfiguracionLimiteBajada.Margin = new System.Windows.Forms.Padding(4);
            this.bnudVistaConfiguracionLimiteBajada.maxValor = 9999;
            this.bnudVistaConfiguracionLimiteBajada.minValor = 0;
            this.bnudVistaConfiguracionLimiteBajada.Name = "bnudVistaConfiguracionLimiteBajada";
            this.bnudVistaConfiguracionLimiteBajada.Size = new System.Drawing.Size(65, 35);
            this.bnudVistaConfiguracionLimiteBajada.TabIndex = 6;
            this.bnudVistaConfiguracionLimiteBajada.Tag = "31";
            this.bnudVistaConfiguracionLimiteBajada.UpDown = 5;
            this.bnudVistaConfiguracionLimiteBajada.valor = 0;
            this.bnudVistaConfiguracionLimiteBajada.CambioDeValor += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // bnudVistaConfiguracionLimiteSubida
            // 
            this.bnudVistaConfiguracionLimiteSubida.BackColor = System.Drawing.Color.Transparent;
            this.bnudVistaConfiguracionLimiteSubida.Location = new System.Drawing.Point(251, 479);
            this.bnudVistaConfiguracionLimiteSubida.Margin = new System.Windows.Forms.Padding(4);
            this.bnudVistaConfiguracionLimiteSubida.maxValor = 9999;
            this.bnudVistaConfiguracionLimiteSubida.minValor = 0;
            this.bnudVistaConfiguracionLimiteSubida.Name = "bnudVistaConfiguracionLimiteSubida";
            this.bnudVistaConfiguracionLimiteSubida.Size = new System.Drawing.Size(65, 35);
            this.bnudVistaConfiguracionLimiteSubida.TabIndex = 6;
            this.bnudVistaConfiguracionLimiteSubida.Tag = "32";
            this.bnudVistaConfiguracionLimiteSubida.UpDown = 5;
            this.bnudVistaConfiguracionLimiteSubida.valor = 0;
            this.bnudVistaConfiguracionLimiteSubida.CambioDeValor += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // lblVistaConfiguracionEfectoBotones
            // 
            this.lblVistaConfiguracionEfectoBotones.AutoSize = true;
            this.lblVistaConfiguracionEfectoBotones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionEfectoBotones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionEfectoBotones.Location = new System.Drawing.Point(136, 323);
            this.lblVistaConfiguracionEfectoBotones.Name = "lblVistaConfiguracionEfectoBotones";
            this.lblVistaConfiguracionEfectoBotones.Size = new System.Drawing.Size(247, 24);
            this.lblVistaConfiguracionEfectoBotones.TabIndex = 1;
            this.lblVistaConfiguracionEfectoBotones.Text = "Efecto transision de botones";
            // 
            // lblVistaConfiguracionMovimientoMenu
            // 
            this.lblVistaConfiguracionMovimientoMenu.AutoSize = true;
            this.lblVistaConfiguracionMovimientoMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionMovimientoMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionMovimientoMenu.Location = new System.Drawing.Point(136, 369);
            this.lblVistaConfiguracionMovimientoMenu.Name = "lblVistaConfiguracionMovimientoMenu";
            this.lblVistaConfiguracionMovimientoMenu.Size = new System.Drawing.Size(233, 24);
            this.lblVistaConfiguracionMovimientoMenu.TabIndex = 1;
            this.lblVistaConfiguracionMovimientoMenu.Text = "Efecto deslizante de menu";
            // 
            // pnlVistaComfiguracionInterfaz
            // 
            this.pnlVistaComfiguracionInterfaz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaComfiguracionInterfaz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaComfiguracionInterfaz.Controls.Add(this.lblVistaConfiguracionInterfaz);
            this.pnlVistaComfiguracionInterfaz.Location = new System.Drawing.Point(22, 206);
            this.pnlVistaComfiguracionInterfaz.Name = "pnlVistaComfiguracionInterfaz";
            this.pnlVistaComfiguracionInterfaz.Size = new System.Drawing.Size(990, 50);
            this.pnlVistaComfiguracionInterfaz.TabIndex = 4;
            // 
            // lblVistaConfiguracionInterfaz
            // 
            this.lblVistaConfiguracionInterfaz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaConfiguracionInterfaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lblVistaConfiguracionInterfaz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionInterfaz.Location = new System.Drawing.Point(6, 6);
            this.lblVistaConfiguracionInterfaz.Name = "lblVistaConfiguracionInterfaz";
            this.lblVistaConfiguracionInterfaz.Size = new System.Drawing.Size(978, 38);
            this.lblVistaConfiguracionInterfaz.TabIndex = 1;
            this.lblVistaConfiguracionInterfaz.Text = "Interfaz";
            this.lblVistaConfiguracionInterfaz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVistaConfiguracionEfectoFade
            // 
            this.lblVistaConfiguracionEfectoFade.AutoSize = true;
            this.lblVistaConfiguracionEfectoFade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionEfectoFade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionEfectoFade.Location = new System.Drawing.Point(136, 277);
            this.lblVistaConfiguracionEfectoFade.Name = "lblVistaConfiguracionEfectoFade";
            this.lblVistaConfiguracionEfectoFade.Size = new System.Drawing.Size(276, 24);
            this.lblVistaConfiguracionEfectoFade.TabIndex = 1;
            this.lblVistaConfiguracionEfectoFade.Text = "Efecto transparencia de sistema";
            // 
            // pnlVistaConfiguracionTransferencias
            // 
            this.pnlVistaConfiguracionTransferencias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaConfiguracionTransferencias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaConfiguracionTransferencias.Controls.Add(this.lblVistaConfiguracionTranseferecias);
            this.pnlVistaConfiguracionTransferencias.Location = new System.Drawing.Point(22, 412);
            this.pnlVistaConfiguracionTransferencias.Name = "pnlVistaConfiguracionTransferencias";
            this.pnlVistaConfiguracionTransferencias.Size = new System.Drawing.Size(990, 50);
            this.pnlVistaConfiguracionTransferencias.TabIndex = 4;
            // 
            // lblVistaConfiguracionTranseferecias
            // 
            this.lblVistaConfiguracionTranseferecias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaConfiguracionTranseferecias.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lblVistaConfiguracionTranseferecias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionTranseferecias.Location = new System.Drawing.Point(6, 6);
            this.lblVistaConfiguracionTranseferecias.Name = "lblVistaConfiguracionTranseferecias";
            this.lblVistaConfiguracionTranseferecias.Size = new System.Drawing.Size(973, 38);
            this.lblVistaConfiguracionTranseferecias.TabIndex = 1;
            this.lblVistaConfiguracionTranseferecias.Text = "Transferencias";
            this.lblVistaConfiguracionTranseferecias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bsVistaConfiguracionEfectoFade
            // 
            this.bsVistaConfiguracionEfectoFade.Activo = true;
            this.bsVistaConfiguracionEfectoFade.BackColor = System.Drawing.Color.Transparent;
            this.bsVistaConfiguracionEfectoFade.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsVistaConfiguracionEfectoFade.Location = new System.Drawing.Point(94, 279);
            this.bsVistaConfiguracionEfectoFade.Margin = new System.Windows.Forms.Padding(4);
            this.bsVistaConfiguracionEfectoFade.Name = "bsVistaConfiguracionEfectoFade";
            this.bsVistaConfiguracionEfectoFade.Size = new System.Drawing.Size(36, 18);
            this.bsVistaConfiguracionEfectoFade.TabIndex = 2;
            this.bsVistaConfiguracionEfectoFade.Tag = "21";
            this.bsVistaConfiguracionEfectoFade.Clickaso += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // bsVistaConfiguracionIniciarConWindows
            // 
            this.bsVistaConfiguracionIniciarConWindows.Activo = false;
            this.bsVistaConfiguracionIniciarConWindows.BackColor = System.Drawing.Color.Transparent;
            this.bsVistaConfiguracionIniciarConWindows.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsVistaConfiguracionIniciarConWindows.Location = new System.Drawing.Point(126, 72);
            this.bsVistaConfiguracionIniciarConWindows.Margin = new System.Windows.Forms.Padding(4);
            this.bsVistaConfiguracionIniciarConWindows.Name = "bsVistaConfiguracionIniciarConWindows";
            this.bsVistaConfiguracionIniciarConWindows.Size = new System.Drawing.Size(36, 18);
            this.bsVistaConfiguracionIniciarConWindows.TabIndex = 2;
            this.bsVistaConfiguracionIniciarConWindows.Tag = "11";
            this.bsVistaConfiguracionIniciarConWindows.Clickaso += new System.EventHandler(this.CambiarConfiguracion);
            this.bsVistaConfiguracionIniciarConWindows.Click += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // bsVistaConfiguracionEfectoMenu
            // 
            this.bsVistaConfiguracionEfectoMenu.Activo = true;
            this.bsVistaConfiguracionEfectoMenu.BackColor = System.Drawing.Color.Transparent;
            this.bsVistaConfiguracionEfectoMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsVistaConfiguracionEfectoMenu.Location = new System.Drawing.Point(94, 371);
            this.bsVistaConfiguracionEfectoMenu.Margin = new System.Windows.Forms.Padding(4);
            this.bsVistaConfiguracionEfectoMenu.Name = "bsVistaConfiguracionEfectoMenu";
            this.bsVistaConfiguracionEfectoMenu.Size = new System.Drawing.Size(36, 18);
            this.bsVistaConfiguracionEfectoMenu.TabIndex = 2;
            this.bsVistaConfiguracionEfectoMenu.Tag = "23";
            this.bsVistaConfiguracionEfectoMenu.Clickaso += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // pnlVistaComfiguracionGeneral
            // 
            this.pnlVistaComfiguracionGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVistaComfiguracionGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(41)))));
            this.pnlVistaComfiguracionGeneral.Controls.Add(this.lblVistaConfiguracionGeneral);
            this.pnlVistaComfiguracionGeneral.Location = new System.Drawing.Point(22, 0);
            this.pnlVistaComfiguracionGeneral.Name = "pnlVistaComfiguracionGeneral";
            this.pnlVistaComfiguracionGeneral.Size = new System.Drawing.Size(990, 50);
            this.pnlVistaComfiguracionGeneral.TabIndex = 4;
            // 
            // lblVistaConfiguracionGeneral
            // 
            this.lblVistaConfiguracionGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVistaConfiguracionGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lblVistaConfiguracionGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionGeneral.Location = new System.Drawing.Point(6, 6);
            this.lblVistaConfiguracionGeneral.Name = "lblVistaConfiguracionGeneral";
            this.lblVistaConfiguracionGeneral.Size = new System.Drawing.Size(978, 38);
            this.lblVistaConfiguracionGeneral.TabIndex = 1;
            this.lblVistaConfiguracionGeneral.Text = "General";
            this.lblVistaConfiguracionGeneral.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bsVistaConfiguracionEfectoBotones
            // 
            this.bsVistaConfiguracionEfectoBotones.Activo = true;
            this.bsVistaConfiguracionEfectoBotones.BackColor = System.Drawing.Color.Transparent;
            this.bsVistaConfiguracionEfectoBotones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsVistaConfiguracionEfectoBotones.Location = new System.Drawing.Point(94, 325);
            this.bsVistaConfiguracionEfectoBotones.Margin = new System.Windows.Forms.Padding(4);
            this.bsVistaConfiguracionEfectoBotones.Name = "bsVistaConfiguracionEfectoBotones";
            this.bsVistaConfiguracionEfectoBotones.Size = new System.Drawing.Size(36, 18);
            this.bsVistaConfiguracionEfectoBotones.TabIndex = 2;
            this.bsVistaConfiguracionEfectoBotones.Tag = "22";
            this.bsVistaConfiguracionEfectoBotones.Clickaso += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // bsVistaConfiguracionMinimizarBandeja
            // 
            this.bsVistaConfiguracionMinimizarBandeja.Activo = false;
            this.bsVistaConfiguracionMinimizarBandeja.BackColor = System.Drawing.Color.Transparent;
            this.bsVistaConfiguracionMinimizarBandeja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsVistaConfiguracionMinimizarBandeja.Location = new System.Drawing.Point(126, 120);
            this.bsVistaConfiguracionMinimizarBandeja.Margin = new System.Windows.Forms.Padding(4);
            this.bsVistaConfiguracionMinimizarBandeja.Name = "bsVistaConfiguracionMinimizarBandeja";
            this.bsVistaConfiguracionMinimizarBandeja.Size = new System.Drawing.Size(36, 18);
            this.bsVistaConfiguracionMinimizarBandeja.TabIndex = 2;
            this.bsVistaConfiguracionMinimizarBandeja.Tag = "12";
            this.bsVistaConfiguracionMinimizarBandeja.Clickaso += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // pbVistaConfiguracionCarpetaDescarga
            // 
            this.pbVistaConfiguracionCarpetaDescarga.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbVistaConfiguracionCarpetaDescarga.BackColor = System.Drawing.Color.Transparent;
            this.pbVistaConfiguracionCarpetaDescarga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaConfiguracionCarpetaDescarga.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaConfiguracionCarpetaDescarga.Image")));
            this.pbVistaConfiguracionCarpetaDescarga.Location = new System.Drawing.Point(848, 528);
            this.pbVistaConfiguracionCarpetaDescarga.Name = "pbVistaConfiguracionCarpetaDescarga";
            this.pbVistaConfiguracionCarpetaDescarga.Size = new System.Drawing.Size(55, 42);
            this.pbVistaConfiguracionCarpetaDescarga.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaConfiguracionCarpetaDescarga.TabIndex = 3;
            this.pbVistaConfiguracionCarpetaDescarga.TabStop = false;
            this.pbVistaConfiguracionCarpetaDescarga.Click += new System.EventHandler(this.SeleccionarCarpetaDescargas);
            // 
            // lblVistaConfiguracionMinimizarBanjeda
            // 
            this.lblVistaConfiguracionMinimizarBanjeda.AutoSize = true;
            this.lblVistaConfiguracionMinimizarBanjeda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionMinimizarBanjeda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionMinimizarBanjeda.Location = new System.Drawing.Point(167, 118);
            this.lblVistaConfiguracionMinimizarBanjeda.Name = "lblVistaConfiguracionMinimizarBanjeda";
            this.lblVistaConfiguracionMinimizarBanjeda.Size = new System.Drawing.Size(178, 24);
            this.lblVistaConfiguracionMinimizarBanjeda.TabIndex = 1;
            this.lblVistaConfiguracionMinimizarBanjeda.Text = "Minimizar a bandeja";
            // 
            // bsVistaConfiguracionTema
            // 
            this.bsVistaConfiguracionTema.Activo = true;
            this.bsVistaConfiguracionTema.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bsVistaConfiguracionTema.BackColor = System.Drawing.Color.Transparent;
            this.bsVistaConfiguracionTema.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsVistaConfiguracionTema.Location = new System.Drawing.Point(746, 338);
            this.bsVistaConfiguracionTema.Margin = new System.Windows.Forms.Padding(4);
            this.bsVistaConfiguracionTema.Name = "bsVistaConfiguracionTema";
            this.bsVistaConfiguracionTema.Size = new System.Drawing.Size(36, 18);
            this.bsVistaConfiguracionTema.TabIndex = 2;
            this.bsVistaConfiguracionTema.Tag = "24";
            this.bsVistaConfiguracionTema.Clickaso += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // lblVistaConfiguracionIniciarConWindows
            // 
            this.lblVistaConfiguracionIniciarConWindows.AutoSize = true;
            this.lblVistaConfiguracionIniciarConWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionIniciarConWindows.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionIniciarConWindows.Location = new System.Drawing.Point(167, 70);
            this.lblVistaConfiguracionIniciarConWindows.Name = "lblVistaConfiguracionIniciarConWindows";
            this.lblVistaConfiguracionIniciarConWindows.Size = new System.Drawing.Size(175, 24);
            this.lblVistaConfiguracionIniciarConWindows.TabIndex = 1;
            this.lblVistaConfiguracionIniciarConWindows.Text = "Iniciar con windows";
            // 
            // bsVistaConfiguracionLatino
            // 
            this.bsVistaConfiguracionLatino.Activo = true;
            this.bsVistaConfiguracionLatino.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.bsVistaConfiguracionLatino.BackColor = System.Drawing.Color.Transparent;
            this.bsVistaConfiguracionLatino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsVistaConfiguracionLatino.Location = new System.Drawing.Point(746, 97);
            this.bsVistaConfiguracionLatino.Margin = new System.Windows.Forms.Padding(4);
            this.bsVistaConfiguracionLatino.Name = "bsVistaConfiguracionLatino";
            this.bsVistaConfiguracionLatino.Size = new System.Drawing.Size(36, 18);
            this.bsVistaConfiguracionLatino.TabIndex = 2;
            this.bsVistaConfiguracionLatino.Tag = "13";
            this.bsVistaConfiguracionLatino.Clickaso += new System.EventHandler(this.CambiarConfiguracion);
            // 
            // lblVistaConfiguracionTema
            // 
            this.lblVistaConfiguracionTema.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionTema.AutoSize = true;
            this.lblVistaConfiguracionTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionTema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionTema.Location = new System.Drawing.Point(735, 309);
            this.lblVistaConfiguracionTema.Name = "lblVistaConfiguracionTema";
            this.lblVistaConfiguracionTema.Size = new System.Drawing.Size(59, 24);
            this.lblVistaConfiguracionTema.TabIndex = 1;
            this.lblVistaConfiguracionTema.Text = "Tema";
            // 
            // lblVistaConfiguracionRutaDescarga
            // 
            this.lblVistaConfiguracionRutaDescarga.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionRutaDescarga.AutoSize = true;
            this.lblVistaConfiguracionRutaDescarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionRutaDescarga.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionRutaDescarga.Location = new System.Drawing.Point(680, 538);
            this.lblVistaConfiguracionRutaDescarga.Name = "lblVistaConfiguracionRutaDescarga";
            this.lblVistaConfiguracionRutaDescarga.Size = new System.Drawing.Size(158, 24);
            this.lblVistaConfiguracionRutaDescarga.TabIndex = 1;
            this.lblVistaConfiguracionRutaDescarga.Text = "Ruta de descarga";
            // 
            // lblVistaConfiguracionKbpsBajada
            // 
            this.lblVistaConfiguracionKbpsBajada.AutoSize = true;
            this.lblVistaConfiguracionKbpsBajada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionKbpsBajada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionKbpsBajada.Location = new System.Drawing.Point(320, 538);
            this.lblVistaConfiguracionKbpsBajada.Name = "lblVistaConfiguracionKbpsBajada";
            this.lblVistaConfiguracionKbpsBajada.Size = new System.Drawing.Size(53, 24);
            this.lblVistaConfiguracionKbpsBajada.TabIndex = 1;
            this.lblVistaConfiguracionKbpsBajada.Text = "Kbps";
            // 
            // lblVistaConfiguracionKbpsSubida
            // 
            this.lblVistaConfiguracionKbpsSubida.AutoSize = true;
            this.lblVistaConfiguracionKbpsSubida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionKbpsSubida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionKbpsSubida.Location = new System.Drawing.Point(320, 485);
            this.lblVistaConfiguracionKbpsSubida.Name = "lblVistaConfiguracionKbpsSubida";
            this.lblVistaConfiguracionKbpsSubida.Size = new System.Drawing.Size(53, 24);
            this.lblVistaConfiguracionKbpsSubida.TabIndex = 1;
            this.lblVistaConfiguracionKbpsSubida.Text = "Kbps";
            // 
            // lblVistaConfiguracionLimiteSubida
            // 
            this.lblVistaConfiguracionLimiteSubida.AutoSize = true;
            this.lblVistaConfiguracionLimiteSubida.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionLimiteSubida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionLimiteSubida.Location = new System.Drawing.Point(121, 485);
            this.lblVistaConfiguracionLimiteSubida.Name = "lblVistaConfiguracionLimiteSubida";
            this.lblVistaConfiguracionLimiteSubida.Size = new System.Drawing.Size(120, 24);
            this.lblVistaConfiguracionLimiteSubida.TabIndex = 1;
            this.lblVistaConfiguracionLimiteSubida.Text = "Limite subida";
            // 
            // lblVistaConfiguracionLimiteBajada
            // 
            this.lblVistaConfiguracionLimiteBajada.AutoSize = true;
            this.lblVistaConfiguracionLimiteBajada.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionLimiteBajada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionLimiteBajada.Location = new System.Drawing.Point(122, 538);
            this.lblVistaConfiguracionLimiteBajada.Name = "lblVistaConfiguracionLimiteBajada";
            this.lblVistaConfiguracionLimiteBajada.Size = new System.Drawing.Size(120, 24);
            this.lblVistaConfiguracionLimiteBajada.TabIndex = 1;
            this.lblVistaConfiguracionLimiteBajada.Text = "Limite bajada";
            // 
            // lblVistaConfiguracionLimiteDescargas
            // 
            this.lblVistaConfiguracionLimiteDescargas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionLimiteDescargas.AutoSize = true;
            this.lblVistaConfiguracionLimiteDescargas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionLimiteDescargas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionLimiteDescargas.Location = new System.Drawing.Point(630, 485);
            this.lblVistaConfiguracionLimiteDescargas.Name = "lblVistaConfiguracionLimiteDescargas";
            this.lblVistaConfiguracionLimiteDescargas.Size = new System.Drawing.Size(203, 24);
            this.lblVistaConfiguracionLimiteDescargas.TabIndex = 1;
            this.lblVistaConfiguracionLimiteDescargas.Text = "Descargas simultaneas";
            // 
            // lblVistaConfiguracionTemaClaro
            // 
            this.lblVistaConfiguracionTemaClaro.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionTemaClaro.AutoSize = true;
            this.lblVistaConfiguracionTemaClaro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionTemaClaro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionTemaClaro.Location = new System.Drawing.Point(687, 336);
            this.lblVistaConfiguracionTemaClaro.Name = "lblVistaConfiguracionTemaClaro";
            this.lblVistaConfiguracionTemaClaro.Size = new System.Drawing.Size(54, 24);
            this.lblVistaConfiguracionTemaClaro.TabIndex = 1;
            this.lblVistaConfiguracionTemaClaro.Text = "Claro";
            // 
            // lblVistaConfiguracionIngles
            // 
            this.lblVistaConfiguracionIngles.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionIngles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionIngles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionIngles.Location = new System.Drawing.Point(662, 95);
            this.lblVistaConfiguracionIngles.Name = "lblVistaConfiguracionIngles";
            this.lblVistaConfiguracionIngles.Size = new System.Drawing.Size(78, 23);
            this.lblVistaConfiguracionIngles.TabIndex = 1;
            this.lblVistaConfiguracionIngles.Text = "Ingles";
            this.lblVistaConfiguracionIngles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVistaConfiguracionTemaOscuro
            // 
            this.lblVistaConfiguracionTemaOscuro.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionTemaOscuro.AutoSize = true;
            this.lblVistaConfiguracionTemaOscuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionTemaOscuro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionTemaOscuro.Location = new System.Drawing.Point(792, 336);
            this.lblVistaConfiguracionTemaOscuro.Name = "lblVistaConfiguracionTemaOscuro";
            this.lblVistaConfiguracionTemaOscuro.Size = new System.Drawing.Size(72, 24);
            this.lblVistaConfiguracionTemaOscuro.TabIndex = 1;
            this.lblVistaConfiguracionTemaOscuro.Text = "Oscuro";
            // 
            // lblVistaConfiguracionEspañol
            // 
            this.lblVistaConfiguracionEspañol.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionEspañol.AutoSize = true;
            this.lblVistaConfiguracionEspañol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionEspañol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionEspañol.Location = new System.Drawing.Point(792, 95);
            this.lblVistaConfiguracionEspañol.Name = "lblVistaConfiguracionEspañol";
            this.lblVistaConfiguracionEspañol.Size = new System.Drawing.Size(79, 24);
            this.lblVistaConfiguracionEspañol.TabIndex = 1;
            this.lblVistaConfiguracionEspañol.Text = "Español";
            // 
            // lblVistaConfiguracionIdioma
            // 
            this.lblVistaConfiguracionIdioma.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVistaConfiguracionIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblVistaConfiguracionIdioma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblVistaConfiguracionIdioma.Location = new System.Drawing.Point(712, 70);
            this.lblVistaConfiguracionIdioma.Name = "lblVistaConfiguracionIdioma";
            this.lblVistaConfiguracionIdioma.Size = new System.Drawing.Size(106, 23);
            this.lblVistaConfiguracionIdioma.TabIndex = 1;
            this.lblVistaConfiguracionIdioma.Text = "Idioma";
            this.lblVistaConfiguracionIdioma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlVistaAbout
            // 
            this.pnlVistaAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlVistaAbout.Controls.Add(this.tbVistaAboutDescripcion);
            this.pnlVistaAbout.Controls.Add(this.pbVistaAboutBotonJulio);
            this.pnlVistaAbout.Controls.Add(this.pbVistaBotonLcs);
            this.pnlVistaAbout.Controls.Add(this.pbVistaAbout);
            this.pnlVistaAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVistaAbout.Location = new System.Drawing.Point(0, 0);
            this.pnlVistaAbout.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVistaAbout.Name = "pnlVistaAbout";
            this.pnlVistaAbout.Size = new System.Drawing.Size(1035, 619);
            this.pnlVistaAbout.TabIndex = 13;
            this.pnlVistaAbout.Tag = "6";
            this.pnlVistaAbout.Visible = false;
            // 
            // tbVistaAboutDescripcion
            // 
            this.tbVistaAboutDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbVistaAboutDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.tbVistaAboutDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbVistaAboutDescripcion.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbVistaAboutDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbVistaAboutDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.tbVistaAboutDescripcion.Location = new System.Drawing.Point(28, 374);
            this.tbVistaAboutDescripcion.Multiline = true;
            this.tbVistaAboutDescripcion.Name = "tbVistaAboutDescripcion";
            this.tbVistaAboutDescripcion.ReadOnly = true;
            this.tbVistaAboutDescripcion.Size = new System.Drawing.Size(978, 103);
            this.tbVistaAboutDescripcion.TabIndex = 3;
            this.tbVistaAboutDescripcion.Text = "Este proyecto fue realizado por alumnos de 3er año de la Universidad de la Punta " +
    "(ULP) para la materia optativa programación concurrente como objetivo de cursada" +
    "";
            this.tbVistaAboutDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbVistaAboutDescripcion.Enter += new System.EventHandler(this.TBSinFoco);
            // 
            // pbVistaAboutBotonJulio
            // 
            this.pbVistaAboutBotonJulio.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbVistaAboutBotonJulio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaAboutBotonJulio.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaAboutBotonJulio.Image")));
            this.pbVistaAboutBotonJulio.Location = new System.Drawing.Point(595, 528);
            this.pbVistaAboutBotonJulio.Name = "pbVistaAboutBotonJulio";
            this.pbVistaAboutBotonJulio.Size = new System.Drawing.Size(378, 67);
            this.pbVistaAboutBotonJulio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaAboutBotonJulio.TabIndex = 2;
            this.pbVistaAboutBotonJulio.TabStop = false;
            this.pbVistaAboutBotonJulio.Tag = "J";
            this.pbVistaAboutBotonJulio.Click += new System.EventHandler(this.MostrarInformacionPersonal);
            // 
            // pbVistaBotonLcs
            // 
            this.pbVistaBotonLcs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbVistaBotonLcs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbVistaBotonLcs.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaBotonLcs.Image")));
            this.pbVistaBotonLcs.Location = new System.Drawing.Point(62, 528);
            this.pbVistaBotonLcs.Name = "pbVistaBotonLcs";
            this.pbVistaBotonLcs.Size = new System.Drawing.Size(378, 67);
            this.pbVistaBotonLcs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbVistaBotonLcs.TabIndex = 1;
            this.pbVistaBotonLcs.TabStop = false;
            this.pbVistaBotonLcs.Tag = "L";
            this.pbVistaBotonLcs.Click += new System.EventHandler(this.MostrarInformacionPersonal);
            // 
            // pbVistaAbout
            // 
            this.pbVistaAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbVistaAbout.Image = ((System.Drawing.Image)(resources.GetObject("pbVistaAbout.Image")));
            this.pbVistaAbout.Location = new System.Drawing.Point(193, 24);
            this.pbVistaAbout.Name = "pbVistaAbout";
            this.pbVistaAbout.Size = new System.Drawing.Size(649, 317);
            this.pbVistaAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbVistaAbout.TabIndex = 0;
            this.pbVistaAbout.TabStop = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.pnlMenu.Controls.Add(this.pnlMenuConfiguracionesRapidas);
            this.pnlMenu.Controls.Add(this.pnlRojoMenu);
            this.pnlMenu.Controls.Add(this.pnlMenuExpandir);
            this.pnlMenu.Controls.Add(this.pnlMenuAbout);
            this.pnlMenu.Controls.Add(this.pnlMenuConfiguracion);
            this.pnlMenu.Controls.Add(this.pnlMenuSolicitar);
            this.pnlMenu.Controls.Add(this.pnlMenuCompartir);
            this.pnlMenu.Controls.Add(this.pnlMenuExplorar);
            this.pnlMenu.Controls.Add(this.pnlMenuDescargar);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 31);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(65, 619);
            this.pnlMenu.TabIndex = 13;
            this.pnlMenu.Tag = "7";
            // 
            // pnlMenuConfiguracionesRapidas
            // 
            this.pnlMenuConfiguracionesRapidas.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuConfiguracionesRapidas.Controls.Add(this.lblMenuCRapidas);
            this.pnlMenuConfiguracionesRapidas.Controls.Add(this.lblMenuConfiguracionesR);
            this.pnlMenuConfiguracionesRapidas.Controls.Add(this.pbMenuConfiguracionesRapidas);
            this.pnlMenuConfiguracionesRapidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuConfiguracionesRapidas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMenuConfiguracionesRapidas.Location = new System.Drawing.Point(0, 558);
            this.pnlMenuConfiguracionesRapidas.Name = "pnlMenuConfiguracionesRapidas";
            this.pnlMenuConfiguracionesRapidas.Size = new System.Drawing.Size(65, 61);
            this.pnlMenuConfiguracionesRapidas.TabIndex = 11;
            this.pnlMenuConfiguracionesRapidas.Tag = "6";
            this.pnlMenuConfiguracionesRapidas.Click += new System.EventHandler(this.AbrirConfigRapidas);
            // 
            // lblMenuCRapidas
            // 
            this.lblMenuCRapidas.AutoSize = true;
            this.lblMenuCRapidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuCRapidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMenuCRapidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMenuCRapidas.Location = new System.Drawing.Point(98, 31);
            this.lblMenuCRapidas.Name = "lblMenuCRapidas";
            this.lblMenuCRapidas.Size = new System.Drawing.Size(68, 20);
            this.lblMenuCRapidas.TabIndex = 2;
            this.lblMenuCRapidas.Tag = "6";
            this.lblMenuCRapidas.Text = "Rapidas";
            this.lblMenuCRapidas.Click += new System.EventHandler(this.AbrirConfigRapidas);
            // 
            // lblMenuConfiguracionesR
            // 
            this.lblMenuConfiguracionesR.AutoSize = true;
            this.lblMenuConfiguracionesR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuConfiguracionesR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMenuConfiguracionesR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMenuConfiguracionesR.Location = new System.Drawing.Point(69, 10);
            this.lblMenuConfiguracionesR.Name = "lblMenuConfiguracionesR";
            this.lblMenuConfiguracionesR.Size = new System.Drawing.Size(124, 20);
            this.lblMenuConfiguracionesR.TabIndex = 2;
            this.lblMenuConfiguracionesR.Tag = "6";
            this.lblMenuConfiguracionesR.Text = "Configuraciones";
            this.lblMenuConfiguracionesR.Click += new System.EventHandler(this.AbrirConfigRapidas);
            // 
            // pbMenuConfiguracionesRapidas
            // 
            this.pbMenuConfiguracionesRapidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMenuConfiguracionesRapidas.Image = ((System.Drawing.Image)(resources.GetObject("pbMenuConfiguracionesRapidas.Image")));
            this.pbMenuConfiguracionesRapidas.Location = new System.Drawing.Point(18, 16);
            this.pbMenuConfiguracionesRapidas.Name = "pbMenuConfiguracionesRapidas";
            this.pbMenuConfiguracionesRapidas.Size = new System.Drawing.Size(29, 29);
            this.pbMenuConfiguracionesRapidas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuConfiguracionesRapidas.TabIndex = 1;
            this.pbMenuConfiguracionesRapidas.TabStop = false;
            this.pbMenuConfiguracionesRapidas.Tag = "6";
            this.pbMenuConfiguracionesRapidas.Click += new System.EventHandler(this.AbrirConfigRapidas);
            // 
            // pnlRojoMenu
            // 
            this.pnlRojoMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.pnlRojoMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlRojoMenu.Location = new System.Drawing.Point(0, 81);
            this.pnlRojoMenu.Name = "pnlRojoMenu";
            this.pnlRojoMenu.Size = new System.Drawing.Size(3, 61);
            this.pnlRojoMenu.TabIndex = 11;
            this.pnlRojoMenu.Tag = "1";
            // 
            // pnlMenuExpandir
            // 
            this.pnlMenuExpandir.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuExpandir.Controls.Add(this.pbMenuExpandir);
            this.pnlMenuExpandir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuExpandir.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuExpandir.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuExpandir.Name = "pnlMenuExpandir";
            this.pnlMenuExpandir.Size = new System.Drawing.Size(65, 61);
            this.pnlMenuExpandir.TabIndex = 6;
            this.pnlMenuExpandir.Tag = "0";
            this.pnlMenuExpandir.Click += new System.EventHandler(this.ExpandirMenu);
            // 
            // pbMenuExpandir
            // 
            this.pbMenuExpandir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbMenuExpandir.Image = ((System.Drawing.Image)(resources.GetObject("pbMenuExpandir.Image")));
            this.pbMenuExpandir.Location = new System.Drawing.Point(15, 27);
            this.pbMenuExpandir.Name = "pbMenuExpandir";
            this.pbMenuExpandir.Size = new System.Drawing.Size(36, 7);
            this.pbMenuExpandir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuExpandir.TabIndex = 6;
            this.pbMenuExpandir.TabStop = false;
            this.pbMenuExpandir.Tag = "0";
            this.pbMenuExpandir.Click += new System.EventHandler(this.ExpandirMenu);
            // 
            // pnlMenuAbout
            // 
            this.pnlMenuAbout.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuAbout.Controls.Add(this.pnlMenuRojoAbout);
            this.pnlMenuAbout.Controls.Add(this.lblMenuAbout);
            this.pnlMenuAbout.Controls.Add(this.pbMenuAbout);
            this.pnlMenuAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuAbout.Location = new System.Drawing.Point(0, 476);
            this.pnlMenuAbout.Name = "pnlMenuAbout";
            this.pnlMenuAbout.Size = new System.Drawing.Size(210, 61);
            this.pnlMenuAbout.TabIndex = 10;
            this.pnlMenuAbout.Tag = "6";
            this.pnlMenuAbout.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuRojoAbout
            // 
            this.pnlMenuRojoAbout.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuRojoAbout.Location = new System.Drawing.Point(0, 58);
            this.pnlMenuRojoAbout.Name = "pnlMenuRojoAbout";
            this.pnlMenuRojoAbout.Size = new System.Drawing.Size(210, 3);
            this.pnlMenuRojoAbout.TabIndex = 6;
            this.pnlMenuRojoAbout.Tag = "6";
            this.pnlMenuRojoAbout.Click += new System.EventHandler(this.ClickMenu);
            // 
            // lblMenuAbout
            // 
            this.lblMenuAbout.AutoSize = true;
            this.lblMenuAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMenuAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMenuAbout.Location = new System.Drawing.Point(66, 19);
            this.lblMenuAbout.Name = "lblMenuAbout";
            this.lblMenuAbout.Size = new System.Drawing.Size(132, 24);
            this.lblMenuAbout.TabIndex = 2;
            this.lblMenuAbout.Tag = "6";
            this.lblMenuAbout.Text = "Sobre bitNode";
            this.lblMenuAbout.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pbMenuAbout
            // 
            this.pbMenuAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMenuAbout.Image = ((System.Drawing.Image)(resources.GetObject("pbMenuAbout.Image")));
            this.pbMenuAbout.Location = new System.Drawing.Point(18, 16);
            this.pbMenuAbout.Name = "pbMenuAbout";
            this.pbMenuAbout.Size = new System.Drawing.Size(29, 29);
            this.pbMenuAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuAbout.TabIndex = 1;
            this.pbMenuAbout.TabStop = false;
            this.pbMenuAbout.Tag = "6";
            this.pbMenuAbout.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuConfiguracion
            // 
            this.pnlMenuConfiguracion.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuConfiguracion.Controls.Add(this.pnlMenuRojoConfiguracion);
            this.pnlMenuConfiguracion.Controls.Add(this.lblMenuConfiguracion);
            this.pnlMenuConfiguracion.Controls.Add(this.pbMenuConfiguracion);
            this.pnlMenuConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuConfiguracion.Location = new System.Drawing.Point(0, 397);
            this.pnlMenuConfiguracion.Name = "pnlMenuConfiguracion";
            this.pnlMenuConfiguracion.Size = new System.Drawing.Size(210, 61);
            this.pnlMenuConfiguracion.TabIndex = 10;
            this.pnlMenuConfiguracion.Tag = "5";
            this.pnlMenuConfiguracion.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuRojoConfiguracion
            // 
            this.pnlMenuRojoConfiguracion.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuRojoConfiguracion.Location = new System.Drawing.Point(0, 58);
            this.pnlMenuRojoConfiguracion.Name = "pnlMenuRojoConfiguracion";
            this.pnlMenuRojoConfiguracion.Size = new System.Drawing.Size(210, 3);
            this.pnlMenuRojoConfiguracion.TabIndex = 6;
            this.pnlMenuRojoConfiguracion.Tag = "5";
            this.pnlMenuRojoConfiguracion.Click += new System.EventHandler(this.ClickMenu);
            // 
            // lblMenuConfiguracion
            // 
            this.lblMenuConfiguracion.AutoSize = true;
            this.lblMenuConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMenuConfiguracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMenuConfiguracion.Location = new System.Drawing.Point(66, 19);
            this.lblMenuConfiguracion.Name = "lblMenuConfiguracion";
            this.lblMenuConfiguracion.Size = new System.Drawing.Size(127, 24);
            this.lblMenuConfiguracion.TabIndex = 2;
            this.lblMenuConfiguracion.Tag = "5";
            this.lblMenuConfiguracion.Text = "Configuracion";
            this.lblMenuConfiguracion.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pbMenuConfiguracion
            // 
            this.pbMenuConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMenuConfiguracion.Image = ((System.Drawing.Image)(resources.GetObject("pbMenuConfiguracion.Image")));
            this.pbMenuConfiguracion.Location = new System.Drawing.Point(18, 16);
            this.pbMenuConfiguracion.Name = "pbMenuConfiguracion";
            this.pbMenuConfiguracion.Size = new System.Drawing.Size(29, 29);
            this.pbMenuConfiguracion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuConfiguracion.TabIndex = 1;
            this.pbMenuConfiguracion.TabStop = false;
            this.pbMenuConfiguracion.Tag = "5";
            this.pbMenuConfiguracion.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuSolicitar
            // 
            this.pnlMenuSolicitar.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuSolicitar.Controls.Add(this.pnlMenuRojoSolicitar);
            this.pnlMenuSolicitar.Controls.Add(this.lblMenuSolicitar);
            this.pnlMenuSolicitar.Controls.Add(this.pbMenuSolicitar);
            this.pnlMenuSolicitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuSolicitar.Location = new System.Drawing.Point(0, 318);
            this.pnlMenuSolicitar.Name = "pnlMenuSolicitar";
            this.pnlMenuSolicitar.Size = new System.Drawing.Size(210, 61);
            this.pnlMenuSolicitar.TabIndex = 9;
            this.pnlMenuSolicitar.Tag = "4";
            this.pnlMenuSolicitar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuRojoSolicitar
            // 
            this.pnlMenuRojoSolicitar.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuRojoSolicitar.Location = new System.Drawing.Point(0, 58);
            this.pnlMenuRojoSolicitar.Name = "pnlMenuRojoSolicitar";
            this.pnlMenuRojoSolicitar.Size = new System.Drawing.Size(210, 3);
            this.pnlMenuRojoSolicitar.TabIndex = 5;
            this.pnlMenuRojoSolicitar.Tag = "4";
            this.pnlMenuRojoSolicitar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // lblMenuSolicitar
            // 
            this.lblMenuSolicitar.AutoSize = true;
            this.lblMenuSolicitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuSolicitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMenuSolicitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMenuSolicitar.Location = new System.Drawing.Point(66, 19);
            this.lblMenuSolicitar.Name = "lblMenuSolicitar";
            this.lblMenuSolicitar.Size = new System.Drawing.Size(75, 24);
            this.lblMenuSolicitar.TabIndex = 2;
            this.lblMenuSolicitar.Tag = "4";
            this.lblMenuSolicitar.Text = "Solicitar";
            this.lblMenuSolicitar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pbMenuSolicitar
            // 
            this.pbMenuSolicitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMenuSolicitar.Image = ((System.Drawing.Image)(resources.GetObject("pbMenuSolicitar.Image")));
            this.pbMenuSolicitar.Location = new System.Drawing.Point(18, 16);
            this.pbMenuSolicitar.Name = "pbMenuSolicitar";
            this.pbMenuSolicitar.Size = new System.Drawing.Size(29, 29);
            this.pbMenuSolicitar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuSolicitar.TabIndex = 1;
            this.pbMenuSolicitar.TabStop = false;
            this.pbMenuSolicitar.Tag = "4";
            this.pbMenuSolicitar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuCompartir
            // 
            this.pnlMenuCompartir.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuCompartir.Controls.Add(this.pnlMenuRojoCompartir);
            this.pnlMenuCompartir.Controls.Add(this.lblMenuCompartir);
            this.pnlMenuCompartir.Controls.Add(this.pbMenuCompartir);
            this.pnlMenuCompartir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuCompartir.Location = new System.Drawing.Point(0, 239);
            this.pnlMenuCompartir.Name = "pnlMenuCompartir";
            this.pnlMenuCompartir.Size = new System.Drawing.Size(210, 61);
            this.pnlMenuCompartir.TabIndex = 8;
            this.pnlMenuCompartir.Tag = "3";
            this.pnlMenuCompartir.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuRojoCompartir
            // 
            this.pnlMenuRojoCompartir.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuRojoCompartir.Location = new System.Drawing.Point(0, 58);
            this.pnlMenuRojoCompartir.Name = "pnlMenuRojoCompartir";
            this.pnlMenuRojoCompartir.Size = new System.Drawing.Size(210, 3);
            this.pnlMenuRojoCompartir.TabIndex = 5;
            this.pnlMenuRojoCompartir.Tag = "3";
            this.pnlMenuRojoCompartir.Click += new System.EventHandler(this.ClickMenu);
            // 
            // lblMenuCompartir
            // 
            this.lblMenuCompartir.AutoSize = true;
            this.lblMenuCompartir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuCompartir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMenuCompartir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMenuCompartir.Location = new System.Drawing.Point(66, 19);
            this.lblMenuCompartir.Name = "lblMenuCompartir";
            this.lblMenuCompartir.Size = new System.Drawing.Size(91, 24);
            this.lblMenuCompartir.TabIndex = 2;
            this.lblMenuCompartir.Tag = "3";
            this.lblMenuCompartir.Text = "Compartir";
            this.lblMenuCompartir.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pbMenuCompartir
            // 
            this.pbMenuCompartir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMenuCompartir.Image = ((System.Drawing.Image)(resources.GetObject("pbMenuCompartir.Image")));
            this.pbMenuCompartir.Location = new System.Drawing.Point(18, 16);
            this.pbMenuCompartir.Name = "pbMenuCompartir";
            this.pbMenuCompartir.Size = new System.Drawing.Size(29, 29);
            this.pbMenuCompartir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuCompartir.TabIndex = 1;
            this.pbMenuCompartir.TabStop = false;
            this.pbMenuCompartir.Tag = "3";
            this.pbMenuCompartir.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuExplorar
            // 
            this.pnlMenuExplorar.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuExplorar.Controls.Add(this.pnlMenuRojoExplorar);
            this.pnlMenuExplorar.Controls.Add(this.lblMenuExplorar);
            this.pnlMenuExplorar.Controls.Add(this.pbMenuExplorar);
            this.pnlMenuExplorar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuExplorar.Location = new System.Drawing.Point(0, 160);
            this.pnlMenuExplorar.Name = "pnlMenuExplorar";
            this.pnlMenuExplorar.Size = new System.Drawing.Size(210, 61);
            this.pnlMenuExplorar.TabIndex = 7;
            this.pnlMenuExplorar.Tag = "2";
            this.pnlMenuExplorar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuRojoExplorar
            // 
            this.pnlMenuRojoExplorar.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuRojoExplorar.Location = new System.Drawing.Point(0, 58);
            this.pnlMenuRojoExplorar.Name = "pnlMenuRojoExplorar";
            this.pnlMenuRojoExplorar.Size = new System.Drawing.Size(210, 3);
            this.pnlMenuRojoExplorar.TabIndex = 4;
            this.pnlMenuRojoExplorar.Tag = "2";
            this.pnlMenuRojoExplorar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // lblMenuExplorar
            // 
            this.lblMenuExplorar.AutoSize = true;
            this.lblMenuExplorar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuExplorar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMenuExplorar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMenuExplorar.Location = new System.Drawing.Point(66, 19);
            this.lblMenuExplorar.Name = "lblMenuExplorar";
            this.lblMenuExplorar.Size = new System.Drawing.Size(81, 24);
            this.lblMenuExplorar.TabIndex = 2;
            this.lblMenuExplorar.Tag = "2";
            this.lblMenuExplorar.Text = "Explorar";
            this.lblMenuExplorar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pbMenuExplorar
            // 
            this.pbMenuExplorar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMenuExplorar.Image = ((System.Drawing.Image)(resources.GetObject("pbMenuExplorar.Image")));
            this.pbMenuExplorar.Location = new System.Drawing.Point(18, 16);
            this.pbMenuExplorar.Name = "pbMenuExplorar";
            this.pbMenuExplorar.Size = new System.Drawing.Size(29, 29);
            this.pbMenuExplorar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuExplorar.TabIndex = 1;
            this.pbMenuExplorar.TabStop = false;
            this.pbMenuExplorar.Tag = "2";
            this.pbMenuExplorar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuDescargar
            // 
            this.pnlMenuDescargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(9)))), ((int)(((byte)(17)))));
            this.pnlMenuDescargar.Controls.Add(this.pnlMenuRojoDescargar);
            this.pnlMenuDescargar.Controls.Add(this.lblMenuDescargar);
            this.pnlMenuDescargar.Controls.Add(this.pbMenuDescargar);
            this.pnlMenuDescargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlMenuDescargar.Location = new System.Drawing.Point(0, 81);
            this.pnlMenuDescargar.Name = "pnlMenuDescargar";
            this.pnlMenuDescargar.Size = new System.Drawing.Size(210, 61);
            this.pnlMenuDescargar.TabIndex = 5;
            this.pnlMenuDescargar.Tag = "1";
            this.pnlMenuDescargar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pnlMenuRojoDescargar
            // 
            this.pnlMenuRojoDescargar.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenuRojoDescargar.Location = new System.Drawing.Point(0, 58);
            this.pnlMenuRojoDescargar.Name = "pnlMenuRojoDescargar";
            this.pnlMenuRojoDescargar.Size = new System.Drawing.Size(210, 3);
            this.pnlMenuRojoDescargar.TabIndex = 3;
            this.pnlMenuRojoDescargar.Tag = "1";
            this.pnlMenuRojoDescargar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // lblMenuDescargar
            // 
            this.lblMenuDescargar.AutoSize = true;
            this.lblMenuDescargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMenuDescargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblMenuDescargar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMenuDescargar.Location = new System.Drawing.Point(66, 19);
            this.lblMenuDescargar.Name = "lblMenuDescargar";
            this.lblMenuDescargar.Size = new System.Drawing.Size(96, 24);
            this.lblMenuDescargar.TabIndex = 2;
            this.lblMenuDescargar.Tag = "1";
            this.lblMenuDescargar.Text = "Descargar";
            this.lblMenuDescargar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // pbMenuDescargar
            // 
            this.pbMenuDescargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMenuDescargar.Image = ((System.Drawing.Image)(resources.GetObject("pbMenuDescargar.Image")));
            this.pbMenuDescargar.Location = new System.Drawing.Point(18, 16);
            this.pbMenuDescargar.Name = "pbMenuDescargar";
            this.pbMenuDescargar.Size = new System.Drawing.Size(29, 29);
            this.pbMenuDescargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMenuDescargar.TabIndex = 1;
            this.pbMenuDescargar.TabStop = false;
            this.pbMenuDescargar.Tag = "1";
            this.pbMenuDescargar.Click += new System.EventHandler(this.ClickMenu);
            // 
            // ttAyuda
            // 
            this.ttAyuda.BackColor = System.Drawing.Color.Silver;
            this.ttAyuda.OwnerDraw = true;
            this.ttAyuda.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ttAyuda_Draw);
            this.ttAyuda.Popup += new System.Windows.Forms.PopupEventHandler(this.ttAyuda_Popup);
            // 
            // niMinimizar
            // 
            this.niMinimizar.Icon = ((System.Drawing.Icon)(resources.GetObject("niMinimizar.Icon")));
            this.niMinimizar.Tag = "niMinimizar";
            this.niMinimizar.Text = "bitNode";
            this.niMinimizar.Click += new System.EventHandler(this.Maximizar);
            // 
            // ofdArchivo
            // 
            this.ofdArchivo.Title = "Seleccione un archivo";
            // 
            // tmrModificarAN
            // 
            this.tmrModificarAN.Interval = 1000;
            this.tmrModificarAN.Tick += new System.EventHandler(this.CargarNuevosValoresDescargados);
            // 
            // frmCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlVistaContenedor);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlBarraGris1Px);
            this.Controls.Add(this.pnlBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCliente";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bitNode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.bitNodeClosing);
            this.SizeChanged += new System.EventHandler(this.TimerOn);
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcono)).EndInit();
            this.pnlVistaContenedor.ResumeLayout(false);
            this.pnlVistaDescargar.ResumeLayout(false);
            this.pnlVistaDescargarContenedor.ResumeLayout(false);
            this.pnlVistaDescargarContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaDescargarStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaDescargarStart)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaDescargas)).EndInit();
            this.pnlVistaExplorar.ResumeLayout(false);
            this.pnlVistaExploarBuscar.ResumeLayout(false);
            this.pnlVistaExploarBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaExplorarBuscar)).EndInit();
            this.pnlVistaExplorarDGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaExplorarArchivosCompartidosVecinos)).EndInit();
            this.pnlVistaCompartir.ResumeLayout(false);
            this.pnlVistaCompartirMostarArchivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaCompartirArchivos)).EndInit();
            this.pnlVistaCompartirGuardarArchivo.ResumeLayout(false);
            this.pnlVistaCompartirGuardarArchivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaCompartirCancelar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaCompartirArchivo)).EndInit();
            this.pnlVistaCompartirSeleccionarArchivo.ResumeLayout(false);
            this.pnlVistaCompartirSeleccionarArchivo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaCompartirSeleccionarArchivo)).EndInit();
            this.pnlVistaSolicitar.ResumeLayout(false);
            this.pnlVistaSolicitarVerSolicitudes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVistaSolicitar)).EndInit();
            this.pnlVistaSolicitarCompartirSolicitud.ResumeLayout(false);
            this.pnlVistaSolicitarCompartirSolicitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlVistaConfiguracionGeneral.ResumeLayout(false);
            this.pnlVistaConfiguracionGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaConfiguracionReconectar)).EndInit();
            this.pnlVistaComfiguracionInterfaz.ResumeLayout(false);
            this.pnlVistaConfiguracionTransferencias.ResumeLayout(false);
            this.pnlVistaComfiguracionGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaConfiguracionCarpetaDescarga)).EndInit();
            this.pnlVistaAbout.ResumeLayout(false);
            this.pnlVistaAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaAboutBotonJulio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaBotonLcs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVistaAbout)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenuConfiguracionesRapidas.ResumeLayout(false);
            this.pnlMenuConfiguracionesRapidas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuConfiguracionesRapidas)).EndInit();
            this.pnlMenuExpandir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuExpandir)).EndInit();
            this.pnlMenuAbout.ResumeLayout(false);
            this.pnlMenuAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuAbout)).EndInit();
            this.pnlMenuConfiguracion.ResumeLayout(false);
            this.pnlMenuConfiguracion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuConfiguracion)).EndInit();
            this.pnlMenuSolicitar.ResumeLayout(false);
            this.pnlMenuSolicitar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuSolicitar)).EndInit();
            this.pnlMenuCompartir.ResumeLayout(false);
            this.pnlMenuCompartir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuCompartir)).EndInit();
            this.pnlMenuExplorar.ResumeLayout(false);
            this.pnlMenuExplorar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuExplorar)).EndInit();
            this.pnlMenuDescargar.ResumeLayout(false);
            this.pnlMenuDescargar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenuDescargar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.PictureBox pbIcono;
        private System.Windows.Forms.PictureBox pbCerrar;
        private System.Windows.Forms.PictureBox pbMinimizar;
        private System.Windows.Forms.PictureBox pbTitulo;
        private System.Windows.Forms.Timer tmrFader;
        private System.Windows.Forms.Panel pnlBarraGris1Px;
        private System.Windows.Forms.Panel pnlVistaContenedor;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlRojoMenu;
        private System.Windows.Forms.Panel pnlMenuExpandir;
        private System.Windows.Forms.PictureBox pbMenuExpandir;
        private System.Windows.Forms.Panel pnlMenuAbout;
        private System.Windows.Forms.Label lblMenuAbout;
        private System.Windows.Forms.PictureBox pbMenuAbout;
        private System.Windows.Forms.Panel pnlMenuConfiguracion;
        private System.Windows.Forms.Label lblMenuConfiguracion;
        private System.Windows.Forms.PictureBox pbMenuConfiguracion;
        private System.Windows.Forms.Panel pnlMenuSolicitar;
        private System.Windows.Forms.Label lblMenuSolicitar;
        private System.Windows.Forms.PictureBox pbMenuSolicitar;
        private System.Windows.Forms.Panel pnlMenuCompartir;
        private System.Windows.Forms.Label lblMenuCompartir;
        private System.Windows.Forms.PictureBox pbMenuCompartir;
        private System.Windows.Forms.Panel pnlMenuExplorar;
        private System.Windows.Forms.Label lblMenuExplorar;
        private System.Windows.Forms.PictureBox pbMenuExplorar;
        private System.Windows.Forms.Panel pnlMenuDescargar;
        private System.Windows.Forms.Label lblMenuDescargar;
        private System.Windows.Forms.PictureBox pbMenuDescargar;
        private System.Windows.Forms.Panel pnlVistaAbout;
        private System.Windows.Forms.TextBox tbVistaAboutDescripcion;
        private System.Windows.Forms.PictureBox pbVistaAboutBotonJulio;
        private System.Windows.Forms.PictureBox pbVistaBotonLcs;
        private System.Windows.Forms.PictureBox pbVistaAbout;
        private System.Windows.Forms.Panel pnlVistaDescargar;
        private System.Windows.Forms.Panel pnlVistaExplorar;
        private System.Windows.Forms.Panel pnlVistaCompartir;
        private System.Windows.Forms.Panel pnlVistaSolicitar;
        private System.Windows.Forms.Panel pnlVistaConfiguracionGeneral;
        private System.Windows.Forms.Panel pnlMenuRojoDescargar;
        private System.Windows.Forms.Panel pnlMenuRojoAbout;
        private System.Windows.Forms.Panel pnlMenuRojoConfiguracion;
        private System.Windows.Forms.Panel pnlMenuRojoSolicitar;
        private System.Windows.Forms.Panel pnlMenuRojoCompartir;
        private System.Windows.Forms.Panel pnlMenuRojoExplorar;
        private System.Windows.Forms.Label lblVistaConfiguracionTranseferecias;
        private System.Windows.Forms.Label lblVistaConfiguracionInterfaz;
        private System.Windows.Forms.Label lblVistaConfiguracionIniciarConWindows;
        private System.Windows.Forms.Label lblVistaConfiguracionIdioma;
        private System.Windows.Forms.Label lblVistaConfiguracionGeneral;
        private System.Windows.Forms.Label lblVistaConfiguracionTema;
        private System.Windows.Forms.Label lblVistaConfiguracionLimiteDescargas;
        private System.Windows.Forms.Label lblVistaConfiguracionEfectoFade;
        private System.Windows.Forms.Label lblVistaConfiguracionEfectoBotones;
        private System.Windows.Forms.Label lblVistaConfiguracionMovimientoMenu;
        private System.Windows.Forms.Label lblVistaConfiguracionMinimizarBanjeda;
        private System.Windows.Forms.Label lblVistaConfiguracionLimiteBajada;
        private System.Windows.Forms.Label lblVistaConfiguracionRutaDescarga;
        private System.Windows.Forms.Label lblVistaConfiguracionLimiteSubida;
        private Controles.botonSwitch bsVistaConfiguracionIniciarConWindows;
        private Controles.botonSwitch bsVistaConfiguracionLatino;
        private System.Windows.Forms.PictureBox pbVistaConfiguracionCarpetaDescarga;
        private System.Windows.Forms.FolderBrowserDialog fbdNavegador;
        private System.Windows.Forms.ToolTip ttAyuda;
        private System.Windows.Forms.Panel pnlVistaComfiguracionGeneral;
        private System.Windows.Forms.Panel pnlVistaComfiguracionInterfaz;
        private System.Windows.Forms.Panel pnlVistaConfiguracionTransferencias;
        private Controles.botonSwitch bsVistaConfiguracionMinimizarBandeja;
        private System.Windows.Forms.Label lblVistaConfiguracionIngles;
        private System.Windows.Forms.Label lblVistaConfiguracionEspañol;
        private Controles.botonSwitch bsVistaConfiguracionEfectoFade;
        private Controles.botonSwitch bsVistaConfiguracionEfectoMenu;
        private Controles.botonSwitch bsVistaConfiguracionEfectoBotones;
        private Controles.botonSwitch bsVistaConfiguracionTema;
        private System.Windows.Forms.Label lblVistaConfiguracionTemaClaro;
        private System.Windows.Forms.Label lblVistaConfiguracionTemaOscuro;
        private System.Windows.Forms.NotifyIcon niMinimizar;
        private Controles.botonNUD bnudVistaConfiguracionLimiteSubida;
        private Controles.botonNUD bnudVistaConfiguracionDescargasSimultaneas;
        private Controles.botonNUD bnudVistaConfiguracionLimiteBajada;
        private System.Windows.Forms.Label lblVistaConfiguracionKbpsBajada;
        private System.Windows.Forms.Label lblVistaConfiguracionKbpsSubida;
        private System.Windows.Forms.Panel pnlMenuConfiguracionesRapidas;
        private System.Windows.Forms.Label lblMenuCRapidas;
        private System.Windows.Forms.Label lblMenuConfiguracionesR;
        private System.Windows.Forms.PictureBox pbMenuConfiguracionesRapidas;
        private System.Windows.Forms.Label lblVistaConfiguracionNombre;
        private System.Windows.Forms.TextBox tbVistaConfiguracionNombre;
        private System.Windows.Forms.PictureBox pbVistaCompartirSeleccionarArchivo;
        private System.Windows.Forms.Panel pnlVistaCompartirGuardarArchivo;
        private System.Windows.Forms.TextBox tbVistaCompartirDescripcionArchivo;
        private System.Windows.Forms.PictureBox pbVistaCompartirCancelar;
        private System.Windows.Forms.PictureBox pbVistaCompartirArchivo;
        private System.Windows.Forms.Label lblVistaCompartirNombreArchivo;
        private System.Windows.Forms.Panel pnlVistaCompartirSeleccionarArchivo;
        private System.Windows.Forms.Label lblVistaCompartirTamañoArchivo;
        private System.Windows.Forms.OpenFileDialog ofdArchivo;
        private System.Windows.Forms.Label lblVistaCompartirSeleccionar;
        private System.Windows.Forms.Panel pnlVistaCompartirMostarArchivos;
        private System.Windows.Forms.Label lblVistaCompartirVerArchivos;
        private System.Windows.Forms.DataGridView dgvVistaCompartirArchivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamaño;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrar;
        private System.Windows.Forms.Panel pnlVistaSolicitarVerSolicitudes;
        private System.Windows.Forms.Label lblVistaSolicitarNuevasSolicitudes;
        private System.Windows.Forms.DataGridView dgvVistaSolicitar;
        private System.Windows.Forms.Panel pnlVistaSolicitarCompartirSolicitud;
        private System.Windows.Forms.Label lblVistaSolicitarInformacion;
        private System.Windows.Forms.TextBox tbVistaSolicitarDescripcion;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel pnlVistaExplorarDGV;
        private System.Windows.Forms.Label lblVistaExplorarArchivosCompartidosVecinos;
        private System.Windows.Forms.DataGridView dgvVistaExplorarArchivosCompartidosVecinos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label lblVistaConfiguracionIP;
        private System.Windows.Forms.PictureBox pbVistaConfiguracionReconectar;
        private System.Windows.Forms.TextBox tbVistaConfiguracionIP;
        private System.Windows.Forms.Label lblVistaConfiguracionBitNoders;
        private System.Windows.Forms.Label lblVistaConfiguracionMiIP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblVistaDescargarExplorar;
        private System.Windows.Forms.DataGridView dgvVistaDescargas;
        private System.Windows.Forms.Panel pnlVistaExploarBuscar;
        private System.Windows.Forms.PictureBox pbVistaExplorarBuscar;
        private System.Windows.Forms.TextBox tbVistaExplorarBuscar;
        private Controles.botonSwitch bsVistaConfiguracionBuscar;
        private System.Windows.Forms.Label lblVistaConfiguracionSyncAuto;
        private System.Windows.Forms.TextBox tbVistaCompartirTags;
        private System.Windows.Forms.Panel pnlVistaCompartirSeparador;
        private System.Windows.Forms.Panel pnlVistaDescargarContenedor;
        private System.Windows.Forms.PictureBox pbVistaDescargarStop;
        private System.Windows.Forms.PictureBox pbVistaDescargarStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descargado;
        private System.Windows.Forms.DataGridViewTextBoxColumn TamañoArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Progreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn BorraraArchivo;
        private System.Windows.Forms.Timer tmrModificarAN;
    }
}

