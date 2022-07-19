using AccesoDatos;
using System;

namespace Servicios.Core.Producto_Venta.Dto
{
    public class Producto_Venta_Dto
    {
        public long Id { get; set; }

        public decimal Cantidad { get; set; }

        public string Talle { get; set; }

        public EstadoPedido Estado { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public long ProductoId { get; set; }

        public long? VentaId { get; set; }

        public long TalleId { get; set; }

        public DateTime Fecha { get; set; }
    }
}
