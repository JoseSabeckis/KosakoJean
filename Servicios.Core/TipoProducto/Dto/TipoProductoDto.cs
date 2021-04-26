using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.TipoProducto.Dto
{
    public class TipoProductoDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public bool EstaEliminado { get; set; }
    }
}
