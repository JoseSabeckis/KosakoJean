using Servicios.Core.Colegio;
using Servicios.Core.Producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Producto
{
    public partial class PocoStock : Form
    {
        private readonly IProductoServicio productoServicio;
        private readonly IColegioServicio colegioServicio;

        long _codigo;

        public PocoStock()
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();
            colegioServicio = new ColegioServicio();

            CargarGrilla();
        }

        public void CargarGrilla()
        {
            if (ckbMayor.Checked)
            {
                dgvGrilla.DataSource = productoServicio.BuscarConMayorStock(nudStock.Value);
                lblCantidad.Text = $"{productoServicio.BuscarConMayorStock(nudStock.Value).Count()} Productos";
            }
            else
            {
                dgvGrilla.DataSource = productoServicio.BuscarConBajoStock(nudStock.Value);
                lblCantidad.Text = $"{productoServicio.BuscarConBajoStock(nudStock.Value).Count()} Productos";
            }

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

            grilla.Columns["Colegio"].Visible = true;
            grilla.Columns["Colegio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Colegio"].HeaderText = @"Colegio";
            grilla.Columns["Colegio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Colegio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Stock"].Visible = true;
            grilla.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Stock"].HeaderText = @"Stock";
            grilla.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _codigo = (long)dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                _codigo = 0;
            }
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            var verificar = new SumarStock(_codigo);
            verificar.ShowDialog();

            CargarGrilla();
        }

        private void ckbMenor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMenor.Checked)
            {
                ckbMayor.Checked = false;
            }

            CargarGrilla();
        }

        private void ckbMayor_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbMayor.Checked)
            {
                ckbMenor.Checked = false;
            }

            CargarGrilla();
        }

        private void nudStock_ValueChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
