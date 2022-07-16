using Presentacion.Clases;
using Presentacion.Core.Mensaje;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.CtaCte;
using Servicios.Core.CtaCte.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.Image.Dto;
using Servicios.Core.Pedido;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.CtaCte
{
    public partial class CtaCte : Form
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly ICtaCteServicio _ctaCteServicio;
        private readonly IDetalleCajaServicio detalleCajaServicio;
        private readonly ICajaServicio cajaServicio;
        private readonly IPedidoServicio pedidoServicio;

        long _ClienteId = 0;
        long _CtaCteId = 0;
        ClienteDto _clienteDto;
        CtaCteDto _ctaDto;

        public CtaCte(long clienteId)
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();
            _ctaCteServicio = new CtaCteServicio();
            detalleCajaServicio = new DetalleCajaServicio();
            cajaServicio = new CajaServicio();
            pedidoServicio = new PedidoServicio();

            _ClienteId = clienteId;
            _clienteDto = _clienteServicio.ObtenerPorId(clienteId);

            lblNombre.Text = $"{_clienteDto.Apellido} - {_clienteDto.Nombre}";
            lblDomicilio.Text = $"Direccion: {_clienteDto.Direccion}";

            DebeYTotal(_ctaCteServicio.Lista(_ClienteId));

            Grilla();
            Datos();

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgCtaCte.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_CtaCte);
        }

        public void nudCobroMaximo()
        {
            nudCobro.Maximum = _ctaDto.Debe;

            if (_ctaDto.Debe == 0)
            {
                nudCobro.Enabled = false;
                //btnCobrar.Enabled = false;
            }
            else
            {
                btnCobrar.Enabled = true;
                nudCobro.Enabled = true;
            }
        }

        public void Datos()
        {
            if (_CtaCteId != 0)
            {

                nudCobroMaximo();

            }
        }

        public void Grilla()
        {
            dgvGrilla.DataSource = _ctaCteServicio.Lista(_ClienteId);
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

            grilla.Columns["Total"].Visible = true;
            grilla.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Total"].HeaderText = @"Total";
            grilla.Columns["Total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Debe"].Visible = true;
            grilla.Columns["Debe"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Debe"].HeaderText = @"Debe";
            grilla.Columns["Debe"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Debe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Fecha"].HeaderText = @"Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["Estado"].Visible = true;
            grilla.Columns["Estado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Estado"].HeaderText = @"Estado";
            grilla.Columns["Estado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _CtaCteId = (long)dgvGrilla["Id", e.RowIndex].Value;
                _ctaDto = _ctaCteServicio.ObtenerPorId(_CtaCteId);
                nudCobroMaximo();
            }
            else
            {
                _CtaCteId = 0;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void DebeYTotal(IEnumerable<CtaCteDto> lista)
        {
            decimal debe = 0;
            decimal total = 0;

            foreach (var item in lista)
            {

                debe += item.Debe;
                total += item.Total;

            }

            txtDebe.Text = $"{debe}";
            txtTotal.Text = $"{total}";

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

        public bool VerCaja()
        {
            var caja = cajaServicio.BuscarCajaAbierta();

            if (caja == null)
            {
                return false;
            }

            return true;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (_CtaCteId != 0)
            {
                if (nudCobro.Value > 0)
                {
                    if (!VerCaja())
                    {
                        MessageBox.Show("Abra la Caja", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        return;
                    }

                    if (ckbNormal.Checked == false && ckbTarjeta.Checked == false)
                    {
                        MessageBox.Show("Seleccione Tipo de Pago: Contado o Tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return;
                    }

                    if (MessageBox.Show("Esta Seguro de Cobrar?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _ctaCteServicio.Pagar(nudCobro.Value, _ClienteId, _CtaCteId);

                        //Inicio Pedido
                        var ctacte = _ctaCteServicio.ObtenerPorId(_CtaCteId);

                        var pedido = pedidoServicio.BuscarIDPedidos(ctacte.PedidoId);

                        pedidoServicio.CambiarRamas(nudCobro.Value, ctacte.PedidoId);

                        if (pedido.Adelanto == pedido.Total)
                        {
                            pedidoServicio.CambiarProcesoTerminado(pedido.Id);
                        }

                        //caja

                        var detalle = new DetalleCajaDto
                        {
                            Fecha = DateTime.Now.ToString(),
                            Total = nudCobro.Value,
                            Descripcion = $"Cobro a {_clienteDto.Apellido} {_clienteDto.Nombre}",
                            CajaId = detalleCajaServicio.BuscarCajaAbierta()
                        };

                        TipoPago(detalle);

                        detalleCajaServicio.AgregarDetalleCaja(detalle);

                        cajaServicio.SumarDineroACaja(nudCobro.Value);

                        //---//

                        DebeYTotal(_ctaCteServicio.Lista(_ClienteId));

                        //Fin Pedido

#pragma warning disable CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                        var mensaje = new Afirmacion("Cobrado", $"Se Le Cobro $ {nudCobro.Value} Exitosamente!\nTipo de Pago: {detalle.TipoPago}");
#pragma warning restore CS0436 // El tipo 'Afirmacion' de 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs' está en conflicto con el tipo importado 'Afirmacion' de 'Presentacion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'. Se usará el tipo definido en 'C:\Users\Pepe\Source\Repos\JoseSabeckis\KosakoJean\Presentacion.Core\Mensaje\Afirmacion.cs'.
                        mensaje.ShowDialog();

                        Grilla();

                        Datos();

                        nudCobro.Value = 0;

                        //nudCobroMaximo();
                    }
                }

            }
        }

        private void nudCobro_ValueChanged(object sender, EventArgs e)
        {
            nudCobroMaximo();
        }

        private void CtaCte_Load(object sender, EventArgs e)
        {
            if (_CtaCteId == 0)
            {
                btnCobrar.Enabled = false;
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
    }
}
