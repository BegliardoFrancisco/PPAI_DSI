namespace PPAI2023.Pantalla
{
    partial class frmSituacionAccion
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
            this.imagenIncorrecta = new Guna.UI2.WinForms.Guna2PictureBox();
            this.imagenExito = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblSituacion = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagenIncorrecta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenExito)).BeginInit();
            this.SuspendLayout();
            // 
            // imagenIncorrecta
            // 
            this.imagenIncorrecta.Image = global::PPAI2023.Properties.Resources.incorrect;
            this.imagenIncorrecta.ImageRotate = 0F;
            this.imagenIncorrecta.Location = new System.Drawing.Point(177, 45);
            this.imagenIncorrecta.Name = "imagenIncorrecta";
            this.imagenIncorrecta.Size = new System.Drawing.Size(101, 67);
            this.imagenIncorrecta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagenIncorrecta.TabIndex = 1;
            this.imagenIncorrecta.TabStop = false;
            // 
            // imagenExito
            // 
            this.imagenExito.Image = global::PPAI2023.Properties.Resources.correct;
            this.imagenExito.ImageRotate = 0F;
            this.imagenExito.Location = new System.Drawing.Point(189, 56);
            this.imagenExito.Name = "imagenExito";
            this.imagenExito.Size = new System.Drawing.Size(93, 56);
            this.imagenExito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imagenExito.TabIndex = 0;
            this.imagenExito.TabStop = false;
            // 
            // lblSituacion
            // 
            this.lblSituacion.BackColor = System.Drawing.Color.Transparent;
            this.lblSituacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacion.Location = new System.Drawing.Point(138, 141);
            this.lblSituacion.Name = "lblSituacion";
            this.lblSituacion.Size = new System.Drawing.Size(144, 22);
            this.lblSituacion.TabIndex = 2;
            this.lblSituacion.Text = "guna2HtmlLabel1";
            this.lblSituacion.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.DefaultAutoSize = true;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.IndicateFocus = true;
            this.guna2Button1.Location = new System.Drawing.Point(177, 184);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(89, 33);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Aceptar";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // frmSituacionAccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(469, 263);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.lblSituacion);
            this.Controls.Add(this.imagenIncorrecta);
            this.Controls.Add(this.imagenExito);
            this.Name = "frmSituacionAccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Situación de la acción";
            this.Load += new System.EventHandler(this.frmSituacionAccion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagenIncorrecta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imagenExito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox imagenExito;
        private Guna.UI2.WinForms.Guna2PictureBox imagenIncorrecta;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSituacion;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}