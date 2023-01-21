using AccesoDatos;
using Servicios.Core.TalleSegunProductoPrecio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.TalleSegunProductoPrecio
{
    public class TalleSegunProductoPrecioServicio : ITalleSegunProductoServicio
    {
        public void Nuevo(TalleSegunProductoPrecioDto Dto)
        {

            using (var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.TalleSegunProductoPrecio
                {                   
                    TalleId = Dto.TalleId,
                    PrecioSegunTalleId = Dto.PrecioSegunTalleId
                };

                context.TalleSegunProductoPrecioSet.Add(nuevo);

                context.SaveChanges();
            }

        }

        public void Eliminar(long id)
        {

            using (var context = new KosakoDBEntities())
            {
                var producto = context.TalleSegunProductoPrecioSet.FirstOrDefault(x => x.Id == id);

                context.TalleSegunProductoPrecioSet.Remove(producto);

                context.SaveChanges();

            }

        }

        public void Modificar(TalleSegunProductoPrecioDto Dto)
        {
            using (var context = new KosakoDBEntities())
            {

                var producto = context.TalleSegunProductoPrecioSet.FirstOrDefault(x => x.Id == Dto.Id);

                producto.TalleId = Dto.TalleId;
                producto.PrecioSegunTalleId = Dto.PrecioSegunTalleId;

                context.SaveChanges();

            }
        }

        public TalleSegunProductoPrecioDto ObtenerPorId(long Id)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.TalleSegunProductoPrecioSet
                    .AsNoTracking()
                    .Select(x => new TalleSegunProductoPrecioDto
                    {
                        Id = x.Id,
                        TalleId = x.TalleId,
                        PrecioSegunTalleId = x.PrecioSegunTalleId

                    }).FirstOrDefault(x => x.Id == Id);
            }
        }

        public IEnumerable<TalleSegunProductoPrecioDto> ObtenerListaPorPrecioSegunTalleId(long precioSegunTalleId)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.TalleSegunProductoPrecioSet
                    .AsNoTracking()
                    .Select(x => new TalleSegunProductoPrecioDto
                    {
                        Id = x.Id,
                        TalleId = x.TalleId,
                        PrecioSegunTalleId = x.PrecioSegunTalleId

                    }).Where(x => x.PrecioSegunTalleId == precioSegunTalleId)
                    .ToList();

            }
        }

    }
}
