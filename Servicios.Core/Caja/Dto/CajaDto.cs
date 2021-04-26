using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Caja.Dto
{
    public class CajaDto
    {
        public long Id { get; set; }

        public decimal TotalCaja { get; set; }

        public decimal MontoApertura { get; set; }

        public decimal MontoCierre { get; set; }

        public DateTime FechaApertura { get; set; }

        public DateTime FechaCierre { get; set; }

        public OpenClose OpenClose { get; set; }
    }
}
