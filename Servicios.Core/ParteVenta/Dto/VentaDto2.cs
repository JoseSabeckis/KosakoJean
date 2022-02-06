using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.ParteVenta.Dto
{
    public class VentaDto2
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Cantidad { get; set; }

        public decimal Precio { get; set; }

        public string Talle { get; set; }
    }
}
