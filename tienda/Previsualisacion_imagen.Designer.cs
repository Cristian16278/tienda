namespace tienda
{
    partial class Previsualisacion_imagen
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnCambiarImagen = new System.Windows.Forms.Button();
            this.BtnAbriConFotos = new System.Windows.Forms.Button();
            this.Borrarimagen = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(55, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(636, 549);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(92, 641);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(169, 42);
            this.BtnGuardar.TabIndex = 1;
            this.BtnGuardar.Text = "Aceptar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(280, 641);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(169, 42);
            this.BtnCancelar.TabIndex = 2;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnCambiarImagen
            // 
            this.BtnCambiarImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCambiarImagen.Location = new System.Drawing.Point(476, 641);
            this.BtnCambiarImagen.Name = "BtnCambiarImagen";
            this.BtnCambiarImagen.Size = new System.Drawing.Size(185, 42);
            this.BtnCambiarImagen.TabIndex = 3;
            this.BtnCambiarImagen.Text = "Cambiar imagen";
            this.BtnCambiarImagen.UseVisualStyleBackColor = true;
            this.BtnCambiarImagen.Click += new System.EventHandler(this.BtnCambiarImagen_Click);
            // 
            // BtnAbriConFotos
            // 
            this.BtnAbriConFotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAbriConFotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbriConFotos.Location = new System.Drawing.Point(515, 12);
            this.BtnAbriConFotos.Name = "BtnAbriConFotos";
            this.BtnAbriConFotos.Size = new System.Drawing.Size(176, 38);
            this.BtnAbriConFotos.TabIndex = 4;
            this.BtnAbriConFotos.Text = "Abrir con Fotos";
            this.BtnAbriConFotos.UseVisualStyleBackColor = true;
            this.BtnAbriConFotos.Click += new System.EventHandler(this.BtnAbriConFotos_Click);
            // 
            // Borrarimagen
            // 
            this.Borrarimagen.Interval = 2000;
            this.Borrarimagen.Tick += new System.EventHandler(this.Borrarimagen_Tick);
            // 
            // Previsualisacion_imagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 718);
            this.Controls.Add(this.BtnAbriConFotos);
            this.Controls.Add(this.BtnCambiarImagen);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(766, 765);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(766, 765);
            this.Name = "Previsualisacion_imagen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Previsualisacion_imagen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnCambiarImagen;
        private System.Windows.Forms.Button BtnAbriConFotos;
        private System.Windows.Forms.Timer Borrarimagen;
    }
}