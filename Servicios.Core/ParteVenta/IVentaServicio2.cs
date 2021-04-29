using Servicios.Core.ParteVenta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.ParteVenta
{
    public interface IVentaServicio2
    {
        void InsertarProducto(string descripcion, decimal precio, int cantidad);

        List<VentaDto2> Obtener(string cadenaBuscar);

        VentaDto2 ObtenerPorCodigo(string codigo);

        void ReiniciarListaDeLaGrilla();

    }
}
