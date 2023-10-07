using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using static System.Net.Mime.MediaTypeNames;

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
            string diaActual = DateTime.Now.ToString("dddd");
            lblFechaActual.Text = DateTime.Now.ToString("dddd, d MMMM 'de' yyyy");
            DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
            string DiaActual = conectar.ObtenerDiaActual(diaActual);
            //Procedimiento definitivo
            //luego se descomenta<--------------8------------------8---------------8-----------
            if (conectar.ConsultaProveedorExisteFechaHoy(date) >= 1)//si ya hay proveedores con la fecha del dia actual que solo me recarge el datagridview
            {
                dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                dtgDiasCompra.Columns["ProveedorID"].Visible = false;
                AgregarBotonAlaFila();
            }
            else//si no quiere decir que es un nuevo dia y lo creara
            {
                List<int> ProveedoresID = conectar.ObtenerIDproveedores(DiaActual);
                conectar.llenarTablaDiasCompra(ProveedoresID, date);
                dtgDiasCompra.DataSource = conectar.CargarTablaDiasCompra(date);
                //dtgDiasCompra.Columns["ProveedorID"].DataPropertyName = "ID";
                dtgDiasCompra.Columns["ProveedorID"].Visible = false;
                AgregarBotonAlaFila();
            }
            //luego se descomenta<---------------8---------------8-----------------8-----------


            //dataGridView1.DataSource = conectar.llenarProveedores(diaActual);
            //dataGridView1.Columns["Proveedor"].DataPropertyName = "NombreProveedor";
            //dataGridView1.Columns["NombreProveedor"].Visible = false;



            //MessageBox.Show($"El dia de hoy es {diaActual}");
            //dataGridView1.Columns["Proveedor"].HeaderText = "Proveedor";
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    row.Cells["Proveedor"].Value = row.Cells["NombreProveedor"].Value;
            //}
        }

        private void AgregarBotonAlaFila()
        {
            DataGridViewButtonColumn botonAgregarimagen = new DataGridViewButtonColumn();
            botonAgregarimagen.Name = "Agregar Imagen";
            botonAgregarimagen.Text = "Agregar imagen";
            botonAgregarimagen.UseColumnTextForButtonValue = true;
            dtgDiasCompra.Columns.Add(botonAgregarimagen);
        }

        //para abrir los forms
        private AgregarProveedores agregarProveedores = null;
        private ConsultaDiasAnteriores consultaDiasAnteriores = null;


        private void agregarProveedorToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void consultarDiasAtrasToolStripMenuItem_Click_1(object sender, EventArgs e)
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

        private void dtgDiasCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //me falta mejorar la logica para modificar el boton al hacerle click
            DateTime date = DateTime.Now.Date;//<----para obtener solo lafecha(yyyy-MM-dd)
            if(e.ColumnIndex == dtgDiasCompra.Columns["Agregar Imagen"].Index)
            {
                //OfdElegirImagen.Title = "Seleccione una imagen";
                //OfdElegirImagen.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*";
                int indice = e.RowIndex;
                int proveedorID = (int)dtgDiasCompra.Rows[indice].Cells["ProveedorID"].Value;
                var (Proveedorexiste, rutaimagen) = conectar.VerificarImagenEnProveedor(date, proveedorID);
                if(Proveedorexiste == proveedorID)
                {
                    Previsualisacion_imagen previsualisacion = new Previsualisacion_imagen(rutaimagen, "si");
                    if(previsualisacion.ShowDialog() == DialogResult.OK)
                    {
                        string obtenernuevaruta = previsualisacion.ObtenerNuevaRuta();
                        MessageBox.Show("Se guardara la nueva ruta");
                        //conectar.GuardarImagenProveedor(proveedorID, date, obtenernuevaruta);
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
                //List<int> ints = conectar.VerificarImagenEnProveedor(date);
                //if (ints.Count > 0)
                //{
                //    foreach (int i in ints)
                //    {
                //        if(i == e.RowIndex)
                //        {
                //            dtgDiasCompra.Rows[e.RowIndex].Cells[3].Value = "Visualizar imagen";
                //        }
                //    }
                //}
                //else
                //{

                //    }
                //}
            }
        }

        private void dtgDiasCompra_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgDiasCompra.SelectedCells.Count > 0)
                {
                    int seleccionarcampo = dtgDiasCompra.SelectedCells[0].RowIndex;
                    DataGridViewRow row = dtgDiasCompra.Rows[seleccionarcampo];

                    txtCompra.Text = row.Cells[2].Value.ToString();
                    txtProveedor.Text = row.Cells[1].Value.ToString();
                }
            }
            catch
            {

            }
        }

        private void txtPresupuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Se preciono la tecla enter");
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
