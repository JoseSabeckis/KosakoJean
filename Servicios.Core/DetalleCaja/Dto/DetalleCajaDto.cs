using AccesoDatos;

namespace Servicios.Core.DetalleCaja.Dto
{
    public class DetalleCajaDto
    {
        public long Id { get; set; }

        public long NumeroOperacion { get; set; }

        public string Descripcion { get; set; }

        public decimal Total { get; set; }

        public string TotalString => Total.ToString("00.00");

        public string Fecha { get; set; }

        public TipoPago TipoPago { get; set; }

        public long CajaId { get; set; }

        public bool EstaEliminado { get; set; }
    }
}
