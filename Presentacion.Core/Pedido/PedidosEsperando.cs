using Servicios.Core.Pedido;
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

            CrearControles();
        }

        private void CrearControles()
        {
            var cuentas = pedidoServicio.BuscarRetiros();           

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
    }
}
