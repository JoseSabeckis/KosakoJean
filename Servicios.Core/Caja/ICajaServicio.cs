﻿using Servicios.Core.Caja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Caja
{
    public interface ICajaServicio
    {
        CajaDto BuscarCajasId(long id);

        IEnumerable<CajaDto> BuscarCajas();

        long BuscarCajaAbierta();

        bool BuscarCajaAbiertaBool();

        void CerrarCaja(decimal montoCierre, DateTime fechaCierre);

        void AbrirCaja(CajaDto cajaDto);

        IEnumerable<CajaDto> BuscarCajasPorCierre(DateTime desde, DateTime hasta);

        IEnumerable<CajaDto> BuscarCajasPorApertura(DateTime desde, DateTime hasta);

        IEnumerable<CajaDto> BuscarCajasPorMes();

        decimal SumarCaja();
    }
}
