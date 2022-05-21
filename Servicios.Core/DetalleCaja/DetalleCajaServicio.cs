using AccesoDatos;
using Servicios.Core.DetalleCaja.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Core.DetalleCaja
{
    public class DetalleCajaServicio : IDetalleCajaServicio
    {
        public void AgregarDetalleCaja(DetalleCajaDto detalleCajaDto)
        {
            using (var context = new KosakoDBEntities())
            {
                var detalleCaja = new AccesoDatos.DetalleCaja
                {
                    Descripcion = detalleCajaDto.Descripcion,
                    Fecha = detalleCajaDto.Fecha,
                    Total = detalleCajaDto.Total,
                    CajaId = detalleCajaDto.CajaId,
                    TipoPago = detalleCajaDto.TipoPago
                };

                context.DetalleCajas.Add(detalleCaja);

                context.SaveChanges();
            }
        }

        public IEnumerable<DetalleCajaDto> Lista(long cajaId)
        {
            using (var context = new KosakoDBEntities())
            {

                return context.DetalleCajas.AsNoTracking().Where(x => x.CajaId == cajaId)
                    .Select(x => new DetalleCajaDto
                    {

                        Id = x.Id,
                        CajaId = x.CajaId,
                        Descripcion = x.Descripcion,
                        Total = x.Total,
                        Fecha = x.Fecha,
                        TipoPago = x.TipoPago

                    }).ToList();

            }
        }

        public void ListaParaEliminar(IEnumerable<DetalleCajaDto> lista)
        {
            using (var context = new KosakoDBEntities())
            {
                List<AccesoDatos.DetalleCaja> List = new List<AccesoDatos.DetalleCaja>();

                foreach (var item in lista)
                {
                    List.Add(context.DetalleCajas.FirstOrDefault(x => x.Id == item.Id));
                }

                foreach (var item in List)
                {
                    context.DetalleCajas.Remove(item);
                }

                context.SaveChanges();
            }
        }

        public long BuscarCajaAbierta()
        {
            using (var context = new KosakoDBEntities())
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
                        Id = x.Id,
                        TipoPago = x.TipoPago

                    }).ToList();

                return lista;

            }

        }

    }
}
