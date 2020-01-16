using NLog;
using PachaSystem.Data;
using PachaSystem.Data.Helpers;
using PachaSystem.Data.Models;
using PachaSystem.Wsfe.Models;
using PachaSystem.Wsfe.Requests;
using PachaSystemERP.Enums;
using PachaSystemERP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PachaSystemERP.Classes
{
    public class InvoiceBuilder : INotifyPropertyChanged
    {
        private PachaSystemContext _context;
        private Invoice _invoice;
        private string _invoiceNumber;
        private List<ItemDetailsView> _itemDetailsView;
        private decimal _totalAmount;
        private int _totalQuantity;
        private UnitOfWork _unitOfWork;
        public InvoiceBuilder(int invoiceNumber, InvoiceType invoiceType, ConceptType conceptType, CurrencyType currencyType)
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _invoice = new Invoice();
            _invoice.InvoiceNumber = invoiceNumber;
            _invoice.PointOfSale = Configuracion.PuntoVenta;
            _invoice.InvoiceTypeID = invoiceType.ID;
            _invoice.ConceptTypeID = conceptType.ID;
            _invoice.ReceiptDate = DateTime.Now;
            _invoice.CurrencyTypeID = currencyType.ID;
            _invoice.CurrencyExchangeRate = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<ItemDetailsView> InvoiceDetails
        {
            get
            {
                if (_itemDetailsView == null)
                {
                    _itemDetailsView = new List<ItemDetailsView>();
                }

                return _itemDetailsView;
            }

            private set
            {
                _itemDetailsView = value;
                NotifyPropertyChanged();
            }
        }

        public string ReceiptNumber
        {
            get
            {
                _invoiceNumber = GetFormatedInvoiceNumber();
                return _invoiceNumber;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return _totalAmount;
            }

            private set
            {
                if (_totalAmount != value)
                {
                    _totalAmount = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public int TotalQuantity
        {
            get
            {
                return _totalQuantity;
            }

            private set
            {
                if (_totalQuantity != value)
                {
                    _totalQuantity = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void AddAssociatedInvoice(DateTime invoiceDate, int invoiceNumber)
        {
            var associatedInvoice = new AssociatedInvoice();
            associatedInvoice.Cuit = Settings.Default.CUIT;
            associatedInvoice.PointOfSale = Settings.Default.PointOfSale;
            associatedInvoice.InvoiceDate = invoiceDate;
            associatedInvoice.InvoiceNumber = invoiceNumber;
            associatedInvoice.InvoiceTypeID = _invoice.InvoiceTypeID;
            associatedInvoice.InvoiceID = _invoice.ID;

            _invoice.AssociatedReceipt = associatedInvoice;
        }

        public void AddCustomer(int customerID)
        {
            _invoice.ClientID = customerID;
        }

        public void AddItem(string itemCode, int quantity)
        {
            var item = _unitOfWork.Items.Get(x => x.Code == itemCode);
            if (item != null)
            {
                InvoiceDetails invoiceDetails = new InvoiceDetails();
                invoiceDetails.ItemID = item.ID;
                invoiceDetails.Quantity = quantity;
                invoiceDetails.TaxBase = decimal.Round(item.UnitPrice * quantity, 2, MidpointRounding.ToEven);
                invoiceDetails.Subtotal = decimal.Round((invoiceDetails.TaxBase + invoiceDetails.VatAmount), 2, MidpointRounding.ToEven);

                switch (item.VatID)
                {
                    case 1:
                        _invoice.NotTaxedNetAmount += invoiceDetails.TaxBase;
                        break;
                    case 2:
                        _invoice.ExemptAmount += invoiceDetails.TaxBase;
                        break;
                    default:
                        invoiceDetails.VatAliquot = item.Vat.Aliquot;
                        invoiceDetails.VatAmount = decimal.Round(invoiceDetails.TaxBase * (item.Vat.Aliquot / 100), 2, MidpointRounding.ToEven);
                        _invoice.VatTotalAmount += invoiceDetails.VatAmount;
                        _invoice.NetAmount += invoiceDetails.TaxBase;
                        break;
                }

                _invoice.InvoiceDetails.Add(invoiceDetails);

                if (_invoice.InvoiceTypeID == 1 || _invoice.InvoiceTypeID == 6)
                {
                    AddTributes();
                }

                _invoice.TotalAmount = _invoice.NetAmount + _invoice.NotTaxedNetAmount + _invoice.ExemptAmount + _invoice.VatTotalAmount + _invoice.TributeTotalAmount;

                TotalAmount = _invoice.TotalAmount;
                TotalQuantity = _invoice.InvoiceDetails.Sum(x => x.Quantity);

                ItemDetailsView itemDetails = new ItemDetailsView();
                itemDetails.ItemID = invoiceDetails.ItemID;
                itemDetails.Code = item.Code;
                itemDetails.Name = item.Description;
                itemDetails.Quantity = quantity;
                itemDetails.UnitPrice = item.UnitPrice;
                itemDetails.VatAliquot = invoiceDetails.VatAliquot;
                itemDetails.VatAmount = invoiceDetails.VatAmount;
                itemDetails.TaxBase = invoiceDetails.TaxBase;
                itemDetails.Subtotal = invoiceDetails.Subtotal;
                _itemDetailsView.Add(itemDetails);
            }
        }

        public void AddNewCustomer(string businessName, int documentTypeId, long documentNumber, int fiscalConditionId, string address)
        {
            Customer client = new Customer();
            client.BusinessName = businessName;
            client.DocumentTypeID = documentTypeId;
            client.DocumentNumber = documentNumber;
            client.FiscalConditionTypeID = fiscalConditionId;
            client.Address = address;
            _invoice.Client = client;
        }

        public Invoice GetInvoiceData()
        {
            if (_invoice.Client == null)
            {
                var cliente = _unitOfWork.Clients.Get(x => x.BusinessName == "Consumidor Final");
                _invoice.ClientID = cliente.ID;
            }

            return _invoice;
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddTributes()
        {
            var tributes = _unitOfWork.Tributes.GetAll();

            if (tributes != null && tributes.Count() > 0)
            {
                foreach (var item in tributes)
                {
                    var tributeDetails = new TributeDetails();
                    tributeDetails.TributeID = item.ID;
                    tributeDetails.Aliquot = item.Aliquot;
                    if (item.IsFixedAmount)
                    {
                        tributeDetails.Amount = item.Aliquot;
                    }
                    else
                    {
                        tributeDetails.Amount = decimal.Round(_invoice.NetAmount * (item.TaxBase / 100) * (item.Aliquot / 100), 2, MidpointRounding.ToEven);
                    }

                    _invoice.TributeDetails.Add(tributeDetails);
                }

                _invoice.TributeTotalAmount = _invoice.TributeDetails.Sum(x => x.Amount);
            }
        }

        private string GetFormatedInvoiceNumber()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Settings.Default.PointOfSale.ToString("D5"));
            stringBuilder.Append(_invoice.InvoiceNumber.ToString("D8"));
            return stringBuilder.ToString();
        }
    }
}