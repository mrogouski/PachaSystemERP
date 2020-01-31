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
        private List<ItemDetailsView> _itemDetailsView;
        private decimal _totalAmount;
        private int _totalQuantity;
        private UnitOfWork _unitOfWork;

        public InvoiceBuilder(Invoice invoice)
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _invoice = invoice;
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
                var invoiceNumber = GetFormatedInvoiceNumber();
                return invoiceNumber;
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

        public int CustomerID
        {
            get
            {
                return _invoice.CustomerID;
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

        public void AddItem(string itemCode, int quantity)
        {
            var item = _unitOfWork.Products.Get(x => x.Code == itemCode);

            if (item != null)
            {
                var addedItem = _invoice.InvoiceDetails.SingleOrDefault(x => x.ItemID == item.ID);
                if (addedItem == null)
                {
                    InvoiceDetails invoiceDetails = new InvoiceDetails();
                    invoiceDetails.Item = item;
                    invoiceDetails.Quantity = quantity;
                    invoiceDetails.TaxBase = decimal.Round(item.UnitPrice * invoiceDetails.Quantity, 2, MidpointRounding.ToEven);
                    invoiceDetails.Subtotal = decimal.Round((invoiceDetails.TaxBase + invoiceDetails.VatAmount), 2, MidpointRounding.ToEven);

                    if (_invoice.InvoiceTypeID != 11)
                    {
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
                    }
                    else
                    {
                        _invoice.NetAmount += invoiceDetails.TaxBase;
                    }

                    _invoice.InvoiceDetails.Add(invoiceDetails);
                }
                else
                {
                    addedItem.Quantity += quantity;
                    addedItem.TaxBase = decimal.Round(item.UnitPrice * addedItem.Quantity, 2, MidpointRounding.ToEven);
                    addedItem.Subtotal = decimal.Round((addedItem.TaxBase + addedItem.VatAmount), 2, MidpointRounding.ToEven);

                    if (_invoice.InvoiceTypeID != 11)
                    {
                        switch (item.VatID)
                        {
                            case 1:
                                _invoice.NotTaxedNetAmount += addedItem.TaxBase;
                                break;

                            case 2:
                                _invoice.ExemptAmount += addedItem.TaxBase;
                                break;
                            default:
                                addedItem.VatAliquot = item.Vat.Aliquot;
                                addedItem.VatAmount = decimal.Round(addedItem.TaxBase * (item.Vat.Aliquot / 100), 2, MidpointRounding.ToEven);
                                _invoice.VatTotalAmount += addedItem.VatAmount;
                                _invoice.NetAmount += addedItem.TaxBase;
                                break;
                        }
                    }
                    else
                    {
                        _invoice.NetAmount += addedItem.TaxBase;
                    }
                }

                if ((_invoice.InvoiceTypeID == 1 || _invoice.InvoiceTypeID == 6) && _invoice.NetAmount > 0)
                {
                    AddTributes();
                }

                _invoice.TotalAmount = _invoice.NetAmount + _invoice.NotTaxedNetAmount + _invoice.ExemptAmount + _invoice.VatTotalAmount + _invoice.TributeTotalAmount;

                TotalAmount = _invoice.TotalAmount;
                TotalQuantity = _invoice.InvoiceDetails.Sum(x => x.Quantity);

                //ItemDetailsView itemDetails = new ItemDetailsView();
                //itemDetails.ItemID = invoiceDetails.ItemID;
                //itemDetails.Code = item.Code;
                //itemDetails.Name = item.Description;
                //itemDetails.Quantity = quantity;
                //itemDetails.UnitPrice = item.UnitPrice;
                //itemDetails.VatAliquot = invoiceDetails.VatAliquot;
                //itemDetails.VatAmount = invoiceDetails.VatAmount;
                //itemDetails.TaxBase = invoiceDetails.TaxBase;
                //itemDetails.Subtotal = invoiceDetails.Subtotal;
                //_itemDetailsView.Add(itemDetails);
            }
        }

        public Invoice GetInvoiceData()
        {
            if (_invoice.CustomerID == 0)
            {
                _invoice.Customer = _unitOfWork.Customers.Get(x => x.BusinessName == "Consumidor Final");
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
    }
}