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
    public partial class Cliente_Abm : FormularioAbm
    {
        private readonly IClienteServicio _Servicio;

        public Cliente_Abm(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _Servicio = new ClienteServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtApellido, "Apellido");
            AgregarControlesObligatorios(txtNombre, "Nombre");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            txtApellido.KeyPress += Validacion.NoSimbolos;
            txtNombre.KeyPress += Validacion.NoSimbolos;

            txtApellido.Focus();
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
            txtApellido.Text = localidad.Apellido;
            txtNombre.Text = localidad.Nombre;
            txtDireccion.Text = localidad.Direccion;
            txtTelefono.Text = localidad.Telefono;
            imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(localidad.Foto);
            ckbPrincipal.Checked = localidad.Principal;
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nuevaLocalidad = new ClienteDto
            {
                Apellido = $"{txtApellido.Text}",
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image),
                Principal = ckbPrincipal.Checked
            };

            _Servicio.Nuevo(nuevaLocalidad);

            ckbPrincipal.Checked = false;

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

            var Modificar = new ClienteDto
            {
                Id = EntidadId.Value,
                Apellido = $"{txtApellido.Text}",
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image),
                Principal = ckbPrincipal.Checked

            };

            _Servicio.Modificar(Modificar);

            return true;
        }

        public override bool EjecutarComandoEliminar()
        {
            if (EntidadId == null) return false;

            _Servicio.Eliminar(EntidadId.Value);

            return true;
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    imgFotoEmpleado.Image = Image.FromFile(openFileDialog.FileName);
                }
                else
                {
                    imgFotoEmpleado.Image = Imagen.Usuario;
                }
            }
            else
            {
                imgFotoEmpleado.Image = Imagen.Usuario;
            }
        }
    }
}
