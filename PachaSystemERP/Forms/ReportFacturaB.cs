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
            BarcodeGenerator barcode = new BarcodeGenerator();
            pictureBox1.Image = barcode.GenerateBarcodeAFIP("01");

            //Bitmap flag = new Bitmap(200, 100);
            //Graphics flagGraphics = Graphics.FromImage(flag);
            //int red = 0;
            //int white = 11;
            //while (white <= 100)
            //{
            //    flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
            //    flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
            //    red += 20;
            //    white += 20;
            //}
            //pictureBox1.Image = flag;
        }
    }
}
