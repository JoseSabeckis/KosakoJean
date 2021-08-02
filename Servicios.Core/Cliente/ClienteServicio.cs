﻿using AccesoDatos;
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
                    Telefono = Dto.Telefono
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

                context.SaveChanges();

            }
        }

        public IEnumerable<ClienteDto> Buscar(string cadenaBuscar)
        {
            using (var context = new KosakoDBEntities())
            {
                var productos = context.Clientes.AsNoTracking().Where(x => x.Apellido.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new ClienteDto
                    {

                        Id = x.Id,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Direccion = x.Direccion,
                        Telefono = x.Telefono,
                        EstaEliminado = x.EstaEliminado

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
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == colegioId && x.EstaEliminado == false);
            }
        }

    }

}