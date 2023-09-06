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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tienda
{
    public partial class loging : Form
    {
        ConectarBD conexionDB = new ConectarBD();
        int oportunidades = 5;
        public loging()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexionDB.logear(txtUsuario.Text, txtContrasena.Text) == 1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    oportunidades = 5;
                    txtUsuario.Text = "";
                    txtContrasena.Text = "";
                }
                else
                {
                    oportunidades--;
                    if (oportunidades == 0)
                    {
                        MessageBox.Show("Datos no correctos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        oportunidades = 5;
                        txtUsuario.Text = "";
                        txtContrasena.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contrasena incorrectos", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ocurio un error {ex}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.Green;
            btnIngresar.ForeColor = Color.White;
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = Color.White;
            btnIngresar.ForeColor = Color.Black;
        }
    }
}
