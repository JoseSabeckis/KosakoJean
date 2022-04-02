using Presentacion.Core.Negocio;
using Servicios.Core.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

                Bandera = negocio.EjecutarComandoNuevo();
            }
            else
            {
                Bandera = true;
            }

            if (Bandera)
            {
                Application.Run(new Principal());
            }
            
        }
    }
}
