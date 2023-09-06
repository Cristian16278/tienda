namespace tienda
{
    partial class agregar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(agregar));
            this.txtVT = new System.Windows.Forms.TextBox();
            this.txtNE = new System.Windows.Forms.TextBox();
            this.txtRU = new System.Windows.Forms.TextBox();
            this.btnRealisarInstruccion = new System.Windows.Forms.Button();
            this.lblVT = new System.Windows.Forms.Label();
            this.lblRU = new System.Windows.Forms.Label();
            this.lblNE = new System.Windows.Forms.Label();
            this.lblFechaRegistro = new System.Windows.Forms.Label();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.cboxSeleccionar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgMostrarConsulta = new System.Windows.Forms.DataGridView();
            this.dtpFechaOpcional = new System.Windows.Forms.DateTimePicker();
            this.lblFechaOpcional = new System.Windows.Forms.Label();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.txtCD = new System.Windows.Forms.TextBox();
            this.lblConsumoD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMostrarConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // txtVT
            // 
            this.txtVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVT.Location = new System.Drawing.Point(53, 55);
            this.txtVT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVT.Name = "txtVT";
            this.txtVT.Size = new System.Drawing.Size(199, 41);
            this.txtVT.TabIndex = 0;
            this.txtVT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVT_KeyPress);
            // 
            // txtNE
            // 
            this.txtNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNE.Location = new System.Drawing.Point(53, 342);
            this.txtNE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNE.Name = "txtNE";
            this.txtNE.Size = new System.Drawing.Size(199, 41);
            this.txtNE.TabIndex = 2;
            this.txtNE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNE_KeyPress);
            // 
            // txtRU
            // 
            this.txtRU.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRU.Location = new System.Drawing.Point(53, 149);
            this.txtRU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRU.Name = "txtRU";
            this.txtRU.Size = new System.Drawing.Size(199, 41);
            this.txtRU.TabIndex = 1;
            this.txtRU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRU_KeyPress);
            // 
            // btnRealisarInstruccion
            // 
            this.btnRealisarInstruccion.BackColor = System.Drawing.Color.White;
            this.btnRealisarInstruccion.FlatAppearance.BorderSize = 0;
            this.btnRealisarInstruccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealisarInstruccion.ForeColor = System.Drawing.Color.Black;
            this.btnRealisarInstruccion.Location = new System.Drawing.Point(309, 677);
            this.btnRealisarInstruccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRealisarInstruccion.Name = "btnRealisarInstruccion";
            this.btnRealisarInstruccion.Size = new System.Drawing.Size(231, 46);
            this.btnRealisarInstruccion.TabIndex = 4;
            this.btnRealisarInstruccion.UseVisualStyleBackColor = false;
            // 
            // lblVT
            // 
            this.lblVT.AutoSize = true;
            this.lblVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVT.Location = new System.Drawing.Point(48, 20);
            this.lblVT.Name = "lblVT";
            this.lblVT.Size = new System.Drawing.Size(66, 32);
            this.lblVT.TabIndex = 9;
            this.lblVT.Text = "V.T:";
            // 
            // lblRU
            // 
            this.lblRU.AutoSize = true;
            this.lblRU.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRU.Location = new System.Drawing.Point(49, 114);
            this.lblRU.Name = "lblRU";
            this.lblRU.Size = new System.Drawing.Size(70, 32);
            this.lblRU.TabIndex = 10;
            this.lblRU.Text = "R.U:";
            // 
            // lblNE
            // 
            this.lblNE.AutoSize = true;
            this.lblNE.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNE.Location = new System.Drawing.Point(48, 306);
            this.lblNE.Name = "lblNE";
            this.lblNE.Size = new System.Drawing.Size(69, 32);
            this.lblNE.TabIndex = 11;
            this.lblNE.Text = "N.E:";
            // 
            // lblFechaRegistro
            // 
            this.lblFechaRegistro.AutoSize = true;
            this.lblFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRegistro.Location = new System.Drawing.Point(49, 450);
            this.lblFechaRegistro.Name = "lblFechaRegistro";
            this.lblFechaRegistro.Size = new System.Drawing.Size(210, 64);
            this.lblFechaRegistro.TabIndex = 12;
            this.lblFechaRegistro.Text = "Fecha registro:\r\n(DD/MM/YYYY)";
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaRegistro.Location = new System.Drawing.Point(53, 529);
            this.dtpFechaRegistro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(199, 41);
            this.dtpFechaRegistro.TabIndex = 3;
            // 
            // cboxSeleccionar
            // 
            this.cboxSeleccionar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxSeleccionar.FormattingEnabled = true;
            this.cboxSeleccionar.Items.AddRange(new object[] {
            "Seleccione",
            "Agregar",
            "Modificar",
            "Borrar"});
            this.cboxSeleccionar.Location = new System.Drawing.Point(53, 679);
            this.cboxSeleccionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboxSeleccionar.Name = "cboxSeleccionar";
            this.cboxSeleccionar.Size = new System.Drawing.Size(227, 44);
            this.cboxSeleccionar.TabIndex = 14;
            this.cboxSeleccionar.SelectedIndexChanged += new System.EventHandler(this.cboxSeleccionar_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 644);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Accion a realizar:";
            // 
            // dtgMostrarConsulta
            // 
            this.dtgMostrarConsulta.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dtgMostrarConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgMostrarConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgMostrarConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgMostrarConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgMostrarConsulta.BackgroundColor = System.Drawing.Color.LightGray;
            this.dtgMostrarConsulta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Wheat;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgMostrarConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgMostrarConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MediumAquamarine;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgMostrarConsulta.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgMostrarConsulta.EnableHeadersVisualStyles = false;
            this.dtgMostrarConsulta.Location = new System.Drawing.Point(569, 12);
            this.dtgMostrarConsulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgMostrarConsulta.MultiSelect = false;
            this.dtgMostrarConsulta.Name = "dtgMostrarConsulta";
            this.dtgMostrarConsulta.ReadOnly = true;
            this.dtgMostrarConsulta.RowHeadersVisible = false;
            this.dtgMostrarConsulta.RowHeadersWidth = 51;
            this.dtgMostrarConsulta.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgMostrarConsulta.RowTemplate.Height = 24;
            this.dtgMostrarConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgMostrarConsulta.Size = new System.Drawing.Size(753, 730);
            this.dtgMostrarConsulta.TabIndex = 16;
            this.dtgMostrarConsulta.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgMostrarConsulta_DataBindingComplete);
            // 
            // dtpFechaOpcional
            // 
            this.dtpFechaOpcional.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaOpcional.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaOpcional.Location = new System.Drawing.Point(309, 529);
            this.dtpFechaOpcional.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaOpcional.Name = "dtpFechaOpcional";
            this.dtpFechaOpcional.Size = new System.Drawing.Size(199, 41);
            this.dtpFechaOpcional.TabIndex = 17;
            this.dtpFechaOpcional.Visible = false;
            // 
            // lblFechaOpcional
            // 
            this.lblFechaOpcional.AutoSize = true;
            this.lblFechaOpcional.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaOpcional.Location = new System.Drawing.Point(303, 450);
            this.lblFechaOpcional.Name = "lblFechaOpcional";
            this.lblFechaOpcional.Size = new System.Drawing.Size(224, 64);
            this.lblFechaOpcional.TabIndex = 18;
            this.lblFechaOpcional.Text = "Modificar Fecha:\r\n(Opcional)";
            this.lblFechaOpcional.Visible = false;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Location = new System.Drawing.Point(445, 12);
            this.BtnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(117, 57);
            this.BtnActualizar.TabIndex = 19;
            this.BtnActualizar.Text = "Actualizar\r\ntabla";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // txtCD
            // 
            this.txtCD.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCD.Location = new System.Drawing.Point(53, 247);
            this.txtCD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCD.Name = "txtCD";
            this.txtCD.Size = new System.Drawing.Size(199, 41);
            this.txtCD.TabIndex = 20;
            this.txtCD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCD_KeyPress);
            // 
            // lblConsumoD
            // 
            this.lblConsumoD.AutoSize = true;
            this.lblConsumoD.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumoD.Location = new System.Drawing.Point(49, 212);
            this.lblConsumoD.Name = "lblConsumoD";
            this.lblConsumoD.Size = new System.Drawing.Size(77, 32);
            this.lblConsumoD.TabIndex = 21;
            this.lblConsumoD.Text = "C.D :";
            // 
            // agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1336, 752);
            this.Controls.Add(this.lblConsumoD);
            this.Controls.Add(this.txtCD);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.lblFechaOpcional);
            this.Controls.Add(this.dtpFechaOpcional);
            this.Controls.Add(this.dtgMostrarConsulta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxSeleccionar);
            this.Controls.Add(this.dtpFechaRegistro);
            this.Controls.Add(this.lblFechaRegistro);
            this.Controls.Add(this.lblNE);
            this.Controls.Add(this.lblRU);
            this.Controls.Add(this.lblVT);
            this.Controls.Add(this.btnRealisarInstruccion);
            this.Controls.Add(this.txtRU);
            this.Controls.Add(this.txtNE);
            this.Controls.Add(this.txtVT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1429, 799);
            this.MinimumSize = new System.Drawing.Size(1351, 799);
            this.Name = "agregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar, Modificar y Borrar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.agregar_FormClosed);
            this.Load += new System.EventHandler(this.agregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgMostrarConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVT;
        private System.Windows.Forms.TextBox txtNE;
        private System.Windows.Forms.TextBox txtRU;
        private System.Windows.Forms.Button btnRealisarInstruccion;
        private System.Windows.Forms.Label lblVT;
        private System.Windows.Forms.Label lblRU;
        private System.Windows.Forms.Label lblNE;
        private System.Windows.Forms.Label lblFechaRegistro;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistro;
        private System.Windows.Forms.ComboBox cboxSeleccionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgMostrarConsulta;
        private System.Windows.Forms.DateTimePicker dtpFechaOpcional;
        private System.Windows.Forms.Label lblFechaOpcional;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.TextBox txtCD;
        private System.Windows.Forms.Label lblConsumoD;
    }
}