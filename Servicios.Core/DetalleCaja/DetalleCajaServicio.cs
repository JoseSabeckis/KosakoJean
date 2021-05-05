using AccesoDatos;
using Servicios.Core.DetalleCaja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.DetalleCaja
{
    public class DetalleCajaServicio : IDetalleCajaServicio
    {
        public void AgregarDetalleCaja(DetalleCajaDto detalleCajaDto)
        {
            using(var context = new KosakoDBEntities())
            {
                var detalleCaja = new AccesoDatos.DetalleCaja
                {
                    Descripcion = detalleCajaDto.Descripcion,
                    Fecha = detalleCajaDto.Fecha,
                    Total = detalleCajaDto.Total,
                    CajaId = detalleCajaDto.CajaId
                };

                context.DetalleCajas.Add(detalleCaja);

                context.SaveChanges();
            }
        }

        public long BuscarCajaAbierta()
        {
            using(var context = new KosakoDBEntities())
            {
                var cajaId = context.Cajas.AsNoTracking().FirstOrDefault(x => x.OpenClose == OpenClose.Abierto).Id;

                return cajaId;
            }

        }

        public IEnumerable<DetalleCajaDto> BuscarDetalles(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var lista = context.DetalleCajas.AsNoTracking().Where(x => x.CajaId == id)
                    .Select(x => new DetalleCajaDto
                    {
                      
                        CajaId = x.CajaId,
                        Descripcion = x.Descripcion,
                        Fecha = x.Fecha,
                        Total = x.Total,
                        Id = x.Id

                    }).ToList();

                return lista;
                
            }

        }

    }
}
