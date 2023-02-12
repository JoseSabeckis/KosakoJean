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
using System.Threading;
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
            InabilitarButton(btnActualizar);

            Thread.Sleep(2000);

            pnlPrincipal.Controls.Clear();
            CrearControles(string.Empty);

            InabilitarButton(btnActualizar);
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            InabilitarButton(btnNuevoProducto);

            var nuevo = new Producto_Abm(TipoOperacion.Nuevo);
            nuevo.ShowDialog();

            InabilitarButton(btnNuevoProducto);
        }

        public void InabilitarButton(Button btn)
        {
            if (btn.Enabled)
            {
                btn.Enabled = false;
            }
            else
            {
                btn.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            InabilitarButton(btnBuscar);

            pnlPrincipal.Controls.Clear();
            CrearControles(txtBusqueda.Text);

            InabilitarButton(btnBuscar);
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
            InabilitarButton(btnCodBarra);

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

            InabilitarButton(btnCodBarra);
        }

        private void btnConPocoStock_Click(object sender, EventArgs e)
        {
            InabilitarButton(btnConPocoStock);
            var stock = new PocoStock();
            stock.ShowDialog();
            InabilitarButton(btnConPocoStock);
        }

        private void btnListaProductos_Click(object sender, EventArgs e)
        {
            InabilitarButton(btnListaProductos);

            var lista = new FormListaProductos();
            lista.ShowDialog();

            InabilitarButton(btnListaProductos);
        }
    }
}
