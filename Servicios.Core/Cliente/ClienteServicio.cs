using AccesoDatos;
using Servicios.Core.Cliente.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Cliente
{
    public class ClienteServicio : IClienteServicio
    {
        public void Nuevo(ClienteDto Dto)
        {
            
            using (var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.Cliente
                {
                    Apellido = Dto.Apellido,
                    Nombre = Dto.Nombre,
                    Direccion = Dto.Direccion,
                    Telefono = Dto.Telefono,
                    Foto = Dto.Foto,
                    Principal = Dto.Principal
                };

                context.Clientes.Add(nuevo);

                context.SaveChanges();
            }
            
        }

        public void Eliminar(long id)
        {

            using (var context = new KosakoDBEntities())
            {
                var producto = context.Clientes.FirstOrDefault(x => x.Id == id);

                producto.EstaEliminado = true;

            }

        }

        public void Modificar(ClienteDto Dto)
        {
            using (var context = new KosakoDBEntities())
            {

                var producto = context.Clientes.FirstOrDefault(x => x.Id == Dto.Id);

                producto.Apellido = Dto.Apellido;
                producto.Nombre = Dto.Nombre;
                producto.Direccion = Dto.Direccion;
                producto.Telefono = Dto.Telefono;
                producto.Foto = Dto.Foto;
                producto.Principal = Dto.Principal;

                context.SaveChanges();

            }
        }

        public IEnumerable<ClienteDto> Buscar(string cadenaBuscar)
        {
            using (var context = new KosakoDBEntities())
            {
                var productos = context.Clientes.AsNoTracking().OrderBy(x => x.Apellido.Contains(cadenaBuscar) && x.EstaEliminado == false && x.Principal == false|| x.Nombre.Contains(cadenaBuscar) && x.EstaEliminado == false && x.Principal == false)
                    .Select(x => new ClienteDto
                    {

                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Direccion = x.Direccion,
                        Telefono = x.Telefono,
                        EstaEliminado = x.EstaEliminado,
                        Foto = x.Foto,
                        Principal = x.Principal

                    }).ToList();


                return productos;
            }

        }

        public ClienteDto ObtenerPorId(long colegioId)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Clientes
                    .AsNoTracking()
                    .Select(x => new ClienteDto
                    {
                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Direccion = x.Direccion,
                        Telefono = x.Telefono,
                        EstaEliminado = x.EstaEliminado,
                        Foto = x.Foto,
                        Principal = x.Principal

                    }).FirstOrDefault(x => x.Id == colegioId && x.EstaEliminado == false);
            }
        }

        public void PasarPrincipal(long clienteId)
        {
            using (var context = new KosakoDBEntities())
            {
                var cliente = context.Clientes.FirstOrDefault(x => x.Id == clienteId);

                if (cliente.Principal == false)
                {
                    cliente.Principal = true;
                }
                else
                {
                    cliente.Principal = false;
                }

            }
        }

    }

}
