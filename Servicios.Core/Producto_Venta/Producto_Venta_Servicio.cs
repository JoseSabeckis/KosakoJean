using AccesoDatos;
using Servicios.Core.Producto_Venta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto_Venta
{
    public class Producto_Venta_Servicio : IProducto_Venta_Servicio
    {
        public void NuevoProductoVenta(Producto_Venta_Dto producto)
        {
            using(var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.Producto_Venta
                {
                    Cantidad = producto.Cantidad,
                    Estado = producto.Estado,
                    Talle = producto.Talle,
                    ProductoId = producto.ProductoId,
                    VentaId = producto.VentaId
                };

                context.Producto_Ventas.Add(nuevo);

                context.SaveChanges();

            }
        }

        public void CambiarEstado(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var estado = context.Producto_Ventas.FirstOrDefault(x => x.Id == id);

                estado.Estado = EstadoPedido.Terminado;

                context.SaveChanges();
            }
        }

    }
}
