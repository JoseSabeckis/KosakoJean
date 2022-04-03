﻿using Presentacion.Core.Cliente;
using Presentacion.Core.Mensaje;
using Servicios.Core.Arreglo;
using Servicios.Core.Arreglo.Dto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.CtaCte;
using Servicios.Core.CtaCte.Dto;
using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.Venta;
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
    public partial class InsertarArreglo : FormularioBase
    {
        private readonly ICajaServicio cajaServicio;
        private readonly IDetalleCajaServicio detallCajaServicio;
        private readonly ICtaCteServicio ctaCteServicio;
        private readonly IClienteServicio clienteServicio;
        private readonly IVentaServicio ventaServicio;
        private readonly IArregloServicio arregloServicio;

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

            _ClienteId = 1;

            ControlDeCliente();

            cmbHorario.SelectedIndex = 0;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (VerificarDatosObligatorios())
            {
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

                if (MessageBox.Show("Esta Seguro de Continuar?","Pregunta",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    var arreglo = new ArregloDto
                    {
                        Adelanto = nudAdelanto.Value,
                        Total = nudTotal.Value,
                        Apellido = txtApellido.Text,
                        Nombre = txtNombre.Text,
                        ClienteId = _ClienteId,
                        Descripcion = txtDescripcion.Text,
                        Estado = AccesoDatos.EstadoArreglo.EnEspera,
                        FechaPedido = DateTime.Now,
                        Horario = cmbHorario.Text,
                        FechaRetirado = null,
                        FechaEntrega = dtpFechaEntrega.Value.Date
                    };

                    arregloServicio.Insertar(arreglo);

                    var detalle = new DetalleCajaDto
                    {
                        Descripcion = "Arreglo de" + " " + txtApellido.Text + " " + txtNombre.Text,
                        Fecha = DateTime.Now.ToLongDateString(),
                        Total = nudAdelanto.Value,
                        CajaId = detallCajaServicio.BuscarCajaAbierta()
                    };

                    TipoPago(detalle);

                    detallCajaServicio.AgregarDetalleCaja(detalle);

                    //dinero a caja
                    cajaServicio.SumarDineroACaja(nudAdelanto.Value);

                    var mensaje = new Afirmacion("-- Arreglo Creado --", "Se Guardo Su Arreglo");
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
        }

        private void ckbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTarjeta.Checked)
            {
                ckbNormal.Checked = false;
            }
        }
    }
}
