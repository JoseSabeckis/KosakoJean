
namespace Presentacion.Core.Factura
{
    partial class Comprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comprobante));
            this.DetalleCajaDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VentaDto2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DetalleCajaDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VentaDto2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DetalleCajaDtoBindingSource
            // 
            this.DetalleCajaDtoBindingSource.DataSource = typeof(Servicios.Core.DetalleCaja.Dto.DetalleCajaDto);
            // 
            // reportViewer
            // 
            this.reportViewer.BackColor = System.Drawing.Color.Silver;
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetDetalleCaja";
            reportDataSource1.Value = this.VentaDto2BindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.VentaDto2BindingSource;
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Presentacion.Core.Factura.ReportComprobante.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(0, 0);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(906, 742);
            this.reportViewer.TabIndex = 0;
            // 
            // VentaDto2BindingSource
            // 
            this.VentaDto2BindingSource.DataSource = typeof(Servicios.Core.ParteVenta.Dto.VentaDto2);
            // 
            // Comprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(906, 742);
            this.Controls.Add(this.reportViewer);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(922, 726);
            this.Name = "Comprobante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comprobante";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Comprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DetalleCajaDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VentaDto2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource DetalleCajaDtoBindingSource;
        private System.Windows.Forms.BindingSource VentaDto2BindingSource;
    }
}