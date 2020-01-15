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
        private List<ItemDetailsView> _itemDetailsView;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private Invoice _invoice;
        private int _totalQuantity;
        private decimal _totalAmount;
        private string _invoiceNumber;

        public InvoiceBuilder(int invoiceTypeId, int conceptTypeId, int invoiceNumber)
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);

            _invoice = new Invoice();
            _invoice.InvoiceNumber = invoiceNumber;
            _invoice.PointOfSale = Configuracion.PuntoVenta;
            _invoice.InvoiceTypeID = invoiceTypeId;
            _invoice.ConceptTypeID = conceptTypeId;
            _invoice.ReceiptDate = DateTime.Now;
            var currencyType = _unitOfWork.CurrencyTypes.Get(x => x.Code == "PES");
            _invoice.CurrencyTypeID = currencyType.ID;
            _invoice.CurrencyExchangeRate = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

            set
            {
                _itemDetailsView = value;
                NotifyPropertyChanged();
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
                if (_totalQuantity == value)
                {
                    return;
                }

                _totalQuantity = value;
                NotifyPropertyChanged();
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
                if (_totalAmount == value)
                {
                    return;
                }

                _totalAmount = value;
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

        public void AddClient(string businessName, int documentTypeId, long documentNumber, int fiscalConditionId, string address)
        {
            Customer client = new Customer();
            client.BusinessName = businessName;
            client.DocumentTypeID = documentTypeId;
            client.DocumentNumber = documentNumber;
            client.FiscalConditionTypeID = fiscalConditionId;
            client.Address = address;
            _invoice.Client = client;
        }

        public void AddItem(string itemCode, int quantity)
        {
            var item = _unitOfWork.Items.Get(x => x.Code == itemCode);
            if (item != null)
            {
                ItemDetailsView itemDetails = new ItemDetailsView();
                itemDetails.Code = item.Code;
                itemDetails.Name = item.Description;
                itemDetails.Quantity = quantity;
                itemDetails.UnitPrice = item.UnitPrice;
                itemDetails.IsNotTaxed = item.IsNotTaxed;
                itemDetails.IsExempt = item.IsExempt;
                itemDetails.ItemID = item.ID;
                if (item.Vat != null)
                {
                    itemDetails.VatID = item.VatID.Value;
                    itemDetails.VatAliquot = item.Vat.Aliquot;
                }
                _itemDetailsView.Add(itemDetails);

                _totalAmount = _itemDetailsView.Sum(x => x.Subtotal);
                _totalQuantity = _itemDetailsView.Sum(x => x.Quantity);
            }
        }

        public void AddTributes(int tributeId, decimal amount)
        {
            var tributeDetails = new TributeDetails();
            tributeDetails.TributeID = tributeId;
            tributeDetails.Amount = amount;
            _invoice.TributeDetails.Add(tributeDetails);
        }

        public Invoice Build()
        {
            if (_itemDetailsView.Count == 0)
            {
                throw new ArgumentException("No se pudo generar el comprobante porque no se cargo ningún producto");
            }
            else
            {
                CalculateVat();

                _invoice.TotalAmount = _invoice.NetAmount + _invoice.NotTaxedNetAmount + _invoice.ExemptAmount + _invoice.VatTotalAmount + _invoice.TributeTotalAmount;

                if (_invoice.Client == null)
                {
                    var cliente = _unitOfWork.Clients.Get(x => x.BusinessName == "Consumidor Final");
                    _invoice.ClientID = cliente.ID;
                }

                return _invoice;
            }
        }

        private string GetFormatedInvoiceNumber()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Settings.Default.PointOfSale.ToString("D5"));
            stringBuilder.Append(_invoice.InvoiceNumber.ToString("D8"));
            return stringBuilder.ToString();
        }

        private void CalculateVat()
        {
            foreach (var details in _itemDetailsView)
            {
                InvoiceDetails invoiceDetails = new InvoiceDetails();
                invoiceDetails.ItemID = details.ItemID;
                invoiceDetails.Quantity = details.Quantity;
                invoiceDetails.TaxBase = details.TaxBase;
                invoiceDetails.Subtotal = details.Subtotal;

                if (details.IsNotTaxed)
                {
                    _invoice.NotTaxedNetAmount += details.TaxBase;
                }
                else if (details.IsExempt)
                {
                    _invoice.ExemptAmount += details.TaxBase;
                }
                else
                {
                    invoiceDetails.VatAmount = details.VatAmount;
                    _invoice.VatTotalAmount += details.VatAmount;
                    _invoice.NetAmount += details.TaxBase;
                }

                _invoice.InvoiceDetails.Add(invoiceDetails);
            }
        }
    }
}
