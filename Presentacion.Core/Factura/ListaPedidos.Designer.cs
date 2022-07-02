
namespace Presentacion.Core.Factura
{
    partial class ListaPedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaPedidos));
            this.FechaDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Producto_Dato_ImpresionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.FechaDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Producto_Dato_ImpresionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // FechaDtoBindingSource
            // 
            this.FechaDtoBindingSource.DataSource = typeof(Servicios.Core.Fecha.FechaDto);
            // 
            // Producto_Dato_ImpresionBindingSource
            // 
            this.Producto_Dato_ImpresionBindingSource.DataSource = typeof(Servicios.Core.Producto_Dato.Dto.Producto_Dato_Impresion);
            // 
            // reportViewer
            // 
            this.reportViewer.BackColor = System.Drawing.Color.DarkGray;
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetFecha";
            reportDataSource1.Value = this.FechaDtoBindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.Producto_Dato_ImpresionBindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Presentacion.Core.Factura.ReportPrendas.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(800, 450);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.Load += new System.EventHandler(this.reportViewer_Load);
            // 
            // ListaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "ListaPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedidos";
            this.Load += new System.EventHandler(this.ListaPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FechaDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Producto_Dato_ImpresionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource FechaDtoBindingSource;
        private System.Windows.Forms.BindingSource Producto_Dato_ImpresionBindingSource;
    }
}