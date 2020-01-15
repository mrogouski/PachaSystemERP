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

namespace PachaSystemERP.Forms
{
    public partial class VatTypeView : Form
    {
        public VatTypeView()
        {
            InitializeComponent();
        }

        private void VatTypeView_Load(object sender, EventArgs e)
        {
            var invoice = new ElectronicInvoicing();
            dataGridView1.DataSource = invoice.GetTributeTypes();
        }
    }
}
