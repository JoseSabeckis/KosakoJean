using Presentacion.Clases;
using Presentacion.Core.Mensaje;
using Presentacion.Core.Producto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.DetalleCaja;
using Servicios.Core.Image.Dto;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Pedido;
using Servicios.Core.Pedido.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
using Servicios.Core.Producto_Dato;
using Servicios.Core.Producto_Dato.Dto;
using Servicios.Core.Producto_Pedido;
using Servicios.Core.Producto_Pedido.Dto;
using Servicios.Core.Producto_Venta;
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

namespace Presentacion.Core.Cobro
{
    public partial class AgregarProductos : FormularioBase
    {
        private readonly IProductoServicio productoServicio;
        private readonly IProducto_Pedido_Servicio producto_Pedido_Servicio;
        private readonly IProducto_Venta_Servicio producto_vent;
        private readonly IVentaServicio ventaServicio;
        private readonly IDetalleCajaServicio detalleCajaServicio;
        private readonly ICajaServicio cajaServicio;
        private readonly IClienteServicio clienteServicio;
        private readonly ITalleServicio talleServicio;
        private readonly IPedidoServicio pedidoServicio;
        private readonly IProducto_Dato_Servicio producto_Dato_Servicio;

        ProductoDto producto;
        PedidoDto _Pedido;
        List<VentaDto2> ListaVenta;
        VentaDto ventaDto;

        long _PedidoId;
        long _productoId;
        long _clienteId;
        decimal _total;
        string _descripcionProducto;

        public bool Bandera;

        public AgregarProductos(long pedidoId)
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();
            producto_vent = new Producto_Venta_Servicio();
            ventaServicio = new VentaServicio();
            detalleCajaServicio = new DetalleCajaServicio();
            cajaServicio = new CajaServicio();
            clienteServicio = new ClienteServicio();
            talleServicio = new TalleServicio();
            pedidoServicio = new PedidoServicio();
            producto_Dato_Servicio = new Producto_Dato_Servicio();
            producto_Pedido_Servicio = new Producto_Pedido_Servicio();

            producto = new ProductoDto();
            ListaVenta = new List<VentaDto2>();
            ventaDto = new VentaDto();

            _PedidoId = pedidoId;
            _Pedido = pedidoServicio.BuscarIDPedidos(pedidoId);
            Bandera = false;

            CargarTalle();
            CargarDatos();
            CargarGrilla(ListaVenta);

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgProductos.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Productos);
        }

        public void CargarTalle()
        {
            CargarComboBox(cmbTalle, talleServicio.Buscar(string.Empty), "Descripcion", "Id");
        }

        private void CargarDatos()
        {
            txtPedidoDueno.Text = $"{_Pedido.Apellido} {_Pedido.Nombre}";
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

        public void Limpiar()
        {
            txtProducto.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            _productoId = 0;

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtProducto.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            nudTotal.Value = 0;

            _total = 0;

            _productoId = 0;
            _clienteId = 0;

            ListaVenta = new List<VentaDto2>();
            ventaDto = new VentaDto();

            CargarGrilla(ListaVenta);
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _descripcionProducto = (string)dgvGrilla["Descripcion", e.RowIndex].Value;
            }
        }

        public void CargarGrilla(List<VentaDto2> producto)
        {
            dgvGrilla.DataSource = ListaVenta.ToList();
            FormatearGrilla(dgvGrilla);
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
                        Id = _productoId,
                        Fecha = DateTime.Now.Date,
                        ProductoId = _productoId
                    };

                    ListaVenta.Add(nuevo);

                    CargarGrilla(ListaVenta);

                    Total();
                }

                Limpiar();

                btnSeleccionProducto.Select();
            }
            else
            {
                MessageBox.Show("Cargue un Producto Antes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                if (MessageBox.Show("Esta Seguro de Agregar Productos a Este Pedido?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProductoDto producto = new ProductoDto();

                    string segunda = string.Empty;
                    decimal total = 0;

                    foreach (var item in ListaVenta)
                    {
                        producto = productoServicio.ObtenerPorId(item.Id);

                        segunda += " " + producto.Descripcion + " ";

                        //stock
                        productoServicio.BajarStock(producto.Id, item.Cantidad);

                        total += producto.Precio * item.Cantidad;
                    }

                    pedidoServicio.SumarTotal(_PedidoId, total);//sumar el total del pedido

                    foreach (var item in ListaVenta)
                    {

                        var aux = new Producto_Pedido_Dto
                        {
                            Cantidad = item.Cantidad,
                            ProductoId = productoServicio.ObtenerPorId(item.Id).Id,
                            Estado = AccesoDatos.EstadoPedido.Esperando,
                            Talle = item.Talle,
                            PedidoId = _PedidoId,
                            Descripcion = segunda,
                            TalleId = talleServicio.BuscarNombreDevuelveId(item.Talle)
                        };

                        var _Id_Pedido = producto_Pedido_Servicio.NuevoProductoPedido(aux);

                        if (_Pedido.Proceso != AccesoDatos.Proceso.Guardado || _Pedido.Proceso != AccesoDatos.Proceso.Retirado)
                        {
                            //datos
                            if (productoServicio.ObtenerPorId(item.Id).Creacion)
                            {
                                for (int i = 0; i < item.Cantidad; i++)
                                {
                                    var dato = new Producto_Dato_Dto
                                    {
                                        EstadoPorPedido = AccesoDatos.EstadoPorPedido.EnEspera,
                                        Producto_PedidoId = _Id_Pedido
                                    };

                                    producto_Dato_Servicio.Insertar(dato);
                                }
                            }
                        }
                        
                    }

                    Bandera = true;

                    var mensaje = new Afirmacion("Guardado", "Se Agregaron Productos");
                    mensaje.ShowDialog();

                    btnVolver.PerformClick();
                }
            }           
        }

        private void AgregarProductos_Load(object sender, EventArgs e)
        {
            btnSeleccionProducto.Select();
        }
    }
}
