using AccesoDatos;
using Servicios.Core.Talle.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Talle
{
    public class TalleServicio : ITalleServicio
    {
        public void Nuevo(TalleDto talleDto)
        {

            using (var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.Talle
                {
                    Descripcion = talleDto.Descripcion,

                };

                context.Talles.Add(nuevo);

                context.SaveChanges();
            }

        }

        public void Eliminar(long id)
        {

            using (var context = new KosakoDBEntities())
            {
                var producto = context.Talles.FirstOrDefault(x => x.Id == id);

                producto.EstaEliminado = true;

                context.SaveChanges();

            }

        }

        public void Modificar(TalleDto talleDto)
        {
            using (var context = new KosakoDBEntities())
            {

                var producto = context.Talles.FirstOrDefault(x => x.Id == talleDto.Id);

                producto.Descripcion = talleDto.Descripcion;

                context.SaveChanges();

            }
        }

        public IEnumerable<TalleDto> Buscar(string cadenaBuscar)
        {
            using (var context = new KosakoDBEntities())
            {
                var productos = context.Talles.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new TalleDto
                    {

                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();


                return productos;
            }

        }

        public long BuscarNombreDevuelveId(string cadenaBuscar)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Talles.AsNoTracking().FirstOrDefault(x => x.Descripcion == cadenaBuscar && x.EstaEliminado == false).Id;
            }
        }

        public TalleDto ObtenerPorId(long talleId)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Talles
                    .AsNoTracking()
                    .Select(x => new TalleDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == talleId && x.EstaEliminado == false);
            }
        }
    }
}
