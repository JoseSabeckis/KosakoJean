using Presentacion.Core.Cobro;
using Presentacion.Core.Mensaje;
using Servicios.Core.Caja;
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
using Servicios.Core.Talle;
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

        public bool semaforo = false;

        public string _Descripcion;
        decimal _total;
        long ClienteId;
        long _TalleId;

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

            if (nombre != null)
            {
                txtApellido.Text = nombre;
            }

            _total = total;
            ListaVentas = Lista;
            _Descripcion = descripcion;
            _TalleId = talleId;

            nudAdelanto.Maximum = _total;

            ClienteId = clienteId;

            if (clienteId != 0)
            {
                txtApellido.Enabled = false;
            }
        }

        public bool AsignarControles()
        {
            if (txtApellido.Text == string.Empty)
            {
                return false;
            }
            /*
            if (txtNombre.Text == string.Empty)
            {
                return false;
            }
            */
            return true;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (AsignarControles())
            {
                if (ckbCtaCte.Checked == true)
                {
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
                            Descripcion = _Descripcion

                        };

                        var pedidoId = pedidoServicio.NuevoPedido(pedido);

                        string descripcion = string.Empty;

                        string segunda = string.Empty;

                        foreach (var item in ListaVentas)
                        {
                            descripcion = productoServicio.ObtenerPorId(item.Id).Descripcion;

                            segunda += " " + descripcion + " ";

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

                        var cuenta = new CtaCteDto
                        {
                            ClienteId = ClienteId,
                            Estado = AccesoDatos.CtaCteEstado.EnEspera,
                            Fecha = dtpFechaEntrega.Value.Date,
                            Total = _total,
                            Debe = _total - nudAdelanto.Value,
                            Descripcion = $"{segunda}"
                        };

                        ctaCteServicio.Agregar(cuenta);

                        var detalle = new DetalleCajaDto
                        {
                            Descripcion = txtApellido.Text + " " + txtNombre.Text + " - " + segunda,
                            Fecha = DateTime.Now,
                            Total = nudAdelanto.Value,
                            CajaId = detallCajaServicio.BuscarCajaAbierta()
                        };

                        detallCajaServicio.AgregarDetalleCaja(detalle);

                        //dinero a caja
                        cajaServicio.SumarDineroACaja(nudAdelanto.Value);

                        var mensaje = new Afirmacion("Agregado a la Cuenta!", $"Dinero Cobrado Por Adelanto $ {nudAdelanto.Value}");
                        mensaje.ShowDialog();

                        semaforo = true;

                        this.Close();

                        return;
                    }
                }
                

                if (MessageBox.Show("Esta Seguro de Continuar?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
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
                        Descripcion = _Descripcion,
                        
                    };

                    var pedidoId = pedidoServicio.NuevoPedido(pedido);

                    string descripcion = string.Empty;

                    string segunda = string.Empty;

                    foreach (var item in ListaVentas)
                    {
                        descripcion = productoServicio.ObtenerPorId(item.Id).Descripcion;

                        segunda += " " + descripcion + " ";

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

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion =  txtApellido.Text + " " + txtNombre.Text + " - " + segunda,
                        Fecha = DateTime.Now,
                        Total = nudAdelanto.Value,
                        CajaId = detallCajaServicio.BuscarCajaAbierta()
                    };

                    detallCajaServicio.AgregarDetalleCaja(detalle);

                    //dinero a caja
                    cajaServicio.SumarDineroACaja(nudAdelanto.Value);

                    var mensaje = new Afirmacion("Pedido Creado!", "Quedara Bien Gracias!");
                    mensaje.ShowDialog();

                    //MessageBox.Show("Listo Pedido Creado!", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    semaforo = true;

                    this.Close();

                }

            }
            else
            {
                var mens = new Negativo("Error", "El Campo Apellido y Nombre no puede estar vacio");
                mens.ShowDialog();
                //MessageBox.Show("El Campo Apellido y Nombre no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNormal.Checked == true)
            {
                ckbCtaCte.Checked = false;
            }
            else
            {
                ckbCtaCte.Checked = true;
            }
        }

        private void ckbCtaCte_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCtaCte.Checked == true)
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
