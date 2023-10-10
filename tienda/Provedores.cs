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
                string diaActual = DateTime.Now.ToString("dddd");
                lblFechaActual.Text = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy");
                DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
                string DiaActual = conectar.ObtenerDiaActual(diaActual);
                RefrescarFormululario(DiaActual, date);
                dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                AgregarBotonAlaFila();
                borrarContenidoTextbox();
                CboxAccionRealizar.SelectedItem = "Modificar";
                llenarComboboxSinFechaFijo();
                LlenarComboboxProveedorAdelanto();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar cargar el form.\ntipo de error:\n{ex}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private bool CompararListas(List<int> lista1, List<int> lista2)
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
                        //OfdElegirImagen.Title = "Seleccione una imagen";
                        //OfdElegirImagen.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*";
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
                                conectar.GuardarImagenProveedor(proveedorID, date, obtenernuevaruta, registroDC);
                                dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                                EnviarMensaje("Se Guardo la nueva imagen", false);
                            }
                            else
                            {
                                MessageBox.Show("No se hiso ningun cambio");
                            }
                        }
                        else
                        {
                            if (OfdElegirImagen.ShowDialog() == DialogResult.OK)
                            {
                                string imagen = OfdElegirImagen.FileName;
                                Previsualisacion_imagen previsualisacion = new Previsualisacion_imagen(imagen, "no");
                                if (previsualisacion.ShowDialog() == DialogResult.OK)
                                {
                                    int indice1 = e.RowIndex;
                                    int proveedorID1 = (int)dtgDiasCompra.Rows[indice1].Cells["ProveedorID"].Value;
                                    conectar.GuardarImagenProveedor(proveedorID1, date, imagen, registroDC);
                                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                                    //dtgDiasCompra.Columns["ProveedorID"].Visible = false;
                                    EnviarMensaje("Se guardo correctamente la imagen", false);
                                }
                                else
                                {
                                    MessageBox.Show("No se guardara en la base de datos");
                                }
                            }
                        }
                    }
                    else if (e.ColumnIndex == dtgDiasCompra.Columns["Compra"].Index || e.ColumnIndex == dtgDiasCompra.Columns["Imagen"].Index || e.ColumnIndex == dtgDiasCompra.Columns["Proveedor"].Index)
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

                    txtCompra.Text = row.Cells["Compra"].Value.ToString();
                    txtProveedor.Text = row.Cells["Proveedor"].Value.ToString();
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
            //if (conectar.VerificarSiSeAgregoProveedorSinFechaFijo() > 0)
            //{
            //    llenarComboboxSinFechaFijo();
            //    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
            //    dtgDiasCompra.Columns["ProveedorID"].Visible = false;
            //}
            //else
            //{
            //    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
            //    dtgDiasCompra.Columns["ProveedorID"].Visible = false;
            //}
            dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
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
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                    dtgDiasCompra.Columns["ProveedorDiaID"].Visible = false;
                }
                else if (conectar.ConsultaProveedorExisteFechaHoy(FechaActual) >= 1)
                {
                    //si ya existen proveedores con la fecha actual que solo me recarge la tabla.
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                    dtgDiasCompra.Columns["ProveedorDiaID"].Visible = false;
                }
                else
                {
                    //si es un nuevo dia que me agrege todos lo proveedores que pasan en el dia actual
                    conectar.llenarTablaDiasCompra(ProveedoresID, FechaActual);
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                    dtgDiasCompra.Columns["ProveedorDiaID"].Visible = false;
                    //AgregarBotonAlaFila();
                }
                //List<int> proveedoresDiascompra = conectar.ObtenerProveedorIDDeDiasCompra(FechaActual);//para comparar las listas
                //List<int> ProveedoresID = conectar.ObtenerIDproveedoresEnTablaProveedores(DiaActual);
                //var (nuevoproveedores, verificar) = VerificarProveedorEspecifico(ProveedoresID,proveedoresDiascompra, FechaActual);
                //if (CompararListas(ProveedoresID, proveedoresDiascompra))
                //{
                //    //si son los mismos valores que solo me recarge la tabla
                //    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                //    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                //    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                //}
                //else if (verificar)
                //{
                //    //si le hace falta ala tabla diascompra, que me agrege lo que falta y me lo recarge
                //    conectar.llenarTablaDiasCompra(nuevoproveedores, FechaActual);
                //    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                //    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                //    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                //}
                //else if (conectar.ConsultaProveedorExisteFechaHoy(FechaActual) >= 1)
                //{
                //    //si es un nuevo dia que me agrege todos lo proveedores que pasan en el dia actual
                //    conectar.llenarTablaDiasCompra(ProveedoresID, FechaActual);
                //    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                //    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                //    dtgDiasCompra.Columns["ProveedorID"].Visible = false; //luego lo descomentamos < -------------------------------
                //    //AgregarBotonAlaFila();
                //}

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
            string elegiraccion = CboxAccionRealizar.SelectedItem.ToString();
            if (elegiraccion == "Agregar proveedor")
            {
                BtnGuardar.Text = "Agregar";
                //lblProveedor.Text = "Proveedor e agregar:";
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click += BtnAgregar_Click;
                BtnGuardar.Click -= BtnBorrar_Click;
                BtnGuardar.Click -= BtnGuardar_Click;
                dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                BtnGuardar.BackColor = Color.Green;
                BtnGuardar.ForeColor = Color.White;
                //CboxProveedoresSinFechaFijo.Visible = true;
                txtProveedor.Visible = false;
                txtProveedor.BackColor = Color.Silver;
                //CboxProveedorAdelantado.Visible = true;
                RdbProveedorSFechaFijo.Visible = true;
                RdbProveedorAdelanto.Visible = true;
                QuitarCheckedRadiobutton(true, false);
                //nesesitaremos el ProveedorID donde DiaVisita sea igual a 'Sin dia fijo',
                //la fecha y la compra sera opcional
            }
            else if(elegiraccion == "Borrar")
            {
                BtnGuardar.Text = "Borrar";
                lblProveedor.Text = "Proveedor a eliminar:";
                BtnGuardar.Click -= BtnBorrar_Click;
                BtnGuardar.Click += BtnBorrar_Click;
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click -= BtnGuardar_Click;
                dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                BtnGuardar.BackColor = Color.Red;
                BtnGuardar.ForeColor = Color.White;
                CboxProveedoresSinFechaFijo.Visible = false;
                txtProveedor.Enabled = false;
                txtProveedor.Visible = true;
                txtProveedor.BackColor = Color.Silver;
                CboxProveedorAdelantado.Visible = false;
                RdbProveedorSFechaFijo.Visible = false;
                RdbProveedorAdelanto.Visible = false;
                QuitarCheckedRadiobutton(false, false);
                //nesesitaremos el ProveedorID y la fecha
            }
            else
            {
                BtnGuardar.Text = "Guardar cambios";
                lblProveedor.Text = "Proveedor a modificar:";
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click -= BtnBorrar_Click;
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
                CboxProveedorAdelantado.Visible = false;
                RdbProveedorSFechaFijo.Visible = false;
                RdbProveedorAdelanto.Visible = false;
                QuitarCheckedRadiobutton(false, false);
                //nesecitaremos el ProveedroID, la compra y la fecha
            }
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
                double compra = double.Parse(txtCompra.Text);
                int resultado = conectar.AgregarCompraTablaDiasCompra(obtenerindiceProveedorID, date, compra, obtenerRegistroDC);
                if(resultado > 0)
                {
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                    dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                    borrarContenidoTextbox();
                    EnviarMensaje("Se guardaron los cambios", false);
                }
                else
                {
                    EnviarMensaje("Ocurrio un error al intentar ingresar los datos", true);
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
                    conectar.borrarProveedorTablaDiasCompra(ObtenerProveedorID, FechaActual);
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
                    dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                    MessageBox.Show("se borraran los datos");
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
                        compra = double.Parse(txtCompra.Text);
                    }
                    //aqui pondre una condicion para saber si agregara un proveedor sin fecha fijo o es un nuevo proveedor o un proveedor adelanto.
                    if (RdbProveedorAdelanto.Checked)
                    {
                        proveedorSeleccionado = (int)CboxProveedorAdelantado.SelectedValue;
                        int resultado = conectar.AgregarNuevoProveedorEnTablaDiasCompra(proveedorSeleccionado, compra, FechaActual);
                        if(resultado > 0)
                        {
                            EnviarMensaje("Se agrego correctamente los datos", false);
                        }
                        else
                        {
                            EnviarMensaje("Ocurrio un problema al intentar agregar los datos", true);
                        }
                    }
                    else if(RdbProveedorSFechaFijo.Checked)
                    {
                        proveedorSeleccionado = (int)CboxProveedoresSinFechaFijo.SelectedValue;
                        int resultado = conectar.AgregarNuevoProveedorEnTablaDiasCompra(proveedorSeleccionado, compra, FechaActual);
                        if (resultado > 0)
                        {
                            EnviarMensaje("Se agrego correctamente los datos", false);
                        }
                        else
                        {
                            EnviarMensaje("Ocurrio un problema al intentar agregar los datos", true);
                        }
                    }
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(FechaActual);
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
                lblMensage.ForeColor = Color.Red;
            }
            else
            {
                timer1.Start();
                lblMensage.Text = mensage;
                lblMensage.ForeColor = Color.Green;
            }
            
        }



        //private void Provedores_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    agregarProveedores = null;
        //    consultaDiasAnteriores = null;
        //}

        //para abrir forms
    }
}
