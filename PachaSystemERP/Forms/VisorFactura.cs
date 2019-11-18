namespace PachaSystemERP.Forms
{
    using Microsoft.Reporting.WinForms;
    using NBarCodes;
    using PachaSystemERP.Classes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class VisorFactura : Form
    {
        private int _comprobanteID;
        public VisorFactura(int comprobanteID)
        {
            _comprobanteID = comprobanteID;
            InitializeComponent();
        }

        private void VisorFactura_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dataSetComprobante.DataTableComprobante' table. You can move, or remove it, as needed.
                this.dataTableComprobanteTableAdapter.Fill(this.dataSetComprobante.DataTableComprobante, _comprobanteID);

            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            BarCodeSettings settings = new BarCodeSettings();
            settings.Data = "20247825607001000036935743048290920190912";
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

            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("Barcode", base64String));
            parameters.Add(new ReportParameter("NombreFantasia", "Pacha System"));
            RvComprobante.LocalReport.SetParameters(parameters);

            this.RvComprobante.RefreshReport();
        }
    }
}
