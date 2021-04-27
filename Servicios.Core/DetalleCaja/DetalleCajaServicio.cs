using AccesoDatos;
using Servicios.Core.DetalleCaja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.DetalleCaja
{
    public class DetalleCajaServicio
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
                    CajaId = BuscarCajaAbierta()
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



    }
}
