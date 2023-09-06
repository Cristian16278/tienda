using Datos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace tienda
{
    public partial class agregar : Form
    {
        ConectarBD conexion = new ConectarBD();//<----conexion a Datos
        private Action _formcerrar;
        public agregar(Action formcerrar)
        {
            InitializeComponent();
            _formcerrar = formcerrar;
        }

        private void agregar_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formcerrar?.Invoke();
        }

        private void dtgMostrarConsulta_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgMostrarConsulta.SelectedCells.Count > 0)
                {
                    int selecionarCampo = dtgMostrarConsulta.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dtgMostrarConsulta.Rows[selecionarCampo];

                    txtVT.Text = Convert.ToString(row.Cells[0].Value);
                    txtRU.Text = Convert.ToString(row.Cells[1].Value);
                    txtCD.Text = Convert.ToString(row.Cells[2].Value);
                    txtNE.Text = Convert.ToString(row.Cells[3].Value);
                    DateTime fechaseleccionada = (DateTime)row.Cells[4].Value;
                    dtpFechaRegistro.Value = fechaseleccionada;
                    dtpFechaOpcional.Value = fechaseleccionada;
                }
            }
            catch (Exception l)
            {
                MessageBox.Show($"Ocurrio un error\n\n tipo de error:\n {l}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregar_Load(object sender, EventArgs e)
        {
            dtgMostrarConsulta.DataSource = conexion.ConsultaBDtienda();
            dtgMostrarConsulta.ClearSelection();
            cboxSeleccionar.SelectedItem = "Seleccione";
            dtpFechaRegistro.MaxDate = DateTime.Today;
            dtpFechaOpcional.MaxDate = DateTime.Today;
        }

        private void cboxSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string accionrealisar = cboxSeleccionar.SelectedItem.ToString();
                switch (accionrealisar)
                {
                    case "Seleccione":
                        dtgMostrarConsulta.SelectionChanged -= dtgMostrarConsulta_SelectionChanged;
                        btnRealisarInstruccion.Text = "Seleccione";
                        btnRealisarInstruccion.BackColor = Color.White;
                        btnRealisarInstruccion.ForeColor = Color.Black;
                        btnRealisarInstruccion.FlatStyle = FlatStyle.Standard;
                        lblFechaOpcional.Visible = false;
                        dtpFechaOpcional.Visible = false;
                        txtNE.Enabled = false;
                        txtRU.Enabled = false;
                        txtVT.Enabled = false;
                        txtCD.Enabled = false;
                        txtVT.Text = "";
                        txtRU.Text = "";
                        txtCD.Text = "";
                        txtNE.Text = "";
                        txtVT.BackColor = Color.LightGray;
                        txtRU.BackColor = Color.LightGray;
                        txtCD.BackColor = Color.LightGray;
                        txtNE.BackColor = Color.LightGray;
                        btnRealisarInstruccion.Click -= BtnAgregar_Click;
                        btnRealisarInstruccion.Click -= BtnBorrar_Click;
                        btnRealisarInstruccion.Click -= BtnModificar_Click;
                        break;
                    case "Agregar":
                        btnRealisarInstruccion.Text = "Agregar";
                        txtNE.Enabled = true;
                        txtRU.Enabled = true;
                        txtVT.Enabled = true;
                        txtCD.Enabled = true;
                        btnRealisarInstruccion.FlatStyle = FlatStyle.Flat;
                        btnRealisarInstruccion.BackColor = Color.Green;
                        btnRealisarInstruccion.ForeColor = Color.White;
                        dtgMostrarConsulta.SelectionChanged -= dtgMostrarConsulta_SelectionChanged;
                        txtVT.Text = "";
                        txtRU.Text = "";
                        txtCD.Text = "";
                        txtNE.Text = "";
                        txtVT.BackColor = Color.White;
                        txtRU.BackColor = Color.White;
                        txtCD.BackColor = Color.White;
                        txtNE.BackColor = Color.White;
                        dtpFechaRegistro.Enabled = true;
                        dtpFechaOpcional.Visible = false;
                        lblFechaOpcional.Visible = false;
                        btnRealisarInstruccion.Click -=BtnAgregar_Click;//borrar si se selecciono varias veses y evitar que salga varios errores
                        btnRealisarInstruccion.Click += BtnAgregar_Click;//volverlo a agregar para que solo se aga una ves
                        btnRealisarInstruccion.Click -= BtnBorrar_Click;
                        btnRealisarInstruccion.Click -= BtnModificar_Click;
                        break;
                    case "Modificar":
                        btnRealisarInstruccion.Text = "Modificar";
                        txtNE.Enabled = true;
                        txtRU.Enabled = true;
                        txtVT.Enabled = true;
                        txtCD.Enabled = true;
                        btnRealisarInstruccion.FlatStyle = FlatStyle.Flat;
                        btnRealisarInstruccion.BackColor = Color.Yellow;
                        btnRealisarInstruccion.ForeColor = Color.Black;
                        dtgMostrarConsulta.SelectionChanged -= dtgMostrarConsulta_SelectionChanged;//quitar si existe para seleccionar si no, no ocurrira nada
                        dtgMostrarConsulta.SelectionChanged += dtgMostrarConsulta_SelectionChanged;//se agrega nuevamente para seleccionar
                        txtVT.Text = "";
                        txtRU.Text = "";
                        txtCD.Text = "";
                        txtNE.Text = "";
                        txtVT.BackColor = Color.White;
                        txtRU.BackColor = Color.White;
                        txtCD.BackColor = Color.White;
                        txtNE.BackColor = Color.White;
                        dtpFechaRegistro.Enabled = false;
                        dtpFechaOpcional.Visible = true;
                        lblFechaOpcional.Visible = true;
                        btnRealisarInstruccion.Click -= BtnAgregar_Click;
                        btnRealisarInstruccion.Click -= BtnBorrar_Click;
                        btnRealisarInstruccion.Click -= BtnModificar_Click;//borrar si se selecciono varias veses y evitar que salga varios errores
                        btnRealisarInstruccion.Click += BtnModificar_Click;//volverlo a agregar para que solo se aga una ves
                        break;
                    case "Borrar":
                        btnRealisarInstruccion.Text = "Borrar";
                        dtgMostrarConsulta.SelectionChanged -= dtgMostrarConsulta_SelectionChanged;//quitar si existe para seleccionar si no, no ocurrira nada
                        dtgMostrarConsulta.SelectionChanged += dtgMostrarConsulta_SelectionChanged;//se agrega nuevamente para seleccionar
                        txtNE.Enabled = false;
                        txtRU.Enabled = false;
                        txtVT.Enabled = false;
                        txtCD.Enabled = false;
                        txtVT.Text = "";
                        txtRU.Text = "";
                        txtCD.Text = "";
                        txtNE.Text = "";
                        txtVT.BackColor = Color.LightGray;
                        txtRU.BackColor = Color.LightGray;
                        txtCD.BackColor = Color.LightGray;
                        txtNE.BackColor = Color.LightGray;
                        btnRealisarInstruccion.FlatStyle = FlatStyle.Flat;
                        btnRealisarInstruccion.BackColor = Color.Red;
                        btnRealisarInstruccion.ForeColor = Color.White;
                        dtpFechaRegistro.Enabled = true;
                        dtpFechaOpcional.Visible = false;
                        lblFechaOpcional.Visible = false;
                        btnRealisarInstruccion.Click -= BtnAgregar_Click;
                        btnRealisarInstruccion.Click -= BtnBorrar_Click;//borrar si se selecciono varias veses y evitar que salga varios errores
                        btnRealisarInstruccion.Click += BtnBorrar_Click;//volverlo a agregar para que solo se aga una ves
                        btnRealisarInstruccion.Click -= BtnModificar_Click;
                        break;
                }
            }
            catch (Exception r)
            {
                MessageBox.Show($"Ocurrio un error\n\n tipo de error:\n {r}","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaborrar = dtpFechaRegistro.Value;
                int vtb = Convert.ToInt32(txtVT.Text);
                int rub = Convert.ToInt32(txtRU.Text);
                int cdb = Convert.ToInt32(txtCD.Text);
                int neb = Convert.ToInt32(txtNE.Text);
                DialogResult re = MessageBox.Show("Esta seguro que quiere borrar esta fila?", "Advertencia!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (re == DialogResult.Yes)
                {
                    if(conexion.Borrar(fechaborrar.ToString()) == 0)
                    {
                        dtgMostrarConsulta.DataSource = conexion.ConsultaBDtienda();
                        txtVT.Text = "";
                        txtRU.Text = "";
                        txtNE.Text = "";
                        txtCD.Text = "";
                        MessageBox.Show("Se borro correctamente", "Accion realizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La fecha que desea borrar no existe", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //cboxSeleccionar.SelectedItem = "Seleccione";
                }
                else
                {
                    MessageBox.Show("No se borro nada", "Accion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show($"Selecione la fila que desea borrar", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception i)
            {
                MessageBox.Show($"Hubo un error\n\nTipo de error:\n{i}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)//arreglar para que no envie el mensaje de que la fecha que intenta modificar no existe apesar de que no lo modifico
        {
            try
            {
                DateTime fechamodificar = dtpFechaRegistro.Value;
                DateTime fechamodificaropcional = dtpFechaOpcional.Value;
                int vt = Convert.ToInt32(txtVT.Text);
                int ru = Convert.ToInt32(txtRU.Text);
                int cd = Convert.ToInt32(txtCD.Text);
                int ne = Convert.ToInt32(txtNE.Text);
                DialogResult resu = MessageBox.Show("Esta seguro que quiere modificar esta fila?", "Advertencia!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resu == DialogResult.Yes)
                {
                    conexion.Modificar(vt, ru,cd, ne, fechamodificaropcional.ToString(), fechamodificar.ToString());
                    dtgMostrarConsulta.DataSource = conexion.ConsultaBDtienda();
                    txtVT.Text = "";
                    txtRU.Text = "";
                    txtCD.Text = "";
                    txtNE.Text = "";
                    MessageBox.Show("Se modifico correctamente","Accion realizada correctamente",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //cboxSeleccionar.SelectedItem = "Seleccione";
                }
                else
                {
                    MessageBox.Show("No se modifico nada", "Accion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show($"Selecione una fila o escriba los valores que coincidan con lo que desea modificar","Advertencia!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Hubo un error\n\nTipo de error:\n{ex}", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaguardar = dtpFechaRegistro.Value;
                int vtg = Convert.ToInt32(txtVT.Text);
                int rug = Convert.ToInt32(txtRU.Text);
                int cdg = Convert.ToInt32(txtCD.Text);
                int neg = Convert.ToInt32(txtNE.Text);
                DialogResult resultado = MessageBox.Show("Esta seguro que quiere agregar estos datos?", "Advertencia!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    TimeSpan ho = DateTime.Now.TimeOfDay;
                    bool existe = conexion.guardar(vtg, rug, cdg, neg, fechaguardar.ToString(), ho);
                    if (existe)
                    {
                        dtgMostrarConsulta.DataSource = conexion.ConsultaBDtienda();
                        MessageBox.Show("Registro guardado correctamente", "Accion realizada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La fecha que esta intentando agregar ya existe", "Hubo un problema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txtVT.Text = "";
                    txtRU.Text = "";
                    txtNE.Text = "";
                    txtCD.Text = "";
                    //cboxSeleccionar.SelectedItem = "Seleccione";
                }
                else
                {
                    MessageBox.Show("No se guardo nada", "Accion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show($"Ingrese valores a agregar", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception err)
            {
                MessageBox.Show($"Hubo un error\n\nTipo de error:\n{err}","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
            
        }

        private void dtgMostrarConsulta_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgMostrarConsulta.ClearSelection();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            dtgMostrarConsulta.DataSource = conexion.ConsultaBDtienda();
            dtgMostrarConsulta.ClearSelection();
        }

        private void txtVT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtRU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
