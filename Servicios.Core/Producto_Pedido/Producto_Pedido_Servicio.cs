using AccesoDatos;
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
        public void NuevoProductoPedido(Producto_Pedido_Dto producto)
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
                    Descripcion = producto.Descripcion

                };

                context.Producto_Pedidos.Add(nuevo);

                context.SaveChanges();

            }
        }

        public void CambiarEstado(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.FirstOrDefault(x => x.Id == id);

                estado.Estado = EstadoPedido.Terminado;

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
                    Id = x.Id

                }).ToList();

                return estado;
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
                    Id = x.Id

                }).ToList();

                return estado;
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
                    Id = x.Id

                }).ToList();

                return estado;
            }
        }

        public List<Producto_Pedido_Dto> Buscar()
        {
            using (var context = new KosakoDBEntities())
            {
                var estado = context.Producto_Pedidos.Where(x => x.Estado == EstadoPedido.Esperando).Select(x => new Producto_Pedido_Dto
                {
                    Cantidad = x.Cantidad,
                    Estado = x.Estado,
                    PedidoId = x.PedidoId,
                    ProductoId = x.ProductoId,
                    Talle = x.Talle,
                    Descripcion = x.Descripcion,
                    Id = x.Id

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
                    Id = estado.Id

                };

                return aux;
            }
        }


    }
}
