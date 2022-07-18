using AccesoDatos;
using Servicios.Core.Caja.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void CerrarCaja(decimal montoCierre, string fechaCierre)
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

        public void RestarDineroACaja(long cajaId, decimal dinero)
        {
            using (var context = new KosakoDBEntities())
            {

                var caja = context.Cajas.FirstOrDefault(x => x.Id == cajaId);

                caja.TotalCaja -= dinero;

                caja.MontoCierre -= dinero;

                context.SaveChanges();

            }
        }

        public AccesoDatos.Caja BuscarCajaAbierta()
        {
            using (var context = new KosakoDBEntities())
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

        public void RestarDineroDeCaja(decimal monto)
        {
            using (var context = new KosakoDBEntities())
            {
                var caja = context.Cajas.FirstOrDefault(x => x.OpenClose == OpenClose.Abierto);

                caja.TotalCaja -= monto;

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
            using (var context = new KosakoDBEntities())
            {
                return context.Cajas.AsNoTracking().Where(x => x.OpenClose == OpenClose.Cerrado && !x.EstaEliminado)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose,
                        EstaEliminado = x.EstaEliminado

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
                    EstaEliminado = caja.EstaEliminado

                };

                return cajaAux;

            }
        }

        public void EliminarCaja(long id)
        {
            using (var context = new KosakoDBEntities())
            {
                var caja = context.Cajas.FirstOrDefault(x => x.Id == id);

                caja.EstaEliminado = true;

                context.SaveChanges();

            }
        }

        public IEnumerable<CajaDto> BuscarCajasPorApertura(DateTime desde, DateTime hasta)
        {
            using (var context = new KosakoDBEntities())
            {
                var caja = context.Cajas.Where(x => x.FechaApertura >= desde && !x.EstaEliminado);

                return caja.Where(x => x.FechaApertura <= hasta)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

        public IEnumerable<CajaDto> BuscarCajasPorMes()
        {
            using (var context = new KosakoDBEntities())
            {
                var fecha = DateTime.Now.AddDays(-30);

                return context.Cajas.Where(x => x.FechaApertura >= fecha && !x.EstaEliminado)
                    .Select(x => new CajaDto
                    {
                        TotalCaja = x.TotalCaja,
                        FechaApertura = x.FechaApertura,
                        FechaCierre = x.FechaCierre,
                        MontoApertura = x.MontoApertura,
                        MontoCierre = x.MontoCierre,
                        Id = x.Id,
                        OpenClose = x.OpenClose,
                        EstaEliminado = x.EstaEliminado

                    }).ToList();
            }
        }

    }
}
