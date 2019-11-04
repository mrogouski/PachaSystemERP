namespace PachaSystemERP.Forms
{
    using Microsoft.Reporting.WinForms;
    using PachaSystemERP.Classes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class VisorFactura : Form
    {
        public VisorFactura()
        {
            InitializeComponent();
        }

        private void VisorFactura_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'dataSetComprobante.DataTableComprobante' table. You can move, or remove it, as needed.
                this.dataTableComprobanteTableAdapter.Fill(this.dataSetComprobante.DataTableComprobante, 1);

            }
            catch (ConstraintException ex)
            {

                throw ex.InnerException;
            }

            var barcode = new BarcodeGenerator();

            barcode.ModuleWidth = 0.40f;
            barcode.ModuleHeight = 12;
            barcode.WideToNarrowRatio = 2.5f;
            var barcodeString = barcode.GenerateBarcodeAFIP("20247825607001000036935743048290920190912");
            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("BarcodeParameter", barcodeString));
            RvComprobante.LocalReport.SetParameters(parameters);

            this.RvComprobante.RefreshReport();
        }
    }
}
