namespace PachaSystemERP.Forms
{
    using Microsoft.Reporting.WinForms;
    using NBarCodes;
    using PachaSystem.Data.Models;
    using PachaSystemERP.Properties;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    public partial class InvoiceViewer : Form
    {
        public InvoiceViewer(Invoice invoice)
        {
            this.invoiceViewBindingSource.DataSource = invoice;
            var barcode = GenerateBarcode(invoice);
            LoadReportParameters(barcode);
            InitializeComponent();
        }

        private void ReceiptViewer_Load(object sender, EventArgs e)
        {
            this.RvInvoice.RefreshReport();
        }

        private void LoadReportParameters(string barcode)
        {
            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("Barcode", barcode));
            parameters.Add(new ReportParameter("NombreFantasia", Settings.Default.FantasyName));
            parameters.Add(new ReportParameter("RazonSocial", Settings.Default.BussinesName));
            parameters.Add(new ReportParameter("Domicilio", Settings.Default.Address));
            parameters.Add(new ReportParameter("CondicionFiscal", Settings.Default.FiscalCondition));
            parameters.Add(new ReportParameter("CUIT", Settings.Default.CUIT.ToString()));
            parameters.Add(new ReportParameter("IngresosBrutos", Settings.Default.GrossIncome));
            parameters.Add(new ReportParameter("FechaInicioActividades", Settings.Default.StartDateActivities.ToShortDateString()));
            parameters.Add(new ReportParameter("Cabecera", "Original"));
            RvInvoice.LocalReport.SetParameters(parameters);
        }

        private string GenerateBarcode(Invoice invoice)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Settings.Default.CUIT);
            builder.Append(invoice.InvoiceTypeID.ToString("D3"));
            builder.Append(invoice.PointOfSale.ToString("D5"));
            builder.Append(invoice.Cae);
            builder.Append(invoice.CaeExpirationDate.ToString("yyyyMMdd"));

            BarCodeSettings settings = new BarCodeSettings();
            settings.Data = builder.ToString();
            settings.Type = BarCodeType.Interleaved25;
            settings.UseChecksum = true;
            settings.Unit = BarCodeUnit.Pixel;
            settings.NarrowWidth = 1;
            settings.WideWidth = 2f;
            settings.BarHeight = 32;
            var font = new Font("Arial", 9f);
            settings.Font = font;
            BarCodeGenerator generator = new BarCodeGenerator(settings);

            var bitmap = new Bitmap(generator.GenerateImage());
            MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, ImageFormat.Bmp);
            byte[] imageBytes = memoryStream.ToArray();
            var base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}