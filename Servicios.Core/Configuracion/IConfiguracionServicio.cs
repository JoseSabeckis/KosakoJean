using Servicios.Core.Configuracion.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Configuracion
{
    public interface IConfiguracionServicio
    {
        void Nuevo(ConfiguracionDto Dto);

        void Modificar(ConfiguracionDto Dto);

        ConfiguracionDto ObtenerPorId(long Id);
    }
}
