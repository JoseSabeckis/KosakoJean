using Servicios.Core.Producto_Pedido.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Dato.Dto
{
    public interface IProducto_Dato_Servicio
    {
        void Insertar(Producto_Dato_Dto _Dto);

        Producto_Pedido_Dto ObtenerProductoPedidoPorId(long id);

        void CambiarEstadoTerminado(long id);

        void CambiarEstadoEnEspera(long id);

        void CambiarEstadoCancelado(long id);

        Producto_Dato_Dto ObtenerPorId(long id);

        List<Producto_Dato_Dto> ObtenerProductosPorPedidoId(long id);
    }
}
