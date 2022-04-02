using AccesoDatos;
using Servicios.Core.Negocio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Negocio
{
    public class NegocioServicio : INegocioServicio
    {
        public void Insertar(NegocioDto negocioDto)
        {
            using(var context = new KosakoDBEntities())
            {

                var negocio = new AccesoDatos.Negocio
                {
                    Celular = negocioDto.Celular,
                    Direccion = negocioDto.Direccion,
                    Cuit = negocioDto.Cuit,
                    Email = negocioDto.Email,
                    RazonSocial = negocioDto.RazonSocial,
                    Imagen = negocioDto.Imagen
                };

                context.Negocios.Add(negocio);

                context.SaveChanges();
            }
        }

        public void Modificar(NegocioDto negocioDto)
        {
            using(var context = new KosakoDBEntities())
            {
                var negocio = context.Negocios.FirstOrDefault(x => x.Id == negocioDto.Id);

                negocio.RazonSocial = negocioDto.RazonSocial;
                negocio.Cuit = negocioDto.Cuit;
                negocio.Celular = negocioDto.Celular;
                negocio.Direccion = negocioDto.Direccion;
                negocio.Email = negocioDto.Email;
                negocio.Imagen = negocioDto.Imagen;

                context.SaveChanges();
            }
        }

        public NegocioDto ObtenerPorId(long id)
        {
            using(var context = new KosakoDBEntities())
            {

                var negocio = context.Negocios.FirstOrDefault(x => x.Id == id);

                if (negocio != null)
                {
                    var NEGOCIO = new NegocioDto
                    {
                        Celular = negocio.Celular,
                        Cuit = negocio.Cuit,
                        Direccion = negocio.Direccion,
                        Email = negocio.Email,
                        Id = negocio.Id,
                        Imagen = negocio.Imagen,
                        RazonSocial = negocio.RazonSocial
                    };

                    return NEGOCIO;
                }

                return null;               

            }
        }

    }
}
