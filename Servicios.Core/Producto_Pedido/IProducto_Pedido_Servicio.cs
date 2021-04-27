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

        void CambiarEstado(long id);
    }
}
