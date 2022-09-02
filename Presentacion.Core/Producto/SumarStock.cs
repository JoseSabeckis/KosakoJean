using Presentacion.Core.Mensaje;
using Servicios.Core.Producto;
using Servicios.Core.Producto.Dto;
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
    public partial class SumarStock : Form
    {
        private readonly IProductoServicio productoServicio;

        ProductoDto _Producto;

        public SumarStock(long productoId)
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();

            _Producto = productoServicio.ObtenerPorId(productoId);

            lblDescripcion.Text = $"{_Producto.Descripcion}";
            lblColegio.Text = $"Colegio: {_Producto.Colegio}";

            nudStock.Value = _Producto.Stock;

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro De Guardar Cambios?", "Pregunta", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                productoServicio.CambiarStock(_Producto.Id, nudStock.Value);

                var mensaje = new Afirmacion("Datos Guardados!", $"{_Producto.Descripcion}\nStock: {nudStock.Value}");
                mensaje.ShowDialog();

                this.Close();

            }
        }
    }
}
