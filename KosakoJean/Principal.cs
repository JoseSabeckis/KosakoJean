using Presentacion.Core.Caja;
using Presentacion.Core.Cobro;
using Presentacion.Core.Colegio;
using Presentacion.Core.Producto;
using Presentacion.Core.TipoProducto;
using Servicios.Core.Caja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KosakoJean
{
    public partial class Principal : Form
    {
        private readonly ICajaServicio _cajaServicio;

        public Principal()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
        }

        private void verColegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colegio = new Colegio();
            colegio.ShowDialog();
        }

        private void verTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tipo = new TipoProducto();
            tipo.ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var producto = new Producto_Abm(Presentacion.Clases.TipoOperacion.Nuevo);
            producto.ShowDialog();
        }

        private void verProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productos = new Producto();
            productos.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnCajas_Click(object sender, EventArgs e)
        {
            var caja = new Caja();
            caja.ShowDialog();
        }

        private void verCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var caja = new Caja();
            caja.ShowDialog();
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            var abrir = new AbrirCaja();
            abrir.ShowDialog();

            ValidarCajas();
        }

        public void ValidarCajas()
        {
            if (_cajaServicio.BuscarCajaAbiertaBool())
            {
                btnAbrirCaja.Visible = false;
                btnCerrarCaja.Visible = true;

            }

            if (!_cajaServicio.BuscarCajaAbiertaBool())
            {
                btnAbrirCaja.Visible = true;
                btnCerrarCaja.Visible = false;

            }

        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            var cerrar = new CerrarCaja();
            cerrar.ShowDialog();

            ValidarCajas();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            ValidarCajas();
        }

        private void salirDeLaAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCobrar2_Click(object sender, EventArgs e)
        {
            if (_cajaServicio.BuscarCajaAbiertaBool())
            {
                var cobro = new Venta();
                cobro.ShowDialog();
            }
            else
            {
                MessageBox.Show("La Caja No Se Encuentra Abierta...", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
