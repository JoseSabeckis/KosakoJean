using Servicios.Core.Caja;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
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

        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detalleCajaServicio;

        AccesoDatos.EstadoPedido Estado;

        long PedidoId;

        decimal _Debe;

        List<VentaDto2> list;

        public PedidoInfo(long pedidoId, AccesoDatos.EstadoPedido estado)
        {
            InitializeComponent();

            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            pedidoServicio = new PedidoServicio();
            productoServicio = new ProductoServicio();
            cajaServicio = new CajaServicio();
            detalleCajaServicio = new DetalleCajaServicio();

            list = new List<VentaDto2>();

            Estado = estado;

            PedidoId = pedidoId;

            Datos(pedidoId);

            Esquema(pedidoId);

            lblVendido.Visible = false;

            if (pedidoServicio.Buscar(pedidoId).Proceso == AccesoDatos.Proceso.InicioPedido)
            {
                btnTerminar.Visible = false;
            }
            else
            {
                if (pedidoServicio.Buscar(pedidoId).Proceso == AccesoDatos.Proceso.EsperandoRetiro)
                {
                    btnTerminar.Visible = true;
                }
                else
                {
                    btnTerminar.Visible = false;
                    lblVendido.Visible = true;
                }
            }

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
                        Precio = producto.Precio
                    };

                    list.Add(lista);

                    CargarGrilla();

                }                

            }
            else
            {
                var esquema = producto_Pedido_Servicio.BuscarPedidoTerminado(pedidoId);

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

                    CargarGrilla();

                }
                
            }
        }

        public void Datos(long pedidoId)
        {
            var pedido = pedidoServicio.Buscar(pedidoId);

            txtTotal.Text = string.Empty;
            txtDebe.Text = string.Empty;
            txtDineroAdelanto.Text = string.Empty;

            lblPersona.Text = $"{pedido.Apellido}";
            lblFechaInicio.Text = $"{pedido.FechaPedido.ToString("dd/MM/yyyy")}";
            lblFecha.Text = $"{pedido.FechaEntrega.ToString("dd/MM/yyyy")}";

            txtDineroAdelanto.Text = $"{pedido.Adelanto}";
            txtTotal.Text = $"{pedido.Total}";

            txtDebe.Text = $"{pedido.Total - pedido.Adelanto}";
            _Debe = pedido.Total - pedido.Adelanto;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {

            if (cajaServicio.BuscarCajaAbierta() != null)
            {
                if (MessageBox.Show("Esta por Terminar el Pedido, Esta Seguro?", "Preguntar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var pedido = pedidoServicio.Buscar(PedidoId);

                    pedidoServicio.CambiarProcesoTerminado(pedido.Id);

                    btnTerminar.Visible = false;

                    //caja

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = $"{lblPersona.Text} - Pedido Terminado",
                        Fecha = DateTime.Now,
                        Total = _Debe,
                        CajaId = detalleCajaServicio.BuscarCajaAbierta()
                    };

                    detalleCajaServicio.AgregarDetalleCaja(detalle);

                    cajaServicio.SumarDineroACaja(_Debe);

                    pedidoServicio.CambiarRamas(_Debe, PedidoId);

                    Datos(PedidoId);

                    lblVendido.Visible = true;

                    MessageBox.Show("---- Felicidades! ----", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("la Caja se encuentra cerrada", "Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
