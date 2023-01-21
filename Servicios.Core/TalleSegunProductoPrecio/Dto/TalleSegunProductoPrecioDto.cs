using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.TalleSegunProductoPrecio.Dto
{
    public class TalleSegunProductoPrecioDto
    {
        public long Id { get; set; }
        public long TalleId { get; set; }
        public long PrecioSegunTalleId { get; set; }
    }
}
