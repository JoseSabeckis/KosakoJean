using Presentacion.Clases;
using Presentacion.Core.Cobro;
using Presentacion.Core.Mensaje;
using Presentacion.Core.Producto_Dato;
using Servicios.Core.Caja;
using Servicios.Core.Configuracion;
using Servicios.Core.CtaCte;
using Servicios.Core.CtaCte.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.Image.Dto;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto_Dato;
using Servicios.Core.Producto_Dato.Dto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
using Servicios.Core.Ticket;
using Servicios.Core.Venta;
using Servicios.Core.Venta.Dto;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Pedido
{
    public partial class PedidoInfo : Form
    {
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProductoServicio productoServicio;
        private readonly IVentaServicio ventaServicio;
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detalleCajaServicio;
        private readonly IProducto_Dato_Servicio producto_Dato_Servicio;
        private readonly ICtaCteServicio ctaCteServicio;
        private readonly IConfiguracionServicio configuracionServicio;
        private readonly ITicketServicio ticketServicio;

        AccesoDatos.EstadoPedido Estado;

        public bool Eliminado = false;
        protected long EntidadId;
        protected long ProductoId;
        long PedidoId;
        long EntidadParaBorrar;
        bool EstaPorEliminar = false;
        PedidoDto _PedidoDto;

        double _Debe;

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
            ventaServicio = new VentaServicio();
            producto_Dato_Servicio = new Producto_Dato_Servicio();
            configuracionServicio = new ConfiguracionServicio();
            ticketServicio = new TicketServicio();

            list = new List<VentaDto2>();

            var _Pedido = pedidoServicio.Buscar(pedidoId);

            Estado = estado;

            PedidoId = pedidoId;

            Datos(pedidoId);

            Esquema(pedidoId);

            lblVendido.Visible = false;

            if (_Pedido.Proceso == AccesoDatos.Proceso.InicioPedido)
            {
                btnTerminar.Visible = false;
            }
            else
            {
                if (_Pedido.Proceso == AccesoDatos.Proceso.EsperandoRetiro)
                {
                    btnTerminar.Visible = true;
                    btnAgregarProductos.Visible = true;
                }
                else
                {
                    btnTerminar.Visible = false;
                    lblVendido.Visible = true;
                    btnVolverPedidoNoRetirado.Visible = true;
                    btnAgregarProductos.Visible = false;
                    btnEliminarPedidoSeleccionado.Visible = false;
                }
            }

            if (_Pedido.EstaEliminado)
            {
                btnEliminar.Visible = false;
                BloquearTodo();
            }
            else
            {
                VerSiHayProductos();
            }

            SiNoHayProductos();

            CargarImageEnGeneral();
        }

        public void BloquearTodo()
        {
            lblEliminado.Visible = true;
            btnGuardar.Visible = false;
            txtNotas.Enabled = false;

            btnEliminarPedidoSeleccionado.Visible = false;
            btnAgregarProductos.Visible = false;
            btnVolverPedidoNoRetirado.Visible = false;

            ckbTarjeta.Visible = false;
            ckbNormal.Visible = false;

            nudCobro.Visible = false;

            lblCobrar.Visible = false;
            btnCobro.Visible = false;
            btnRestar.Visible = false;
        }

        private void CargarImageEnGeneral()
        {
            imgLogo.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Info);
        }

        public void PonerNumOperacion()
        {
            var cuenta = ctaCteServicio.ObtenerPorIdDePedidosId(PedidoId);

            lblNumeroOperacion.Text = "#" + cuenta.NumeroOperacion.ToString("00000");
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

            grilla.Columns["PrecioString"].Visible = true;
            grilla.Columns["PrecioString"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["PrecioString"].HeaderText = @"Precio";
            grilla.Columns["PrecioString"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["PrecioString"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Cantidad"].Visible = true;
            grilla.Columns["Cantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Cantidad"].HeaderText = @"Cantidad";
            grilla.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Estado"].Visible = true;
            grilla.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Estado"].HeaderText = @"Estado";
            grilla.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        public void CrearGrilla(long pedidoId)
        {
            List<Producto_Pedido_Dto> esquema = new List<Producto_Pedido_Dto>();

            if (Estado == AccesoDatos.EstadoPedido.Esperando)
            {
                esquema = producto_Pedido_Servicio.BuscarPedidoId(pedidoId);
            }
            else
            {
                esquema = producto_Pedido_Servicio.BuscarPedidoTerminado(pedidoId);
            }

            foreach (var item in esquema)
            {
                var producto = productoServicio.ObtenerPorId(item.ProductoId);

                var lista = new VentaDto2
                {
                    Id = item.Id,
                    Cantidad = (double)item.Cantidad,
                    Talle = item.Talle,
                    Descripcion = producto.Descripcion,
                    Precio = item.Precio * (double)item.Cantidad,
                    ProductoId = producto.Id
                };

                var listaDatos = producto_Dato_Servicio.ObtenerProductosPorPedidoId(item.Id);

                int CantEnEspera = 0;
                int CantTerminado = 0;
                int CantCancelado = 0;

#pragma warning disable CS0219 // La variable 'bandera' está asignada pero su valor nunca se usa
                bool bandera = false;
#pragma warning restore CS0219 // La variable 'bandera' está asignada pero su valor nunca se usa

                foreach (var dato in listaDatos)
                {
                    if (dato.EstadoPorPedido == AccesoDatos.EstadoPorPedido.EnEspera)
                    {
                        CantEnEspera += 1;
                    }

                    if (dato.EstadoPorPedido == AccesoDatos.EstadoPorPedido.Terminado)
                    {
                        CantTerminado += 1;
                    }

                    if (dato.EstadoPorPedido == AccesoDatos.EstadoPorPedido.Cancelado)
                    {
                        CantCancelado += 1;
                    }
                }

                if (producto.Creacion)
                {
                    lista.Estado = $"EnEspera: {CantEnEspera}, Terminado: {CantTerminado}, Cancelado: {CantCancelado}";
                }
                else
                {
                    lista.Estado = "Realizado";
                }

                list.Add(lista);
            }

        }

        private void Esquema(long pedidoId)
        {
            CrearGrilla(pedidoId);

            CargarGrilla();
        }

        public void Datos(long pedidoId)
        {
            var pedido = pedidoServicio.Buscar(pedidoId);

            _PedidoDto = pedidoServicio.BuscarDto(pedidoId);

            txtTotal.Text = string.Empty;
            txtDebe.Text = string.Empty;
            txtDineroAdelanto.Text = string.Empty;

            lblPersona.Text = $"{pedido.Apellido} {pedido.Nombre}";
            lblFechaInicio.Text = $"{pedido.FechaPedido.ToString("dddd dd/MM/yyyy")}";
            lblFecha.Text = $"{pedido.FechaEntrega.ToString("dddd dd/MM/yyyy")}";

            PonerNumOperacion();
            lblHorario.Text = $"Se Retira a la: {pedido.Horario}";

            txtNotas.Text = $"{pedido.Descripcion}";

            txtDineroAdelanto.Text = pedido.Adelanto.ToString("00.00");
            txtTotal.Text = pedido.Total.ToString("00.00");

            txtDebe.Text = (pedido.Total - pedido.Adelanto).ToString("00.00");
            _Debe = pedido.Total - pedido.Adelanto;

            nudCobro.Maximum = (decimal)_Debe;

            if (_Debe == 0)
            {

                ckbTarjeta.Visible = false;
                ckbNormal.Visible = false;

                nudCobro.Visible = false;

                lblCobrar.Visible = false;
                btnCobro.Visible = false;
                btnRestar.Visible = false;

                if (pedido.Proceso == AccesoDatos.Proceso.PedidoTerminado)
                {
                    btnTerminar.Visible = false;
                    lblVendido.Text = $"Entregado el \n{pedido.FechaRetirado}";
                }

                if (!pedido.EstaEliminado)
                {
                    lblPagado.Text = $"| Pagado |";
                    lblPagado.Visible = true;
                }

            }
            else
            {
                ckbTarjeta.Visible = true;
                ckbNormal.Visible = true;

                nudCobro.Visible = true;
                lblCobrar.Visible = true;
                btnCobro.Visible = true;
                btnRestar.Visible = true;

                lblPagado.Visible = false;
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool VerCaja()
        {
            var caja = cajaServicio.BuscarCajaAbierta();

            if (caja == null)
            {
                return false;
            }

            return true;
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (cajaServicio.BuscarCajaAbierta() != null)
            {
                if (MessageBox.Show("Esta por Terminar el Pedido, Esta Seguro?", "Preguntar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var pedido = pedidoServicio.Buscar(PedidoId);

                    pedidoServicio.CambiarProcesoTerminado(pedido.Id);

                    pedidoServicio.CambiarFechaRetirado(pedido.Id);

                    pedidoServicio.CambiarFechaDatoRetiro(pedido.Id);

                    producto_Pedido_Servicio.CambiarEstado(pedido.Id);

                    //Total Cta Cte

                    var cuentaId = new CtaCteDto();

                    cuentaId = ctaCteServicio.ObtenerPorIdDePedidosId(pedido.Id);

                    ctaCteServicio.Pagar(_Debe, pedido.ClienteId, cuentaId.Id);

                    //Fin Cta Cte

                    btnTerminar.Visible = false;

                    //caja

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = $"{lblPersona.Text} - Pedido Terminado",
                        Fecha = DateTime.Now.ToString(),
                        Total = _Debe,
                        CajaId = detalleCajaServicio.BuscarCajaAbierta(),
                        NumeroOperacion = cuentaId.NumeroOperacion
                    };

                    TipoPago(detalle);

                    detalleCajaServicio.AgregarDetalleCaja(detalle);

                    cajaServicio.SumarDineroACaja(_Debe);

                    pedidoServicio.CambiarRamas((double)_Debe, PedidoId);

                    var venta = new VentaDto
                    {
                        ClienteId = pedido.ClienteId,
                        Descuento = 0,
                        Fecha = DateTime.Now,
                        Total = (double)_Debe
                    };

                    ventaServicio.NuevaVenta(venta);

#pragma warning disable CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    var completado = new Afirmacion("Felicidades!", $"Completado \nSe obtuvo de ganancias $ {_Debe}\nTipo de Pago: {detalle.TipoPago}");
#pragma warning restore CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
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
            if (!EstaPorEliminar)
            {
                if (MessageBox.Show("Este Seguro De Eliminar Este Pedido, Perdera Todos Los Datos...?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }

            pedidoServicio.Eliminar(PedidoId);

            var ListaSoloIdProductoPedido = producto_Pedido_Servicio.Eliminar(PedidoId);

            if (ListaSoloIdProductoPedido.Count() > 0)
            {
                producto_Dato_Servicio.Eliminar(ListaSoloIdProductoPedido);
            }

            MessageBox.Show("Pedido Eliminado...", "Borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            VerificarSiEstaEliminadoElPedido();

            Eliminado = true;

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
                btnRestar.Visible = false;

                ckbNormal.Visible = false;
                ckbTarjeta.Visible = false;

                btnAgregarProductos.Visible = false;
                btnVolverPedidoNoRetirado.Visible = false;

                txtNotas.Enabled = false;
                lblEliminado.Visible = true;
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

        private void btnCobro_Click(object sender, EventArgs e)
        {
            if (nudCobro.Value > 0)
            {
                if (!VerCaja())
                {
                    MessageBox.Show("Abra la Caja", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }

                if (MessageBox.Show("Esta Por Cobrar Un Adelanto, Desea Continuar?", "Adelanto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var pedido = pedidoServicio.Buscar(PedidoId);

                    //Total Cta Cte

                    var cuentaId = new CtaCteDto();

                    cuentaId = ctaCteServicio.ObtenerPorIdDePedidosId(pedido.Id);

                    ctaCteServicio.Pagar((double)nudCobro.Value, pedido.ClienteId, cuentaId.Id);

                    //caja

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = $"{lblPersona.Text} - Adelanto de Pedido",
                        Fecha = DateTime.Now.ToString(),
                        Total = (double)nudCobro.Value,
                        CajaId = detalleCajaServicio.BuscarCajaAbierta(),
                        NumeroOperacion = cuentaId.NumeroOperacion
                    };

                    TipoPago(detalle);

                    detalleCajaServicio.AgregarDetalleCaja(detalle);

                    cajaServicio.SumarDineroACaja((double)nudCobro.Value);

                    pedidoServicio.CambiarRamas((double)nudCobro.Value, PedidoId);

                    var venta = new VentaDto
                    {
                        ClienteId = pedido.ClienteId,
                        Descuento = 0,
                        Fecha = DateTime.Now,
                        Total = (double)nudCobro.Value
                    };

                    ventaServicio.NuevaVenta(venta);

#pragma warning disable CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    var completado = new Afirmacion("Felicidades!", $"Completado \nSe obtuvo de ganancias $ {nudCobro.Value}\nTipo de Pago: {detalle.TipoPago}");
#pragma warning restore CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    completado.ShowDialog();

                    nudCobro.Value = 0;

                    Datos(PedidoId);

                }
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                EntidadId = (long)dgvGrilla["Id", e.RowIndex].Value;
                EntidadParaBorrar = (long)dgvGrilla["Id", e.RowIndex].Value;
                ProductoId = (long)dgvGrilla["ProductoId", e.RowIndex].Value;

                if (!productoServicio.ObtenerPorId(ProductoId).Creacion)
                {
                    EntidadId = 0;
                }

            }
            else
            {
                EntidadId = 0;
                EntidadParaBorrar = 0;
            }
        }

        public void VerSiHayProductos()
        {
            if (dgvGrilla.RowCount == 0)
            {
                btnEliminarPedidoSeleccionado.Visible = false;
                BloquearTodo();
            }
            else
            {
                btnEliminarPedidoSeleccionado.Visible = true;
            }
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (EntidadId != 0)
            {
                if (!pedidoServicio.BuscarIDPedidos(PedidoId).EstaEliminado)
                {
                    var datos = new EstadoProducto(EntidadId);
                    datos.ShowDialog();

                    list = new List<VentaDto2>();
                    CrearGrilla(PedidoId);
                    CargarGrilla();
                }
            }
        }

        private void btnVolverPedidoNoRetirado_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro De Poner Este Pedido a no Retirado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                pedidoServicio.CambiarProcesoRetiro(PedidoId);

                Datos(PedidoId);

#pragma warning disable CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                var mensaje = new Afirmacion("Pedido Cambiado a Espera de Retiro", "Completado");
#pragma warning restore CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
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
            var pedido = new AgregarProductos(PedidoId, true);
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
                if (EntidadParaBorrar != 0)
                {
                    if (MessageBox.Show("Esta Seguro de Borrar Este Producto?\nSi Hay Mas de un Producto Se Eliminara Uno", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var pedido = producto_Pedido_Servicio.ObtenerPorId(EntidadParaBorrar);
                        var producto = productoServicio.ObtenerPorId(pedido.ProductoId);
                        var producto_pedido = producto_Pedido_Servicio.ObtenerPorId(EntidadParaBorrar);

                        double CantRestar = 0;
                        int Bandera = 0;

                        if (producto_pedido.Cantidad > 1)
                        {
                            if (producto.Creacion)
                            {
                                producto_Dato_Servicio.EliminacionDefinitiva(EntidadParaBorrar);
                            }

                            producto_Pedido_Servicio.RestarCantidad1(EntidadParaBorrar);

                            CantRestar = producto_pedido.Precio;

                            Bandera = 1;
                        }
                        else
                        {
                            if (producto.Creacion)
                            {
                                producto_Dato_Servicio.EliminacionDefinitiva(EntidadParaBorrar);
                            }

                            producto_Pedido_Servicio.EliminacionDefinitiva(EntidadParaBorrar);

                            CantRestar = (double)producto_pedido.Precio;

                            Bandera = 2;
                        }

                        pedidoServicio.RestarTotal(pedido.PedidoId, (double)CantRestar);

                        var pedidoPrincipal = pedidoServicio.BuscarIDPedidos(pedido.PedidoId);

                        if (pedidoPrincipal.Adelanto != 0)
                        {
                            if (pedidoPrincipal.Adelanto > pedidoPrincipal.Total)
                            {
                                pedidoServicio.RestarAdelanto((double)CantRestar, pedidoPrincipal.Id);
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

        public void VerSiHayProductosDespuesDeBorrar()
        {
            if (dgvGrilla.RowCount == 0)
            {
                EstaPorEliminar = true;
                SiNoHayProductos();
                btnEliminarPedidoSeleccionado.PerformClick();
            }
        }

        public void SiNoHayProductos()
        {
            if (dgvGrilla.RowCount == 0)
            {
                btnAgregarProductos.Visible = false;
                btnEliminarPedidoSeleccionado.Visible = false;
            }

        }

        public void CargaDeNuevo()
        {
            list = new List<VentaDto2>();
            CrearGrilla(PedidoId);
            CargarGrilla();

            Datos(PedidoId);
        }

        private void lblPagado_Click(object sender, EventArgs e)
        {

        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            if (nudCobro.Value > 0)
            {
                var pedido = pedidoServicio.Buscar(PedidoId);

                if ((double)nudCobro.Value > pedido.Adelanto)
                {
                    MessageBox.Show("No Se Puedo Restar Dinero, Lo Que Quiere Restar Es Mayor Al Adelanto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (MessageBox.Show("Esta Seguro De Restar Dinero A La Cuenta?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var Resto = nudCobro.Value * -1;

                    //Total Cta Cte

                    var cuentaId = ctaCteServicio.ObtenerPorIdDePedidosId(pedido.Id);

                    ctaCteServicio.SumarLoQueDebe((double)nudCobro.Value, pedido.ClienteId, cuentaId.Id);

                    //caja

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = $"{lblPersona.Text} - Dinero Devuelto",
                        Fecha = DateTime.Now.ToLongDateString(),
                        Total = (double)Resto,
                        CajaId = detalleCajaServicio.BuscarCajaAbierta()
                    };

                    TipoPago(detalle);

                    detalleCajaServicio.AgregarDetalleCaja(detalle);

                    cajaServicio.RestarDineroDeCaja((double)nudCobro.Value);

                    pedidoServicio.RestarAdelanto((double)nudCobro.Value, PedidoId);

                    MessageBox.Show("Dinero Regresado Al Cliente...", "Devuelto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    nudCobro.Value = 0;

                    Datos(PedidoId);

                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro De Imprimir?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var pd = new PrintDocument();

                var name = pd.PrinterSettings.PrinterName;

                ticketServicio.ImprimirAutomaticamentePedido(detalleCajaServicio.BuscarDetalleConPedidoId(PedidoId).Id, name, _PedidoDto.ClienteId, PedidoId);
            }
        }
    }
}
