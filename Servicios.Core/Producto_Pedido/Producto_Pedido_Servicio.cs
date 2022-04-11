using AccesoDatos;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Core.Producto_Pedido
{
    public class Producto_Pedido_Servicio : IProducto_Pedido_Servicio
    {
        IProductoServicio _ProductoServicio = new ProductoServicio();

        public long NuevoProductoPedido(Producto_Pedido_Dto producto)
        {
            using (var context = new KosakoDBEntities())
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

        public List<long> BuscarProductoEnPedidos(long productoId)
        {
            using (var context = new KosakoDBEntities())
            {
                var pedidos = context.Producto_Pedidos.Where(x => x.ProductoId == productoId && x.Estado == EstadoPedido.Esperando).ToList();

                List<long> Datos = new List<long>();

                foreach (var item in pedidos)
                {
                    Datos.Add(item.Id);
                }

                return Datos;
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

                    if (_ProductoServicio.ObtenerPorId(item.ProductoId).Creacion)
                    {
                        var listaSoloId = new Producto_Pedido_Dto
                        {
                            Id = item.Id
                        };

                        Lista.Add(listaSoloId);
                    }
                }

                context.SaveChanges();

                return Lista.ToList();
            }
        }

        public void EliminacionDefinitiva(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var dato = context.Producto_Pedidos.FirstOrDefault(x => x.Id == id);

                context.Producto_Pedidos.Remove(dato);

                context.SaveChanges();
            }
        }

        public void EliminacionDefinitivaLista()
        {
            using (var context = new KosakoDBEntities())
            {
                var datos = context.Producto_Pedidos.Where(x => x.EstaEliminado == true).ToList();

                foreach (var item in datos)
                {
                    context.Producto_Pedidos.Remove(item);
                }

                context.SaveChanges();
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

        public void RestarCantidad1(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.FirstOrDefault(x => x.Id == id);

                estado.Cantidad -= 1;

                context.SaveChanges();
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
