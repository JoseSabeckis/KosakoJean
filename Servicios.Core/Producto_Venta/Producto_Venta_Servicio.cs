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
        public bool VerVentas(string descripcion)
        {
            using (var context = new KosakoDBEntities())
            {
                var bandera = context.Producto_Ventas.Where(x => x.Estado == EstadoPedido.Esperando && x.Descripcion == descripcion);

                if (bandera == null)
                {

                    return true;

                }

                return false;
            }
        }

        public void CambiarCant(string descripcion, decimal cantidad)
        {
            using (var context = new KosakoDBEntities())
            {
                var cant = context.Producto_Ventas.FirstOrDefault(x => x.Estado == EstadoPedido.Esperando && x.Descripcion == descripcion);

                cant.Cantidad += cantidad;

            }
        }

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
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    VentaId = producto.VentaId
                };

                context.Producto_Ventas.Add(nuevo);

                context.SaveChanges();

            }
        }

        public IEnumerable<Producto_Venta_Dto> Obtener()
        {
            using (var context = new KosakoDBEntities())
            {

                return context.Producto_Ventas.Where(x => x.Estado == EstadoPedido.Esperando)
                    .Select(x => new Producto_Venta_Dto
                    {
                        Descripcion = x.Descripcion,
                        Cantidad = x.Cantidad,
                        Estado = x.Estado,
                        ProductoId = x.ProductoId,
                        Talle = x.Talle,
                        VentaId = x.VentaId,
                        Precio = x.Precio,
                        Id = x.Id
                    }).ToList();

            }
        }

        public void Eliminar()
        {
            using (var context = new KosakoDBEntities())
            {
                var obj = context.Producto_Ventas.Where(x => x.Estado == EstadoPedido.Esperando);

                foreach (var item in obj)
                {

                    context.Producto_Ventas.Remove(item);

                }

                context.SaveChanges();
            }
        }

        public void PonerPorEjemplo(Producto_Venta_Dto producto)
        {
            using (var context = new KosakoDBEntities())
            {

                var ejemplo = new AccesoDatos.Producto_Venta
                {
                    Descripcion = producto.Descripcion,
                    Cantidad = producto.Cantidad,
                    Estado = producto.Estado,
                    Precio = producto.Precio,
                    Talle = producto.Talle,
                    ProductoId = producto.ProductoId,
                    VentaId = producto.VentaId
                };

                context.Producto_Ventas.Add(ejemplo);

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
