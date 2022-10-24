using Servicios.Core.ParteVenta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.DetalleProducto
{
    public interface IDetalleProductoServicio
    {
        void Insertar(VentaDto2 detalleProductoDto);

        List<VentaDto2> ObtenerListaPorDetalleId(long detalleId);

        void EliminarTodoPorDetalleCajaId(long detalleCajaId);

    }
}
