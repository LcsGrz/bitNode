namespace Cliente.Controles
{
    partial class botonSwitch
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(botonSwitch));
            this.pbFondoAzul = new System.Windows.Forms.PictureBox();
            this.pbActivado = new System.Windows.Forms.PictureBox();
            this.pbDesactivado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFondoAzul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActivado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesactivado)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFondoAzul
            // 
            this.pbFondoAzul.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFondoAzul.BackColor = System.Drawing.Color.Transparent;
            this.pbFondoAzul.Image = ((System.Drawing.Image)(resources.GetObject("pbFondoAzul.Image")));
            this.pbFondoAzul.Location = new System.Drawing.Point(0, 0);
            this.pbFondoAzul.Name = "pbFondoAzul";
            this.pbFondoAzul.Size = new System.Drawing.Size(50, 25);
            this.pbFondoAzul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFondoAzul.TabIndex = 0;
            this.pbFondoAzul.TabStop = false;
            this.pbFondoAzul.Click += new System.EventHandler(this.CambiarEstado);
            // 
            // pbActivado
            // 
            this.pbActivado.BackColor = System.Drawing.Color.Transparent;
            this.pbActivado.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbActivado.Image = ((System.Drawing.Image)(resources.GetObject("pbActivado.Image")));
            this.pbActivado.Location = new System.Drawing.Point(25, 0);
            this.pbActivado.Name = "pbActivado";
            this.pbActivado.Size = new System.Drawing.Size(25, 25);
            this.pbActivado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbActivado.TabIndex = 1;
            this.pbActivado.TabStop = false;
            this.pbActivado.Click += new System.EventHandler(this.CambiarEstado);
            // 
            // pbDesactivado
            // 
            this.pbDesactivado.BackColor = System.Drawing.Color.Transparent;
            this.pbDesactivado.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbDesactivado.Image = ((System.Drawing.Image)(resources.GetObject("pbDesactivado.Image")));
            this.pbDesactivado.Location = new System.Drawing.Point(0, 0);
            this.pbDesactivado.Name = "pbDesactivado";
            this.pbDesactivado.Size = new System.Drawing.Size(25, 25);
            this.pbDesactivado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDesactivado.TabIndex = 1;
            this.pbDesactivado.TabStop = false;
            this.pbDesactivado.Visible = false;
            this.pbDesactivado.Click += new System.EventHandler(this.CambiarEstado);
            // 
            // botonSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbDesactivado);
            this.Controls.Add(this.pbActivado);
            this.Controls.Add(this.pbFondoAzul);
            this.Name = "botonSwitch";
            this.Size = new System.Drawing.Size(50, 25);
            this.Click += new System.EventHandler(this.CambiarEstado);
            ((System.ComponentModel.ISupportInitialize)(this.pbFondoAzul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbActivado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesactivado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFondoAzul;
        private System.Windows.Forms.PictureBox pbActivado;
        private System.Windows.Forms.PictureBox pbDesactivado;
    }
}
