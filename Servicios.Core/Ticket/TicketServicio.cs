using Servicios.Core.Cliente;
using Servicios.Core.Configuracion;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleProducto;
using Servicios.Core.Negocio;
using Servicios.Core.Pedido;
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
        private readonly IClienteServicio clienteServicio = new ClienteServicio();
        private readonly IPedidoServicio pedidoServicio = new PedidoServicio();
        private readonly IConfiguracionServicio configuracionServicio = new ConfiguracionServicio();

        public void ImprimirAutomaticamenteVenta(long _DetalleId, string impresora, long clienteId)//Venta
        {
            var _Detalle = _detalleCajaServicio.ObtenerPorId(_DetalleId);
            var _Negocio = negocioServicio.ObtenerPorId(1);
            var _Cliente = clienteServicio.ObtenerPorId(clienteId);

            //configuracion
            var Config = configuracionServicio.ObtenerPorId(1);

            CrearTicket ticket = new CrearTicket();

            ticket.AbreCajon();

            ticket.TextoCentro(_Negocio.RazonSocial);

            if (Config.MostrarDatos)
            {
                ticket.TextoIzquierda("Cuit: " + _Negocio.Cuit);
                ticket.TextoIzquierda("Direccion: " + _Negocio.Direccion);
                ticket.TextoIzquierda("Mail: " + _Negocio.Email);
            }

            ticket.TextoIzquierda("Celular: " + _Negocio.Celular);
            //ticket.textoExtremos("Caja #1", "Ticket #002-00001")
            ticket.LineaAstericoMetodo();//*********

            //ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Atencion: VENDEDOR");
            ticket.TextoIzquierda($"Cliente: {_Cliente.Apellido} {_Cliente.Nombre}");
            ticket.TextoIzquierda("Fecha: " + _Detalle.Fecha);
            ticket.LineaAstericoMetodo();//*********

            ticket.Encabezado();//descripcion, cantidad, precio, total
            ticket.LineaIgualMetodo();
            //ticket.LineaAstericoMetodo();//*********

            var ListaVenta = detalleProductoServicio.ObtenerListaPorDetalleId(_DetalleId);

            double total = 0;
            int cantComprados = 0;
            string numeroOperacion = _detalleCajaServicio.ObtenerPorId(_DetalleId).NumeroOperacion.ToString("00000");

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
            ticket.TextoIzquierda("#" + numeroOperacion);
            ticket.CortaTicket();

            ticket.ImprimirTicket(impresora);//POS58 Printer
        }

        public void ImprimirAutomaticamentePedido(long _DetalleId, string impresora, long clienteId, long? pedidoId)//Pedido
        {
            var _Detalle = _detalleCajaServicio.ObtenerPorId(_DetalleId);
            var _Negocio = negocioServicio.ObtenerPorId(1);
            var _Cliente = clienteServicio.ObtenerPorId(clienteId);

            var _Pedido = pedidoServicio.BuscarIDPedidos((long)pedidoId);

            //configuracion
            var Config = configuracionServicio.ObtenerPorId(1);

            CrearTicket ticket = new CrearTicket();

            ticket.AbreCajon();

            ticket.TextoCentro(_Negocio.RazonSocial);

            if (Config.MostrarDatos)
            {
                ticket.TextoIzquierda("Cuit: " + _Negocio.Cuit);
                ticket.TextoIzquierda("Direccion: " + _Negocio.Direccion);
                ticket.TextoIzquierda("Mail: " + _Negocio.Email);
            }
            ticket.TextoIzquierda("Celular: " + _Negocio.Celular);

            //ticket.textoExtremos("Caja #1", "Ticket #002-00001")
            ticket.LineaAstericoMetodo();//*********

            //ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Atencion: VENDEDOR");
            ticket.TextoIzquierda($"Cliente: {_Detalle.Descripcion}");
            ticket.TextoIzquierda("Fecha: " + _Detalle.Fecha);
            ticket.TextoIzquierda("Retirar El: " + _Pedido.FechaEntrega.ToLongDateString());
            ticket.TextoIzquierda("A La: " + _Pedido.Horario);
            ticket.LineaAstericoMetodo();//*********

            ticket.Encabezado();//descripcion, cantidad, precio, total
            ticket.LineaIgualMetodo();
            //ticket.LineaAstericoMetodo();//*********

            var ListaVenta = detalleProductoServicio.ObtenerListaPorDetalleId(_DetalleId);

            double total = 0;
            int cantComprados = 0;
            string numeroOperacion = _detalleCajaServicio.ObtenerPorId(_DetalleId).NumeroOperacion.ToString("00000");

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
            ticket.TextoIzquierda("#" + numeroOperacion);
            ticket.CortaTicket();

            ticket.ImprimirTicket(impresora);//POS58 Printer
        }

        public void ImprimirAutomaticamenteArreglo(long _DetalleId, string impresora, long? pedidoId)//Arreglo
        {
            var _Detalle = _detalleCajaServicio.ObtenerPorId(_DetalleId);
            var _Negocio = negocioServicio.ObtenerPorId(1);

            var _Pedido = pedidoServicio.BuscarIDPedidos((long)pedidoId);

            //configuracion
            var Config = configuracionServicio.ObtenerPorId(1);

            CrearTicket ticket = new CrearTicket();

            ticket.AbreCajon();

            ticket.TextoCentro(_Negocio.RazonSocial);

            if (Config.MostrarDatos)
            {
                ticket.TextoIzquierda("Cuit: " + _Negocio.Cuit);
                ticket.TextoIzquierda("Direccion: " + _Negocio.Direccion);
                ticket.TextoIzquierda("Mail: " + _Negocio.Email);
            }
            ticket.TextoIzquierda("Celular: " + _Negocio.Celular);

            //ticket.textoExtremos("Caja #1", "Ticket #002-00001")
            ticket.LineaAstericoMetodo();//*********

            //ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Atencion: VENDEDOR");
            ticket.TextoIzquierda($"{_Detalle.Descripcion}");
            ticket.TextoIzquierda("Fecha: " + _Detalle.Fecha);
            ticket.TextoIzquierda("Retirar El: " + _Pedido.FechaEntrega.ToLongDateString());
            ticket.TextoIzquierda("A La: " + _Pedido.Horario);
            ticket.LineaAstericoMetodo();//*********

            ticket.Encabezado();//descripcion, cantidad, precio, total
            ticket.LineaIgualMetodo();
            //ticket.LineaAstericoMetodo();//*********

            var ListaVenta = detalleProductoServicio.ObtenerListaPorDetalleId(_DetalleId);

            double total = 0;
            int cantComprados = 0;
            string numeroOperacion = _detalleCajaServicio.ObtenerPorId(_DetalleId).NumeroOperacion.ToString("00000");

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
            ticket.TextoIzquierda("#" + numeroOperacion);
            ticket.CortaTicket();

            ticket.ImprimirTicket(impresora);//POS58 Printer
        }

    }
}
