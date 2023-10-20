using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Microsoft.Win32;

namespace tienda
{
    public partial class AgarrarDinero : Form
    {
        //ConectarBD Conectar = new ConectarBD();
        public AgarrarDinero(int NEOSobroProveedores, string SobroOagarrar)
        {
            InitializeComponent();
            lblNE.Text = NEOSobroProveedores.ToString();
            lblSobroOagarrar.Text = SobroOagarrar;
        }

        private void AgarrarDinero_Load(object sender, EventArgs e)
        {
            lblResultadoDineroAgarrado.Text = "";
        }

        int obtenerDinero;


        public int ObtenerNEoProveedor()
        {
            return obtenerDinero;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int Agarrardinero = int.Parse(txtAgarrarDinero.Text);//8,000
            DialogResult respuesta = MessageBox.Show($"Esta seguro de almacenar ${Agarrardinero}?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                obtenerDinero = Agarrardinero;
                DialogResult = DialogResult.OK;
            }
            else
            {

            }
        }

        private void txtAgarrarDinero_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string texto = lblSobroOagarrar.Text;
                int lbl = int.Parse(lblNE.Text);
                int txt = int.Parse(txtAgarrarDinero.Text);
                if (txt > lbl)
                {
                    MessageBox.Show($"No puede dejar mas que {texto}{lbl}");
                    BtnGuardar.Enabled = false;
                }
                else
                {
                    BtnGuardar.Enabled = true;
                }
            }
            catch(FormatException)
            {
                BtnGuardar.Enabled = false;
            }
            catch(Exception f)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{f}");
            }
        }
    }
}