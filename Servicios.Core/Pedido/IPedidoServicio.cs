using Servicios.Core.Pedido.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Pedido
{
    public interface IPedidoServicio
    {
        void NuevoPedido(PedidoDto pedidoDto);

        IEnumerable<PedidoDto> Buscar30Dias();
    }
}
