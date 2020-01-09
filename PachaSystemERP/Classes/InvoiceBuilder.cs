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
        private int _cantidadTotal;
        private decimal _importeTotal;
        private string _numeroComprobante;

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
            _invoice.CurrencyType = _unitOfWork.CurrencyTypes.Get(x => x.Code == "PES");
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
            }
        }

        public int CantidadTotal
        {
            get
            {
                return _cantidadTotal;
            }

            private set
            {
                if (_cantidadTotal == value)
                {
                    return;
                }

                _cantidadTotal = value;
                NotifyPropertyChanged();
            }
        }

        public decimal ImporteTotal
        {
            get
            {
                return _importeTotal;
            }

            private set
            {
                if (_importeTotal == value)
                {
                    return;
                }

                _importeTotal = value;
                NotifyPropertyChanged();
            }
        }

        public string ReceiptNumber
        {
            get
            {
                _numeroComprobante = GetFormatedInvoiceNumber();
                return _numeroComprobante;
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

        public void AddClient(string businessName, int documentTypeId, string documentNumber, int fiscalConditionId, string address)
        {
            Client client = new Client();
            client.BusinessName = businessName;
            client.DocumentTypeID = documentTypeId;
            client.DocumentNumber = documentNumber;
            client.FiscalConditionID = fiscalConditionId;
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
                itemDetails.ProductID = item.ID;
                itemDetails.Quantity = quantity;
                _itemDetailsView.Add(itemDetails);
            }
        }

        public void AddTributes()
        {
            Tribute tribute = new Tribute();
            tribute.
        }

        public Invoice Build()
        {
            if (_itemDetailsView.Count == 0)
            {
                throw new ArgumentException("No se pudo generar el comprobante porque no se cargo ningún producto");
            }
            else
            {
                _invoice.NetAmount = _itemDetailsView.Sum(x => x.TaxBase);
                _invoice.NotTaxedNetAmount = 0;
                _invoice.ExemptAmount = 0;
                _invoice.VatTotalAmount = _itemDetailsView.Sum(x => x.VatAmount);
                _invoice.TotalAmount = _invoice.NetAmount + _invoice.NotTaxedNetAmount + _invoice.ExemptAmount + _invoice.VatTotalAmount + _invoice.TributeTotalAmount;

                foreach (var item in _itemDetailsView)
                {
                    InvoiceDetails details = new InvoiceDetails();
                    details.InvoiceID = _invoice.ID;
                    details.Item = _unitOfWork.Items.Get(x => x.ID == item.ProductID);
                    details.Quantity = item.Quantity;
                    details.VatAmount = item.VatAmount;
                    details.TaxBase = item.TaxBase;
                    details.Subtotal = item.Subtotal;

                    _invoice.InvoiceDetails.Add(details);
                }

                if (_invoice.Client == null)
                {
                    Client cliente = new Client();
                    cliente = _unitOfWork.Clients.Get(x => x.BusinessName == "CONSUMIDOR FINAL");
                    _invoice.Client = cliente;
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
    }
}