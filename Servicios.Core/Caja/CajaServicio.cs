using AccesoDatos;
using Servicios.Core.Caja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Caja
{
    public class CajaServicio : ICajaServicio
    {
        public void AbrirCaja(CajaDto cajaDto)
        {
            using (var context = new KosakoDBEntities())
            {
                var newCaja = new AccesoDatos.Caja
                {
                    FechaApertura = cajaDto.FechaApertura,
                    FechaCierre = cajaDto.FechaCierre,
                    MontoApertura = cajaDto.MontoApertura,
                    MontoCierre = cajaDto.MontoCierre,
                    TotalCaja = cajaDto.TotalCaja,
                    OpenClose = OpenClose.Abierto
                };

                context.Cajas.Add(newCaja);

                context.SaveChanges();
            }
        }

        public void CerrarCaja(decimal montoCierre, DateTime fechaCierre)
        {
            using (var context = new KosakoDBEntities())
            {
                var cajaId = BuscarCajaAbierta();

                var caja = context.Cajas.FirstOrDefault(x => x.Id == cajaId);

                caja.FechaCierre = fechaCierre;
                caja.MontoCierre = montoCierre;

                caja.TotalCaja = SumarCaja();

                context.SaveChanges();
         
            }
        }

        public decimal SumarCaja()
        {
            using (var context = new KosakoDBEntities())
            {

                var detalles = context.Cajas.AsNoTracking().FirstOrDefault(x => x.OpenClose == OpenClose.Abierto);

                var completa = context.DetalleCajas.AsNoTracking().Where(x => x.CajaId == detalles.Id);

                var total = completa.Sum(x => x.Total);

                return total + detalles.MontoApertura;

            }
        }

        public long BuscarCajaAbierta()
        {
            using(var context = new KosakoDBEntities())
            {
                var cajaId = context.Cajas.FirstOrDefault(x => x.OpenClose == OpenClose.Abierto).Id;

                return cajaId;
            }
        }

        public IEnumerable<CajaDto> BuscarCajas()
        {
            using(var context = new KosakoDBEntities())
            {
                return context.Cajas.AsNoTracking().Where(x => x.OpenClose == OpenClose.Cerrado)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose

                    }).ToList();
            }
        }

        public IEnumerable<CajaDto> BuscarCajasPorApertura(DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Cajas.AsNoTracking().Where(x => x.FechaApertura >= desde && x.FechaApertura <= hasta)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose

                    }).ToList();
            }
        }

        public IEnumerable<CajaDto> BuscarCajasPorCierre(DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Cajas.AsNoTracking().Where(x => x.FechaCierre >= desde && x.FechaCierre <= hasta)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose

                    }).ToList();
            }
        }

        public IEnumerable<CajaDto> BuscarCajasPorMes()
        {
            using (var context = new KosakoDBEntities())
            {
                var fecha = DateTime.Now;
                fecha.AddDays(-30);

                return context.Cajas.AsNoTracking().Where(x => x.FechaCierre == fecha)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose

                    }).ToList();
            }
        }

    }
}
