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
        void NuevoProductoPedido(Producto_Pedido_Dto producto);

        Producto_Pedido_Dto BuscarPedidoId2(long id);

        List<Producto_Pedido_Dto> BuscarPedidoId(long id);

        List<Producto_Pedido_Dto> BuscarPedidoTerminado(long id);

        List<Producto_Pedido_Dto> BuscarPedidoGuardado(long id);

        List<Producto_Pedido_Dto> BuscarPedidoRetirado(long id);

        void CambiarEstado(long id);

        List<Producto_Pedido_Dto> Buscar();

        List<Producto_Pedido_Dto> BuscarId(long id);
    }
}
