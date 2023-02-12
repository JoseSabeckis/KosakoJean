using Presentacion.Core.Pedido;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Unidad
{
    public partial class UnidadEspera : UserControl
    {
        private readonly IProducto_Pedido_Servicio pedido_Producto_Servicio;
        private readonly IProductoServicio producto;
        private readonly IPedidoServicio pedidoServicio;

        PedidoDto Pedido;

        AccesoDatos.Proceso _estado;

        public UnidadEspera(PedidoDto pedidoDto, AccesoDatos.Proceso estado)
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

            var dia = DateTime.Now.Date - Pedido.FechaIniciado.Date;

            if (Pedido.DiasHastaRetiro == null)
            {
                lblFechaHastaRetiro.Text = $"Dias Esperando al Cliente: {dia.Days}";
            }
            else
            {
                lblFechaHastaRetiro.Text = Pedido.DiasHastaRetiro;
            }

            lblId.Text = $"{Pedido.Id}";

            List<Producto_Pedido_Dto> Lista = new List<Producto_Pedido_Dto>();

            if (_estado == AccesoDatos.Proceso.Guardado)
            {
                Lista = pedido_Producto_Servicio.BuscarPedidoGuardado(Pedido.Id);
            }
            else
            {
                Lista = pedido_Producto_Servicio.BuscarPedidoRetirado(Pedido.Id);
            }

            foreach (var item in Lista)
            {
                var product = producto.ObtenerPorId(item.ProductoId);

                txtProductos.Text += $"{product.Descripcion} {product.Colegio} | ";
                lblIdPedido.Text = $"{item.PedidoId}";
            }

        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            var guardado = new PedidoGuardado(Pedido.Id, Pedido.Proceso);
            guardado.ShowDialog();
        }
    }
}
