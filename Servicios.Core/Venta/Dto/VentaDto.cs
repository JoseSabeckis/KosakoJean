using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Venta.Dto
{
    public class VentaDto
    {
        public long Id { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }

        public DateTime Fecha { get; set; }

        public long ClienteId { get; set; }

    }
}
