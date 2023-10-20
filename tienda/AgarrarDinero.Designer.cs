namespace tienda
{
    partial class AgarrarDinero
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
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.lblNE = new System.Windows.Forms.Label();
            this.lblResultadoDineroAgarrado = new System.Windows.Forms.Label();
            this.txtAgarrarDinero = new System.Windows.Forms.TextBox();
            this.lblSobroOagarrar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Enabled = false;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(30, 305);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(411, 46);
            this.BtnGuardar.TabIndex = 1;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // lblNE
            // 
            this.lblNE.AutoSize = true;
            this.lblNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNE.Location = new System.Drawing.Point(183, 62);
            this.lblNE.Name = "lblNE";
            this.lblNE.Size = new System.Drawing.Size(103, 38);
            this.lblNE.TabIndex = 2;
            this.lblNE.Text = "label1";
            // 
            // lblResultadoDineroAgarrado
            // 
            this.lblResultadoDineroAgarrado.AutoSize = true;
            this.lblResultadoDineroAgarrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultadoDineroAgarrado.Location = new System.Drawing.Point(183, 243);
            this.lblResultadoDineroAgarrado.Name = "lblResultadoDineroAgarrado";
            this.lblResultadoDineroAgarrado.Size = new System.Drawing.Size(103, 38);
            this.lblResultadoDineroAgarrado.TabIndex = 3;
            this.lblResultadoDineroAgarrado.Text = "label2";
            // 
            // txtAgarrarDinero
            // 
            this.txtAgarrarDinero.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgarrarDinero.Location = new System.Drawing.Point(151, 133);
            this.txtAgarrarDinero.Name = "txtAgarrarDinero";
            this.txtAgarrarDinero.Size = new System.Drawing.Size(182, 45);
            this.txtAgarrarDinero.TabIndex = 4;
            this.txtAgarrarDinero.TextChanged += new System.EventHandler(this.txtAgarrarDinero_TextChanged);
            // 
            // lblSobroOagarrar
            // 
            this.lblSobroOagarrar.AutoSize = true;
            this.lblSobroOagarrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSobroOagarrar.Location = new System.Drawing.Point(185, 24);
            this.lblSobroOagarrar.Name = "lblSobroOagarrar";
            this.lblSobroOagarrar.Size = new System.Drawing.Size(79, 29);
            this.lblSobroOagarrar.TabIndex = 5;
            this.lblSobroOagarrar.Text = "label1";
            // 
            // AgarrarDinero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 381);
            this.Controls.Add(this.lblSobroOagarrar);
            this.Controls.Add(this.txtAgarrarDinero);
            this.Controls.Add(this.lblResultadoDineroAgarrado);
            this.Controls.Add(this.lblNE);
            this.Controls.Add(this.BtnGuardar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgarrarDinero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgarrarDinero";
            this.Load += new System.EventHandler(this.AgarrarDinero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label lblNE;
        private System.Windows.Forms.Label lblResultadoDineroAgarrado;
        private System.Windows.Forms.TextBox txtAgarrarDinero;
        private System.Windows.Forms.Label lblSobroOagarrar;
    }
}