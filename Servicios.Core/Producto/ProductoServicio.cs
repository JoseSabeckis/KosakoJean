using AccesoDatos;
using Servicios.Core.Producto.Dto;
using System.Collections.Generic;
using System.Linq;

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
                    Creacion = dto.Creacion,
                    CodigoBarra = dto.CodigoBarra,
                    ImagenCodBarra = dto.ImagenCodBarra,
                    CodBarraVerdadero = dto.CodigoBarraVerdadero,
                    CodCreado = dto.CodCreado
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
                producto.CodigoBarra = dto.CodigoBarra;
                producto.ImagenCodBarra = dto.ImagenCodBarra;
                producto.CodBarraVerdadero = dto.CodigoBarraVerdadero;
                producto.CodCreado = dto.CodCreado;

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
                        Extras = x.Extras,
                        TipoProductoId = x.TipoProductoId,
                        ColegioId = x.ColegioId,
                        Foto = x.Foto,
                        Colegio = context.Colegios.FirstOrDefault(f => f.Id == x.ColegioId).Descripcion,
                        TipoProducto = context.TipoProductos.FirstOrDefault(f => f.Id == x.TipoProductoId).Descripcion,
                        Stock = x.Stock,
                        Creacion = x.Creacion,
                        Precio = x.Precio,
                        CodigoBarra = x.CodigoBarra,
                        ImagenCodBarra = x.ImagenCodBarra,
                        CodigoBarraVerdadero = x.CodBarraVerdadero,
                        CodCreado = x.CodCreado

                    }).ToList();

                return productos;
            }

        }

        public bool VerificarCodigoDeBarra(long cod, long id)
        {
            using(var context = new KosakoDBEntities())
            {

                var bandera = context.Productos.FirstOrDefault(x => x.CodigoBarra == cod && x.Id != id);

                if (bandera != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public bool VerificarCodigoDeBarraVerdadero(string cod, long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var bandera = context.Productos.FirstOrDefault(x => x.CodBarraVerdadero == cod && x.Id != id);

                if (bandera != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public long TraerNuevoCodBarra()
        {
            using (var context = new KosakoDBEntities())
            {

                var bandera = context.Productos.Max(x => x.CodigoBarra);

                return bandera + 1;

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
                        Creacion = x.Creacion,
                        CodigoBarra = x.CodigoBarra,
                        ImagenCodBarra = x.ImagenCodBarra,
                        CodigoBarraVerdadero = x.CodBarraVerdadero,
                        CodCreado = x.CodCreado

                    }).FirstOrDefault(x => x.Id == Id);
            }
        }

        public ProductoDto ObtenerPorCodigoBarra(string codigo)
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
                        Creacion = x.Creacion,
                        CodigoBarra = x.CodigoBarra,
                        ImagenCodBarra = x.ImagenCodBarra,
                        CodigoBarraVerdadero = x.CodBarraVerdadero,
                        CodCreado = x.CodCreado

                    }).FirstOrDefault(x => x.CodigoBarraVerdadero == codigo);
            }
        }

    }
}