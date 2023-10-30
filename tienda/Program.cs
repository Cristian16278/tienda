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
            //DateTime horaActual = DateTime.Now;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Provedores());
            //if (horaActual.Hour >= 22 && horaActual.Minute >= 0)
            //{
            //    Application.Run(new CuentasDiarias());//<---para que funcione bien todo tengo que poner: CuentasDiarias()
            //    //para que comiense bien en proveedores debo poner: Provedores()
            //}
            //else
            //{
            //    Application.Run(new Provedores());//<---para que funcione bien todo tengo que poner: Proveedores()
            //    //para que comiense bien en proveedores debo poner: Provedores()
            //}

        }
    }
}
