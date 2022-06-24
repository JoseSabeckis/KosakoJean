using Presentacion.Clases;
using Servicios.Core.Colegio;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
using Servicios.Core.TipoProducto;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Producto
{
    public partial class Producto : FormularioConsulta
    {
        private readonly IProductoServicio _Servicio;
        private readonly IColegioServicio colegioServicio;
        private readonly ITipoProducto tipoProducto;

        public Producto()
            : this(new ProductoServicio())
        {
            InitializeComponent();

            colegioServicio = new ColegioServicio();
            tipoProducto = new TipoProductoServicio();
        }

        public Producto(IProductoServicio Servicio)
        {
            _Servicio = Servicio;
        }

        public override void FormatearGrilla(DataGridView grilla)
        {
            base.FormatearGrilla(grilla);

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

        public override void ActualizarDatos(DataGridView grilla, string cadenaBuscar)
        {
            var lista = _Servicio.Buscar(cadenaBuscar);

            foreach (var item in lista)
            {
                var producto = _Servicio.ObtenerPorId(item.Id);

                var colegioDescripcion = colegioServicio.ObtenerPorId(producto.ColegioId).Descripcion;
                var tipoDescripcion = tipoProducto.ObtenerPorId(producto.TipoProductoId).Descripcion;

                item.Colegio = colegioDescripcion;
                item.TipoProducto = tipoDescripcion;
            }

            grilla.DataSource = lista.ToList();
        }

        public override void EjecutarNuevo()
        {
            var fEmpleadoAbm = new Producto_Abm(TipoOperacion.Nuevo);
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
                if (EntidadId == 1)
                {
                    MessageBox.Show("No Se Ver Este Producto General", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (!((ProductoDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarModificar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new Producto_Abm(TipoOperacion.Modificar, EntidadId);
                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El Producto se encuentra Eliminado", @"Atención", MessageBoxButtons.OK,
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
                    MessageBox.Show("No Se Puede Eliminar Este Producto General", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

                if (!((ProductoDto)EntidadSeleccionada).EstaEliminado)
                {
                    base.EjecutarEliminar();

                    if (!PuedeEjecutarComando) return;

                    var fEmpleadoAbm = new Producto_Abm(TipoOperacion.Eliminar, EntidadId);

                    fEmpleadoAbm.ShowDialog();

                    ActualizarSegunOperacion(fEmpleadoAbm.RealizoAlgunaOperacion);
                }
                else
                {
                    MessageBox.Show(@"El Producto se encuentra Eliminado", @"Atención", MessageBoxButtons.OK,
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
