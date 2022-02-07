using Servicios.Core.DetalleCaja;
using Servicios.Core.DetalleCaja.Dto;
using Servicios.Core.ParteVenta.Dto;
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
    public partial class Comprobante : Form
    {
        private readonly IDetalleCajaServicio detalleCajaServicio;

        List<VentaDto2> ListaDetalle;

        public Comprobante(List<VentaDto2> detalleCajaDtos)
        {
            InitializeComponent();

            detalleCajaServicio = new DetalleCajaServicio();

            ListaDetalle = detalleCajaDtos;

        }

        private void Comprobante_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.DataSources.Clear();

            reportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetComprobante", ListaDetalle));
            
            reportViewer.LocalReport.Refresh();
            reportViewer.Refresh();

            this.reportViewer.RefreshReport();
        }
    }
}
