// <copyright file="Factura.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Forms
{
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystemERP.Classes;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Invoicing : Form
    {
        private PachaSystemContext _context;
        private ElectronicInvoicing _electronicInvoicing;
        private InvoiceBuilder _invoiceBuilder;
        private InvoiceType _invoiceType;
        private UnitOfWork _unitOfWork;

        public Invoicing(InvoiceType invoiceType)
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _invoiceType = invoiceType;
            _electronicInvoicing = new ElectronicInvoicing();
            InitializeComponent();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            _invoiceBuilder.AddItem(TxtProductCode.Text, (int)NudProductQuantity.Value);
            TxtProductCode.Clear();
            TxtProductDescription.Clear();
            NudProductQuantity.Value = 1;
            NudUnitPrice.Value = 0.00M;
            NudSubtotal.Value = 0.00M;
            bindingSource.ResetBindings(false);

            if (_invoiceBuilder.TotalAmount > 10000 && _invoiceBuilder.CustomerID == 1)
            {
                MessageBox.Show("Al pasarse el monto total de $10000, la identificación del cliente es obligatoria");
            }
        }

        private void BtnCancelInvoice_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void BtnCancelItem_Click(object sender, EventArgs e)
        {
            TxtProductCode.Clear();
            TxtProductDescription.Clear();
            NudProductQuantity.Value = 1;
            NudUnitPrice.Value = 0;
            NudSubtotal.Value = 0;
        }

        private void BtnGenerateInvoice_Click(object sender, EventArgs e)
        {
            var invoice = _invoiceBuilder.GetInvoice();
            var response = _electronicInvoicing.GenerateInvoice(invoice);
            if (response != null)
            {
                foreach (var item in response.DetalleResponse)
                {
                    _invoice = _invoiceBuilder.GetInvoiceData();
                    _invoice.Cae = item.CAE;
                    _invoice.CaeExpirationDate = DateTime.ParseExact(item.FechaVencimientoCAE, "yyyyMMdd", CultureInfo.CurrentCulture);
                }

                _unitOfWork.Invoices.Add(_invoice);
                _unitOfWork.SaveChanges();

                var form = new InvoiceViewer(invoice);
                form.ShowDialog();
                Initialize();
            }
        }

        private void BtnSelectCustomer_Click(object sender, EventArgs e)
        {
            using (var form = new CustomerManagement())
            {
                var dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    if (_invoiceBuilder.InvoiceTypeID == 1 && customer.DocumentTypeID != 80)
                    {
                        MessageBox.Show("El cliente seleccionado es invalido para la operacion que desea realizar");
                    }
                    else
                    {
                        _invoiceBuilder.AddCustomer(form.CustomerID);
                        TxtCustomerCode.Text = form.Customer.Code;
                        TxtCustomerName.Text = form.Customer.BusinessName;
                    }
                }
            }
        }

        private void Initialize()
        {
            var invoiceNumber = _electronicInvoicing.GetLastReceiptNumber(_invoiceType.ID) + 1;
            _invoiceBuilder = new InvoiceBuilder(_invoiceType, invoiceNumber);

            LblInvoiceType.Text = _invoiceType.Description;
            LblReceiptNumber.Text = _invoiceBuilder.ReceiptNumber;

            TxtProductCode.Clear();
            TxtProductDescription.Clear();
            NudProductQuantity.Value = 1;
            NudUnitPrice.Value = 0;
            NudSubtotal.Value = 0;

            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            bindingSource.DataSource = _invoiceBuilder;
            bindingSource.DataMember = "InvoiceDetailsView";

            DgvItems.DataSource = bindingSource;
            DgvItems.Columns["ItemID"].Visible = false;
            DgvItems.Columns["VatAliquot"].Visible = false;
            DgvItems.Columns["VatAmount"].Visible = false;
            DgvItems.Columns["TaxBase"].Visible = false;
        }

        private void MenuFacturacion_Load(object sender, EventArgs e)
        {
            Initialize();

            lblTotal.DataBindings.Add("Text", _invoiceBuilder, "TotalAmount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C");
            lblCantidadArticulos.DataBindings.Add("Text", _invoiceBuilder, "TotalQuantity", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void NudQuantity_ValueChanged(object sender, EventArgs e)
        {
            NudSubtotal.Value = decimal.Round(NudProductQuantity.Value * NudUnitPrice.Value, 2, MidpointRounding.ToEven);
        }

        private void NudUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            NudSubtotal.Value = decimal.Round(NudProductQuantity.Value * NudUnitPrice.Value, 2, MidpointRounding.ToEven);
        }

        private void TxtItemCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtItemCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtProductCode.Text))
            {
                var producto = _unitOfWork.Products.Get(x => x.Code == TxtProductCode.Text);
                if (producto != null)
                {
                    TxtProductDescription.Text = producto.Description;
                    NudUnitPrice.Value = producto.UnitPrice;
                }
            }
            else
            {
                TxtProductDescription.Clear();
                NudProductQuantity.Value = 1;
                NudUnitPrice.Value = 0;
                NudSubtotal.Value = 0;
            }
        }

        private void TxtItemName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtProductDescription.Text))
            {
                var product = _unitOfWork.Products.Get(x => x.Description == TxtProductDescription.Text);
                if (product != null)
                {
                    TxtProductCode.Text = product.Code;
                    NudUnitPrice.Value = product.UnitPrice;
                }
            }
        }
    }
}