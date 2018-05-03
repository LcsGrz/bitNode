namespace Cliente.Controles
{
    partial class botonNUD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(botonNUD));
            this.pbFondo = new System.Windows.Forms.PictureBox();
            this.pbUP = new System.Windows.Forms.PictureBox();
            this.pbDOWN = new System.Windows.Forms.PictureBox();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.mtbNumero = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDOWN)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFondo
            // 
            this.pbFondo.BackColor = System.Drawing.Color.Transparent;
            this.pbFondo.Image = ((System.Drawing.Image)(resources.GetObject("pbFondo.Image")));
            this.pbFondo.Location = new System.Drawing.Point(0, 0);
            this.pbFondo.Name = "pbFondo";
            this.pbFondo.Size = new System.Drawing.Size(65, 35);
            this.pbFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFondo.TabIndex = 0;
            this.pbFondo.TabStop = false;
            // 
            // pbUP
            // 
            this.pbUP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUP.Image = ((System.Drawing.Image)(resources.GetObject("pbUP.Image")));
            this.pbUP.Location = new System.Drawing.Point(54, 0);
            this.pbUP.Name = "pbUP";
            this.pbUP.Size = new System.Drawing.Size(11, 18);
            this.pbUP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbUP.TabIndex = 1;
            this.pbUP.TabStop = false;
            this.pbUP.Tag = "1";
            this.pbUP.Click += new System.EventHandler(this.UP_DOWN);
            this.pbUP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmpezarContador);
            this.pbUP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TerminarContador);
            // 
            // pbDOWN
            // 
            this.pbDOWN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDOWN.Image = ((System.Drawing.Image)(resources.GetObject("pbDOWN.Image")));
            this.pbDOWN.Location = new System.Drawing.Point(54, 17);
            this.pbDOWN.Name = "pbDOWN";
            this.pbDOWN.Size = new System.Drawing.Size(11, 18);
            this.pbDOWN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDOWN.TabIndex = 2;
            this.pbDOWN.TabStop = false;
            this.pbDOWN.Tag = "2";
            this.pbDOWN.Click += new System.EventHandler(this.UP_DOWN);
            this.pbDOWN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EmpezarContador);
            this.pbDOWN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TerminarContador);
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 250;
            this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
            // 
            // mtbNumero
            // 
            this.mtbNumero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(11)))), ((int)(((byte)(21)))));
            this.mtbNumero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mtbNumero.Font = new System.Drawing.Font("Roboto Lt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbNumero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.mtbNumero.Location = new System.Drawing.Point(5, 6);
            this.mtbNumero.MaxLength = 4;
            this.mtbNumero.Name = "mtbNumero";
            this.mtbNumero.Size = new System.Drawing.Size(45, 23);
            this.mtbNumero.TabIndex = 3;
            this.mtbNumero.Text = "9999";
            this.mtbNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbNumero.Click += new System.EventHandler(this.BorrarMTB);
            this.mtbNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtbNumero_KeyPress);
            // 
            // botonNUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.mtbNumero);
            this.Controls.Add(this.pbDOWN);
            this.Controls.Add(this.pbUP);
            this.Controls.Add(this.pbFondo);
            this.Name = "botonNUD";
            this.Size = new System.Drawing.Size(65, 35);
            ((System.ComponentModel.ISupportInitialize)(this.pbFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDOWN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbFondo;
        private System.Windows.Forms.PictureBox pbUP;
        private System.Windows.Forms.PictureBox pbDOWN;
        private System.Windows.Forms.Timer tmrTimer;
        private System.Windows.Forms.TextBox mtbNumero;
    }
}
