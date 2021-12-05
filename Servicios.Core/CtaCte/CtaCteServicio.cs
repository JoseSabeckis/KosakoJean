using AccesoDatos;
using Servicios.Core.CtaCte.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.CtaCte
{
    public class CtaCteServicio
    {
        public void Agregar(CtaCteDto ctaCteDto)
        {
            using (var contex = new KosakoDBEntities())
            {
                var cuenta = new AccesoDatos.CtaCte
                {
                    Descripcion = ctaCteDto.Descripcion,
                    Fecha = ctaCteDto.Fecha,
                    Total = ctaCteDto.Total,
                    Debe = ctaCteDto.Debe,
                    Estado = ctaCteDto.Estado,
                    ClienteId = ctaCteDto.ClienteId
                };

                contex.CtasCtes.Add(cuenta);

                contex.SaveChanges();

            }
        }

        public void Pagar(decimal monto, long clienteId, long cuentaId)
        {
            using(var context = new KosakoDBEntities())
            {
                var cuenta = context.CtasCtes.FirstOrDefault(x => x.ClienteId == clienteId && x.Id == cuentaId);

                cuenta.Debe -= monto;

                context.SaveChanges();

            }
        }

        public IEnumerable<CtaCteDto> Lista(long clienteId)
        {
            using(var context = new KosakoDBEntities())
            {
                return context.CtasCtes.Where(x => x.ClienteId == clienteId).Select(x => new CtaCteDto
                {
                    Id = x.Id,
                    ClienteId = x.ClienteId,
                    Debe = x.Debe,
                    Descripcion = x.Descripcion,
                    Total = x.Total,
                    Fecha = x.Fecha,
                    Estado = x.Estado

                }).ToList();
            }
        }

    }
}
