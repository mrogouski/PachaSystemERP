using PachaSystemERP.Classes;
using System;
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