using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Net.Mime.MediaTypeNames;

namespace tienda
{
    public partial class Provedores : Form
    {
        public Provedores()
        {
            InitializeComponent();
            timer1.Interval = 10000;
        }
        ConectarBD conectar =  new ConectarBD();

        private void Provedores_Load(object sender, EventArgs e)
        {
            try
            {
                DayOfWeek dia = DateTime.Now.DayOfWeek;
                DateTime horaactual = DateTime.Now;
                if (dia == DayOfWeek.Sunday)//si hoy es domingo
                {
                    if (horaactual.Hour >= 17 && horaactual.Minute >= 0)//y la hora es mas de las 17:00 horas(5:00 PM)
                    {
                        CboxAccionRealizar.SelectedItem = "Sumar todo";//Seleccioname el 'Sumar todo' del combobox
                        MetodoParaEventoLoadDelForm();
                        CboxElegirAhorroOcomplemento.SelectedItem = "Sel..";
                    }
                    else
                    {    //en caso contrario
                        CboxAccionRealizar.SelectedItem = "Modificar";//seleccioname el 'Modificar' del combobox
                        MetodoParaEventoLoadDelForm();
                        CboxElegirAhorroOcomplemento.SelectedItem = "Sel..";
                    }
                }
                else//en caso contrario es otro dia
                {
                    if (horaactual.Hour >= 22 && horaactual.Minute >= 0)//y la hora es mas de las 22:00 horas(10:00 PM)
                    {
                        CboxAccionRealizar.SelectedItem = "Sumar todo";//Seleccioname el 'Sumar todo' del combobox 
                        MetodoParaEventoLoadDelForm();
                        CboxElegirAhorroOcomplemento.SelectedItem = "Sel..";
                    }
                    else//en caso contrario
                    {
                        CboxAccionRealizar.SelectedItem = "Modificar";//Seleccioname el 'Modificar' del Combobox
                        MetodoParaEventoLoadDelForm();
                        CboxElegirAhorroOcomplemento.SelectedItem = "Sel..";

                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar cargar el form.\ntipo de error:\n{ex}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MetodoParaEventoLoadDelForm()
        {
            //dtgDiasCompra.ClearSelection();
            string diaActual = DateTime.Now.ToString("dddd");
            lblFechaActual.Text = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy");
            DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
            string DiaActual = conectar.ObtenerDiaActual(diaActual);
            RefrescarFormululario(DiaActual, date);
            dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
            AgregarBotonAlaFila();
            dtgDiasCompra.ClearSelection();
            borrarContenidoTextbox();
            //verificar si se agarro dinero
            DateTime fechaActual1 = DateTime.Now.Date;//esto lo utilizaremos cuando de la hora para el dia de manana
            DateTime fechaAnterior = fechaActual1.AddDays(-1);
            int MostrarEnTextbox = conectar.VerificarDineroAgarradoDiaAnterior(fechaAnterior);
            txtPresupuesto.Text = MostrarEnTextbox.ToString();
            llenarComboboxSinFechaFijo();
            LlenarComboboxProveedorAdelanto();
            //dtgDiasCompra.ClearSelection();
        }

        private List<int> VerificarProveedorEspecifico(List<int> obtenerProveedorDeTablaProveedores, List<int> proveedoresDiascompra, DateTime dia)
        {
            try
            {
                List<int> nuevosproveedores = new List<int>();
                //List<int> proveedoresDiascompra = conectar.ObtenerProveedorIDDeDiasCompra(dia);
                //List<int> nuevoovacio = CompararListas(obtenerProveedorDeTablaProveedores, proveedoresDiascompra);
                if (obtenerProveedorDeTablaProveedores.Count > proveedoresDiascompra.Count)
                {
                    // Si Numeros es más largo, agregar sus elementos a la NuevaLista
                    foreach (int numero in obtenerProveedorDeTablaProveedores)
                    {
                        if (!proveedoresDiascompra.Contains(numero))
                        {
                            nuevosproveedores.Add(numero);
                        }
                    }
                    return nuevosproveedores;
                }
                return null;
            }
            catch (Exception f)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{f}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool CompararListas(List<int> lista1, List<int> lista2)//este metodo no lo utilizo
        {
            try
            {
                if (lista1.Count != lista2.Count || (lista1.Count == 0 && lista2.Count == 0))
                {
                    return false;
                }

                foreach (int numero in lista1)
                {
                    if (!lista2.Contains(numero))
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception d)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{d}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void AgregarBotonAlaFila()
        {
            try
            {
                DataGridViewButtonColumn botonAgregarimagen = new DataGridViewButtonColumn();
                botonAgregarimagen.Name = "Agregar Imagen";
                botonAgregarimagen.Text = "Agregar imagen";
                botonAgregarimagen.UseColumnTextForButtonValue = true;
                dtgDiasCompra.Columns.Add(botonAgregarimagen);
            }
            catch(Exception p)
            {
                MessageBox.Show($"Ocurrio un error al intentar agregar la fila de botones\ntipo de error:\n{p}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //para abrir los forms
        private AgregarProveedores agregarProveedores = null;
        private ConsultaDiasAnteriores consultaDiasAnteriores = null;


        private void agregarProveedorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (agregarProveedores == null || agregarProveedores.IsDisposed)
                {
                    agregarProveedores = new AgregarProveedores();
                    agregarProveedores.Show();
                }
                else
                {
                    agregarProveedores.Activate();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show($"No se pudo abrir el form\ntipo de error:{f}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void consultarDiasAtrasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (consultaDiasAnteriores == null || consultaDiasAnteriores.IsDisposed)
                {
                    consultaDiasAnteriores = new ConsultaDiasAnteriores();
                    consultaDiasAnteriores.Show();
                }
                else
                {
                    consultaDiasAnteriores.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo abrir el form\ntipo de error:\n{ex}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int proveedorID;
        int registroDC;
        private void dtgDiasCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0 && e.ColumnIndex >= 0)//si se dio click en una celda valida(que no sean los encabezados)
                {
                    DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
                    if (e.ColumnIndex == dtgDiasCompra.Columns["Agregar Imagen"].Index)
                    {
                        //OfdElegirImagen.InitialDirectory = "";
                        OfdElegirImagen.Title = "Seleccione una imagen";
                        OfdElegirImagen.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png";
                        int indice = e.RowIndex;
                        int proveedorID = (int)dtgDiasCompra.Rows[indice].Cells["ProveedorID"].Value;
                        int registroDC = (int)dtgDiasCompra.Rows[indice].Cells["ProveedorDiaID"].Value;
                        var (Proveedorexiste, rutaimagen) = conectar.VerificarImagenEnProveedor(date, proveedorID, registroDC);
                        if (Proveedorexiste == proveedorID)
                        {
                            Previsualisacion_imagen previsualisacion = new Previsualisacion_imagen(rutaimagen, "si");
                            if (previsualisacion.ShowDialog() == DialogResult.OK)
                            {
                                string obtenernuevaruta = previsualisacion.ObtenerNuevaRuta();
                                byte[] bytesguardarimagen = File.ReadAllBytes(obtenernuevaruta);
                                conectar.GuardarImagenProveedor(proveedorID, date, bytesguardarimagen, registroDC);
                                dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                                EnviarMensaje("Se cambio la imagen correctamente.", false);
                            }
                            else
                            {
                                EnviarMensaje("No se cambio la imagen.", true);
                            }
                        }
                        else
                        {
                            if (OfdElegirImagen.ShowDialog() == DialogResult.OK)
                            {
                                string imagen = OfdElegirImagen.FileName;
                                byte[] rutaimagengua = File.ReadAllBytes(imagen);
                                Previsualisacion_imagen previsualisacion = new Previsualisacion_imagen(rutaimagengua, "no");
                                if (previsualisacion.ShowDialog() == DialogResult.OK)
                                {
                                    int indice1 = e.RowIndex;
                                    int proveedorID1 = (int)dtgDiasCompra.Rows[indice1].Cells["ProveedorID"].Value;
                                    conectar.GuardarImagenProveedor(proveedorID1, date, rutaimagengua, registroDC);
                                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                                    //dtgDiasCompra.Columns["ProveedorID"].Visible = false;
                                    EnviarMensaje("Se guardo correctamente la imagen", false);
                                }
                                else
                                {
                                    EnviarMensaje("No se guardara la imagen.", true);
                                }
                            }
                        }
                    }
                    else if (e.ColumnIndex == dtgDiasCompra.Columns["Compra"].Index || e.ColumnIndex == dtgDiasCompra.Columns["Proveedor"].Index || e.ColumnIndex == dtgDiasCompra.Columns["Comentario"].Index)
                    {
                        int indice = e.RowIndex;
                        proveedorID = (int)dtgDiasCompra.Rows[indice].Cells["ProveedorID"].Value;
                        registroDC = (int)dtgDiasCompra.Rows[indice].Cells["ProveedorDiaID"].Value;
                    }
                }
                else
                {

                }
                
            }
            catch (Exception f)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{f}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void borrarContenidoTextbox()
        {
            txtCompra.Text = "";
            txtProveedor.Text = "";
            proveedorID = 0;
        }

        private void dtgDiasCompra_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgDiasCompra.SelectedCells.Count > 0)
                {
                    int seleccionarcampo = dtgDiasCompra.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dtgDiasCompra.Rows[seleccionarcampo];

                    txtCompra.Text = row.Cells["Compra"].Value.ToString().Replace(",",".");
                    txtProveedor.Text = row.Cells["Proveedor"].Value.ToString();
                    string comentario = row.Cells["Comentario"].Value.ToString();
                    if (string.IsNullOrEmpty(comentario))
                    {
                        txtAgregarComentario.Text = "Agrege un Comentario";
                        txtAgregarComentario.ForeColor = Color.Gray;
                    }
                    else
                    {
                        txtAgregarComentario.Text = comentario;
                        txtAgregarComentario.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{a}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPresupuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Se preciono la tecla enter");
            }
        }

        private void BtnRefrescarTabla_Click(object sender, EventArgs e)
        {
            string diaActual = DateTime.Now.ToString("dddd");
            DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
            string DiaActual = conectar.ObtenerDiaActual(diaActual);
            RefrescarFormululario(DiaActual, date);
            dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
            dtgDiasCompra.ClearSelection();
            borrarContenidoTextbox();
            llenarComboboxSinFechaFijo();
            LlenarComboboxProveedorAdelanto();
        }

        private void RefrescarFormululario(string DiaActual, DateTime FechaActual)
        {
            try
            {
                List<int> proveedoresDiascompra = conectar.ObtenerProveedorIDDeDiasCompra(FechaActual);//para comparar las listas
                List<int> ProveedoresID = conectar.ObtenerIDproveedoresEnTablaProveedores(DiaActual);
                List<int> nuevoproveedores = VerificarProveedorEspecifico(ProveedoresID, proveedoresDiascompra, FechaActual);
                if (ProveedoresID.Count > proveedoresDiascompra.Count)
                {
                    //si le hace falta ala tabla diascompra, que me agrege lo que falta y me lo recarge
                    conectar.llenarTablaDiasCompra(nuevoproveedores, FechaActual);
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    //dtgDiasCompra.ClearSelection();
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                    dtgDiasCompra.Columns["ProveedorDiaID"].Visible = false;
                }
                else if (conectar.ConsultaProveedorExisteFechaHoy(FechaActual) >= 1)
                {
                    //si ya existen proveedores con la fecha actual que solo me recarge la tabla.
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    //dtgDiasCompra.ClearSelection();
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                    dtgDiasCompra.Columns["ProveedorDiaID"].Visible = false;
                }
                else
                {
                    //si es un nuevo dia que me agrege todos lo proveedores que pasan en el dia actual
                    conectar.llenarTablaDiasCompra(ProveedoresID, FechaActual);
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    //dtgDiasCompra.ClearSelection();
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                    dtgDiasCompra.Columns["ProveedorDiaID"].Visible = false;
                    //AgregarBotonAlaFila();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{ex}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void llenarComboboxSinFechaFijo()
        {
            CboxProveedoresSinFechaFijo.DataSource = conectar.CargarCboxProveedorSinFechaFijo();
            CboxProveedoresSinFechaFijo.DisplayMember = "NombreProveedor";
            CboxProveedoresSinFechaFijo.ValueMember = "ProveedorID";
        }

        private void LlenarComboboxProveedorAdelanto()
        {
            CboxProveedorAdelantado.DataSource = conectar.CargarCboxProveedorAdelanto();
            CboxProveedorAdelantado.DisplayMember = "NombreProveedor";
            CboxProveedorAdelantado.ValueMember = "ProveedorID";
        }

        private void CboxAccionRealizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime horaactual = DateTime.Now;
            DayOfWeek dia = DateTime.Now.DayOfWeek;
            //MessageBox.Show($"Test{dia}");
            string elegiraccion = CboxAccionRealizar.SelectedItem.ToString();
            if (elegiraccion == "Agregar proveedor")
            {
                BtnGuardar.Text = "Agregar";
                lblCompra.Text = "Compra:";
                txtCompra.Text = "";
                txtAgregarComentario.Text = "Agrege un Comentario";
                txtAgregarComentario.ForeColor = Color.DarkGray;
                //lblProveedor.Text = "Proveedor e agregar:";
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click += BtnAgregar_Click;
                BtnGuardar.Click -= BtnBorrar_Click;
                BtnGuardar.Click -= BtnGuardar_Click;
                BtnGuardar.Click -= BtnSumarTodo_Click;
                dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                BtnGuardar.BackColor = Color.Green;
                BtnGuardar.ForeColor = Color.White;
                //CboxProveedoresSinFechaFijo.Visible = true;
                txtProveedor.Visible = false;
                txtProveedor.BackColor = Color.Silver;
                //CboxProveedorAdelantado.Visible = true;
                RdbProveedorSFechaFijo.Visible = true;
                RdbProveedorAdelanto.Visible = true;
                txtAgregarComentario.Visible = true;
                txtProveedorEspecifico.Visible = true;
                txtProveedorEspecifico.Enabled = true;
                QuitarCheckedRadiobutton(true, false);
                llenarComboboxSinFechaFijo();
                LlenarComboboxProveedorAdelanto();
                
                //nesesitaremos el ProveedorID donde DiaVisita sea igual a 'Sin dia fijo',
                //la fecha y la compra sera opcional
            }
            else if(elegiraccion == "Borrar")
            {
                BtnGuardar.Text = "Borrar";
                lblProveedor.Text = "Proveedor a eliminar:";
                lblCompra.Text = "Compra:";
                txtCompra.Text = "";
                txtAgregarComentario.Text = "";
                BtnGuardar.Click -= BtnBorrar_Click;
                BtnGuardar.Click += BtnBorrar_Click;
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click -= BtnGuardar_Click;
                BtnGuardar.Click -= BtnSumarTodo_Click;
                dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                BtnGuardar.BackColor = Color.Red;
                BtnGuardar.ForeColor = Color.White;
                CboxProveedoresSinFechaFijo.Visible = false;
                txtProveedor.Enabled = false;
                txtProveedor.Visible = true;
                txtAgregarComentario.Visible = true;
                txtProveedor.BackColor = Color.Silver;
                CboxProveedorAdelantado.Visible = false;
                RdbProveedorSFechaFijo.Visible = false;
                RdbProveedorAdelanto.Visible = false;
                txtProveedorEspecifico.Visible = false;
                txtProveedorEspecifico.Enabled = false;
                QuitarCheckedRadiobutton(false, false);
                //nesesitaremos el ProveedorID y la fecha
            }
            else if (elegiraccion == "Sumar todo")
            {
                if(dia == DayOfWeek.Sunday)//para domingo
                {
                    if (horaactual.Hour >= 17 && horaactual.Minute >= 0)// solo se podra hacer la suma asta las 5:00pm
                    {
                        lblProveedor.Visible = false;
                        txtProveedor.Visible = false;
                        CboxProveedoresSinFechaFijo.Visible = false;
                        CboxProveedorAdelantado.Visible = false;
                        RdbProveedorAdelanto.Visible = false;
                        RdbProveedorSFechaFijo.Visible = false;
                        txtAgregarComentario.Visible = false;
                        txtProveedorEspecifico.Visible = false;
                        txtProveedorEspecifico.Enabled = false;
                        lblCompra.Text = "Resultado:";
                        BtnGuardar.Click -= BtnSumarTodo_Click;
                        BtnGuardar.Click += BtnSumarTodo_Click;
                        BtnGuardar.Click -= BtnAgregar_Click;
                        BtnGuardar.Click -= BtnGuardar_Click;
                        BtnGuardar.Click -= BtnBorrar_Click;
                        dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                        BtnGuardar.Text = "Sumar";
                        txtCompra.Text = "";
                        BtnGuardar.BackColor = Color.Yellow;
                        BtnGuardar.ForeColor = Color.Black;
                    }
                    else
                    {
                        MessageBox.Show("Solo se podra sumar los proveedores alas \n17:00 horas(5:00 PM).", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CboxAccionRealizar.SelectedItem = "Modificar";
                    }
                }
                else//para los demas dias
                {
                    if (horaactual.Hour >= 22 && horaactual.Minute >= 0)//solo se podra hacer la suma asta las 10:00 pm
                    {
                        //MessageBox.Show("Se activaran los botones");
                        lblProveedor.Visible = false;
                        txtProveedor.Visible = false;
                        CboxProveedoresSinFechaFijo.Visible = false;
                        CboxProveedorAdelantado.Visible = false;
                        RdbProveedorAdelanto.Visible = false;
                        RdbProveedorSFechaFijo.Visible = false;
                        txtAgregarComentario.Visible = false;
                        txtProveedorEspecifico.Visible = false;
                        txtProveedorEspecifico.Enabled = false;
                        lblCompra.Text = "Resultado:";
                        txtCompra.Text = "";
                        BtnGuardar.Click -= BtnSumarTodo_Click;
                        BtnGuardar.Click += BtnSumarTodo_Click;
                        BtnGuardar.Click -= BtnAgregar_Click;
                        BtnGuardar.Click -= BtnGuardar_Click;
                        BtnGuardar.Click -= BtnBorrar_Click;
                        dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                        BtnGuardar.Text = "Sumar";
                        BtnGuardar.BackColor = Color.Yellow;
                        BtnGuardar.ForeColor = Color.Black;
                    }
                    else
                    {
                        MessageBox.Show("Solo se podra sumar los proveedores alas \n22:00 horas(10:00 PM).", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CboxAccionRealizar.SelectedItem = "Modificar";
                    }
                }
                
                //aqui se activaran los componentes que bayan a servir para sumar los datos de cada proveedor
            }
            else
            {
                BtnGuardar.Text = "Guardar cambios";
                lblProveedor.Text = "Proveedor a modificar:";
                lblCompra.Text = "Compra:";
                txtCompra.Text = "";
                txtAgregarComentario.Text = "Agrege un Comentario";
                txtAgregarComentario.ForeColor = Color.DarkGray;
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click -= BtnBorrar_Click;
                BtnGuardar.Click -= BtnSumarTodo_Click;
                BtnGuardar.Click -= BtnGuardar_Click;
                BtnGuardar.Click += BtnGuardar_Click;
                dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                BtnGuardar.BackColor = Color.Silver;
                BtnGuardar.ForeColor = Color.Black;
                CboxProveedoresSinFechaFijo.Visible = false;
                txtProveedor.Visible = true;
                txtProveedor.Enabled = false;
                txtProveedor.BackColor = Color.Silver;
                txtAgregarComentario.Visible = true;
                CboxProveedorAdelantado.Visible = false;
                RdbProveedorSFechaFijo.Visible = false;
                RdbProveedorAdelanto.Visible = false;
                txtProveedorEspecifico.Visible = false;
                txtProveedorEspecifico.Enabled = false;
                QuitarCheckedRadiobutton(false, false);
                //nesecitaremos el ProveedroID, la compra y la fecha
            }
        }

        private void BtnSumarTodo_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("No hace falta ningun proveedor?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.No)
            {
                dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                double resultado = conectar.SumarTodosLosProveedoresFechaActual(FechaActual);
                txtCompra.Text = resultado.ToString();
                double ne = Convert.ToDouble(txtPresupuesto.Text);
                double decasa = Convert.ToDouble(txtAhorroCasaOcomplemento.Text);
                double restar = (ne + decasa) - resultado;
                string result = restar.ToString("N2");
                string elegido = CboxElegirAhorroOcomplemento.SelectedItem.ToString();
                MessageBox.Show($"el resultado de la resta de (T.E: ${ne} + {elegido}: ${decasa}) - {resultado} = {result}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(restar < 0)//si el resultado de la resta de tara existente y la suma de los proveedores da un numero negativo -1
                {
                    VerificarSiEsNumeroNegativo(restar);
                    double numeronegativo = Math.Abs(restar);
                    double numeroredondeado = Math.Round(numeronegativo);
                    Properties.Settings.Default.Delacaja = numeroredondeado;
                    Properties.Settings.Default.Save();
                    CuentasDiarias cuentasDiarias = new CuentasDiarias(numeroredondeado);
                    this.Hide();
                    if(cuentasDiarias.ShowDialog() == DialogResult.Cancel)
                    {
                        Application.Exit();//hicieron todos los calculos y lo cerraron
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio algo desde el form cuentas diarias");
                    }
                }
                else//en caso contrario se almacenara para preguntar despues si desean agregarlo o no
                {
                    VerificarSiEsNumeroNegativo(restar);
                    double redondear = Math.Round(restar);
                    Properties.Settings.Default.Delacaja = redondear;
                    Properties.Settings.Default.Save();
                    CuentasDiarias cuentas = new CuentasDiarias();
                    this.Hide();
                    if(cuentas.ShowDialog() == DialogResult.Cancel)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio algo desde el form cuentas diarias");
                    }
                }
            }
            else
            {

            }
        }

        private void VerificarSiEsNumeroNegativo(double restar)
        {
            Properties.Settings.Default.NumeroNegativoOno = restar;
            Properties.Settings.Default.Save();
        }

        DateTime FechaActual = DateTime.Now.Date;

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                txtProveedor.Text = "";
                //se cambiaran los datos
                //se descomentara despues < -----------------------------------------------------------------------------------
                DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
                int obtenerindiceProveedorID = proveedorID;
                int obtenerRegistroDC = registroDC;
                double compra = double.Parse(txtCompra.Text.Replace(".",","));
                string comentario = txtAgregarComentario.Text;
                if(comentario == "Agrege un Comentario")
                {
                    comentario = "";
                }
                int resultado = conectar.AgregarCompraTablaDiasCompra(obtenerindiceProveedorID, date, compra, obtenerRegistroDC, comentario);
                if(resultado > 0)
                {
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                    dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                    borrarContenidoTextbox();
                    EnviarMensaje("Se guardaron los cambios.", false);
                    txtAgregarComentario.Text = "";
                    txtCompra.Text = "";
                }
                else
                {
                    EnviarMensaje("Ocurrio un error al intentar ingresar los datos.", true);
                }
                
                //se descomentara despues<-----------------------------------------------------------------------------------
            }
            catch (FormatException)
            {
                MessageBox.Show($"Elija una fila", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception es)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{es}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("Esta seguro que quiere borrar este dato?", "Mensage del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    int ObtenerProveedorID = proveedorID;
                    int obtenerregistro = registroDC;
                    int resultado = conectar.borrarProveedorTablaDiasCompra(ObtenerProveedorID, obtenerregistro, FechaActual);
                    if (resultado == 0)
                    {
                        EnviarMensaje("Hubo un error.", true);
                    }
                    else
                    {
                        dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                        dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                        dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                        EnviarMensaje("Se borro el dato.", false);
                    }
                }
                else
                {
                    MessageBox.Show("No se borro ningun dato", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception s)
            {
                MessageBox.Show($"Ocurrio un error al intentar borrar los datos\ntipo de error:\n{s}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarParaBotonAgregar();
        }

        private void AgregarParaBotonAgregar()
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("Esta seguro de agregar estos datos a la tabla?", "Mensage del program", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    double compra;
                    int proveedorSeleccionado;
                    if (string.IsNullOrEmpty(txtCompra.Text))
                    {
                        compra = 0;
                    }
                    else
                    {
                        compra = double.Parse(txtCompra.Text.Replace(".", ","));
                    }
                    //aqui pondre una condicion para saber si agregara un proveedor sin fecha fijo o es un nuevo proveedor o un proveedor adelanto.
                    if (RdbProveedorAdelanto.Checked)
                    {
                        proveedorSeleccionado = (int)CboxProveedorAdelantado.SelectedValue;
                        string comentario = txtAgregarComentario.Text;
                        if(comentario == "Agrege un Comentario")
                        {
                            comentario = "";
                        }
                        int resultado = conectar.AgregarNuevoProveedorEnTablaDiasCompra(proveedorSeleccionado, compra, FechaActual, comentario);
                        if(resultado > 0)
                        {
                            EnviarMensaje("Se agrego correctamente los datos.", false);
                            txtCompra.Text = "";
                            txtAgregarComentario.Text = "Agrege un Comentario";
                            txtAgregarComentario.ForeColor = Color.DarkGray;
                        }
                        else
                        {
                            EnviarMensaje("Ocurrio un problema al intentar agregar los datos.", true);
                        }
                    }
                    else if(RdbProveedorSFechaFijo.Checked)
                    {
                        proveedorSeleccionado = (int)CboxProveedoresSinFechaFijo.SelectedValue;
                        string comentario = txtAgregarComentario.Text;
                        if (comentario == "Agrege un Comentario")
                        {
                            comentario = "";
                        }
                        int resultado = conectar.AgregarNuevoProveedorEnTablaDiasCompra(proveedorSeleccionado, compra, FechaActual, comentario);
                        if (resultado > 0)
                        {
                            EnviarMensaje("Se agrego correctamente los datos.", false);
                            txtCompra.Text = "";
                            txtAgregarComentario.Text = "Agrege un Comentario";
                            txtAgregarComentario.ForeColor = Color.DarkGray;
                        }
                        else
                        {
                            EnviarMensaje("Ocurrio un problema al intentar agregar los datos.", true);
                        }
                    }
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                    txtProveedorEspecifico.Text = "";
                }
                else
                {
                    MessageBox.Show("No se agrego ningun dato", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar agregar los datos\ntipo de error:\n{ex}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RdbProveedorAdelanto_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbProveedorAdelanto.Checked)
            {
                CboxProveedorAdelantado.Visible = true;
                CboxProveedoresSinFechaFijo.Visible = false;
                lblProveedor.Text = "Proveedor adelanto:";
            }
            
        }

        private void RdbProveedorSFechaFijo_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbProveedorSFechaFijo.Checked)
            {
                CboxProveedoresSinFechaFijo.Visible = true;
                CboxProveedorAdelantado.Visible = false;
                lblProveedor.Text = "Proveedor sin dia fijo:";
            }
            
        }

        private void QuitarCheckedRadiobutton(bool MarcarProveedorSinFechaFijo, bool MarcarProveedorAdelantado)
        {
            RdbProveedorSFechaFijo.Checked = MarcarProveedorSinFechaFijo;
            RdbProveedorAdelanto.Checked = MarcarProveedorAdelantado;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMensage.Text = "";
            timer1.Stop();
        }

        private void EnviarMensaje(string mensage, bool error)
        {
            if (error)
            {
                timer1.Start();
                lblMensage.Text = mensage;
                lblMensage.ForeColor = Color.FromArgb(250,186,12);
            }
            else
            {
                timer1.Start();
                lblMensage.Text = mensage;
                lblMensage.ForeColor = Color.Green;
            }
            
        }

        private void txtCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear la tecla
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))// Si ya hay un punto
            {
                e.Handled = true;// Bloquear la tecla
            }
        }

        

        private void CboxElegirAhorroOcomplemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string agregar = CboxElegirAhorroOcomplemento.SelectedItem.ToString();
            if (agregar == "A.C")
            {
                lblAhoroCasaOcomplemento.Text = "A.C:";
                txtAhorroCasaOcomplemento.Enabled = true;
            }
            else if (agregar == "D.L")
            {
                lblAhoroCasaOcomplemento.Text = "D.L:";
                txtAhorroCasaOcomplemento.Enabled = true;
            }
            else if(agregar == "Sel..")
            {
                lblAhoroCasaOcomplemento.Text = "";
                txtAhorroCasaOcomplemento.Text = "0";
                txtAhorroCasaOcomplemento.Enabled = false;
            }
        }

        private void txtAhorroCasaOcomplemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquear la tecla
            }
        }

        private void txtAgregarComentario_Enter(object sender, EventArgs e)
        {
            if (txtAgregarComentario.Text == "Agrege un Comentario")
            {
                txtAgregarComentario.Text = "";
                txtAgregarComentario.ForeColor = Color.Black;
            }
        }

        private void txtAgregarComentario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAgregarComentario.Text))
            {
                txtAgregarComentario.Text = "Agrege un Comentario";
                txtAgregarComentario.ForeColor = Color.DarkGray;
            }
        }

        private void txtProveedorEspecifico_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProveedorEspecifico.Text))//si el textbox no esta vacio, hara la logica
            {
                if (RdbProveedorAdelanto.Checked)
                {
                    //aqui ira para proveedor adelantado
                    string proveedorA = txtProveedorEspecifico.Text;
                    LlenarComboboxProveedorEspecificoAdelantado(proveedorA);
                }
                else if (RdbProveedorSFechaFijo.Checked)
                {
                    //aqui ira para proveedor sindiafijo
                    string proveedorSDF = txtProveedorEspecifico.Text;
                    LlenarComboboxProveedorEspecificoSinDiaFijo(proveedorSDF);
                }
            }
            else//si esta vacio que me muestre todos dependiendo que radiobutton esta elegido
            {
                if (RdbProveedorAdelanto.Checked)
                {
                    LlenarComboboxProveedorAdelanto();
                }
                else if (RdbProveedorSFechaFijo.Checked)
                {
                    llenarComboboxSinFechaFijo();
                }
                
            }
        }

        private void LlenarComboboxProveedorEspecificoAdelantado(string proveedorEA)
        {
            CboxProveedorAdelantado.DataSource = conectar.BuscarProveedorAdelantado(proveedorEA);
            CboxProveedorAdelantado.DisplayMember = "NombreProveedor";
            CboxProveedorAdelantado.ValueMember = "ProveedorID";
        }

        private void LlenarComboboxProveedorEspecificoSinDiaFijo(string proveedorSDF)
        {
            CboxProveedoresSinFechaFijo.DataSource = conectar.BuscarProveedorSinDiaFijo(proveedorSDF);
            CboxProveedoresSinFechaFijo.DisplayMember = "NombreProveedor";
            CboxProveedoresSinFechaFijo.ValueMember = "ProveedorID";
        }

        //private void Provedores_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    agregarProveedores = null;
        //    consultaDiasAnteriores = null;
        //}

        //para abrir forms
    }
}
