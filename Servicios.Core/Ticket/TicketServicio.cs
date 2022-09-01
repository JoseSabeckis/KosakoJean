using Servicios.Core.Arreglo;
using Servicios.Core.Cliente;
using Servicios.Core.Colegio;
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
        private readonly IArregloServicio arregloServicio = new ArregloServicio();

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
            ticket.TextoIzquierda(" ");

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
                var colegio = "";
                var talle = "";

                colegio = NombreSiEsDistintoaA1(item.ColegioId, item.Colegio);
                talle = NombreSiEsDistintoaA1(item.TalleId, item.Talle);

                ticket.AgregaArticulo(item.Descripcion + colegio + talle, (int)item.Cantidad, item.Precio, item.Precio * item.Cantidad);

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
            ticket.TextoIzquierda(" ");

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
            ticket.TextoIzquierda($"Cliente: {_Pedido.Apellido} {_Pedido.Nombre}");
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
                var colegio = "";
                var talle = "";

                colegio = NombreSiEsDistintoaA1(item.ColegioId, item.Colegio);
                talle = NombreSiEsDistintoaA1(item.TalleId, item.Talle);

                ticket.AgregaArticulo(item.Descripcion + colegio + talle, (int)item.Cantidad, item.Precio, item.Precio * item.Cantidad);

                total += item.Precio * item.Cantidad;
                cantComprados += (int)item.Cantidad;
            }

            ticket.LineaIgualMetodo();

            ticket.TextoIzquierda(" ");
            ticket.AgregarTotales("Total:....$", total);
            ticket.AgregarTotales("Adelanto:.$", _Pedido.Adelanto);
            ticket.AgregarTotales("Debe:.....$", total - _Pedido.Adelanto);
            //ticket.TextoIzquierda(" ");
            ticket.TextoIzquierda("Articulos Vendidos: " + cantComprados);
            ticket.TextoIzquierda(" ");

            ticket.TextoCentro("-- GRACIAS POR SU COMPRA! --");
            ticket.TextoIzquierda("#" + numeroOperacion);
            ticket.CortaTicket();

            ticket.ImprimirTicket(impresora);//POS58 Printer
        }

        public void ImprimirAutomaticamenteArreglo(long _DetalleId, string impresora, long arregloId)//Arreglo
        {
            var _Detalle = _detalleCajaServicio.ObtenerPorId(_DetalleId);
            var _Negocio = negocioServicio.ObtenerPorId(1);

            var _Arreglo = arregloServicio.ObtenerPorId(arregloId);

            //configuracion
            var Config = configuracionServicio.ObtenerPorId(1);

            CrearTicket ticket = new CrearTicket();

            ticket.AbreCajon();

            ticket.TextoCentro(_Negocio.RazonSocial);
            ticket.TextoIzquierda(" ");

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
            ticket.TextoIzquierda($"{_Arreglo.ApyNom}");
            ticket.TextoIzquierda("Fecha: " + _Detalle.Fecha);
            ticket.TextoIzquierda("Retirar El: " + _Arreglo.FechaEntrega.ToLongDateString());
            ticket.TextoIzquierda("A La: " + _Arreglo.Horario);
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
                var colegio = "";
                var talle = "";

                colegio = NombreSiEsDistintoaA1(item.ColegioId, item.Colegio);
                talle = NombreSiEsDistintoaA1(item.TalleId, item.Talle);

                ticket.AgregaArticulo(item.Descripcion + colegio + talle, (int)item.Cantidad, item.Precio, item.Precio * item.Cantidad);

                total += item.Precio * item.Cantidad;
                cantComprados += (int)item.Cantidad;
            }

            ticket.LineaIgualMetodo();

            ticket.TextoIzquierda(" ");
            ticket.AgregarTotales("Total:....$", total);
            ticket.AgregarTotales("Adelanto:.$", _Arreglo.Adelanto);
            ticket.AgregarTotales("Debe:.....$", total - _Arreglo.Adelanto);
            //ticket.TextoIzquierda(" ");
            ticket.TextoIzquierda("Articulos Vendidos: " + cantComprados);
            ticket.TextoIzquierda(" ");

            ticket.TextoCentro("-- GRACIAS POR SU COMPRA! --");
            ticket.TextoIzquierda("#" + numeroOperacion);
            ticket.CortaTicket();

            ticket.ImprimirTicket(impresora);//POS58 Printer
        }

        public void ImprimirAutomaticamenteCtaCte(long _DetalleId, string impresora, long clienteId)//CtaCte
        {
            var _Detalle = _detalleCajaServicio.ObtenerPorId(_DetalleId);
            var _Negocio = negocioServicio.ObtenerPorId(1);
            var _Cliente = clienteServicio.ObtenerPorId(clienteId);

            //configuracion
            var Config = configuracionServicio.ObtenerPorId(1);

            CrearTicket ticket = new CrearTicket();

            ticket.AbreCajon();

            ticket.TextoCentro(_Negocio.RazonSocial);
            ticket.TextoIzquierda(" ");

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
            ticket.TextoIzquierda($"{_Cliente.Apellido} {_Cliente.Nombre}");
            ticket.TextoIzquierda("Fecha: " + _Detalle.Fecha);
            ticket.LineaAstericoMetodo();//*********

            ticket.Encabezado();//descripcion, cantidad, precio, total
            ticket.LineaIgualMetodo();
            //ticket.LineaAstericoMetodo();//*********

            var ListaVenta = detalleProductoServicio.ObtenerListaPorDetalleId(_DetalleId);

            double total = 0;
            string numeroOperacion = _detalleCajaServicio.ObtenerPorId(_DetalleId).NumeroOperacion.ToString("00000");

            foreach (var item in ListaVenta)
            {
                var colegio = "";
                var talle = "";

                colegio = NombreSiEsDistintoaA1(item.ColegioId, item.Colegio);
                talle = NombreSiEsDistintoaA1(item.TalleId, item.Talle);

                ticket.AgregaArticulo(item.Descripcion + colegio + talle, (int)item.Cantidad, item.Precio, item.Precio * item.Cantidad);

                total += item.Precio * item.Cantidad;
            }

            ticket.LineaIgualMetodo();

            ticket.TextoIzquierda(" ");
            ticket.AgregarTotales("Total:....$", total);
            ticket.TextoIzquierda(" ");

            ticket.TextoCentro("-- GRACIAS POR SU COMPRA! --");
            ticket.TextoIzquierda("#" + numeroOperacion);
            ticket.CortaTicket();

            ticket.ImprimirTicket(impresora);//POS58 Printer
        }

        public string NombreSiEsDistintoaA1(long? id, string nombre)
        {
            var retorno = "";

            if (id != null && id != 1)
            {
                retorno = " " + nombre;
            }

            return retorno;

        }

    }
}
