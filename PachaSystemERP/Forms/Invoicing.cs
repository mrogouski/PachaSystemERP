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
        private Invoice _invoice;
        private ElectronicInvoicing _electronicInvoicing;
        private InvoiceBuilder _invoiceBuilder;
        private UnitOfWork _unitOfWork;
        private InvoiceType _invoiceType;

        public Invoicing(InvoiceType invoiceType)
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _electronicInvoicing = new ElectronicInvoicing();
            _invoiceType = invoiceType;
            InitializeComponent();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            _invoiceBuilder.AddItem(TxtItemCode.Text, (int)NudQuantity.Value);
            TxtItemCode.Clear();
            TxtItemName.Clear();
            NudQuantity.Value = 1;
            NudUnitPrice.Value = 0.00M;
            NudSubtotal.Value = 0.00M;

            if (_invoiceBuilder.TotalAmount > 10000 && _invoiceBuilder.CustomerID == 1)
            {
                MessageBox.Show("Al pasarse el monto total de $10000, la identificación del cliente es obligatoria");
            }

            LoadDataGridView();
        }

        private void BtnGenerateInvoice_Click(object sender, EventArgs e)
        {
            _electronicInvoicing = new ElectronicInvoicing();
            var response = _electronicInvoicing.GenerateInvoice(_invoiceBuilder);
            if (response != null)
            {
                foreach (var item in response.DetalleResponse)
                {
                    _invoice.Cae = item.CAE;
                    _invoice.CaeExpirationDate = DateTime.ParseExact(item.FechaVencimientoCAE, "yyyyMMdd", CultureInfo.CurrentCulture);
                }
                _unitOfWork.Invoices.Add(_invoice);
                _unitOfWork.SaveChanges();

                var form = new InvoiceViewer(_invoice);
                form.ShowDialog();
                Initialize();
            }
        }

        private void Initialize()
        {
            _invoice = new Invoice();
            _invoice.ConceptType = _unitOfWork.ConceptTypes.Get(x => x.Name == "Productos");
            _invoice.InvoiceNumber = _electronicInvoicing.GetLastReceiptNumber(_invoiceType.ID) + 1;
            _invoice.CurrencyType = _unitOfWork.CurrencyTypes.Get(x => x.Code == "PES");
            _invoice.InvoiceTypeID = _invoiceType.ID;
            _invoice.InvoiceDate = DateTime.Now;
            _invoice.PointOfSale = PachaSystemApplicationConfiguration.PuntoVenta;
            _invoice.CurrencyExchangeRate = 1;
            _invoiceBuilder = new InvoiceBuilder(_invoice);

            LblInvoiceType.Text = _invoiceType.Description;
            LblReceiptNumber.Text = _invoiceBuilder.ReceiptNumber;

            TxtItemCode.Clear();
            TxtItemName.Clear();
            NudQuantity.Value = 1;
            NudUnitPrice.Value = 0;
            NudSubtotal.Value = 0;
        }

        private void LoadDataGridView()
        {
            bindingSource.DataSource = null;
            bindingSource.DataSource = from invoiceDetails in _invoice.InvoiceDetails
                                       select new 
                                       { 
                                           invoiceDetails.ItemID, 
                                           invoiceDetails.Item.Description, 
                                           invoiceDetails.Item.UnitPrice 
                                       };
            
            //bindingSource.DataSource = _invoice;
            //bindingSource.DataMember = "InvoiceDetails";

            DgvItems.DataSource = bindingSource;
            //DgvItems.Columns["ItemID"].Visible = false;
            //DgvItems.Columns["VatAliquot"].Visible = false;
            //DgvItems.Columns["VatAmount"].Visible = false;
            //DgvItems.Columns["TaxBase"].Visible = false;
        }

        private void MenuFacturacion_Load(object sender, EventArgs e)
        {
            Initialize();

            lblTotal.DataBindings.Add("Text", _invoiceBuilder, "TotalAmount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C");
            lblCantidadArticulos.DataBindings.Add("Text", _invoiceBuilder, "TotalQuantity", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void NudQuantity_ValueChanged(object sender, EventArgs e)
        {
            NudSubtotal.Value = decimal.Round(NudQuantity.Value * NudUnitPrice.Value, 2, MidpointRounding.ToEven);
        }

        private void NudUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            NudSubtotal.Value = decimal.Round(NudQuantity.Value * NudUnitPrice.Value, 2, MidpointRounding.ToEven);
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
            if (!string.IsNullOrWhiteSpace(TxtItemCode.Text))
            {
                var producto = _unitOfWork.Products.Get(x => x.Code == TxtItemCode.Text);
                if (producto != null)
                {
                    TxtItemName.Text = producto.Description;
                    NudUnitPrice.Value = producto.UnitPrice;
                }
            }
            else
            {
                TxtItemName.Clear();
                NudQuantity.Value = 1;
                NudUnitPrice.Value = 0;
                NudSubtotal.Value = 0;
            }
        }

        private void TxtItemName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtItemName.Text))
            {
                var product = _unitOfWork.Products.Get(x => x.Description == TxtItemName.Text);
                if (product != null)
                {
                    TxtItemCode.Text = product.Code;
                    NudUnitPrice.Value = product.UnitPrice;
                }
            }
        }

        private void BtnCancelItem_Click(object sender, EventArgs e)
        {
            TxtItemCode.Clear();
            TxtItemName.Clear();
            NudQuantity.Value = 1;
            NudUnitPrice.Value = 0;
            NudSubtotal.Value = 0;
        }

        private void BtnCancelInvoice_Click(object sender, EventArgs e)
        {
            Initialize();
        }

        private void BtnSelectCustomer_Click(object sender, EventArgs e)
        {
            var form = new CustomerManagement(_invoice);
            var dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                var customer = _unitOfWork.Customers.Get(x => x.ID == _invoice.CustomerID);
                if (_invoice.InvoiceTypeID == 1 && customer.DocumentTypeID != 80)
                {
                    MessageBox.Show("El cliente seleccionado es invalido para la operacion que desea realizar");
                }
                else
                {
                    _invoice.Customer = customer;
                    TxtCustomerCode.Text = _invoice.Customer.Code;
                    TxtCustomerName.Text = _invoice.Customer.BusinessName;
                }
            }
        }
    }
}