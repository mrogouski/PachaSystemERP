using PachaSystem.Data;
using PachaSystem.Data.Helpers;
using PachaSystem.Data.Models;
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

        public int CustomerID { get; set; }

        public CustomerManagement()
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            InitializeComponent();
        }

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

            var selectColumn = new DataGridViewButtonColumn();
            selectColumn.HeaderText = string.Empty;
            selectColumn.Name = "select";
            selectColumn.Text = "Seleccionar";
            selectColumn.UseColumnTextForButtonValue = true;
            DgvCustomers.Columns.Add(selectColumn);
        }

        private void DgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn
                && e.RowIndex >= 0)
            {
                var customerID = (int)DgvCustomers["ID", e.RowIndex].Value;
                CustomerID = customerID;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
