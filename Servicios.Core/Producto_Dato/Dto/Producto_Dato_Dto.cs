using AccesoDatos;
using Servicios.Core.Producto_Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Dato.Dto
{
    public class Producto_Dato_Dto
    {
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio = new Producto_Pedido_Servicio();

        public long Id { get; set; }

        public EstadoPorPedido EstadoPorPedido { get; set; }

        public long Producto_PedidoId { get; set; }

        public string ProductoDescripcion => producto_Pedido_Servicio.ObtenerPorId(Producto_PedidoId).Descripcion;

        public string ProductoTalle => producto_Pedido_Servicio.ObtenerPorId(Producto_PedidoId).Talle;

    }
}
