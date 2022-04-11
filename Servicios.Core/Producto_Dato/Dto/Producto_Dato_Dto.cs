using AccesoDatos;
using Servicios.Core.Colegio;
using Servicios.Core.Pedido;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido;

namespace Servicios.Core.Producto_Dato.Dto
{
    public class Producto_Dato_Dto
    {
        public IProducto_Pedido_Servicio producto_Pedido_Servicio = new Producto_Pedido_Servicio();
        public IProductoServicio producto_Servicio = new ProductoServicio();
        public IPedidoServicio pedidoServicio = new PedidoServicio();
        public IColegioServicio colegioServicio = new ColegioServicio();

        public long Id { get; set; }

        public EstadoPorPedido EstadoPorPedido { get; set; }

        public long Producto_PedidoId { get; set; }

        public string ProductoDescripcion => producto_Servicio.ObtenerPorId(producto_Pedido_Servicio.ObtenerPorId(Producto_PedidoId).ProductoId).Descripcion;
        public string ProductoDescripcionImpresion { get; set; }

        public string Colegio => colegioServicio.ObtenerPorId(producto_Servicio.ObtenerPorId(producto_Pedido_Servicio.ObtenerPorId(Producto_PedidoId).ProductoId).ColegioId).Descripcion;
        public string ColegioImpresion { get; set; }

        public string ProductoTalle => producto_Pedido_Servicio.ObtenerPorId(Producto_PedidoId).Talle;
        public string ProductoTalleImpresion { get; set; }

        public string Cliente => pedidoServicio.BuscarIDPedidos(producto_Pedido_Servicio.BuscarId_Producto_Pedido(Producto_PedidoId).PedidoId).Apellido + " " + pedidoServicio.BuscarIDPedidos(producto_Pedido_Servicio.BuscarId_Producto_Pedido(Producto_PedidoId).PedidoId).Nombre;
        public string ClienteImpresion { get; set; }

        public bool EstaEliminado { get; set; }

    }
}
