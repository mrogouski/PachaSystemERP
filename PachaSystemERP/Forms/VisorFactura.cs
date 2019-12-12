namespace PachaSystemERP.Forms
{
    using Microsoft.Reporting.WinForms;
    using NBarCodes;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystem.Data.Views;
    using PachaSystemERP.Classes;
    using PachaSystemERP.Properties;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class VisorFactura : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private Comprobante _comprobante;
        List<ComprobanteView> _comprobanteView;
        public VisorFactura(Comprobante comprobante)
        {
            _comprobante = comprobante;
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _comprobanteView = _unitOfWork.Comprobante.Obtener(comprobante.ID);
            InitializeComponent();
        }

        private void VisorFactura_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'dataSetComprobante.DataTableComprobante' table. You can move, or remove it, as needed.
            //this.dataTableComprobanteTableAdapter.Fill(this.dataSetComprobante.DataTableComprobante, _comprobante.ID);
            bindingSourceComprobante.DataSource = _comprobanteView;

            StringBuilder builder = new StringBuilder();
            builder.Append(Settings.Default.CUIT);
            builder.Append(_comprobante.TipoComprobanteID.ToString("D3"));
            builder.Append(Settings.Default.PuntoVenta.ToString("D5"));
            builder.Append(_comprobante.CAE);
            builder.Append(_comprobante.FechaVencimientoCAE.ToString("yyyyMMdd"));

            BarCodeSettings settings = new BarCodeSettings();
            //settings.Data = "20247825607001000036935743048290920190912";
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

            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("Barcode", base64String));
            parameters.Add(new ReportParameter("NombreFantasia", Settings.Default.NombreFantasia));
            parameters.Add(new ReportParameter("RazonSocial", Settings.Default.RazonSocial));
            parameters.Add(new ReportParameter("Domicilio", Settings.Default.Domicilio));
            parameters.Add(new ReportParameter("CondicionFiscal", Settings.Default.CondicionFiscal));
            parameters.Add(new ReportParameter("CUIT", Settings.Default.CUIT));
            parameters.Add(new ReportParameter("IngresosBrutos", Settings.Default.IngresosBrutos));
            parameters.Add(new ReportParameter("FechaInicioActividades", Settings.Default.FechaInicioActividades.ToShortDateString()));
            parameters.Add(new ReportParameter("Cabecera", "Original"));
            RvComprobante.LocalReport.SetParameters(parameters);

            this.RvComprobante.RefreshReport();
            this.RvComprobante.RefreshReport();
            this.RvComprobante.RefreshReport();
            this.RvComprobante.RefreshReport();
        }
    }
}