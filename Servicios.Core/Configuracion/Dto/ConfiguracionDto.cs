using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Configuracion.Dto
{
    public class ConfiguracionDto
    {
        public long Id { get; set; }

        public bool UsarLogin { get; set; }

        public bool UsarTicketera { get; set; }

        public bool MostrarDatos { get; set; }

    }
}
