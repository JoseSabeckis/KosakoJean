using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.PrecioSegunTalle.Dto
{
    public class PrecioSegunTalleDto
    {
        public long Id { get; set; }

        public decimal Precio { get; set; }

        public long ProductoId { get; set; }

        public long TalleId { get; set; }

        public bool EstaEliminado { get; set; }

    }
}
