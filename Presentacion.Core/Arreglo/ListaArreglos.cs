using Servicios.Core.Arreglo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Arreglo
{
    public partial class ListaArreglos : FormularioBase
    {
        private readonly IArregloServicio arregloServicio;
        long _ArregloId;

        public ListaArreglos()
        {
            InitializeComponent();

            arregloServicio = new ArregloServicio();

            CargarGrilla();            
        }

        private void CargarGrilla()
        {
            if (ckbEnEspera.Checked)
            {
                dgvGrilla.DataSource = arregloServicio.ListaArreglosEnEspera();
            }
            if (ckbRetirados.Checked)
            {
                dgvGrilla.DataSource = arregloServicio.ListaArreglosRetirados();
            }

            FormatearGrilla(dgvGrilla);
        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["ApyNom"].Visible = true;
            grilla.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["ApyNom"].HeaderText = @"Cliente";
            grilla.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["FechaEntrega"].Visible = true;
            grilla.Columns["FechaEntrega"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["FechaEntrega"].HeaderText = @"Entrega";
            grilla.Columns["FechaEntrega"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["FechaEntrega"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Horario"].Visible = true;
            grilla.Columns["Horario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Horario"].HeaderText = @"Horario";
            grilla.Columns["Horario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Horario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Total"].Visible = true;
            grilla.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Total"].HeaderText = @"Total";
            grilla.Columns["Total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void ckbEnEspera_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEnEspera.Checked)
            {
                ckbRetirados.Checked = false;
            }

            CargarGrilla();
        }

        private void ckbRetirados_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbRetirados.Checked)
            {
                ckbEnEspera.Checked = false;
            }

            CargarGrilla();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevo = new InsertarArreglo();
            nuevo.ShowDialog();

            CargarGrilla();
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _ArregloId = (long)dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                _ArregloId = 0;
            }
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (_ArregloId != 0)
            {
                var arreglo = new DatosArreglo(_ArregloId);
                arreglo.ShowDialog();

                CargarGrilla();
            }
        }
    }
}
