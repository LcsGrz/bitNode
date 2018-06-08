using System;

namespace Cliente
{
    partial class frmMensaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMensaje));
            this.pnlMensaje = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.pbCheck = new System.Windows.Forms.PictureBox();
            this.pnlMensaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMensaje
            // 
            this.pnlMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(23)))), ((int)(((byte)(33)))));
            this.pnlMensaje.Controls.Add(this.panel3);
            this.pnlMensaje.Controls.Add(this.panel2);
            this.pnlMensaje.Controls.Add(this.panel1);
            this.pnlMensaje.Controls.Add(this.lblMensaje);
            this.pnlMensaje.Controls.Add(this.pnlBarra);
            this.pnlMensaje.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlMensaje.Location = new System.Drawing.Point(0, 0);
            this.pnlMensaje.Name = "pnlMensaje";
            this.pnlMensaje.Size = new System.Drawing.Size(300, 80);
            this.pnlMensaje.TabIndex = 0;
            this.pnlMensaje.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 3);
            this.panel3.TabIndex = 4;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(297, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(3, 79);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 79);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.BackColor = System.Drawing.Color.Transparent;
            this.lblMensaje.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.lblMensaje.Font = new System.Drawing.Font("Roboto Lt", 12F);
            this.lblMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.lblMensaje.Location = new System.Drawing.Point(12, 31);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(69, 19);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Mensaje";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMensaje.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.pnlBarra.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBarra.Location = new System.Drawing.Point(0, 79);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(300, 1);
            this.pnlBarra.TabIndex = 0;
            this.pnlBarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            // 
            // pbCheck
            // 
            this.pbCheck.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCheck.Image = ((System.Drawing.Image)(resources.GetObject("pbCheck.Image")));
            this.pbCheck.Location = new System.Drawing.Point(270, 85);
            this.pbCheck.Name = "pbCheck";
            this.pbCheck.Size = new System.Drawing.Size(30, 17);
            this.pbCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCheck.TabIndex = 1;
            this.pbCheck.TabStop = false;
            // 
            // frmMensaje
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(17)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(300, 105);
            this.Controls.Add(this.pbCheck);
            this.Controls.Add(this.pnlMensaje);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMensaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "bitNode";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TeclaEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoverForm);
            this.pnlMensaje.ResumeLayout(false);
            this.pnlMensaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMensaje;
        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.PictureBox pbCheck;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
    }
}