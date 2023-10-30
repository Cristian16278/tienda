using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tienda
{
    public partial class ConsultaDiasAnteriores : Form
    {
        ConectarBD ConectarBD = new ConectarBD();
        
        private DateTime fechaActual = DateTime.Now.Date;
        public ConsultaDiasAnteriores()
        {
            InitializeComponent();
        }

        private void ConsultaDiasAnteriores_Load(object sender, EventArgs e)
        {
            CargarTablasDiasAtras();
            QuitarColumnaProveedorID();
            AgregarBotonAlaTabla(dataGridView1);
            AgregarBotonAlaTabla(dataGridView2);
            AgregarBotonAlaTabla(dataGridView3);
            AgregarBotonAlaTabla(dataGridView4);
            AgregarEventoCellClickAdataGridview(true);
        }

        private void QuitarColumnaProveedorID()
        {
            dataGridView1.Columns["ProveedorID"].Visible = false;
            dataGridView2.Columns["ProveedorID"].Visible = false;
            dataGridView3.Columns["ProveedorID"].Visible = false;
            dataGridView4.Columns["ProveedorID"].Visible = false;
            dataGridView1.Columns["ProveedorDiaID"].Visible = false;
            dataGridView2.Columns["ProveedorDiaID"].Visible = false;
            dataGridView3.Columns["ProveedorDiaID"].Visible = false;
            dataGridView4.Columns["ProveedorDiaID"].Visible = false;
        }

        private void AgregarEventoCellClickAdataGridview(DataGridView data, bool quitarOagregarEvento)//con este se traba bastante
        {
            if (quitarOagregarEvento)
            {
                data.CellClick += VisualizarImagen_CellClick;
                
            }
            else
            {
                data.CellClick -= VisualizarImagen_CellClick;
                
            }
        }

        private void AgregarEventoCellClickAdataGridview(bool quitarOagregarEvento)//creo que es mejor este en rendimiento
        {
            if (quitarOagregarEvento)
            {
                dataGridView1.CellClick += VisualizarImagen_CellClick;
                dataGridView2.CellClick += VisualizarImagen_CellClick;
                dataGridView3.CellClick += VisualizarImagen_CellClick;
                dataGridView4.CellClick += VisualizarImagen_CellClick;

            }
            else
            {
                dataGridView1.CellClick -= VisualizarImagen_CellClick;
                dataGridView2.CellClick -= VisualizarImagen_CellClick;
                dataGridView3.CellClick -= VisualizarImagen_CellClick;
                dataGridView4.CellClick -= VisualizarImagen_CellClick;

            }
        }

        private void VisualizarImagen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = (DataGridView)sender;
            string nombredeldatagridview = data.Name;
            DateTime fechadtgEspecifico = obtenerFechaDtgEspecifico(nombredeldatagridview);
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if(e.ColumnIndex == data.Columns["Visualizar imagen"].Index)
                {
                    int indice = e.RowIndex;
                    int proveedorID = (int)data.Rows[indice].Cells["ProveedorID"].Value;
                    int registroDC = (int)data.Rows[indice].Cells["ProveedorDiaID"].Value;
                    var (Proveedorexiste, rutaimagen) = ConectarBD.VerificarImagenEnProveedor(fechadtgEspecifico, proveedorID, registroDC);//aqui falta poner la fecha dependiendo el dia que sea en el datagridview
                    if(Proveedorexiste == proveedorID)
                    {
                        Previsualisacion_imagen imagen = new Previsualisacion_imagen(rutaimagen, "si");
                        if(imagen.ShowDialog() == DialogResult.OK)
                        {
                            MessageBox.Show("se guardara la nueva ruta");
                            //string obtenernuevaruta = imagen.ObtenerNuevaRuta();
                            //MessageBox.Show("Se guardara la nueva ruta");
                            //ConectarBD.GuardarImagenProveedor(proveedorID, date, obtenernuevaruta);
                            //data.DataSource = conectar.CargarTablaDiasCompra(date);
                        }
                        else
                        {
                            MessageBox.Show("No se hara ningun cambio");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay imagen que mostrar");
                    }
                }
            }
        }

        private DateTime obtenerFechaDtgEspecifico(string nombreDtg)
        {
            if (nombreDtg == "dataGridView1")
            {
                return fechadtg1;
            }
            else if (nombreDtg == "dataGridView2")
            {
                return fechadtg2;
            }
            else if (nombreDtg == "dataGridView3")
            {
                return fechadtg3;
            }
            else
            {
                return fechadtg4;
            }
        }

        DateTime fechadtg1;
        DateTime fechadtg2;
        DateTime fechadtg3;
        DateTime fechadtg4;

        private void CargarTablasDiasAtras()
        {
            for(int i = 0; i < 4; i++)
            {
                DateTime fecharetrocedida = fechaActual.AddDays(-i);
                DataTable dt = ConectarBD.CargarTablaDiasCompra(fecharetrocedida);
                switch (i)
                {
                    case 0:
                        dataGridView1.DataSource = dt;
                        string fechaFormateada = fecharetrocedida.ToString("dddd, d 'de' MMMM 'de' yyyy");
                        label1.Text = fechaFormateada;
                        fechadtg1 = fecharetrocedida;
                        if(ConectarBD.TraerNetoExistenteDiaAnterior(fecharetrocedida) == 0)
                        {
                            BtnSacarCuentas1.Enabled = true;
                            BtnSacarCuentas1.Visible = true;
                        }
                        else
                        {
                            BtnSacarCuentas1.Enabled = false;
                            BtnSacarCuentas1.Visible = false;
                        }
                        break;
                    case 1:
                        dataGridView2.DataSource = dt;
                        string fechaFormateada1 = fecharetrocedida.ToString("dddd, d 'de' MMMM 'de' yyyy");
                        label2.Text = fechaFormateada1;
                        fechadtg2 = fecharetrocedida;
                        if (ConectarBD.TraerNetoExistenteDiaAnterior(fecharetrocedida) == 0)
                        {
                            BtnSacarCuentas2.Enabled = true;
                            BtnSacarCuentas2.Visible = true;
                        }
                        else
                        {
                            BtnSacarCuentas2.Enabled = false;
                            BtnSacarCuentas2.Visible = false;
                        }
                        break;
                    case 2:
                        dataGridView3.DataSource = dt;
                        string fechaFormateada2 = fecharetrocedida.ToString("dddd, d 'de' MMMM 'de' yyyy");
                        label3.Text = fechaFormateada2;
                        fechadtg3 = fecharetrocedida;
                        if (ConectarBD.TraerNetoExistenteDiaAnterior(fecharetrocedida) == 0)
                        {
                            BtnSacarCuentas3.Enabled = true;
                            BtnSacarCuentas3.Visible = true;
                        }
                        else
                        {
                            BtnSacarCuentas3.Enabled = false;
                            BtnSacarCuentas3.Visible = false;
                        }
                        break;
                    case 3:
                        dataGridView4.DataSource = dt;
                        string fechaFormateada3 = fecharetrocedida.ToString("dddd, d 'de' MMMM 'de' yyyy");
                        label4.Text = fechaFormateada3;
                        fechadtg4 = fecharetrocedida;
                        if (ConectarBD.TraerNetoExistenteDiaAnterior(fecharetrocedida) == 0)
                        {
                            BtnSacarCuentas4.Enabled = true;
                            BtnSacarCuentas4.Visible = true;
                        }
                        else
                        {
                            BtnSacarCuentas4.Enabled = false;
                            BtnSacarCuentas4.Visible = false;
                        }
                        break;
                }
            }
        }

        private void BtnDiaAtras_Click(object sender, EventArgs e)
        {
            fechaActual = fechaActual.AddDays(-4);
            CargarTablasDiasAtras();
        }

        private void BtnDiaAvansar_Click(object sender, EventArgs e)
        {
            fechaActual = fechaActual.AddDays(4);
            CargarTablasDiasAtras();
        }

        private void AgregarBotonAlaTabla(DataGridView dataGrid)
        {
            DataGridViewButtonColumn botonVisualizarImagen = new DataGridViewButtonColumn();
            botonVisualizarImagen.Name = "Visualizar imagen";
            botonVisualizarImagen.Text = "Visualizar imagen";
            botonVisualizarImagen.UseColumnTextForButtonValue = true;
            dataGrid.Columns.Add(botonVisualizarImagen);
        }

        DateTime obtenerfecha;
        DateTime guardarfecha;
        private void BtnSacarCuentas1_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg1;//para sumar los proveedores de ese dia
            DateTime fechaanterior = obtenerfecha.AddDays(-1);//para obtener el neto existente del dia anterior al dia que se cunsulta para poder restarlo.
            LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
        }

        private void LogicaParaCalcularGuardar(DateTime fechaSumarProveedor, DateTime fechaObtenerNEanterior)
        {
            double SumaProveedoresFechaPersonalizada = ConectarBD.SumarTodosLosProveedoresFechaActual(fechaSumarProveedor);
            double NEfechaPersonalizada = ConectarBD.TraerNetoExistenteDiaAnterior(fechaObtenerNEanterior);
            double resultado = NEfechaPersonalizada - SumaProveedoresFechaPersonalizada;
            string re = resultado.ToString("N2");
            guardarFechaPersonalizada(fechaSumarProveedor);
            DialogResult respuesta = MessageBox.Show($"El resultado de la resta de N.E(${NEfechaPersonalizada}) y la suma de todos los proveedores(${SumaProveedoresFechaPersonalizada}) de la fecha {obtenerfecha} es ${re}.\nEsta de acuerdo con el resultado?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (respuesta == DialogResult.Yes)
            {
                this.Hide();
                if (resultado < 0)//si es negativo
                {
                    VerificarSiEsNumeroNegativo(resultado);
                    double numeronegativo = Math.Abs(resultado);
                    double numeroredondeado = Math.Round(numeronegativo);
                    GuardarAgarroDeLaCaja(numeroredondeado);
                    CuentasDiarias cuentas = new CuentasDiarias(numeroredondeado, "Si");
                    if (cuentas.ShowDialog() == DialogResult.Cancel)
                    {
                        this.Show();
                    }
                }
                else//si no es negativo
                {
                    VerificarSiEsNumeroNegativo(resultado);
                    double redondear = Math.Round(resultado);
                    GuardarAgarroDeLaCaja(redondear);
                    CuentasDiarias cuentas = new CuentasDiarias();
                    if (cuentas.ShowDialog() == DialogResult.Cancel)
                    {
                        this.Show();
                    }
                }

            }
            else
            {

            }
        }

        private void BtnSacarCuentas2_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg2;
            DateTime fechaanterior = obtenerfecha.AddDays(-1);
            LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
        }

        private void BtnSacarCuentas3_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg3;
            DateTime fechaanterior = obtenerfecha.AddDays(-1);
            LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
        }

        private void BtnSacarCuentas4_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg4;
            DateTime fechaanterior = obtenerfecha.AddDays(-1);
            LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
        }

        public DateTime ObtenerFechaAguardar()//con este metodo guardaremos la fecha que se quiere guardar
        {
            DateTime obtenerfecha = Properties.Settings.Default.FechaPersonalizadaGuardar;
            return obtenerfecha;
        }

        public void guardarFechaPersonalizada(DateTime fechaAguardar)
        {
            Properties.Settings.Default.FechaPersonalizadaGuardar = fechaAguardar;
            Properties.Settings.Default.Save();
        }

        public void VerificarSiEsNumeroNegativo(double restar)
        {
            Properties.Settings.Default.NumeroNegativoOno = restar;
            Properties.Settings.Default.Save();
        }

        private void GuardarAgarroDeLaCaja(double guardar)
        {
            Properties.Settings.Default.Delacaja = guardar;
            Properties.Settings.Default.Save();
        }
    }
}
