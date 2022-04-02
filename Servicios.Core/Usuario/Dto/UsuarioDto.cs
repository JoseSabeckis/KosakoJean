using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Usuario.Dto
{
    public class UsuarioDto
    {
        public long Id { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public bool Bloqueado { get; set; }

        public bool EstaEliminado { get; set; }

    }
}
