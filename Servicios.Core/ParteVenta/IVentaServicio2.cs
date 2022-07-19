using Servicios.Core.ParteVenta.Dto;
using System.Collections.Generic;

namespace Servicios.Core.ParteVenta
{
    public interface IVentaServicio2
    {
        void InsertarProducto(string descripcion, double precio, int cantidad);

        List<VentaDto2> Obtener(string cadenaBuscar);

        VentaDto2 ObtenerPorCodigo(string codigo);

        void ReiniciarListaDeLaGrilla();

    }
}
