using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
using Servicios.Core.Producto_Venta.Dto;
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
    public partial class PedidoInfo : Form
    {
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProductoServicio productoServicio;

        AccesoDatos.EstadoPedido Estado;

        List<VentaDto2> list;

        public PedidoInfo(long pedidoId, AccesoDatos.EstadoPedido estado)
        {
            InitializeComponent();

            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            pedidoServicio = new PedidoServicio();
            productoServicio = new ProductoServicio();

            list = new List<VentaDto2>();

            Estado = estado;

            Datos(pedidoId);

            Esquema(pedidoId);

            
        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = list.ToList();
            FormatearGrilla(dgvGrilla);
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

        private void Esquema(long pedidoId)
        {
            if (Estado == AccesoDatos.EstadoPedido.Esperando)
            {
                var esquema = producto_Pedido_Servicio.BuscarPedidoId(pedidoId);

                foreach (var item in esquema)
                {
                    var producto = productoServicio.ObtenerPorId(item.ProductoId);

                    var lista = new VentaDto2
                    {
                        Cantidad = item.Cantidad,
                        Talle = item.Talle,
                        Descripcion = producto.Descripcion,
                        Precio = producto.Precio * item.Cantidad
                    };

                    list.Add(lista);

                }

                CargarGrilla();

            }
            else
            {
                var esquema = producto_Pedido_Servicio.BuscarPedidoTerminado(pedidoId);
            }
        }

        public void Datos(long pedidoId)
        {
            var pedido = pedidoServicio.Buscar(pedidoId);

            lblPersona.Text = $"{pedido.Apellido} {pedido.Nombre}";
            lblFechaInicio.Text = $"{pedido.FechaPedido.ToString("dd/MM/yyyy")}";
            lblFecha.Text = $"{pedido.FechaEntrega.ToString("dd/MM/yyyy")}";

            txtDineroAdelanto.Text = $"{pedido.Adelanto}";
            txtTotal.Text = $"{pedido.Total}";

            txtDebe.Text = $"{pedido.Total - pedido.Adelanto}";
        }

    }
}
