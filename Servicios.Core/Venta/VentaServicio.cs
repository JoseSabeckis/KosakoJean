﻿using AccesoDatos;
using Servicios.Core.Venta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Core.Venta
{
    public class VentaServicio : IVentaServicio
    {
        public long NuevaVenta(VentaDto ventaDto)
        {
            using (var context = new KosakoDBEntities())
            {

                var nueva = new AccesoDatos.Venta
                {
                    Descuento = ventaDto.Descuento,
                    Fecha = ventaDto.Fecha,
                    Total = ventaDto.Total,
                    ClienteId = ventaDto.ClienteId
                };

                context.Ventas.Add(nueva);

                context.SaveChanges();

                return nueva.Id;
            }
        }

        public IEnumerable<VentaDto> VentaPorCliente(long idCliente)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Ventas.Where(x => x.ClienteId == idCliente).Select(x => new VentaDto
                {
                    ClienteId = x.ClienteId,
                    Descuento = x.Descuento,
                    Fecha = x.Fecha,
                    Id = x.Id,
                    Total = x.Total

                }).ToList();

            }
        }

        public void EliminarVenta(long idVenta)
        {
            using (var context = new KosakoDBEntities())
            {

                var venta = context.Ventas.FirstOrDefault(x => x.Id == idVenta);

                //pendiente

            }
        }

        public IEnumerable<VentaDto> VentaClientePedidos(long idCliente)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.ClienteId == idCliente).Select(x => new VentaDto
                {
                    ClienteId = x.ClienteId,
                    Id = x.Id,
                    Total = x.Total,
                    Fecha = x.FechaPedido

                }).ToList();

            }
        }

        public IEnumerable<VentaDto> VentaPorClienteDesdeHasta(long clienteId, DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Ventas.Where(x => x.Fecha.Day >= desde.Day && x.Fecha.Month >= desde.Month && x.Fecha.Year >= desde.Year && x.Fecha.Year <= hasta.Year && x.Fecha.Month <= hasta.Month && x.Fecha.Day <= hasta.Day
                && x.ClienteId == clienteId).Select(x => new VentaDto
                {
                    ClienteId = x.ClienteId,
                    Descuento = x.Descuento,
                    Fecha = x.Fecha,
                    Id = x.Id,
                    Total = x.Total

                }).ToList();
            }
        }

        public IEnumerable<VentaDto> VentaPorClienteDesdeHastaPedido(long clienteId, DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.FechaPedido.Day >= desde.Day && x.FechaPedido.Month >= desde.Month && x.FechaPedido.Year >= desde.Year && x.FechaPedido.Year <= hasta.Year && x.FechaPedido.Month <= hasta.Month && x.FechaPedido.Day <= hasta.Day
                && x.ClienteId == clienteId).Select(x => new VentaDto
                {
                    ClienteId = x.ClienteId,
                    Fecha = x.FechaPedido,
                    Id = x.Id,
                    Total = x.Total

                }).ToList();

            }
        }

        public IEnumerable<VentaDto> VentaPorClienteFecha(long clienteId, DateTime date)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Ventas.Where(x => x.Fecha.Day == date.Day && x.Fecha.Month == date.Month && x.Fecha.Year == date.Year && x.ClienteId == clienteId).Select(x => new VentaDto
                {
                    ClienteId = x.ClienteId,
                    Descuento = x.Descuento,
                    Fecha = x.Fecha,
                    Id = x.Id,
                    Total = x.Total

                }).ToList();
            }
        }

        public IEnumerable<VentaDto> VentaPorClienteFechaPedido(long clienteId, DateTime date)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.FechaPedido.Day == date.Day && x.FechaPedido.Month == date.Month && x.FechaPedido.Year == date.Year && x.ClienteId == clienteId).Select(x => new VentaDto
                {
                    ClienteId = x.ClienteId,
                    Fecha = x.FechaPedido,
                    Id = x.Id,
                    Total = x.Total

                }).ToList();

            }
        }

        public string ObtenerClienteName(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var cliente = context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == id);

                string client = " .";

                if (cliente != null)
                {
                    client = cliente.Apellido + " " + cliente.Nombre;
                }


                if (client == " .")
                {

                    client = string.Empty;

                    return client;

                }
                else
                {
                    return client;
                }

            }
        }

        public IEnumerable<VentaDto> BuscarPor30Dias()
        {
            using (var context = new KosakoDBEntities())
            {
                var fecha = DateTime.Now;
                fecha.AddDays(-30);

                return context.Ventas.AsNoTracking().Where(x => x.Fecha >= fecha)
                    .Select(x => new VentaDto
                    {

                        Descuento = x.Descuento,
                        Fecha = x.Fecha,
                        Total = x.Total

                    }).ToList();
            }
        }
    }
}
