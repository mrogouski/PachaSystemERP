using PachaSystem.Data;
using PachaSystem.Data.Helpers;
using PachaSystem.Data.Models;
using PachaSystemERP.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace PachaSystemERP.Classes
{
    public class InvoiceBuilder : INotifyPropertyChanged
    {
        private PachaSystemContext _context;
        private Invoice _invoice;
        private List<ItemDetailsView> _invoiceDetailsView;
        private decimal _totalAmount;
        private int _totalQuantity;
        private UnitOfWork _unitOfWork;

        public InvoiceBuilder(InvoiceType invoiceType, int invoiceNumber)
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _invoice = new Invoice();
            _invoice.ConceptType = _unitOfWork.ConceptTypes.Get(x => x.Name == "Productos");
            _invoice.InvoiceNumber = invoiceNumber;
            _invoice.CurrencyType = _unitOfWork.CurrencyTypes.Get(x => x.Code == "PES");
            _invoice.InvoiceType = invoiceType;
            _invoice.InvoiceDate = DateTime.Now;
            _invoice.PointOfSale = Settings.Default.PointOfSale;
            _invoice.CurrencyExchangeRate = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int CustomerID
        {
            get
            {
                return _invoice.CustomerID;
            }
        }

        public List<ItemDetailsView> InvoiceDetailsView
        {
            get
            {
                if (_invoiceDetailsView == null)
                {
                    _invoiceDetailsView = new List<ItemDetailsView>();
                }

                return _invoiceDetailsView;
            }

            private set
            {
                _invoiceDetailsView = value;
                NotifyPropertyChanged();
            }
        }

        public string ReceiptNumber
        {
            get
            {
                var invoiceNumber = GetFormatedInvoiceNumber();
                return invoiceNumber;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return _invoice.TotalAmount;
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
                return _invoice.InvoiceDetails.Sum(x => x.Quantity);
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

        public void AddAssociatedInvoice(DateTime invoiceDate, int invoiceNumber, int invoiceTypeID)
        {
            var associatedInvoice = new AssociatedInvoice();
            associatedInvoice.Cuit = Settings.Default.CUIT;
            associatedInvoice.PointOfSale = Settings.Default.PointOfSale;
            associatedInvoice.InvoiceDate = invoiceDate;
            associatedInvoice.InvoiceNumber = invoiceNumber;
            associatedInvoice.InvoiceTypeID = invoiceTypeID;
            associatedInvoice.InvoiceID = _invoice.ID;

            _invoice.AssociatedReceipt = associatedInvoice;
        }

        public void AddCustomer(int customerID)
        {
            _invoice.CustomerID = customerID;
        }

        public void AddItem(string productCode, int quantity)
        {
            var product = _unitOfWork.Products.Get(x => x.Code == productCode);
            if (product != null)
            {
                if (_invoice.InvoiceDetails.Any(x => x.Product.ID == product.ID))
                {
                    var invoiceDetails = _invoice.InvoiceDetails.SingleOrDefault(x => x.ProductID == product.ID);
                    invoiceDetails.Quantity += quantity;
                    invoiceDetails.TaxBase = decimal.Round(product.UnitPrice * invoiceDetails.Quantity, 2, MidpointRounding.ToEven);
                    invoiceDetails.Subtotal = decimal.Round((invoiceDetails.TaxBase + invoiceDetails.VatAmount), 2, MidpointRounding.ToEven);

                    if (_invoice.InvoiceType.ID != 11)
                    {
                        switch (product.VatID)
                        {
                            case 1:
                                _invoice.NotTaxedNetAmount += invoiceDetails.TaxBase;
                                break;

                            case 2:
                                _invoice.ExemptAmount += invoiceDetails.TaxBase;
                                break;
                            default:
                                invoiceDetails.VatAliquot = product.Vat.Aliquot;
                                invoiceDetails.VatAmount = decimal.Round(invoiceDetails.TaxBase * (product.Vat.Aliquot / 100), 2, MidpointRounding.ToEven);
                                _invoice.VatTotalAmount += invoiceDetails.VatAmount;
                                _invoice.NetAmount += invoiceDetails.TaxBase;
                                break;
                        }
                    }
                    else
                    {
                        _invoice.NetAmount += invoiceDetails.TaxBase;
                    }
                }
                else
                {
                    InvoiceDetails invoiceDetails = new InvoiceDetails();
                    invoiceDetails.Product = product;
                    invoiceDetails.Quantity = quantity;
                    invoiceDetails.TaxBase = decimal.Round(product.UnitPrice * invoiceDetails.Quantity, 2, MidpointRounding.ToEven);
                    invoiceDetails.Subtotal = decimal.Round((invoiceDetails.TaxBase + invoiceDetails.VatAmount), 2, MidpointRounding.ToEven);

                    if (_invoice.InvoiceType.ID != 11)
                    {
                        switch (product.VatID)
                        {
                            case 1:
                                _invoice.NotTaxedNetAmount += invoiceDetails.TaxBase;
                                break;

                            case 2:
                                _invoice.ExemptAmount += invoiceDetails.TaxBase;
                                break;
                            default:
                                invoiceDetails.VatAliquot = product.Vat.Aliquot;
                                invoiceDetails.VatAmount = decimal.Round(invoiceDetails.TaxBase * (product.Vat.Aliquot / 100), 2, MidpointRounding.ToEven);
                                _invoice.VatTotalAmount += invoiceDetails.VatAmount;
                                _invoice.NetAmount += invoiceDetails.TaxBase;
                                break;
                        }
                    }
                    else
                    {
                        _invoice.NetAmount += invoiceDetails.TaxBase;
                    }

                    _invoice.InvoiceDetails.Add(invoiceDetails);

                    if ((_invoice.InvoiceType.ID == 1 || _invoice.InvoiceType.ID == 6) && _invoice.NetAmount > 0)
                    {
                        AddTributes();
                    }

                    _invoice.TotalAmount = _invoice.NetAmount + _invoice.NotTaxedNetAmount + _invoice.ExemptAmount + _invoice.VatTotalAmount + _invoice.TributeTotalAmount;
                }
            }

            UpdateInvoiceData();
        }

        private void UpdateInvoiceData()
        {
            _invoiceDetailsView.Clear();
            foreach (var item in _invoice.InvoiceDetails)
            {
                ItemDetailsView itemDetailsView = new ItemDetailsView();
                itemDetailsView.ItemID = item.Product.ID;
                itemDetailsView.Code = item.Product.Code;
                itemDetailsView.Description = item.Product.Description;
                itemDetailsView.UnitPrice = item.Product.UnitPrice;
                itemDetailsView.Quantity = item.Quantity;
                itemDetailsView.TaxBase = item.TaxBase;
                itemDetailsView.VatAliquot = item.VatAliquot;
                itemDetailsView.VatAmount = item.VatAmount;
                itemDetailsView.Subtotal = item.Subtotal;
                _invoiceDetailsView.Add(itemDetailsView);
            }

            TotalAmount = _invoice.TotalAmount;
            TotalQuantity = _invoice.InvoiceDetails.Sum(x => x.Quantity);
        }

        public Invoice GetInvoice()
        {
            if (_invoice.Customer == null || _invoice.Customer.ID == 0)
            {
                _invoice.Customer = _unitOfWork.Customers.Get(x => x.BusinessName == "Consumidor Final");
            }

            return _invoice;
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int InvoiceTypeID
        {
            get
            {
                if (_invoice == null)
                {
                    return 0;
                }

                return _invoice.InvoiceTypeID;
            }
        }

        private void AddTributes()
        {
            var tributes = _unitOfWork.Tributes.GetAll();

            if (tributes != null && tributes.Count() > 0)
            {
                _invoice.TributeDetails.Clear();
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

        public void AddCae(string cae, DateTime caeExpirationDate)
        {
            _invoice.Cae = cae;
            _invoice.CaeExpirationDate = caeExpirationDate;
            _unitOfWork.Invoices.Add(_invoice);
            _unitOfWork.SaveChanges();
        }
    }
}