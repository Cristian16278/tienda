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
    public partial class Billetes : Form
    {
        int resultado1;
        public Billetes()
        {
            InitializeComponent();
        }

        private void txtMil_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMil.Text))
                {
                    lblMil.Text = "Ingrese valores";
                    lblMil.ForeColor = Color.Red;
                }
                else
                {

                    int mil = 1000;
                    int resultado = Calcular(txtMil.Text, mil);
                    lblMil.Text = resultado.ToString();
                    lblMil.ForeColor = Color.Black;
                }
            }
            catch
            {
                lblMil.Text = "Error";
                lblMil.ForeColor = Color.Red;
            }
        }

        private void txtQuinientos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQuinientos.Text))
                {
                    lblQuinientos.Text = "Ingrese valores";
                    lblQuinientos.ForeColor = Color.Red;
                }
                else
                {
                    int quinientos = 500;
                    int resultado = Calcular(txtQuinientos.Text, quinientos);
                    lblQuinientos.Text = resultado.ToString();
                    lblQuinientos.ForeColor = Color.Black;
                }
            }
            catch
            {
                lblQuinientos.Text = "Error";
                lblQuinientos.ForeColor = Color.Red;
            }
        }

        private void txtDoscientos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDoscientos.Text))
                {
                    lblDoscientos.Text = "Ingrese valores";
                    lblDoscientos.ForeColor = Color.Red;
                }
                else
                {
                    int doscientos = 200;
                    int resultado = Calcular(txtDoscientos.Text, doscientos);
                    lblDoscientos.Text = resultado.ToString();
                    lblDoscientos.ForeColor = Color.Black;
                }
            }
            catch
            {
                lblDoscientos.Text = "Error";
                lblDoscientos.ForeColor = Color.Red;
            }
        }

        private void txtCien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCien.Text))
                {
                    lblCien.Text = "Ingrese valores";
                    lblCien.ForeColor = Color.Red;
                }
                else
                {
                    int cien = 100;
                    int resultado = Calcular(txtCien.Text, cien);
                    lblCien.Text = resultado.ToString();
                    lblCien.ForeColor = Color.Black;
                }
            }
            catch
            {
                lblCien.Text = "Error";
                lblCien.ForeColor = Color.Red;
            }
        }

        private void txtCincuenta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCincuenta.Text))
                {
                    lblCincuenta.Text = "Ingrese valores";
                    lblCincuenta.ForeColor = Color.Red;
                }
                else
                {
                    int cincuenta = 50;
                    int resultado = Calcular(txtCincuenta.Text, cincuenta);
                    lblCincuenta.Text = resultado.ToString();
                    lblCincuenta.ForeColor= Color.Black;
                }
            }
            catch
            {
                lblCincuenta.Text = "Error";
                lblCincuenta.ForeColor = Color.Red;
            }
        }

        private void txtVeinte_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtVeinte.Text))
                {
                    lblVeinte.Text = "Ingrese valores";
                    lblVeinte.ForeColor = Color.Red;
                }
                else
                {
                    int veinte = 20;
                    int resultado = Calcular(txtVeinte.Text, veinte);
                    lblVeinte.Text = resultado.ToString();
                    lblVeinte.ForeColor = Color.Black;
                }
            }
            catch
            {
                lblVeinte.Text = "Error";
                lblVeinte.ForeColor = Color.Red;
            }
        }

        private int Calcular(string billete, int cantidadamultiplicar)
        {
            int mil = int.Parse(billete);
            int multiplicar = cantidadamultiplicar;
            int resultado = mil * multiplicar;
            return resultado;
        }


        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMil.Text) && string.IsNullOrEmpty(txtQuinientos.Text) && string.IsNullOrEmpty(txtDoscientos.Text) && string.IsNullOrEmpty(txtCien.Text) && string.IsNullOrEmpty(txtCincuenta.Text) && string.IsNullOrEmpty(txtVeinte.Text))
                {
                    lblResultado.Text = "Esperando...";
                    lblResultado.ForeColor = Color.Red;
                    BtnAceptar.Enabled = false;
                }
                else
                {
                    int mil = int.Parse(lblMil.Text);
                    int quinientos = int.Parse(lblQuinientos.Text);
                    int doscientos = int.Parse(lblDoscientos.Text);
                    int cien = int.Parse(lblCien.Text);
                    int cincuenta = int.Parse(lblCincuenta.Text);
                    int veinte = int.Parse(lblVeinte.Text);
                    int resultado = mil + quinientos + doscientos + cien + cincuenta + veinte;
                    lblResultado.Text = resultado.ToString();
                    lblResultado.ForeColor = Color.Black;
                    resultado1 = int.Parse(lblResultado.Text);
                    //BtnCalcular.Enabled = false;
                    BtnAceptar.Enabled = true;
                    BtnAceptar.BackColor = Color.White;
                    //txtMil.Enabled = false;
                    //txtQuinientos.Enabled = false;
                    //txtDoscientos.Enabled= false;
                    //txtCien.Enabled = false;
                    //txtCincuenta.Enabled = false;
                    //txtVeinte.Enabled = false;
                }
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(txtMil.Text))
                {
                    lblMil.Text = "Le falto aqui";
                }
                if (string.IsNullOrEmpty(txtQuinientos.Text))
                {
                    lblQuinientos.Text = "Le falto aqui";
                }
                if (string.IsNullOrEmpty(txtDoscientos.Text))
                {
                    lblDoscientos.Text = "Le falto aqui";
                }
                if (string.IsNullOrEmpty(txtCien.Text))
                {
                    lblCien.Text = "Le falto aqui";
                }
                if (string.IsNullOrEmpty(txtCincuenta.Text))
                {
                    lblCincuenta.Text = "Le falto aqui";
                }
                if (string.IsNullOrEmpty(txtVeinte.Text))
                {
                    lblVeinte.Text = "Le falto aqui";
                }
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Hide();
        }

        public int ObtenerResultado()
        {
            return resultado1;
        }

        private void txtMil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQuinientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDoscientos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCincuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtVeinte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
