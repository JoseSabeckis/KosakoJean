using AccesoDatos;

namespace Servicios.Core.DetalleCaja.Dto
{
    public class DetalleCajaDto
    {
        public long Id { get; set; }

        public long NumeroOperacion { get; set; }

        public string NumeroOperacionVista => NumeroOperacion.ToString("00000");

        public string Descripcion { get; set; }

        public double Total { get; set; }

        public string TotalString => Total.ToString("00.00");

        public string Fecha { get; set; }

        public TipoPago TipoPago { get; set; }

        public TipoOperacion TipoOperacion { get; set; }

        public long CajaId { get; set; }

        public long ClienteId { get; set; }

        public long? PedidoId { get; set; }

        public long? ArregloId { get; set; }

        public bool EstaEliminado { get; set; }
    }
}
