using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace Servicios.Core.Colegio
{
    public class ColegioServicio : IColegioServicio
    {

        public void Nuevo(ColegioDto colegioDto)
        {

            using (var context = new KosakoBDEntities())//KosakoDBEntities
            {
                var nuevo = new AccesoDatos.Colegio
                {
                    Descripcion = colegioDto.Descripcion,

                };

                context.Colegios.Add(nuevo);

                context.SaveChanges();
            }

        }

        public void Eliminar(long id)
        {

            using (var context = new KosakoBDEntities())
            {
                var producto = context.Colegios.FirstOrDefault(x => x.Id == id);

                producto.EstaEliminado = true;

            }

        }

        public void Modificar(ColegioDto colegioDto)
        {
            using(var context = new KosakoBDEntities())
            {

                var producto = context.Colegios.FirstOrDefault(x => x.Id == colegioDto.Id);

                producto.Descripcion = colegioDto.Descripcion;

                context.SaveChanges();

            }
        }

        public IEnumerable<ColegioDto> Buscar(string cadenaBuscar)
        {
            //metadata=res://*/ModelBD.csdl|res://*/ModelBD.ssdl|res://*/ModelBD.msl;provider=System.Data.SqlClient
            using (var context = new KosakoBDEntities())
            {
                var productos = context.Colegios.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new ColegioDto{

                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();

                
                return productos;
            }

        }

        public ColegioDto ObtenerPorId(long colegioId)
        {
            using (var context = new KosakoBDEntities())
            {
                return context.Colegios
                    .AsNoTracking()
                    .Select(x => new ColegioDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == colegioId && x.EstaEliminado == false);
            }
        }

    }
}
