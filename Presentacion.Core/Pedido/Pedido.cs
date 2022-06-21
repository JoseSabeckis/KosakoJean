using Presentacion.Clases;
using Presentacion.Core.Factura;
using Presentacion.Core.Mensaje;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.CtaCte;
using Servicios.Core.CtaCte.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.DetalleProducto;
using Servicios.Core.Fecha;
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
using Servicios.Core.Talle;
using Servicios.Core.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IProducto_Dato_Servicio producto_Dato_Servicio;
        private readonly IDetalleProductoServicio detalleProductoServicio;

        public bool semaforo = false;

        decimal _total;
        long ClienteId;

        ClienteDto _Cliente;
        List<VentaDto2> ListaVentas;

        public Pedido(List<VentaDto2> Lista, decimal total, string nombre, long clienteId, string descripcion)
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
            producto_Dato_Servicio = new Producto_Dato_Servicio();
            detalleProductoServicio = new DetalleProductoServicio();

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

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgPedido.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Pedido_Venta);
        }

        public bool AsignarControles()
        {
            if (txtApellido.Text == string.Empty)
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
                        Horario = cmbHorario.Text,
                        DiasHastaRetiro = null
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
                            TalleId = talleServicio.BuscarNombreDevuelveId(item.Talle),
                            Precio = item.Precio
                        };

                        var _Id_Pedido = producto_Pedido_Servicio.NuevoProductoPedido(aux);

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

                    var cuenta = new CtaCteDto
                    {
                        ClienteId = ClienteId,
                        Estado = AccesoDatos.CtaCteEstado.EnEspera,
                        Fecha = dtpFechaEntrega.Value,
                        Total = _total,
                        Debe = _total - nudAdelanto.Value,
                        Descripcion = $"{segunda}",
                        PedidoId = pedidoId
                    };

                    ctaCteServicio.Agregar(cuenta);


                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = txtApellido.Text + " " + txtNombre.Text + " - " + segunda,
                        Fecha = DateTime.Now.ToLongDateString(),
                        Total = nudAdelanto.Value,
                        CajaId = detallCajaServicio.BuscarCajaAbierta()
                    };

                    TipoPago(detalle);

                    var detalleCajaId = detallCajaServicio.AgregarDetalleCaja(detalle);

                    //detalle producto
                    foreach (var item in ListaVentas)
                    {
                        item.DetalleCajaId = detalleCajaId;
                    }

                    foreach (var item in ListaVentas)
                    {
                        detalleProductoServicio.Insertar(item);
                    }

                    //

                    //dinero a caja
                    cajaServicio.SumarDineroACaja(nudAdelanto.Value);//

#pragma warning disable CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    var mensaje = new Afirmacion("Agregado a la Cuenta!", $"Dinero Cobrado Por Adelanto $ {nudAdelanto.Value}\nTipo de Pago: {detalle.TipoPago}");
#pragma warning restore CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
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
#pragma warning disable CS0436 // El tipo 'Negativo' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Negativo.cs' está en conflicto con el tipo importado 'Negativo' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Negativo.cs'.
                var mens = new Negativo("Error", "Apellido y Nombre \nno puede estar vacio");
#pragma warning restore CS0436 // El tipo 'Negativo' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Negativo.cs' está en conflicto con el tipo importado 'Negativo' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Negativo.cs'.
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

        private void ckbSinNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSinNombre.Checked)
            {
                txtApellido.Text = "Sin Nombre";
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnCargar.PerformClick();
            }
        }
    }
}
