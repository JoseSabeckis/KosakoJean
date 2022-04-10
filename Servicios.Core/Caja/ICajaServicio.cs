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
        CajaDto BuscarCajasId(long id);

        void SumarDineroACaja(decimal total);

        IEnumerable<CajaDto> BuscarCajas();

        AccesoDatos.Caja BuscarCajaAbierta();

        bool BuscarCajaAbiertaBool();

        void CerrarCaja(decimal montoCierre, string fechaCierre);

        void AbrirCaja(CajaDto cajaDto);

        IEnumerable<CajaDto> BuscarCajasPorApertura(DateTime desde, DateTime hasta);

        decimal SumarCaja();

        void RestarDineroDeCaja(decimal monto);

        IEnumerable<CajaDto> BuscarCajasPorMes();
    }
}
