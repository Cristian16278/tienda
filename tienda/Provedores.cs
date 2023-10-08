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
                //Procedimiento definitivo
                //luego se descomenta<--------------8------------------8---------------8-----------
                //if (conectar.ConsultaProveedorExisteFechaHoy(date) >= 1)//si ya hay proveedores con la fecha del dia actual que solo me recarge el datagridview
                //{
                //    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                //    dtgDiasCompra.Columns["ProveedorID"].Visible = false;
                //    AgregarBotonAlaFila();
                //}
                //else//si no quiere decir que es un nuevo dia y lo creara
                //{
                //    List<int> ProveedoresID = conectar.ObtenerIDproveedores(DiaActual);
                //    conectar.llenarTablaDiasCompra(ProveedoresID, date);
                //    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                //    //dtgDiasCompra.Columns["ProveedorID"].DataPropertyName = "ID";
                //    dtgDiasCompra.Columns["ProveedorID"].Visible = false;
                //    AgregarBotonAlaFila();
                //}
                //luego se descomenta<---------------8---------------8-----------------8-----------
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al intentar cargar el form.\ntipo de error:\n{ex}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private (List<int>, bool) VerificarProveedorEspecifico(List<int> obtenerProveedorDeTablaProveedores, DateTime dia)
        {
            try
            {
                List<int> nuevosproveedores = new List<int>();
                List<int> proveedoresDiascompra = conectar.ObtenerProveedorIDDeDiasCompra(dia);
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
                    return (nuevosproveedores, true);
                }
                return (null, false);
            }
            catch (Exception f)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{f}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (null, false);
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
        private void dtgDiasCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0 && e.ColumnIndex >= 0)//si se dio click en una celda valida(que no sean los encabezados)
                {
                    //me falta mejorar la logica para modificar el boton al hacerle click
                    DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
                    if (e.ColumnIndex == dtgDiasCompra.Columns["Agregar Imagen"].Index)
                    {
                        //OfdElegirImagen.Title = "Seleccione una imagen";
                        //OfdElegirImagen.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*";
                        int indice = e.RowIndex;
                        int proveedorID = (int)dtgDiasCompra.Rows[indice].Cells["ProveedorID"].Value;
                        var (Proveedorexiste, rutaimagen) = conectar.VerificarImagenEnProveedor(date, proveedorID);
                        if (Proveedorexiste == proveedorID)
                        {
                            Previsualisacion_imagen previsualisacion = new Previsualisacion_imagen(rutaimagen, "si");
                            if (previsualisacion.ShowDialog() == DialogResult.OK)
                            {
                                string obtenernuevaruta = previsualisacion.ObtenerNuevaRuta();
                                MessageBox.Show("Se guardara la nueva ruta");
                                conectar.GuardarImagenProveedor(proveedorID, date, obtenernuevaruta);
                                dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
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
                                    MessageBox.Show("Se guardara en la base de datos");
                                    int indice1 = e.RowIndex;
                                    int proveedorID1 = (int)dtgDiasCompra.Rows[indice1].Cells["ProveedorID"].Value;
                                    conectar.GuardarImagenProveedor(proveedorID1, date, imagen);
                                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                                    //dtgDiasCompra.Columns["ProveedorID"].Visible = false;

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
            dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
            borrarContenidoTextbox();
        }

        private void RefrescarFormululario(string DiaActual, DateTime date)
        {
            try
            {
                List<int> proveedoresDiascompra = conectar.ObtenerProveedorIDDeDiasCompra(date);//para comparar las listas
                List<int> ProveedoresID = conectar.ObtenerIDproveedores(DiaActual);
                var (nuevoproveedores, verificar) = VerificarProveedorEspecifico(ProveedoresID, date);
                if (CompararListas(ProveedoresID, proveedoresDiascompra))
                {
                    //si son los mismos valores que solo me recarge la tabla
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                    //dtgDiasCompra.Columns["ProveedorID"].Visible = false;luego lo descomentamos<-------------------------------
                    //dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                    //AgregarBotonAlaFila();
                }
                else if (verificar)
                {
                    //si le hace falta ala tabla diascompra, que me agrege lo que falta y me lo recarge
                    conectar.llenarTablaDiasCompra(nuevoproveedores, date);
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                    //dtgDiasCompra.Columns["ProveedorID"].Visible = false;luego lo descomentamos<-------------------------------
                    //dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                    //AgregarBotonAlaFila();
                }
                else if (conectar.ConsultaProveedorExisteFechaHoy(date) >= 1)
                {
                    //si es un nuevo dia que me agrege todos lo proveedores que pasan en el dia actual
                    conectar.llenarTablaDiasCompra(ProveedoresID, date);
                    dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                    dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                    //dtgDiasCompra.Columns["ProveedorID"].Visible = false;luego lo descomentamos<-------------------------------
                    //dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                    //AgregarBotonAlaFila();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error\ntipo de error:\n{ex}", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                txtProveedor.Text = "";
                //se cambiaran los datos
                MessageBox.Show("Se modificaran los datos");
                //se descomentara despues<-----------------------------------------------------------------------------------
                //DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
                //int obtenerindiceProveedorID = proveedorID;
                //double compra = double.Parse(txtCompra.Text);
                //conectar.AgregarCompraTablaDiasCompra(obtenerindiceProveedorID, date, compra);
                //dtgDiasCompra.SelectionChanged -= dtgDiasCompra_SelectionChanged;
                //dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                //dtgDiasCompra.SelectionChanged += dtgDiasCompra_SelectionChanged;
                //borrarContenidoTextbox();
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

        private void llenarCombobox()
        {
            CboxProveedoresSinFechaFijo.DataSource = conectar.CargarCbox();
            CboxProveedoresSinFechaFijo.DisplayMember = "NombreProveedor";
            CboxProveedoresSinFechaFijo.ValueMember = "ProveedorID";
        }

        private void CboxAccionRealizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string elegiraccion = CboxAccionRealizar.SelectedItem.ToString();
            if (elegiraccion == "Agregar")
            {
                BtnGuardar.Text = "Agregar";
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click += BtnAgregar_Click;
                BtnGuardar.Click -= BtnBorrar_Click;
                BtnGuardar.Click -= BtnGuardar_Click;
                BtnGuardar.BackColor = Color.Green;
                BtnGuardar.ForeColor = Color.White;
                CboxProveedoresSinFechaFijo.Visible = true;
                txtProveedor.Visible = false;
                //nesesitaremos el ProveedorID donde DiaVisita sea igual a 'Sin dia fijo',
                //la fecha y la compra sera opcional
            }
            else if(elegiraccion == "Borrar")
            {
                BtnGuardar.Text = "Borrar";
                BtnGuardar.Click -= BtnBorrar_Click;
                BtnGuardar.Click += BtnBorrar_Click;
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click -= BtnGuardar_Click;
                BtnGuardar.BackColor = Color.Red;
                BtnGuardar.ForeColor = Color.White;
                CboxProveedoresSinFechaFijo.Visible = false;
                txtProveedor.Enabled = false;
                //nesesitaremos el ProveedorID y la fecha
            }
            else
            {
                BtnGuardar.Text = "Guardar cambios";
                BtnGuardar.Click -= BtnAgregar_Click;
                BtnGuardar.Click -= BtnBorrar_Click;
                BtnGuardar.Click -= BtnGuardar_Click;
                BtnGuardar.Click += BtnGuardar_Click;
                BtnGuardar.BackColor = Color.Silver;
                BtnGuardar.ForeColor = Color.Black;
                CboxProveedoresSinFechaFijo.Visible = false;
                txtProveedor.Visible = true;

                //nesecitaremos el ProveedroID, la compra y la fecha
            }
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("se borraran los datos");
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("se agregaran nuevos datos");
        }



        //private void Provedores_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    agregarProveedores = null;
        //    consultaDiasAnteriores = null;
        //}

        //para abrir forms
    }
}
