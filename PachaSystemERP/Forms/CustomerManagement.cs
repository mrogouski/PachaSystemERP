using PachaSystem.Data;
using PachaSystem.Data.Helpers;
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
    public partial class CustomerManagement : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        public CustomerManagement()
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            InitializeComponent();
        }

        public int CustomerID { get; set; }

        private void CustomerManagement_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void BtnNewCustomer_Click(object sender, EventArgs e)
        {
            var form = new CustomerEntry();
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Initialize();
            }
        }

        private void Initialize()
        {
            DgvCustomers.DataSource = _unitOfWork.Customers.GetAll();
        }
    }
}
