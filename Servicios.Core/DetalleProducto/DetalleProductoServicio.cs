using AccesoDatos;
using Servicios.Core.ParteVenta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.DetalleProducto
{
    public class DetalleProductoServicio : IDetalleProductoServicio
    {
        public void Insertar(VentaDto2 detalleProductoDto)
        {
            using(var context = new KosakoDBEntities())
            {

                var detalle = new AccesoDatos.DetalleProducto
                {
                    Descripcion = detalleProductoDto.Descripcion,
                    Colegio = detalleProductoDto.Colegio,
                    Talle = detalleProductoDto.Talle,
                    Cantidad = detalleProductoDto.Cantidad,
                    Precio = detalleProductoDto.Precio,
                    Fecha = detalleProductoDto.Fecha,
                    DetalleCajaId = detalleProductoDto.DetalleCajaId,
                    ProductoId = detalleProductoDto.ProductoId,
                };

                context.DetalleProductos.Add(detalle);

                context.SaveChanges();

            }
        }

        public void EliminarTodoPorDetalleCajaId(long detalleCajaId)
        {
            using(var context = new KosakoDBEntities())
            {
                var lista = context.DetalleProductos.Where(x => x.DetalleCajaId == detalleCajaId);

                foreach (var item in lista)
                {
                    context.DetalleProductos.Remove(item);
                }

                context.SaveChanges();
            }
        }

        public List<VentaDto2> ObtenerListaPorDetalleId(long detalleId)
        {
            using(var context = new KosakoDBEntities())
            {
                var lista = context.DetalleProductos.Where(x => x.DetalleCajaId == detalleId);

                List<VentaDto2> ListaCompleta = new List<VentaDto2>();

                foreach (var item in lista)
                {
                    var producto = new VentaDto2
                    {
                        Descripcion = item.Descripcion,
                        Cantidad = item.Cantidad,
                        Talle = item.Talle,
                        Precio = item.Precio,
                        Fecha = item.Fecha,
                        ProductoId = (long)item.ProductoId,
                    };

                    ListaCompleta.Add(producto);
                }

                return ListaCompleta;
            }
        }

    }
}
