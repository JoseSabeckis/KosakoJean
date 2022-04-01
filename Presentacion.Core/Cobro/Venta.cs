using Presentacion.Clases;
using Presentacion.Core.Cliente;
using Presentacion.Core.CtaCte;
using Presentacion.Core.Factura;
using Presentacion.Core.Mensaje;
using Presentacion.Core.Producto;
using Presentacion.Core.Talle;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.Fecha;
using Servicios.Core.ParteVenta;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
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

namespace Presentacion.Core.Cobro
{
    public partial class Venta : Form
    {
        private readonly IProductoServicio productoServicio;
        private readonly IProducto_Venta_Servicio producto_vent;
        private readonly IVentaServicio ventaServicio;
        private readonly IDetalleCajaServicio detalleCajaServicio;
        private readonly ICajaServicio cajaServicio;
        private readonly IClienteServicio clienteServicio;
        private readonly ITalleServicio talleServicio;

        ProductoDto producto;
        long _productoId;
        long _clienteId;

        string _descripcionProducto;

        List<VentaDto2> ListaVenta;
        List<Producto_Venta_Dto> ListaCtaCte;
        VentaDto ventaDto;

        decimal _total;

        public Venta()
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();
            producto_vent = new Producto_Venta_Servicio();
            ventaServicio = new VentaServicio();
            producto = new ProductoDto();
            detalleCajaServicio = new DetalleCajaServicio();
            cajaServicio = new CajaServicio();
            clienteServicio = new ClienteServicio();
            talleServicio = new TalleServicio();

            CargarTalle();

            ListaVenta = new List<VentaDto2>();
            ListaCtaCte = new List<Producto_Venta_Dto>();
            ventaDto = new VentaDto();

            ConsumidorFinall();

            CargarGrilla(ListaVenta);

            btnSeleccionProducto.Select();
        }

        public void CargarTalle()
        {
            CargarComboBox(cmbTalle, talleServicio.Buscar(string.Empty), "Descripcion", "Id");
        }

        public void CargarComboBox(ComboBox cmb, object datos, string propiedadMostrar,
            string propiedadDevolver)
        {
            cmb.DataSource = datos;
            cmb.DisplayMember = propiedadMostrar;
            cmb.ValueMember = propiedadDevolver;
        }

        public void ConsumidorFinall()
        {
            var consumer = clienteServicio.ObtenerPorId(1);

            txtCliente.Text = "Consumidor Final";

            _clienteId = consumer.Id;
            ventaDto.ClienteId = consumer.Id;

            ckbNormal.Checked = true;

            VerificarSiEsValidoCtaCte(_clienteId);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccionProducto_Click(object sender, EventArgs e)
        {
            var seleccionar = new ElegirProducto();
            seleccionar.ShowDialog();

            if (seleccionar._codigo != 0)
            {
                var product = productoServicio.ObtenerPorId(seleccionar._codigo);

                producto = product;

                _productoId = product.Id;
                txtProducto.Text = producto.Descripcion;


                nudPrecio.Value = product.Precio;

                btnAgregarAlaGrilla.Select();
            }

        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProducto.Text))
            {
                nudPrecio.Value = producto.Precio;
            }
            else
            {
                producto = null;
            }
        }

        public void CargarGrilla(List<VentaDto2> producto)
        {
            dgvGrilla.DataSource = ListaVenta.ToList();
            FormatearGrilla(dgvGrilla);
        }

        private void btnAgregarAlaGrilla_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProducto.Text))
            {
                var prueba = ListaVenta.FirstOrDefault(x => x.Descripcion == txtProducto.Text && x.Talle == cmbTalle.Text);

                if (nudPrecio.Value == 0)
                {
                    if (MessageBox.Show("El Precio Sera Cero Esta Seguro de Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        btnAgregarAlaGrilla.Select();
                        return;
                    }
                }                

                if (prueba != null)
                {
                    prueba.Cantidad += nudCantidad.Value;

                    CargarGrilla(ListaVenta);

                    Total();
                }
                else
                {

                    var nuevo = new VentaDto2
                    {

                        Cantidad = nudCantidad.Value,
                        Descripcion = txtProducto.Text,
                        Precio = nudPrecio.Value,
                        Talle = cmbTalle.Text,
                        Id = _productoId,
                        Fecha = DateTime.Now.Date,
                        ProductoId = _productoId
                    };

                    ListaVenta.Add(nuevo);

                    CargarGrilla(ListaVenta);

                    Total();
                }

                Limpiar();                
            }
            else
            {
                MessageBox.Show("Cargue un Producto Antes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnSeleccionProducto.Select();
        }

        public void Total()
        {
            decimal total = 0;

            decimal precio = 0;

            foreach (var item in ListaVenta)
            {
                foreach (var producto in productoServicio.Buscar(string.Empty))
                {
                    if (item.Descripcion == producto.Descripcion)
                    {
                        precio += item.Cantidad * item.Precio;
                    }
                    else
                    {
                        if (producto.Descripcion == item.Descripcion)
                        {
                            precio += item.Precio;
                        }
                        
                    }

                }
            }

            total = precio;
            _total = precio;

            nudTotal.Value = total;
            nudTotalVenta.Value = total;
        }

        public void Limpiar()
        {
            txtProducto.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            _productoId = 0;

            txtVuelto.Text = string.Empty;
            nudPagaron.Value = 0;
            nudTotalVenta.Value = 0;

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtProducto.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            nudTotal.Value = 0;
            txtVuelto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            nudPagaron.Value = 0;

            _total = 0;

            _productoId = 0;
            _clienteId = 0;

            ListaVenta = new List<VentaDto2>();
            ListaCtaCte = new List<Producto_Venta_Dto>();
            ventaDto = new VentaDto();

            ConsumidorFinall();

            CargarGrilla(ListaVenta);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (nudPagaron.Value > 0 && nudTotalVenta.Value > 0)
            {                   
                 var pago = nudPagaron.Value - nudTotalVenta.Value;

                 txtVuelto.Text = $" $ {pago}";
            }
            else
            {
                MessageBox.Show("Cargue el Dinero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void VerTicket(List<VentaDto2> Lista)
        {
            //ticket

            var fecha = new FechaDto
            {
                Fecha = DateTime.Now.ToShortDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };

            var factura = new Comprobante(ListaVenta.ToList(), fecha);
            factura.ShowDialog();
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {

            if (dgvGrilla.RowCount > 0)
            {
                if (ckbTarjeta.Checked == false && ckbPedido.Checked == false && ckbNormal.Checked == false && ckbCtaCte.Checked == false && ckbGuardar.Checked == false)
                {
                    MessageBox.Show("Seleccione el Tipo de Pago, Tarjeta, Contado, Pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (ckbNormal.Checked || ckbTarjeta.Checked)
                {
                    if (MessageBox.Show("Esta Seguro de Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        if (ventaDto.ClienteId == 0)
                        {
                            ventaDto.ClienteId = 0;
                        }

                        ventaDto.Fecha = DateTime.Now;
                        ventaDto.Total = _total;                           
                        

                        var ventaId = ventaServicio.NuevaVenta(ventaDto);

                        string descripcion = string.Empty;

                        foreach (var item in ListaVenta)
                        {
                            var producto = productoServicio.ObtenerPorId(item.Id);

                            var producto_venta = new Producto_Venta_Dto
                            {
                                Cantidad = item.Cantidad,
                                Descripcion = item.Descripcion,
                                Estado = AccesoDatos.EstadoPedido.Terminado,
                                ProductoId = item.Id,
                                Talle = item.Talle,
                                Precio = item.Precio * item.Cantidad,
                                VentaId = ventaId,
                                TalleId = ((TalleDto)cmbTalle.SelectedItem).Id
                            };

                            // descontar stock
                            productoServicio.BajarStock(producto.Id, item.Cantidad);                          
                            //

                            descripcion = $"{descripcion} - {producto_venta.Descripcion}";

                            producto_vent.NuevoProductoVenta(producto_venta);
                        }

                        var detalle = new DetalleCajaDto
                        {
                            Fecha = DateTime.Now.ToLongDateString(),
                            Total = _total,
                            Descripcion = $"Venta {descripcion}",
                            CajaId = detalleCajaServicio.BuscarCajaAbierta(),
                        };

                        TipoPago(detalle);

                        detalleCajaServicio.AgregarDetalleCaja(detalle);

                        cajaServicio.SumarDineroACaja(_total);

                        //MessageBox.Show("Felicidades, Cobro Aceptado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var mensaje = new Afirmacion("Genial", $"Cobro Aceptado!\n\nGanancia: $ {_total}\n{detalle.TipoPago}");
                        mensaje.ShowDialog();

                        foreach (var item in ListaVenta)
                        {
                            item.Precio = item.Cantidad * item.Precio;
                        }


                        if (ckbTicket.Checked)
                        {
                            VerTicket(ListaVenta.ToList());
                        }                                              

                        //limpiar
                        btnLimpiar.PerformClick();                      

                    }

                }
                else
                {
                    if (ckbPedido.Checked)
                    {
                        var pedidos = new Pedido.Pedido(ListaVenta, _total, ventaServicio.ObtenerClienteName(ventaDto.ClienteId), _clienteId, txtDescripcion.Text);
                        pedidos.ShowDialog();

                        if (pedidos.semaforo)
                        {
                            if (ckbTicket.Checked)
                            {
                                VerTicket(ListaVenta.ToList());
                            }

                            btnLimpiar.PerformClick();
                        }
                    }

                    if (ckbCtaCte.Checked || ckbGuardar.Checked)
                    {

                        foreach (var item in ListaVenta)
                        {
                            var producto = productoServicio.ObtenerPorId(item.Id);

                            var producto_venta = new Producto_Venta_Dto
                            {
                                Cantidad = item.Cantidad,
                                Descripcion = item.Descripcion,
                                Estado = AccesoDatos.EstadoPedido.Terminado,
                                ProductoId = item.Id,
                                Talle = item.Talle,
                                Precio = item.Precio * item.Cantidad,
                                VentaId = 0,
                                TalleId = ((TalleDto)cmbTalle.SelectedItem).Id
                            };

                            ListaCtaCte.Add(producto_venta);
                        }

                        var cuenta = new CtaCteClientePedido(_clienteId, _total, ListaCtaCte, ListaVenta);
                        cuenta.ShowDialog();

                        if (cuenta.semaforo)
                        {
                            if (ckbTicket.Checked)
                            {
                                VerTicket(ListaVenta.ToList());
                            }

                            btnLimpiar.PerformClick();
                        }

                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Cargue la Grilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            btnSeleccionProducto.Select();
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
            if (dgvGrilla.RowCount > 0)
            {
                var lista = ListaVenta.FirstOrDefault(x => x.Descripcion == _descripcionProducto);

                ListaVenta.Remove(lista);

                CargarGrilla(ListaVenta);

                Total();
            }
            else
            {
                var error = new Negativo("Error...", "No Hay Nada Para Eliminar");
                error.ShowDialog();
                //MessageBox.Show("No Hay Nada Para Eliminar...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _descripcionProducto = (string)dgvGrilla["Descripcion", e.RowIndex].Value;

            }
        }

        private void ckbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNormal.Checked)
            {
                ckbPedido.Checked = false;
                ckbTarjeta.Checked = false;
                ckbCtaCte.Checked = false;
                ckbGuardar.Checked = false;

                ckbTicket.Checked = true;
                ckbTicket.Enabled = true;
            }
        }

        private void ckbPedido_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPedido.Checked)
            {
                ckbNormal.Checked = false;
                ckbTarjeta.Checked = false;
                ckbCtaCte.Checked = false;
                ckbGuardar.Checked = false;

                ckbTicket.Checked = false;
                //ckbTicket.Enabled = false;
            }
        }

        private void ckbCtaCte_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarAlaGrilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnAgregarAlaGrilla.PerformClick();
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            var seleccionar = new ElegirCliente();
            seleccionar.ShowDialog();

            if (seleccionar._codigo != 0)
            {
                var aux = clienteServicio.ObtenerPorId(seleccionar._codigo);

                _clienteId = aux.Id;
                txtCliente.Text = aux.Apellido + " " + aux.Nombre;

                ventaDto.ClienteId = _clienteId;

                VerificarSiEsValidoCtaCte(_clienteId);
            }

        }

        public void VerificarSiEsValidoCtaCte(long clienteId)
        {
            if (clienteId == 1)
            {
                ckbCtaCte.Visible = false;
            }
            else
            {
                ckbCtaCte.Visible = true;
            }
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            
        }

        public void CargarConsumidorFinal()
        {
            if (clienteServicio.Buscar("Consumidor Final").Count() == 0)
            {
                var confumidor = new ClienteDto
                {
                    Apellido = "Consumidor Final",
                    Foto = ImagenDb.Convertir_Imagen_Bytes(Imagen.Usuario),
                    Nombre = "",
                    Direccion = "",
                    Telefono = ""
                };

                clienteServicio.Nuevo(confumidor);
            }
        }

        private void btnNewCliente_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente_Abm(TipoOperacion.Nuevo);
            cliente.ShowDialog();
        }

        private void nudPagaron_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void ckbContado_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ckbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTarjeta.Checked)
            {
                ckbNormal.Checked = false;
                ckbPedido.Checked = false;
                ckbCtaCte.Checked = false;
                ckbGuardar.Checked = false;

                ckbTicket.Checked = true;
                ckbTicket.Enabled = true;
            }
        }

        private void ckbTarjeta_AppearanceChanged(object sender, EventArgs e)
        {

        }

        private void btnSeleccionProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                btnCobrar.PerformClick();
            }
        }

        private void ckbCtaCte_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ckbCtaCte.Checked)
            {
                ckbNormal.Checked = false;
                ckbPedido.Checked = false;
                ckbTarjeta.Checked = false;
                ckbGuardar.Checked = false;

                ckbTicket.Checked = false;
                //ckbTicket.Enabled = false;
            }
        }

        private void btnNuevoTalle_Click(object sender, EventArgs e)
        {
            var verTalle = new Talle_Abm(TipoOperacion.Nuevo);
            verTalle.ShowDialog();

            CargarTalle();
        }

        private void ckbGuardar_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbGuardar.Checked)
            {
                ckbNormal.Checked = false;
                ckbPedido.Checked = false;
                ckbTarjeta.Checked = false;
                ckbCtaCte.Checked = false;

                ckbTicket.Checked = false;
                //ckbTicket.Enabled = false;
            }
        }

        private void Venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
