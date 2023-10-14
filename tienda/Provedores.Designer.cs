namespace tienda
{
    partial class Provedores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgDiasCompra = new System.Windows.Forms.DataGridView();
            this.OfdElegirImagen = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agregarProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarDiasAtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCompra = new System.Windows.Forms.TextBox();
            this.lblCompra = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnRefrescarTabla = new System.Windows.Forms.Button();
            this.CboxProveedoresSinFechaFijo = new System.Windows.Forms.ComboBox();
            this.CboxAccionRealizar = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMensage = new System.Windows.Forms.Label();
            this.CboxProveedorAdelantado = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RdbProveedorSFechaFijo = new System.Windows.Forms.RadioButton();
            this.RdbProveedorAdelanto = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CboxElegirAhorroOcomplemento = new System.Windows.Forms.ComboBox();
            this.txtAhorroCasaOcomplemento = new System.Windows.Forms.TextBox();
            this.lblAhoroCasaOcomplemento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDiasCompra)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgDiasCompra
            // 
            this.dtgDiasCompra.AllowUserToAddRows = false;
            this.dtgDiasCompra.AllowUserToDeleteRows = false;
            this.dtgDiasCompra.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            this.dtgDiasCompra.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgDiasCompra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgDiasCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgDiasCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgDiasCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtgDiasCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgDiasCompra.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtgDiasCompra.Location = new System.Drawing.Point(27, 110);
            this.dtgDiasCompra.MultiSelect = false;
            this.dtgDiasCompra.Name = "dtgDiasCompra";
            this.dtgDiasCompra.ReadOnly = true;
            this.dtgDiasCompra.RowHeadersVisible = false;
            this.dtgDiasCompra.RowHeadersWidth = 51;
            this.dtgDiasCompra.RowTemplate.Height = 24;
            this.dtgDiasCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgDiasCompra.Size = new System.Drawing.Size(1080, 400);
            this.dtgDiasCompra.TabIndex = 2;
            this.dtgDiasCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDiasCompra_CellClick);
            this.dtgDiasCompra.SelectionChanged += new System.EventHandler(this.dtgDiasCompra_SelectionChanged);
            // 
            // OfdElegirImagen
            // 
            this.OfdElegirImagen.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProveedorToolStripMenuItem,
            this.consultarDiasAtrasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1119, 39);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // agregarProveedorToolStripMenuItem
            // 
            this.agregarProveedorToolStripMenuItem.Name = "agregarProveedorToolStripMenuItem";
            this.agregarProveedorToolStripMenuItem.Size = new System.Drawing.Size(221, 35);
            this.agregarProveedorToolStripMenuItem.Text = "Agregar Proveedor";
            this.agregarProveedorToolStripMenuItem.Click += new System.EventHandler(this.agregarProveedorToolStripMenuItem_Click_1);
            // 
            // consultarDiasAtrasToolStripMenuItem
            // 
            this.consultarDiasAtrasToolStripMenuItem.Name = "consultarDiasAtrasToolStripMenuItem";
            this.consultarDiasAtrasToolStripMenuItem.Size = new System.Drawing.Size(173, 35);
            this.consultarDiasAtrasToolStripMenuItem.Text = "Consultar dias";
            this.consultarDiasAtrasToolStripMenuItem.Click += new System.EventHandler(this.consultarDiasAtrasToolStripMenuItem_Click_1);
            // 
            // txtCompra
            // 
            this.txtCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompra.Location = new System.Drawing.Point(421, 109);
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Size = new System.Drawing.Size(236, 38);
            this.txtCompra.TabIndex = 4;
            this.txtCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompra_KeyPress);
            // 
            // lblCompra
            // 
            this.lblCompra.AutoSize = true;
            this.lblCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompra.Location = new System.Drawing.Point(415, 69);
            this.lblCompra.Name = "lblCompra";
            this.lblCompra.Size = new System.Drawing.Size(122, 32);
            this.lblCompra.TabIndex = 5;
            this.lblCompra.Text = "Compra:";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(19, 69);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(153, 32);
            this.lblProveedor.TabIndex = 6;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.Location = new System.Drawing.Point(25, 109);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(285, 38);
            this.txtProveedor.TabIndex = 7;
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaActual.Location = new System.Drawing.Point(21, 52);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(0, 32);
            this.lblFechaActual.TabIndex = 8;
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.Enabled = false;
            this.txtPresupuesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresupuesto.Location = new System.Drawing.Point(602, 57);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Size = new System.Drawing.Size(102, 38);
            this.txtPresupuesto.TabIndex = 9;
            this.txtPresupuesto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPresupuesto_KeyDown);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.White;
            this.BtnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.Location = new System.Drawing.Point(6, 152);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(313, 44);
            this.BtnGuardar.TabIndex = 10;
            this.BtnGuardar.Text = "Guardar cambios";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnRefrescarTabla
            // 
            this.BtnRefrescarTabla.Location = new System.Drawing.Point(1008, 46);
            this.BtnRefrescarTabla.Name = "BtnRefrescarTabla";
            this.BtnRefrescarTabla.Size = new System.Drawing.Size(99, 55);
            this.BtnRefrescarTabla.TabIndex = 11;
            this.BtnRefrescarTabla.Text = "Refrescar tabla";
            this.BtnRefrescarTabla.UseVisualStyleBackColor = true;
            this.BtnRefrescarTabla.Click += new System.EventHandler(this.BtnRefrescarTabla_Click);
            // 
            // CboxProveedoresSinFechaFijo
            // 
            this.CboxProveedoresSinFechaFijo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxProveedoresSinFechaFijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxProveedoresSinFechaFijo.FormattingEnabled = true;
            this.CboxProveedoresSinFechaFijo.Location = new System.Drawing.Point(25, 109);
            this.CboxProveedoresSinFechaFijo.Name = "CboxProveedoresSinFechaFijo";
            this.CboxProveedoresSinFechaFijo.Size = new System.Drawing.Size(285, 39);
            this.CboxProveedoresSinFechaFijo.TabIndex = 12;
            // 
            // CboxAccionRealizar
            // 
            this.CboxAccionRealizar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxAccionRealizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxAccionRealizar.FormattingEnabled = true;
            this.CboxAccionRealizar.Items.AddRange(new object[] {
            "Modificar",
            "Agregar proveedor",
            "Borrar",
            "Sumar todo"});
            this.CboxAccionRealizar.Location = new System.Drawing.Point(6, 47);
            this.CboxAccionRealizar.Name = "CboxAccionRealizar";
            this.CboxAccionRealizar.Size = new System.Drawing.Size(313, 44);
            this.CboxAccionRealizar.TabIndex = 13;
            this.CboxAccionRealizar.SelectedIndexChanged += new System.EventHandler(this.CboxAccionRealizar_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.lblMensage);
            this.groupBox1.Controls.Add(this.CboxProveedorAdelantado);
            this.groupBox1.Controls.Add(this.lblCompra);
            this.groupBox1.Controls.Add(this.txtCompra);
            this.groupBox1.Controls.Add(this.CboxProveedoresSinFechaFijo);
            this.groupBox1.Controls.Add(this.lblProveedor);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 221);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingresar valores";
            // 
            // lblMensage
            // 
            this.lblMensage.AutoSize = true;
            this.lblMensage.Location = new System.Drawing.Point(29, 167);
            this.lblMensage.Name = "lblMensage";
            this.lblMensage.Size = new System.Drawing.Size(0, 29);
            this.lblMensage.TabIndex = 14;
            // 
            // CboxProveedorAdelantado
            // 
            this.CboxProveedorAdelantado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxProveedorAdelantado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxProveedorAdelantado.FormattingEnabled = true;
            this.CboxProveedorAdelantado.Location = new System.Drawing.Point(25, 109);
            this.CboxProveedorAdelantado.Name = "CboxProveedorAdelantado";
            this.CboxProveedorAdelantado.Size = new System.Drawing.Size(285, 39);
            this.CboxProveedorAdelantado.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.RdbProveedorSFechaFijo);
            this.groupBox2.Controls.Add(this.RdbProveedorAdelanto);
            this.groupBox2.Controls.Add(this.BtnGuardar);
            this.groupBox2.Controls.Add(this.CboxAccionRealizar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(782, 516);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 221);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // RdbProveedorSFechaFijo
            // 
            this.RdbProveedorSFechaFijo.AutoSize = true;
            this.RdbProveedorSFechaFijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbProveedorSFechaFijo.Location = new System.Drawing.Point(162, 109);
            this.RdbProveedorSFechaFijo.Name = "RdbProveedorSFechaFijo";
            this.RdbProveedorSFechaFijo.Size = new System.Drawing.Size(122, 29);
            this.RdbProveedorSFechaFijo.TabIndex = 15;
            this.RdbProveedorSFechaFijo.TabStop = true;
            this.RdbProveedorSFechaFijo.Text = "Sin dia fijo";
            this.RdbProveedorSFechaFijo.UseVisualStyleBackColor = true;
            this.RdbProveedorSFechaFijo.CheckedChanged += new System.EventHandler(this.RdbProveedorSFechaFijo_CheckedChanged);
            // 
            // RdbProveedorAdelanto
            // 
            this.RdbProveedorAdelanto.AutoSize = true;
            this.RdbProveedorAdelanto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbProveedorAdelanto.Location = new System.Drawing.Point(22, 109);
            this.RdbProveedorAdelanto.Name = "RdbProveedorAdelanto";
            this.RdbProveedorAdelanto.Size = new System.Drawing.Size(111, 29);
            this.RdbProveedorAdelanto.TabIndex = 14;
            this.RdbProveedorAdelanto.TabStop = true;
            this.RdbProveedorAdelanto.Text = "Adelanto";
            this.RdbProveedorAdelanto.UseVisualStyleBackColor = true;
            this.RdbProveedorAdelanto.CheckedChanged += new System.EventHandler(this.RdbProveedorAdelanto_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(530, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 32);
            this.label1.TabIndex = 16;
            this.label1.Text = "T.E:";
            // 
            // CboxElegirAhorroOcomplemento
            // 
            this.CboxElegirAhorroOcomplemento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxElegirAhorroOcomplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxElegirAhorroOcomplemento.FormattingEnabled = true;
            this.CboxElegirAhorroOcomplemento.Items.AddRange(new object[] {
            "Sel..",
            "A.C",
            "D.L"});
            this.CboxElegirAhorroOcomplemento.Location = new System.Drawing.Point(710, 55);
            this.CboxElegirAhorroOcomplemento.Name = "CboxElegirAhorroOcomplemento";
            this.CboxElegirAhorroOcomplemento.Size = new System.Drawing.Size(86, 39);
            this.CboxElegirAhorroOcomplemento.TabIndex = 17;
            this.CboxElegirAhorroOcomplemento.SelectedIndexChanged += new System.EventHandler(this.CboxElegirAhorroOcomplemento_SelectedIndexChanged);
            // 
            // txtAhorroCasaOcomplemento
            // 
            this.txtAhorroCasaOcomplemento.Enabled = false;
            this.txtAhorroCasaOcomplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAhorroCasaOcomplemento.Location = new System.Drawing.Point(886, 56);
            this.txtAhorroCasaOcomplemento.Name = "txtAhorroCasaOcomplemento";
            this.txtAhorroCasaOcomplemento.Size = new System.Drawing.Size(104, 38);
            this.txtAhorroCasaOcomplemento.TabIndex = 18;
            this.txtAhorroCasaOcomplemento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAhorroCasaOcomplemento_KeyPress);
            // 
            // lblAhoroCasaOcomplemento
            // 
            this.lblAhoroCasaOcomplemento.AutoSize = true;
            this.lblAhoroCasaOcomplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAhoroCasaOcomplemento.Location = new System.Drawing.Point(811, 59);
            this.lblAhoroCasaOcomplemento.Name = "lblAhoroCasaOcomplemento";
            this.lblAhoroCasaOcomplemento.Size = new System.Drawing.Size(0, 32);
            this.lblAhoroCasaOcomplemento.TabIndex = 19;
            // 
            // Provedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1119, 749);
            this.Controls.Add(this.lblAhoroCasaOcomplemento);
            this.Controls.Add(this.txtAhorroCasaOcomplemento);
            this.Controls.Add(this.CboxElegirAhorroOcomplemento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnRefrescarTabla);
            this.Controls.Add(this.txtPresupuesto);
            this.Controls.Add(this.lblFechaActual);
            this.Controls.Add(this.dtgDiasCompra);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(1137, 796);
            this.Name = "Provedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control de proveedores";
            this.Load += new System.EventHandler(this.Provedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDiasCompra)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtgDiasCompra;
        private System.Windows.Forms.OpenFileDialog OfdElegirImagen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agregarProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarDiasAtrasToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCompra;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.TextBox txtPresupuesto;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnRefrescarTabla;
        private System.Windows.Forms.ComboBox CboxProveedoresSinFechaFijo;
        private System.Windows.Forms.ComboBox CboxAccionRealizar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CboxProveedorAdelantado;
        private System.Windows.Forms.RadioButton RdbProveedorSFechaFijo;
        private System.Windows.Forms.RadioButton RdbProveedorAdelanto;
        private System.Windows.Forms.Label lblMensage;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboxElegirAhorroOcomplemento;
        private System.Windows.Forms.TextBox txtAhorroCasaOcomplemento;
        private System.Windows.Forms.Label lblAhoroCasaOcomplemento;
    }
}