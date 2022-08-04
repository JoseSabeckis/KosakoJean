using Presentacion.Clases;
using Servicios.Core.Image.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Venta;
using Servicios.Core.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
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

            public double Total { get; set; }

            public string TotalVista => Total.ToString("00.00");

            public string Fecha { get; set; }
        }

        List<HistorialCompras> ListaVentas;
        List<HistorialCompras> ListaPedidos;

        long IdCliente;

        public HistorialClientes(long idCliente)
        {
            InitializeComponent();

            ventaServicio = new VentaServicio();
            producto_Venta_Servicio = new Producto_Venta_Servicio();

            pedidoServicio = new PedidoServicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();

            ListaVentas = new List<HistorialCompras>();
            ListaPedidos = new List<HistorialCompras>();

            CargarNombre(idCliente);

            CargarGrilla(idCliente);

            IdCliente = idCliente;

            dgvGrillaVentas.DataSource = ListaVentas.ToList();
            dgvGrillaPedidos.DataSource = ListaPedidos.ToList();

            FormatearGrillaVentas(dgvGrillaVentas);
            FormatearGrilla(dgvGrillaPedidos);

            CargarImageEnGeneral();

        }

        private void CargarImageEnGeneral()
        {
            imgClientes.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Clientes);
        }

        private void CargarGrilla(long idCliente)
        {
            var lista = ventaServicio.VentaPorCliente(idCliente);
            var listPedidos = ventaServicio.VentaClientePedidos(idCliente);

            foreach (var ventas in lista)
            {

                var historial = new HistorialCompras
                {
                    Fecha = ventas.FechaString,
                    Total = (double)ventas.Total,
                    //Descripcion = producto_Venta_Servicio.ObtenerDescripcion(ventas.Id)
                };

                nudTotal.Value += (decimal)historial.Total;

                ListaVentas.Add(historial);

            }

            foreach (var ventas in listPedidos)
            {
                var pedido = producto_Venta_Servicio.ObtenerDescripcionPedido(ventas.Id);

                var historial = new HistorialCompras
                {
                    Fecha = ventas.FechaString,
                    Total = pedido.Precio,
                    Descripcion = pedido.Descripcion
                };

                nudTotal.Value += (decimal)historial.Total;

                ListaPedidos.Add(historial);

            }

            /*
            foreach (var item in pedidoServicio.BuscandoTerminadosyClientes(idCliente))
            {

                var pedido = new HistorialCompras
                {
                    Fecha = item.FechaPedido,
                    Total = item.Total,
                    Descripcion = producto_Pedido_Servicio.BuscarPedidoId2(item.Id).Descripcion
                };

                nudTotal.Value += pedido.Total;

                ListaPedidos.Add(pedido);

            }
            */
        }

        private void CargarGrillaDesdeHasta(long idCliente)
        {
            ListaVentas = new List<HistorialCompras>();
            ListaPedidos = new List<HistorialCompras>();
            nudTotal.Value = 0;

            foreach (var ventas in ventaServicio.VentaPorClienteDesdeHasta(idCliente, dtpDesde.Value, dtpHasta.Value))
            {

                var historial = new HistorialCompras
                {
                    Fecha = ventas.FechaString,
                    Total = ventas.Total,
                    //Descripcion = producto_Venta_Servicio.ObtenerDescripcion(ventas.Id).Descripcion
                };

                nudTotal.Value += (decimal)historial.Total;

                ListaVentas.Add(historial);

            }

            foreach (var ventas in ventaServicio.VentaPorClienteDesdeHastaPedido(idCliente, dtpDesde.Value, dtpHasta.Value))
            {
                var producto = producto_Venta_Servicio.ObtenerDescripcionPedido(ventas.Id);

                var historial = new HistorialCompras
                {
                    Fecha = ventas.FechaString,
                    Total = producto.Precio,
                    Descripcion = producto.Descripcion
                };

                nudTotal.Value += (decimal)historial.Total;

                ListaPedidos.Add(historial);

            }

            /*
            foreach (var item in pedidoServicio.BuscandoTerminadosyClientesDesdeHasta(idCliente, dtpDesde.Value, dtpHasta.Value))
            {

                var pedido = new HistorialCompras
                {
                    Fecha = item.FechaPedido,
                    Total = item.Total,
                    Descripcion = producto_Pedido_Servicio.BuscarPedidoId2(item.Id).Descripcion
                };

                nudTotal.Value += pedido.Total;

                ListaVentas.Add(pedido);

            }
            */
        }

        private void CargarGrillaFecha(long idCliente)
        {
            ListaVentas = new List<HistorialCompras>();
            ListaPedidos = new List<HistorialCompras>();
            nudTotal.Value = 0;

            foreach (var ventas in ventaServicio.VentaPorClienteFechaPedido(idCliente, dtpDesde.Value))
            {
                var pedido = producto_Venta_Servicio.ObtenerDescripcionPedido(ventas.Id);

                var historial = new HistorialCompras
                {
                    Fecha = ventas.FechaString,
                    Total = pedido.Precio,
                    Descripcion = pedido.Descripcion
                };

                nudTotal.Value += (decimal)historial.Total;

                ListaPedidos.Add(historial);

            }

            foreach (var ventas in ventaServicio.VentaPorClienteFecha(idCliente, dtpDesde.Value))
            {

                var historial = new HistorialCompras
                {
                    Fecha = ventas.FechaString,
                    Total = ventas.Total,
                    //Descripcion = producto_Venta_Servicio.ObtenerDescripcion(ventas.Id).Descripcion
                };

                nudTotal.Value += (decimal)historial.Total;

                ListaVentas.Add(historial);

            }

            /*
            foreach (var item in pedidoServicio.BuscandoTerminadosyClientesFecha(idCliente, dtpDesde.Value))
            {

                var pedido = new HistorialCompras
                {
                    Fecha = item.FechaPedido,
                    Total = item.Total,
                    Descripcion = producto_Pedido_Servicio.BuscarPedidoId2(item.Id).Descripcion
                };

                nudTotal.Value += pedido.Total;

                ListaVentas.Add(pedido);

            }
            */
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

            grilla.Columns["TotalVista"].Visible = true;
            grilla.Columns["TotalVista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TotalVista"].HeaderText = @"Total";
            grilla.Columns["TotalVista"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["TotalVista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Fecha"].HeaderText = @"Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public void FormatearGrillaVentas(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["TotalVista"].Visible = true;
            grilla.Columns["TotalVista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TotalVista"].HeaderText = @"Total";
            grilla.Columns["TotalVista"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["TotalVista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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


            dgvGrillaPedidos.DataSource = ListaPedidos.ToList();
            dgvGrillaVentas.DataSource = ListaVentas.ToList();
        }
    }
}
