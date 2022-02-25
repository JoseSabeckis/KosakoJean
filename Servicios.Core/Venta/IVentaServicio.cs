using Servicios.Core.Venta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Venta
{
    public interface IVentaServicio
    {
        long NuevaVenta(VentaDto ventaDto);

        IEnumerable<VentaDto> VentaPorCliente(long idCliente);

        IEnumerable<VentaDto> VentaPorClienteDesdeHasta(long clienteId, DateTime desde, DateTime hasta);

        IEnumerable<VentaDto> VentaPorClienteFecha(long clienteId, DateTime date);

        IEnumerable<VentaDto> VentaClientePedidos(long idCliente);

        IEnumerable<VentaDto> VentaPorClienteFechaPedido(long clienteId, DateTime date);

        IEnumerable<VentaDto> VentaPorClienteDesdeHastaPedido(long clienteId, DateTime desde, DateTime hasta);

        string ObtenerClienteName(long id);

        IEnumerable<VentaDto> BuscarPor30Dias();
    }
}
