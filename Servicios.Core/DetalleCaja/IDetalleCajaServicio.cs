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
        void AgregarDetalleCaja(DetalleCajaDto detalleCajaDto);

        long BuscarCajaAbierta();
    }
}
