using Servicios.Core.Colegio;
using Servicios.Core.Producto;
using Servicios.Core.TipoProducto;
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
    public partial class ElegirProducto : Form
    {
        private readonly IProductoServicio productoServicio;
        private readonly IColegioServicio colegioServicio;
        private readonly ITipoProducto tipoDeProducto;

        public bool Bandera = false;
        public long _codigo;

        public ElegirProducto()
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();
            colegioServicio = new ColegioServicio();
            tipoDeProducto = new TipoProductoServicio();

            CargarGrilla();
        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = productoServicio.Buscar(string.Empty);
            FormatearGrilla(dgvGrilla);
        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;                

            }

            //grilla.Columns["Id"].Visible = true;
            //grilla.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //grilla.Columns["Id"].HeaderText = @"Nro";
            //grilla.Columns["Id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //grilla.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Precio"].Visible = true;
            grilla.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Precio"].HeaderText = @"Precio";
            grilla.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Colegio"].Visible = true;
            grilla.Columns["Colegio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Colegio"].HeaderText = @"Colegio";
            grilla.Columns["Colegio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Colegio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["TipoProducto"].Visible = true;
            grilla.Columns["TipoProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TipoProducto"].HeaderText = @"Estilo";
            grilla.Columns["TipoProducto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["TipoProducto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _codigo = (long)dgvGrilla["Id", e.RowIndex].Value;

                Bandera = true;
            }
            else
            {
                _codigo = 0;
            }
        }

        public decimal CodigoSeleccionado()
        {
            return _codigo;
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBusqueda.Text))
            {
                dgvGrilla.DataSource = productoServicio.Buscar(txtBusqueda.Text);
                FormatearGrilla(dgvGrilla);
            }
            else
            {
                MessageBox.Show("Campo Vacio...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnBuscar.PerformClick();
        }

        private void ElegirProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
         
        }

        private void ElegirProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Bandera == false)
            {
                _codigo = 0;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ElegirProducto_Load(object sender, EventArgs e)
        {
            btnAgregar.Select();
        }

        private void dgvGrilla_Enter(object sender, EventArgs e)
        {
            btnAgregar.Select();
        }
    }
}
