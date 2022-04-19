using Servicios.Core.Fecha;
using Servicios.Core.Producto_Dato.Dto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Core.Factura
{
    public partial class ListaPedidos : Form
    {
        List<Producto_Dato_Dto> ListaDato;
        List<FechaDto> Fecha;

        public ListaPedidos(List<Producto_Dato_Dto> listaDato)
        {
            InitializeComponent();

            ListaDato = listaDato;
            Fecha = new List<FechaDto>();

            var fecha = new FechaDto
            {
                Fecha = DateTime.Now.ToLongDateString(),
                Hora = DateTime.Now.ToShortTimeString()
            };

            Fecha.Add(fecha);

        }

        private void ListaPedidos_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ListaDato));
            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetFecha", Fecha));

            reportViewer.LocalReport.Refresh();
            reportViewer.Refresh();

            this.reportViewer.RefreshReport();
        }
    }
}
