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

namespace Presentacion.Core.Factura
{
    public partial class FormListaProductos : Form
    {
        private readonly IProductoServicio productoServicio;

        IEnumerable<ProductoDto> Producto { get; }

        public FormListaProductos()
        {
            InitializeComponent();

            productoServicio = new ProductoServicio();

            Producto = productoServicio.Buscar(string.Empty);
        }

        private void FormListaProductos_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetProductos", Producto));

            reportViewer.LocalReport.Refresh();
            reportViewer.Refresh();

            this.reportViewer.RefreshReport();
        }
    }
}
