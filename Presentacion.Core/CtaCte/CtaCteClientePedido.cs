﻿using Presentacion.Core.Mensaje;
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
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
using Servicios.Core.Producto_Venta;
using Servicios.Core.Producto_Venta.Dto;
using Servicios.Core.Talle;
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
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly ITalleServicio talleServicio;

        public bool semaforo = false;

        ClienteDto _Cliente;
        VentaDto ventaDto;
        List<Producto_Venta_Dto> ListaVenta;
        List<VentaDto2> ListaVentasDto2;
        decimal _Total;

        public CtaCteClientePedido(long clienteId, decimal total, List<Producto_Venta_Dto> listProductoVenta, List<VentaDto2> listVentaDto2)
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();
            producto_vent = new Producto_Venta_Servicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            clienteServicio = new ClienteServicio();
            ctaCteServicio = new CtaCteServicio();
            cajaServicio = new CajaServicio();
            detallCajaServicio = new DetalleCajaServicio();
            ventaServicio = new VentaServicio();
            pedidoServicio = new PedidoServicio();
            talleServicio = new TalleServicio();

            ventaDto = new VentaDto();

            ListaVentasDto2 = listVentaDto2;
            ListaVenta = listProductoVenta;

            var cliente = clienteServicio.ObtenerPorId(clienteId);

            cmbHorario.SelectedIndex = 0;

            txtApellido.Text = cliente.Apellido;
            txtNombre.Text = cliente.Nombre;

            if (txtApellido.Text == "Consumidor Final")
            {
                txtApellido.Text = string.Empty;

                txtApellido.Enabled = true;
                txtNombre.Enabled = true;
            }

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
            if (txtApellido.Text == string.Empty || txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Coloque El Nombre o el Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!ckbTarjeta.Checked && !ckbNormal.Checked)
            {
                MessageBox.Show("Seleccione Contado o Tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Seguro de Continuar?","Pregunta",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ventaDto.ClienteId = _Cliente.Id;
                ventaDto.Fecha = DateTime.Now;
                ventaDto.Total = nudAdelanto.Value;

                var ventaId = ventaServicio.NuevaVenta(ventaDto);

                string descripcion = string.Empty;

                foreach (var item in ListaVenta)
                {
                    var producto = productoServicio.ObtenerPorId(item.ProductoId);

                    item.VentaId = ventaId;

                    descripcion += " " + item.Descripcion + " ";
                    
                    // descontar stock
                    productoServicio.BajarStock(producto.Id, item.Cantidad);

                    producto_vent.NuevoProductoVenta(item);
                }               

                AccesoDatos.Proceso _Proceso;

                if (_Cliente.Id == 1)
                {
                    _Proceso = AccesoDatos.Proceso.Guardado;
                }
                else
                {
                    _Proceso = AccesoDatos.Proceso.CtaCte;
                }

                var pedido = new PedidoDto
                {
                    Adelanto = nudAdelanto.Value,
                    Apellido = txtApellido.Text,
                    FechaPedido = DateTime.Now,
                    Nombre = txtNombre.Text,
                    Proceso = _Proceso,
                    FechaEntrega = dtpFechaEntrega.Value,
                    Total = _Total,
                    ClienteId = _Cliente.Id,
                    Descripcion = $"Espera de Pago - {txtApellido.Text} {txtNombre.Text}",
                    Horario = $"Sera Retirado a la {cmbHorario.Text}"
                };

                var pedidoId = pedidoServicio.NuevoPedido(pedido);

                AccesoDatos.EstadoPedido EstadoPedido;

                if (_Cliente.Id == 1)
                {
                    EstadoPedido = AccesoDatos.EstadoPedido.Guardado;
                }
                else
                {
                    EstadoPedido = AccesoDatos.EstadoPedido.Esperando;
                }

                foreach (var item in ListaVentasDto2)
                {

                    var aux = new Producto_Pedido_Dto
                    {
                        Cantidad = item.Cantidad,
                        ProductoId = productoServicio.ObtenerPorId(item.Id).Id,
                        Estado = EstadoPedido,
                        Talle = item.Talle,
                        PedidoId = pedidoId,
                        Descripcion = descripcion,
                        TalleId = talleServicio.BuscarNombreDevuelveId(item.Talle),
                    };

                    producto_Pedido_Servicio.NuevoProductoPedido(aux);

                }

                var cuenta = new CtaCteDto
                {
                    ClienteId = _Cliente.Id,
                    Estado = AccesoDatos.CtaCteEstado.EnEspera,
                    Fecha = DateTime.Now,
                    Total = _Total,
                    Debe = _Total - nudAdelanto.Value,
                    Descripcion = $"Prenda Guardada",
                    PedidoId = pedidoId
                };

                ctaCteServicio.Agregar(cuenta);


                var detalle = new DetalleCajaDto
                {
                    Descripcion = txtApellido.Text + " " + txtNombre.Text,
                    Fecha = DateTime.Now.ToLongDateString(),
                    Total = nudAdelanto.Value,
                    CajaId = detallCajaServicio.BuscarCajaAbierta()
                };

                TipoPago(detalle);

                detallCajaServicio.AgregarDetalleCaja(detalle);

                //dinero a caja
                cajaServicio.SumarDineroACaja(nudAdelanto.Value);//

                var NewPrenda = new Afirmacion("Prenda Guardada", $"A Esperar...\nAdelanto de Cobro: {nudAdelanto.Value}");
                NewPrenda.ShowDialog();

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