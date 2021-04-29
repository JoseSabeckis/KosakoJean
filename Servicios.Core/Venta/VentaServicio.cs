using AccesoDatos;
using Servicios.Core.Venta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Venta
{
    public class VentaServicio : IVentaServicio
    {
        public long NuevaVenta(VentaDto ventaDto)
        {
            using(var context = new KosakoDBEntities())
            {

                var nueva = new AccesoDatos.Venta
                {
                    Descuento = ventaDto.Descuento,
                    Fecha = ventaDto.Fecha,
                    Total = ventaDto.Total
                };

                context.Ventas.Add(nueva);

                context.SaveChanges();

                return nueva.Id;
            }
        }

        public IEnumerable<VentaDto> BuscarPor30Dias()
        {
            using (var context = new KosakoDBEntities())
            {
                var fecha = DateTime.Now;
                fecha.AddDays(-30);

                return context.Ventas.AsNoTracking().Where(x => x.Fecha >= fecha)
                    .Select(x => new VentaDto
                    {

                        Descuento = x.Descuento,
                        Fecha = x.Fecha,
                        Total = x.Total

                    }).ToList();
            }
        }
    }
}
