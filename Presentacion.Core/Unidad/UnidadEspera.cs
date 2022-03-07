using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Unidad
{
    public partial class UnidadEspera : UserControl
    {
        private readonly IProducto_Pedido_Servicio pedido_Producto_Servicio;
        private readonly IProductoServicio producto;
        private readonly IPedidoServicio pedidoServicio;

        PedidoDto Pedido;

        AccesoDatos.EstadoPedido _estado;

        public UnidadEspera(PedidoDto pedidoDto, AccesoDatos.EstadoPedido estado)
        {
            InitializeComponent();

            pedido_Producto_Servicio = new Producto_Pedido_Servicio();
            producto = new ProductoServicio();
            pedidoServicio = new PedidoServicio();

            Pedido = pedidoDto;
            _estado = estado;

            VerDatos();
        }

        private void VerDatos()
        {
            lblFecha.Text = $"{Pedido.FechaEntrega.ToString("dddd dd/MM/yyyy")}";

            lblNombre.Text = $"{Pedido.Apellido} {Pedido.Nombre}";

            lblId.Text = $"{Pedido.Id}";

            List<Producto_Pedido_Dto> Lista = new List<Producto_Pedido_Dto>();

            if (_estado == AccesoDatos.EstadoPedido.Guardado)
            {
                Lista = pedido_Producto_Servicio.BuscarPedidoGuardado(Pedido.Id);
            }
            else
            {
                Lista = pedido_Producto_Servicio.BuscarPedidoRetirado(Pedido.Id);
            }

            foreach (var item in Lista)
            {
                lblProducto.Text = $"{Lista.FirstOrDefault(x => x.Id == item.Id).Descripcion} | ";
                lblIdPedido.Text = $"{item.PedidoId}";
            }

        }

    }
}
