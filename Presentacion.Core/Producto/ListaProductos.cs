using Presentacion.Clases;
using Presentacion.Core.CodBarra;
using Presentacion.Core.Factura;
using Presentacion.Core.Producto.Ctrl;
using Servicios.Core.Image.Dto;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Core.Producto
{
    public partial class ListaProductos : Form
    {
        private readonly IProductoServicio productoServicio;

        public ListaProductos()
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();

            CrearControles(string.Empty);

            CargarImageEnGeneral();
        }

        private void CargarImageEnGeneral()
        {
            imgProducto.Image = ImagenDb.Convertir_Bytes_Imagen(ImageLogueado.Image_Productos);
        }

        public void CrearControles(string busqueda)
        {
            var cuadros = productoServicio.Buscar(busqueda);

            var flowPanel = new FlowLayoutPanel
            {
                Name = $"flowPanel",
                Dock = DockStyle.Fill,
                BackgroundImageLayout = ImageLayout.Stretch,
                AutoScroll = true
            };

            foreach (var item in cuadros)
            {
                var cuadro = item;

                var control = new ProductoCtrol(cuadro.Id);

                flowPanel.Controls.Add(control);

            }

            pnlPrincipal.Controls.Add(flowPanel);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            CrearControles(string.Empty);
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            var nuevo = new Producto_Abm(Clases.TipoOperacion.Nuevo);
            nuevo.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            CrearControles(txtBusqueda.Text);
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void btnCodBarra_Click(object sender, EventArgs e)
        {
            if (productoServicio.Buscar(string.Empty).Count() != 0)
            {
                var productos = productoServicio.Buscar(string.Empty);

                List<CodBarraDto> Lista = new List<CodBarraDto>();

                foreach (var item in productos)
                {
                    var objeto = new CodBarraDto
                    {
                        Id = item.Id,
                        Descripcion = item.Descripcion,
                        Extra = item.Extras,
                        Precio = item.Precio,
                        CodigoBarra = item.CodigoBarra,
                        Imagen = item.ImagenCodBarra,
                        Colegio = item.Colegio
                    };

                    Lista.Add(objeto);
                }                

                var form = new FormularioCodigoBarra(Lista);
                form.Show();

            }
        }

        private void btnConPocoStock_Click(object sender, EventArgs e)
        {
            var stock = new PocoStock();
            stock.ShowDialog();
        }

        private void btnListaProductos_Click(object sender, EventArgs e)
        {
            var lista = new FormListaProductos();
            lista.Show();
        }
    }
}
