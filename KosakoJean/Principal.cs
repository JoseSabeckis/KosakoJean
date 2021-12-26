using Presentacion.Clases;
using Presentacion.Core.Caja;
using Presentacion.Core.Cliente;
using Presentacion.Core.Cobro;
using Presentacion.Core.Colegio;
using Presentacion.Core.Pedido;
using Presentacion.Core.Producto;
using Presentacion.Core.TipoProducto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
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
        private readonly IClienteServicio clienteServicio;

        public Principal()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
            clienteServicio = new ClienteServicio();
        }

        private void verColegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colegio = new Colegio_Abm(TipoOperacion.Nuevo);
            colegio.ShowDialog();
        }

        private void verTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tipo = new TipoProducto();
            tipo.ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var producto = new Producto_Abm(TipoOperacion.Nuevo);
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

            CargarConsumidorFinal();
        }

        public void CargarConsumidorFinal()
        {
            if (clienteServicio.Buscar("Consumidor Final").Count() == 0)
            {
                var confumidor = new ClienteDto
                {
                    Apellido = "Consumidor Final",
                    Foto = ImagenDb.Convertir_Imagen_Bytes(Imagen.Usuario),
                    Nombre = "",
                    Direccion = "",
                    Telefono = "",
                    Principal = true
                };

                clienteServicio.Nuevo(confumidor);
            }
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

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            if (_cajaServicio.BuscarCajaAbiertaBool())
            {
                var lista = new Lista();
                lista.ShowDialog();
            }
            else
            {
                MessageBox.Show("La Caja No Se Encuentra Abierta...", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListoParaEntregar_Click(object sender, EventArgs e)
        {
            if (_cajaServicio.BuscarCajaAbiertaBool())
            {
                var pedidos = new PedidosEsperando();
                pedidos.Show();
            }
            else
            {
                MessageBox.Show("La Caja No Se Encuentra Abierta...", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoColegioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colegio = new Colegio();
            colegio.ShowDialog();
        }

        private void nuevoTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tipo = new TipoProducto_Abm(TipoOperacion.Nuevo);
            tipo.ShowDialog();
        }

        private void verTiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var tipo = new TipoProducto();
            tipo.ShowDialog();
        }

        private void btnTerminados_Click(object sender, EventArgs e)
        {
            var terminado = new PedidosTerminados();
            terminado.ShowDialog();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente_Abm(TipoOperacion.Nuevo);
            cliente.ShowDialog();
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente();
            cliente.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            var cliente = new VerClientes();
            cliente.ShowDialog();
        }
    }
}
