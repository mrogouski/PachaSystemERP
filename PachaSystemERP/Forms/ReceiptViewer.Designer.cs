namespace PachaSystemERP.Forms
{
    partial class ReceiptViewer
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
            this.RvReceipt = new Microsoft.Reporting.WinForms.ReportViewer();
            this.receiptViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.receiptViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RvReceipt
            // 
            this.RvReceipt.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ReceiptViewDataSet";
            reportDataSource1.Value = this.receiptViewBindingSource;
            this.RvReceipt.LocalReport.DataSources.Add(reportDataSource1);
            this.RvReceipt.LocalReport.ReportEmbeddedResource = "PachaSystemERP.Reports.Factura.rdlc";
            this.RvReceipt.Location = new System.Drawing.Point(0, 0);
            this.RvReceipt.Name = "RvReceipt";
            this.RvReceipt.ServerReport.BearerToken = null;
            this.RvReceipt.Size = new System.Drawing.Size(800, 450);
            this.RvReceipt.TabIndex = 0;
            // 
            // receiptViewBindingSource
            // 
            this.receiptViewBindingSource.DataSource = typeof(PachaSystem.Data.Views.ReceiptView);
            // 
            // ReceiptViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RvReceipt);
            this.Name = "ReceiptViewer";
            this.Text = "VisorFactura";
            this.Load += new System.EventHandler(this.ReceiptViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.receiptViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvReceipt;
        private System.Windows.Forms.BindingSource receiptViewBindingSource;
    }
}