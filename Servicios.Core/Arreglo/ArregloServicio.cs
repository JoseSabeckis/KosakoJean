﻿using AccesoDatos;
using Servicios.Core.Arreglo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Arreglo
{
    public class ArregloServicio : IArregloServicio
    {
        public void Insertar(ArregloDto arregloDto)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = new AccesoDatos.Arreglo
                {
                    Adelanto = arregloDto.Adelanto,
                    Apellido = arregloDto.Apellido,
                    ClienteId = arregloDto.ClienteId,
                    Descripcion = arregloDto.Descripcion,
                    Estado = arregloDto.Estado,
                    FechaEntrega = arregloDto.FechaEntrega,
                    FechaPedido = arregloDto.FechaPedido,
                    Horario = arregloDto.Horario,
                    Nombre = arregloDto.Nombre,
                    Titulo = arregloDto.Titulo,
                    Total = arregloDto.Total
                };

                context.Arreglos.Add(arreglo);

                context.SaveChanges();
            }
        }

        public void ModificarDescripcion(long id, string descripcion)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = context.Arreglos.FirstOrDefault(x => x.Id == id);

                arreglo.Descripcion = descripcion;

                context.SaveChanges();

            }
        }

        public void CambiarARetiradoYFechaDeRetiro(long id, DateTime date)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = context.Arreglos.FirstOrDefault(x => x.Id == id);

                arreglo.Estado = EstadoArreglo.Retirado;
                arreglo.FechaRetirado = date;

                context.SaveChanges();

            }
        }

        public void Cobrar(long id, decimal dinero)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = context.Arreglos.FirstOrDefault(x => x.Id == id);

                arreglo.Adelanto += dinero;

                context.SaveChanges();

            }
        }

        public IEnumerable<ArregloDto> ListaArreglos()
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Arreglos.Where(x => !x.EstaEliminado)
                    .Select(x => new ArregloDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        Estado = x.Estado,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        FechaRetirado = x.FechaRetirado,
                        Horario = x.Horario,
                        Nombre = x.Nombre,
                        Titulo = x.Titulo,
                        Total = x.Total,
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public ArregloDto ObtenerPorId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = context.Arreglos.FirstOrDefault(x => x.Id == id);

                var listo = new ArregloDto
                {
                    Adelanto = arreglo.Adelanto,
                    Apellido = arreglo.Apellido,
                    ClienteId = arreglo.ClienteId,
                    Descripcion = arreglo.Descripcion,
                    Estado = arreglo.Estado,
                    EstaEliminado = arreglo.EstaEliminado,
                    FechaEntrega = arreglo.FechaEntrega,
                    FechaPedido = arreglo.FechaPedido,
                    FechaRetirado = arreglo.FechaRetirado,
                    Horario = arreglo.Horario,
                    Nombre = arreglo.Nombre,
                    Titulo = arreglo.Titulo,
                    Total = arreglo.Total,
                    Id = arreglo.Id
                };

                return listo;
            }
        }

        public void Eliminar(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = context.Arreglos.FirstOrDefault(x => x.Id == id);

                arreglo.EstaEliminado = true;

                context.SaveChanges();

            }
        }

        public void EliminarEnSerio(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = context.Arreglos.FirstOrDefault(x => x.Id == id);

                context.Arreglos.Remove(arreglo);

                context.SaveChanges();

            }
        }

    }
}
