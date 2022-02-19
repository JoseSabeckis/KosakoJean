using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.DetalleCaja.Dto
{
    public class DetalleCajaDto
    {
        public long Id { get; set; }

        public string Descripcion { get; set; }

        public decimal Total { get; set; }

        public string Fecha { get; set; }

        public TipoPago TipoPago{ get; set; }

        public long CajaId { get; set; }
    }
}
