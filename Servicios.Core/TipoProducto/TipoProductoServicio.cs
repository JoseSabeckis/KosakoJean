using AccesoDatos;
using Servicios.Core.TipoProducto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.TipoProducto
{
    public class TipoProductoServicio : ITipoProducto
    {
        public void Nuevo(TipoProductoDto colegioDto)
        {

            using (var context = new KosakoBDEntities())//KosakoDBEntities
            {
                var nuevo = new AccesoDatos.TipoProducto
                {
                    Descripcion = colegioDto.Descripcion,

                };

                context.TipoProductos.Add(nuevo);

                context.SaveChanges();
            }

        }

        public void Eliminar(long id)
        {

            using (var context = new KosakoBDEntities())
            {
                var producto = context.TipoProductos.FirstOrDefault(x => x.Id == id);

                producto.EstaEliminado = true;

            }

        }

        public void Modificar(TipoProductoDto colegioDto)
        {
            using (var context = new KosakoBDEntities())
            {

                var producto = context.TipoProductos.FirstOrDefault(x => x.Id == colegioDto.Id);

                producto.Descripcion = colegioDto.Descripcion;

                context.SaveChanges();

            }
        }

        public IEnumerable<TipoProductoDto> Buscar(string cadenaBuscar)
        {
            //metadata=res://*/ModelBD.csdl|res://*/ModelBD.ssdl|res://*/ModelBD.msl;provider=System.Data.SqlClient
            using (var context = new KosakoBDEntities())
            {
                var productos = context.TipoProductos.AsNoTracking().Where(x => x.Descripcion.Contains(cadenaBuscar) && x.EstaEliminado == false)
                    .Select(x => new TipoProductoDto
                    {

                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();


                return productos;
            }

        }

        public TipoProductoDto ObtenerPorId(long colegioId)
        {
            using (var context = new KosakoBDEntities())
            {
                return context.TipoProductos
                    .AsNoTracking()
                    .Select(x => new TipoProductoDto
                    {
                        Id = x.Id,
                        Descripcion = x.Descripcion,
                        EstaEliminado = x.EstaEliminado

                    }).FirstOrDefault(x => x.Id == colegioId && x.EstaEliminado == false);
            }
        }
    }
}
