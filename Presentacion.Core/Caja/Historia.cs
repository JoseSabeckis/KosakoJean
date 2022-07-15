using Presentacion.Clases;
using Presentacion.Core.Factura;
using Servicios.Core.Caja;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleProducto;
using Servicios.Core.Fecha;
using Servicios.Core.Image.Dto;
using Servicios.Core.Negocio;
using Servicios.Core.Negocio.Dto;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class Historia : Form
    {
        private readonly IDetalleCajaServicio _detalleCajaServicio;
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleProductoServicio detalleProductoServicio;
        private readonly INegocioServicio negocioServicio;

        long _CajaId;
        long _DetalleId;

        NegocioDto _Negocio;

        public Historia(long id)
        {
            InitializeComponent();

            _detalleCajaServicio = new DetalleCajaServicio();
            cajaServicio = new CajaServicio();
            detalleProductoServicio = new DetalleProductoServicio();
            negocioServicio = new NegocioServicio();

            _CajaId = id;

            CargarGrilla();

            Calculos();

            CargarImageEnGeneral();

            VerificarSiHayCobros();

            DatosNegocio();
        }

        public void DatosNegocio()
        {
            _Negocio = negocioServicio.ObtenerPorId(1);
        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = _detalleCajaServicio.Lista(_CajaId);

            FormatearGrilla(dgvGrilla);
        }

        public void VerificarSiHayCobros()
        {
            if (_detalleCajaServicio.Lista(_CajaId).Count() == 0)
            {
                btnEliminar.Visible = false;
            }
        }

        private void CargarImageEnGeneral()
        {
            imgCaja.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Caja);
        }

        private void Calculos()
        {
            var caja = cajaServicio.BuscarCajasId(_CajaId);

            lblDesde.Text = $"{caja.FechaApertura}";

            lblHasta.Text = $"{caja.FechaCierre}";

            //listo caja ahora detalle

            nudTotal.Value = caja.TotalCaja;

            nudSinMonto.Value = caja.TotalCaja - caja.MontoApertura;

            nudComienzoCaja.Value = caja.MontoApertura;

        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Total"].Visible = true;
            grilla.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Total"].HeaderText = @"Total";
            grilla.Columns["Total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Fecha"].HeaderText = @"Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["TipoPago"].Visible = true;
            grilla.Columns["TipoPago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TipoPago"].HeaderText = @"Tipo Pago";
            grilla.Columns["TipoPago"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Tipopago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Este Seguro De Eliminar Este Cobro?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                detalleProductoServicio.EliminarTodoPorDetalleCajaId(_DetalleId);

                var dinero = _detalleCajaServicio.BuscarDetallePorId(_DetalleId);

                cajaServicio.RestarDineroACaja(_CajaId, dinero);

                VerificarSiHayCobros();

                CargarGrilla();
                Calculos();

                VerificarBotonTicket();
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _DetalleId = (long)dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                _DetalleId = 0;
            }
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (_DetalleId != 0)
            {/*
                if (detalleProductoServicio.ObtenerListaPorDetalleId(_DetalleId).Count() == 0)
                {
                    MessageBox.Show("Solo Ventas y Pedidos Se Veran.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
             */
                var formDetalle = new DetalleCaja(_DetalleId);
                formDetalle.ShowDialog();
            }
        }

        public void VerificarBotonTicket()
        {           
            if (_detalleCajaServicio.Lista(_CajaId).Count() == 0)
            {
                btnTicket.Visible = false;
                btnCrearTicket.Visible = false;
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            if (_DetalleId != 0)
            {
                //ticket

                var fecha = new FechaDto
                {
                    Fecha = DateTime.Now.ToShortDateString(),
                    Hora = DateTime.Now.ToShortTimeString()
                };

                List<VentaDto2> ListaVenta = new List<VentaDto2>();

                ListaVenta = detalleProductoServicio.ObtenerListaPorDetalleId(_DetalleId);

                var factura = new Comprobante(ListaVenta, fecha);
                factura.ShowDialog();
            }
        }

        private void Historia_Load(object sender, EventArgs e)
        {
            VerificarBotonTicket();
        }

        private void btnCrearTicket_Click(object sender, EventArgs e)
        {
            var _Detalle = _detalleCajaServicio.ObtenerPorId(_DetalleId);

            CrearTicket ticket = new CrearTicket();

            ticket.AbreCajon();

            ticket.TextoCentro(_Negocio.RazonSocial);
            ticket.TextoIzquierda(" ");
            ticket.TextoIzquierda("Cuit: " + _Negocio.Cuit);
            ticket.TextoIzquierda("Direccion: " + _Negocio.Direccion);
            ticket.TextoIzquierda("Celular: " + _Negocio.Celular);
            ticket.TextoIzquierda("Mail: " + _Negocio.Email);

            ticket.TextoIzquierda(" ");
            //ticket.textoExtremos("Caja #1", "Ticket #002-00001")
            ticket.LineaAstericoMetodo();//*********

            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("Atendio: VENDEDOR");
            ticket.TextoIzquierda("Cliente: PUBLICO EN GENERAL");
            ticket.TextoIzquierda("Fecha: " + _Detalle.Fecha);
            ticket.LineaAstericoMetodo();//*********

            ticket.Encabezado();//descripcion, cantidad, precio, total

            ticket.LineaAstericoMetodo();//*********

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
            ticket.TextoIzquierda(" ");
            ticket.TextoIzquierda("Articulos Vendidos: " + cantComprados);
            ticket.TextoIzquierda(" ");

            ticket.TextoCentro("-- GRACIAS POR SU COMPRA! --");
            ticket.CortaTicket();

            ticket.ImprimirTicket("POS58 Printer");
        }
    }
}
