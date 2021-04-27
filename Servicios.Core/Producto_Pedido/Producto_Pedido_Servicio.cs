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


    }
}
