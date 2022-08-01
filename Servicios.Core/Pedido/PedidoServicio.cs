using AccesoDatos;
using Servicios.Core.Pedido.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Core.Pedido
{
    public class PedidoServicio : IPedidoServicio
    {
        public long NuevoPedido(PedidoDto pedidoDto)
        {
            using (var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.Pedido
                {
                    Adelanto = pedidoDto.Adelanto,
                    Apellido = pedidoDto.Apellido,
                    Nombre = pedidoDto.Nombre,
                    FechaEntrega = pedidoDto.FechaEntrega,
                    FechaPedido = pedidoDto.FechaPedido,
                    Total = pedidoDto.Total,
                    Proceso = pedidoDto.Proceso,
                    ClienteId = pedidoDto.ClienteId,
                    ApyNom = $"{pedidoDto.Apellido} {pedidoDto.Nombre}",
                    Descripcion = pedidoDto.Descripcion,
                    Horario = pedidoDto.Horario,
                    DiasHastaRetiro = pedidoDto.DiasHastaRetiro,
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

                return context.Pedidos.AsNoTracking().Where(x => x.FechaPedido >= fecha && x.EstaEliminado == false)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        FechaRetiro = x.FechaRetirado,
                        Horario = x.Horario,
                        DiasHastaRetiro = x.DiasHastaRetiro,
                        FechaIniciado = x.FechaPedido,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> Buscar(string busqueda)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.AsNoTracking().Where(x => x.Apellido.Contains(busqueda) && x.EstaEliminado == false)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        FechaRetiro = x.FechaRetirado,
                        Horario = x.Horario,
                        DiasHastaRetiro = x.DiasHastaRetiro,
                        FechaIniciado = x.FechaPedido,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscarEnInicio(string busqueda)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.AsNoTracking().Where(x => x.ApyNom.Contains(busqueda) && x.Proceso == Proceso.InicioPedido && x.EstaEliminado == false)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        FechaRetiro = x.FechaRetirado,
                        Horario = x.Horario,
                        DiasHastaRetiro = x.DiasHastaRetiro,
                        FechaIniciado = x.FechaPedido,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscarEsPerandoRetiro(string busqueda)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.AsNoTracking().Where(x => x.ApyNom.Contains(busqueda) && x.Proceso == Proceso.EsperandoRetiro && x.EstaEliminado == false)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        FechaRetiro = x.FechaRetirado,
                        Horario = x.Horario,
                        DiasHastaRetiro = x.DiasHastaRetiro,
                        FechaIniciado = x.FechaPedido,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();

            }
        }

        public void Eliminar(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var eliminado = context.Pedidos.FirstOrDefault(x => x.Id == id);

                eliminado.EstaEliminado = true;

                context.SaveChanges();
            }
        }

        public void EliminacionDefinitiva(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var dato = context.Pedidos.FirstOrDefault(x => x.Id == id);

                context.Pedidos.Remove(dato);

                context.SaveChanges();
            }
        }

        public void EliminacionDefinitivaLista()
        {
            using (var context = new KosakoDBEntities())
            {
                var datos = context.Pedidos.Where(x => x.EstaEliminado == true).ToList();

                foreach (var item in datos)
                {
                    context.Pedidos.Remove(item);
                }

                context.SaveChanges();
            }
        }

        public IEnumerable<PedidoDto> BuscarPedidosNuevos()
        {
            using (var context = new KosakoDBEntities())
            {

                var lista = context.Pedidos.Where(x => x.Proceso == Proceso.InicioPedido && x.EstaEliminado == false);


                return lista.OrderBy(x => x.FechaEntrega).Select(x => new PedidoDto
                {
                    Adelanto = x.Adelanto,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    FechaEntrega = x.FechaEntrega,
                    FechaPedido = x.FechaPedido,
                    Total = x.Total,
                    Id = x.Id,
                    Proceso = x.Proceso,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    FechaRetiro = x.FechaRetirado,
                    Horario = x.Horario,
                    DiasHastaRetiro = x.DiasHastaRetiro,
                    FechaIniciado = x.FechaPedido,
                    EstaEliminado = x.EstaEliminado
                }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscarRetiros()
        {
            using (var context = new KosakoDBEntities())
            {

                var lista = context.Pedidos.Where(x => x.Proceso == Proceso.EsperandoRetiro && x.EstaEliminado == false);


                return lista.OrderBy(x => x.FechaEntrega).Select(x => new PedidoDto
                {
                    Adelanto = x.Adelanto,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    FechaEntrega = x.FechaEntrega,
                    FechaPedido = x.FechaPedido,
                    Total = x.Total,
                    Id = x.Id,
                    Proceso = x.Proceso,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    FechaRetiro = x.FechaRetirado,
                    Horario = x.Horario,
                    DiasHastaRetiro = x.DiasHastaRetiro,
                    FechaIniciado = x.FechaPedido,
                    EstaEliminado = x.EstaEliminado
                }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscarGuardados()
        {
            using (var context = new KosakoDBEntities())
            {

                var lista = context.Pedidos.Where(x => x.Proceso == Proceso.Guardado && x.EstaEliminado == false);


                return lista.OrderBy(x => x.FechaEntrega).Select(x => new PedidoDto
                {
                    Adelanto = x.Adelanto,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    FechaEntrega = x.FechaEntrega,
                    FechaPedido = x.FechaPedido,
                    Total = x.Total,
                    Id = x.Id,
                    Proceso = x.Proceso,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    FechaRetiro = x.FechaRetirado,
                    Horario = x.Horario,
                    DiasHastaRetiro = x.DiasHastaRetiro,
                    FechaIniciado = x.FechaPedido,
                    EstaEliminado = x.EstaEliminado
                }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscarRetirado()
        {
            using (var context = new KosakoDBEntities())
            {

                var lista = context.Pedidos.Where(x => x.Proceso == Proceso.Retirado && x.EstaEliminado == false);


                return lista.OrderBy(x => x.FechaEntrega).Select(x => new PedidoDto
                {
                    Adelanto = x.Adelanto,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    FechaEntrega = x.FechaEntrega,
                    FechaPedido = x.FechaPedido,
                    Total = x.Total,
                    Id = x.Id,
                    Proceso = x.Proceso,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    FechaRetiro = x.FechaRetirado,
                    Horario = x.Horario,
                    DiasHastaRetiro = x.DiasHastaRetiro,
                    FechaIniciado = x.FechaPedido,
                    EstaEliminado = x.EstaEliminado
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
                    Nombre = aux.Nombre,
                    FechaEntrega = aux.FechaEntrega,
                    FechaPedido = aux.FechaPedido,
                    Total = aux.Total,
                    Id = aux.Id,
                    Proceso = aux.Proceso,
                    ClienteId = aux.ClienteId,
                    Descripcion = aux.Descripcion,
                    FechaRetiro = aux.FechaRetirado,
                    Horario = aux.Horario,
                    DiasHastaRetiro = aux.DiasHastaRetiro,
                    FechaIniciado = aux.FechaPedido,
                    EstaEliminado = aux.EstaEliminado
                };
                return aux2;
            }
        }

        public void SumarTotal(long id, double suma)
        {
            using (var context = new KosakoDBEntities())
            {
                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Total += suma;

                context.SaveChanges();
            }
        }

        public void RestarTotal(long id, double resta)
        {
            using (var context = new KosakoDBEntities())
            {
                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Total -= resta;

                context.SaveChanges();
            }
        }

        public void RestarAdelanto(long id, double resta)
        {
            using (var context = new KosakoDBEntities())
            {
                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Adelanto -= resta;

                context.SaveChanges();
            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminados(string descripcion)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.Proceso == Proceso.PedidoTerminado && x.ApyNom.Contains(descripcion) && x.EstaEliminado == false).Select(x => new PedidoDto
                {
                    Adelanto = x.Adelanto,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    FechaEntrega = x.FechaEntrega,
                    FechaPedido = x.FechaPedido,
                    Total = x.Total,
                    Id = x.Id,
                    Proceso = x.Proceso,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    FechaRetiro = x.FechaRetirado,
                    Horario = x.Horario,
                    DiasHastaRetiro = x.DiasHastaRetiro,
                    FechaIniciado = x.FechaPedido,
                    EstaEliminado = x.EstaEliminado
                }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminadosUltima()
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.Proceso == Proceso.PedidoTerminado).Select(x => new PedidoDto
                {
                    Adelanto = x.Adelanto,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    FechaEntrega = x.FechaEntrega,
                    FechaPedido = x.FechaPedido,
                    Total = x.Total,
                    Id = x.Id,
                    Proceso = x.Proceso,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    FechaRetiro = x.FechaRetirado,
                    Horario = x.Horario,
                    DiasHastaRetiro = x.DiasHastaRetiro,
                    FechaIniciado = x.FechaPedido,
                    EstaEliminado = x.EstaEliminado
                }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscandoRetiradosUltima()
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.Proceso == Proceso.Retirado).Select(x => new PedidoDto
                {
                    Adelanto = x.Adelanto,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    FechaEntrega = x.FechaEntrega,
                    FechaPedido = x.FechaPedido,
                    Total = x.Total,
                    Id = x.Id,
                    Proceso = x.Proceso,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    FechaRetiro = x.FechaRetirado,
                    Horario = x.Horario,
                    DiasHastaRetiro = x.DiasHastaRetiro,
                    FechaIniciado = x.FechaPedido,
                    EstaEliminado = x.EstaEliminado
                }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminadosyClientes(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.ClienteId == id && x.Proceso == Proceso.PedidoTerminado && x.EstaEliminado == false)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        FechaRetiro = x.FechaRetirado,
                        Horario = x.Horario,
                        DiasHastaRetiro = x.DiasHastaRetiro,
                        FechaIniciado = x.FechaPedido,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminadosyClientesDesdeHasta(long id, DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.FechaEntrega.Day >= desde.Day && x.FechaEntrega.Month >= desde.Month && x.FechaEntrega.Year >= desde.Year && x.FechaEntrega.Year <= hasta.Year && x.FechaEntrega.Month <= hasta.Month && x.FechaEntrega.Day <= hasta.Day && x.ClienteId == id && x.Proceso == Proceso.PedidoTerminado && x.EstaEliminado == false)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        FechaRetiro = x.FechaRetirado,
                        Horario = x.Horario,
                        DiasHastaRetiro = x.DiasHastaRetiro,
                        FechaIniciado = x.FechaPedido,
                        EstaEliminado = x.EstaEliminado
                    }).ToList();

            }
        }

        public IEnumerable<PedidoDto> BuscandoTerminadosyClientesFecha(long id, DateTime date)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Pedidos.Where(x => x.FechaEntrega.Day == date.Day && x.FechaEntrega.Month == date.Month && x.FechaEntrega.Year == date.Year && x.ClienteId == id && x.Proceso == Proceso.PedidoTerminado && x.EstaEliminado == false)
                    .Select(x => new PedidoDto
                    {
                        Adelanto = x.Adelanto,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        FechaEntrega = x.FechaEntrega,
                        FechaPedido = x.FechaPedido,
                        Total = x.Total,
                        Id = x.Id,
                        Proceso = x.Proceso,
                        ClienteId = x.ClienteId,
                        Descripcion = x.Descripcion,
                        FechaRetiro = x.FechaRetirado,
                        Horario = x.Horario,
                        DiasHastaRetiro = x.DiasHastaRetiro,
                        FechaIniciado = x.FechaPedido,
                        EstaEliminado = x.EstaEliminado
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

        public PedidoDto BuscarDto(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var x = context.Pedidos.FirstOrDefault(c => c.Id == id);

                return new PedidoDto
                {
                    Adelanto = x.Adelanto,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    FechaEntrega = x.FechaEntrega,
                    FechaPedido = x.FechaPedido,
                    Total = x.Total,
                    Id = x.Id,
                    Proceso = x.Proceso,
                    ClienteId = x.ClienteId,
                    Descripcion = x.Descripcion,
                    FechaRetiro = x.FechaRetirado,
                    Horario = x.Horario,
                    DiasHastaRetiro = x.DiasHastaRetiro,
                    FechaIniciado = x.FechaPedido,
                    EstaEliminado = x.EstaEliminado

                };
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

        public void CambiarFechaRetirado(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.FechaRetirado = DateTime.Now.ToLongDateString();

                context.SaveChanges();

            }
        }

        public void CambiarFechaDatoRetiro(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.DiasHastaRetiro = $"Retirado: {DateTime.Now.ToLongDateString()}";

                context.SaveChanges();

            }
        }

        public void CambiarRamas(double total, long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Adelanto += total;

                context.SaveChanges();

            }
        }

        public void RestarAdelanto(double total, long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Adelanto -= total;

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

        public void CambiarProcesoGuardado(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Proceso = Proceso.Guardado;

                context.SaveChanges();

            }
        }

        public void CambiarProcesoRetirado(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Proceso = Proceso.Retirado;

                context.SaveChanges();

            }
        }

        public void GuardarDatosString(string datos, long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var pedido = context.Pedidos.FirstOrDefault(x => x.Id == id);

                pedido.Descripcion = datos;

                context.SaveChanges();

            }
        }

    }
}
