// <copyright file="UnitOfWork.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Helpers
{
    using PachaSystem.Data.Models;
    using PachaSystem.Data.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PachaSystemContext _context;
        private Repository<ItemCategory> _itemCategory;
        private Repository<TributeCategory> _tributeCategory;
        private Repository<Customer> _customers;
        private InvoiceRepository _invoice;
        private Repository<InvoiceDetails> _invoiceDetails;
        private Repository<Vat> _vat;
        private ItemRepository _item;
        private Repository<InvoiceType> _invoiceType;
        private Repository<ConceptType> _conceptType;
        private Repository<DocumentType> _documentType;
        private Repository<CurrencyType> _currencyType;
        private Repository<FiscalConditionType> _fiscalConditionType;
        private Repository<Tribute> _tributeType;
        private InvoiceViewRepository _receiptView;

        public UnitOfWork(PachaSystemContext context)
        {
            _context = context;
        }

        public Repository<ItemCategory> ItemCategories
        {
            get
            {
                if (_itemCategory != null)
                {
                    _itemCategory = new Repository<ItemCategory>(_context);
                }

                return _itemCategory;
            }
        }

        public Repository<TributeCategory> TributeCategories
        {
            get
            {
                if (_tributeCategory == null)
                {
                    _tributeCategory = new Repository<TributeCategory>(_context);
                }

                return _tributeCategory;
            }
        }

        public Repository<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new Repository<Customer>(_context);
                }

                return _customers;
            }
        }

        public InvoiceRepository Invoices
        {
            get
            {
                if (_invoice == null)
                {
                    _invoice = new InvoiceRepository(_context);
                }

                return _invoice;
            }
        }

        public Repository<InvoiceDetails> InvoiceDetails
        {
            get
            {
                if (_invoiceDetails == null)
                {
                    _invoiceDetails = new Repository<InvoiceDetails>(_context);
                }

                return _invoiceDetails;
            }
        }

        public ItemRepository Items
        {
            get
            {
                if (_item == null)
                {
                    _item = new ItemRepository(_context);
                }

                return _item;
            }
        }

        public Repository<InvoiceType> InvoiceTypes
        {
            get
            {
                if (_invoiceType == null)
                {
                    _invoiceType = new Repository<InvoiceType>(_context);
                }

                return _invoiceType;
            }
        }

        public Repository<Vat> Vat
        {
            get
            {
                if (_vat == null)
                {
                    _vat = new Repository<Vat>(_context);
                }

                return _vat;
            }
        }

        public Repository<ConceptType> ConceptTypes
        {
            get
            {
                if (_conceptType == null)
                {
                    _conceptType = new Repository<ConceptType>(_context);
                }

                return _conceptType;
            }
        }

        public Repository<DocumentType> DocumentTypes
        {
            get
            {
                if (_documentType == null)
                {
                    _documentType = new Repository<DocumentType>(_context);
                }

                return _documentType;
            }
        }

        public Repository<CurrencyType> CurrencyTypes
        {
            get
            {
                if (_currencyType == null)
                {
                    _currencyType = new Repository<CurrencyType>(_context);
                }

                return _currencyType;
            }
        }

        public Repository<FiscalConditionType> FiscalConditionTypes
        {
            get
            {
                if (_fiscalConditionType == null)
                {
                    _fiscalConditionType = new Repository<FiscalConditionType>(_context);
                }

                return _fiscalConditionType;
            }
        }

        public Repository<Tribute> Tributes
        {
            get
            {
                if (_tributeType == null)
                {
                    _tributeType = new Repository<Tribute>(_context);
                }

                return _tributeType;
            }
        }

        public InvoiceViewRepository ReceiptView
        {
            get
            {
                if (_receiptView == null)
                {
                    _receiptView = new InvoiceViewRepository();
                }

                return _receiptView;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}