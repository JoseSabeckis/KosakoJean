using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.CtaCte.Dto
{
    public class CtaCteDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public decimal Total { get; set; }

        public decimal Debe { get; set; }

        public DateTime Fecha { get; set; }

        public CtaCteEstado Estado { get; set; }

        public long ClienteId { get; set; }


    }
}
