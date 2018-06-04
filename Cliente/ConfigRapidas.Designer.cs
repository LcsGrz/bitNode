namespace Cliente
{
    partial class frmConfigRapidas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigRapidas));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.lblHibernar = new System.Windows.Forms.Label();
            this.lblApagar = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblSuspender = new System.Windows.Forms.Label();
            this.lblCerrarApp = new System.Windows.Forms.Label();
            this.lblDeseo = new System.Windows.Forms.Label();
            this.lblNoHacerNada = new System.Windows.Forms.Label();
            this.bsCerrarApp = new Cliente.Controles.botonSwitch();
            this.bsNoHacerNada = new Cliente.Controles.botonSwitch();
            this.bsApagar = new Cliente.Controles.botonSwitch();
            this.bsSuspender = new Cliente.Controles.botonSwitch();
            this.bsHibernar = new Cliente.Controles.botonSwitch();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbOk = new System.Windows.Forms.PictureBox();
            this.pnlNada = new System.Windows.Forms.Panel();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto Lt", 16F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(398, 27);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configuraciones rapidas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlContenedor.Controls.Add(this.lblHibernar);
            this.pnlContenedor.Controls.Add(this.lblApagar);
            this.pnlContenedor.Controls.Add(this.lblDescripcion);
            this.pnlContenedor.Controls.Add(this.lblSuspender);
            this.pnlContenedor.Controls.Add(this.lblCerrarApp);
            this.pnlContenedor.Controls.Add(this.lblDeseo);
            this.pnlContenedor.Controls.Add(this.lblNoHacerNada);
            this.pnlContenedor.Controls.Add(this.bsCerrarApp);
            this.pnlContenedor.Controls.Add(this.bsNoHacerNada);
            this.pnlContenedor.Controls.Add(this.bsApagar);
            this.pnlContenedor.Controls.Add(this.bsSuspender);
            this.pnlContenedor.Controls.Add(this.bsHibernar);
            this.pnlContenedor.Controls.Add(this.panel2);
            this.pnlContenedor.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pnlContenedor.Location = new System.Drawing.Point(10, 37);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(379, 209);
            this.pnlContenedor.TabIndex = 1;
            // 
            // lblHibernar
            // 
            this.lblHibernar.AutoSize = true;
            this.lblHibernar.BackColor = System.Drawing.Color.Transparent;
            this.lblHibernar.Font = new System.Drawing.Font("Roboto Lt", 12F);
            this.lblHibernar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblHibernar.Location = new System.Drawing.Point(142, 131);
            this.lblHibernar.Name = "lblHibernar";
            this.lblHibernar.Size = new System.Drawing.Size(121, 19);
            this.lblHibernar.TabIndex = 4;
            this.lblHibernar.Text = "Hibernar equipo";
            // 
            // lblApagar
            // 
            this.lblApagar.AutoSize = true;
            this.lblApagar.BackColor = System.Drawing.Color.Transparent;
            this.lblApagar.Font = new System.Drawing.Font("Roboto Lt", 12F);
            this.lblApagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblApagar.Location = new System.Drawing.Point(142, 162);
            this.lblApagar.Name = "lblApagar";
            this.lblApagar.Size = new System.Drawing.Size(112, 19);
            this.lblApagar.TabIndex = 2;
            this.lblApagar.Text = "Apagar equipo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDescripcion.Font = new System.Drawing.Font("Roboto Lt", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblDescripcion.Location = new System.Drawing.Point(0, 195);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(379, 14);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Recuerda que deberás configurarlas cada vez que estés BitNode";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDescripcion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // lblSuspender
            // 
            this.lblSuspender.AutoSize = true;
            this.lblSuspender.BackColor = System.Drawing.Color.Transparent;
            this.lblSuspender.Font = new System.Drawing.Font("Roboto Lt", 12F);
            this.lblSuspender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblSuspender.Location = new System.Drawing.Point(142, 100);
            this.lblSuspender.Name = "lblSuspender";
            this.lblSuspender.Size = new System.Drawing.Size(136, 19);
            this.lblSuspender.TabIndex = 2;
            this.lblSuspender.Text = "Suspender equipo";
            // 
            // lblCerrarApp
            // 
            this.lblCerrarApp.AutoSize = true;
            this.lblCerrarApp.BackColor = System.Drawing.Color.Transparent;
            this.lblCerrarApp.Font = new System.Drawing.Font("Roboto Lt", 12F);
            this.lblCerrarApp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblCerrarApp.Location = new System.Drawing.Point(142, 69);
            this.lblCerrarApp.Name = "lblCerrarApp";
            this.lblCerrarApp.Size = new System.Drawing.Size(128, 19);
            this.lblCerrarApp.TabIndex = 2;
            this.lblCerrarApp.Text = "Cerrar aplicacion";
            // 
            // lblDeseo
            // 
            this.lblDeseo.BackColor = System.Drawing.Color.Transparent;
            this.lblDeseo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDeseo.Font = new System.Drawing.Font("Roboto Lt", 14F);
            this.lblDeseo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblDeseo.Location = new System.Drawing.Point(0, 0);
            this.lblDeseo.Name = "lblDeseo";
            this.lblDeseo.Size = new System.Drawing.Size(379, 23);
            this.lblDeseo.TabIndex = 2;
            this.lblDeseo.Text = "Al finalizar descargas, desea:";
            this.lblDeseo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoHacerNada
            // 
            this.lblNoHacerNada.AutoSize = true;
            this.lblNoHacerNada.BackColor = System.Drawing.Color.Transparent;
            this.lblNoHacerNada.Font = new System.Drawing.Font("Roboto Lt", 12F);
            this.lblNoHacerNada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblNoHacerNada.Location = new System.Drawing.Point(142, 38);
            this.lblNoHacerNada.Name = "lblNoHacerNada";
            this.lblNoHacerNada.Size = new System.Drawing.Size(112, 19);
            this.lblNoHacerNada.TabIndex = 2;
            this.lblNoHacerNada.Text = "No hacer nada";
            // 
            // bsCerrarApp
            // 
            this.bsCerrarApp.Activo = false;
            this.bsCerrarApp.BackColor = System.Drawing.Color.Transparent;
            this.bsCerrarApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsCerrarApp.Location = new System.Drawing.Point(100, 69);
            this.bsCerrarApp.Name = "bsCerrarApp";
            this.bsCerrarApp.Size = new System.Drawing.Size(36, 18);
            this.bsCerrarApp.TabIndex = 3;
            this.bsCerrarApp.Tag = "1";
            this.bsCerrarApp.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // bsNoHacerNada
            // 
            this.bsNoHacerNada.Activo = true;
            this.bsNoHacerNada.BackColor = System.Drawing.Color.Transparent;
            this.bsNoHacerNada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsNoHacerNada.Location = new System.Drawing.Point(100, 38);
            this.bsNoHacerNada.Name = "bsNoHacerNada";
            this.bsNoHacerNada.Size = new System.Drawing.Size(36, 18);
            this.bsNoHacerNada.TabIndex = 3;
            this.bsNoHacerNada.Tag = "0";
            this.bsNoHacerNada.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // bsApagar
            // 
            this.bsApagar.Activo = false;
            this.bsApagar.BackColor = System.Drawing.Color.Transparent;
            this.bsApagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsApagar.Location = new System.Drawing.Point(100, 162);
            this.bsApagar.Name = "bsApagar";
            this.bsApagar.Size = new System.Drawing.Size(36, 18);
            this.bsApagar.TabIndex = 3;
            this.bsApagar.Tag = "4";
            this.bsApagar.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // bsSuspender
            // 
            this.bsSuspender.Activo = false;
            this.bsSuspender.BackColor = System.Drawing.Color.Transparent;
            this.bsSuspender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsSuspender.Location = new System.Drawing.Point(100, 100);
            this.bsSuspender.Name = "bsSuspender";
            this.bsSuspender.Size = new System.Drawing.Size(36, 18);
            this.bsSuspender.TabIndex = 3;
            this.bsSuspender.Tag = "2";
            this.bsSuspender.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // bsHibernar
            // 
            this.bsHibernar.Activo = false;
            this.bsHibernar.BackColor = System.Drawing.Color.Transparent;
            this.bsHibernar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsHibernar.Location = new System.Drawing.Point(100, 131);
            this.bsHibernar.Name = "bsHibernar";
            this.bsHibernar.Size = new System.Drawing.Size(36, 18);
            this.bsHibernar.TabIndex = 3;
            this.bsHibernar.Tag = "3";
            this.bsHibernar.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.panel2.Location = new System.Drawing.Point(92, 214);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 10);
            this.panel2.TabIndex = 2;
            // 
            // pbOk
            // 
            this.pbOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOk.Image = ((System.Drawing.Image)(resources.GetObject("pbOk.Image")));
            this.pbOk.Location = new System.Drawing.Point(360, 249);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(29, 18);
            this.pbOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOk.TabIndex = 1;
            this.pbOk.TabStop = false;
            // 
            // pnlNada
            // 
            this.pnlNada.BackColor = System.Drawing.Color.Transparent;
            this.pnlNada.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNada.Location = new System.Drawing.Point(0, 0);
            this.pnlNada.Name = "pnlNada";
            this.pnlNada.Size = new System.Drawing.Size(398, 5);
            this.pnlNada.TabIndex = 2;
            this.pnlNada.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // frmConfigRapidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(398, 270);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlNada);
            this.Controls.Add(this.pbOk);
            this.Controls.Add(this.pnlContenedor);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfigRapidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bitNode";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.PictureBox pbOk;
        private Controles.botonSwitch bsCerrarApp;
        private Controles.botonSwitch bsNoHacerNada;
        private Controles.botonSwitch bsSuspender;
        private Controles.botonSwitch bsHibernar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHibernar;
        private System.Windows.Forms.Label lblApagar;
        private System.Windows.Forms.Label lblSuspender;
        private System.Windows.Forms.Label lblCerrarApp;
        private System.Windows.Forms.Label lblNoHacerNada;
        private Controles.botonSwitch bsApagar;
        private System.Windows.Forms.Label lblDeseo;
        private System.Windows.Forms.Panel pnlNada;
    }
}