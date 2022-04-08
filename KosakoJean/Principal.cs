﻿using AccesoDatos;
using KosakoJean.Properties;
using Presentacion.Clases;
using Presentacion.Core.Arreglo;
using Presentacion.Core.Caja;
using Presentacion.Core.Cliente;
using Presentacion.Core.Cobro;
using Presentacion.Core.Colegio;
using Presentacion.Core.CtaCte;
using Presentacion.Core.Negocio;
using Presentacion.Core.Pedido;
using Presentacion.Core.Producto;
using Presentacion.Core.Talle;
using Presentacion.Core.TipoProducto;
using Servicios.Core.Caja;
using Servicios.Core.Cliente;
using Servicios.Core.Cliente.Dto;
using Servicios.Core.Colegio;
using Servicios.Core.Image;
using Servicios.Core.Image.Dto;
using Servicios.Core.Negocio;
using Servicios.Core.Negocio.Dto;
using Servicios.Core.Talle;
using Servicios.Core.Talle.Dto;
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
        private readonly INegocioServicio negocioServicio;
        private readonly I_ImageServicio imageServicio;

        public Principal()
        {
            InitializeComponent();

            _cajaServicio = new CajaServicio();
            clienteServicio = new ClienteServicio();
            talleServicio = new TalleServicio();
            tipoProductoServicio = new TipoProductoServicio();
            colegioServicio = new ColegioServicio();
            negocioServicio = new NegocioServicio();
            imageServicio = new ImageServicio();

            DatosComercio();
            CargarImagenes();
            imageServicio.CargarImagenes();
            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imageLogo.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Logo_Principal);
        }

        public void DatosComercio()
        {
            var comercio = negocioServicio.ObtenerPorId(1);

            NegocioLogeado.Id = comercio.Id;
            NegocioLogeado.RazonSocial = comercio.RazonSocial;
            NegocioLogeado.Email = comercio.Email;
            NegocioLogeado.Cuit = comercio.Cuit;
            NegocioLogeado.Direccion = comercio.Direccion;
            NegocioLogeado.Celular = comercio.Celular;
            NegocioLogeado.Imagen = comercio.Imagen;

            imagePrincipal.Image = ImagenDb.Convertir_Bytes_Imagen(comercio.Imagen);

            lblRazonSocial.Text = NegocioLogeado.RazonSocial;
        }

        private void verColegiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var colegio = new Colegio_Abm(TipoOperacion.Nuevo);
            colegio.ShowDialog();
        }

        private void verTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tipo = new Presentacion.Core.TipoProducto.TipoProducto();
            tipo.ShowDialog();
        }

        private void nuevoProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var producto = new Producto_Abm(TipoOperacion.Nuevo);
            producto.ShowDialog();
        }

        private void verProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productos = new Presentacion.Core.Producto.Producto();
            productos.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss tt");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnCajas_Click(object sender, EventArgs e)
        {
            var caja = new Presentacion.Core.Caja.Caja();
            caja.ShowDialog();
        }

        private void verCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var caja = new Presentacion.Core.Caja.Caja();
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

        public void CargarImagenes()
        {
            if (imageServicio.ObtenerPorId(1) == null)
            {
                var image = new ImageDto
                {
                    Image_Caja = ImagenDb.Convertir_Imagen_Bytes(Resources.caja),
                    Image_Clientes = ImagenDb.Convertir_Imagen_Bytes(Resources.clientes),
                    Image_Cobrar = ImagenDb.Convertir_Imagen_Bytes(Resources.clientes),
                    Image_CtaCte = ImagenDb.Convertir_Imagen_Bytes(Resources.ctacte),
                    Image_Logo_Principal = ImagenDb.Convertir_Imagen_Bytes(Resources.analytics_78917),
                    Image_Para_Hacer = ImagenDb.Convertir_Imagen_Bytes(Resources.ctacte),
                    Image_Pedidos_Listos = ImagenDb.Convertir_Imagen_Bytes(Resources.listos),
                    Image_Pedidos_Pendientes = ImagenDb.Convertir_Imagen_Bytes(Resources.pendiente),
                    Image_Pedidos_Terminados = ImagenDb.Convertir_Imagen_Bytes(Resources.listos),
                    Image_Pedido_Entregado = ImagenDb.Convertir_Imagen_Bytes(Resources.ropa),
                    Image_Pedido_Guardado = ImagenDb.Convertir_Imagen_Bytes(Resources.guardado),
                    Image_Productos = ImagenDb.Convertir_Imagen_Bytes(Resources.producto),
                    Image_Pedido_Venta = ImagenDb.Convertir_Imagen_Bytes(Resources.venta),
                    Image_Arreglos = ImagenDb.Convertir_Imagen_Bytes(Resources.arreglo),
                    Image_Esperando = ImagenDb.Convertir_Imagen_Bytes(Resources.espera),
                    Image_Info = ImagenDb.Convertir_Imagen_Bytes(Resources.info),
                    Image_Fabricar = ImagenDb.Convertir_Imagen_Bytes(Resources.fabricar)
                };

                imageServicio.Insertar(image);
            }
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

            if (talleServicio.ObtenerPorId(1) == null)
            {
                var talle0 = new TalleDto
                {
                    Descripcion = "Sin Talle"
                };

                talleServicio.Nuevo(talle0);

                var talle = new TalleDto
                {
                    Descripcion = "0"
                };

                talleServicio.Nuevo(talle);

                var talle1 = new TalleDto
                {
                    Descripcion = "1"
                };

                talleServicio.Nuevo(talle1);

                var talle2 = new TalleDto
                {
                    Descripcion = "2"
                };

                talleServicio.Nuevo(talle2);

                var talle3 = new TalleDto
                {
                    Descripcion = "3"
                };

                talleServicio.Nuevo(talle3);

                var talle4 = new TalleDto
                {
                    Descripcion = "4"
                };

                talleServicio.Nuevo(talle4);

                var talle6 = new TalleDto
                {
                    Descripcion = "6"
                };

                talleServicio.Nuevo(talle6);

                var talle8 = new TalleDto
                {
                    Descripcion = "8"
                };

                talleServicio.Nuevo(talle8);

                var talle10 = new TalleDto
                {
                    Descripcion = "10"
                };

                talleServicio.Nuevo(talle10);

                var talle12 = new TalleDto
                {
                    Descripcion = "12"
                };

                talleServicio.Nuevo(talle12);

                var talle14 = new TalleDto
                {
                    Descripcion = "14"
                };

                talleServicio.Nuevo(talle14);

                var talleS = new TalleDto
                {
                    Descripcion = "S"
                };

                talleServicio.Nuevo(talleS);

                var talleM = new TalleDto
                {
                    Descripcion = "M"
                };

                talleServicio.Nuevo(talleM);

                var talleL = new TalleDto
                {
                    Descripcion = "L"
                };

                talleServicio.Nuevo(talleL);

                var talleXL = new TalleDto
                {
                    Descripcion = "XL"
                };

                talleServicio.Nuevo(talleXL);

                var talleXXL = new TalleDto
                {
                    Descripcion = "XXL"
                };

                talleServicio.Nuevo(talleXXL);

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
                    Direccion = "Peru Sud 573",
                    Telefono = "3813590385",
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
                var cobro = new Presentacion.Core.Cobro.Venta();
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
            var colegio = new Presentacion.Core.Colegio.Colegio();
            colegio.ShowDialog();
        }

        private void nuevoTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tipo = new TipoProducto_Abm(TipoOperacion.Nuevo);
            tipo.ShowDialog();
        }

        private void verTiposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var tipo = new Presentacion.Core.TipoProducto.TipoProducto();
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
            var cliente = new Presentacion.Core.Cliente.Cliente();
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
            var talle = new Presentacion.Core.Talle.Talle();
            talle.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            var lista = new ListaProductos();
            lista.ShowDialog();
        }

        private void btnPrendasEntregadas_Click(object sender, EventArgs e)
        {
            var prenda = new GuardadoConsumidorFinal(Proceso.Retirado);
            prenda.ShowDialog();
        }

        private void btnPrendaGuardadas_Click(object sender, EventArgs e)
        {
            var prenda = new GuardadoConsumidorFinal(Proceso.Guardado);
            prenda.ShowDialog();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var fabricar = new PrendaFabricar();
            fabricar.ShowDialog();
        }

        private void verNegocioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var negocio = new NegocioDatos();
            negocio.ShowDialog();

            DatosComercio();
        }

        private void btnArreglos_Click(object sender, EventArgs e)
        {
            if (_cajaServicio.BuscarCajaAbiertaBool())
            {
                var arreglos = new ListaArreglos();
                arreglos.ShowDialog();
            }
            else
            {
                MessageBox.Show("La Caja No Se Encuentra Abierta...", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
    }
}
