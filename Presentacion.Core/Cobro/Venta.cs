using Presentacion.Clases;
using Presentacion.Core.Cliente;
using Presentacion.Core.Mensaje;
using Presentacion.Core.Producto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
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

            CargarComboBox(cmbTalle, talleServicio.Buscar(string.Empty), "Descripcion", "Id");

            ListaVenta = new List<VentaDto2>();
            ventaDto = new VentaDto();

            ConsumidorFinall();

            CargarGrilla(ListaVenta);

            
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
                    MessageBox.Show("El Precio No Puede Ser Cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
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
                        Id = _productoId

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
        }

        public void Limpiar()
        {
            txtProducto.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            _productoId = 0;

            txtVuelto.Text = string.Empty;
            nudPagaron.Value = 0;

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
            ventaDto = new VentaDto();

            ConsumidorFinall();

            CargarGrilla(ListaVenta);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (nudPagaron.Value > 0)
            {
                if (nudTotal.Value != 0)
                {                   

                    var pago = nudPagaron.Value - _total;

                    txtVuelto.Text = $" $ {pago}";
                }
            }
            else
            {
                MessageBox.Show("Cargue el Dinero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {

            if (dgvGrilla.RowCount > 0)
            {
                if (ckbNormal.Checked)
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

                            descripcion = $"{descripcion} - {producto_venta.Descripcion}";

                            producto_vent.NuevoProductoVenta(producto_venta);
                        }

                        var detalle = new DetalleCajaDto
                        {
                            Fecha = DateTime.Now,
                            Total = _total,
                            Descripcion = $"Venta {descripcion}",
                            CajaId = detalleCajaServicio.BuscarCajaAbierta()
                        };

                        detalleCajaServicio.AgregarDetalleCaja(detalle);

                        cajaServicio.SumarDineroACaja(_total);

                        //MessageBox.Show("Felicidades, Cobro Aceptado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var mensaje = new Afirmacion("Felicidades...", "Cobro Aceptado!");
                        mensaje.ShowDialog();

                        btnLimpiar.PerformClick();

                    }

                }
                else
                {
                    if (txtCliente.Text == "Consumidor Final")
                    {
                        var pedis = new Negativo("Error ...", "No Puede Cobrar a un Consumidor Final");
                        pedis.ShowDialog();

                        return;
                    }

                    var pedidos = new Pedido.Pedido(ListaVenta, _total, ventaServicio.ObtenerClienteName(ventaDto.ClienteId), _clienteId, txtDescripcion.Text, ((TalleDto)cmbTalle.SelectedItem).Id);
                    pedidos.ShowDialog();


                    if (pedidos.semaforo)
                    {
                        btnLimpiar.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Cargue la Grilla", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (ckbNormal.Checked == true)
            {
                ckbPedido.Checked = false;
            }
            else
            {
                ckbPedido.Checked = true;
            }
        }

        private void ckbPedido_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPedido.Checked == true)
            {
                ckbNormal.Checked = false;
            }
            else
            {
                ckbNormal.Checked = true;
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

                PedidoEnabled();
            }

        }

        private void Venta_Load(object sender, EventArgs e)
        {
            PedidoEnabled();
        }

        public void PedidoEnabled()
        {
            if (txtCliente.Text == "Consumidor Final" || _clienteId == 1)
            {

                ckbPedido.Enabled = false;
                ckbPedido.Checked = false;

            }
            else
            {
                ckbPedido.Enabled = true;
                ckbPedido.Checked = true;
            }
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
    }
}
