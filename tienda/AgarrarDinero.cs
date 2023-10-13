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
    public partial class AgarrarDinero : Form
    {
        ConectarBD Conectar = new ConectarBD();
        public AgarrarDinero(int NE)
        {
            InitializeComponent();
            lblNE.Text = NE.ToString();
        }

        private void AgarrarDinero_Load(object sender, EventArgs e)
        {
            lblResultadoDineroAgarrado.Text = "";
        }

        private void BtnRestarDineroAgarrar_Click(object sender, EventArgs e)
        {
            try
            {
                int ne = int.Parse(lblNE.Text);
                int Agarrardinero = int.Parse(txtAgarrarDinero.Text);
                int resultado = ne - Agarrardinero;
                lblResultadoDineroAgarrado.Text = resultado.ToString();
                BtnGuardar.Enabled = true;
                BtnRestarDineroAgarrar.Enabled = false;
            }
            catch(FormatException)
            {
                MessageBox.Show("Ingrese valores", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception df)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n {df}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now.Date;
            int guardar = int.Parse(lblResultadoDineroAgarrado.Text);
            int resultado = Conectar.GuardarMostrarNEDiaSiguiente(fecha, guardar);
            if(resultado > 0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void txtAgarrarDinero_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAgarrarDinero.Text))
            {
                BtnRestarDineroAgarrar.Enabled = false;
            }
            else
            {
                BtnRestarDineroAgarrar.Enabled = true;
            }
        }
    }
}
