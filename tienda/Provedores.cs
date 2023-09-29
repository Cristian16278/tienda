using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace tienda
{
    public partial class Provedores : Form
    {
        public Provedores()
        {
            InitializeComponent();
        }
        ConectarBD conectar =  new ConectarBD();

        private void Provedores_Load(object sender, EventArgs e)
        {
            string diaActual = DateTime.Now.ToString("dddd");
            dataGridView1.DataSource = conectar.llenarProveedores(diaActual);
            dataGridView1.Columns["Proveedor"].DataPropertyName = "NombreProveedor";
            dataGridView1.Columns["NombreProveedor"].Visible = false;
            //dataGridView1.Columns["Proveedor"].HeaderText = "Proveedor";
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    row.Cells["Proveedor"].Value = row.Cells["NombreProveedor"].Value;
            //}
        }

        //para abrir el forms
        private AgregarProveedores agregarProveedores = null;
        private ConsultaDiasAnteriores consultaDiasAnteriores = null;
        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(agregarProveedores == null || agregarProveedores.IsDisposed)
            {
                agregarProveedores = new AgregarProveedores();
                agregarProveedores.Show();
            }
            else
            {
                agregarProveedores.Activate();
            }
        }
        
        private void consultarDiasAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(consultaDiasAnteriores == null || consultaDiasAnteriores.IsDisposed)
            {
                consultaDiasAnteriores = new ConsultaDiasAnteriores();
                consultaDiasAnteriores.Show();
            }
            else
            {
                consultaDiasAnteriores.Activate();
            }
        }
        
        //private void Provedores_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    agregarProveedores = null;
        //    consultaDiasAnteriores = null;
        //}

        //para abrir forms
    }
}
