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
                    OpenClose = OpenClose.Abierto,

                };

                context.Cajas.Add(newCaja);

                context.SaveChanges();
            }
        }

        public void CerrarCaja(decimal montoCierre, DateTime fechaCierre)
        {
            using (var context = new KosakoDBEntities())
            {
                var caja = context.Cajas.FirstOrDefault(x => x.OpenClose == OpenClose.Abierto);

                caja.FechaCierre = fechaCierre;
                caja.MontoCierre = montoCierre;
                caja.OpenClose = OpenClose.Cerrado;
                caja.TotalCaja = SumarCaja();

                context.SaveChanges();
         
            }
        }

        public decimal SumarCaja()
        {
            using (var context = new KosakoDBEntities())
            {

                var detalles = context.Cajas.FirstOrDefault(x => x.OpenClose == OpenClose.Abierto);

                var completa = context.DetalleCajas.Where(x => x.CajaId == detalles.Id);

                decimal total = 0;

                foreach (var item in completa)
                {
                    total += item.Total;
                }

                return total + detalles.MontoApertura;

            }
        }

        public AccesoDatos.Caja BuscarCajaAbierta()
        {
            using(var context = new KosakoDBEntities())
            {
                return context.Cajas.FirstOrDefault(x => x.OpenClose == OpenClose.Abierto);

            }
        }

        public void SumarDineroACaja(decimal total)
        {
            using (var context = new KosakoDBEntities())
            {
                var caja = context.Cajas.FirstOrDefault(x => x.OpenClose == OpenClose.Abierto);

                caja.TotalCaja += total;

                context.SaveChanges();
            }
        }

        public bool BuscarCajaAbiertaBool()
        {
            using (var context = new KosakoDBEntities())
            {
                if (context.Cajas.Any(x => x.OpenClose == OpenClose.Abierto))
                {
                    return true;

                }
                return false;
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
                        OpenClose = x.OpenClose,

                    }).ToList();
            }
        }

        public CajaDto BuscarCajasId(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var caja = context.Cajas.AsNoTracking().FirstOrDefault(x => x.Id == id);

                var cajaAux = new CajaDto
                {
                    FechaApertura = caja.FechaApertura,
                    MontoCierre = caja.MontoCierre,
                    MontoApertura = caja.MontoApertura,
                    FechaCierre = caja.FechaCierre,
                    TotalCaja = caja.TotalCaja,
                    Id = caja.Id,
                    OpenClose = caja.OpenClose,

                };

                return cajaAux;

            }
        }

        public IEnumerable<CajaDto> BuscarCajasPorApertura(DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Cajas.AsNoTracking().Where(x => x.FechaApertura.Day >= desde.Day && x.FechaApertura.Month >= desde.Month && x.FechaApertura.Year >= desde.Year && x.FechaApertura.Day <= hasta.Day && x.FechaApertura.Month <= hasta.Month && x.FechaApertura.Year <= hasta.Year)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose,

                    }).ToList();
            }
        }

        public IEnumerable<CajaDto> BuscarCajasPorCierre(DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {
                return context.Cajas.AsNoTracking().Where(x => x.FechaCierre.Day >= desde.Day && x.FechaCierre.Month >= desde.Month && x.FechaCierre.Year >= desde.Year && x.FechaCierre.Day <= hasta.Day && x.FechaCierre.Month <= hasta.Month && x.FechaCierre.Year <= hasta.Year)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose,

                    }).ToList();
            }
        }

        public IEnumerable<CajaDto> BuscarCajasPorMes()
        {
            using (var context = new KosakoDBEntities())
            {
                var fecha = DateTime.Now;
                fecha.AddDays(-30);

                return context.Cajas.AsNoTracking().Where(x => x.FechaCierre.Day >= fecha.Day && x.FechaCierre.Month >= fecha.Month && x.FechaCierre.Year >= fecha.Year)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose,

                    }).ToList();
            }
        }

    }
}
