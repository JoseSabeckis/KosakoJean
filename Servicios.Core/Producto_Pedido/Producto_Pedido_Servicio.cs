using AccesoDatos;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto_Pedido.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Pedido
{
    public class Producto_Pedido_Servicio : IProducto_Pedido_Servicio
    {
        public long NuevoProductoPedido(Producto_Pedido_Dto producto)
        {
            using(var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.Producto_Pedido
                {

                    Cantidad = producto.Cantidad,
                    Estado = producto.Estado,
                    Talle = producto.Talle,
                    PedidoId = producto.PedidoId,
                    ProductoId = producto.ProductoId,            
                    Descripcion = producto.Descripcion,
                    TalleId = producto.TalleId,
                    
                };

                context.Producto_Pedidos.Add(nuevo);

                context.SaveChanges();

                return nuevo.Id;
            }
        }

        public void CambiarEstado(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.PedidoId == id).ToList();

                foreach (var item in estado)
                {
                    item.Estado = EstadoPedido.Terminado;
                }              

                context.SaveChanges();
            }
        }

        public List<Producto_Pedido_Dto> Eliminar(long pedidoid)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.PedidoId == pedidoid).ToList();

                List<Producto_Pedido_Dto> Lista = new List<Producto_Pedido_Dto>();

                foreach (var item in estado)
                {
                    item.EstaEliminado = true;

                    var listaSoloId = new Producto_Pedido_Dto
                    {
                        Id = item.Id
                    };

                    Lista.Add(listaSoloId);
                }

                context.SaveChanges();

                return Lista.ToList();
            }
        }

        public List<Producto_Pedido_Dto> BuscarId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.PedidoId == id && x.Estado == EstadoPedido.Esperando).Select(x => new Producto_Pedido_Dto
                {
                    Cantidad = x.Cantidad,
                    Estado = x.Estado,
                    PedidoId = x.PedidoId,
                    ProductoId = x.ProductoId,
                    Talle = x.Talle,
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    TalleId = x.TalleId,
                    EstaEliminado = x.EstaEliminado
                }).ToList();

                return estado;
            }
        }

        public Producto_Pedido_Dto ObtenerPorId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.FirstOrDefault(x => x.Id == id);

                var estado2 = new Producto_Pedido_Dto
                {
                    Cantidad = estado.Cantidad,
                    Estado = estado.Estado,
                    PedidoId = estado.PedidoId,
                    ProductoId = estado.ProductoId,
                    Talle = estado.Talle,
                    Descripcion = estado.Descripcion,
                    Id = estado.Id,
                    TalleId = estado.TalleId,
                    EstaEliminado = estado.EstaEliminado
                };

                return estado2;
            }
        }

        public List<Producto_Pedido_Dto> BuscarPedidoId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.PedidoId == id).Select(x => new Producto_Pedido_Dto
                {
                    Cantidad = x.Cantidad,
                    Estado = x.Estado,
                    PedidoId = x.PedidoId,
                    ProductoId = x.ProductoId,
                    Talle = x.Talle,
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    TalleId = x.TalleId,
                    EstaEliminado = x.EstaEliminado

                }).ToList();

                return estado;
            }
        }

        public Producto_Pedido_Dto BuscarId_Producto_Pedido(long producto_pedido_id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.FirstOrDefault(x => x.Id == producto_pedido_id);

                var aux = new Producto_Pedido_Dto
                {
                    Cantidad = estado.Cantidad,
                    Estado = estado.Estado,
                    PedidoId = estado.PedidoId,
                    ProductoId = estado.ProductoId,
                    Talle = estado.Talle,
                    Descripcion = estado.Descripcion,
                    Id = estado.Id,
                    TalleId = estado.TalleId,
                    EstaEliminado = estado.EstaEliminado
                };

                return aux;
            }
        }

        public List<Producto_Pedido_Dto> BuscarPedidoTerminado(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.PedidoId == id && x.Estado == EstadoPedido.Terminado).Select(x => new Producto_Pedido_Dto
                {
                    Cantidad = x.Cantidad,
                    Estado = x.Estado,
                    PedidoId = x.PedidoId,
                    ProductoId = x.ProductoId,
                    Talle = x.Talle,
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    TalleId = x.TalleId,
                    EstaEliminado = x.EstaEliminado

                }).ToList();

                return estado;
            }
        }

        public List<Producto_Pedido_Dto> BuscarPedidoGuardado(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.PedidoId == id).Select(x => new Producto_Pedido_Dto
                {
                    Cantidad = x.Cantidad,
                    Estado = x.Estado,
                    PedidoId = x.PedidoId,
                    ProductoId = x.ProductoId,
                    Talle = x.Talle,
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    TalleId = x.TalleId,
                    EstaEliminado = x.EstaEliminado

                }).ToList();

                return estado;
            }
        }

        public List<Producto_Pedido_Dto> BuscarPedidoRetirado(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.PedidoId == id).Select(x => new Producto_Pedido_Dto
                {
                    Cantidad = x.Cantidad,
                    Estado = x.Estado,
                    PedidoId = x.PedidoId,
                    ProductoId = x.ProductoId,
                    Talle = x.Talle,
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    TalleId = x.TalleId,
                    EstaEliminado = x.EstaEliminado

                }).ToList();

                return estado;
            }
        }

        public List<Producto_Pedido_Dto> Buscar()
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.Estado == EstadoPedido.Esperando && x.EstaEliminado == false).Select(x => new Producto_Pedido_Dto
                {
                    Cantidad = x.Cantidad,
                    Estado = x.Estado,
                    PedidoId = x.PedidoId,
                    ProductoId = x.ProductoId,
                    Talle = x.Talle,
                    Descripcion = x.Descripcion,
                    Id = x.Id,
                    TalleId = x.TalleId,
                    EstaEliminado = x.EstaEliminado

                }).ToList();

                return estado;
            }
        }

        public Producto_Pedido_Dto BuscarPedidoId2(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.FirstOrDefault(x => x.PedidoId == id);

                var aux = new Producto_Pedido_Dto
                {
                    Cantidad = estado.Cantidad,
                    Estado = estado.Estado,
                    PedidoId = estado.PedidoId,
                    ProductoId = estado.ProductoId,
                    Talle = estado.Talle,
                    Descripcion = estado.Descripcion,
                    Id = estado.Id,
                    TalleId = estado.TalleId,
                    EstaEliminado = estado.EstaEliminado
                };

                return aux;
            }
        }


    }
}
