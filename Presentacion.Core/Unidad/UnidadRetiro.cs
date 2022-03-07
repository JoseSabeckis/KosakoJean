using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido;
using Presentacion.Core.Pedido;

namespace Presentacion.Core.Unidad
{
    public partial class UnidadRetiro : UserControl
    {
        private readonly IProducto_Pedido_Servicio pedido_Producto_Servicio;
        private readonly IProductoServicio producto;
        private readonly IPedidoServicio pedidoServicio;

        PedidoDto Pedido;

        AccesoDatos.EstadoPedido estado;

        public UnidadRetiro(PedidoDto pedidoDto)
        {
            InitializeComponent();

            pedido_Producto_Servicio = new Producto_Pedido_Servicio();
            producto = new ProductoServicio();
            pedidoServicio = new PedidoServicio();

            Pedido = pedidoDto;

            VerDatos();
        }

        private void VerDatos()
        {
            lblFecha.Text = $"{Pedido.FechaEntrega.ToString("dddd dd/MM/yyyy")}";

            lblNombre.Text = $"{Pedido.Apellido} {Pedido.Nombre}";

            lblId.Text = $"{Pedido.Id}";

            var respuesta = pedido_Producto_Servicio.BuscarPedidoTerminado(Pedido.Id);

            foreach (var item in respuesta)
            {   
                txtProductos.Text += $"{respuesta.FirstOrDefault(x => x.Id == item.Id).Descripcion} |";
                lblIdPedido.Text = $"{item.PedidoId}";
                estado = item.Estado;
            }

        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            var pedido = new PedidoInfo(Pedido.Id, estado);
            pedido.ShowDialog();
        }
    }
}
