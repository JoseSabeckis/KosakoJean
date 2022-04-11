using System;

namespace Servicios.Core.Venta.Dto
{
    public class VentaDto
    {
        public long Id { get; set; }

        public decimal Total { get; set; }

        public decimal Descuento { get; set; }

        public DateTime Fecha { get; set; }

        public string FechaString => Fecha.ToLongDateString();

        public long ClienteId { get; set; }

    }
}
