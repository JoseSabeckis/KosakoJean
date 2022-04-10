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

        IEnumerable<PedidoDto> Buscar(string busqueda);

        void CambiarProcesoRetirado(long id);

        void RestarAdelanto(decimal total, long id);

        void Eliminar(long id);
        void EliminacionDefinitiva(long id);
        void EliminacionDefinitivaLista();
        IEnumerable<PedidoDto> BuscandoRetiradosUltima();

        PedidoDto BuscarIDPedidos(long id);

        void CambiarFechaDatoRetiro(long id);

        void CambiarProcesoGuardado(long id);

        void SumarTotal(long id, decimal suma);

        void RestarTotal(long id, decimal resta);

        void RestarAdelanto(long id, decimal resta);

        IEnumerable<PedidoDto> BuscarRetirado();

        IEnumerable<PedidoDto> BuscarGuardados();

        IEnumerable<PedidoDto> BuscandoTerminadosUltima();

        IEnumerable<PedidoDto> BuscandoTerminadosyClientesFecha(long id, DateTime date);

        IEnumerable<PedidoDto> BuscandoTerminadosyClientesDesdeHasta(long id, DateTime desde, DateTime hasta);

        IEnumerable<PedidoDto> BuscandoTerminadosyClientes(long id);

        IEnumerable<PedidoDto> BuscandoTerminados();

        void CambiarFechaRetirado(long id);

        void CambiarRamas(decimal total, long id);

        AccesoDatos.Pedido Buscar(long id);

        IEnumerable<PedidoDto> BuscarRetiros();

        void CambiarProcesoRetiro(long id);

        void CambiarProcesoTerminado(long id);

        IEnumerable<PedidoDto> Buscar30Dias();

        IEnumerable<PedidoDto> BuscarPedidosNuevos();

        void GuardarDatosString(string datos, long id);
    }
}
