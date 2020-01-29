namespace PachaSystemERP.Forms
{
    using Microsoft.Reporting.WinForms;
    using NBarCodes;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
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
        private Invoice _receipt;

        public InvoiceViewer(Invoice receipt)
        {
            _receipt = receipt;
            InitializeComponent();
        }

        private void ReceiptViewer_Load(object sender, EventArgs e)
        {
            LoadReportParameters();

            using (var context = new PachaSystemContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    this.invoiceViewBindingSource.DataSource = unitOfWork.Invoices.Get(_receipt.ID);
                    this.RvInvoice.RefreshReport();
                }
            }
        }

        private void LoadReportParameters()
        {
            var barcode = GenerateBarcode();
            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("Barcode", barcode));
            parameters.Add(new ReportParameter("NombreFantasia", Settings.Default.NombreFantasia));
            parameters.Add(new ReportParameter("RazonSocial", Settings.Default.RazonSocial));
            parameters.Add(new ReportParameter("Domicilio", Settings.Default.Domicilio));
            parameters.Add(new ReportParameter("CondicionFiscal", Settings.Default.CondicionFiscal));
            parameters.Add(new ReportParameter("CUIT", Settings.Default.CUIT.ToString()));
            parameters.Add(new ReportParameter("IngresosBrutos", Settings.Default.IngresosBrutos));
            parameters.Add(new ReportParameter("FechaInicioActividades", Settings.Default.FechaInicioActividades.ToShortDateString()));
            parameters.Add(new ReportParameter("Cabecera", "Original"));
            RvInvoice.LocalReport.SetParameters(parameters);
        }

        private string GenerateBarcode()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Settings.Default.CUIT);
            builder.Append(_receipt.InvoiceTypeID.ToString("D3"));
            builder.Append(_receipt.PointOfSale.ToString("D5"));
            builder.Append(_receipt.Cae);
            builder.Append(_receipt.CaeExpirationDate.ToString("yyyyMMdd"));

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