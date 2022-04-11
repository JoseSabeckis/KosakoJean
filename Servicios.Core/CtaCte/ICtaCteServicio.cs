using Servicios.Core.CtaCte.Dto;
using System.Collections.Generic;

namespace Servicios.Core.CtaCte
{
    public interface ICtaCteServicio
    {
        void Agregar(CtaCteDto ctaCteDto);

        void Pagar(decimal monto, long clienteId, long cuentaId);

        IEnumerable<CtaCteDto> Lista(long clienteId);

        CtaCteDto ObtenerPorId(long ctaId);

        CtaCteDto ObtenerPorIdDePedidosId(long pedidoId);

        void SumarLoQueDebe(decimal monto, long clienteId, long cuentaId);
    }
}
