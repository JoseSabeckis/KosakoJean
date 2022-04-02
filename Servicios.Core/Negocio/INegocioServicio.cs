using Servicios.Core.Negocio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Negocio
{
    public interface INegocioServicio
    {
        void Insertar(NegocioDto negocioDto);

        void Modificar(NegocioDto negocioDto);

        NegocioDto ObtenerPorId(long id);
    }
}
