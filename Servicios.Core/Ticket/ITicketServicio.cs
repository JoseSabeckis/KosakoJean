using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Ticket
{
    public interface ITicketServicio
    {
        void ImprimirAutomaticamente(long _DetalleId, string impresora);
    }
}
