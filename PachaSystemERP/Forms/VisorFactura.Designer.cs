namespace PachaSystemERP.Forms
{
    partial class VisorFactura
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
            this.dataTableComprobanteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetComprobante = new PachaSystemERP.Properties.DataSources.DataSetComprobante();
            this.RvComprobante = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTableComprobanteTableAdapter = new PachaSystemERP.Properties.DataSources.DataSetComprobanteTableAdapters.DataTableComprobanteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableComprobanteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetComprobante)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTableComprobanteBindingSource
            // 
            this.dataTableComprobanteBindingSource.DataMember = "DataTableComprobante";
            this.dataTableComprobanteBindingSource.DataSource = this.dataSetComprobante;
            // 
            // dataSetComprobante
            // 
            this.dataSetComprobante.DataSetName = "DataSetComprobante";
            this.dataSetComprobante.EnforceConstraints = false;
            this.dataSetComprobante.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RvComprobante
            // 
            this.RvComprobante.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetComprobante";
            reportDataSource1.Value = this.dataTableComprobanteBindingSource;
            this.RvComprobante.LocalReport.DataSources.Add(reportDataSource1);
            this.RvComprobante.LocalReport.EnableExternalImages = true;
            this.RvComprobante.LocalReport.ReportEmbeddedResource = "PachaSystemERP.Reports.FacturaB.rdlc";
            this.RvComprobante.Location = new System.Drawing.Point(0, 0);
            this.RvComprobante.Name = "RvComprobante";
            this.RvComprobante.ServerReport.BearerToken = null;
            this.RvComprobante.Size = new System.Drawing.Size(800, 450);
            this.RvComprobante.TabIndex = 0;
            // 
            // dataTableComprobanteTableAdapter
            // 
            this.dataTableComprobanteTableAdapter.ClearBeforeFill = true;
            // 
            // VisorFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RvComprobante);
            this.Name = "VisorFactura";
            this.Text = "VisorFactura";
            this.Load += new System.EventHandler(this.VisorFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableComprobanteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetComprobante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvComprobante;
        private System.Windows.Forms.BindingSource dataTableComprobanteBindingSource;
        private Properties.DataSources.DataSetComprobante dataSetComprobante;
        private Properties.DataSources.DataSetComprobanteTableAdapters.DataTableComprobanteTableAdapter dataTableComprobanteTableAdapter;
    }
}