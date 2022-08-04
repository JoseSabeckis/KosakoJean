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
using Servicios.Core.Ticket;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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
        private readonly ITicketServicio ticketServicio;

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
            ticketServicio = new TicketServicio();

            _ClienteId = clienteId;
            _clienteDto = _clienteServicio.ObtenerPorId(clienteId);

            lblNombre.Text = $"{_clienteDto.Apellido} - {_clienteDto.Nombre}";
            lblDomicilio.Text = $"Direccion: {_clienteDto.Direccion}";

            DebeYTotal(_ctaCteServicio.Lista(_ClienteId));

            Grilla();
            Datos();

            CargarImageEnGeneral();
            MostrarImpresoras();
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

        private void CargarImageEnGeneral()
        {
            imgCtaCte.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_CtaCte);
        }

        public void nudCobroMaximo()
        {
            nudCobro.Maximum = (decimal)_ctaDto.Debe;

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

            if (dgvGrilla.RowCount == 0)
            {
                btnImprimir.Enabled = false;
            }
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

            grilla.Columns["TotalVista"].Visible = true;
            grilla.Columns["TotalVista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TotalVista"].HeaderText = @"Total";
            grilla.Columns["TotalVista"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["TotalVista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["DebeVista"].Visible = true;
            grilla.Columns["DebeVista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["DebeVista"].HeaderText = @"Debe";
            grilla.Columns["DebeVista"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["DebeVista"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            double debe = 0;
            double total = 0;

            foreach (var item in lista)
            {

                debe += item.Debe;
                total += item.Total;

            }

            txtDebe.Text = debe.ToString("00.00");
            txtTotal.Text = total.ToString("00.00");
            txtDebeTotal.Text = debe.ToString("00.00");
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
                        _ctaCteServicio.Pagar((double)nudCobro.Value, _ClienteId, _CtaCteId);

                        //Inicio Pedido
                        var ctacte = _ctaCteServicio.ObtenerPorId(_CtaCteId);

                        var pedido = pedidoServicio.BuscarIDPedidos(ctacte.PedidoId);

                        pedidoServicio.CambiarRamas((double)nudCobro.Value, ctacte.PedidoId);

                        if (pedido.Adelanto == pedido.Total)
                        {
                            pedidoServicio.CambiarProcesoTerminado(pedido.Id);
                        }

                        //caja

                        var detalle = new DetalleCajaDto
                        {
                            Fecha = DateTime.Now.ToString(),
                            Total = (double)nudCobro.Value,
                            Descripcion = $"Cobro a {_clienteDto.Apellido} {_clienteDto.Nombre}",
                            CajaId = detalleCajaServicio.BuscarCajaAbierta(),
                            ArregloId = null,
                            ClienteId = pedido.ClienteId,
                            CtaCteId = _CtaCteId,
                            TipoOperacion = AccesoDatos.TipoOperacion.CtaCte,
                            NumeroOperacion = _ctaDto.NumeroOperacion,
                            PedidoId = pedido.Id,                           
                        };

                        TipoPago(detalle);

                        detalleCajaServicio.AgregarDetalleCaja(detalle);

                        cajaServicio.SumarDineroACaja((double)nudCobro.Value);

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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro De Imprimir","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cmbImpresoras.Text == string.Empty)
                {
                    MessageBox.Show("Elija el Formato de Impresion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ticketServicio.ImprimirAutomaticamenteCtaCte(detalleCajaServicio.BuscarDetalleConCtaCteId(_CtaCteId).Id, cmbImpresoras.Text, _ClienteId);
                }
            }
        }
    }
}
