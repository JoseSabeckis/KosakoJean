using Presentacion.Core.Producto;
using Servicios.Core.ParteVenta;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
using Servicios.Core.Producto_Venta;
using Servicios.Core.Producto_Venta.Dto;
using Servicios.Core.Venta;
using Servicios.Core.Venta.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Cobro
{
    public partial class Venta : Form
    {
        private readonly IProductoServicio productoServicio;
        private readonly IProducto_Venta_Servicio producto_vent;
        private readonly IVentaServicio ventaServicio;

        ProductoDto producto;
        long _productoId;

        string _descripcionProducto;

        List<VentaDto2> ListaVenta;

        public Venta()
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();
            producto_vent = new Producto_Venta_Servicio();
            ventaServicio = new VentaServicio();
            producto = new ProductoDto();

            cmbTalle.SelectedIndex = 0;

            ListaVenta = new List<VentaDto2>();

            CargarGrilla(ListaVenta);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccionProducto_Click(object sender, EventArgs e)
        {
            var seleccionar = new ElegirProducto();
            seleccionar.ShowDialog();

            if (seleccionar._codigo != 0)
            {
                var product = productoServicio.ObtenerPorId(seleccionar._codigo);

                producto = product;

                _productoId = product.Id;
                txtProducto.Text = producto.Descripcion;


                if (nudCantidad.Value != 1)
                {
                    nudPrecio.Value = product.Precio * nudCantidad.Value;
                }
                else
                {
                    nudPrecio.Value = product.Precio;
                }              
                

            }

        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProducto.Text))
            {
                nudPrecio.Value = producto.Precio * nudCantidad.Value;
            }
            else
            {
                producto = null;
            }
        }

        public void CargarGrilla(List<VentaDto2> producto)
        {
            dgvGrilla.DataSource = ListaVenta.ToList();
            FormatearGrilla(dgvGrilla);
        }

        private void btnAgregarAlaGrilla_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProducto.Text))
            {
                var prueba = ListaVenta.FirstOrDefault(x => x.Descripcion == txtProducto.Text && x.Talle == cmbTalle.Text);


                if (prueba != null)
                {
                    prueba.Cantidad += nudCantidad.Value;
                    prueba.Precio += prueba.Precio;

                    CargarGrilla(ListaVenta);

                    Total();
                }
                else
                {

                    var nuevo = new VentaDto2
                    {

                        Cantidad = nudCantidad.Value,
                        Descripcion = txtProducto.Text,
                        Precio = nudPrecio.Value,
                        Talle = cmbTalle.Text,
                        Id = _productoId

                    };

                    ListaVenta.Add(nuevo);

                    CargarGrilla(ListaVenta);

                    Total();
                }

                Limpiar();
            }
            else
            {
                MessageBox.Show("Cargue un Producto Antes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Total()
        {
            var precio = ListaVenta.Sum(x => x.Precio);
            var cantidad = ListaVenta.Sum(x => x.Cantidad);

            txtTotal.Text = $"$ {precio * cantidad}";
        }

        public void Limpiar()
        {
            txtProducto.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            _productoId = 0;

            txtVuelto.Text = string.Empty;
            nudPagaron.Value = 0;
        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["Descripcion"].Visible = true;
            grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Descripcion"].HeaderText = @"Descripcion";
            grilla.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Talle"].Visible = true;
            grilla.Columns["Talle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Talle"].HeaderText = @"Talle";
            grilla.Columns["Talle"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Talle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Precio"].Visible = true;
            grilla.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Precio"].HeaderText = @"Precio";
            grilla.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Cantidad"].Visible = true;
            grilla.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtProducto.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            txtTotal.Text = string.Empty;
            txtVuelto.Text = string.Empty;
            nudPagaron.Value = 0;

            _productoId = 0;

            ListaVenta = new List<VentaDto2>();

            CargarGrilla(ListaVenta);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (nudPagaron.Value > 0)
            {
                if (txtTotal.Text != string.Empty)
                {
                    var precio = ListaVenta.Sum(x => x.Precio);
                    var cantidad = ListaVenta.Sum(x => x.Cantidad);

                    var pago = nudPagaron.Value - (precio * cantidad);

                    txtVuelto.Text = $" $ {pago}";
                }
            }
            else
            {
                MessageBox.Show("Cargue el Dinero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                if (MessageBox.Show("Esta Seguro de Continuar?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var precio = ListaVenta.Sum(x => x.Precio);
                    var cantidad = ListaVenta.Sum(x => x.Cantidad);

                    var pago = nudPagaron.Value - (precio * cantidad);

                    var venta = new VentaDto
                    {
                        Fecha = DateTime.Now,
                        Total = pago
                    };

                    var ventaId = ventaServicio.NuevaVenta(venta);

                    foreach (var item in ListaVenta)
                    {
                        var producto = productoServicio.ObtenerPorId(item.Id);

                        var producto_venta = new Producto_Venta_Dto
                        {
                            Cantidad = item.Cantidad,
                            Descripcion = item.Descripcion,
                            Estado = AccesoDatos.EstadoPedido.Terminado,
                            ProductoId = item.Id,
                            Talle = item.Talle,
                            Precio = item.Precio,
                            VentaId = ventaId
                        };

                        producto_vent.NuevoProductoVenta(producto_venta);
                    }

                    btnLimpiar.PerformClick();

                    MessageBox.Show("Felicidades, Cobro Aceptado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Cargue la Grilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                var lista = ListaVenta.FirstOrDefault(x => x.Descripcion == _descripcionProducto);

                ListaVenta.Remove(lista);

                CargarGrilla(ListaVenta);

                Total();
            }
            else
            {
                MessageBox.Show("No Hay Nada Para Eliminar...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _descripcionProducto = (string)dgvGrilla["Descripcion", e.RowIndex].Value;

            }
        }
    }
}
