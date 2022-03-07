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

namespace Presentacion.Core.CtaCte
{
    public partial class GuardadoConsumidorFinal : FormularioBase
    {
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;

        public GuardadoConsumidorFinal(AccesoDatos.Proceso pedido)
        {
            InitializeComponent();

            pedidoServicio = new PedidoServicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();

            if (pedido == AccesoDatos.Proceso.Retirado)
            {
                lblTitulo.Text = "Prendas Retiradas";

                var cuentas = pedidoServicio.BuscarRetirado();

                CrearControles(cuentas, AccesoDatos.EstadoPedido.Retirado);
            }
            else
            {
                var cuentas = pedidoServicio.BuscarGuardados();

                CrearControles(cuentas, AccesoDatos.EstadoPedido.Guardado);
            }

            
        }

        private void CrearControles(IEnumerable<PedidoDto> cuentas, AccesoDatos.EstadoPedido pedido)
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

                var control = new Unidad.UnidadEspera(cuenta, pedido);

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
