using Presentacion.Clases;
using Presentacion.Core.Caja;
using Presentacion.Core.Cliente;
using Presentacion.Core.Cobro;
using Presentacion.Core.Colegio;
using Presentacion.Core.Pedido;
using Presentacion.Core.Producto;
using Presentacion.Core.Talle;
using Presentacion.Core.TipoProducto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.Colegio;
using Servicios.Core.Talle;
using Servicios.Core.TipoProducto;
using Servicios.Core.TipoProducto.Dto;
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
        private readonly ITalleServicio talleServicio;
        private readonly ITipoProducto tipoProductoServicio;
        private readonly IColegioServicio colegioServicio;

        public Principal()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
            clienteServicio = new ClienteServicio();
            talleServicio = new TalleServicio();
            tipoProductoServicio = new TipoProductoServicio();
            colegioServicio = new ColegioServicio();
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
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss tt");
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

            VerificarPrimeraVez();
        }

        public void VerificarPrimeraVez()
        {
            if (tipoProductoServicio.ObtenerPorId(1) == null)
            {
                var tipo = new TipoProductoDto
                {
                    Descripcion = "Prenda"
                };

                tipoProductoServicio.Nuevo(tipo);
            }

            if (colegioServicio.ObtenerPorId(1) == null)
            {
                var colegio = new ColegioDto
                {
                    Descripcion = "No Colegial"
                };

                colegioServicio.Nuevo(colegio);
            }

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
                    Dni = "11111111",
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
            if (talleServicio.Buscar(string.Empty).Count() == 0)
            {
                MessageBox.Show("No Existes Los Talles, Cree Algunos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

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

        private void nuevoTalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var talle = new Talle_Abm(TipoOperacion.Nuevo);
            talle.ShowDialog();
        }

        private void verTallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var talle = new Talle();
            talle.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            var lista = new ListaProductos();
            lista.ShowDialog();
        }
    }
}
