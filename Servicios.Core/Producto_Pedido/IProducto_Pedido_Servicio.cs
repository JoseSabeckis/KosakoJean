using Servicios.Core.Producto_Pedido.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Pedido
{
    public interface IProducto_Pedido_Servicio
    {
        long NuevoProductoPedido(Producto_Pedido_Dto producto);

        List<long> BuscarProductoEnPedidos(long productoId);

        List<Producto_Pedido_Dto> Eliminar(long pedidoid);

        Producto_Pedido_Dto BuscarPedidoId2(long id);

        List<Producto_Pedido_Dto> BuscarPedidoId(long id);

        List<Producto_Pedido_Dto> BuscarPedidoTerminado(long id);

        List<Producto_Pedido_Dto> BuscarPedidoGuardado(long id);

        List<Producto_Pedido_Dto> BuscarPedidoRetirado(long id);

        Producto_Pedido_Dto ObtenerPorId(long id);

        void RestarCantidad1(long id);

        Producto_Pedido_Dto BuscarId_Producto_Pedido(long producto_pedido_id);

        void EliminacionDefinitiva(long id);

        void EliminacionDefinitivaLista();

        void CambiarEstado(long id);

        List<Producto_Pedido_Dto> Buscar();

        List<Producto_Pedido_Dto> BuscarId(long id);
    }
}
