﻿using System;
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
            var barcode = new BarcodeGenerator();

            barcode.ModuleWidth = 0.40f;
            barcode.ModuleHeight = 12;
            barcode.WideToNarrowRatio = 2.5f;
            textBox1.Text = barcode.GenerateBarcodeAFIP("20247825607001000036935743048290920190912");
        }
    }
}