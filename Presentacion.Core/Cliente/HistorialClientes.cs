using Servicios.Core.Pedido;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Venta;
using Servicios.Core.Venta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Cliente
{
    public partial class HistorialClientes : Form
    {
        private readonly IVentaServicio ventaServicio;
        private readonly IProducto_Venta_Servicio producto_Venta_Servicio;
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;

        public class HistorialCompras
        {
            public string Descripcion { get; set; }

            public decimal Total { get; set; }

            public DateTime Fecha { get; set; }
        }

        List<HistorialCompras> Lista;

        long IdCliente;

        public HistorialClientes(long idCliente)
        {
            InitializeComponent();

            ventaServicio = new VentaServicio();
            producto_Venta_Servicio = new Producto_Venta_Servicio();

            pedidoServicio = new PedidoServicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();

            Lista = new List<HistorialCompras>();

            CargarNombre(idCliente);

            CargarGrilla(idCliente);

            IdCliente = idCliente;

            dgvGrilla.DataSource = Lista.ToList();

            FormatearGrilla(dgvGrilla);

        }

        private void CargarGrilla(long idCliente)
        {
            foreach (var ventas in ventaServicio.VentaPorCliente(idCliente))
            {

                var historial = new HistorialCompras
                {
                    Fecha = ventas.Fecha,
                    Total = ventas.Total,
                    Descripcion = producto_Venta_Servicio.ObtenerDescripcion(ventas.Id).Descripcion
                };

                nudTotal.Value += historial.Total;

                Lista.Add(historial);

            }


            foreach (var item in pedidoServicio.BuscandoTerminadosyClientes(idCliente))
            {

                var pedido = new HistorialCompras
                {
                    Fecha = item.FechaPedido,
                    Total = item.Total,
                    Descripcion = producto_Pedido_Servicio.BuscarPedidoId2(item.Id).Descripcion
                };

                nudTotal.Value += pedido.Total;

                Lista.Add(pedido);

            }
            
        }

        private void CargarGrillaDesdeHasta(long idCliente)
        {
            Lista = new List<HistorialCompras>();
            nudTotal.Value = 0;

            foreach (var ventas in ventaServicio.VentaPorClienteDesdeHasta(idCliente, dtpDesde.Value, dtpHasta.Value))
            {

                var historial = new HistorialCompras
                {
                    Fecha = ventas.Fecha,
                    Total = ventas.Total,
                    Descripcion = producto_Venta_Servicio.ObtenerDescripcion(ventas.Id).Descripcion
                };

                nudTotal.Value += historial.Total;

                Lista.Add(historial);

            }
            
            
            foreach (var item in pedidoServicio.BuscandoTerminadosyClientesDesdeHasta(idCliente, dtpDesde.Value, dtpHasta.Value))
            {

                var pedido = new HistorialCompras
                {
                    Fecha = item.FechaPedido,
                    Total = item.Total,
                    Descripcion = producto_Pedido_Servicio.BuscarPedidoId2(item.Id).Descripcion
                };

                nudTotal.Value += pedido.Total;

                Lista.Add(pedido);

            }

        }

        private void CargarGrillaFecha(long idCliente)
        {
            Lista = new List<HistorialCompras>();
            nudTotal.Value = 0;

            foreach (var ventas in ventaServicio.VentaPorClienteFecha(idCliente, dtpDesde.Value))
            {

                var historial = new HistorialCompras
                {
                    Fecha = ventas.Fecha,
                    Total = ventas.Total,
                    Descripcion = producto_Venta_Servicio.ObtenerDescripcion(ventas.Id).Descripcion
                };

                nudTotal.Value += historial.Total;

                Lista.Add(historial);

            }


            foreach (var item in pedidoServicio.BuscandoTerminadosyClientesFecha(idCliente, dtpDesde.Value))
            {

                var pedido = new HistorialCompras
                {
                    Fecha = item.FechaPedido,
                    Total = item.Total,
                    Descripcion = producto_Pedido_Servicio.BuscarPedidoId2(item.Id).Descripcion
                };

                nudTotal.Value += pedido.Total;

                Lista.Add(pedido);

            }

        }

        public void CargarNombre(long idCliente)
        {
            lblNombre.Text = ventaServicio.ObtenerClienteName(idCliente);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
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

            grilla.Columns["Total"].Visible = true;
            grilla.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Total"].HeaderText = @"Total";
            grilla.Columns["Total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Fecha"].HeaderText = @"Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (dtpDesde == dtpHasta)
            {
                CargarGrillaFecha(IdCliente);

            }
            else
            {
                CargarGrillaDesdeHasta(IdCliente);
            }
            

            dgvGrilla.DataSource = Lista.ToList();
        }
    }
}
