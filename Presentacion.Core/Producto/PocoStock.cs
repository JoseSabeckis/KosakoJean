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

        public PocoStock()
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();
            colegioServicio = new ColegioServicio();

            CargarGrilla();
        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = productoServicio.BuscarConBajoStock();
            lblCantidad.Text = $"{productoServicio.BuscarConBajoStock().Count()} Productos";
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
    }
}
