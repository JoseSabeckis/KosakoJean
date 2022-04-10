using Servicios.Core.CtaCte.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
