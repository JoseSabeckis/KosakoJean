using Presentacion.Clases;
using Servicios.Core.Negocio;
using Servicios.Core.Negocio.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Negocio
{
    public partial class Negocio_Abm : FormularioAbm
    {
        private readonly INegocioServicio negocioServicio;

        public Negocio_Abm(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            negocioServicio = new NegocioServicio();

            if (tipoOperacion == TipoOperacion.Eliminar || tipoOperacion == TipoOperacion.Modificar)
            {
                CargarDatos(entidadId);
            }

            if (tipoOperacion == TipoOperacion.Eliminar)
            {
                DesactivarControles(this);
            }

            AsignarEventoEnterLeave(this);

            AgregarControlesObligatorios(txtRazonSocial, "txtRazonSocial");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            txtRazonSocial.KeyPress += Validacion.NoSimbolos;

            txtCelular.KeyPress += Validacion.NoSimbolos;
            txtCelular.KeyPress += Validacion.NoLetras;

            txtCuit.KeyPress += Validacion.NoSimbolos;
            txtCuit.KeyPress += Validacion.NoLetras;

            //Validacion.ValidarEmail(txtEmail.Text, error, txtEmail);

            txtRazonSocial.Focus();
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

            var negocio = negocioServicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtRazonSocial.Text = negocio.RazonSocial;
            txtCuit.Text = negocio.Cuit;
            txtCelular.Text = negocio.Celular;
            txtEmail.Text = negocio.Email;
            txtDireccion.Text = negocio.Direccion;

            imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(negocio.Imagen);
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nueva = new NegocioDto
            {
                RazonSocial = txtRazonSocial.Text,
                Cuit = txtCuit.Text,
                Celular = txtCelular.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
                Imagen = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image),
            };

            negocioServicio.Insertar(nueva);

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

            var Modificar = new NegocioDto
            {
                Id = EntidadId.Value,
                RazonSocial = txtRazonSocial.Text,
                Cuit = txtCuit.Text,
                Celular = txtCelular.Text,
                Direccion = txtDireccion.Text,
                Email = txtEmail.Text,
                Imagen = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image),

            };

            negocioServicio.Modificar(Modificar);

            NegocioLogeado.Id = Modificar.Id;
            NegocioLogeado.RazonSocial = Modificar.RazonSocial;
            NegocioLogeado.Email = Modificar.Email;
            NegocioLogeado.Cuit = Modificar.Cuit;
            NegocioLogeado.Direccion = Modificar.Direccion;
            NegocioLogeado.Celular = Modificar.Celular;
            NegocioLogeado.Imagen = Modificar.Imagen;

            return true;
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    imgFotoEmpleado.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
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
