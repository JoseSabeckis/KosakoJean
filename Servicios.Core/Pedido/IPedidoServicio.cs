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
        long NuevoPedido(PedidoDto pedidoDto);

        IEnumerable<PedidoDto> BuscandoTerminados();

        void CambiarRamas(decimal total, long id);

        AccesoDatos.Pedido Buscar(long id);

        IEnumerable<PedidoDto> BuscarRetiros();

        void CambiarProcesoRetiro(long id);

        void CambiarProcesoTerminado(long id);

        IEnumerable<PedidoDto> Buscar30Dias();

        IEnumerable<PedidoDto> BuscarPedidosNuevos();
    }
}
