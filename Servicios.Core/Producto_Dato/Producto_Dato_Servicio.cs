using AccesoDatos;
using Servicios.Core.Producto_Dato.Dto;
using Servicios.Core.Producto_Pedido.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Dato
{
    public class Producto_Dato_Servicio : IProducto_Dato_Servicio
    {
        public void Insertar(Producto_Dato_Dto _Dto)
        {
            using(var context = new KosakoDBEntities())
            {
                var dato = new AccesoDatos.Producto_Dato
                {
                    Producto_PedidoId = _Dto.Producto_PedidoId,
                    EstadoPorPedido = _Dto.EstadoPorPedido,
                };

                context.Producto_Datos.Add(dato);

                context.SaveChanges();
            }
        }

        public void CambiarEstadoTerminado(long id)
        {
            using(var context = new KosakoDBEntities())
            {
                var dato = context.Producto_Datos.FirstOrDefault(x => x.Id == id);

                dato.EstadoPorPedido = EstadoPorPedido.Terminado;

                context.SaveChanges();
            }
        }

        public void CambiarEstadoEnEspera(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var dato = context.Producto_Datos.FirstOrDefault(x => x.Id == id);

                dato.EstadoPorPedido = EstadoPorPedido.EnEspera;

                context.SaveChanges();
            }
        }

        public void CambiarEstadoCancelado(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var dato = context.Producto_Datos.FirstOrDefault(x => x.Id == id);

                dato.EstadoPorPedido = EstadoPorPedido.Cancelado;

                context.SaveChanges();
            }
        }

        public void Eliminar(List<Producto_Pedido_Dto> ListaSoloIdProductoPedido)
        {
            using (var context = new KosakoDBEntities())
            {
                List<AccesoDatos.Producto_Dato> Datos = new List<AccesoDatos.Producto_Dato>();

                foreach (var item in ListaSoloIdProductoPedido)
                {
                    Datos = context.Producto_Datos.Where(x => x.Producto_PedidoId == item.Id).ToList();
                }

                foreach (var item2 in Datos.ToList())
                {
                    item2.EstaEliminado = true;
                }

                context.SaveChanges();
            }
        }

        public Producto_Dato_Dto ObtenerPorId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var dato = context.Producto_Datos.FirstOrDefault(x => x.Id == id);

                var dato2 = new Producto_Dato_Dto
                {
                    Id = dato.Id,
                    EstadoPorPedido = dato.EstadoPorPedido,
                    Producto_PedidoId = dato.Producto_PedidoId,
                    EstaEliminado = dato.EstaEliminado
                };

                return dato2;
            }
        }

        public Producto_Pedido_Dto ObtenerProductoPedidoPorId(long producto_pedido_id)
        {
            using (var context = new KosakoDBEntities())
            {
                //ProductoPedidoId
                var dato = context.Producto_Pedidos.FirstOrDefault(x => x.Id == producto_pedido_id);

                var dato2 = new Producto_Pedido_Dto
                {
                    Id = dato.Id,
                    Talle = dato.Talle,
                    Descripcion = dato.Descripcion,
                    Cantidad = dato.Cantidad,
                    Estado = dato.Estado,
                    PedidoId = dato.PedidoId,
                    TalleId = dato.TalleId,
                    ProductoId = dato.ProductoId,
                    EstaEliminado = dato.EstaEliminado
                };

                return dato2;
            }
        }

        public List<Producto_Dato_Dto> ObtenerProductosPorPedidoId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Producto_Datos.Where(x => x.Producto_PedidoId == id).Select(x => new Producto_Dato_Dto
                {
                    Id = x.Id,
                    EstadoPorPedido = x.EstadoPorPedido,
                    Producto_PedidoId = x.Producto_PedidoId,
                    EstaEliminado = x.EstaEliminado
                }).ToList();
            }
        }

        public List<Producto_Dato_Dto> ObtenerProductosParaHacer()
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Producto_Datos.Where(x => x.EstadoPorPedido == EstadoPorPedido.EnEspera && x.EstaEliminado == false).Select(x => new Producto_Dato_Dto
                {
                    Id = x.Id,
                    EstadoPorPedido = x.EstadoPorPedido,
                    Producto_PedidoId = x.Producto_PedidoId,
                    EstaEliminado = x.EstaEliminado

                }).ToList();
            }
        }

    }
}
