using Servicios.Core.DetalleCaja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.DetalleCaja
{
    public interface IDetalleCajaServicio
    {
        IEnumerable<DetalleCajaDto> Lista(long cajaId);

        void AgregarDetalleCaja(DetalleCajaDto detalleCajaDto);

        IEnumerable<DetalleCajaDto> BuscarDetalles(long id);

        long BuscarCajaAbierta();
    }
}
