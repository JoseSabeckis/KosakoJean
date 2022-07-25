using Servicios.Core.DetalleCaja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class DetalleNroOperacion : FormularioBase
    {
        private readonly IDetalleCajaServicio _detalleCajaServicio;

        public DetalleNroOperacion()
        {
            InitializeComponent();

            _detalleCajaServicio = new DetalleCajaServicio();

            CargarGrilla();
        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = _detalleCajaServicio.BuscarDetallesNumerosOperacion(txtBusqueda.Text);

            FormatearGrilla(dgvGrilla);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CargarGrilla();
            }
        }

        private void DetalleNroOperacion_Load(object sender, EventArgs e)
        {
            txtBusqueda.Focus();
        }
    }
}
