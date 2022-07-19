using AccesoDatos;
using System;

namespace Servicios.Core.Caja.Dto
{
    public class CajaDto
    {
        public long Id { get; set; }

        public double TotalCaja { get; set; }

        public string TotalCajaString => TotalCaja.ToString("00.00");

        public double MontoApertura { get; set; }

        public string MontoAperturaString => MontoApertura.ToString("00.00");

        public double MontoCierre { get; set; }

        public string MontoCierreString => MontoCierre.ToString("00.00");

        public DateTime FechaApertura { get; set; }

        public string FechaCierre { get; set; }

        public OpenClose OpenClose { get; set; }

        public bool EstaEliminado { get; set; }

    }
}
