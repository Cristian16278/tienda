using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class Previsualisacion_imagen : Form
    {
        public Previsualisacion_imagen(string imagen)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(imagen);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.Cancel;
        }
    }
}
