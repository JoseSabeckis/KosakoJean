﻿using Presentacion.Clases;
using Servicios.Core.Caja;
using Servicios.Core.DetalleCaja;
using Servicios.Core.Image.Dto;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class Historia : Form
    {
        private readonly IDetalleCajaServicio _detalleCajaServicio;
        private readonly ICajaServicio cajaServicio;

        long _CajaId;
        long _DetalleId;

        public Historia(long id)
        {
            InitializeComponent();

            _detalleCajaServicio = new DetalleCajaServicio();
            cajaServicio = new CajaServicio();

            _CajaId = id;

            CargarGrilla();

            Calculos();

            CargarImageEnGeneral();

            VerificarSiHayCobros();
        }

        public void CargarGrilla()
        {
            dgvGrilla.DataSource = _detalleCajaServicio.Lista(_CajaId);

            FormatearGrilla(dgvGrilla);
        }

        public void VerificarSiHayCobros()
        {
            if (_detalleCajaServicio.Lista(_CajaId).Count() == 0)
            {
                btnEliminar.Visible = false;
            }
        }

        private void CargarImageEnGeneral()
        {
            imgCaja.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Caja);
        }

        private void Calculos()
        {
            var caja = cajaServicio.BuscarCajasId(_CajaId);

            lblDesde.Text = $"{caja.FechaApertura}";

            lblHasta.Text = $"{caja.FechaCierre}";

            //listo caja ahora detalle

            nudTotal.Value = caja.TotalCaja;

            nudSinMonto.Value = caja.TotalCaja - caja.MontoApertura;

            nudComienzoCaja.Value = caja.MontoApertura;

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

            grilla.Columns["Fecha"].Visible = true;
            grilla.Columns["Fecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["Fecha"].HeaderText = @"Fecha";
            grilla.Columns["Fecha"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["TipoPago"].Visible = true;
            grilla.Columns["TipoPago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TipoPago"].HeaderText = @"Tipo Pago";
            grilla.Columns["TipoPago"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["Tipopago"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Este Seguro De Eliminar Este Cobro?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var dinero = _detalleCajaServicio.BuscarDetallePorId(_DetalleId);

                cajaServicio.RestarDineroACaja(_CajaId, dinero);

                VerificarSiHayCobros();

                CargarGrilla();
                Calculos();
            }
        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _DetalleId = (long)dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                _DetalleId = 0;
            }
        }
    }
}
