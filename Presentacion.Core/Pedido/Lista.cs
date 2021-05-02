using Servicios.Core.Pedido;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Presentacion.Core.Pedido
{
    public partial class Lista : Form
    {
        private readonly IPedidoServicio pedidoServicio;

        public Lista()
        {
            InitializeComponent();

            pedidoServicio = new PedidoServicio();

            CrearControles();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CrearControles()
        {
            var cuentas = pedidoServicio.BuscarPedidosNuevos();

            var flowPanel = new FlowLayoutPanel
            {
                Name = $"flowPanel Cuenta",
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            foreach (var item in cuentas)
            {
                var cuenta = item;

                var control = new Unidad.Unidad(cuenta);

                flowPanel.Controls.Add(control);

            }

            panelGrilla.Controls.Add(flowPanel);

        }

    }
}
