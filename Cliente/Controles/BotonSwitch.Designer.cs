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
            this.pbOFF = new System.Windows.Forms.PictureBox();
            this.pbON = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbON)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOFF
            // 
            this.pbOFF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOFF.BackColor = System.Drawing.Color.Transparent;
            this.pbOFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOFF.Image = ((System.Drawing.Image)(resources.GetObject("pbOFF.Image")));
            this.pbOFF.Location = new System.Drawing.Point(0, 0);
            this.pbOFF.Name = "pbOFF";
            this.pbOFF.Size = new System.Drawing.Size(36, 18);
            this.pbOFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbOFF.TabIndex = 0;
            this.pbOFF.TabStop = false;
            this.pbOFF.Visible = false;
            this.pbOFF.Click += new System.EventHandler(this.CambiarEstado);
            // 
            // pbON
            // 
            this.pbON.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbON.BackColor = System.Drawing.Color.Transparent;
            this.pbON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbON.Image = ((System.Drawing.Image)(resources.GetObject("pbON.Image")));
            this.pbON.Location = new System.Drawing.Point(0, 0);
            this.pbON.Name = "pbON";
            this.pbON.Size = new System.Drawing.Size(36, 18);
            this.pbON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbON.TabIndex = 0;
            this.pbON.TabStop = false;
            this.pbON.Click += new System.EventHandler(this.CambiarEstado);
            // 
            // botonSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pbON);
            this.Controls.Add(this.pbOFF);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "botonSwitch";
            this.Size = new System.Drawing.Size(36, 18);
            this.Click += new System.EventHandler(this.CambiarEstado);
            ((System.ComponentModel.ISupportInitialize)(this.pbOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbON)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOFF;
        private System.Windows.Forms.PictureBox pbON;
    }
}
