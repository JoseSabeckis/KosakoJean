using AccesoDatos;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
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
        private readonly IProductoServicio producto_Servicio = new ProductoServicio();
        private readonly IPedidoServicio pedidoServicio = new PedidoServicio();

        public long Id { get; set; }

        public EstadoPorPedido EstadoPorPedido { get; set; }

        public long Producto_PedidoId { get; set; } 

        public string ProductoDescripcion => producto_Servicio.ObtenerPorId(producto_Pedido_Servicio.ObtenerPorId(Producto_PedidoId).ProductoId).Descripcion;

        public string ProductoTalle => producto_Pedido_Servicio.ObtenerPorId(Producto_PedidoId).Talle;

        public string Cliente => pedidoServicio.BuscarIDPedidos(producto_Pedido_Servicio.BuscarId_Producto_Pedido(Producto_PedidoId).PedidoId).Apellido + " " + pedidoServicio.BuscarIDPedidos(producto_Pedido_Servicio.BuscarId_Producto_Pedido(Producto_PedidoId).PedidoId).Nombre;

    }
}
