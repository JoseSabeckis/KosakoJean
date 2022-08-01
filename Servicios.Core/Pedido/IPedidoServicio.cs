using Servicios.Core.Pedido.Dto;
using System;
using System.Collections.Generic;

namespace Servicios.Core.Pedido
{
    public interface IPedidoServicio
    {
        long NuevoPedido(PedidoDto pedidoDto);

        IEnumerable<PedidoDto> Buscar(string busqueda);

        IEnumerable<PedidoDto> BuscarEnInicio(string busqueda);
        IEnumerable<PedidoDto> BuscarEsPerandoRetiro(string busqueda);

        void CambiarProcesoRetirado(long id);

        void RestarAdelanto(double total, long id);

        void Eliminar(long id);
        void EliminacionDefinitiva(long id);
        void EliminacionDefinitivaLista();
        IEnumerable<PedidoDto> BuscandoRetiradosUltima();

        PedidoDto BuscarIDPedidos(long id);

        PedidoDto BuscarDto(long id);
        void CambiarFechaDatoRetiro(long id);

        void CambiarProcesoGuardado(long id);

        void SumarTotal(long id, double suma);

        void RestarTotal(long id, double resta);

        void RestarAdelanto(long id, double resta);

        IEnumerable<PedidoDto> BuscarRetirado();

        IEnumerable<PedidoDto> BuscarGuardados();

        IEnumerable<PedidoDto> BuscandoTerminadosUltima();

        IEnumerable<PedidoDto> BuscandoTerminadosyClientesFecha(long id, DateTime date);

        IEnumerable<PedidoDto> BuscandoTerminadosyClientesDesdeHasta(long id, DateTime desde, DateTime hasta);

        IEnumerable<PedidoDto> BuscandoTerminadosyClientes(long id);

        IEnumerable<PedidoDto> BuscandoTerminados(string descripcion);

        void CambiarFechaRetirado(long id);

        void CambiarRamas(double total, long id);

        AccesoDatos.Pedido Buscar(long id);

        IEnumerable<PedidoDto> BuscarRetiros();

        void CambiarProcesoRetiro(long id);

        void CambiarProcesoTerminado(long id);

        IEnumerable<PedidoDto> Buscar30Dias();

        IEnumerable<PedidoDto> BuscarPedidosNuevos();

        void GuardarDatosString(string datos, long id);
    }
}
