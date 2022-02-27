using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.CtaCte;
using Servicios.Core.CtaCte.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Venta;
using Servicios.Core.Producto_Venta.Dto;
using Servicios.Core.Talle.Dto;
using Servicios.Core.Venta;
using Servicios.Core.Venta.Dto;
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
    public partial class CtaCteClientePedido : Form
    {
        private readonly IPedidoServicio pedidoServicio;
        private readonly IClienteServicio clienteServicio;
        private readonly IProductoServicio productoServicio;
        private readonly IProducto_Venta_Servicio producto_vent;
        private readonly ICtaCteServicio ctaCteServicio;
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detallCajaServicio;
        private readonly IVentaServicio ventaServicio;

        public bool semaforo = false;

        ClienteDto _Cliente;
        VentaDto ventaDto;
        List<Producto_Venta_Dto> ListaVenta;
        decimal _Total;

        public CtaCteClientePedido(long clienteId, decimal total, List<Producto_Venta_Dto> list)
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();
            producto_vent = new Producto_Venta_Servicio();
            clienteServicio = new ClienteServicio();
            ctaCteServicio = new CtaCteServicio();
            cajaServicio = new CajaServicio();
            detallCajaServicio = new DetalleCajaServicio();
            ventaServicio = new VentaServicio();
            pedidoServicio = new PedidoServicio();

            ventaDto = new VentaDto();
            ListaVenta = list;

            var cliente = clienteServicio.ObtenerPorId(clienteId);

            txtApellido.Text = cliente.Apellido;
            txtNombre.Text = cliente.Nombre;

            nudAdelanto.Maximum = total;

            _Total = total;

            _Cliente = cliente;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ckbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNormal.Checked)
            {
                ckbTarjeta.Checked = false;
            }
        }

        private void ckbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTarjeta.Checked)
            {
                ckbNormal.Checked = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ckbTarjeta.Checked && !ckbNormal.Checked)
            {
                MessageBox.Show("Seleccione Contado o Tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Seguro de Continuar?","Pregunta",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ventaDto.ClienteId = _Cliente.Id;
                ventaDto.Fecha = DateTime.Now.ToLongDateString();
                ventaDto.Total = nudAdelanto.Value;

                var ventaId = ventaServicio.NuevaVenta(ventaDto);

                foreach (var item in ListaVenta)
                {
                    var producto = productoServicio.ObtenerPorId(item.ProductoId);

                    // descontar stock
                    productoServicio.BajarStock(producto.Id, item.Cantidad);

                    producto_vent.NuevoProductoVenta(item);
                }

                var pedido = new PedidoDto
                {
                    Adelanto = nudAdelanto.Value,
                    Apellido = txtApellido.Text,
                    FechaPedido = DateTime.Now,
                    Nombre = txtNombre.Text,
                    Proceso = AccesoDatos.Proceso.PedidoTerminado,
                    FechaEntrega = DateTime.Now,
                    Total = _Total,
                    ClienteId = _Cliente.Id,
                    Descripcion = $"Espera de Pago - {txtApellido.Text} {txtNombre.Text}",

                };

                var pedidoId = pedidoServicio.NuevoPedido(pedido);

                var cuenta = new CtaCteDto
                {
                    ClienteId = _Cliente.Id,
                    Estado = AccesoDatos.CtaCteEstado.EnEspera,
                    Fecha = DateTime.Now,
                    Total = _Total,
                    Debe = _Total - nudAdelanto.Value,
                    Descripcion = $"Sin Datos",
                    PedidoId = pedidoId
                };

                ctaCteServicio.Agregar(cuenta);


                var detalle = new DetalleCajaDto
                {
                    Descripcion = txtApellido.Text + " " + txtNombre.Text,
                    Fecha = DateTime.Now.ToString("dddd dd/MM/yy"),
                    Total = nudAdelanto.Value,
                    CajaId = detallCajaServicio.BuscarCajaAbierta()
                };

                TipoPago(detalle);

                detallCajaServicio.AgregarDetalleCaja(detalle);

                //dinero a caja
                cajaServicio.SumarDineroACaja(nudAdelanto.Value);//


                semaforo = true;

                this.Close();
            }
        }

        public void TipoPago(DetalleCajaDto detalle)
        {
            if (ckbNormal.Checked)
            {
                detalle.TipoPago = AccesoDatos.TipoPago.Contado;
            }

            if (ckbTarjeta.Checked)
            {
                detalle.TipoPago = AccesoDatos.TipoPago.Tarjeta;
            }
        }

    }
}
