using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            BtnConsultar.Visible = false;
            CboxElegirDia.Visible = false;
            BtnDiaAvansar.Enabled = false;
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
                        double suma1 = ConectarBD.TraerSumaProveedores(fecharetrocedida);
                        lblSumaProveedor1.Text = "S.P = $" + suma1.ToString();
                        if (ConectarBD.TraerNetoExistenteDiaAnterior(fecharetrocedida) == 0)
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
                        double suma2 = ConectarBD.TraerSumaProveedores(fecharetrocedida);
                        lblSumaProveedor2.Text = "S.P = $" + suma2.ToString();
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
                        double suma3 = ConectarBD.TraerSumaProveedores(fecharetrocedida);
                        lblSumaProveedor3.Text = "S.P = $" + suma3.ToString();
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
                        double suma4 = ConectarBD.TraerSumaProveedores(fecharetrocedida);
                        lblSumaProveedor4.Text = "S.P = $" + suma4.ToString();
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


        private int indice = 0;
        private List<DateTime> dias = new List<DateTime>();
        private void CargarDiaEspecifico(string opcion)
        {
            string diaelegido = CboxElegirDia.SelectedItem.ToString();
            int dia = ObtenerDiaSemana(diaelegido);
            int ano = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            DateTime primerdiadelano = new DateTime(ano, 1, 1);
            DateTime ultimodiadelano = new DateTime(ano, mes, day);
            dias = ConectarBD.ConsultaDiasAnterioresDiasDelaSemana(dia, primerdiadelano, ultimodiadelano);
            for (int i = 0; i < 4; i++)
            {
                if(opcion == "A")
                {
                    indice++;
                }
                else if(opcion == "R")
                {
                    indice--;
                    
                }
                else
                {
                    
                }
                
                try
                {
                    DataTable dt = ConectarBD.DiasSemana(dias[dias.Count -indice]);
                    switch (i)
                    {
                        case 0:
                            dataGridView1.DataSource = dt;
                            string diaformateado1 = dias[dias.Count -indice].ToString("dddd, d 'de' MMMM 'de' yyyy");
                            label1.Text = diaformateado1;
                            double suma1 = ConectarBD.TraerSumaProveedores(dias[dias.Count -indice]);
                            lblSumaProveedor1.Text = "S.P = $" + suma1.ToString();
                            break;
                        case 1:
                            dataGridView2.DataSource = dt;
                            string diaformateado2 = dias[dias.Count -indice].ToString("dddd, d 'de' MMMM 'de' yyyy");
                            label2.Text = diaformateado2;
                            double suma2 = ConectarBD.TraerSumaProveedores(dias[dias.Count - indice]);
                            lblSumaProveedor1.Text = "S.P = $" + suma2.ToString();
                            break;
                        case 2:
                            dataGridView3.DataSource = dt;
                            string diaformateado3 = dias[dias.Count -indice].ToString("dddd, d 'de' MMMM 'de' yyyy");
                            label3.Text = diaformateado3;
                            double suma3 = ConectarBD.TraerSumaProveedores(dias[dias.Count - indice]);
                            lblSumaProveedor1.Text = "S.P = $" + suma3.ToString();
                            break;
                        case 3:
                            dataGridView4.DataSource = dt;
                            string diaformateado4 = dias[dias.Count - indice].ToString("dddd, d 'de' MMMM 'de' yyyy");
                            label4.Text = diaformateado4;
                            double suma4 = ConectarBD.TraerSumaProveedores(dias[dias.Count - indice]);
                            lblSumaProveedor1.Text = "S.P = $" + suma4.ToString();
                            break;

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"ERROR\n\n {e}");
                    BtnDiaAvansar.Enabled = false;
                    break;
                }
                
                
            }
        }

        private int ObtenerDiaSemana(string dia)
        {
            switch (dia)
            {
                case "Lunes":
                    return 1;
                case "Martes":
                    return 2;
                case "Miércoles":
                    return 3;
                case "Jueves":
                    return 4;
                case "Viernes":
                    return 5;
                case "Sábado":
                    return 6;
                case "Domingo":
                    return 7;
            }
            return 0;
        }

        private bool botonatras;
        private bool botonavanzar;
        private void BtnDiaAtras_Click(object sender, EventArgs e)
        {
            botonatras = true;
            BtnDiaAvansar.Enabled = true;
            //botonavanzar = false;
            if (checkBox1.Checked)
            {
                //if(indice - 4 >= 0)
                //{
                    if (botonavanzar)
                    {
                        //indice += 3;
                        CargarDiaEspecifico("A");
                    }
                    else
                    {
                        CargarDiaEspecifico("A");
                    }
                    
                    
                //}
                //else
                //{
                //    MessageBox.Show("Test1");
                //}
            }
            else
            {
                dias.Clear();
                fechaActual = fechaActual.AddDays(-4);
                CargarTablasDiasAtras();
            }
            
        }

        private void BtnDiaAvansar_Click(object sender, EventArgs e)
        {
            //botonatras = false;
            botonavanzar = true;
            if (checkBox1.Checked)
            {
                //if(indice + 4 < dias.Count)
                //{
                    if (botonatras)
                    {
                        //indice -= 3;
                        CargarDiaEspecifico("R");
                    }
                    else
                    {
                        CargarDiaEspecifico("R");
                    }
                    
                    
                //}
                //else
                //{
                //    MessageBox.Show("Test2");
                //}
            }
            else
            {
                dias.Clear();
                fechaActual = fechaActual.AddDays(4);
                CargarTablasDiasAtras();
            }
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
        //DateTime guardarfecha;
        private void BtnSacarCuentas1_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg1;
            logicaSacarCuentas(label1.Text, obtenerfecha);
            //DialogResult r = MessageBox.Show($"Alparecer en esta fecha {label1.Text} no se saco las cuentas diarias en las noches, desea hacerlos?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if(r == DialogResult.Yes)
            //{
            //    obtenerfecha = fechadtg1;//para sumar los proveedores de ese dia
            //    DateTime fechaanterior = obtenerfecha.AddDays(-1);//para obtener el neto existente del dia anterior al dia que se cunsulta para poder restarlo.
            //    LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
            //}
            //else
            //{

            //}
        }

        private void logicaSacarCuentas(string labelfecha, DateTime fecha)
        {
            DialogResult r = MessageBox.Show($"Alparecer en esta fecha {labelfecha} no se saco las cuentas diarias en las noches, desea hacerlos?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r == DialogResult.Yes)
            {
                obtenerfecha = fecha;//para sumar los proveedores de ese dia
                DateTime fechaanterior = obtenerfecha.AddDays(-1);//para obtener el neto existente del dia anterior al dia que se cunsulta para poder restarlo.
                DialogResult resp = MessageBox.Show($"En esta fecha {labelfecha} agrego dinero de ahorro casa o de limones?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(resp == DialogResult.Yes)
                {
                    AgregarDineroAL agregar = new AgregarDineroAL();
                    if(agregar.ShowDialog() == DialogResult.OK)
                    {
                        int dinero = agregar.ObtenerDinero();
                        LogicaParaCalcularGuardar(obtenerfecha, fechaanterior, dinero);
                    }
                }
                else
                {
                    LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
                }
            }
            else
            {

            }
        }

        private void LogicaParaCalcularGuardar(DateTime fechaSumarProveedor, DateTime fechaObtenerNEanterior, int AhorroOlimones = 0)
        {
            double SumaProveedoresFechaPersonalizada = ConectarBD.SumarTodosLosProveedoresFechaActual(fechaSumarProveedor);
            double NEfechaPersonalizada = ConectarBD.VerificarDineroAgarradoDiaAnterior(fechaObtenerNEanterior);
            double resultado = (NEfechaPersonalizada + AhorroOlimones) - SumaProveedoresFechaPersonalizada;
            string re = resultado.ToString("N2");
            guardarFechaPersonalizada(fechaSumarProveedor);
            DialogResult respuesta = MessageBox.Show($"El resultado de la resta de N.E(${NEfechaPersonalizada}) de la fecha {fechaObtenerNEanterior} con la suma de ${AhorroOlimones}(A.C o L.) y la suma de todos los proveedores(${SumaProveedoresFechaPersonalizada}) de la fecha {obtenerfecha} es ${re}.\nEsta de acuerdo con el resultado?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                    CuentasDiarias cuentas = new CuentasDiarias(0,"Si");
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
            logicaSacarCuentas(label2.Text, obtenerfecha);
            //DialogResult r = MessageBox.Show($"Alparecer en esta fecha {label2.Text} no se saco las cuentas diarias en las noches, desea hacerlos?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if(r == DialogResult.Yes)
            //{
            //    obtenerfecha = fechadtg2;
            //    DateTime fechaanterior = obtenerfecha.AddDays(-1);
            //    LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
            //}
            //else
            //{

            //}
            
        }

        private void BtnSacarCuentas3_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg3;
            logicaSacarCuentas(label3.Text, obtenerfecha);
            //DialogResult r = MessageBox.Show($"Alparecer en esta fecha {label3.Text} no se saco las cuentas diarias en las noches, desea hacerlos?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if(r == DialogResult.Yes)
            //{
            //    obtenerfecha = fechadtg3;
            //    DateTime fechaanterior = obtenerfecha.AddDays(-1);
            //    LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
            //}
            //else
            //{

            //}
            
        }

        private void BtnSacarCuentas4_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg4;
            logicaSacarCuentas(label4.Text, obtenerfecha);
            //DialogResult r = MessageBox.Show($"Alparecer en esta fecha {label4.Text} no se saco las cuentas diarias en las noches, desea hacerlos?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if(r == DialogResult.Yes)
            //{
            //    obtenerfecha = fechadtg4;
            //    DateTime fechaanterior = obtenerfecha.AddDays(-1);
            //    LogicaParaCalcularGuardar(obtenerfecha, fechaanterior);
            //}
            //else
            //{

            //}
            
        }

        public DateTime ObtenerFechaAguardar()//con este metodo obtendremos la fecha guardada.
        {
            DateTime obtenerfecha = Properties.Settings.Default.FechaPersonalizadaGuardar;
            return obtenerfecha;
        }

        public void guardarFechaPersonalizada(DateTime fechaAguardar)//con este metodo guardaremos la fecha que se quiere guardar.
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

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            CargarDiaEspecifico("A");
            BtnDiaAvansar.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                CboxElegirDia.Visible = true;
                BtnConsultar.Visible = true;
            }
            else
            {
                CboxElegirDia.Visible = false;
                BtnConsultar.Visible = false;
                indice = 0;
                CargarTablasDiasAtras();
            }
        }
    }
}
