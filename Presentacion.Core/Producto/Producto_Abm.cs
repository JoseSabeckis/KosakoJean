using Presentacion.Clases;
using Servicios.Core.Colegio;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
using Servicios.Core.TipoProducto;
using Servicios.Core.TipoProducto.Dto;
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
    public partial class Producto_Abm : FormularioAbm
    {
        private readonly IProductoServicio _Servicio;
        private readonly IColegioServicio _colegioServicio;
        private readonly ITipoProducto _tipoProductoServicio;

        public Producto_Abm(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _Servicio = new ProductoServicio();
            _colegioServicio = new ColegioServicio();
            _tipoProductoServicio = new TipoProductoServicio();


            CargarComboBox(cmbColegio, _colegioServicio.Buscar(string.Empty), "Descripcion", "Id");
            CargarComboBox(cmbTipo, _tipoProductoServicio.Buscar(string.Empty), "Descripcion", "Id");

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
            AgregarControlesObligatorios(nudPrecio, "Precio");
            AgregarControlesObligatorios(cmbColegio, "Colegio");
            AgregarControlesObligatorios(cmbTipo, "Tipo Producto");

            Inicializador(entidadId);
        }

        public override void Inicializador(long? entidadId)
        {
            if (entidadId.HasValue) return;

            txtDescripcion.KeyPress += Validacion.NoSimbolos;

            imgFotoEmpleado.Image = Imagen.Usuario;

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

            var dto = _Servicio.ObtenerPorId(entidadId.Value);

            // Datos Personales
            txtDescripcion.Text = dto.Descripcion;
            txtExtras.Text = dto.Extras;

            nudPrecio.Value = dto.Precio;

            cmbColegio.SelectedValue = dto.ColegioId;
            cmbTipo.SelectedValue = dto.TipoProductoId;

            imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(dto.Foto);
        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            var nueva= new ProductoDto
            {
                Descripcion = $"{txtDescripcion.Text}",
                Extras = txtExtras.Text,
                Precio = nudPrecio.Value,
                ColegioId = ((ColegioDto)cmbColegio.SelectedItem).Id,
                TipoProductoId = ((TipoProductoDto)cmbTipo.SelectedItem).Id,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image)
            };

            _Servicio.Nuevo(nueva);

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

            var localidadParaModificar = new ProductoDto
            {
                Id = EntidadId.Value,
                Descripcion = $"{txtDescripcion.Text}",
                Extras = txtExtras.Text,
                Precio = nudPrecio.Value,
                ColegioId = ((ColegioDto)cmbColegio.SelectedItem).Id,
                TipoProductoId = ((TipoProductoDto)cmbTipo.SelectedItem).Id,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image)
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
            var fNuevaProvincia = new Producto_Abm(TipoOperacion.Nuevo);
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
            var zon = new Producto_Abm(TipoOperacion.Nuevo);
            zon.ShowDialog();

        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (archivo.ShowDialog() == DialogResult.OK)
            {

                // Pregunta si Selecciono un Archivo
                if (!string.IsNullOrEmpty(archivo.FileName))
                {
                    imgFotoEmpleado.Image = Image.FromFile(archivo.FileName);
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
