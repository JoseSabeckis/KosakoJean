﻿using Presentacion.Core.Mensaje;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.CtaCte;
using Servicios.Core.CtaCte.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.CtaCte
{
    public partial class CtaCte : Form
    {
        private readonly IClienteServicio _clienteServicio;
        private readonly ICtaCteServicio _ctaCteServicio;

        long _ClienteId;
        long _CtaCteId;
        ClienteDto _clienteDto;
        CtaCteDto _ctaDto;

        public CtaCte(long clienteId)
        {
            InitializeComponent();

            _clienteServicio = new ClienteServicio();
            _ctaCteServicio = new CtaCteServicio();

            _ClienteId = clienteId;
            _clienteDto = _clienteServicio.ObtenerPorId(clienteId);

            lblNombre.Text = $"{_clienteDto.Apellido} - {_clienteDto.Nombre}";
            lblDomicilio.Text = $"{_clienteDto.Direccion}";

            DebeYTotal(_ctaCteServicio.Lista(_ClienteId));

            Grilla();
            Datos();

        }

        public void nudCobroMaximo()
        {
            nudCobro.Maximum = _ctaDto.Debe;
        }

        public void CobrarEnabled()
        {
            if (Convert.ToDecimal(txtDebe.Text) == 0)
            {
                nudCobro.Enabled = false;
                btnCobrar.Enabled = false;
            }
            else
            {
                
                nudCobro.Enabled = true;
                btnCobrar.Enabled = true;
                nudCobroMaximo();
            }
            
        }

        public void Datos()
        {
            if (_CtaCteId != 0 || _ctaDto != null)
            {

                CobrarEnabled();

            }
            //else
            //{
            //    CobrarEnabled();
            //}
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
                CobrarEnabled();
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

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (_CtaCteId != 0)
            {
                if (MessageBox.Show("Esta Seguro de Cobrar?","Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    _ctaCteServicio.Pagar(nudCobro.Value, _ClienteId, _CtaCteId);

                    var mensaje = new Afirmacion("Cobrado", $"Se Le Cobro $ {nudCobro.Value} Exitosamente!");
                    mensaje.ShowDialog();

                    DebeYTotal(_ctaCteServicio.Lista(_ClienteId));

                    Grilla();

                    Datos();

                }
            }
        }
    }
}
