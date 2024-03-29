﻿using Presentacion.Clases;
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
using System.Drawing.Printing;
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
        private readonly ITicketServicio ticketServicio;

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
            ticketServicio = new TicketServicio();

            _CajaId = id;

            CargarGrilla();

            Calculos();

            CargarImageEnGeneral();

            VerificarSiHayCobros();

            DatosNegocio();

            MostrarImpresoras();
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

            nudTotal.Value = (decimal)caja.TotalCaja;

            nudSinMonto.Value = (decimal)(caja.TotalCaja - caja.MontoApertura);

            nudComienzoCaja.Value = (decimal)caja.MontoApertura;

        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["NumeroOperacionVista"].Visible = true;
            grilla.Columns["NumeroOperacionVista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["NumeroOperacionVista"].HeaderText = @"Nro";
            grilla.Columns["NumeroOperacionVista"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["NumeroOperacionVista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["TotalString"].Visible = true;
            grilla.Columns["TotalString"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TotalString"].HeaderText = @"Total";
            grilla.Columns["TotalString"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["TotalString"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

                _detalleCajaServicio.EliminarUnaVenta(_DetalleId);

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
                cmbImpresoras.Visible = false;
                lblUsar.Visible = false;
            }
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            if (_DetalleId != 0)
            {
                //ticket

                List<VentaDto2> ListaVenta = new List<VentaDto2>();

                ListaVenta = detalleProductoServicio.ObtenerListaPorDetalleId(_DetalleId);

                var fecha = new FechaDto
                {
                    Fecha = DateTime.Now.ToShortDateString(),
                    Hora = DateTime.Now.ToShortTimeString(),
                    NumeroOperacion = _detalleCajaServicio.ObtenerPorId(_DetalleId).NumeroOperacion.ToString("00000")
                };

                var factura = new Comprobante(ListaVenta, fecha);
                factura.ShowDialog();
            }
        }

        private void Historia_Load(object sender, EventArgs e)
        {
            VerificarBotonTicket();
        }

        public void MostrarImpresoras()
        {
            var pd = new PrintDocument();

            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbImpresoras.Items.Add(strPrinter);
            }

            var name = pd.PrinterSettings.PrinterName;

            var index = cmbImpresoras.FindString(name);

            cmbImpresoras.SelectedIndex = index;
        }

        private void btnCrearTicket_Click(object sender, EventArgs e)
        {
            if (cmbImpresoras.Text == string.Empty)
            {
                MessageBox.Show("Elija el Formato de Impresion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var detalle = _detalleCajaServicio.ObtenerPorId(_DetalleId);

            if (detalle.TipoOperacion == AccesoDatos.TipoOperacion.Venta)
            {
                ticketServicio.ImprimirAutomaticamenteVenta(_DetalleId, cmbImpresoras.Text, detalle.ClienteId);
            }

            if (detalle.TipoOperacion == AccesoDatos.TipoOperacion.Pedido)
            {
                ticketServicio.ImprimirAutomaticamentePedido(_DetalleId, cmbImpresoras.Text, detalle.ClienteId, detalle.PedidoId);
            }

            if (detalle.TipoOperacion == AccesoDatos.TipoOperacion.Arreglo)
            {
                ticketServicio.ImprimirAutomaticamenteArreglo(_DetalleId, cmbImpresoras.Text, (long)detalle.PedidoId);
            }

            if (detalle.TipoOperacion == AccesoDatos.TipoOperacion.CtaCte)
            {
                ticketServicio.ImprimirAutomaticamenteCtaCte(_DetalleId, cmbImpresoras.Text, detalle.ClienteId);
            }

        }
    }
}
