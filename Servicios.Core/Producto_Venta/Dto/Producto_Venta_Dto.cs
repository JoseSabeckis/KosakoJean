using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Venta.Dto
{
    public class Producto_Venta_Dto
    {
        public long Id { get; set; }

        public decimal Cantidad { get; set; }

        public string Talle { get; set; }

        public EstadoPedido Estado { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public long ProductoId { get; set; }

        public long? VentaId { get; set; }
    }
}
