using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PachaSystemERP.Classes;

namespace PachaSystemERP.Forms
{
    public partial class ReportFacturaB : Form
    {
        public ReportFacturaB()
        {
            InitializeComponent();
            using (var barcode = new BarcodeGenerator())
            {
                barcode.ModuleWidth = 0.191f;
                barcode.ModuleHeight = 10;
                barcode.WideToNarrowRatio = 2.5f;
                pictureBox1.Image = barcode.GenerateBarcodeAFIP("20247825607001000036935743048290920190912");
            }
        }
    }
}