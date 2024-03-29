using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConectarBD conectarBD = new ConectarBD();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //aqui hay que aplicar una logica para abrir un formulario dependiendo si ya se hicieron las cuentas diarias
            DateTime Fechaactual = DateTime.Now.Date;
            int resultado = conectarBD.TraerNetoExistenteDiaAnterior(Fechaactual);
            if (resultado == 0)//si el resultado es '0' se abrira el formulario de "Provedores".
            {
                Application.Run(new Provedores());//<---para que funcione bien todo tengo que poner: Provedores()
            }
            else//en caso contrario se abrira el formulario de "CuentasDiarias"
            {
                Application.Run(new CuentasDiarias());
            }
        }
    }
}
