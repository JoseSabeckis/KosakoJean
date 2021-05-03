using AccesoDatos;
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
                    Nombre = pedidoDto.Nombre,
                    FechaEntrega = pedidoDto.FechaEntrega,
                    FechaPedido = pedidoDto.FechaPedido,
                    Total = pedidoDto.Total,
                    Proceso = pedidoDto.Proceso
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
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso

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
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso

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
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso

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
