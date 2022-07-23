using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Ticket
{
    public interface ITicketServicio
    {
        void ImprimirAutomaticamenteVenta(long _DetalleId, string impresora, long clienteId);
        void ImprimirAutomaticamentePedido(long _DetalleId, string impresora, long clienteId, long? pedidoId);
        void ImprimirAutomaticamenteArreglo(long _DetalleId, string impresora, long? pedidoId);
    }
}
