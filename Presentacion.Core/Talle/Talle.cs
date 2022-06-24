using Presentacion.Clases;
using Servicios.Core.Talle;
using Servicios.Core.Talle.Dto;
using System.Windows.Forms;

namespace Presentacion.Core.Talle
{
    public partial class Talle : FormularioConsulta
    {
        private readonly ITalleServicio _Servicio;

        public Talle()
            : this(new TalleServicio())
        {
            InitializeComponent();
        }

        public Talle(ITalleServicio colegioServicio)
        {
            _Servicio = colegioServicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grilla.Columns["EstaEliminado"].Visible = true;
            grilla.Columns["EstaEliminado"].Width = 200;
            grilla.Columns["EstaEliminado"].HeaderText = @"Eliminado";
            grilla.Columns["EstaEliminado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["EstaEliminado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            grilla.DataSource = _Servicio.Buscar(cadenaBuscar);
        }

        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new Talle_Abm(TipoOperacion.Nuevo);
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
                if (!((TalleDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarModificar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new Talle_Abm(TipoOperacion.Modificar, EntidadId);
                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El Talle se encuentra Eliminado", @"Atención", MessageBoxButtons.OK,
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
                if (EntidadId == 1)
                {
                    MessageBox.Show("No Se Puede Borrar El Talle Principal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (!((TalleDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarEliminar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new Talle_Abm(TipoOperacion.Eliminar, EntidadId);

                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El Talle se encuentra Eliminado", @"Atención", MessageBoxButtons.OK,
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
