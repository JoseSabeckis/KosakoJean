using AccesoDatos;
using Servicios.Core.DetalleCaja.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Servicios.Core.DetalleCaja
{
    public class DetalleCajaServicio : IDetalleCajaServicio
    {
        public long AgregarDetalleCaja(DetalleCajaDto detalleCajaDto)
        {
            using (var context = new KosakoDBEntities())
            {
                var detalleCaja = new AccesoDatos.DetalleCaja
                {
                    Descripcion = detalleCajaDto.Descripcion,
                    Fecha = detalleCajaDto.Fecha,
                    Total = detalleCajaDto.Total,
                    CajaId = detalleCajaDto.CajaId,
                    TipoPago = detalleCajaDto.TipoPago,
                    NumeroOperacion = detalleCajaDto.NumeroOperacion,
                    TipoOperacion = detalleCajaDto.TipoOperacion,
                    ClienteId = detalleCajaDto.ClienteId,
                    PedidoId = detalleCajaDto.PedidoId,
                    ArregloId = detalleCajaDto.ArregloId,
                    CtaCteId = detalleCajaDto.CtaCteId,                   
                };

                context.DetalleCajas.Add(detalleCaja);

                context.SaveChanges();

                return detalleCaja.Id;
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
                        TipoPago = x.TipoPago,
                        EstaEliminado = x.EstaEliminado,
                        NumeroOperacion = x.NumeroOperacion,
                        TipoOperacion = x.TipoOperacion,
                        ClienteId = x.ClienteId,
                        PedidoId = x.PedidoId,
                        ArregloId = x.ArregloId

                    }).ToList();

            }
        }

        public DetalleCajaDto ObtenerPorId(long detalleId)
        {
            using (var context = new KosakoDBEntities())
            {

                var detalle = context.DetalleCajas.FirstOrDefault(x => x.Id == detalleId);

                return new DetalleCajaDto
                {

                    Id = detalle.Id,
                    CajaId = detalle.CajaId,
                    Descripcion = detalle.Descripcion,
                    Total = detalle.Total,
                    Fecha = detalle.Fecha,
                    TipoPago = detalle.TipoPago,
                    EstaEliminado = detalle.EstaEliminado,
                    NumeroOperacion = detalle.NumeroOperacion,
                    TipoOperacion = detalle.TipoOperacion,
                    ClienteId = detalle.ClienteId,
                    PedidoId = detalle.PedidoId,
                    ArregloId = detalle.ArregloId

                };

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
                    //context.DetalleCajas.Remove(item);
                    item.EstaEliminado = true;
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

        public double BuscarDetallePorId(long detalleId)
        {
            using (var context = new KosakoDBEntities())
            {
                var detalle = context.DetalleCajas.FirstOrDefault(x => x.Id == detalleId);

                var dinero = detalle.Total;

                //context.DetalleCajas.Remove(detalle);
                detalle.EstaEliminado = true;

                context.SaveChanges();

                return dinero;
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
                        TipoPago = x.TipoPago,
                        EstaEliminado = x.EstaEliminado,
                        NumeroOperacion = x.NumeroOperacion,
                        TipoOperacion = x.TipoOperacion,
                        ClienteId = x.ClienteId,
                        PedidoId = x.PedidoId,
                        ArregloId = x.ArregloId

                    }).ToList();

                return lista;

            }

        }

        public DetalleCajaDto BuscarDetalleConArregloId(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var x = context.DetalleCajas.FirstOrDefault(a => a.ArregloId == id);

                var arreglo = new DetalleCajaDto
                {

                    CajaId = x.CajaId,
                    Descripcion = x.Descripcion,
                    Fecha = x.Fecha,
                    Total = x.Total,
                    Id = x.Id,
                    TipoPago = x.TipoPago,
                    EstaEliminado = x.EstaEliminado,
                    NumeroOperacion = x.NumeroOperacion,
                    TipoOperacion = x.TipoOperacion,
                    ClienteId = x.ClienteId,
                    PedidoId = x.PedidoId,
                    ArregloId = x.ArregloId

                };

                return arreglo;

            }

        }

        public DetalleCajaDto BuscarDetalleConPedidoId(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var x = context.DetalleCajas.FirstOrDefault(a => a.PedidoId == id);

                var arreglo = new DetalleCajaDto
                {

                    CajaId = x.CajaId,
                    Descripcion = x.Descripcion,
                    Fecha = x.Fecha,
                    Total = x.Total,
                    Id = x.Id,
                    TipoPago = x.TipoPago,
                    EstaEliminado = x.EstaEliminado,
                    NumeroOperacion = x.NumeroOperacion,
                    TipoOperacion = x.TipoOperacion,
                    ClienteId = x.ClienteId,
                    PedidoId = x.PedidoId,
                    ArregloId = x.ArregloId

                };

                return arreglo;

            }

        }

        public DetalleCajaDto BuscarDetalleConCtaCteId(long id)
        {
            using (var context = new KosakoDBEntities())
            {

                var x = context.DetalleCajas.FirstOrDefault(a => a.CtaCteId == id);

                var arreglo = new DetalleCajaDto
                {

                    CajaId = x.CajaId,
                    Descripcion = x.Descripcion,
                    Fecha = x.Fecha,
                    Total = x.Total,
                    Id = x.Id,
                    TipoPago = x.TipoPago,
                    EstaEliminado = x.EstaEliminado,
                    NumeroOperacion = x.NumeroOperacion,
                    TipoOperacion = x.TipoOperacion,
                    ClienteId = x.ClienteId,
                    PedidoId = x.PedidoId,
                    ArregloId = x.ArregloId

                };

                return arreglo;

            }

        }

        public IEnumerable<DetalleCajaDto> BuscarDetallesNumerosOperacion(string numeroOperacion)
        {
            using (var context = new KosakoDBEntities())
            {

                var lista = context.DetalleCajas.AsNoTracking().Where(x => x.NumeroOperacion.ToString().Contains(numeroOperacion))
                    .Select(x => new DetalleCajaDto
                    {
                        CajaId = x.CajaId,
                        Descripcion = x.Descripcion,
                        Fecha = x.Fecha,
                        Total = x.Total,
                        Id = x.Id,
                        TipoPago = x.TipoPago,
                        EstaEliminado = x.EstaEliminado,
                        NumeroOperacion = x.NumeroOperacion,
                        TipoOperacion = x.TipoOperacion,
                        ClienteId = x.ClienteId,
                        PedidoId = x.PedidoId,
                        ArregloId = x.ArregloId

                    }).ToList();

                return lista;

            }

        }

        public string TraerNuevoNumeroOperacion()
        {
            using (var context = new KosakoDBEntities())
            {
                if (context.DetalleCajas.Count() == 0)
                {
                    return "00001";
                }

                var bandera = context.DetalleCajas.Max(x => x.NumeroOperacion);

                return $"{bandera + 1:00000}";

            }
        }

    }
}
