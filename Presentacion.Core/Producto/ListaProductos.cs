using Presentacion.Clases;
using Presentacion.Core.Producto.Ctrl;
using Servicios.Core.Image.Dto;
using Servicios.Core.Producto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
