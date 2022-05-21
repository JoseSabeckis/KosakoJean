﻿using Presentacion.Clases;
using Servicios.Core.Caja;
using Servicios.Core.DetalleCaja;
using Servicios.Core.Image.Dto;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Caja
{
    public partial class Caja : Form
    {
        private readonly ICajaServicio _cajaServicio;
        private readonly IDetalleCajaServicio _detalleCajaServicio;

        long _Id;

        public Caja()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
            _detalleCajaServicio = new DetalleCajaServicio();

            ckbApertura.Enabled = false;

            VerCaja();

            CargarImageEnGeneral();
            VerificarBotonEliminar();
        }

        private void VerificarBotonEliminar()
        {
            var lista = _cajaServicio.BuscarCajasPorMes();

            if (lista.Count() == 0)
            {
                btnEliminarCaja.Visible = false;
            }
        }

        private void CargarImageEnGeneral()
        {
            imgCaja.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Caja);
        }

        public void VerCaja()
        {
            dgvGrilla.DataSource = _cajaServicio.BuscarCajasPorMes();
            FormatearGrilla(dgvGrilla);
        }

        public void VerCajaApertura(DateTime desde, DateTime hasta)
        {
            dgvGrilla.DataSource = _cajaServicio.BuscarCajasPorApertura(desde, hasta);
            FormatearGrilla(dgvGrilla);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Caja_Load(object sender, EventArgs e)
        {

        }

        public void FormatearGrilla(DataGridView grilla)
        {
            for (var i = 0; i < grilla.ColumnCount; i++)
            {
                grilla.Columns[i].Visible = false;
            }

            grilla.Columns["TotalCaja"].Visible = true;
            grilla.Columns["TotalCaja"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["TotalCaja"].HeaderText = @"Total Caja";
            grilla.Columns["TotalCaja"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["TotalCaja"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["MontoApertura"].Visible = true;
            grilla.Columns["MontoApertura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["MontoApertura"].HeaderText = @"Monto Apertura";
            grilla.Columns["MontoApertura"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["MontoApertura"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            /*
            grilla.Columns["MontoCierre"].Visible = true;
            grilla.Columns["MontoCierre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["MontoCierre"].HeaderText = @"Monto Cierre";
            grilla.Columns["MontoCierre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["MontoCierre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            */
            grilla.Columns["FechaApertura"].Visible = true;
            grilla.Columns["FechaApertura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["FechaApertura"].HeaderText = @"Fecha Apertura";
            grilla.Columns["FechaApertura"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["FechaApertura"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grilla.Columns["FechaCierre"].Visible = true;
            grilla.Columns["FechaCierre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grilla.Columns["FechaCierre"].HeaderText = @"Fecha Cierre";
            grilla.Columns["FechaCierre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grilla.Columns["FechaCierre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void ckbApertura_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ckbCierre_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (ckbApertura.Checked == true)
            {
                VerCajaApertura(dtpDesde.Value, dtpHasta.Value);
            }
        }

        private void dgvGrilla_DoubleClick(object sender, EventArgs e)
        {
            if (dgvGrilla.RowCount == 0)
            {
                MessageBox.Show("Error no hay nada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var historial = new Historia(_Id);
            historial.ShowDialog();

        }

        private void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGrilla.RowCount > 0)
            {
                _Id = (long)dgvGrilla["Id", e.RowIndex].Value;
            }
            else
            {
                _Id = 0;
            }
        }

        private void btnEliminarCaja_Click(object sender, EventArgs e)
        {
            var caja = _cajaServicio.BuscarCajasId(_Id);

            if (caja.FechaCierre == "No Esta Cerrada")
            {
                MessageBox.Show("Cierre La Caja Para Poder Eliminarla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Este Seguro De Eliminar Esta Caja Completamente?","Pregunta",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            var listaDetalles = _detalleCajaServicio.Lista(_Id);

            _detalleCajaServicio.ListaParaEliminar(listaDetalles);

            _cajaServicio.EliminarCaja(_Id);

            VerCaja();

            VerificarBotonEliminar();
        }
    }
}
