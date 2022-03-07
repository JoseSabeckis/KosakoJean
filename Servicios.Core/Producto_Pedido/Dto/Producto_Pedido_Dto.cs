using AccesoDatos;
using Servicios.Core.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Pedido.Dto
{
    public class Producto_Pedido_Dto
    {
        IProductoServicio productoServicio = new ProductoServicio();

        public long Id { get; set; }

        public decimal Cantidad { get; set; }

        public string Talle { get; set; }

        public long TalleId { get; set; }

        public EstadoPedido Estado { get; set; }

        public string Descripcion { get; set; }

        public long PedidoId { get; set; }

        public long ProductoId { get; set; }

        public string ProductoDescripcion => productoServicio.ObtenerPorId(ProductoId).Descripcion;

    }
}
