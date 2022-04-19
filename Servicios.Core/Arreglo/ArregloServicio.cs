using AccesoDatos;
using Servicios.Core.Arreglo.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void CambiarAEnEsperaYFechaDeRetiro(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = context.Arreglos.FirstOrDefault(x => x.Id == id);

                arreglo.Estado = EstadoArreglo.EnEspera;

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

        public void GuardarDescripcion(long id, string descripcion)
        {
            using (var context = new KosakoDBEntities())
            {
                var arreglo = context.Arreglos.FirstOrDefault(x => x.Id == id);

                arreglo.Descripcion = descripcion;

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
                        Total = x.Total,
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public IEnumerable<ArregloDto> ListaArreglosEnEspera()
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Arreglos.Where(x => x.Estado == EstadoArreglo.EnEspera)
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
                        Total = x.Total,
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public IEnumerable<ArregloDto> ListaArreglosEnEsperaBusqueda(string descripcion)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Arreglos.Where(x => x.Estado == EstadoArreglo.EnEspera && x.Apellido.Contains(descripcion) || x.Estado == EstadoArreglo.EnEspera && x.Nombre.Contains(descripcion))
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
                        Total = x.Total,
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public IEnumerable<ArregloDto> ListaArreglosRetiradosBusqueda(string descripcion)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Arreglos.Where(x => x.Estado == EstadoArreglo.Retirado && x.Apellido.Contains(descripcion) || x.Estado == EstadoArreglo.Retirado && x.Nombre.Contains(descripcion))
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
                        Total = x.Total,
                        Id = x.Id,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public IEnumerable<ArregloDto> ListaArreglosRetirados()
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Arreglos.Where(x => x.Estado == EstadoArreglo.Retirado)
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
