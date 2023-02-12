using Presentacion.Clases;
using Presentacion.Core.Mensaje;
using Presentacion.Core.Producto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.CtaCte;
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
using System.Linq;
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
        private readonly ICtaCteServicio ctaCteServicio;

        ProductoDto producto;
        PedidoDto _Pedido;
        List<VentaDto2> ListaVenta;
        VentaDto ventaDto;

        long _PedidoId;
        long _productoId;
#pragma warning disable CS0414 // El campo 'AgregarProductos._clienteId' está asignado pero su valor nunca se usa
        long _clienteId;
#pragma warning restore CS0414 // El campo 'AgregarProductos._clienteId' está asignado pero su valor nunca se usa
        double _total;
        string _descripcionProducto;
        string _colegio;
        string _talle;
        double _precio;

        public bool Bandera;
        bool _Semaforo = false;

        public AgregarProductos(long pedidoId, bool semaforo)
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
            ctaCteServicio = new CtaCteServicio();

            producto = new ProductoDto();
            ListaVenta = new List<VentaDto2>();
            ventaDto = new VentaDto();

            _Semaforo = semaforo;

            _PedidoId = pedidoId;
            _Pedido = pedidoServicio.BuscarIDPedidos(pedidoId);
            _clienteId = _Pedido.ClienteId;
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

        public void InabilitarButton(Button btn)
        {
            if (btn.Enabled)
            {
                btn.Enabled = false;
            }
            else
            {
                btn.Enabled = true;
            }
        }

        private void btnSeleccionProducto_Click(object sender, EventArgs e)
        {
            InabilitarButton(btnSeleccionProducto);

            var seleccionar = new ElegirProducto();
            seleccionar.ShowDialog();

            InabilitarButton(btnSeleccionProducto);

            if (seleccionar._codigo != 0)
            {
                var product = productoServicio.ObtenerPorId(seleccionar._codigo);

                producto = product;

                _productoId = product.Id;
                txtProducto.Text = producto.Descripcion;
                txtColegio.Text = product.Colegio;

                nudPrecio.Value = (decimal)product.Precio;

                btnAgregarAlaGrilla.Select();
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            /*
            if (!string.IsNullOrEmpty(txtProducto.Text))
            {
                nudPrecio.Value = producto.Precio;
            }
            else
            {
                producto = null;
            }
            */
        }

        public void Limpiar()
        {
            txtProducto.Text = string.Empty;
            txtColegio.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            _productoId = 0;
            cmbTalle.SelectedIndex = 0;
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

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtProducto.Text = string.Empty;
            txtColegio.Text = string.Empty;
            nudCantidad.Value = 1;
            nudPrecio.Value = 0;

            nudTotal.Value = 0;

            _total = 0;

            _productoId = 0;
            _clienteId = 0;

            cmbTalle.SelectedIndex = 0;

            ListaVenta = new List<VentaDto2>();
            ventaDto = new VentaDto();

            CargarGrilla(ListaVenta);
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _descripcionProducto = (string)dgvGrilla["Descripcion", e.RowIndex].Value;
                _colegio = (string)dgvGrilla["Colegio", e.RowIndex].Value;
                _talle = (string)dgvGrilla["Talle", e.RowIndex].Value;
                _precio = (double)dgvGrilla["Precio", e.RowIndex].Value;
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
                var lista = ListaVenta.FirstOrDefault(x => x.Descripcion == _descripcionProducto && x.Colegio == _colegio && x.Talle == _talle && x.Precio == _precio);

                if (lista.Cantidad > 1)
                {
                    lista.Cantidad -= 1;
                }
                else
                {
                    ListaVenta.Remove(lista);
                }

                CargarGrilla(ListaVenta);

                Total();
            }
            else
            {
#pragma warning disable CS0436 // El tipo 'Negativo' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Negativo.cs' está en conflicto con el tipo importado 'Negativo' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Negativo.cs'.
                var error = new Negativo("Error...", "No Hay Nada Para Eliminar");
#pragma warning restore CS0436 // El tipo 'Negativo' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Negativo.cs' está en conflicto con el tipo importado 'Negativo' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Negativo.cs'.
                error.ShowDialog();
            }
        }

        public void Total()
        {
            double total = 0;

            double precio = 0;

            foreach (var item in ListaVenta)
            {
                foreach (var producto in productoServicio.Buscar(string.Empty))
                {
                    if (item.Descripcion == producto.Descripcion && item.Colegio == producto.Colegio)
                    {
                        precio += item.Cantidad * item.Precio;
                    }
                }
            }

            total = precio;
            _total = precio;

            nudTotal.Value = (decimal)total;
        }

        private void btnAgregarAlaGrilla_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProducto.Text))
            {
                var prueba = ListaVenta.FirstOrDefault(x => x.Descripcion == txtProducto.Text && x.Talle == cmbTalle.Text && x.Precio == (double)nudPrecio.Value && x.Colegio == txtColegio.Text);

                if (nudPrecio.Value == 0)
                {
                    MessageBox.Show("El Precio No Puede Ser Cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (prueba != null)
                {
                    prueba.Cantidad += (double)nudCantidad.Value;

                    CargarGrilla(ListaVenta);

                    Total();
                }
                else
                {

                    var nuevo = new VentaDto2
                    {
                        Cantidad = (double)nudCantidad.Value,
                        Descripcion = txtProducto.Text,
                        Precio = (double)nudPrecio.Value,
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
            if (dgvGrilla.RowCount > 0)
            {
                if (!VerCaja())
                {
                    MessageBox.Show("Abra la Caja", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }

                if (MessageBox.Show("Esta Seguro de Agregar Productos a Este Pedido?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProductoDto producto = new ProductoDto();

                    string segunda = string.Empty;
                    double total = 0;

                    foreach (var item in ListaVenta)
                    {
                        producto = productoServicio.ObtenerPorId(item.Id);

                        segunda += " " + producto.Descripcion + " ";

                        //stock
                        productoServicio.BajarStock(producto.Id, (decimal)item.Cantidad);

                        total += item.Precio * item.Cantidad;
                    }

                    pedidoServicio.SumarTotal(_PedidoId, total);//sumar el total del pedido

                    foreach (var item in ListaVenta)
                    {

                        var aux = new Producto_Pedido_Dto
                        {
                            Cantidad = (decimal)item.Cantidad,
                            ProductoId = productoServicio.ObtenerPorId(item.Id).Id,
                            Estado = AccesoDatos.EstadoPedido.Esperando,
                            Talle = item.Talle,
                            PedidoId = _PedidoId,
                            Descripcion = segunda,
                            TalleId = talleServicio.BuscarNombreDevuelveId(item.Talle),
                            Precio = item.Precio
                        };

                        var _Id_Pedido = producto_Pedido_Servicio.NuevoProductoPedido(aux);

                        if (_Pedido.Proceso != AccesoDatos.Proceso.Guardado || _Pedido.Proceso != AccesoDatos.Proceso.Retirado)
                        {
                            if (_Semaforo)
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

                        var ctacte = ctaCteServicio.ObtenerPorIdDePedidosId(_PedidoId);

                        ctaCteServicio.SumarLoQueDebe(total, _clienteId, ctacte.Id);

                    }

                    Bandera = true;

#pragma warning disable CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    var mensaje = new Afirmacion("Guardado", "Se Agregaron Productos");
#pragma warning restore CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    mensaje.ShowDialog();

                    btnVolver.PerformClick();
                }
            }
        }

        private void AgregarProductos_Load(object sender, EventArgs e)
        {
            btnSeleccionProducto.Select();
        }

        private void AgregarProductos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                btnAgregarAlaGrilla.PerformClick();

            }

            if (e.KeyChar == (char)Keys.Escape)
            {
                btnTerminar.PerformClick();
            }

        }
    }
}
