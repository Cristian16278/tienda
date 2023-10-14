using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace tienda
{
    public partial class CuentasDiarias : Form
    {
        ConectarBD cone = new ConectarBD();
        loging lo = new loging();
        
        public CuentasDiarias(double seAgarroDelacaja = 0)
        {
            InitializeComponent();
            int DelaCaja = redondearSeagarrodelacaja(seAgarroDelacaja);
            txtDelacaja.Text = DelaCaja.ToString();
        }

        private int redondearSeagarrodelacaja(double caja)
        {
            int redondear = (int)caja;

            string Redondear = redondear.ToString();
            //asi se convierte de string a una lista de string
            var lista = from x in Redondear select x.ToString();
            List<string> str = new List<string>(lista);

            //se convierte a lista de enteros
            List<int> ints = str.Select(int.Parse).ToList();
            RedondearUn(ints);

            List<string> strings = ints.ConvertAll(x => x.ToString());
            string une = string.Join("", strings);//<-------si da error utilizar este ---->  string une = String.Join("", strings);

            //asi se convierte un string a int
            int delacaja = int.Parse(une);
            return delacaja;
        }

        private void CuentasDiarias_Load(object sender, EventArgs e)
        {
            DateTime fechaactual = DateTime.Today;
            if (cone.ActivarBotonAgarrarDinero(fechaactual) >= 1)
            {
                BtnAgarrarDinero.Enabled = false;
            }
            else
            {
                BtnAgarrarDinero.Enabled = true;
            }

            if(lo.ShowDialog() == DialogResult.OK)
            {
                if(cone.desacbtnSHFechahoy() == DateTime.Today)
                {
                    btnGuardar.Enabled = false;
                    btnGuardar.BackColor = Color.LightGray;
                    BtnBilletesCalcular.Enabled = false;
                    BtnAgarrarDinero.Enabled = true;
                    BtnAgarrarDinero.Visible = true;
                    BtnBilletesCalcular.BackColor = Color.LightGray;
                    lblRegistrohoy.Text = "Ya hay un registro para la fecha de hoy";
                    lblRegistrohoy.ForeColor = Color.Red;
                    txtBilletes.Enabled = false;
                    txtMonedas.Enabled = false;
                    txtDelacaja.Enabled = false;
                    txtConsumoDiario.Enabled = false;
                    txtBilletes.BackColor = Color.LightGray;
                    txtMonedas.BackColor = Color.LightGray;
                    txtDelacaja.BackColor = Color.LightGray;
                    txtConsumoDiario.BackColor = Color.LightGray;
                }
                else
                {
                    btnGuardar.Enabled = true;
                    btnGuardar.BackColor = Color.White;
                }
            }
            else
            {
                MessageBox.Show("Intentelo de nuevo mas tarde","Error al ingresar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Application.Exit();
            }
        }
        int ObtenerNE;
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            calcularCuentas(txtBilletes.Text, txtMonedas.Text, txtDelacaja.Text, txtConsumoDiario.Text);
        }

        private void GuardarNEconfiguracionDefault(int NEguardarEnConfiguracion)
        {
            Properties.Settings.Default.AgarrarDinero = NEguardarEnConfiguracion;
            Properties.Settings.Default.Save();
        }

        private int CargarValorNE()
        {
            int CargarNE = Properties.Settings.Default.AgarrarDinero;
            return CargarNE;
        }

        private void calcularCuentas(string bill, string mone, string delaC, string consumoD)
        {
            try
            {
                int billetes = Int32.Parse(bill);
                int monedas = Int32.Parse(mone);
                int delaCaja = Int32.Parse(delaC);
                int consumoDiario = Int32.Parse(consumoD);
                DialogResult res = MessageBox.Show("Se agarro el dinero de los empleados?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    //se ace el calculo
                    int vt = billetes + monedas + delaCaja;
                    double veinte_porciento = vt * 0.8;
                    double un = vt - veinte_porciento;
                    int redondear = (int)un;

                    string Redondear = redondear.ToString();
                    //asi se convierte de string a una lista de string
                    var lista = from x in Redondear select x.ToString();
                    List<string> str = new List<string>(lista);

                    //se convierte a lista de enteros
                    List<int> ints = str.Select(int.Parse).ToList();

                    //regla de redondeo
                    RedondearUn(ints);

                    //asi se convierte una lista de int a string
                    List<string> strings = ints.ConvertAll(x => x.ToString());
                    string une = string.Join("", strings);//<-------si da error utilizar este ---->  string une = String.Join("", strings);

                    //asi se convierte un string a int
                    int u_netao = int.Parse(une);//<-------------si da error utilizar este -----> int u_netao = Int32.Parse(une);
                    int resto_utilidad = u_netao - consumoDiario;
                    int n_exi = billetes + monedas - resto_utilidad;
                    string fecha = DateTime.Today.ToString();
                    string fechamostrar = DateTime.Now.ToString();
                    listMostrar.Items.Add(fechamostrar);
                    listMostrar.Items.Add($"Billetes = {billetes}");
                    listMostrar.Items.Add($"Monedas = {monedas}");
                    listMostrar.Items.Add($"De la caja = {delaCaja}");
                    listMostrar.Items.Add($"V.T = {vt}");
                    listMostrar.Items.Add($"U.N = {u_netao}");
                    listMostrar.Items.Add($"C.D = {consumoDiario}");
                    listMostrar.Items.Add($"R.U = {resto_utilidad}");
                    listMostrar.Items.Add($"N.E = {n_exi}");
                    TimeSpan horare = DateTime.Now.TimeOfDay;
                    bool berificar = cone.guardar(vt, resto_utilidad, consumoDiario, n_exi, fecha, horare);
                    if (berificar)
                    {
                        MessageBox.Show("Se guardo correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnGuardar.Enabled = false;
                        btnGuardar.BackColor = Color.LightGray;
                        BtnAgarrarDinero.Enabled = true;
                        BtnAgarrarDinero.Visible = true;
                        ObtenerNE = n_exi;
                        GuardarNEconfiguracionDefault(ObtenerNE);
                    }
                    else
                    {
                        MessageBox.Show("la fecha que desea guardar ya existe", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se guardo nada", "Guardado cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show($"Debe ingresar valores","Advertencia!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch (Exception g)
            {
                MessageBox.Show($"Hubo un error\n\nTipo de error:\n{g}","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        //aqui se hace el redondeo
        private void RedondearUn(List<int> redondear)
        {
            try
            {
                if (redondear[redondear.Count - 1] <= 5)
                {
                    redondear[redondear.Count - 1] = 0;
                }
                else if (redondear[redondear.Count - 3] <= 8 && redondear[redondear.Count - 2] == 9 && redondear[redondear.Count - 1] >= 5)
                {
                    
                    //redondear[redondear.Count - 3] = +1;
                    redondear[redondear.Count - 3] = redondear[redondear.Count - 3] + 1;
                    redondear[redondear.Count - 2] = 0;
                    redondear[redondear.Count - 1] = 0;
                }
                else if (redondear[redondear.Count - 3] == 9 && redondear[redondear.Count - 2] == 9 && redondear[redondear.Count - 1] >= 5)
                {
                    redondear[redondear.Count - 4] = redondear[redondear.Count - 4] + 1;
                    redondear[redondear.Count - 3] = 0;
                    redondear[redondear.Count - 2] = 0;
                    redondear[redondear.Count - 1] = 0;
                }
                else
                {
                    redondear[redondear.Count - 2] = redondear[redondear.Count - 2] + 1;
                    redondear[redondear.Count - 1] = 0;
                }
            }
            catch (Exception n)
            {
                MessageBox.Show($"Ocurrio un error(Probablemente sea de que es menor que 1000)\n\ntipo de error:\n {n}","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private bool loginAbrir = false;
        
        private void consultarCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ConsultaVT consulta = new ConsultaVT(() => loginAbrir = false);
                if (!loginAbrir)
                {
                    lo.ShowDialog();
                    if (lo.DialogResult == DialogResult.OK)
                    {
                        consulta.Show();
                        loginAbrir = true;
                    }
                }
                else
                {
                    Form consultaForm = Application.OpenForms.OfType<ConsultaVT>().FirstOrDefault();
                    if (consultaForm != null)
                    {
                        if (consultaForm.WindowState == FormWindowState.Minimized)
                        {
                            consultaForm.WindowState = FormWindowState.Normal; // Restauramos el estado del formulario
                        }
                        consultaForm.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error\n\n tipo de error:\n {ex}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtBilletes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMonedas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDelacaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtConsumoDiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                agregar agre = new agregar(() => loginAbrir = false);
                if (!loginAbrir)
                {
                    lo.ShowDialog();
                    if (lo.DialogResult == DialogResult.OK)
                    {
                        agre.Show();
                        loginAbrir = true;
                    }
                }
                else
                {
                    Form consultaForm = Application.OpenForms.OfType<agregar>().FirstOrDefault();
                    if (consultaForm != null)
                    {
                        if (consultaForm.WindowState == FormWindowState.Minimized)
                        {
                            consultaForm.WindowState = FormWindowState.Normal; // Restauramos el estado del formulario
                        }
                        consultaForm.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error\n\n tipo de error:\n {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void actualisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaactual = DateTime.Today;
                if (cone.ActivarBotonAgarrarDinero(fechaactual) >= 1)
                {
                    BtnAgarrarDinero.Enabled = false;
                }
                else
                {
                    BtnAgarrarDinero.Enabled = true;
                }

                if (cone.desacbtnSHFechahoy() == DateTime.Today)
                {
                    MessageBox.Show("ya hay una registro para la fecha de hoy","Advertencia!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    btnGuardar.Enabled = false;
                    btnGuardar.BackColor = Color.LightGray;
                    BtnBilletesCalcular.Enabled = false;
                    BtnBilletesCalcular.BackColor = Color.LightGray;
                    lblRegistrohoy.Text = "Ya hay un registro para la fecha de hoy";
                    lblRegistrohoy.ForeColor = Color.Red;
                    txtBilletes.Enabled = false;
                    txtMonedas.Enabled = false;
                    txtDelacaja.Enabled = false;
                    txtConsumoDiario.Enabled = false;
                    txtBilletes.BackColor = Color.LightGray;
                    txtMonedas.BackColor = Color.LightGray;
                    txtDelacaja.BackColor = Color.LightGray;
                    txtConsumoDiario.BackColor = Color.LightGray;
                }
                else
                {
                    btnGuardar.Enabled = true;
                    btnGuardar.BackColor = Color.White;
                    BtnBilletesCalcular.Enabled = true;
                    BtnBilletesCalcular.BackColor = Color.White;
                    lblRegistrohoy.Text = "";
                    lblRegistrohoy.ForeColor = Color.Black;
                    txtBilletes.Enabled = true;
                    txtMonedas.Enabled = true;
                    txtDelacaja.Enabled = true;
                    txtConsumoDiario.Enabled = true;
                    txtBilletes.BackColor = Color.White;
                    txtMonedas.BackColor = Color.White;
                    txtDelacaja.BackColor = Color.White;
                    txtConsumoDiario.BackColor = Color.White;
                    txtBilletes.Text = "";
                    txtMonedas.Text = "";
                    txtDelacaja.Text = "0";
                    txtConsumoDiario.Text = "";
                    listMostrar.Items.Clear();
                    
                }
            }
            catch (Exception c)
            {
                MessageBox.Show($"Ocurrio un error\n\n tipo de error:\n {c}","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.Green;
            btnGuardar.ForeColor = Color.White;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = Color.White;
            btnGuardar.ForeColor = Color.Black;
        }

        //para obtener billetes
        Billetes obtener = new Billetes();
        private void BtnBilletesCalcular_Click(object sender, EventArgs e)
        {
            if(obtener.ShowDialog() == DialogResult.OK)
            {
                int mostrarentextbox = obtener.ObtenerResultado();
                txtBilletes.Text = mostrarentextbox.ToString();
            }
        }

        private void BtnAgarrarDinero_Click(object sender, EventArgs e)
        {
            int cargarNE = CargarValorNE();
            AgarrarDinero agarrar = new AgarrarDinero(cargarNE);
            if (agarrar.ShowDialog() == DialogResult.OK)
            {
                BtnAgarrarDinero.Enabled = false;
                MessageBox.Show("Se guardo exitosamente la cantidad para mostrar para el dia de mañana", "Mensage del program", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BtnAgarrarDinero.Enabled = true;
                MessageBox.Show("Alparecer hubo un problema al intentar guardar los datos.", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}