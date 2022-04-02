using AccesoDatos;
using Servicios.Core.Usuario.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Usuario
{
    public class UsuarioServicio
    {
        public void Insertar(UsuarioDto usuarioDto)
        {
            using(var context = new KosakoDBEntities())
            {
                var usuario = new AccesoDatos.Usuario
                {
                    User = usuarioDto.User,
                    Password = usuarioDto.Password,
                };

                context.Usuarios.Add(usuario);

                context.SaveChanges();
            }
        }

        public void ModificarUser(string user, long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);

                usuario.User = user;

                context.SaveChanges();
            }
        }

        public void ModificarPassword(string password, long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);

                usuario.Password = password;

                context.SaveChanges();
            }
        }

        public void Bloquear(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);

                usuario.Bloqueado = true;

                context.SaveChanges();
            }
        }

        public void Desbloquear(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);

                usuario.Bloqueado = false;

                context.SaveChanges();
            }
        }

        public UsuarioDto ObtenerPorId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);

                var user = new UsuarioDto
                {
                    User = usuario.User,
                    Password = usuario.Password,
                    Bloqueado = usuario.Bloqueado,
                    Id = usuario.Id,
                    EstaEliminado = usuario.EstaEliminado
                };

                return user;
            }
        }

        public IEnumerable<UsuarioDto> ListaUsuarios()
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Usuarios.Where(x => x.EstaEliminado == false)
                    .Select(x => new UsuarioDto
                    {
                        User = x.User,
                        Password = x.Password,
                        Bloqueado = x.Bloqueado,
                        EstaEliminado = x.EstaEliminado,
                        Id = x.Id

                    }).ToList();
            }
        }

    }
}
