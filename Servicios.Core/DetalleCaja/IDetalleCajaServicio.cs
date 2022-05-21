using Servicios.Core.DetalleCaja.Dto;
using System.Collections.Generic;

namespace Servicios.Core.DetalleCaja
{
    public interface IDetalleCajaServicio
    {
        IEnumerable<DetalleCajaDto> Lista(long cajaId);

        void ListaParaEliminar(IEnumerable<DetalleCajaDto> lista);

        void AgregarDetalleCaja(DetalleCajaDto detalleCajaDto);

        IEnumerable<DetalleCajaDto> BuscarDetalles(long id);

        long BuscarCajaAbierta();
    }
}
