// <copyright file="UnitOfWork.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PachaSystem.Data.Models;
    using PachaSystem.Data.Repositories;
    using PachaSystem.Data.Views;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PachaSystemContext _context;
        private Repository<ItemCategory> _itemCategory;
        private Repository<TributeCategory> _tributeCategory;
        private Repository<Client> _client;
        private ReceiptRepository _receipt;
        private Repository<InvoiceDetails> _receiptDetails;
        private Repository<Vat> _vat;
        private Repository<Item> _item;
        private Repository<InvoiceType> _receiptType;
        private Repository<ConceptType> _conceptType;
        private Repository<DocumentType> _documentType;
        private Repository<CurrencyType> _currencyType;
        private Repository<FiscalConditionType> _fiscalConditionType;
        private Repository<Tribute> _tributeType;
        private ReceiptViewRepository _receiptView;

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

        public Repository<Client> Clients
        {
            get
            {
                if (_client == null)
                {
                    _client = new Repository<Client>(_context);
                }

                return _client;
            }
        }

        public ReceiptRepository Invoices
        {
            get
            {
                if (_receipt == null)
                {
                    _receipt = new ReceiptRepository(_context);
                }

                return _receipt;
            }
        }

        public Repository<InvoiceDetails> InvoiceDetails
        {
            get
            {
                if (_receiptDetails == null)
                {
                    _receiptDetails = new Repository<InvoiceDetails>(_context);
                }

                return _receiptDetails;
            }
        }

        public Repository<Item> Items
        {
            get
            {
                if (_item == null)
                {
                    _item = new Repository<Item>(_context);
                }

                return _item;
            }
        }

        public Repository<InvoiceType> InvoiceTypes
        {
            get
            {
                if (_receiptType == null)
                {
                    _receiptType = new Repository<InvoiceType>(_context);
                }

                return _receiptType;
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

        public ReceiptViewRepository ReceiptView
        {
            get
            {
                if (_receiptView == null)
                {
                    _receiptView = new ReceiptViewRepository();
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
        #endregion
    }
}
