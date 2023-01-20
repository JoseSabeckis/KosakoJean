using AccesoDatos;
using Servicios.Core.PrecioSegunTalle.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.PrecioSegunTalle
{
    public class PrecioSegunTalleServicio : IPrecioSegunTalleServicio
    {
        public void Nuevo(PrecioSegunTalleDto Dto)
        {
            using (var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.PrecioSegunTalle
                {
                    Precio = Dto.Precio,
                    ProductoId = Dto.ProductoId,
                    TalleId = Dto.TalleId,
                };

                context.PrecioSegunTalles.Add(nuevo);

                context.SaveChanges();
            }

        }

        public void Eliminar(long id)
        {

            using (var context = new KosakoDBEntities())
            {
                var producto = context.PrecioSegunTalles.FirstOrDefault(x => x.Id == id);

                producto.EstaEliminado = true;

                context.SaveChanges();

            }

        }

        public void Modificar(PrecioSegunTalleDto Dto)
        {
            using (var context = new KosakoDBEntities())
            {

                var producto = context.PrecioSegunTalles.FirstOrDefault(x => x.Id == Dto.Id);

                producto.Precio = Dto.Precio;
                producto.ProductoId = Dto.ProductoId;
                producto.TalleId = Dto.TalleId;

                context.SaveChanges();

            }
        }

        public PrecioSegunTalleDto ObtenerPorId(long precioSegunTalleId)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.PrecioSegunTalles
                    .AsNoTracking()
                    .Select(x => new PrecioSegunTalleDto
                    {
                        Id = x.Id,
                        Precio = x.Precio,
                        ProductoId = x.ProductoId,
                        TalleId = x.TalleId,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == precioSegunTalleId && x.EstaEliminado == false);
            }
        }

        public IEnumerable<PrecioSegunTalleDto> BuscarTodos()
        {
            using (var context = new KosakoDBEntities())
            {
                var productos = context.PrecioSegunTalles.AsNoTracking().Where(x => x.EstaEliminado == false)
                    .Select(x => new PrecioSegunTalleDto
                    {

                        Id = x.Id,
                        Precio = x.Precio,
                        ProductoId = x.ProductoId,
                        TalleId = x.TalleId,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();


                return productos;
            }

        }

        public bool VerificarSiEstaYaCreado(long productoId, long talleId)
        {
            using (var context = new KosakoDBEntities())
            {
                foreach (var item in BuscarTodos())
                {
                    if (item.ProductoId == productoId && item.TalleId == talleId)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public decimal ObtenerPrecio(long productoId, long talleId)
        {
            using (var context = new KosakoDBEntities())
            {

                var precio = context.PrecioSegunTalles.FirstOrDefault(x => x.ProductoId == productoId && x.TalleId == talleId && x.EstaEliminado == false);

                return precio.Precio;

            }
        }

    }
}
