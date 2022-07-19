﻿using Presentacion.Core.Cliente;
using Presentacion.Core.Mensaje;
using Servicios.Core.Arreglo;
using Servicios.Core.Arreglo.Dto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.CtaCte;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.DetalleProducto;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Venta;
using System;
using System.Windows.Forms;

namespace Presentacion.Core.Arreglo
{
    public partial class InsertarArreglo : FormularioBase
    {
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detallCajaServicio;
        private readonly ICtaCteServicio ctaCteServicio;
        private readonly IClienteServicio clienteServicio;
        private readonly IVentaServicio ventaServicio;
        private readonly IArregloServicio arregloServicio;
        private readonly IDetalleProductoServicio detalleProductoServicio;

        long _ClienteId;
        ClienteDto _Cliente;

        public InsertarArreglo()
        {
            InitializeComponent();

            cajaServicio = new CajaServicio();
            detallCajaServicio = new DetalleCajaServicio();
            ctaCteServicio = new CtaCteServicio();
            clienteServicio = new ClienteServicio();
            ventaServicio = new VentaServicio();
            arregloServicio = new ArregloServicio();
            detalleProductoServicio = new DetalleProductoServicio();

            _ClienteId = 1;

            ControlDeCliente();

            cmbHorario.SelectedIndex = 0;

            lblNumeroOperacion.Text = "#" + detallCajaServicio.TraerNuevoNumeroOperacion();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDatosObligatorios())
            {
                if (!VerCaja())
                {
                    MessageBox.Show("Abra la Caja", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }

                if (nudTotal.Value <= 0)
                {
                    MessageBox.Show("El Total No Puede Ser Cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (txtDescripcion.Text == string.Empty)
                {
                    MessageBox.Show("Agregue Una Descripcion Para Poder Continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                if (MessageBox.Show("Esta Seguro de Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lblNumeroOperacion.Text = "#" + detallCajaServicio.TraerNuevoNumeroOperacion();

                    var numOperacion = detallCajaServicio.TraerNuevoNumeroOperacion();

                    var arreglo = new ArregloDto
                    {
                        Adelanto = (double)nudAdelanto.Value,
                        Total = (double)nudTotal.Value,
                        Apellido = txtApellido.Text,
                        Nombre = txtNombre.Text,
                        ClienteId = _ClienteId,
                        Descripcion = txtDescripcion.Text,
                        Estado = AccesoDatos.EstadoArreglo.EnEspera,
                        FechaPedido = DateTime.Now,
                        Horario = cmbHorario.Text,
                        FechaRetirado = null,
                        FechaEntrega = dtpFechaEntrega.Value.Date,
                        Cantidad = nudCantidad.Value,
                        NumeroOperacion = long.Parse(numOperacion)
                    };

                    arregloServicio.Insertar(arreglo);

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = "Arreglo de" + " " + txtApellido.Text + " " + txtNombre.Text,
                        Fecha = DateTime.Now.ToLongDateString(),
                        Total = (double)nudAdelanto.Value,
                        CajaId = detallCajaServicio.BuscarCajaAbierta(),
                        NumeroOperacion = long.Parse(numOperacion)
                };

                    TipoPago(detalle);

                    var detallleId = detallCajaServicio.AgregarDetalleCaja(detalle);

                    //para ticket
                    VentaDto2 ventaDto2 = new VentaDto2
                    {
                        Cantidad = 1,
                        Descripcion = arreglo.Descripcion,
                        DetalleCajaId = detallleId,
                        Fecha = DateTime.Now,
                        Talle = "---",
                        Precio = arreglo.Total,
                        ProductoId = 1,
                    };

                    detalleProductoServicio.Insertar(ventaDto2);

                    //dinero a caja
                    cajaServicio.SumarDineroACaja((double)nudAdelanto.Value);

#pragma warning disable CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    var mensaje = new Afirmacion("-- Arreglo Creado --", "Se Guardo Su Arreglo");
#pragma warning restore CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                    mensaje.ShowDialog();

                    LimpiarArreglo();
                }
            }
            else
            {
                MessageBox.Show("Verifique Apellido, Titulo, Total: Mayor a 0", "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarArreglo()
        {
            nudTotal.Value = 0;
            nudAdelanto.Value = 0;

            dtpFechaEntrega.Value = DateTime.Now.Date;
            ckbNormal.Checked = true;
            txtDescripcion.Text = "";

            nudCantidad.Value = 1;
            _ClienteId = 1;
            ControlDeCliente();
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

        private void InsertarArreglo_Load(object sender, EventArgs e)
        {
            AgregarControlesObligatorios(txtApellido, "txtApellido");
        }

        private void ControlDeCliente()
        {
            _Cliente = clienteServicio.ObtenerPorId(_ClienteId);

            txtNombre.Text = _Cliente.Nombre;
            txtApellido.Text = _Cliente.Apellido;

            txtCliente.Text = _Cliente.Apellido + " " + _Cliente.Nombre;

            if (_ClienteId == 1)
            {
                txtApellido.Enabled = true;
                txtNombre.Enabled = true;
                txtApellido.Text = "";
            }
            else
            {
                txtApellido.Enabled = false;
                txtNombre.Enabled = false;
            }
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            var elegir = new ElegirCliente();
            elegir.ShowDialog();

            if (elegir.Bandera)
            {
                _ClienteId = (long)elegir.CodigoSeleccionado();
                ControlDeCliente();
            }
        }

        private void nudTotal_ValueChanged(object sender, EventArgs e)
        {
            nudAdelanto.Maximum = nudTotal.Value;
        }

        private void ckbNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbNormal.Checked)
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
            if (ckbTarjeta.Checked)
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
    }
}
