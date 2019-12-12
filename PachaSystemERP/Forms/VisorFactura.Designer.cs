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
            this.RvComprobante = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSourceComprobante = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComprobante)).BeginInit();
            this.SuspendLayout();
            // 
            // RvComprobante
            // 
            this.RvComprobante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RvComprobante.LocalReport.ReportEmbeddedResource = "PachaSystemERP.Reports.Factura.rdlc";
            this.RvComprobante.Location = new System.Drawing.Point(0, 0);
            this.RvComprobante.Name = "RvComprobante";
            this.RvComprobante.ServerReport.BearerToken = null;
            this.RvComprobante.Size = new System.Drawing.Size(800, 450);
            this.RvComprobante.TabIndex = 0;
            // 
            // bindingSourceComprobante
            // 
            this.bindingSourceComprobante.DataSource = typeof(PachaSystem.Data.Views.ComprobanteView);
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
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComprobante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvComprobante;
        private System.Windows.Forms.BindingSource bindingSourceComprobante;
    }
}