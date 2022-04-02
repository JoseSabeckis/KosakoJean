using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Usuario.Dto
{
    public static class UsuarioLogeado
    {
        public static long Id { get; set; }

        public static string User { get; set; }

        public static string Password { get; set; }

        public static bool Bloqueado { get; set; }

        public static bool EstaEliminado { get; set; }
    }
}
