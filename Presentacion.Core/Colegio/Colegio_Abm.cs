using Presentacion.Clases;
using Servicios.Core.Colegio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Colegio
{
    public partial class Colegio_Abm : FormularioAbm
    {
        private readonly IColegioServicio _Servicio;

        public Colegio_Abm(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _Servicio = new ColegioServicio();

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

            var localidad = _Servicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = localidad.Descripcion;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaLocalidad = new ColegioDto
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

            var localidadParaModificar = new ColegioDto
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

            _Servicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void BtnNuevaProvincia_Click(object sender, System.EventArgs e)
        {
            var fNuevaProvincia = new Colegio_Abm(TipoOperacion.Nuevo);
            fNuevaProvincia.ShowDialog();

        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                if ((char.IsWhiteSpace(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
        }



        private void btnNuevaZona_Click(object sender, System.EventArgs e)
        {
            var zon = new Colegio_Abm(TipoOperacion.Nuevo);
            zon.ShowDialog();

        }

    }
}
