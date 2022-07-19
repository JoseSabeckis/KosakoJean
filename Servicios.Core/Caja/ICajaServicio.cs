using Servicios.Core.Caja.Dto;
using System;
using System.Collections.Generic;

namespace Servicios.Core.Caja
{
    public interface ICajaServicio
    {
        CajaDto BuscarCajasId(long id);

        void SumarDineroACaja(double total);

        IEnumerable<CajaDto> BuscarCajas();

        void RestarDineroACaja(long cajaId, double dinero);

        AccesoDatos.Caja BuscarCajaAbierta();

        bool BuscarCajaAbiertaBool();

        void EliminarCaja(long id);

        void CerrarCaja(double montoCierre, string fechaCierre);

        void AbrirCaja(CajaDto cajaDto);

        IEnumerable<CajaDto> BuscarCajasPorApertura(DateTime desde, DateTime hasta);

        double SumarCaja();

        void RestarDineroDeCaja(double monto);

        IEnumerable<CajaDto> BuscarCajasPorMes();
    }
}
