using Servicios.Core.Usuario.Dto;
using System.Collections.Generic;

namespace Servicios.Core.Usuario
{
    public interface IUsuarioServicio
    {
        void Insertar(UsuarioDto usuarioDto);

        void ModificarUser(string user, long id);

        void ModificarPassword(string password, long id);

        void Bloquear(long id);

        void Desbloquear(long id);

        UsuarioDto ObtenerPorId(long id);

        IEnumerable<UsuarioDto> ListaUsuarios();
    }
}
