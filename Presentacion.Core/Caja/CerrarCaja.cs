using Servicios.Core.Caja;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
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

        }

        public void CargarDatos()
        {
            var total = _cajaServicio.SumarCaja();
            var suma = _cajaServicio.BuscarCajaAbierta();

            txtCobrado.Text = $"$ {total}";
            txtTotal.Text = $"$ {suma.TotalCaja}";

            _Total = total + suma.TotalCaja;
        }

        private void btmVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Cerrar Caja?","Opcion",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var caja = new DetalleCajaDto
                {
                    Fecha = DateTime.Now,
                    Total = _Total
                };

                _cajaServicio.CerrarCaja(caja.Total, caja.Fecha);

                MessageBox.Show("Caja Cerrada, Exitosamente!", "Caja Cerrar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
