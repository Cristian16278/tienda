namespace tienda
{
    partial class CuentasDiarias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuentasDiarias));
            this.txtBilletes = new System.Windows.Forms.TextBox();
            this.txtMonedas = new System.Windows.Forms.TextBox();
            this.txtDelacaja = new System.Windows.Forms.TextBox();
            this.txtConsumoDiario = new System.Windows.Forms.TextBox();
            this.lblBilletes = new System.Windows.Forms.Label();
            this.lblMonedas = new System.Windows.Forms.Label();
            this.lblConDiario = new System.Windows.Forms.Label();
            this.lblDelacaja = new System.Windows.Forms.Label();
            this.listMostrar = new System.Windows.Forms.ListBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.consultarCuentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRegistrohoy = new System.Windows.Forms.Label();
            this.BtnBilletesCalcular = new System.Windows.Forms.Button();
            this.BtnAgarrarDinero = new System.Windows.Forms.Button();
            this.BtnAgregarSumarProveedor = new System.Windows.Forms.Button();
            this.BtnProveedores = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBilletes
            // 
            this.txtBilletes.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBilletes.ForeColor = System.Drawing.Color.Teal;
            this.txtBilletes.Location = new System.Drawing.Point(55, 114);
            this.txtBilletes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBilletes.Name = "txtBilletes";
            this.txtBilletes.Size = new System.Drawing.Size(225, 53);
            this.txtBilletes.TabIndex = 0;
            this.txtBilletes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBilletes_KeyPress);
            // 
            // txtMonedas
            // 
            this.txtMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonedas.ForeColor = System.Drawing.Color.Teal;
            this.txtMonedas.Location = new System.Drawing.Point(55, 238);
            this.txtMonedas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMonedas.Name = "txtMonedas";
            this.txtMonedas.Size = new System.Drawing.Size(225, 53);
            this.txtMonedas.TabIndex = 1;
            this.txtMonedas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonedas_KeyPress);
            // 
            // txtDelacaja
            // 
            this.txtDelacaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelacaja.ForeColor = System.Drawing.Color.Teal;
            this.txtDelacaja.Location = new System.Drawing.Point(55, 370);
            this.txtDelacaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDelacaja.Name = "txtDelacaja";
            this.txtDelacaja.Size = new System.Drawing.Size(225, 53);
            this.txtDelacaja.TabIndex = 2;
            this.txtDelacaja.Text = "0";
            this.txtDelacaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDelacaja_KeyPress);
            // 
            // txtConsumoDiario
            // 
            this.txtConsumoDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsumoDiario.ForeColor = System.Drawing.Color.Teal;
            this.txtConsumoDiario.Location = new System.Drawing.Point(57, 503);
            this.txtConsumoDiario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConsumoDiario.Name = "txtConsumoDiario";
            this.txtConsumoDiario.Size = new System.Drawing.Size(225, 53);
            this.txtConsumoDiario.TabIndex = 3;
            this.txtConsumoDiario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsumoDiario_KeyPress);
            // 
            // lblBilletes
            // 
            this.lblBilletes.AutoSize = true;
            this.lblBilletes.BackColor = System.Drawing.Color.LightGray;
            this.lblBilletes.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBilletes.ForeColor = System.Drawing.Color.Black;
            this.lblBilletes.Location = new System.Drawing.Point(49, 66);
            this.lblBilletes.Name = "lblBilletes";
            this.lblBilletes.Size = new System.Drawing.Size(160, 46);
            this.lblBilletes.TabIndex = 4;
            this.lblBilletes.Text = "Billetes:";
            // 
            // lblMonedas
            // 
            this.lblMonedas.AutoSize = true;
            this.lblMonedas.BackColor = System.Drawing.Color.LightGray;
            this.lblMonedas.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonedas.ForeColor = System.Drawing.Color.Black;
            this.lblMonedas.Location = new System.Drawing.Point(49, 190);
            this.lblMonedas.Name = "lblMonedas";
            this.lblMonedas.Size = new System.Drawing.Size(195, 46);
            this.lblMonedas.TabIndex = 5;
            this.lblMonedas.Text = "Monedas:";
            // 
            // lblConDiario
            // 
            this.lblConDiario.AutoSize = true;
            this.lblConDiario.BackColor = System.Drawing.Color.LightGray;
            this.lblConDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConDiario.ForeColor = System.Drawing.Color.Black;
            this.lblConDiario.Location = new System.Drawing.Point(49, 454);
            this.lblConDiario.Name = "lblConDiario";
            this.lblConDiario.Size = new System.Drawing.Size(243, 46);
            this.lblConDiario.TabIndex = 6;
            this.lblConDiario.Text = "Consumo D:";
            // 
            // lblDelacaja
            // 
            this.lblDelacaja.AutoSize = true;
            this.lblDelacaja.BackColor = System.Drawing.Color.LightGray;
            this.lblDelacaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelacaja.ForeColor = System.Drawing.Color.Black;
            this.lblDelacaja.Location = new System.Drawing.Point(47, 321);
            this.lblDelacaja.Name = "lblDelacaja";
            this.lblDelacaja.Size = new System.Drawing.Size(210, 46);
            this.lblDelacaja.TabIndex = 7;
            this.lblDelacaja.Text = "De la caja:";
            // 
            // listMostrar
            // 
            this.listMostrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.listMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMostrar.FormattingEnabled = true;
            this.listMostrar.ItemHeight = 51;
            this.listMostrar.Location = new System.Drawing.Point(433, 57);
            this.listMostrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listMostrar.Name = "listMostrar";
            this.listMostrar.Size = new System.Drawing.Size(449, 463);
            this.listMostrar.TabIndex = 8;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(671, 571);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(211, 50);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnCalcular_Click);
            this.btnGuardar.MouseEnter += new System.EventHandler(this.btnGuardar_MouseEnter);
            this.btnGuardar.MouseLeave += new System.EventHandler(this.btnGuardar_MouseLeave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarCuentasToolStripMenuItem,
            this.agregarToolStripMenuItem,
            this.actualisarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(913, 40);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // consultarCuentasToolStripMenuItem
            // 
            this.consultarCuentasToolStripMenuItem.Name = "consultarCuentasToolStripMenuItem";
            this.consultarCuentasToolStripMenuItem.Size = new System.Drawing.Size(223, 36);
            this.consultarCuentasToolStripMenuItem.Text = "Consultar cuentas";
            this.consultarCuentasToolStripMenuItem.Click += new System.EventHandler(this.consultarCuentasToolStripMenuItem_Click);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(132, 36);
            this.agregarToolStripMenuItem.Text = "Agregar...";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // actualisarToolStripMenuItem
            // 
            this.actualisarToolStripMenuItem.Name = "actualisarToolStripMenuItem";
            this.actualisarToolStripMenuItem.Size = new System.Drawing.Size(135, 36);
            this.actualisarToolStripMenuItem.Text = "Actualisar";
            this.actualisarToolStripMenuItem.Click += new System.EventHandler(this.actualisarToolStripMenuItem_Click);
            // 
            // lblRegistrohoy
            // 
            this.lblRegistrohoy.AutoSize = true;
            this.lblRegistrohoy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrohoy.Location = new System.Drawing.Point(441, 524);
            this.lblRegistrohoy.Name = "lblRegistrohoy";
            this.lblRegistrohoy.Size = new System.Drawing.Size(0, 22);
            this.lblRegistrohoy.TabIndex = 11;
            // 
            // BtnBilletesCalcular
            // 
            this.BtnBilletesCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBilletesCalcular.Location = new System.Drawing.Point(295, 124);
            this.BtnBilletesCalcular.Name = "BtnBilletesCalcular";
            this.BtnBilletesCalcular.Size = new System.Drawing.Size(67, 33);
            this.BtnBilletesCalcular.TabIndex = 12;
            this.BtnBilletesCalcular.Text = "...";
            this.BtnBilletesCalcular.UseVisualStyleBackColor = true;
            this.BtnBilletesCalcular.Click += new System.EventHandler(this.BtnBilletesCalcular_Click);
            // 
            // BtnAgarrarDinero
            // 
            this.BtnAgarrarDinero.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnAgarrarDinero.Enabled = false;
            this.BtnAgarrarDinero.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgarrarDinero.Location = new System.Drawing.Point(433, 571);
            this.BtnAgarrarDinero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAgarrarDinero.Name = "BtnAgarrarDinero";
            this.BtnAgarrarDinero.Size = new System.Drawing.Size(232, 50);
            this.BtnAgarrarDinero.TabIndex = 13;
            this.BtnAgarrarDinero.Text = "Agarrar dinero";
            this.BtnAgarrarDinero.UseVisualStyleBackColor = true;
            this.BtnAgarrarDinero.Visible = false;
            this.BtnAgarrarDinero.Click += new System.EventHandler(this.BtnAgarrarDinero_Click);
            // 
            // BtnAgregarSumarProveedor
            // 
            this.BtnAgregarSumarProveedor.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnAgregarSumarProveedor.Enabled = false;
            this.BtnAgregarSumarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregarSumarProveedor.Location = new System.Drawing.Point(55, 586);
            this.BtnAgregarSumarProveedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAgregarSumarProveedor.Name = "BtnAgregarSumarProveedor";
            this.BtnAgregarSumarProveedor.Size = new System.Drawing.Size(232, 50);
            this.BtnAgregarSumarProveedor.TabIndex = 14;
            this.BtnAgregarSumarProveedor.Text = "Agregar Suma";
            this.BtnAgregarSumarProveedor.UseVisualStyleBackColor = true;
            this.BtnAgregarSumarProveedor.Visible = false;
            this.BtnAgregarSumarProveedor.Click += new System.EventHandler(this.BtnAgregarSumarProveedor_Click);
            // 
            // BtnProveedores
            // 
            this.BtnProveedores.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProveedores.Location = new System.Drawing.Point(746, 11);
            this.BtnProveedores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnProveedores.Name = "BtnProveedores";
            this.BtnProveedores.Size = new System.Drawing.Size(136, 42);
            this.BtnProveedores.TabIndex = 15;
            this.BtnProveedores.Text = "Proveedores";
            this.BtnProveedores.UseVisualStyleBackColor = true;
            this.BtnProveedores.Click += new System.EventHandler(this.BtnProveedores_Click);
            // 
            // CuentasDiarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(913, 647);
            this.Controls.Add(this.BtnProveedores);
            this.Controls.Add(this.BtnAgregarSumarProveedor);
            this.Controls.Add(this.BtnAgarrarDinero);
            this.Controls.Add(this.BtnBilletesCalcular);
            this.Controls.Add(this.lblRegistrohoy);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.listMostrar);
            this.Controls.Add(this.lblDelacaja);
            this.Controls.Add(this.lblConDiario);
            this.Controls.Add(this.lblMonedas);
            this.Controls.Add(this.lblBilletes);
            this.Controls.Add(this.txtConsumoDiario);
            this.Controls.Add(this.txtDelacaja);
            this.Controls.Add(this.txtMonedas);
            this.Controls.Add(this.txtBilletes);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(931, 694);
            this.MinimumSize = new System.Drawing.Size(931, 694);
            this.Name = "CuentasDiarias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas diarias";
            this.Load += new System.EventHandler(this.CuentasDiarias_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBilletes;
        private System.Windows.Forms.TextBox txtMonedas;
        private System.Windows.Forms.TextBox txtDelacaja;
        private System.Windows.Forms.TextBox txtConsumoDiario;
        private System.Windows.Forms.Label lblBilletes;
        private System.Windows.Forms.Label lblMonedas;
        private System.Windows.Forms.Label lblConDiario;
        private System.Windows.Forms.Label lblDelacaja;
        private System.Windows.Forms.ListBox listMostrar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem consultarCuentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.Label lblRegistrohoy;
        private System.Windows.Forms.ToolStripMenuItem actualisarToolStripMenuItem;
        private System.Windows.Forms.Button BtnBilletesCalcular;
        private System.Windows.Forms.Button BtnAgarrarDinero;
        private System.Windows.Forms.Button BtnAgregarSumarProveedor;
        private System.Windows.Forms.Button BtnProveedores;
    }
}