using Presentacion.Clases;
using Servicios.Core.Image.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Dato;
using Servicios.Core.Producto_Dato.Dto;
using Servicios.Core.Producto_Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Pedido
{
    public partial class PedidosTerminados : Form
    {
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IProductoServicio productoServicio;
        private readonly IProducto_Dato_Servicio producto_Dato_Servicio;

        public PedidosTerminados()
        {
            InitializeComponent();

            pedidoServicio = new PedidoServicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            productoServicio = new ProductoServicio();
            producto_Dato_Servicio = new Producto_Dato_Servicio();

            var cuentas = pedidoServicio.BuscandoTerminados(string.Empty);

            CrearControles(cuentas);

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgTerminado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedidos_Terminados);
        }

        private void CrearControles(IEnumerable<PedidoDto> cuentas)
        {

            var flowPanel = new FlowLayoutPanel
            {
                Name = $"flowPanel Cuenta",
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch,
                AutoScroll = true
            };

            foreach (var item in cuentas)
            {
                var cuenta = item;

                var control = new Unidad.UnidadRetiro(cuenta);

                control.BackColor = System.Drawing.Color.Orange;

                flowPanel.Controls.Add(control);

            }

            panelGrilla.Controls.Add(flowPanel);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            panelGrilla.Controls.Clear();

            var cuenta = pedidoServicio.BuscandoTerminados(txtBusqueda.Text);

            CrearControles(cuenta);

        }

        private void btnEliminarPedidos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro De Eliminar Los Pedidos? No Se Podran Recuperar", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var listaPedidosTerminado = pedidoServicio.BuscandoTerminadosUltima();

                foreach (var item in listaPedidosTerminado)
                {
                    var producto_pedido_Lista = producto_Pedido_Servicio.BuscarPedidoId(item.Id);

                    foreach (var pedido in producto_pedido_Lista)
                    {
                        if (productoServicio.ObtenerPorId(pedido.ProductoId).Creacion)
                        {
                            producto_Dato_Servicio.EliminacionDefinitivaPorPedido(pedido.Id);
                        }

                        producto_Pedido_Servicio.EliminacionDefinitiva(pedido.Id);
                    }

                    pedidoServicio.EliminacionDefinitiva(item.Id);

                }

                MessageBox.Show("Datos Eliminados Exitosamente!!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                panelGrilla.Controls.Clear();

                var cuentas = pedidoServicio.BuscandoTerminados(string.Empty);

                CrearControles(cuentas);

                btnEliminarPedidos.Visible = false;

            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void PedidosTerminados_Load(object sender, EventArgs e)
        {
            if (pedidoServicio.BuscandoTerminadosUltima().Count() == 0)
            {
                btnEliminarPedidos.Visible = false;
            }
        }
    }
}
