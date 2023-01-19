using Servicios.Core.Caja;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.DetalleProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class CerrarCaja : Form
    {
        private readonly ICajaServicio _cajaServicio;
        private readonly IDetalleCajaServicio _detalleCajaServicio;
        private readonly IDetalleProductoServicio detalleProductoServicio;

        double _Total;
        long CajaAbiertaId;
        long _DetalleId;

        public CerrarCaja()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
            _detalleCajaServicio = new DetalleCajaServicio();
            detalleProductoServicio = new DetalleProductoServicio();

            CargarDatos();

            CajaAbiertaId = _detalleCajaServicio.BuscarCajaAbierta();
            lblApertura.Text = $"Monto Apertura: {_cajaServicio.BuscarCajasId(CajaAbiertaId).MontoApertura}";
            CargarGrilla();
            VerSiHayVentas();
        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = ActualizarGrilla().ToList();
            FormatearGrilla(dgvGrilla);
        }

        public IEnumerable<DetalleCajaDto> ActualizarGrilla()
        {
            return _detalleCajaServicio.BuscarDetalles(CajaAbiertaId);
        }

        private void VerSiHayVentas()
        {
            if (_detalleCajaServicio.BuscarDetalles(CajaAbiertaId).Count() == 0)
            {
                btnQuitar.Visible = false;
            }
            else
            {
                btnQuitar.Visible = true;
            }
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

        public void CargarDatos()
        {
            var total = _cajaServicio.SumarCaja();
            var suma = _cajaServicio.BuscarCajaAbierta();

            txtCobrado.Text = (total - suma.MontoApertura).ToString("00.00");
            txtTotal.Text = total.ToString("00.00");

            _Total = total;
        }

        private void btmVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (_cajaServicio.BuscarCajaAbierta() == null)
            {
                MessageBox.Show("la Caja Se Encuentra Cerrada", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Close();
                return;
            }

            if (MessageBox.Show("Esta Seguro de Cerrar Caja?", "Opcion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var caja = new DetalleCajaDto
                {
                    Fecha = DateTime.Now.ToLongDateString(),
                    Total = _Total
                };

                _cajaServicio.CerrarCaja(caja.Total, caja.Fecha);

                MessageBox.Show($"Caja Cerrada, Exitosamente!\nCobrado: ${_Total}", "Cerrar Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void CerrarCaja_Load(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Este Seguro De Eliminar Este Cobro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                var dinero = _detalleCajaServicio.BuscarDetallePorId(_DetalleId);
                detalleProductoServicio.EliminarTodoPorDetalleCajaId(_DetalleId);
                _detalleCajaServicio.EliminarUnaVenta(_DetalleId);

                _cajaServicio.RestarDineroACaja(CajaAbiertaId, dinero);

                VerSiHayVentas();

                CargarGrilla();
                CargarDatos();
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
    }
}
