﻿using Servicios.Core.DetalleCaja.Dto;
using System.Collections.Generic;

namespace Servicios.Core.DetalleCaja
{
    public interface IDetalleCajaServicio
    {
        IEnumerable<DetalleCajaDto> Lista(long cajaId);

        void ListaParaEliminar(IEnumerable<DetalleCajaDto> lista);

        long AgregarDetalleCaja(DetalleCajaDto detalleCajaDto);

        double BuscarDetallePorId(long detalleId);

        IEnumerable<DetalleCajaDto> BuscarDetalles(long id);

        DetalleCajaDto ObtenerPorId(long detalleId);

        long BuscarCajaAbierta();

        IEnumerable<DetalleCajaDto> BuscarDetallesNumerosOperacion(string numeroOperacion);

        DetalleCajaDto BuscarDetalleConArregloId(long id);
        DetalleCajaDto BuscarDetalleConPedidoId(long id);

        DetalleCajaDto BuscarDetalleConCtaCteId(long id);

        void EliminarUnaVenta(long id);

        string TraerNuevoNumeroOperacion();
    }
}
