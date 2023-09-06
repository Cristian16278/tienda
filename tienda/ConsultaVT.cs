using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace tienda
{
    public partial class ConsultaVT : Form
    {
        int activarboton;//<---variable para activar los botones
        ConectarBD cone = new ConectarBD();//<--conexion a Datos
        private Action _onFormClosed;
        
        public ConsultaVT(Action onFormClosed)
        {
            InitializeComponent();
            _onFormClosed = onFormClosed;
        }
        

        private void ConsultaVT_FormClosed(object sender, FormClosedEventArgs e)
        {
            _onFormClosed?.Invoke();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaini = dtpFechaini.Value;
                DateTime fechafi = dtpFechafin.Value;
                if (fechaini > fechafi)
                {
                    MessageBox.Show("No puede poner una fecha de inicio mayor a la fecha fin que desea consultar","Fecha inicio mayor a la fecha fin",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    graficomesactual.Series["V_T"].Points.Clear();
                    cone.BuscarSumar2(fechaini.ToString(), fechafi.ToString(), lblVentaT, lblCosumoD, lblRestoU, lblNetoE);
                    dataGridView1Mostra.DataSource = cone.ConsultaPorFecha(fechaini.ToString(), fechafi.ToString());
                    cone.ConsultaPorFechellenarchart(fechaini.ToString(), fechafi.ToString(), graficomesactual);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error\n\ntipo de error:\n {ex}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            activarboton = 1;
            graficomesactual.Titles[0].Text = "7 dias atras";
            activarbotones();
            int sem = -7;
            fechas(sem);
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            activarboton = 2;
            graficomesactual.Titles[0].Text = "30 dias atras";
            activarbotones();
            int mes = -30;
            fechas(mes);
        }

        private void btnAno_Click(object sender, EventArgs e)
        {
            activarboton = 3;
            graficomesactual.Titles[0].Text = "Un Año atras";
            activarbotones();
            int ano = -365;
            fechas(ano);
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            activarboton = 4;
            graficomesactual.Titles[0].Text = "Fecha personalisada";
            graficomesactual.Series["V_T"].Points.Clear();
            //dataGridView1Mostra.Rows.Clear();
            activarbotones();
            dtpFechafin.Value = DateTime.Today;
            lblFechainicio.Visible = true;
            lblFechafin.Visible = true;
            //dateTimePickerFechainicio.Visible = true;
            //dateTimePickerFechafin.Visible = true;
            lblVentaT.Text = "0";
            lblRestoU.Text = "0";
            lblNetoE.Text = "0";
            lblCosumoD.Text = "0";
            dtpFechaini.Visible = true;
            dtpFechafin.Visible = true;
            dtpFechafin.Enabled = true;
            btnConsultar.Visible = true;
        }

        private void activarbotones()
        {
            try
            {
                switch (activarboton)
                {
                    case 1:
                        btnSemana.Enabled = false;
                        quitarcolor();
                        //btnSemana.BackColor = Color.White;
                        btnMes.Enabled = true;
                        btnAno.Enabled = true;
                        btnFecha.Enabled = true;
                        lblFechainicio.Visible = false;
                        lblFechafin.Visible = false;
                        //dateTimePickerFechainicio.Visible = false;
                        //dateTimePickerFechafin.Visible = false;
                        dtpFechaini.Visible = false;
                        dtpFechafin.Visible = false;
                        btnConsultar.Visible = false;
                        break;
                    case 2:
                        btnSemana.Enabled = true;
                        btnMes.Enabled = false;
                        quitarcolor();
                        //btnMes.BackColor= Color.White;
                        btnAno.Enabled = true;
                        btnFecha.Enabled = true;
                        lblFechainicio.Visible = false;
                        lblFechafin.Visible = false;
                        //dateTimePickerFechainicio.Visible = false;
                        //dateTimePickerFechafin.Visible = false;
                        dtpFechaini.Visible = false;
                        dtpFechafin.Visible = false;
                        btnConsultar.Visible = false;
                        break;
                    case 3:
                        btnSemana.Enabled = true;
                        btnMes.Enabled = true;
                        btnAno.Enabled = false;
                        quitarcolor();
                        //btnAno.BackColor = Color.White;
                        btnFecha.Enabled = true;
                        lblFechainicio.Visible = false;
                        lblFechafin.Visible = false;
                        //dateTimePickerFechainicio.Visible = false;
                        //dateTimePickerFechafin.Visible = false;
                        dtpFechaini.Visible = false;
                        dtpFechafin.Visible = false;
                        btnConsultar.Visible = false;
                        break;
                    case 4:
                        btnSemana.Enabled = true;
                        btnMes.Enabled = true;
                        btnAno.Enabled = true;
                        btnFecha.Enabled = false;
                        quitarcolor();
                        //btnFecha.BackColor = Color.White;
                        break;
                }
            }
            catch (Exception k)
            {
                MessageBox.Show($"Ocurrio un error\n\ntipo de error:\n {k}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quitarcolor()
        {
            switch (activarboton)
            {
                case 1:
                    btnSemana.BackColor = Color.White;
                    btnMes.BackColor = Color.Teal;
                    btnAno.BackColor = Color.Teal;
                    btnFecha.BackColor = Color.Teal;
                    break;
                case 2:
                    btnSemana.BackColor = Color.Teal;
                    btnMes.BackColor = Color.White;
                    btnAno.BackColor = Color.Teal;
                    btnFecha.BackColor = Color.Teal;
                    break;
                case 3:
                    btnSemana.BackColor = Color.Teal;
                    btnMes.BackColor = Color.Teal;
                    btnAno.BackColor = Color.White;
                    btnFecha.BackColor = Color.Teal;
                    break;
                case 4:
                    btnSemana.BackColor = Color.Teal;
                    btnMes.BackColor = Color.Teal;
                    btnAno.BackColor = Color.Teal;
                    btnFecha.BackColor = Color.White;
                    break;
            }
        }

        private void fechas(int numerodias)
        {
            try
            {
                graficomesactual.Series["V_T"].Points.Clear();
                //graficomesactual.Series["Datos anterior"].Points.Clear();
                switch (numerodias)
                {
                    case -7:
                        dateTimePickerFechainicio.Value = DateTime.Today.AddDays(numerodias);
                        dateTimePickerFechafin.Value = DateTime.Today;
                        dataGridView1Mostra.DataSource = cone.ConsultaPorFecha(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString());
                        cone.ConsultaPorFechellenarchart(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString(), graficomesactual);
                        cone.BuscarSumar(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString(), lblVentaT, lblCosumoD, lblRestoU, lblNetoE);/*.ToString("#,##0",culture)*/
                        break;
                    case -30:
                        dateTimePickerFechainicio.Value = DateTime.Today.AddDays(numerodias);
                        dateTimePickerFechafin.Value = DateTime.Today;
                        dataGridView1Mostra.DataSource = cone.ConsultaPorFecha(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString());
                        cone.ConsultaPorFechellenarchart(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString(), graficomesactual);
                        cone.BuscarSumar(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString(), lblVentaT, lblCosumoD, lblRestoU, lblNetoE);/*.ToString("#,##0", culture)*/

                        break;
                    case -365:
                        dateTimePickerFechainicio.Value = DateTime.Today.AddDays(numerodias);
                        dateTimePickerFechafin.Value = DateTime.Today;
                        dataGridView1Mostra.DataSource = cone.ConsultaPorFecha(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString());
                        cone.ConsultaPorFechellenarchart(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString(), graficomesactual);
                        cone.BuscarSumar(dateTimePickerFechainicio.Value.ToString(), dateTimePickerFechafin.Value.ToString(), lblVentaT, lblCosumoD, lblRestoU, lblNetoE);/*.ToString("#,##0", culture)*/
                        break;
                }
            }
            catch (Exception q)
            {
                MessageBox.Show($"Ocurrio un error\n\ntipo de error:\n {q}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConsultaVT_Load(object sender, EventArgs e)
        {
            btnSemana.Select();
            btnSemana.PerformClick();
            dtpFechaini.MaxDate = DateTime.Today;
            dtpFechafin.MaxDate = DateTime.Today;
            dateTimePickerFechainicio.MaxDate = DateTime.Today;
            dateTimePickerFechafin.MaxDate = DateTime.Today;
        }
    }
}
