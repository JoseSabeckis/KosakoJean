﻿using Presentacion.Core.Mensaje;
using Servicios.Core.Caja;
using Servicios.Core.CtaCte;
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

        private readonly ICtaCteServicio ctaCteServicio;

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
            ctaCteServicio = new CtaCteServicio();

            list = new List<VentaDto2>();

            var _Pedido = pedidoServicio.Buscar(pedidoId);

            if (_Pedido.Proceso == AccesoDatos.Proceso.PedidoTerminado)
            {
                btnEliminar.Visible = true;
            }
            else
            {
                btnEliminar.Visible = false;
            }

            Estado = estado;

            PedidoId = pedidoId;

            Datos(pedidoId);

            Esquema(pedidoId);

            lblVendido.Visible = false;

            if (_Pedido.Proceso == AccesoDatos.Proceso.InicioPedido)
            {
                btnTerminar.Visible = false;
                ckbTarjeta.Visible = false;
                ckbNormal.Visible = false;
            }
            else
            {
                if (_Pedido.Proceso == AccesoDatos.Proceso.EsperandoRetiro)
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
            txtNotas.Text = $"{pedido.Descripcion}";

            txtDineroAdelanto.Text = $"{pedido.Adelanto}";
            txtTotal.Text = $"{pedido.Total}";

            txtDebe.Text = $"{pedido.Total - pedido.Adelanto}";
            _Debe = pedido.Total - pedido.Adelanto;

            if (_Debe == 0)
            {

                ckbTarjeta.Visible = false;
                ckbNormal.Visible = false;

                if (pedido.Proceso == AccesoDatos.Proceso.PedidoTerminado)
                {
                    btnTerminar.Visible = false;
                }

                lblPagado.Visible = true;

            }
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

                    //Total Cta Cte

                    var cuentaId = ctaCteServicio.ObtenerPorIdDePedidosId(pedido.Id);

                    if (cuentaId != null)
                    {
                        ctaCteServicio.Pagar(_Debe, pedido.ClienteId, cuentaId.Id);
                    }               

                    //Fin Cta Cte

                    btnTerminar.Visible = false;

                    //caja

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = $"{lblPersona.Text} - Pedido Terminado",
                        Fecha = DateTime.Now.ToString("dd/MM/yy"),
                        Total = _Debe,
                        CajaId = detalleCajaServicio.BuscarCajaAbierta()
                    };

                    TipoPago(detalle);

                    detalleCajaServicio.AgregarDetalleCaja(detalle);

                    cajaServicio.SumarDineroACaja(_Debe);

                    pedidoServicio.CambiarRamas(_Debe, PedidoId);

                    var completado = new Afirmacion("Felicidades!", $"Completado se obtuvo de ganancias $ {_Debe}");
                    completado.ShowDialog();

                    Datos(PedidoId);

                    lblVendido.Visible = true;                    

                    //MessageBox.Show("---- Felicidades! ----", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("la Caja se encuentra cerrada", "Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Este seguro de eliminar este Pedido?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pedidoServicio.Eliminar(PedidoId);

                MessageBox.Show("Pedido Eliminado...", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            pedidoServicio.GuardarDatosString(txtNotas.Text, PedidoId);

            MessageBox.Show("Datos Guardados!", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
        }

        private void ckbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNormal.Checked == true)
            {
                ckbTarjeta.Checked = false;
            }
            else
            {
                ckbTarjeta.Checked = true;
            }
        }

        private void ckbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTarjeta.Checked == true)
            {
                ckbNormal.Checked = false;
            }
            else
            {
                ckbNormal.Checked = true;
            }
        }
    }
}
