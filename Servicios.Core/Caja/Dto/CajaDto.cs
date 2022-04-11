using AccesoDatos;
using System;

namespace Servicios.Core.Caja.Dto
{
    public class CajaDto
    {
        public long Id { get; set; }

        public decimal TotalCaja { get; set; }

        public decimal MontoApertura { get; set; }

        public decimal MontoCierre { get; set; }

        public DateTime FechaApertura { get; set; }

        public string FechaCierre { get; set; }

        public OpenClose OpenClose { get; set; }

    }
}
