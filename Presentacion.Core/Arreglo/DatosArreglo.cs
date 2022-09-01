using Presentacion.Clases;
using Presentacion.Core.Mensaje;
using Servicios.Core.Arreglo;
using Servicios.Core.Arreglo.Dto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.Configuracion;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.DetalleProducto;
using Servicios.Core.Image.Dto;
using Servicios.Core.ParteVenta.Dto;
using Servicios.Core.Ticket;
using Servicios.Core.Venta;
using Servicios.Core.Venta.Dto;
using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Presentacion.Core.Arreglo
{
    public partial class DatosArreglo : FormularioBase
    {
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detalleCajaServicio;
        private readonly IClienteServicio clienteServicio;
        private readonly IVentaServicio ventaServicio;
        private readonly IArregloServicio arregloServicio;
        private readonly IDetalleProductoServicio DetalleServicio;
        private readonly ITicketServicio ticketServicio;
        private readonly IConfiguracionServicio configuracionServicio;

        ArregloDto _ArregloDto;
        ClienteDto _ClienteDto;

        long _ArregloId;
        double _Debe = 0;
        double _Total = 0;

        public DatosArreglo(long arregloId)
        {
            InitializeComponent();

            cajaServicio = new CajaServicio();
            detalleCajaServicio = new DetalleCajaServicio();
            clienteServicio = new ClienteServicio();
            ventaServicio = new VentaServicio();
            arregloServicio = new ArregloServicio();
            DetalleServicio = new DetalleProductoServicio();
            ticketServicio = new TicketServicio();
            configuracionServicio = new ConfiguracionServicio();

            _ArregloId = arregloId;

            Datos();

            VerificarSiEstaPagado();
            VerificarSiEstaTerminado();

            CargarImageEnGeneral();

            MostrarImpresoras();
        }

        private void CargarImageEnGeneral()
        {
            imgArreglo.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Arreglos);
        }

        public void MostrarImpresoras()
        {
            var pd = new PrintDocument();

            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbImpresoras.Items.Add(strPrinter);
            }

            var name = pd.PrinterSettings.PrinterName;

            var index = cmbImpresoras.FindString(name);

            cmbImpresoras.SelectedIndex = index;

        }

        private void Datos()
        {
            //_ClienteDto = clienteServicio.ObtenerPorId(_ArregloDto.ClienteId);
            _ArregloDto = arregloServicio.ObtenerPorId(_ArregloId);

            _Total = _ArregloDto.Total;

            lblPrendas.Text = $"Prendas: {_ArregloDto.Cantidad}";

            lblCliente.Text = $"{_ArregloDto.ApyNom}";

            lblFechaDejado.Text = $"{_ArregloDto.FechaPedido.ToLongDateString()}";
            lblFechaEntrega.Text = $"{_ArregloDto.FechaEntrega.ToLongDateString()}";

            lblEstado.Text = $"{_ArregloDto.Estado}";

            lblHorarioRetiro.Text = $"{_ArregloDto.Horario}";

            txtDescripcion.Text = $"{_ArregloDto.Descripcion}";

            txtTotal.Text = _ArregloDto.Total.ToString("00.00");
            txtDineroAdelanto.Text = _ArregloDto.Adelanto.ToString("00.00");

            txtDebe.Text = (_ArregloDto.Total - _ArregloDto.Adelanto).ToString("00.00");

            lblNumeroOperacion.Text = "#" + _ArregloDto.NumeroOperacion.ToString("00000");

            _Debe = _ArregloDto.Total - _ArregloDto.Adelanto;
            nudCobro.Maximum = (decimal)_Debe;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Guardar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                arregloServicio.GuardarDescripcion(_ArregloId, txtDescripcion.Text);

                var mensaje = new Afirmacion("Guardado!", "Continue con la Prenda");
                mensaje.ShowDialog();
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


        public long NuevoDetalleCaja()
        {
            //caja
            var detalle = new DetalleCajaDto
            {
                Descripcion = $"{lblCliente.Text} - Cobro",
                Fecha = DateTime.Now.ToLongDateString(),
                Total = _Debe,
                CajaId = detalleCajaServicio.BuscarCajaAbierta(),
                NumeroOperacion = _ArregloDto.NumeroOperacion,
                ArregloId = _ArregloId,
                ClienteId = _ArregloDto.ClienteId,
                CtaCteId = null,
                PedidoId = null,
                TipoOperacion = AccesoDatos.TipoOperacion.Arreglo,
            };

            TipoPago(detalle);

            return detalleCajaServicio.AgregarDetalleCaja(detalle);
        }

        private void btnCobro_Click(object sender, EventArgs e)
        {
            if (cajaServicio.BuscarCajaAbierta() != null)
            {
                if (nudCobro.Value > 0)
                {
                    Datos();

                    if (MessageBox.Show("Esta Por Cobrar Un Adelanto, Desea Continuar?", "Adelanto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        arregloServicio.Cobrar(_ArregloId, (double)nudCobro.Value);

                        var detalleId = NuevoDetalleCaja();

                        cajaServicio.SumarDineroACaja((double)nudCobro.Value);

                        //para ticket
                        Detalle(detalleId, (double)nudCobro.Value);

                        _ArregloDto = arregloServicio.ObtenerPorId(_ArregloId);
                        //
                        Datos();

                        //limpieza
                        nudCobro.Value = 0;

                        VerificarSiEstaPagado();

                        var mensaje = new Afirmacion("Adelanto Cobrado", "Continue Con Las Ventas");
                        mensaje.ShowDialog();
                    }

                    return;
                }
                else
                {
                    MessageBox.Show("Error El Valor Tiene Que Ser Mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La Caja Esta Cerrada", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void VerificarSiEstaPagado()
        {
            if (_ArregloDto.Total - _ArregloDto.Adelanto == 0)
            {
                btnCobro.Visible = false;
                nudCobro.Visible = false;
                lblCobrar.Visible = false;

                ckbNormal.Visible = false;
                ckbTarjeta.Visible = false;

            }
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
                Datos();

                if (MessageBox.Show("Esta Seguro de Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    arregloServicio.Cobrar(_ArregloId, _Debe);

                    arregloServicio.CambiarARetiradoYFechaDeRetiro(_ArregloId, DateTime.Now);

                    //detalle

                    var detalleId = NuevoDetalleCaja();

                    //para ticket
                    Detalle(detalleId, _Debe);
                    //
                    Datos();

                    arregloServicio.CambiarARetiradoYFechaDeRetiro(_ArregloId, DateTime.Now);

                    VerificarSiEstaPagado();
                    VerificarSiEstaTerminado();

                    var mensaje = new Afirmacion("Felicidades", "Arreglo Terminado");
                    mensaje.ShowDialog();

                }
            }
            else
            {
                MessageBox.Show("La Caja Esta Cerrada", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void Detalle(long detalleId, double cobro)
        {
            VentaDto2 ventaDto2 = new VentaDto2
            {
                Cantidad = (double)_ArregloDto.Cantidad,
                Descripcion = txtDescripcion.Text,
                DetalleCajaId = detalleId,
                Fecha = DateTime.Now,
                Talle = "-",
                Precio = cobro,
                ProductoId = 1,
            };

            DetalleServicio.Insertar(ventaDto2);

            //venta
            var venta = new VentaDto
            {
                ClienteId = _ArregloDto.ClienteId,
                Descuento = 0,
                Fecha = DateTime.Now,
                Total = cobro
            };

            ventaServicio.NuevaVenta(venta);
        }

        public void VerificarSiEstaTerminado()
        {
            if (_ArregloDto.Estado == AccesoDatos.EstadoArreglo.EnEspera)
            {
                btnRestaurar.Visible = false;
                btnTerminar.Visible = true;
                lblEstado.BackColor = System.Drawing.Color.LightYellow;
            }
            else
            {
                btnTerminar.Visible = false;
                btnRestaurar.Visible = true;
                lblEstado.BackColor = System.Drawing.Color.OrangeRed;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro De Restaurar Este Arreglo?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                arregloServicio.CambiarAEnEsperaYFechaDeRetiro(_ArregloId);

                Datos();
                VerificarSiEstaTerminado();

                var mensaje = new Afirmacion("Cambio Realizado", "Se Volvio a En Espera");
                mensaje.ShowDialog();

            }
        }

        private void lblNumeroOperacion_Click(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDatos.PerformClick();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Imprimir?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {

                if (cmbImpresoras.Text == string.Empty)
                {
                    MessageBox.Show("Elija el Formato de Impresion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ticketServicio.ImprimirAutomaticamenteArreglo(detalleCajaServicio.BuscarDetalleConArregloId(_ArregloId).Id, cmbImpresoras.Text, _ArregloDto.ClienteId);
                }

            }
        }
    }
}
