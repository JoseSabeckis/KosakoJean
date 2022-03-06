﻿using Presentacion.Core.Cobro;
using Presentacion.Core.Factura;
using Presentacion.Core.Mensaje;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.CtaCte;
using Servicios.Core.CtaCte.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.Fecha;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
using Servicios.Core.Talle;
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

namespace Presentacion.Core.Pedido
{
    public partial class Pedido : Form
    {
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IProductoServicio productoServicio;
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detallCajaServicio;
        private readonly ICtaCteServicio ctaCteServicio;
        private readonly ITalleServicio talleServicio;
        private readonly IClienteServicio clienteServicio;
        private readonly IVentaServicio ventaServicio;

        public bool semaforo = false;

        decimal _total;
        long ClienteId;
        long _TalleId;

        ClienteDto _Cliente;
        List<VentaDto2> ListaVentas;

        public Pedido(List<VentaDto2> Lista, decimal total, string nombre, long clienteId, string descripcion, long talleId)
        {
            InitializeComponent();

            pedidoServicio = new PedidoServicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            productoServicio = new ProductoServicio();
            cajaServicio = new CajaServicio();
            detallCajaServicio = new DetalleCajaServicio();
            ctaCteServicio = new CtaCteServicio();
            talleServicio = new TalleServicio();
            clienteServicio = new ClienteServicio();
            ventaServicio = new VentaServicio();

            _Cliente = new ClienteDto();

            _Cliente = clienteServicio.ObtenerPorId(clienteId);

            cmbHorario.SelectedIndex = 0;

            txtDescripcion.Text = descripcion;

            if (nombre != null)
            {
                txtApellido.Text = _Cliente.Apellido;
                txtNombre.Text = _Cliente.Nombre;
            }

            _total = total;
            ListaVentas = Lista;
            _TalleId = talleId;

            nudAdelanto.Maximum = _total;

            ClienteId = clienteId;

            if (clienteId != 0)
            {
                if (clienteId != 1)
                {
                    txtApellido.Enabled = false;
                    txtNombre.Enabled = false;
                }
                else
                {
                    txtApellido.Text = string.Empty;
                    txtNombre.Text = string.Empty;

                    ckbCtaCte.Enabled = false;
                }
            }

        }

        public bool AsignarControles()
        {
            if (txtApellido.Text == string.Empty || txtNombre.Text == string.Empty)
            {
                return false;
            }

            return true;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void VerificarSiEsTotal()
        {
            if (nudAdelanto.Value == _total)
            {
                if (ClienteId != 1)
                {
                    ckbCtaCte.Checked = false;
                    ckbCtaCte.Enabled = false;

                    ckbNormal.Checked = true;
                }
                
            }
            else
            {
                if (ClienteId != 1)
                {
                    ckbCtaCte.Enabled = true;
                }               
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (AsignarControles())
            {

                if (ckbNormal.Checked == false && ckbCtaCte.Checked == false && ckbTarjeta.Checked == false)
                {
                    MessageBox.Show("Seleccione el Tipo de Pago: Contado, CtaCte, Tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (MessageBox.Show("Esta Seguro de Continuar? Puede ser un Cobro para Despues", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var pedido = new PedidoDto
                    {
                        Adelanto = nudAdelanto.Value,
                        Apellido = txtApellido.Text,
                        FechaPedido = DateTime.Now,
                        Nombre = txtNombre.Text,
                        Proceso = AccesoDatos.Proceso.InicioPedido,
                        FechaEntrega = dtpFechaEntrega.Value.Date,
                        Total = _total,
                        ClienteId = ClienteId,
                        Descripcion = txtDescripcion.Text,
                        Horario = cmbHorario.Text
                    };

                    var pedidoId = pedidoServicio.NuevoPedido(pedido);

                    ProductoDto producto = new ProductoDto();

                    string segunda = string.Empty;

                    foreach (var item in ListaVentas)
                    {
                        producto = productoServicio.ObtenerPorId(item.Id);

                        segunda += " " + producto.Descripcion + " ";

                        //stock
                        productoServicio.BajarStock(producto.Id, item.Cantidad);
                        
                    }

                    foreach (var item in ListaVentas)
                    {

                        var aux = new Producto_Pedido_Dto
                        {
                            Cantidad = item.Cantidad,
                            ProductoId = productoServicio.ObtenerPorId(item.Id).Id,
                            Estado = AccesoDatos.EstadoPedido.Esperando,
                            Talle = item.Talle,
                            PedidoId = pedidoId,
                            Descripcion = segunda,
                            TalleId = _TalleId
                        };

                        producto_Pedido_Servicio.NuevoProductoPedido(aux);                        

                    }

                    if (ckbCtaCte.Checked)
                    {
                        var cuenta = new CtaCteDto
                        {
                            ClienteId = ClienteId,
                            Estado = AccesoDatos.CtaCteEstado.EnEspera,
                            Fecha = dtpFechaEntrega.Value.Date,
                            Total = _total,
                            Debe = _total - nudAdelanto.Value,
                            Descripcion = $"{segunda}",
                            PedidoId = pedidoId
                        };

                        ctaCteServicio.Agregar(cuenta);
                    }
                    

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = txtApellido.Text + " " + txtNombre.Text + " - " + segunda,
                        Fecha = DateTime.Now.ToLongDateString(),
                        Total = nudAdelanto.Value,
                        CajaId = detallCajaServicio.BuscarCajaAbierta()
                    };

                    TipoPago(detalle);

                    detallCajaServicio.AgregarDetalleCaja(detalle);

                    //dinero a caja
                    cajaServicio.SumarDineroACaja(nudAdelanto.Value);//

                    var mensaje = new Afirmacion("Agregado a la Cuenta!", $"Dinero Cobrado Por Adelanto $ {nudAdelanto.Value}");
                    mensaje.ShowDialog();

                    if (ckbNormal.Checked || ckbTarjeta.Checked)
                    {
                        if (nudAdelanto.Value == _total)
                        {
                            foreach (var item in ListaVentas)
                            {
                                item.Precio = item.Cantidad * item.Precio;
                            }

                            //ticket

                            var fecha = new FechaDto
                            {
                                Fecha = DateTime.Now.ToShortDateString(),
                                Hora = DateTime.Now.ToShortTimeString()
                            };

                            var factura = new Comprobante(ListaVentas.ToList(), fecha);
                            factura.ShowDialog();
                        }
                    }

                    semaforo = true;

                    this.Close();

                    return;
                }
                                                                  
            }
            else
            {
                var mens = new Negativo("Error", "Apellido y Nombre \nno puede estar vacio");
                mens.ShowDialog();
                //MessageBox.Show("El Campo Apellido y Nombre no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void TipoPago(DetalleCajaDto detalle)
        {
            if (ckbNormal.Checked)
            {
                detalle.TipoPago = AccesoDatos.TipoPago.Contado;
            }
            if (ckbCtaCte.Checked)
            {
                detalle.TipoPago = AccesoDatos.TipoPago.CtaCte;
            }
            if (ckbTarjeta.Checked)
            {
                detalle.TipoPago = AccesoDatos.TipoPago.Tarjeta;
            }
        }

        private void ckbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNormal.Checked == true)
            {
                ckbCtaCte.Checked = false;
                ckbTarjeta.Checked = false;
            }
        }

        private void ckbCtaCte_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCtaCte.Checked == true)
            {
                ckbNormal.Checked = false;
                ckbTarjeta.Checked = false;
            }
        }

        private void nudAdelanto_ValueChanged(object sender, EventArgs e)
        {
            VerificarSiEsTotal();
        }

        private void ckbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTarjeta.Checked == true)
            {
                ckbNormal.Checked = false;
                ckbCtaCte.Checked = false;
            }
        }
    }
}
