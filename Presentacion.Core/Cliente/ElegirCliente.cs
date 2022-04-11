using Presentacion.Clases;
using Servicios.Core.Cliente;
using Servicios.Core.Image.Dto;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class ElegirCliente : Form
    {
        private readonly IClienteServicio Servicio;

        public bool Bandera = false;
        public long _codigo;

        public ElegirCliente()
        {
            InitializeComponent();

            Servicio = new ClienteServicio();

            CargarGrilla();

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgCliente.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Clientes);
        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = Servicio.Buscar(string.Empty);
            FormatearGrilla(dgvGrilla);
        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["Id"].Visible = true;
            grilla.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Id"].HeaderText = @"Nro";
            grilla.Columns["Id"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Apellido"].Visible = true;
            grilla.Columns["Apellido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Apellido"].HeaderText = @"Apellido";
            grilla.Columns["Apellido"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Apellido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Nombre"].Visible = true;
            grilla.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Nombre"].HeaderText = @"Nombre";
            grilla.Columns["Nombre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Telefono"].Visible = true;
            grilla.Columns["Telefono"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Telefono"].HeaderText = @"Telefono";
            grilla.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Telefono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Direccion"].Visible = true;
            grilla.Columns["Direccion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Direccion"].HeaderText = @"Direccion";
            grilla.Columns["Direccion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Direccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
                dgvGrilla.DataSource = Servicio.Buscar(txtBusqueda.Text);
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


        private void ElegirCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Bandera == false)
            {
                _codigo = 0;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
