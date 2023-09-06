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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Provedores_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = 
        }

        private void agregarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarDiasAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
