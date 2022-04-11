using Presentacion.Core.Negocio;
using Servicios.Core.Negocio;
using System;
using System.Windows.Forms;

namespace KosakoJean
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            INegocioServicio negocioServicio = new NegocioServicio();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool Bandera = false;

            if (negocioServicio.ObtenerPorId(1) == null)
            {
                var negocio = new Negocio_Abm(Presentacion.Clases.TipoOperacion.Nuevo);
                negocio.ShowDialog();

                Bandera = negocio.RealizoAlgunaOperacion;
            }
            else
            {
                Bandera = true;
            }

            if (Bandera)
            {
                Application.Run(new Principal());
            }
            else
            {
                Application.Exit();
            }

        }
    }
}
