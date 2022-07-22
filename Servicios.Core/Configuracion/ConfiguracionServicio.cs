using AccesoDatos;
using Servicios.Core.Configuracion.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Configuracion
{
    public class ConfiguracionServicio : IConfiguracionServicio
    {
        public void Nuevo(ConfiguracionDto Dto)
        {
            using (var context = new KosakoDBEntities())
            {
                var nuevo = new AccesoDatos.Configuracion
                {
                    MostrarDatos = Dto.MostrarDatos,
                    UsarLogin = Dto.UsarLogin,
                    UsarTicketera = Dto.UsarTicketera
                };

                context.Configuraciones.Add(nuevo);

                context.SaveChanges();
            }
        }

        public void Modificar(ConfiguracionDto Dto)
        {
            using (var context = new KosakoDBEntities())
            {

                var config = context.Configuraciones.FirstOrDefault(x => x.Id == Dto.Id);

                config.UsarLogin = Dto.UsarLogin;
                config.UsarTicketera = Dto.UsarTicketera;
                config.MostrarDatos = Dto.MostrarDatos;

                context.SaveChanges();

            }
        }

        public ConfiguracionDto ObtenerPorId(long Id)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Configuraciones
                    .AsNoTracking()
                    .Select(x => new ConfiguracionDto
                    {
                        Id = x.Id,
                        MostrarDatos = x.MostrarDatos,
                        UsarLogin = x.UsarLogin,
                        UsarTicketera = x.UsarTicketera

                    }).FirstOrDefault(x => x.Id == Id);
            }
        }

    }
}
