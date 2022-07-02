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

namespace Presentacion.Core.CodBarra
{
    public partial class FormularioCodigoBarra : Form
    {
        List<CodBarraDto> ListaGeneral;

        public FormularioCodigoBarra(List<CodBarraDto> lista)
        {
            InitializeComponent();

            //ListaGeneral = new List<CodBarraDto>();

            ListaGeneral = lista;
        }

        private void FormularioCodigoBarra_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetCodBarraProducto", ListaGeneral));

            reportViewer.LocalReport.Refresh();
            reportViewer.Refresh();

            this.reportViewer.RefreshReport();
        }
    }
}
