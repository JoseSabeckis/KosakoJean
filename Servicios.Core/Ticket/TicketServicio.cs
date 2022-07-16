using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleProducto;
using Servicios.Core.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Ticket
{
    public class TicketServicio : ITicketServicio
    {
        private readonly IDetalleCajaServicio _detalleCajaServicio = new DetalleCajaServicio();
        private readonly INegocioServicio negocioServicio = new NegocioServicio();
        private readonly IDetalleProductoServicio detalleProductoServicio = new DetalleProductoServicio();

        public void ImprimirAutomaticamente(long _DetalleId, string impresora)
        {
            var _Detalle = _detalleCajaServicio.ObtenerPorId(_DetalleId);
            var _Negocio = negocioServicio.ObtenerPorId(1);

            CrearTicket ticket = new CrearTicket();

            ticket.AbreCajon();

            ticket.TextoCentro(_Negocio.RazonSocial);
            ticket.TextoIzquierda(" ");
            ticket.TextoIzquierda("Cuit: " + _Negocio.Cuit);
            ticket.TextoIzquierda("Direccion: " + _Negocio.Direccion);
            ticket.TextoIzquierda("Celular: " + _Negocio.Celular);
            ticket.TextoIzquierda("Mail: " + _Negocio.Email);

            //ticket.TextoIzquierda(" ");
            //ticket.textoExtremos("Caja #1", "Ticket #002-00001")
            ticket.LineaAstericoMetodo();//*********

            //ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Atencion: VENDEDOR");
            ticket.TextoIzquierda("Cliente: Consumidor Final");
            ticket.TextoIzquierda("Fecha: " + _Detalle.Fecha);
            ticket.LineaAstericoMetodo();//*********

            ticket.Encabezado();//descripcion, cantidad, precio, total
            ticket.LineaIgualMetodo();
            //ticket.LineaAstericoMetodo();//*********

            var ListaVenta = detalleProductoServicio.ObtenerListaPorDetalleId(_DetalleId);

            decimal total = 0;
            int cantComprados = 0;

            foreach (var item in ListaVenta)
            {
                ticket.AgregaArticulo(item.Descripcion, (int)item.Cantidad, item.Precio, item.Precio * item.Cantidad);

                total += item.Precio * item.Cantidad;
                cantComprados += (int)item.Cantidad;
            }

            ticket.LineaIgualMetodo();

            ticket.TextoIzquierda(" ");
            ticket.AgregarTotales("Total:....$", total);
            //ticket.TextoIzquierda(" ");
            ticket.TextoIzquierda("Articulos Vendidos: " + cantComprados);
            ticket.TextoIzquierda(" ");

            ticket.TextoCentro("-- GRACIAS POR SU COMPRA! --");
            ticket.CortaTicket();

            ticket.ImprimirTicket(impresora);//POS58 Printer
        }
    }
}
