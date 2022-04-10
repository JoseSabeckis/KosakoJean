using AccesoDatos;
using Servicios.Core.CtaCte.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.CtaCte
{
    public class CtaCteServicio : ICtaCteServicio
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
                    ClienteId = ctaCteDto.ClienteId,
                    PedidoId = ctaCteDto.PedidoId
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

                if (cuenta.Debe == 0)
                {
                    cuenta.Estado = CtaCteEstado.Pagado;
                }

                context.SaveChanges();

            }
        }

        public void SumarLoQueDebe(decimal monto, long clienteId, long cuentaId)
        {
            using (var context = new KosakoDBEntities())
            {
                var cuenta = context.CtasCtes.FirstOrDefault(x => x.ClienteId == clienteId && x.Id == cuentaId);

                cuenta.Debe += monto;

                if (cuenta.Debe == 0)
                {
                    cuenta.Estado = CtaCteEstado.Pagado;
                }

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
                    Estado = x.Estado,
                    PedidoId = x.PedidoId

                }).ToList();
            }
        }

        public CtaCteDto ObtenerPorId(long ctaId)
        {
            using (var context = new KosakoDBEntities())
            {
                var cuenta = context.CtasCtes.FirstOrDefault(x => x.Id == ctaId);

                var cuentaNueva = new CtaCteDto
                {
                    Id = cuenta.Id,
                    ClienteId = cuenta.ClienteId,
                    Debe = cuenta.Debe,
                    Descripcion = cuenta.Descripcion,
                    Total = cuenta.Total,
                    Fecha = cuenta.Fecha,
                    Estado = cuenta.Estado,
                    PedidoId = cuenta.PedidoId

                };

                return cuentaNueva;

            }
        }

        public CtaCteDto ObtenerPorIdDePedidosId(long pedidoId)
        {
            using (var context = new KosakoDBEntities())
            {
                var cuenta = context.CtasCtes.FirstOrDefault(x => x.PedidoId == pedidoId);

                var cuentaNueva = new CtaCteDto
                {
                    Id = cuenta.Id,
                    ClienteId = cuenta.ClienteId,
                    Debe = cuenta.Debe,
                    Descripcion = cuenta.Descripcion,
                    Total = cuenta.Total,
                    Fecha = cuenta.Fecha,
                    Estado = cuenta.Estado,
                    PedidoId = cuenta.PedidoId                  

                };

                return cuentaNueva;

            }
        }

    }
}
