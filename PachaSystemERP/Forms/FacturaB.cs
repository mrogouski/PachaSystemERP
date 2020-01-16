// <copyright file="Factura.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Forms
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystemERP.Classes;
    using PachaSystemERP.Controles;
    using PachaSystemERP.Enums;

    public partial class FacturaB : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private InvoiceBuilder _invoiceBuilder;
        private ElectronicInvoicing _electronicInvoicing;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacturaB"/>.
        /// </summary>
        public FacturaB()
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _electronicInvoicing = new ElectronicInvoicing();
            InitializeComponent();
        }

        private void MenuFacturacion_Load(object sender, EventArgs e)
        {
            Initialize();

            lblTotal.DataBindings.Add("Text", _invoiceBuilder, "TotalAmount", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C");
            lblCantidadArticulos.DataBindings.Add("Text", _invoiceBuilder, "TotalQuantity", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Initialize()
        {
            var invoiceType = _unitOfWork.InvoiceTypes.Get(x => x.Description == "FACTURA B");
            var conceptType = _unitOfWork.ConceptTypes.Get(x => x.Name == "Productos");
            var invoiceNumber = _electronicInvoicing.GetLastReceiptNumber(invoiceType.ID) + 1;
            var currencyType = _unitOfWork.CurrencyTypes.Get(x => x.Code == "PES");
            _invoiceBuilder = new InvoiceBuilder(invoiceNumber, invoiceType, conceptType, currencyType);

            LblReceiptNumber.Text = _invoiceBuilder.ReceiptNumber;

            TxtItemCode.Clear();
            TxtItemName.Clear();
            NudQuantity.Value = 1;
            NudUnitPrice.Value = 0;
            NudSubtotal.Value = 0;

            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            bindingSource.DataSource = _invoiceBuilder.InvoiceDetails;

            DgvArticles.DataSource = bindingSource;
            DgvArticles.Columns["ItemID"].Visible = false;
            DgvArticles.Columns["VatAliquot"].Visible = false;
            DgvArticles.Columns["VatAmount"].Visible = false;
            DgvArticles.Columns["TaxBase"].Visible = false;
        }

        private void TxtItemCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtItemCode.Text))
            {
                var producto = _unitOfWork.Items.Get(x => x.Code == TxtItemCode.Text);

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

        private void NudQuantity_ValueChanged(object sender, EventArgs e)
        {
            NudSubtotal.Value = decimal.Round(NudQuantity.Value * NudUnitPrice.Value, 2, MidpointRounding.ToEven);
        }

        private void NudUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            NudSubtotal.Value = decimal.Round(NudQuantity.Value * NudUnitPrice.Value, 2, MidpointRounding.ToEven);
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            _invoiceBuilder.AddItem(TxtItemCode.Text, (int)NudQuantity.Value);
            bindingSource.ResetBindings(false);
            TxtItemCode.Clear();
            TxtItemName.Clear();
            NudQuantity.Value = 1;
            NudUnitPrice.Value = 0.00M;
            NudSubtotal.Value = 0.00M;
        }

        private void BtnGenerateInvoice_Click(object sender, EventArgs e)
        {
            _electronicInvoicing = new ElectronicInvoicing();
            var invoice = _electronicInvoicing.GenerateInvoice(_invoiceBuilder);
            if (invoice != null)
            {
                var form = new ReceiptViewer(invoice);
                form.ShowDialog();
            }

            Initialize();
        }

        private void TxtItemName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxtItemName.Text))
            {
                var query = _unitOfWork.Items.Get(x => x.Description == TxtItemName.Text);
                if (query != null)
                {
                    TxtItemCode.Text = query.Code;
                    NudUnitPrice.Value = query.UnitPrice;
                }
            }
        }
    }
}