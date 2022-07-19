using Servicios.Core.Caja;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class CerrarCaja : Form
    {
        private readonly ICajaServicio _cajaServicio;
        private readonly IDetalleCajaServicio _detalleCajaServicio;

        decimal _Total;

        public CerrarCaja()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
            _detalleCajaServicio = new DetalleCajaServicio();

            CargarDatos();

            var cajaAbierta = _detalleCajaServicio.BuscarCajaAbierta();

            dgvGrilla.DataSource = _detalleCajaServicio.BuscarDetalles(cajaAbierta);
            FormatearGrilla(dgvGrilla);

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
            if (MessageBox.Show("Esta Seguro de Cerrar Caja?", "Opcion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var caja = new DetalleCajaDto
                {
                    Fecha = DateTime.Now.ToLongDateString(),
                    Total = _Total
                };

                _cajaServicio.CerrarCaja(caja.Total, caja.Fecha);

                MessageBox.Show("Caja Cerrada, Exitosamente!", "Caja Cerrar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }

        private void CerrarCaja_Load(object sender, EventArgs e)
        {

        }
    }
}
