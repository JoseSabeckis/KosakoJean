using Presentacion.Clases;
using Presentacion.Core.CodBarra;
using Servicios.Core.Colegio;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
using Servicios.Core.Producto_Dato;
using Servicios.Core.Producto_Dato.Dto;
using Servicios.Core.TipoProducto;
using Servicios.Core.TipoProducto.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BarcodeLib;

namespace Presentacion.Core.Producto
{
    public partial class Producto_Abm : FormularioAbm
    {
        private readonly IProductoServicio _Servicio;
        private readonly IColegioServicio _colegioServicio;
        private readonly ITipoProducto _tipoProductoServicio;
        private readonly IProducto_Dato_Servicio producto_Dato_Servicio;

        public Producto_Abm(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _Servicio = new ProductoServicio();
            _colegioServicio = new ColegioServicio();
            _tipoProductoServicio = new TipoProductoServicio();
            producto_Dato_Servicio = new Producto_Dato_Servicio();

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

            if (tipoOperacion == TipoOperacion.Nuevo)
            {
                nudCodigoBarra.Value = _Servicio.TraerNuevoCodBarra();
                btnVerCodBarra.Visible = false;
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
            nudStock.Value = dto.Stock;

            cmbColegio.SelectedValue = dto.ColegioId;
            cmbTipo.SelectedValue = dto.TipoProductoId;

            ckbFabricacion.Checked = dto.Creacion;

            imgFotoEmpleado.Image = ImagenDb.Convertir_Bytes_Imagen(dto.Foto);

            if (dto.Creacion)
            {
                ckbFabricacion.Enabled = false;
            }

            nudCodigoBarra.Value = dto.CodigoBarra;

            ActualizarImgCodeBarras(dto.CodigoBarra);

        }

        public void ActualizarImgCodeBarras(decimal codigo)
        {
            Barcode Codigo = new BarcodeLib.Barcode();
            Codigo.IncludeLabel = true;
            imgCodigoBarras.Image = Codigo.Encode(BarcodeLib.TYPE.EAN13, $"{codigo}");

        }

        public override bool EjecutarComandoNuevo()
        {
            if (!VerificarDatosObligatorios())
            {
                MessageBox.Show(@"Por favor ingrese los campos Obligatorios.", @"Atención", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (!_Servicio.VerificarCodigoDeBarra((long)nudCodigoBarra.Value, 0))
            {
                MessageBox.Show("Este Codigo Barra Ya Lo Tiene Un Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (nudPrecio.Value == 0)
            {
                if (MessageBox.Show("El Producto Valdra 0, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }

            if (ckbFabricacion.Checked)
            {
                if (MessageBox.Show("Selecciono Que Este Producto Se Tendra Que Fabricar\nNo Podra Desacer Esto Del Producto\nDesea Continuar?", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }

            ActualizarImgCodeBarras(nudCodigoBarra.Value);

            var nueva = new ProductoDto
            {
                Descripcion = $"{txtDescripcion.Text}",
                Extras = txtExtras.Text,
                Precio = nudPrecio.Value,
                ColegioId = ((ColegioDto)cmbColegio.SelectedItem).Id,
                TipoProductoId = ((TipoProductoDto)cmbTipo.SelectedItem).Id,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image),
                Stock = nudStock.Value,
                Creacion = ckbFabricacion.Checked,
                CodigoBarra = (long)nudCodigoBarra.Value,
                ImagenCodBarra = ImagenDb.Convertir_Imagen_Bytes(imgCodigoBarras.Image),
            };

            _Servicio.Nuevo(nueva);

            Close();

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

            if (!_Servicio.VerificarCodigoDeBarra((long)nudCodigoBarra.Value, EntidadId.Value))
            {
                MessageBox.Show("Este Codigo Barra Ya Lo Tiene Un Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }

            if (nudPrecio.Value == 0)
            {
                if (MessageBox.Show("El Producto Valdra 0, Desea Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }

            ActualizarImgCodeBarras(nudCodigoBarra.Value);

            var localidadParaModificar = new ProductoDto
            {
                Id = EntidadId.Value,
                Descripcion = $"{txtDescripcion.Text}",
                Extras = txtExtras.Text,
                Precio = nudPrecio.Value,
                ColegioId = ((ColegioDto)cmbColegio.SelectedItem).Id,
                TipoProductoId = ((TipoProductoDto)cmbTipo.SelectedItem).Id,
                Foto = ImagenDb.Convertir_Imagen_Bytes(imgFotoEmpleado.Image),
                Stock = nudStock.Value,
                Creacion = ckbFabricacion.Checked,
                CodigoBarra = (long)nudCodigoBarra.Value,
                ImagenCodBarra = ImagenDb.Convertir_Imagen_Bytes(imgCodigoBarras.Image)
            };

            _Servicio.Modificar(localidadParaModificar);

            Close();

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
                    imgFotoEmpleado.Image = System.Drawing.Image.FromFile(archivo.FileName);
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

        private void txtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void nudCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ActualizarImgCodeBarras(nudCodigoBarra.Value);
            }
        }

        private void btnVerCodBarra_Click(object sender, EventArgs e)
        {
            if (EntidadId != null)
            {
                var producto = _Servicio.ObtenerPorId(EntidadId.Value);

                List<CodBarraDto> Lista = new List<CodBarraDto>();

                var objeto = new CodBarraDto
                {
                    Id = EntidadId.Value,
                    Descripcion = producto.Descripcion,
                    Extra = producto.Extras,
                    Precio = producto.Precio,
                    CodigoBarra = producto.CodigoBarra,
                    Imagen = producto.ImagenCodBarra,
                    Colegio = producto.Colegio
                };

                Lista.Add(objeto);

                var form = new FormularioCodigoBarra(Lista);
                form.Show();

            }
        }
    }
}
