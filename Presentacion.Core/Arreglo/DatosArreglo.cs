using Presentacion.Core.Mensaje;
using Servicios.Core.Arreglo;
using Servicios.Core.Arreglo.Dto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
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

namespace Presentacion.Core.Arreglo
{
    public partial class DatosArreglo : FormularioBase
    {
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detalleCajaServicio;
        private readonly IClienteServicio clienteServicio;
        private readonly IVentaServicio ventaServicio;
        private readonly IArregloServicio arregloServicio;

        ArregloDto _ArregloDto;
        ClienteDto _ClienteDto;

        long _ArregloId;
        decimal _Debe = 0;

        public DatosArreglo(long arregloId)
        {
            InitializeComponent();

            cajaServicio = new CajaServicio();
            detalleCajaServicio = new DetalleCajaServicio();
            clienteServicio = new ClienteServicio();
            ventaServicio = new VentaServicio();
            arregloServicio = new ArregloServicio();

            _ArregloId = arregloId;

            Datos();

            VerificarSiEstaPagado();
            VerificarSiEstaTerminado();
        }

        private void Datos()
        {
            _ArregloDto = arregloServicio.ObtenerPorId(_ArregloId);

            _ClienteDto = clienteServicio.ObtenerPorId(_ArregloDto.ClienteId);

            lblCliente.Text = $"|-- {_ClienteDto.Apellido} {_ClienteDto.Nombre} --|";

            lblFechaDejado.Text = $"{_ArregloDto.FechaPedido}";
            lblFechaEntrega.Text = $"{_ArregloDto.FechaEntrega}";

            lblEstado.Text = $"{_ArregloDto.Estado}";

            lblHorarioRetiro.Text = $"{_ArregloDto.Horario}";

            txtDescripcion.Text = $"{_ArregloDto.Descripcion}";

            txtTotal.Text = $"$ {_ArregloDto.Total}";
            txtDineroAdelanto.Text = $"$ {_ArregloDto.Adelanto}";

            txtDebe.Text = $"$ {_ArregloDto.Total - _ArregloDto.Adelanto}";

            _Debe = _ArregloDto.Total - _ArregloDto.Adelanto;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Guardar?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void btnCobro_Click(object sender, EventArgs e)
        {
            if (cajaServicio.BuscarCajaAbierta() != null)
            {
                if (nudCobro.Value > 0)
                {
                    if (MessageBox.Show("Esta Por Cobrar Un Adelanto, Desea Continuar?", "Adelanto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        arregloServicio.Cobrar(_ArregloId, nudCobro.Value);

                        //caja
                        var detalle = new DetalleCajaDto
                        {
                            Descripcion = $"{lblCliente.Text} - Cobro Adelanto",
                            Fecha = DateTime.Now.ToLongDateString(),
                            Total = _Debe,
                            CajaId = detalleCajaServicio.BuscarCajaAbierta()
                        };

                        TipoPago(detalle);

                        detalleCajaServicio.AgregarDetalleCaja(detalle);

                        cajaServicio.SumarDineroACaja(nudCobro.Value);
                        var venta = new VentaDto
                        {
                            ClienteId = _ArregloDto.ClienteId,
                            Descuento = 0,
                            Fecha = DateTime.Now,
                            Total = nudCobro.Value
                        };

                        ventaServicio.NuevaVenta(venta);

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
                if (MessageBox.Show("Esta Seguro de Continuar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    arregloServicio.Cobrar(_ArregloId, _Debe);

                    arregloServicio.CambiarARetiradoYFechaDeRetiro(_ArregloId, DateTime.Now);

                    Datos();

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

        public void VerificarSiEstaTerminado()
        {
            if (_ArregloDto.Estado == AccesoDatos.EstadoArreglo.EnEspera)
            {
                btnRestaurar.Visible = false;
                btnTerminar.Visible = true;
            }
            else
            {
                btnTerminar.Visible = false;
                btnRestaurar.Visible = true;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro De Restaurar Este Arreglo?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes
            {

                arregloServicio.CambiarAEnEsperaYFechaDeRetiro(_ArregloId);

                Datos();
                VerificarSiEstaTerminado();

                var mensaje = new Afirmacion("Cambio Realizado", "Se Volvio a En Espera");
                mensaje.ShowDialog();

            }
        }
    }
}
