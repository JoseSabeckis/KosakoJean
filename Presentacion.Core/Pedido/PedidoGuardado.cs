﻿using Presentacion.Clases;
using Presentacion.Core.Cobro;
using Presentacion.Core.Mensaje;
using Servicios.Core.Caja;
using Servicios.Core.CtaCte;
using Servicios.Core.CtaCte.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.Image.Dto;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Dato;
using Servicios.Core.Producto_Dato.Dto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
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
    public partial class PedidoGuardado : FormularioBase
    {
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProductoServicio productoServicio;
        private readonly IVentaServicio ventaServicio;
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detalleCajaServicio;

        private readonly ICtaCteServicio ctaCteServicio;

        AccesoDatos.Proceso Estado;

        long PedidoId;
        long EntidadId;
        decimal _Debe;
        bool EstaPorEliminar = false;

        List<VentaDto2> list;

        public PedidoGuardado(long pedidoId, AccesoDatos.Proceso estado)
        {
            InitializeComponent();

            producto_Pedido_Servicio = new Producto_Pedido_Servicio();
            pedidoServicio = new PedidoServicio();
            productoServicio = new ProductoServicio();
            cajaServicio = new CajaServicio();
            detalleCajaServicio = new DetalleCajaServicio();
            ctaCteServicio = new CtaCteServicio();
            ventaServicio = new VentaServicio();

            list = new List<VentaDto2>();

            Estado = estado;

            var _Pedido = pedidoServicio.Buscar(pedidoId);

            PedidoId = pedidoId;

            Datos(pedidoId);

            Esquema(pedidoId);


            if (_Pedido.Proceso == AccesoDatos.Proceso.Retirado)
            {
                btnTerminar.Visible = false;
                ckbTarjeta.Visible = false;
                ckbNormal.Visible = false;
                lblVendido.Visible = true;
                btnVolverPedidoNoRetirado.Visible = true;
                btnAgregarProductos.Visible = false;
                btnEliminarPedidoSeleccionado.Visible = false;
            }
            else
            {
                btnAgregarProductos.Visible = true;
            }

            if (_Pedido.EstaEliminado)
            {
                lblEliminado.Visible = true;
                btnGuardar.Visible = false;
                btnEliminar.Visible = false;

                txtNotas.Enabled = false;

                btnCobro.Visible = false;
                lblCobrar.Visible = false;
                ckbNormal.Visible = false;
                ckbTarjeta.Visible = false;
                nudCobro.Visible = false;

                btnTerminar.Visible = false;

                btnAgregarProductos.Visible = false;
                btnEliminarPedidoSeleccionado.Visible = false;
                btnVolverPedidoNoRetirado.Visible = false;

            }

            if (dgvGrilla.RowCount == 0)
            {
                btnEliminarPedidoSeleccionado.Visible = false;
                btnAgregarProductos.Visible = false;
                btnTerminar.Enabled = false;
            }

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgGuardado.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedido_Guardado);
        }

        public void VerificarSiEstaEliminadoElPedido()
        {
            if (pedidoServicio.BuscarIDPedidos(PedidoId).EstaEliminado)
            {
                btnGuardar.Visible = false;
                btnEliminar.Visible = false;

                btnEliminarPedidoSeleccionado.Visible = false;
                btnTerminar.Visible = false;

                lblCobrar.Visible = false;
                nudCobro.Visible = false;
                btnCobro.Visible = false;

                ckbNormal.Visible = false;
                ckbTarjeta.Visible = false;

                btnAgregarProductos.Visible = false;
                btnVolverPedidoNoRetirado.Visible = false;

                txtNotas.Enabled = false;
                lblEliminado.Visible = true;
            }
        }

        public void VerSiHayProductos()
        {
            if (dgvGrilla.RowCount == 0)
            {
                btnEliminarPedidoSeleccionado.Visible = false;
                btnAgregarProductos.Visible = false;
                btnTerminar.Visible = false;
            }
            else
            {
                btnEliminarPedidoSeleccionado.Visible = true;
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!EstaPorEliminar)
            {
                if (MessageBox.Show("Este Seguro De Eliminar Este Pedido, Perdera Todos Los Datos...?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            pedidoServicio.Eliminar(PedidoId);

            var ListaSoloIdProductoPedido = producto_Pedido_Servicio.Eliminar(PedidoId);

            MessageBox.Show("Pedido Eliminado...", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            VerificarSiEstaEliminadoElPedido();

        }

        public void VerSiHayProductosDespuesDeBorrar()
        {
            if (dgvGrilla.RowCount == 0)
            {
                EstaPorEliminar = true;
                btnEliminarPedidoSeleccionado.PerformClick();
            }
        }

        public void Datos(long pedidoId)
        {
            var pedido = pedidoServicio.Buscar(pedidoId);

            txtTotal.Text = string.Empty;
            txtDebe.Text = string.Empty;
            txtDineroAdelanto.Text = string.Empty;

            lblPersona.Text = $"{pedido.Apellido} {pedido.Nombre}";
            lblFechaInicio.Text = $"{pedido.FechaPedido.ToString("dddd dd/MM/yyyy")}";
            lblFecha.Text = $"{pedido.FechaEntrega.ToString("dddd dd/MM/yyyy")}";

            lblHorario.Text = $"{pedido.Horario}";

            txtNotas.Text = $"{pedido.Descripcion}";

            txtDineroAdelanto.Text = $"{pedido.Adelanto}";
            txtTotal.Text = $"{pedido.Total}";

            txtDebe.Text = $"{pedido.Total - pedido.Adelanto}";
            _Debe = pedido.Total - pedido.Adelanto;

            nudCobro.Maximum = _Debe;

            if (_Debe == 0)
            {

                ckbTarjeta.Visible = false;
                ckbNormal.Visible = false;

                nudCobro.Visible = false;
                lblCobrar.Visible = false;
                btnCobro.Visible = false;

                if (pedido.Proceso == AccesoDatos.Proceso.Retirado)
                {
                    btnTerminar.Visible = false;
                    lblVendido.Text = $"Entregado el \n{pedido.FechaRetirado}";
                }

                lblPagado.Text = $"| Pagado |";
                lblPagado.Visible = true;

            }
            else
            {
                ckbTarjeta.Visible = true;
                ckbNormal.Visible = true;

                nudCobro.Visible = true;
                lblCobrar.Visible = true;
                btnCobro.Visible = true;

                lblPagado.Visible = false;
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

            grilla.Columns["Colegio"].Visible = true;
            grilla.Columns["Colegio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Colegio"].HeaderText = @"Colegio";
            grilla.Columns["Colegio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Colegio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Talle"].Visible = true;
            grilla.Columns["Talle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Talle"].HeaderText = @"Talle";
            grilla.Columns["Talle"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Talle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Cantidad"].Visible = true;
            grilla.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Precio"].Visible = true;
            grilla.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Precio"].HeaderText = @"Precio";
            grilla.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           

        }

        public void CrearGrilla(long pedidoId)
        {
            List<Producto_Pedido_Dto> esquema = new List<Producto_Pedido_Dto>();

            if (Estado == AccesoDatos.Proceso.Guardado)
            {
                esquema = producto_Pedido_Servicio.BuscarPedidoId(pedidoId);
            }
            else
            {
                esquema = producto_Pedido_Servicio.BuscarPedidoRetirado(pedidoId);
            }

            foreach (var item in esquema)
            {
                var producto = productoServicio.ObtenerPorId(item.ProductoId);

                var lista = new VentaDto2
                {
                    Id = item.Id,
                    Cantidad = item.Cantidad,
                    Talle = item.Talle,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio * item.Cantidad,
                    ProductoId = producto.Id
                };

                list.Add(lista);

            }

        }

        private void Esquema(long pedidoId)
        {
            CrearGrilla(pedidoId);
            CargarGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            pedidoServicio.GuardarDatosString(txtNotas.Text, PedidoId);

            MessageBox.Show("Datos Guardados!", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (cajaServicio.BuscarCajaAbierta() != null)
            {
                if (MessageBox.Show("Esta por Terminar el Pedido, Esta Seguro?", "Preguntar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var pedido = pedidoServicio.Buscar(PedidoId);

                    pedidoServicio.CambiarProcesoRetirado(pedido.Id);

                    pedidoServicio.CambiarFechaRetirado(pedido.Id);

                    producto_Pedido_Servicio.CambiarEstado(pedido.Id);
                    
                    //Total Cta Cte

                    var cuentaId = new CtaCteDto();

                    if (pedido.ClienteId != 1)
                    {
                        cuentaId = ctaCteServicio.ObtenerPorIdDePedidosId(pedido.Id);

                        ctaCteServicio.Pagar(_Debe, pedido.ClienteId, cuentaId.Id);
                    }

                    //Fin Cta Cte

                    btnTerminar.Visible = false;

                    //caja

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = $"{lblPersona.Text} - Pedido Terminado",
                        Fecha = DateTime.Now.ToLongDateString(),
                        Total = _Debe,
                        CajaId = detalleCajaServicio.BuscarCajaAbierta()
                    };

                    TipoPago(detalle);

                    detalleCajaServicio.AgregarDetalleCaja(detalle);

                    cajaServicio.SumarDineroACaja(_Debe);

                    pedidoServicio.CambiarRamas(_Debe, PedidoId);

                    var venta = new VentaDto
                    {
                        ClienteId = pedido.ClienteId,
                        Descuento = 0,
                        Fecha = DateTime.Now,
                        Total = _Debe
                    };

                    ventaServicio.NuevaVenta(venta);

                    var completado = new Afirmacion("Felicidades!", $"Completado \nse obtuvo de ganancias $ {_Debe}\nTipo de Pago: {detalle.TipoPago}");
                    completado.ShowDialog();

                    Datos(PedidoId);

                    lblVendido.Visible = true;
                    btnAgregarProductos.Visible = false;
                    btnVolverPedidoNoRetirado.Visible = true;
                    btnEliminarPedidoSeleccionado.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("la Caja se encuentra cerrada", "Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCobro_Click(object sender, EventArgs e)
        {
            if (nudCobro.Value > 0)
            {
                if (MessageBox.Show("Esta Por Cobrar Un Adelanto, Desea Continuar?", "Adelanto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var pedido = pedidoServicio.Buscar(PedidoId);

                    //Total Cta Cte

                    var cuentaId = new CtaCteDto();

                    cuentaId = ctaCteServicio.ObtenerPorIdDePedidosId(pedido.Id);

                    ctaCteServicio.Pagar(nudCobro.Value, pedido.ClienteId, cuentaId.Id);

                    //caja

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = $"{lblPersona.Text} - Adelanto de Pedido",
                        Fecha = DateTime.Now.ToLongDateString(),
                        Total = nudCobro.Value,
                        CajaId = detalleCajaServicio.BuscarCajaAbierta()
                    };

                    TipoPago(detalle);

                    detalleCajaServicio.AgregarDetalleCaja(detalle);

                    cajaServicio.SumarDineroACaja(nudCobro.Value);

                    pedidoServicio.CambiarRamas(nudCobro.Value, PedidoId);

                    var venta = new VentaDto
                    {
                        ClienteId = pedido.ClienteId,
                        Descuento = 0,
                        Fecha = DateTime.Now,
                        Total = nudCobro.Value
                    };

                    ventaServicio.NuevaVenta(venta);

                    var completado = new Afirmacion("Felicidades!", $"Completado \nSe obtuvo de ganancias $ {nudCobro.Value}\nTipo de Pago: {detalle.TipoPago}");
                    completado.ShowDialog();

                    nudCobro.Value = 0;

                    Datos(PedidoId);

                }
            }
        }

        private void btnVolverPedidoNoRetirado_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro De Poner Este Pedido a no Retirado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pedidoServicio.CambiarProcesoGuardado(PedidoId);

                Datos(PedidoId);

                var mensaje = new Afirmacion("Pedido Cambiado a Espera de Retiro", "Completado");
                mensaje.ShowDialog();

                btnVolverPedidoNoRetirado.Visible = false;
                lblVendido.Visible = false;
                btnTerminar.Visible = true;
                btnAgregarProductos.Visible = true;
                btnEliminarPedidoSeleccionado.Visible = true;

                VerSiHayProductos();
            }
        }

        private void btnAgregarProductos_Click(object sender, EventArgs e)
        {
            var pedido = new AgregarProductos(PedidoId);
            pedido.ShowDialog();

            if (pedido.Bandera)
            {
                list = new List<VentaDto2>();
                CrearGrilla(PedidoId);
                CargarGrilla();

                Datos(PedidoId);

                VerSiHayProductos();

            }
        }

        private void btnEliminarPedidoSeleccionado_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                if (EntidadId != 0)
                {
                    if (MessageBox.Show("Esta Seguro de Borrar Este Producto?\nSi Hay Mas de un Producto Se Eliminara Uno", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var pedido = producto_Pedido_Servicio.ObtenerPorId(EntidadId);

                        decimal CantRestar = 0;
                        int Bandera = 0;

                        if (pedido.Cantidad > 1)
                        {
                            producto_Pedido_Servicio.RestarCantidad1(EntidadId);

                            CantRestar = productoServicio.ObtenerPorId(pedido.ProductoId).Precio;

                            Bandera = 1;
                        }
                        else
                        {
                            producto_Pedido_Servicio.EliminacionDefinitiva(EntidadId);

                            CantRestar = productoServicio.ObtenerPorId(pedido.ProductoId).Precio * pedido.Cantidad;

                            Bandera = 2;
                        }

                        pedidoServicio.RestarTotal(pedido.PedidoId, CantRestar);

                        var pedidoPrincipal = pedidoServicio.BuscarIDPedidos(pedido.PedidoId);

                        if (pedidoPrincipal.Adelanto != 0)
                        {
                            if (pedidoPrincipal.Adelanto > pedidoPrincipal.Total)
                            {
                                pedidoServicio.RestarAdelanto(pedidoPrincipal.Id, CantRestar);
                            }
                        }                        

                        //cargar datos de nuevo
                        CargaDeNuevo();
                        VerSiHayProductos();
                        VerSiHayProductosDespuesDeBorrar();

                        if (Bandera == 1)
                        {
                            MessageBox.Show("- Eliminacion Realizada -\nVerifique El Esta Del Producto Restante...", "Revision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (Bandera == 2)
                        {
                            MessageBox.Show("- Producto Borrado -\nContinue Controlando los Datos", "Bien", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        if (Bandera == 0)
                        {
                            MessageBox.Show("Contaxte al Programador Tel: 3813590385", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public void CargaDeNuevo()
        {
            list = new List<VentaDto2>();
            CrearGrilla(PedidoId);
            CargarGrilla();

            Datos(PedidoId);
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                EntidadId = (long)dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                EntidadId = 0;
            }
        }
    }
}
