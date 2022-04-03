using Presentacion.Clases;
using Servicios.Core.Image.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto_Pedido;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Pedido
{
    public partial class PedidosEsperando : Form
    {
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;

        public PedidosEsperando()
        {
            InitializeComponent();

            pedidoServicio = new PedidoServicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();

            var cuentas = pedidoServicio.BuscarRetiros();

            CrearControles(cuentas);

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgEsperando.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedidos_Listos);
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

                flowPanel.Controls.Add(control);

            }

            panelGrilla.Controls.Add(flowPanel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBusqueda.Text))
            {
                panelGrilla.Controls.Clear();

                var cuenta = pedidoServicio.Buscar(txtBusqueda.Text);

                CrearControles(cuenta);
            }
            else
            {
                MessageBox.Show("El Campo de descripcion esta vacio", "Vacio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
