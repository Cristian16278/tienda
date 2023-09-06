﻿namespace tienda
{
    partial class AgregarProveedores
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
            this.DtgvProveedores = new System.Windows.Forms.DataGridView();
            this.CboxElegirAccion = new System.Windows.Forms.ComboBox();
            this.lblRealizarAccion = new System.Windows.Forms.Label();
            this.BtnRealizarAccion = new System.Windows.Forms.Button();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblDiavisitaProveedor = new System.Windows.Forms.Label();
            this.TxtProveedor = new System.Windows.Forms.TextBox();
            this.CheckboxLunes = new System.Windows.Forms.CheckBox();
            this.CheckboxMartes = new System.Windows.Forms.CheckBox();
            this.CheckboxMiercoles = new System.Windows.Forms.CheckBox();
            this.CheckboxDomingo = new System.Windows.Forms.CheckBox();
            this.CheckboxViernes = new System.Windows.Forms.CheckBox();
            this.CheckboxSabado = new System.Windows.Forms.CheckBox();
            this.CheckboxJueves = new System.Windows.Forms.CheckBox();
            this.GropboxVariosDias = new System.Windows.Forms.GroupBox();
            this.CheckboxNoPasa = new System.Windows.Forms.CheckBox();
            this.lblObtenerDias = new System.Windows.Forms.Label();
            this.lblDiaAcambiar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgvProveedores)).BeginInit();
            this.GropboxVariosDias.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgvProveedores
            // 
            this.DtgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgvProveedores.Location = new System.Drawing.Point(395, 12);
            this.DtgvProveedores.Name = "DtgvProveedores";
            this.DtgvProveedores.RowHeadersWidth = 51;
            this.DtgvProveedores.RowTemplate.Height = 24;
            this.DtgvProveedores.Size = new System.Drawing.Size(535, 740);
            this.DtgvProveedores.TabIndex = 0;
            this.DtgvProveedores.SelectionChanged += new System.EventHandler(this.DtgvProveedores_SelectionChanged);
            // 
            // CboxElegirAccion
            // 
            this.CboxElegirAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxElegirAccion.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxElegirAccion.FormattingEnabled = true;
            this.CboxElegirAccion.Items.AddRange(new object[] {
            "Seleccione",
            "Agregar proveedor",
            "Modificar proveedor",
            "Borrar proveedor"});
            this.CboxElegirAccion.Location = new System.Drawing.Point(12, 45);
            this.CboxElegirAccion.Name = "CboxElegirAccion";
            this.CboxElegirAccion.Size = new System.Drawing.Size(362, 39);
            this.CboxElegirAccion.TabIndex = 1;
            this.CboxElegirAccion.SelectedIndexChanged += new System.EventHandler(this.CboxElegirAccion_SelectedIndexChanged);
            // 
            // lblRealizarAccion
            // 
            this.lblRealizarAccion.AutoSize = true;
            this.lblRealizarAccion.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealizarAccion.Location = new System.Drawing.Point(12, 12);
            this.lblRealizarAccion.Name = "lblRealizarAccion";
            this.lblRealizarAccion.Size = new System.Drawing.Size(195, 30);
            this.lblRealizarAccion.TabIndex = 2;
            this.lblRealizarAccion.Text = "Realizar accion:";
            // 
            // BtnRealizarAccion
            // 
            this.BtnRealizarAccion.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRealizarAccion.Location = new System.Drawing.Point(12, 701);
            this.BtnRealizarAccion.Name = "BtnRealizarAccion";
            this.BtnRealizarAccion.Size = new System.Drawing.Size(362, 51);
            this.BtnRealizarAccion.TabIndex = 3;
            this.BtnRealizarAccion.Text = "Seleccione";
            this.BtnRealizarAccion.UseVisualStyleBackColor = true;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.Location = new System.Drawing.Point(12, 113);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(27, 30);
            this.lblProveedor.TabIndex = 6;
            this.lblProveedor.Text = "p";
            // 
            // lblDiavisitaProveedor
            // 
            this.lblDiavisitaProveedor.AutoSize = true;
            this.lblDiavisitaProveedor.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiavisitaProveedor.Location = new System.Drawing.Point(12, 213);
            this.lblDiavisitaProveedor.Name = "lblDiavisitaProveedor";
            this.lblDiavisitaProveedor.Size = new System.Drawing.Size(27, 30);
            this.lblDiavisitaProveedor.TabIndex = 7;
            this.lblDiavisitaProveedor.Text = "d";
            // 
            // TxtProveedor
            // 
            this.TxtProveedor.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtProveedor.Location = new System.Drawing.Point(12, 146);
            this.TxtProveedor.Name = "TxtProveedor";
            this.TxtProveedor.Size = new System.Drawing.Size(362, 36);
            this.TxtProveedor.TabIndex = 8;
            // 
            // CheckboxLunes
            // 
            this.CheckboxLunes.AutoSize = true;
            this.CheckboxLunes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxLunes.Location = new System.Drawing.Point(6, 29);
            this.CheckboxLunes.Name = "CheckboxLunes";
            this.CheckboxLunes.Size = new System.Drawing.Size(100, 33);
            this.CheckboxLunes.TabIndex = 10;
            this.CheckboxLunes.Text = "Lunes";
            this.CheckboxLunes.UseVisualStyleBackColor = true;
            // 
            // CheckboxMartes
            // 
            this.CheckboxMartes.AutoSize = true;
            this.CheckboxMartes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxMartes.Location = new System.Drawing.Point(6, 68);
            this.CheckboxMartes.Name = "CheckboxMartes";
            this.CheckboxMartes.Size = new System.Drawing.Size(108, 33);
            this.CheckboxMartes.TabIndex = 11;
            this.CheckboxMartes.Text = "Martes";
            this.CheckboxMartes.UseVisualStyleBackColor = true;
            // 
            // CheckboxMiercoles
            // 
            this.CheckboxMiercoles.AutoSize = true;
            this.CheckboxMiercoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxMiercoles.Location = new System.Drawing.Point(6, 108);
            this.CheckboxMiercoles.Name = "CheckboxMiercoles";
            this.CheckboxMiercoles.Size = new System.Drawing.Size(141, 33);
            this.CheckboxMiercoles.TabIndex = 12;
            this.CheckboxMiercoles.Text = "Miercoles";
            this.CheckboxMiercoles.UseVisualStyleBackColor = true;
            // 
            // CheckboxDomingo
            // 
            this.CheckboxDomingo.AutoSize = true;
            this.CheckboxDomingo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxDomingo.Location = new System.Drawing.Point(177, 94);
            this.CheckboxDomingo.Name = "CheckboxDomingo";
            this.CheckboxDomingo.Size = new System.Drawing.Size(133, 33);
            this.CheckboxDomingo.TabIndex = 13;
            this.CheckboxDomingo.Text = "Domingo";
            this.CheckboxDomingo.UseVisualStyleBackColor = true;
            // 
            // CheckboxViernes
            // 
            this.CheckboxViernes.AutoSize = true;
            this.CheckboxViernes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxViernes.Location = new System.Drawing.Point(6, 187);
            this.CheckboxViernes.Name = "CheckboxViernes";
            this.CheckboxViernes.Size = new System.Drawing.Size(117, 33);
            this.CheckboxViernes.TabIndex = 14;
            this.CheckboxViernes.Text = "Viernes";
            this.CheckboxViernes.UseVisualStyleBackColor = true;
            // 
            // CheckboxSabado
            // 
            this.CheckboxSabado.AutoSize = true;
            this.CheckboxSabado.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxSabado.Location = new System.Drawing.Point(6, 226);
            this.CheckboxSabado.Name = "CheckboxSabado";
            this.CheckboxSabado.Size = new System.Drawing.Size(119, 33);
            this.CheckboxSabado.TabIndex = 15;
            this.CheckboxSabado.Text = "Sabado";
            this.CheckboxSabado.UseVisualStyleBackColor = true;
            // 
            // CheckboxJueves
            // 
            this.CheckboxJueves.AutoSize = true;
            this.CheckboxJueves.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxJueves.Location = new System.Drawing.Point(6, 148);
            this.CheckboxJueves.Name = "CheckboxJueves";
            this.CheckboxJueves.Size = new System.Drawing.Size(111, 33);
            this.CheckboxJueves.TabIndex = 16;
            this.CheckboxJueves.Text = "Jueves";
            this.CheckboxJueves.UseVisualStyleBackColor = true;
            // 
            // GropboxVariosDias
            // 
            this.GropboxVariosDias.Controls.Add(this.CheckboxNoPasa);
            this.GropboxVariosDias.Controls.Add(this.CheckboxLunes);
            this.GropboxVariosDias.Controls.Add(this.CheckboxMartes);
            this.GropboxVariosDias.Controls.Add(this.CheckboxJueves);
            this.GropboxVariosDias.Controls.Add(this.CheckboxMiercoles);
            this.GropboxVariosDias.Controls.Add(this.CheckboxSabado);
            this.GropboxVariosDias.Controls.Add(this.CheckboxDomingo);
            this.GropboxVariosDias.Controls.Add(this.CheckboxViernes);
            this.GropboxVariosDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GropboxVariosDias.ForeColor = System.Drawing.SystemColors.InfoText;
            this.GropboxVariosDias.Location = new System.Drawing.Point(12, 257);
            this.GropboxVariosDias.Name = "GropboxVariosDias";
            this.GropboxVariosDias.Size = new System.Drawing.Size(362, 281);
            this.GropboxVariosDias.TabIndex = 18;
            this.GropboxVariosDias.TabStop = false;
            this.GropboxVariosDias.Text = "Elegir dia:";
            // 
            // CheckboxNoPasa
            // 
            this.CheckboxNoPasa.AutoSize = true;
            this.CheckboxNoPasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckboxNoPasa.Location = new System.Drawing.Point(177, 148);
            this.CheckboxNoPasa.Name = "CheckboxNoPasa";
            this.CheckboxNoPasa.Size = new System.Drawing.Size(155, 33);
            this.CheckboxNoPasa.TabIndex = 17;
            this.CheckboxNoPasa.Text = "Ya no pasa";
            this.CheckboxNoPasa.UseVisualStyleBackColor = true;
            this.CheckboxNoPasa.CheckedChanged += new System.EventHandler(this.CheckboxNoPasa_CheckedChanged);
            // 
            // lblObtenerDias
            // 
            this.lblObtenerDias.AutoSize = true;
            this.lblObtenerDias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObtenerDias.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblObtenerDias.Location = new System.Drawing.Point(15, 635);
            this.lblObtenerDias.Name = "lblObtenerDias";
            this.lblObtenerDias.Size = new System.Drawing.Size(19, 20);
            this.lblObtenerDias.TabIndex = 19;
            this.lblObtenerDias.Text = "o";
            // 
            // lblDiaAcambiar
            // 
            this.lblDiaAcambiar.AutoSize = true;
            this.lblDiaAcambiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaAcambiar.ForeColor = System.Drawing.Color.Red;
            this.lblDiaAcambiar.Location = new System.Drawing.Point(15, 575);
            this.lblDiaAcambiar.Name = "lblDiaAcambiar";
            this.lblDiaAcambiar.Size = new System.Drawing.Size(22, 20);
            this.lblDiaAcambiar.TabIndex = 20;
            this.lblDiaAcambiar.Text = "C";
            // 
            // AgregarProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 764);
            this.Controls.Add(this.lblDiaAcambiar);
            this.Controls.Add(this.lblObtenerDias);
            this.Controls.Add(this.GropboxVariosDias);
            this.Controls.Add(this.TxtProveedor);
            this.Controls.Add(this.lblDiavisitaProveedor);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.BtnRealizarAccion);
            this.Controls.Add(this.lblRealizarAccion);
            this.Controls.Add(this.CboxElegirAccion);
            this.Controls.Add(this.DtgvProveedores);
            this.MaximizeBox = false;
            this.Name = "AgregarProveedores";
            this.Text = "AgregarProveedores";
            this.Load += new System.EventHandler(this.AgregarProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgvProveedores)).EndInit();
            this.GropboxVariosDias.ResumeLayout(false);
            this.GropboxVariosDias.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgvProveedores;
        private System.Windows.Forms.ComboBox CboxElegirAccion;
        private System.Windows.Forms.Label lblRealizarAccion;
        private System.Windows.Forms.Button BtnRealizarAccion;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblDiavisitaProveedor;
        private System.Windows.Forms.TextBox TxtProveedor;
        private System.Windows.Forms.CheckBox CheckboxLunes;
        private System.Windows.Forms.CheckBox CheckboxMartes;
        private System.Windows.Forms.CheckBox CheckboxMiercoles;
        private System.Windows.Forms.CheckBox CheckboxDomingo;
        private System.Windows.Forms.CheckBox CheckboxViernes;
        private System.Windows.Forms.CheckBox CheckboxSabado;
        private System.Windows.Forms.CheckBox CheckboxJueves;
        private System.Windows.Forms.GroupBox GropboxVariosDias;
        private System.Windows.Forms.Label lblObtenerDias;
        private System.Windows.Forms.CheckBox CheckboxNoPasa;
        private System.Windows.Forms.Label lblDiaAcambiar;
    }
}