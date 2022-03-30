using AccesoDatos;
using Servicios.Core.Colegio;
using Servicios.Core.Producto.Dto;
using Servicios.Core.TipoProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Producto
{
    public class ProductoServicio : IProductoServicio
    {

        public void Nuevo(ProductoDto dto)
        {

            using (var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.Producto
                {
                    Descripcion = dto.Descripcion,
                    Precio = dto.Precio,
                    Extras = dto.Extras,
                    TipoProductoId = dto.TipoProductoId,
                    ColegioId = dto.ColegioId,
                    Foto = dto.Foto,
                    Stock = dto.Stock,
                    Creacion = dto.Creacion
                };

                context.Productos.Add(nuevo);

                context.SaveChanges();
            }

        }

        public void Eliminar(long id)
        {

            using (var context = new KosakoDBEntities())
            {
                var producto = context.Productos.FirstOrDefault(x => x.Id == id);

                producto.EstaEliminado = true;

                context.SaveChanges();

            }

        }

        public void BajarStock(long id, decimal stock)
        {

            using (var context = new KosakoDBEntities())
            {
                var producto = context.Productos.FirstOrDefault(x => x.Id == id);

                producto.Stock -= stock;

                context.SaveChanges();

            }

        }

        public void Modificar(ProductoDto dto)
        {
            using (var context = new KosakoDBEntities())
            {

                var producto = context.Productos.FirstOrDefault(x => x.Id == dto.Id);

                producto.Descripcion = dto.Descripcion;
                producto.ColegioId = dto.ColegioId;
                producto.Extras = dto.Extras;
                producto.Precio = dto.Precio;
                producto.TipoProductoId = dto.TipoProductoId;
                producto.Foto = dto.Foto;
                producto.Stock = dto.Stock;
                producto.Creacion = dto.Creacion;

                context.SaveChanges();

            }
        }

        public IEnumerable<ProductoDto> Buscar(string cadenaBuscar)
        {
            using (var context = new KosakoDBEntities())
            {

                var productos = context.Productos.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new ProductoDto
                    {

                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        Precio = x.Precio,
                        Extras = x.Extras,
                        TipoProductoId = x.TipoProductoId,
                        ColegioId = x.ColegioId,
                        Foto = x.Foto,
                        Colegio = context.Colegios.FirstOrDefault(f=>f.Id == x.ColegioId).Descripcion,
                        TipoProducto = context.TipoProductos.FirstOrDefault(f=>f.Id == x.TipoProductoId).Descripcion,
                        Stock = x.Stock,
                        Creacion = x.Creacion

                    }).ToList();


                return productos;
            }

        }

        public ProductoDto ObtenerPorId(long Id)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Productos
                    .AsNoTracking()
                    .Select(x => new ProductoDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado,
                        Precio = x.Precio,
                        Extras = x.Extras,
                        TipoProductoId = x.TipoProductoId,
                        ColegioId = x.ColegioId,
                        Foto = x.Foto,
                        Colegio = context.Colegios.FirstOrDefault(f => f.Id == x.ColegioId).Descripcion,
                        TipoProducto = context.TipoProductos.FirstOrDefault(f => f.Id == x.TipoProductoId).Descripcion,
                        Stock = x.Stock,
                        Creacion = x.Creacion

                    }).FirstOrDefault(x => x.Id == Id);
            }
        }

    }
}