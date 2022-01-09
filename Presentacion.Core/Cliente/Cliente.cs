using Presentacion.Clases;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class Cliente : FormularioConsulta
    {
        private readonly IClienteServicio _Servicio;

        public Cliente()
            : this(new ClienteServicio())
        {
            InitializeComponent();
        }

        public Cliente(IClienteServicio colegioServicio)
        {
            _Servicio = colegioServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

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

            grilla.Columns["Dni"].Visible = true;
            grilla.Columns["Dni"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Dni"].HeaderText = @"Dni";
            grilla.Columns["Dni"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Dni"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _Servicio.Buscar(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new Cliente_Abm(TipoOperacion.Nuevo);
            fEmpleadoAbm.ShowDialog();

            ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
        }

        public override void EjecutarModificar()
        {
            if (dgvGrilla.RowCount == 0)
            {

            }
            else
            {
                if (!((ClienteDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarModificar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new Cliente_Abm(TipoOperacion.Modificar, EntidadId);
                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El empleado se encuetra Elimnado", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        public override void EjecutarEliminar()
        {
            if (dgvGrilla.RowCount == 0)
            {

            }
            else
            {

                if (!((ClienteDto)EntidadSeleccionada).EstaEliminado)
                {
                    if (((ClienteDto)EntidadSeleccionada).Id == 1)
                    {
                        MessageBox.Show("No Puede Eliminar el Consumidor Final", "Nop", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    base.EjecutarEliminar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new Cliente_Abm(TipoOperacion.Eliminar, EntidadId);

                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El empleado se encuetra Eliminado", @"Atención", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void ActualizarSegunOperacion(bool realizoAlgunaOperacion)
        {
            if (realizoAlgunaOperacion)
            {
                ActualizarDatos(dgvGrilla, string.Empty);
            }
        }
    }
}
