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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHibernar = new System.Windows.Forms.Label();
            this.lblApagar = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblSuspender = new System.Windows.Forms.Label();
            this.lblCerrarApp = new System.Windows.Forms.Label();
            this.lblDeseo = new System.Windows.Forms.Label();
            this.lblNoHacerNada = new System.Windows.Forms.Label();
            this.botonSwitch5 = new Cliente.Controles.botonSwitch();
            this.bsNoHacerNada = new Cliente.Controles.botonSwitch();
            this.botonSwitch1 = new Cliente.Controles.botonSwitch();
            this.botonSwitch4 = new Cliente.Controles.botonSwitch();
            this.botonSwitch2 = new Cliente.Controles.botonSwitch();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbOk = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblTitulo.Font = new System.Drawing.Font("Roboto Lt", 16F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.lblTitulo.Location = new System.Drawing.Point(77, 5);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(245, 27);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configuraciones rapidas";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.lblHibernar);
            this.panel1.Controls.Add(this.lblApagar);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.lblSuspender);
            this.panel1.Controls.Add(this.lblCerrarApp);
            this.panel1.Controls.Add(this.lblDeseo);
            this.panel1.Controls.Add(this.lblNoHacerNada);
            this.panel1.Controls.Add(this.botonSwitch5);
            this.panel1.Controls.Add(this.bsNoHacerNada);
            this.panel1.Controls.Add(this.botonSwitch1);
            this.panel1.Controls.Add(this.botonSwitch4);
            this.panel1.Controls.Add(this.botonSwitch2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Location = new System.Drawing.Point(10, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 209);
            this.panel1.TabIndex = 1;
            // 
            // lblHibernar
            // 
            this.lblHibernar.AutoSize = true;
            this.lblHibernar.BackColor = System.Drawing.Color.Transparent;
            this.lblHibernar.Font = new System.Drawing.Font("Roboto Lt", 12F);
            this.lblHibernar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblHibernar.Location = new System.Drawing.Point(142, 156);
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
            this.lblApagar.Location = new System.Drawing.Point(142, 128);
            this.lblApagar.Name = "lblApagar";
            this.lblApagar.Size = new System.Drawing.Size(112, 19);
            this.lblApagar.TabIndex = 2;
            this.lblApagar.Text = "Apagar equipo";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblDescripcion.Font = new System.Drawing.Font("Roboto Lt", 9F);
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblDescripcion.Location = new System.Drawing.Point(16, 193);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(346, 14);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Recuerda que deberás configurarlas cada vez que estés BitNode";
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
            this.lblCerrarApp.Location = new System.Drawing.Point(142, 72);
            this.lblCerrarApp.Name = "lblCerrarApp";
            this.lblCerrarApp.Size = new System.Drawing.Size(128, 19);
            this.lblCerrarApp.TabIndex = 2;
            this.lblCerrarApp.Text = "Cerrar aplicacion";
            // 
            // lblDeseo
            // 
            this.lblDeseo.AutoSize = true;
            this.lblDeseo.BackColor = System.Drawing.Color.Transparent;
            this.lblDeseo.Font = new System.Drawing.Font("Roboto Lt", 14F);
            this.lblDeseo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblDeseo.Location = new System.Drawing.Point(63, 4);
            this.lblDeseo.Name = "lblDeseo";
            this.lblDeseo.Size = new System.Drawing.Size(252, 23);
            this.lblDeseo.TabIndex = 2;
            this.lblDeseo.Text = "Al finalizar descargas, desea:";
            // 
            // lblNoHacerNada
            // 
            this.lblNoHacerNada.AutoSize = true;
            this.lblNoHacerNada.BackColor = System.Drawing.Color.Transparent;
            this.lblNoHacerNada.Font = new System.Drawing.Font("Roboto Lt", 12F);
            this.lblNoHacerNada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblNoHacerNada.Location = new System.Drawing.Point(142, 44);
            this.lblNoHacerNada.Name = "lblNoHacerNada";
            this.lblNoHacerNada.Size = new System.Drawing.Size(112, 19);
            this.lblNoHacerNada.TabIndex = 2;
            this.lblNoHacerNada.Text = "No hacer nada";
            // 
            // botonSwitch5
            // 
            this.botonSwitch5.Activo = false;
            this.botonSwitch5.BackColor = System.Drawing.Color.Transparent;
            this.botonSwitch5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonSwitch5.Location = new System.Drawing.Point(100, 72);
            this.botonSwitch5.Name = "botonSwitch5";
            this.botonSwitch5.Size = new System.Drawing.Size(36, 18);
            this.botonSwitch5.TabIndex = 3;
            this.botonSwitch5.Tag = "1";
            this.botonSwitch5.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // bsNoHacerNada
            // 
            this.bsNoHacerNada.Activo = true;
            this.bsNoHacerNada.BackColor = System.Drawing.Color.Transparent;
            this.bsNoHacerNada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bsNoHacerNada.Location = new System.Drawing.Point(100, 44);
            this.bsNoHacerNada.Name = "bsNoHacerNada";
            this.bsNoHacerNada.Size = new System.Drawing.Size(36, 18);
            this.bsNoHacerNada.TabIndex = 3;
            this.bsNoHacerNada.Tag = "0";
            this.bsNoHacerNada.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // botonSwitch1
            // 
            this.botonSwitch1.Activo = false;
            this.botonSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.botonSwitch1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonSwitch1.Location = new System.Drawing.Point(100, 156);
            this.botonSwitch1.Name = "botonSwitch1";
            this.botonSwitch1.Size = new System.Drawing.Size(36, 18);
            this.botonSwitch1.TabIndex = 3;
            this.botonSwitch1.Tag = "4";
            this.botonSwitch1.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // botonSwitch4
            // 
            this.botonSwitch4.Activo = false;
            this.botonSwitch4.BackColor = System.Drawing.Color.Transparent;
            this.botonSwitch4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonSwitch4.Location = new System.Drawing.Point(100, 100);
            this.botonSwitch4.Name = "botonSwitch4";
            this.botonSwitch4.Size = new System.Drawing.Size(36, 18);
            this.botonSwitch4.TabIndex = 3;
            this.botonSwitch4.Tag = "2";
            this.botonSwitch4.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
            // 
            // botonSwitch2
            // 
            this.botonSwitch2.Activo = false;
            this.botonSwitch2.BackColor = System.Drawing.Color.Transparent;
            this.botonSwitch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botonSwitch2.Location = new System.Drawing.Point(100, 128);
            this.botonSwitch2.Name = "botonSwitch2";
            this.botonSwitch2.Size = new System.Drawing.Size(36, 18);
            this.botonSwitch2.TabIndex = 3;
            this.botonSwitch2.Tag = "3";
            this.botonSwitch2.Clickaso += new System.EventHandler(this.botonSwitch3_Clickaso);
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
            // frmConfigRapidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(398, 270);
            this.Controls.Add(this.pbOk);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitulo);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfigRapidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigRapidas";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.PictureBox pbOk;
        private Controles.botonSwitch botonSwitch5;
        private Controles.botonSwitch bsNoHacerNada;
        private Controles.botonSwitch botonSwitch4;
        private Controles.botonSwitch botonSwitch2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHibernar;
        private System.Windows.Forms.Label lblApagar;
        private System.Windows.Forms.Label lblSuspender;
        private System.Windows.Forms.Label lblCerrarApp;
        private System.Windows.Forms.Label lblNoHacerNada;
        private Controles.botonSwitch botonSwitch1;
        private System.Windows.Forms.Label lblDeseo;
    }
}