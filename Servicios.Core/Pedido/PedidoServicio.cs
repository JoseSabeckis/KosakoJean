﻿using AccesoDatos;
using Servicios.Core.Pedido.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Pedido
{
    public class PedidoServicio : IPedidoServicio
    {
        public long NuevoPedido(PedidoDto pedidoDto)
        {
            using(var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.Pedido
                {
                    Adelanto = pedidoDto.Adelanto,
                    Apellido = pedidoDto.Apellido,
                    Nombre = pedidoDto.Apellido,
                    FechaEntrega = pedidoDto.FechaEntrega,
                    FechaPedido = pedidoDto.FechaPedido,
                    Total = pedidoDto.Total,
                    Proceso = pedidoDto.Proceso,
                    ClienteId = pedidoDto.ClienteId,
                    ApyNom = pedidoDto.Apellido
                };

                context.Pedidos.Add(nuevo);

                context.SaveChanges();

                return nuevo.Id;
            }
        }

        public IEnumerable<PedidoDto> Buscar30Dias()
        {
            using (var context = new KosakoDBEntities())
            {
                var fecha = DateTime.Now;
                fecha.AddDays(-30);

                return context.Pedidos.AsNoTracking().Where(x => x.FechaPedido >= fecha)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Apellido,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId,
                        

                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscarPedidosNuevos()
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.Proceso == Proceso.InicioPedido)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Apellido,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId

                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscarRetiros()
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.Proceso == Proceso.EsperandoRetiro)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Apellido,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId

                    }).ToList();

            }
        }

        public PedidoDto BuscarIDPedidos(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var aux = context.Pedidos.FirstOrDefault(x => x.Id == id);

                    var aux2 = new PedidoDto
                    {
                        Adelanto = aux.Adelanto,
                        Apellido = aux.Apellido,
                        Nombre = aux.Apellido,
                        FechaEntrega = aux.FechaEntrega,
                        FechaPedido = aux.FechaPedido,
                        Total = aux.Total,
                        Id = aux.Id,
                        Proceso = aux.Proceso,
                        ClienteId = aux.ClienteId

                    };
                return aux2;
            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminados()
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.Proceso == Proceso.PedidoTerminado)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Apellido,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId

                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminadosyClientes(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.ClienteId == id && x.Proceso == Proceso.PedidoTerminado)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Apellido,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId

                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminadosyClientesDesdeHasta(long id, DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.FechaEntrega.Day >= desde.Day && x.FechaEntrega.Month >= desde.Month && x.FechaEntrega.Year >= desde.Year && x.FechaEntrega.Year <= hasta.Year && x.FechaEntrega.Month <= hasta.Month && x.FechaEntrega.Day <= hasta.Day && x.ClienteId == id && x.Proceso == Proceso.PedidoTerminado)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Apellido,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId

                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminadosyClientesFecha(long id, DateTime date)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.FechaEntrega.Day == date.Day && x.FechaEntrega.Month == date.Month && x.FechaEntrega.Year == date.Year && x.ClienteId == id && x.Proceso == Proceso.PedidoTerminado)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Apellido,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId

                    }).ToList();

            }
        }

        public AccesoDatos.Pedido Buscar(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Pedidos.FirstOrDefault(x => x.Id == id);
            }
        }

        public void CambiarProcesoRetiro(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Proceso = Proceso.EsperandoRetiro;

                context.SaveChanges();

            }
        }

        public void CambiarRamas(decimal total, long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Adelanto += total;

                context.SaveChanges();

            }
        }

        public void CambiarProcesoTerminado(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Proceso = Proceso.PedidoTerminado;

                context.SaveChanges();

            }
        }

    }
}
