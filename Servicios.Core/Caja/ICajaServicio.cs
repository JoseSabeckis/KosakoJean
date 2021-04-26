using Servicios.Core.Caja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Caja
{
    public interface ICajaServicio
    {
        IEnumerable<CajaDto> BuscarCajas();

        long BuscarCajaAbierta();

        void CerrarCaja(decimal montoCierre, DateTime fechaCierre);

        void AbrirCaja(CajaDto cajaDto);

        IEnumerable<CajaDto> BuscarCajasPorCierre(DateTime cierre);

        IEnumerable<CajaDto> BuscarCajasPorApertura(DateTime apertura);

        IEnumerable<CajaDto> BuscarCajasPorMes();
    }
}
