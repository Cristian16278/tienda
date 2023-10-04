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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImagenCompra = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dtgDiasCompra = new System.Windows.Forms.DataGridView();
            this.OfdElegirImagen = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agregarProveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarDiasAtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDiasCompra)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Proveedor,
            this.Compra,
            this.ImagenCompra});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.Location = new System.Drawing.Point(123, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(191, 437);
            this.dataGridView1.TabIndex = 0;
            // 
            // Proveedor
            // 
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Proveedor.DefaultCellStyle = dataGridViewCellStyle14;
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.MinimumWidth = 10;
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.Width = 200;
            // 
            // Compra
            // 
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Compra.DefaultCellStyle = dataGridViewCellStyle15;
            this.Compra.HeaderText = "Compra";
            this.Compra.MinimumWidth = 10;
            this.Compra.Name = "Compra";
            this.Compra.Width = 200;
            // 
            // ImagenCompra
            // 
            this.ImagenCompra.HeaderText = "Imagen_de_compra";
            this.ImagenCompra.MinimumWidth = 6;
            this.ImagenCompra.Name = "ImagenCompra";
            this.ImagenCompra.Width = 125;
            // 
            // dtgDiasCompra
            // 
            this.dtgDiasCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDiasCompra.Location = new System.Drawing.Point(426, 142);
            this.dtgDiasCompra.Name = "dtgDiasCompra";
            this.dtgDiasCompra.RowHeadersWidth = 51;
            this.dtgDiasCompra.RowTemplate.Height = 24;
            this.dtgDiasCompra.Size = new System.Drawing.Size(424, 377);
            this.dtgDiasCompra.TabIndex = 2;
            this.dtgDiasCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDiasCompra_CellClick);
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
            this.menuStrip1.Size = new System.Drawing.Size(1016, 39);
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
            // Provedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 659);
            this.Controls.Add(this.dtgDiasCompra);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Provedores";
            this.Text = "Provedores";
            this.Load += new System.EventHandler(this.Provedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDiasCompra)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Compra;
        private System.Windows.Forms.DataGridViewButtonColumn ImagenCompra;
        private System.Windows.Forms.DataGridView dtgDiasCompra;
        private System.Windows.Forms.OpenFileDialog OfdElegirImagen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem agregarProveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarDiasAtrasToolStripMenuItem;
    }
}