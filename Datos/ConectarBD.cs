﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using System.Data;
using System.Net;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System.Net.Http.Headers;

namespace Datos
{
    public class ConectarBD
    {
        public static string obtener()
        {
            string obtenerservidor = Dns.GetHostName();
            string cadenaconectar = $"server= {obtenerservidor}\\SQLEXPRESS; database= tienda; integrated security= true";//<---conexion a la base de datos independiente mente en que compu se pase
            return cadenaconectar;
        }
        static string obte = obtener();
        SqlConnection conn = new SqlConnection(obte);
        CultureInfo culture = new CultureInfo("en-ES");
        CultureInfo cultura = new CultureInfo("es-ES");
        

        //metodo para buscar el usuario y contrasena si no se encuentra retornara un 0 y un 1 si se encuentra.
        public int logear(string Usuario, string contrasena)
        {
            try
            {
                int count;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                /*
                Explicacion de COLLATE Latin1_General_CS_AS:
                COLLATE: se utilisa para especificar la regla de ordenacion y comparacion en una consulta.
                En la parte de Latin1_General: Indica el conjunto de caracteres que se utilizará para la comparación y ordenación
                la cual es una regla de ordenacion generica para caracteres latinos.
                'CS' : (Case-Sensitive) indica que sera sensible a mayusculas y minusculas, lo que significa que "hola" y "Hola" son diferentes.
                'AS' : (Accent-Sensitive) indica que sera sendible a acentos, lo que significa que "á" y "a" son diferentes.
                en conclusion COLLATE Latin1_General_CS_AS establece que en la consulta que tomara encuenta las mayusculas y minusculas y tambien los acentos,
                por ejemplo "Jose" y "josé" son siferentes la cual la consulta no devolvera nada.
                */
                string consultar = $"SELECT COUNT(*) FROM Persona WHERE usuario COLLATE Latin1_General_CS_AS = '{Usuario}' AND contrasena COLLATE Latin1_General_CS_AS = '{contrasena}'";
                SqlCommand sqlCommand = new SqlCommand(consultar, conn);
                count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                conn.Close();
                return count;
            }
            catch (Exception po)
            {
                MessageBox.Show($"Hubo un problema \n \n tipo de error:\n{po}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        //metodo para guardar calculos, si la fecha que intenta guardar existe, retornara un false, si no, retornara un true.
        public bool guardar(int ventaTotal, int restoutilidad, int consumodiario, int netoexistente, string fechagistro, TimeSpan horaregistro)
        {
            try
            {
                string horaformateado = horaregistro.ToString(@"hh\:mm\:ss", culture);
                bool isInsertSuccessful = false;

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string verificarExistencia = $"SELECT COUNT(*) FROM cuentas_Diarias WHERE fecha_registro = '{fechagistro}'";
                SqlCommand cmdVerificar = new SqlCommand(verificarExistencia, conn);
                int count = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (count == 0)
                {
                    string agregar = $"INSERT INTO cuentas_Diarias(V_T, R_U, C_D, N_E, fecha_registro, hora_registro) VALUES ({ventaTotal}, {restoutilidad}, {consumodiario}, {netoexistente}, '{fechagistro}', '{horaformateado}')";
                    SqlCommand cmdAgregar = new SqlCommand(agregar, conn);
                    int rowsAffected = cmdAgregar.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        isInsertSuccessful = true;
                    }
                }
                else
                {
                    isInsertSuccessful = false;
                }
                conn.Close();
                return isInsertSuccessful;
            }
            catch (Exception t)
            {
                MessageBox.Show($"Hubo un problema \n \n tipo de error:\n{t}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        //metodo para llenar un datagridview y ordenarlo de manera desendente por fecha_registro.
        public DataTable ConsultaBDtienda()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string Consultar = "SELECT V_T, R_U, C_D, N_E, fecha_registro, hora_registro FROM cuentas_Diarias ORDER BY fecha_registro DESC";
                SqlCommand sqlCommand = new SqlCommand(Consultar, conn);
                //SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                using (SqlDataReader re = sqlCommand.ExecuteReader())
                {
                    DataTable data = new DataTable();
                    data.Load(re);
                    return data;
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show($"Hubo un problema \n \n tipo de error:\n{ec}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //metodo para sumar 4 columnas y mostrar los resultado en labels en su propiedad de text.
        public void BuscarSumar(string fechainicio, string fechafin, Label Vt, Label cd, Label ru, Label ne)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string buscar = $"SELECT SUM(V_T) AS venta_total, SUM(R_U) AS resto_utilidad, SUM(C_D) AS consumo_diario, SUM(N_E) AS neto_existente FROM cuentas_Diarias WHERE fecha_registro BETWEEN '{fechainicio}' AND '{fechafin}'";
                SqlCommand command = new SqlCommand(buscar, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int sumavt = Convert.ToInt32(reader["venta_total"]);
                        int sumaru = Convert.ToInt32(reader["resto_utilidad"]);
                        int sumacd = Convert.ToInt32(reader["consumo_diario"]);
                        int sumane = Convert.ToInt32(reader["neto_existente"]);

                        Vt.Text = sumavt.ToString("#,##0", culture);
                        ru.Text = sumaru.ToString("#,##0", culture);
                        cd.Text = sumacd.ToString("#,##0", culture);
                        ne.Text = sumane.ToString("#,##0", culture);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"El rango de fecha que eligio se pasa de la fecha actual, elija otra dentro dela fecha actual \t {ex}", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        //este es lo mismo que el metodo "BuscarSumar" solo que este es para una fecha especifica, el anterior es para 7, 30 y 365 dias atras.
        public void BuscarSumar2(string fechainicio, string fechafin, Label Vt, Label cd, Label ru, Label ne)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string verificarsiexistefecha = $"SELECT COUNT(*) FROM cuentas_Diarias WHERE fecha_registro BETWEEN '{fechainicio}' AND '{fechafin}'";
                SqlCommand verificarsiexiste = new SqlCommand(verificarsiexistefecha, conn);
                int contar = Convert.ToInt32(verificarsiexiste.ExecuteScalar());
                if (contar == 0)
                {
                    MessageBox.Show("La consulta que desea buscar no existe","Advertencia!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                else
                {
                    string buscar = $"SELECT SUM(V_T) AS venta_total, SUM(R_U) AS resto_utilidad, SUM(C_D) AS consumo_diario, SUM(N_E) AS neto_existente FROM cuentas_Diarias WHERE fecha_registro BETWEEN '{fechainicio}' AND '{fechafin}'";
                    SqlCommand command = new SqlCommand(buscar, conn);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int sumavt = Convert.ToInt32(reader["venta_total"]);
                            int sumaru = Convert.ToInt32(reader["resto_utilidad"]);
                            int sumacd = Convert.ToInt32(reader["consumo_diario"]);
                            int sumane = Convert.ToInt32(reader["neto_existente"]);

                            Vt.Text = sumavt.ToString("#,##0", culture);
                            ru.Text = sumaru.ToString("#,##0", culture);
                            cd.Text = sumacd.ToString("#,##0", culture);
                            ne.Text = sumane.ToString("#,##0", culture);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"El rango de fecha que eligio se pasa de la fecha actual, elija otra dentro dela fecha actual \t {ex}", "Advertencia!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        //metodo para mostrar en un datagridview una fecha especifica ejemplo: solo se mostrara de la fecha 12/04/2016 asta 28/08/2020. 
        public DataTable ConsultaPorFecha(string fechaini, string fechafinal)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string buscar = $"SELECT V_T, R_U, C_D, N_E, fecha_registro, hora_registro FROM cuentas_Diarias WHERE fecha_registro BETWEEN '{fechaini}' AND '{fechafinal}' ORDER BY fecha_registro DESC";
                SqlCommand comando = new SqlCommand(buscar, conn);
                //SqlDataAdapter adapter = new SqlDataAdapter(comando);
                using (SqlDataReader leer = comando.ExecuteReader())
                {
                    DataTable data = new DataTable();
                    data.Load(leer);
                    return data;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show($"Hubo un problema \n \n tipo de error:\n{x}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        //metodo para mostrar en un grafico de datos de una fecha especificada.
        public void ConsultaPorFechellenarchart(string fechaini, string fechafinal, Chart grafico)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    string buscar = $"SELECT CONVERT(date,fecha_registro) AS fecha, V_T FROM cuentas_Diarias WHERE fecha_registro BETWEEN '{fechaini}' AND '{fechafinal}' ORDER BY fecha_registro ASC";
                    SqlCommand comando = new SqlCommand(buscar, conn);
                    using (SqlDataReader rea = comando.ExecuteReader())
                    {
                        while (rea.Read())
                        {
                            grafico.Series["V_T"].Points.AddXY(rea.GetDateTime(0).ToString("dd/MM/yyyy"), rea["V_T"].ToString());
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception o)
            {
                MessageBox.Show($"Hubo un problema \n \n tipo de error:\n{o}", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }


        //metodo para desactivar un boton si ya existe una fecha actual.
        public DateTime desacbtnSHFechahoy()
        {
            try
            {
                object resultado;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string cosultarfechahoy = "SELECT fecha_registro FROM cuentas_Diarias WHERE fecha_registro = CONVERT(date, GETDATE());";
                SqlCommand command = new SqlCommand(cosultarfechahoy, conn);
                resultado = command.ExecuteScalar();
                //DateTime flg = (DateTime)command.ExecuteScalar();
                conn.Close();
                if (resultado != null)
                {
                    DateTime flg = (DateTime)resultado;
                    return flg;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
            catch (Exception h)
            {
                MessageBox.Show($"Ocurrio un error\n\n tipo de error:\n {h}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DateTime.MinValue;
            }
            finally
            {
                conn.Close();
            }
            
        }

        //metodo para modificar datos desde una base datos permitiendole modificar al usuario: ventatoatal, restoutilidas, consumodiario, netoexistente y la fecha.
        public int Modificar(int VentaT, int RestoUtilidad,int ConsumoDiario,  int NetoExistente, string fechamodificaropcion, string Fecharegistro)
        {
            try
            {
                int enviarresultado;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string checarsiexiste = $"SELECT COUNT(*) FROM cuentas_Diarias WHERE fecha_registro = '{Fecharegistro}'";
                SqlCommand verificart = new SqlCommand(checarsiexiste, conn);
                int veri = Convert.ToInt32(verificart.ExecuteScalar());
                if (veri == 0)
                {
                    MessageBox.Show("La fecha que desea modificar no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 1;
                }
                else
                {
                    //string verificarfechaopcional = $"SELECT COUNT(*) FROM cuentas_Diarias WHERE fecha_registro = '{fechamodificaropcion}'"<-------------aqui es para verificar si la fecha que intenta modificar ya existe, que envie un mensaje de que ya existe una fecha igual ala que desea modificar.
                    //SqlCommand fechaopcionalverificar = new SqlCommand(verificarfechaopcional,conn);<-------pero si no quire modificar la fecha siempre hara esta parte apesar de que no desea modificar la fecha.
                    //int v = Convert.ToInt32(fechaopcionalverificar.ExecuteScalar());
                    //if (v == 0)
                    //{
                        string actualisar = $"UPDATE cuentas_Diarias SET V_T = {VentaT}, R_U = {RestoUtilidad}, C_D = {ConsumoDiario}, N_E = {NetoExistente}, fecha_registro = '{fechamodificaropcion}' WHERE fecha_registro = '{Fecharegistro}'";
                        SqlCommand comm = new SqlCommand(actualisar, conn);
                        enviarresultado = Convert.ToInt32(comm.ExecuteScalar());
                        conn.Close();
                        return enviarresultado;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("La fecha que desea modificar ya existe","Advertencia!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    //    return 0;
                    //}
                }
            }
            catch (Exception p)
            {
                MessageBox.Show($"Ocurrio un error\n\n tipo de error:\n {p}","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        //metodo para borrar datos desde una base datos permitiendole borrar al usuario: ventatotal, restoutilidad, consumodiario, netoexistente y la fecha.
        public int Borrar(string FechaRb)
        {
            try
            {
                int enviar;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string checarsiexiste = $"SELECT COUNT(*) FROM cuentas_Diarias WHERE fecha_registro = '{FechaRb}'";
                SqlCommand verificart = new SqlCommand(checarsiexiste, conn);
                int verifi = Convert.ToInt32(verificart.ExecuteScalar());
                if (verifi == 0)
                {
                    //MessageBox.Show("La fecha que desea borrar no existe","Advertencia!!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return 1;
                }
                else
                {
                    string Borrar = $"DELETE FROM cuentas_Diarias WHERE fecha_registro = '{FechaRb}'";
                    SqlCommand comm = new SqlCommand(Borrar, conn);
                    enviar = Convert.ToInt32(comm.ExecuteScalar());
                    conn.Close();
                    return enviar;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show($"Ocurrio un error\n\n tipo de error:\n {m}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }
        #region Para los forms de diascompraproveedores, agregarProveedores y consultaProveedores
        //pendiente
        public DataTable MostrarTablaProveedores()//este metodo no lo utilizo
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string mostrartabla = "SELECT NombreProveedor AS Proveedor, DiaVisita AS Dia_de_visita FROM Proveedores";
                SqlCommand comando = new SqlCommand(mostrartabla, conn);
                using (SqlDataReader datareader = comando.ExecuteReader())
                {
                    DataTable data = new DataTable();
                    data.Load(datareader);
                    return data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
                return null;
            }
            finally
            {
                conn.Close();
            }
            //string mostrartabla = "SELECT P.NombreProveedor, DC.Compra FROM DiasCompra AS DC INNER JOIN Proveedores AS P ON DC.ProveedorID = P.ProveedorID WHERE DiaVisita = 'Lunes'"; 
            //return DataTable;
        }
        string diaactual;
        public string ObtenerDiaActual(string dia)
        {
            try
            {
                switch (dia)
                {
                    case "lunes":
                        diaactual = "Lunes";
                        break;
                    case "martes":
                        diaactual = "Martes";
                        break;
                    case "miércoles":
                        diaactual = "Miércoles";
                        break;
                    case "jueves":
                        diaactual = "Jueves";
                        break;
                    case "viernes":
                        diaactual = "Viernes";
                        break;
                    case "sábado":
                        diaactual = "Sábado";
                        break;
                    case "domingo":
                        diaactual = "Domingo";
                        break;
                }
                return diaactual;
            }
            catch (Exception es)
            {
                return es.Message;
            }
        }


        public List<int> ObtenerIDproveedores(string diaActual)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                List<int> ProveedoresID = new List<int>();
                string obtenerID = $"SELECT ProveedorID FROM Proveedores WHERE DiaVisita LIKE @diaactual";
                //string obtenerID = "SELECT ProveedorID FROM Proveedores WHERE DiaVisita COLLATE Latin1_General_BIN LIKE @diaactual COLLATE Latin1_General_BIN";
                using (SqlCommand comando = new SqlCommand(obtenerID, conn))
                {
                    comando.Parameters.AddWithValue("@diaactual","%" + diaActual + "%");
                    using (SqlDataReader datareader = comando.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            int proveedorID = datareader.GetInt32(0);
                            ProveedoresID.Add(proveedorID);
                        }
                        return ProveedoresID;
                    }
                }
                    

                //Hacemos la consulta para ver el nombre y el dia de visita
                //string ConsultaProveedores = $"SELECT NombreProveedor FROM Proveedores WHERE DiaVisita LIKE '%{diaActual}%'";
                //string consulta = "SELECT P.ProveedorID, DC.Fecha, DC.Compra, DC.ImagenCompras" +
                //                  "FROM Proveedores AS P" +
                //                  "INNER JOIN DiasCompra AS DC ON P.ProveedorID = DC.ProveedorID" +
                //                  $"WHERE P.DiaVisita LIKE '%{diaActual}%'";
                ////SqlCommand sqlCommand = new SqlCommand(ConsultaProveedores, conn);
                //SqlDataAdapter dataAdapter = new SqlDataAdapter(ConsultaProveedores, conn);
                //DataTable data = new DataTable();
                //dataAdapter.Fill(data);
                //return data;
                //using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                //{
                //    DataTable data = new DataTable();
                //    data.Load(dataReader);
                //    return data;
                //}


                //llenamos el dataAdapter con data
                //dataAdapter.Fill(data);

                //luego obtenemos el dia actual
                //string diaActual = DateTime.Now.ToString("dddd");
                //DataView dataView = new DataView(data);
                ////encontramos el dia en la columna DiaVisita
                //dataView.RowFilter = $"DiaVisita LIKE '%{diaActual}%'";

                //y lo retornamos
                //return dataView;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
                return null;
            }
        }


        public List<int> ObtenerProveedorIDDeDiasCompra(DateTime fechaActual)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                List<int>obtenerProveedorDeDiasCompra = new List<int>();
                string verificar = "SELECT ProveedorID " +
                                   "FROM DiasCompra " +
                                   "WHERE Fecha = @Fecha";
                using (SqlCommand comando = new SqlCommand(verificar, conn))
                {
                    comando.Parameters.AddWithValue("@Fecha", fechaActual);
                    using (SqlDataReader datareader = comando.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            int proveedorID = datareader.GetInt32(0);
                            obtenerProveedorDeDiasCompra.Add(proveedorID);
                        }
                        return obtenerProveedorDeDiasCompra;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public DataTable CargarTablaDiasCompra(DateTime FechaActual)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string consultar = "SELECT P.ProveedorID, P.NombreProveedor AS Proveedor, DC.Compra, DC.ImagenCompras AS Imagen " +
                                   "FROM DiasCompra AS DC " +
                                   "INNER JOIN Proveedores AS P ON DC.ProveedorID = P.ProveedorID " +
                                   "WHERE DC.Fecha = @fecha";
                //string consultar = "SELECT P.ProveedorID, P.NombreProveedor AS Proveedor, DC.Compra " +
                //                   "FROM DiasCompra AS DC " +
                //                   "INNER JOIN Proveedores AS P ON DC.ProveedorID = P.ProveedorID " +
                //                   "WHERE DC.Fecha = @fecha";
                using (SqlCommand comando = new SqlCommand(consultar, conn))
                {
                    comando.Parameters.AddWithValue("@fecha", FechaActual);
                    using (SqlDataReader sqlDataReader = comando.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(sqlDataReader);
                        return dt;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Hubo un erro {e}");
                return null;
            }
        }

        public int ConsultaProveedorExisteFechaHoy(DateTime fechaActualVerificar)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string verificarsiexiste = "SELECT COUNT(*) " +
                                           "FROM DiasCompra " +
                                           "WHERE Fecha = @fecha";
                //string verificarsiexiste = "SELECT P.NombreProveedor " +
                //                           "FROM DiasCompra AS DC " +
                //                           "INNER JOIN Proveedores AS P ON DC.ProveedorID = P.ProveedorID " +
                //                           "WHERE DC.Fecha = @fecha";
                using (SqlCommand comando = new SqlCommand(verificarsiexiste, conn))
                {
                    comando.Parameters.AddWithValue("@fecha", fechaActualVerificar);
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    return count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error {ex}");
                return 0;
            }
        }

        public void llenarTablaDiasCompra(List<int> proveedorID, DateTime fechaactual)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                foreach (int provedorID in proveedorID)
                {
                    string insertarProveedor = $"INSERT INTO DiasCompra(ProveedorID, Compra, Fecha, ImagenCompras) VALUES (@Proveedor, 0, @Fecha, null)";
                    using (SqlCommand insertar = new SqlCommand(insertarProveedor, conn))
                    {
                        insertar.Parameters.AddWithValue("@Proveedor", provedorID);
                        insertar.Parameters.AddWithValue("@Fecha", fechaactual);
                        insertar.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"hubo un error {e}");
            }
            finally
            {
                conn.Close();
            }
        }

        private bool VerificarSiExisteNombreProveedor(string nombreproveedor)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string verificar = "SELECT COUNT(NombreProveedor) " +
                                   "FROM Proveedores " +
                                   "WHERE NombreProveedor = @VerificarProveedor";
                using (SqlCommand insertar = new SqlCommand(verificar, conn))
                {
                    insertar.Parameters.AddWithValue("@VerificarProveedor", nombreproveedor);
                    int proveedor = Convert.ToInt32(insertar.ExecuteScalar());
                    if (proveedor > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            //finally { conn.Close(); }
        }
        

        //Metodo Agregar Proveedor
        public int AgregarProveedor(string Nombreproveedor, string Diavisita)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                if (VerificarSiExisteNombreProveedor(Nombreproveedor))
                {
                    string Agregarproveedor = $"INSERT INTO Proveedores(NombreProveedor, DiaVisita) VALUES('{Nombreproveedor}','{Diavisita}')";
                    SqlCommand agregar = new SqlCommand(Agregarproveedor, conn);
                    int resultado = agregar.ExecuteNonQuery();
                    if (resultado >= 1)
                    {
                        return resultado;
                    }
                    else
                    {
                        return resultado;
                    }
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception es)
            {
                MessageBox.Show($"Ocurrio un error {es}","Mensage del programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        //metodo Modificar proveedor
        public int ModificarProveedor(/*string NuevoProveedor, */string NuevoDia, string ProveedorAcambiar, string DiaVisitaAcambiar)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                //string modificar = $"UPDATE Proveedores SET NombreProveedor = '{NuevoProveedor}', DiaVisita = '{NuevoDia}' WHERE NombreProveedor = '{ProveedorAcambiar}' AND DiaVisita = '{DiaVisitaAcambiar}'";
                string modificar = $"UPDATE Proveedores SET DiaVisita = '{NuevoDia}' WHERE NombreProveedor = '{ProveedorAcambiar}' AND DiaVisita = '{DiaVisitaAcambiar}'";
                SqlCommand comando = new SqlCommand(modificar, conn);
                int resultado = Convert.ToInt32(comando.ExecuteScalar());
                conn.Close();
                return resultado;
            }
            catch (Exception es)
            {
                MessageBox.Show($"ocurrio un error{es}", "Mensaje del Programa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally { conn.Close(); }
        }


        //este metodo aun nose si lo usare
        public int BorrarProveedor(string proveedor, string diavisita)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string Borrar = $"DELETE FROM Proveedores WHERE NombreProveedor = '{proveedor}' AND DiaVisita = '{diavisita}'";
                SqlCommand comando = new SqlCommand(Borrar, conn);
                int resultado = Convert.ToInt32(comando.ExecuteScalar());
                conn.Close();
                return resultado;
            }
            catch (Exception o)
            {
                return 0;
            }
        }
        //este metodo aun nose si lo usare



        //aqui se ara el guardado de la imagen
        public void GuardarImagenProveedor(int idproveedor, DateTime fechaactual, string imagenguardar)
        {
            string guardarimagen = "UPDATE DiasCompra " +
                                   "SET ImagenCompras = @guardarImagen " +
                                   "WHERE ProveedorID = @idproveedor AND Fecha = @FechaActual";
            using (SqlCommand comando = new SqlCommand(guardarimagen, conn))
            {
                comando.Parameters.AddWithValue("@guardarImagen", imagenguardar);
                comando.Parameters.AddWithValue("@idproveedor", idproveedor);
                comando.Parameters.AddWithValue("@FechaActual", fechaactual);
                comando.ExecuteNonQuery();
            }

        }

        //
        public (int,string) VerificarImagenEnProveedor(DateTime fecha, int proveedorID)//este metodo aun nolo utilizo
        {
            //List<int> ObtenerProveedoresImagen = new List<int>();
            string verificarImagen = "SELECT ProveedorID AS Proveedor, ImagenCompras AS Imagen " +
                                     "FROM DiasCompra " +
                                     "WHERE ImagenCompras <> '' AND Fecha = @fechaVerificar AND ProveedorID = @proveedor";
            //string verificarImagen = "SELECT ProveedorID AS Proveedor, ImagenCompras AS Imagen " +
            //                         "FROM DiasCompra " +
            //                         "WHERE (ImagenCompras IS NULL OR ImagenCompras <> '') AND Fecha = @fechaVerificar AND ProveedorID = @proveedor";
            using (SqlCommand comando = new SqlCommand(verificarImagen, conn))
            {
                comando.Parameters.AddWithValue("@fechaVerificar", fecha);
                comando.Parameters.AddWithValue("@proveedor", proveedorID);
                using (SqlDataReader leer = comando.ExecuteReader())
                {
                    if (leer.Read())
                    {
                        int proveedor = Convert.ToInt32(leer["Proveedor"]);
                        string rutaimagen = leer["Imagen"].ToString();
                        return (proveedor, rutaimagen);
                    }
                    return (0, null);
                }
                //using (SqlDataReader datareader = comando.ExecuteReader())
                //{
                //    while (datareader.Read())
                //    {
                //        int proveedorID = datareader.GetInt32(0);
                //        ObtenerProveedoresImagen.Add(proveedorID);
                //    }
                //    return ObtenerProveedoresImagen;
                //}
            }
        }

        public void AgregarCompraTablaDiasCompra(int ProveedorID, DateTime fecha, double compra)
        {
            string agregarCompra = "UPDATE DiasCompra " +
                                   "SET Compra = @compraProveedor " +
                                   "WHERE ProveedorID = @Proveedor AND Fecha = @fecha";
            using (SqlCommand ejecutar = new SqlCommand(agregarCompra, conn))
            {
                ejecutar.Parameters.AddWithValue("@compraProveedor", compra);
                ejecutar.Parameters.AddWithValue("@Proveedor", ProveedorID);
                ejecutar.Parameters.AddWithValue("@fecha", fecha);
                ejecutar.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
