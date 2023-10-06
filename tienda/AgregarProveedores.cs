using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class AgregarProveedores : Form
    {
        private List<string> diasobtener = new List<string>();
        ConectarBD conectar = new ConectarBD();
        public AgregarProveedores()
        {
            InitializeComponent();
            //CheckBox c = new CheckBox();
            //c.CheckedChanged += C_CheckedChanged;
            
        }

        private void C_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            string dia = checkBox.Text;

            if (checkBox.Checked)
            {
                diasobtener.Add(dia);
                CheckboxNoPasa.Checked = false;
                CheckBoxSinDiaFijo.Checked = false;
            }
            else
            {
                diasobtener.Remove(dia);
            }

            Mostrar();
        }

        private void Mostrar() => lblObtenerDias.Text = string.Join(", ", diasobtener);

        private void CambiarEstadoDeEventoChecked(bool cambiarestado)
        {
            if (cambiarestado)
            {
                CheckboxLunes.CheckedChanged += C_CheckedChanged;
                CheckboxMartes.CheckedChanged += C_CheckedChanged;
                CheckboxMiercoles.CheckedChanged += C_CheckedChanged;
                CheckboxJueves.CheckedChanged += C_CheckedChanged;
                CheckboxViernes.CheckedChanged += C_CheckedChanged;
                CheckboxSabado.CheckedChanged += C_CheckedChanged;
                CheckboxDomingo.CheckedChanged += C_CheckedChanged;
            }
            else
            {
                CheckboxLunes.CheckedChanged -= C_CheckedChanged;
                CheckboxMartes.CheckedChanged -= C_CheckedChanged;
                CheckboxMiercoles.CheckedChanged -= C_CheckedChanged;
                CheckboxJueves.CheckedChanged -= C_CheckedChanged;
                CheckboxViernes.CheckedChanged -= C_CheckedChanged;
                CheckboxSabado.CheckedChanged -= C_CheckedChanged;
                CheckboxDomingo.CheckedChanged -= C_CheckedChanged;
            }
        }

        private void CboxElegirAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accion = CboxElegirAccion.SelectedItem.ToString();
            if (accion == "Seleccione")
            {
                CambiarMetodoaBoton(accion);
                TxtProveedor.Visible = false;
                //CboxElegirCantidadDias.Visible = false;
                lblDiavisitaProveedor.Text = "";
                lblProveedor.Text = "";
                lblObtenerDias.Text = "";
                lblDiaAcambiar.Text = "";
                BtnRealizarAccion.Text = "Seleccione";
                GropboxVariosDias.Visible = false;
                //CboxElegirDia.Visible = false;
                HacerVisibleCheckBoxs(false);
                CambiarEstadoDeEventoChecked(false);
                
            }
            else if (accion == "Agregar proveedor")
            {
                CambiarMetodoaBoton(accion);
                QuitarOmarcarChecked(false);
                lblProveedor.Text = "Nombre del Proveedor:";
                lblDiavisitaProveedor.Text = "Seleccione los dias que pasara:";
                lblDiaAcambiar.Text = "";
                //CboxElegirCantidadDias.Visible = true;
                TxtProveedor.Visible = true;
                GropboxVariosDias.Visible = true;
                HacerVisibleCheckBoxs(true);
                CambiarEstadoDeEventoChecked(false);
                CambiarEstadoDeEventoChecked(true);
                
                //CboxElegirCantidadDias.SelectedItem = "Seleccione";
                BtnRealizarAccion.Text = "Agregar proveedor";
            }
            else if (accion == "Modificar proveedor")
            {
                CambiarMetodoaBoton(accion);
                QuitarOmarcarChecked(false);
                lblProveedor.Text = "Nombre del Proveedor:";
                lblDiavisitaProveedor.Text = "Seleccione la cantidad de dias:";
                //CboxElegirCantidadDias.Visible = true;
                GropboxVariosDias.Visible = true;
                HacerVisibleCheckBoxs(true);
                TxtProveedor.Visible = true;
                CambiarEstadoDeEventoChecked(false);
                CambiarEstadoDeEventoChecked(true);
                BtnRealizarAccion.Text = "Modificar proveedor";
            }
            else if (accion == "Borrar")//       <----esto no estoy seguro si lo utilisare
            {
                CambiarMetodoaBoton(accion);
                lblProveedor.Text = "Nombre del Proveedor:";
                lblDiavisitaProveedor.Text = "Seleccione la cantidad de dias:";
                //CboxElegirCantidadDias.Visible = true;
                TxtProveedor.Visible = true;
                BtnRealizarAccion.Text = "Borrar proveedor";
            }
        }

        //metodo Borrar proveedor (este metodo nose si lo utilizare)
        private void BtnBorrarProveedor_Click(object sender, EventArgs e)
        {
            string provedor = TxtProveedor.Text;
            //string diavisita = CboxElegirCantidadDias.SelectedItem.ToString();
            DialogResult respuesta = MessageBox.Show("Esta seguro que quiere borrar estos datos?","Advertencia!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                //conectar.BorrarProveedor(provedor, diavisita);
                DtgvProveedores.DataSource = conectar.MostrarTablaProveedores();
                TxtProveedor.Text = "";
            }
            else
            {
                MessageBox.Show("No se borro ningun dato","Accion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //metodo Modificar proveedor
        private void BtnModificarProveedor_Click(object sender, EventArgs e)
        {
            string provedor = TxtProveedor.Text;
            string diavisita = lblObtenerDias.Text;
            string Modificardiavisita = lblDiaAcambiar.Text;
            DialogResult respuesta = MessageBox.Show("Esta seguro que quiere modificar estos datos?","Advertencia!",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(respuesta == DialogResult.Yes)
            {
                conectar.ModificarProveedor(diavisita, provedor, Modificardiavisita);      //<---- aqui ira el metodo de modificar
                DtgvProveedores.DataSource = conectar.MostrarTablaProveedores();
            }
            else
            {
                MessageBox.Show("No se modifico nada");
            }
            TxtProveedor.Text = "";
            QuitarOmarcarChecked(false);
        }

        //metodo Agregar proveedor
        private void BtnAgregarProveedor_Click(object sender, EventArgs e)
        {
            string provedor = TxtProveedor.Text;
            if (string.IsNullOrEmpty(provedor))
            {
                MessageBox.Show("Debe al menos agregar un nombre", "Mensaje del programa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string diavisita = lblObtenerDias.Text;
                DialogResult respuesta = MessageBox.Show("Esta seguro que quiero guardar estos datos?", "Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    if (conectar.AgregarProveedor(provedor, diavisita) == 0)
                    {
                        MessageBox.Show("Ya existe un proveedor con ese nombre", "!Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DtgvProveedores.DataSource = conectar.MostrarTablaProveedores();
                        MessageBox.Show("Se guardo en la base de datos correctamente", "Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Se ha cancelado", "Accion cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TxtProveedor.Text = "";
                QuitarOmarcarChecked(false);
            }
        }

        //este evento se activa al cargar el form
        private void AgregarProveedores_Load(object sender, EventArgs e)
        {
            DtgvProveedores.ClearSelection();
            TxtProveedor.Visible = false;
            lblDiavisitaProveedor.Text = "";
            lblProveedor.Text = "";
            CboxElegirAccion.SelectedItem = "Seleccione";
            DtgvProveedores.DataSource = conectar.MostrarTablaProveedores();
        }

        private void CambiarMetodoaBoton(string cambiaraccion)
        {
            if (cambiaraccion == "Seleccione")
            {
                BtnRealizarAccion.Click -= BtnAgregarProveedor_Click;
                BtnRealizarAccion.Click -= BtnModificarProveedor_Click;
                BtnRealizarAccion.Click -= BtnBorrarProveedor_Click;
                DtgvProveedores.SelectionChanged -= DtgvProveedores_SelectionChanged;
            }
            else if(cambiaraccion == "Agregar proveedor")
            {
                DtgvProveedores.SelectionChanged -= DtgvProveedores_SelectionChanged;
                BtnRealizarAccion.Click -= BtnAgregarProveedor_Click;//si ya esta activado el evento, lo quimos luego se volvera a agregar
                BtnRealizarAccion.Click += BtnAgregarProveedor_Click;//para no tener conflico de agregacion de datos
                BtnRealizarAccion.Click -= BtnModificarProveedor_Click;
                BtnRealizarAccion.Click -= BtnBorrarProveedor_Click;
            }
            else if (cambiaraccion == "Modificar proveedor")
            {
                BtnRealizarAccion.Click -= BtnAgregarProveedor_Click;
                BtnRealizarAccion.Click -= BtnModificarProveedor_Click;//si ya esta activado el evento, lo quitamos luego se volvera a agregar
                BtnRealizarAccion.Click += BtnModificarProveedor_Click;//para no tener conflico de agregacion de datos
                BtnRealizarAccion.Click -= BtnBorrarProveedor_Click;
                DtgvProveedores.SelectionChanged -= DtgvProveedores_SelectionChanged;
                DtgvProveedores.SelectionChanged += DtgvProveedores_SelectionChanged;
            }
            else if (cambiaraccion == "Borrar")//esto no estoy seguro si lo utilizare
            {
                BtnRealizarAccion.Click -= BtnAgregarProveedor_Click;
                BtnRealizarAccion.Click -= BtnModificarProveedor_Click;
                BtnRealizarAccion.Click += BtnBorrarProveedor_Click;
                DtgvProveedores.SelectionChanged -= DtgvProveedores_SelectionChanged;
                DtgvProveedores.SelectionChanged += DtgvProveedores_SelectionChanged;
            }
            else
            {

            }
        }

        
        private void DtgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (DtgvProveedores.SelectedCells.Count > 0)
                {
                    int seleccionarcampo = DtgvProveedores.SelectedCells[0].RowIndex;
                    DataGridViewRow row = DtgvProveedores.Rows[seleccionarcampo];

                    TxtProveedor.Text = row.Cells[0].Value.ToString();
                    string dia = row.Cells[1].Value.ToString();
                    ColocarDiasEnCheckbox(dia);
                }
            }
            catch
            {

            }
        }
        

        private void ColocarDiasEnCheckbox(string obtenerdias)
        {
            try
            {
                QuitarOmarcarChecked(false);
                string[] obten = obtenerdias.Split(new string[] { ", " }, StringSplitOptions.None);

                foreach (string dias in obten)
                {
                    if (dias == "Lunes")
                    {
                        CheckboxLunes.Checked = true;
                    }
                    else if (dias == "Martes")
                    {
                        CheckboxMartes.Checked = true;
                    }
                    else if (dias == "Miercoles")
                    {
                        CheckboxMiercoles.Checked = true;
                    }
                    else if (dias == "Jueves")
                    {
                        CheckboxJueves.Checked = true;
                    }
                    else if (dias == "Viernes")
                    {
                        CheckboxViernes.Checked = true;
                    }
                    else if (dias == "Sabado")
                    {
                        CheckboxSabado.Checked = true;
                    }
                    else if (dias == "Domingo")
                    {
                        CheckboxDomingo.Checked = true;
                    }
                    else
                    {
                        CheckboxNoPasa.Checked = true;
                    }
                }
                lblDiaAcambiar.Text = lblObtenerDias.Text;
            }
            catch
            {

            }
        }

        private void HacerVisibleCheckBoxs(bool VisibleOnoVisible)
        {
            CheckboxLunes.Visible = VisibleOnoVisible;
            CheckboxMartes.Visible = VisibleOnoVisible;
            CheckboxMiercoles.Visible = VisibleOnoVisible;
            CheckboxJueves.Visible = VisibleOnoVisible;
            CheckboxViernes.Visible = VisibleOnoVisible;
            CheckboxSabado.Visible = VisibleOnoVisible;
            CheckboxDomingo.Visible = VisibleOnoVisible;
        }

        private void QuitarOmarcarChecked(bool ActivarOdesactivar)
        {
            CheckboxLunes.Checked = ActivarOdesactivar;
            CheckboxMartes.Checked = ActivarOdesactivar;
            CheckboxMiercoles.Checked = ActivarOdesactivar;
            CheckboxJueves.Checked = ActivarOdesactivar;
            CheckboxViernes.Checked = ActivarOdesactivar;
            CheckboxSabado.Checked = ActivarOdesactivar;
            CheckboxDomingo.Checked = ActivarOdesactivar;
            CheckboxNoPasa.Checked = ActivarOdesactivar;
        }

        private void CheckboxNoPasa_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckboxNoPasa.Checked)
            {
                CheckboxLunes.Checked = false;
                CheckboxMartes.Checked = false;
                CheckboxMiercoles.Checked = false;
                CheckboxJueves.Checked = false;
                CheckboxViernes.Checked = false;
                CheckboxSabado.Checked = false;
                CheckboxDomingo.Checked = false;
                CheckBoxSinDiaFijo.Checked = false;
                lblObtenerDias.Text = CheckboxNoPasa.Text;
            }
            else
            {
                lblObtenerDias.Text = "";
            }
        }

        

        private void CheckBoxSinDiaFijo_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxSinDiaFijo.Checked)
            {
                CheckboxLunes.Checked = false;
                CheckboxMartes.Checked = false;
                CheckboxMiercoles.Checked = false;
                CheckboxJueves.Checked = false;
                CheckboxViernes.Checked = false;
                CheckboxSabado.Checked = false;
                CheckboxDomingo.Checked = false;
                CheckboxNoPasa.Checked = false;
                lblObtenerDias.Text = CheckBoxSinDiaFijo.Text;
            }
            else
            {
                lblObtenerDias.Text = "";
            }
        }
    }
}
