using Presentacion.Clases;
using Servicios.Core.Talle;
using Servicios.Core.Talle.Dto;
using System.Windows.Forms;

namespace Presentacion.Core.Talle
{
    public partial class Talle_Abm : FormularioAbm
    {
        private readonly ITalleServicio _Servicio;

        public Talle_Abm(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _Servicio = new TalleServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtDescripcion, "Descripción");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            txtDescripcion.Focus();
        }

        public override void CargarDatos(long? entidadId)
        {
            if (!entidadId.HasValue)
            {
                MessageBox.Show(@"Ocurrio un Error Grave", @"Error Grave", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                this.Close();
            }

            if (TipoOperacion == TipoOperacion.Eliminar)
            {
                btnLimpiar.Enabled = false;
            }

            var dato = _Servicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = dato.Descripcion;

            if (entidadId == 1)
            {
                lblInfo.Text = "INFO - Este Talle No Aparecera En El Ticket";
            }
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaLocalidad = new TalleDto
            {
                Descripcion = $"{txtDescripcion.Text}",
            };

            _Servicio.Nuevo(nuevaLocalidad);

            return true;
        }

        public override bool EjecutarComandoModificar()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var localidadParaModificar = new TalleDto
            {
                Id = EntidadId.Value,
                Descripcion = $"{txtDescripcion.Text}",
            };

            _Servicio.Modificar(localidadParaModificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            if (MessageBox.Show("Esta Seguro De Eliminar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }

            _Servicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void BtnNuevaProvincia_Click(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new Talle_Abm(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();

        }

        private void btnNuevaZona_Click(object sender, System.EventArgs e)
        {
            var zon = new Talle_Abm(TipoOperacion.Nuevo);
            zon.ShowDialog();

        }

        private void lblInfo_Click(object sender, System.EventArgs e)
        {

        }
    }
}
