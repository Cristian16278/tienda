using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tienda
{
    public partial class ConsultaDiasAnteriores : Form
    {
        ConectarBD ConectarBD = new ConectarBD();
        CultureInfo cultura = new CultureInfo("en-ES");


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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == data.Columns["Visualizar imagen"].Index)
                {
                    int indice = e.RowIndex;
                    int proveedorID = (int)data.Rows[indice].Cells["ProveedorID"].Value;
                    int registroDC = (int)data.Rows[indice].Cells["ProveedorDiaID"].Value;
                    var (Proveedorexiste, rutaimagen) = ConectarBD.VerificarImagenEnProveedor(fechadtgEspecifico, proveedorID, registroDC);//aqui falta poner la fecha dependiendo el dia que sea en el datagridview
                    if (Proveedorexiste == proveedorID)
                    {
                        Previsualisacion_imagen imagen = new Previsualisacion_imagen(rutaimagen, "si");
                        DialogResult respuesta = imagen.ShowDialog();
                        if (respuesta == DialogResult.OK)
                        {
                            string obtenernuevaruta = imagen.ObtenerNuevaRuta();
                            byte[] bytesguardarimagen = File.ReadAllBytes(obtenernuevaruta);
                            ConectarBD.GuardarImagenProveedor(proveedorID, fechadtgEspecifico, bytesguardarimagen, registroDC);
                            data.DataSource = ConectarBD.CargarTablaDiasCompra(fechadtgEspecifico);
                            MessageBox.Show("Se modifico correctamente la imagen", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (respuesta == DialogResult.Yes)
                        {

                        }
                        else if (respuesta == DialogResult.Abort)
                        {
                            MessageBox.Show("No se hara ningun cambio", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        DialogResult respuesta = MessageBox.Show("No se encontro ninguga imagen, desea agregar una?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (respuesta == DialogResult.Yes)
                        {
                            if (OfdElegirImagen.ShowDialog() == DialogResult.OK)
                            {
                                string imagen = OfdElegirImagen.FileName;
                                byte[] rutaimagengua = File.ReadAllBytes(imagen);
                                Previsualisacion_imagen previsualisacion = new Previsualisacion_imagen(rutaimagengua, "no");
                                DialogResult respuesta2 = previsualisacion.ShowDialog();
                                if (respuesta2 == DialogResult.OK)
                                {
                                    int indice1 = e.RowIndex;
                                    int proveedorID1 = (int)data.Rows[indice1].Cells["ProveedorID"].Value;
                                    ConectarBD.GuardarImagenProveedor(proveedorID1, fechadtgEspecifico, rutaimagengua, registroDC);
                                    data.DataSource = ConectarBD.CargarTablaDiasCompra(fechadtgEspecifico);
                                    //dtgDiasCompra.Columns["ProveedorID"].Visible = false;
                                    MessageBox.Show("Se guardo correctamente la imagen","Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    
                                }
                                else if (respuesta2 == DialogResult.Yes)
                                {

                                }
                                else if (respuesta2 == DialogResult.Abort)
                                {
                                    MessageBox.Show("No se hara ningun cambio","Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {

                            }
                        }
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

        private void MetodoCargarDtgvLabels(DataTable dt, DateTime fecharetrocedida, Label lblSumaProveedor, Label label, Button BtnSacarcuentas, DataGridView dataGridView)
        {
            dataGridView.DataSource = dt;
            string fechaFormateada = fecharetrocedida.ToString("dddd, d 'de' MMMM 'de' yyyy");
            label.Text = fechaFormateada;
            //fechadtg1 = fecharetrocedida;
            double suma1 = ConectarBD.TraerSumaProveedores(fecharetrocedida);
            lblSumaProveedor.Text = "S.P = $" + suma1.ToString("#,##0.##", cultura);
            if (ConectarBD.TraerNetoExistenteDiaAnterior(fecharetrocedida) == 0)
            {
                BtnSacarcuentas.Enabled = true;
                BtnSacarcuentas.Visible = true;
            }
            else
            {
                BtnSacarcuentas.Enabled = false;
                BtnSacarcuentas.Visible = false;
            }
        }

        private void CargarTablasDiasAtras()
        {
            for(int i = 0; i < 4; i++)
            {
                DateTime fecharetrocedida = fechaActual.AddDays(-i);
                DataTable dt = ConectarBD.CargarTablaDiasCompra(fecharetrocedida);
                switch (i)
                {
                    case 0:
                        MetodoCargarDtgvLabels(dt, fecharetrocedida, lblSumaProveedor1, label1, BtnSacarCuentas1, dataGridView1);
                        fechadtg1 = fecharetrocedida;
                        break;
                    case 1:
                        MetodoCargarDtgvLabels(dt, fecharetrocedida, lblSumaProveedor2, label2, BtnSacarCuentas2, dataGridView2);
                        fechadtg2 = fecharetrocedida;
                        break;
                    case 2:
                        MetodoCargarDtgvLabels(dt, fecharetrocedida, lblSumaProveedor3, label3, BtnSacarCuentas3, dataGridView3);
                        fechadtg3 = fecharetrocedida;
                        break;
                    case 3:
                        MetodoCargarDtgvLabels(dt, fecharetrocedida, lblSumaProveedor4, label4, BtnSacarCuentas4,dataGridView4);
                        fechadtg4 = fecharetrocedida;
                        break;
                }
            }
        }


        private int indice = 0;
        private List<DateTime> dias = new List<DateTime>();
        private void CargarDiaEspecifico(string opcion)
        {
            try
            {
                string diaelegido = CboxElegirDia.SelectedItem.ToString();
                int dia = ObtenerDiaSemana(diaelegido);
                int ano = DateTime.Now.Year;
                int mes = DateTime.Now.Month;
                int day = DateTime.Now.Day;
                DateTime primerdiadelano = new DateTime(2023, 1, 1);
                DateTime ultimodiadelano = new DateTime(2050, 12, 31);
                if (dias.Count == 0)//si la lista esta vacia
                {
                    //traeme los dias especificado
                    dias = ConectarBD.ConsultaDiasAnterioresDiasDelaSemana(dia, primerdiadelano, ultimodiadelano);
                }
                else//sino
                {
                    //no me agas nada
                }
                for (int i = 0; i < 4; i++)
                {
                    if (opcion == "A")
                    {
                        indice++;
                    }
                    else if (opcion == "R")
                    {
                        indice--;

                    }
                    else
                    {

                    }

                    DataTable dt = ConectarBD.DiasSemana(dias[dias.Count - indice]);
                    switch (i)
                    {
                        case 0:
                            dataGridView1.DataSource = dt;
                            string diaformateado1 = dias[dias.Count - indice].ToString("dddd, d 'de' MMMM 'de' yyyy");
                            label1.Text = diaformateado1;
                            double suma1 = ConectarBD.TraerSumaProveedores(dias[dias.Count - indice]);
                            lblSumaProveedor1.Text = "S.P = $" + suma1.ToString("#,##0.##", cultura);
                            break;
                        case 1:
                            dataGridView2.DataSource = dt;
                            string diaformateado2 = dias[dias.Count - indice].ToString("dddd, d 'de' MMMM 'de' yyyy");
                            label2.Text = diaformateado2;
                            double suma2 = ConectarBD.TraerSumaProveedores(dias[dias.Count - indice]);
                            lblSumaProveedor2.Text = "S.P = $" + suma2.ToString("#,##0.##", cultura);
                            break;
                        case 2:
                            dataGridView3.DataSource = dt;
                            string diaformateado3 = dias[dias.Count - indice].ToString("dddd, d 'de' MMMM 'de' yyyy");
                            label3.Text = diaformateado3;
                            double suma3 = ConectarBD.TraerSumaProveedores(dias[dias.Count - indice]);
                            lblSumaProveedor3.Text = "S.P = $" + suma3.ToString("#,##0.##", cultura);
                            break;
                        case 3:
                            dataGridView4.DataSource = dt;
                            string diaformateado4 = dias[dias.Count - indice].ToString("dddd, d 'de' MMMM 'de' yyyy");
                            label4.Text = diaformateado4;
                            double suma4 = ConectarBD.TraerSumaProveedores(dias[dias.Count - indice]);
                            lblSumaProveedor4.Text = "S.P = $" + suma4.ToString("#,##0.##", cultura);
                            break;

                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show($"ocurrio un error:\n{es}");
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
                if(dias.Count == 0)
                {

                }
                else
                {
                    dias.Clear();
                }
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
                if (dias.Count == 0)
                {

                }
                else
                {
                    dias.Clear();
                }
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
            string re = resultado.ToString("#,##0.##", cultura);
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
            
            
        }

        private void BtnSacarCuentas3_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg3;
            logicaSacarCuentas(label3.Text, obtenerfecha);
            
            
        }

        private void BtnSacarCuentas4_Click(object sender, EventArgs e)
        {
            obtenerfecha = fechadtg4;
            logicaSacarCuentas(label4.Text, obtenerfecha);
            
            
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
            if(dias.Count == 0)
            {
                CargarDiaEspecifico("A");
                BtnDiaAvansar.Enabled = false;
            }
            else
            {
                dias.Clear();
                CargarDiaEspecifico("A");
                BtnDiaAvansar.Enabled = false;
            }
            
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

        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarProveedor.Text))
            {
                dataGridViewProveedores.DataSource = ConectarBD.BuscarProveedorTablaDiasCompra("$");
            }
            else
            {
                dataGridViewProveedores.DataSource = ConectarBD.BuscarProveedorTablaDiasCompra(txtBuscarProveedor.Text);
                CargartablaBuscarProveedoresEspecifico();
                contador++;
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == TpBuscar)
            {
                
            }
            else
            {

            }
        }

        int contador = 0;

        private void CargartablaBuscarProveedoresEspecifico()
        {
            //dataGridViewProveedores.DataSource = ConectarBD.BuscarProveedorTablaDiasCompra("");
            dataGridViewProveedores.Columns["ProveedorID"].Visible = false;
            dataGridViewProveedores.Columns["ProveedorDiaID"].Visible = false;
            //dataGridViewProveedores.CellClick += VisualizarImagen_CellClick;
            //se utilizara otro metodo para visualizar la imagen
            if(contador == 0)
            {
                AgregarBotonAlaTabla(dataGridViewProveedores);
            }
        }

        private void dataGridViewProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == dataGridViewProveedores.Columns["Visualizar imagen"].Index)
                {
                    int indice = e.RowIndex;
                    int proveedorID = (int)dataGridViewProveedores.Rows[indice].Cells["ProveedorID"].Value;
                    int registroDC = (int)dataGridViewProveedores.Rows[indice].Cells["ProveedorDiaID"].Value;
                    DateTime obtenerfecha = Convert.ToDateTime(dataGridViewProveedores.Rows[indice].Cells["Fecha"].Value);
                    var (Proveedorexiste, rutaimagen) = ConectarBD.VerificarImagenEnProveedor(obtenerfecha, proveedorID, registroDC);//aqui falta poner la fecha dependiendo el dia que sea en el datagridview
                    if (Proveedorexiste == proveedorID)
                    {
                        Previsualisacion_imagen imagen = new Previsualisacion_imagen(rutaimagen, "si");
                        if (imagen.ShowDialog() == DialogResult.OK)
                        {
                            //MessageBox.Show("se guardara la nueva ruta");
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
                        MessageBox.Show("No se encontro ninguga imagen", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
