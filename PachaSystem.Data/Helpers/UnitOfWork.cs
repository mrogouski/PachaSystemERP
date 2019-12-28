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
        private Repository<CategoriaProducto> _categoriaProducto;
        private Repository<CategoriaTributo> _categoriaTributo;
        private Repository<Cliente> _cliente;
        private ReceiptRepository _receipt;
        private Repository<ReceiptDetails> _detalleComprobante;
        private Repository<Iva> _condicionIva;
        private Repository<Item> _producto;
        private Repository<ReceiptDetails> _productoComprobante;
        private Repository<TipoComprobante> _tipoComprobante;
        private Repository<TipoConcepto> _tipoConcepto;
        private Repository<TipoDocumento> _tipoDocumento;
        private Repository<TipoMoneda> _tipoMoneda;
        private Repository<TipoResponsable> _tipoResponsable;
        private Repository<Tributo> _tributo;
        private ReceiptViewRepository _receiptView;

        public UnitOfWork(PachaSystemContext context)
        {
            _context = context;
        }

        public Repository<CategoriaProducto> CategoriaProducto
        {
            get
            {
                if (_categoriaProducto != null)
                {
                    _categoriaProducto = new Repository<CategoriaProducto>(_context);
                }

                return _categoriaProducto;
            }
        }

        public Repository<CategoriaTributo> CategoriaTributo
        {
            get
            {
                if (_categoriaTributo == null)
                {
                    _categoriaTributo = new Repository<CategoriaTributo>(_context);
                }

                return _categoriaTributo;
            }
        }

        public Repository<Cliente> Cliente
        {
            get
            {
                if (_cliente == null)
                {
                    _cliente = new Repository<Cliente>(_context);
                }

                return _cliente;
            }
        }

        public ReceiptRepository Receipt
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

        public Repository<ReceiptDetails> DetalleComprobante
        {
            get
            {
                if (_detalleComprobante == null)
                {
                    _detalleComprobante = new Repository<ReceiptDetails>(_context);
                }

                return _detalleComprobante;
            }
        }

        public Repository<Item> Producto
        {
            get
            {
                if (_producto == null)
                {
                    _producto = new Repository<Item>(_context);
                }

                return _producto;
            }
        }

        public Repository<ReceiptDetails> ProductoComprobante
        {
            get
            {
                if (_productoComprobante == null)
                {
                    _productoComprobante = new Repository<ReceiptDetails>(_context);
                }

                return _productoComprobante;
            }
        }

        public Repository<TipoComprobante> TipoComprobante
        {
            get
            {
                if (_tipoComprobante == null)
                {
                    _tipoComprobante = new Repository<TipoComprobante>(_context);
                }

                return _tipoComprobante;
            }
        }

        public Repository<Iva> TipoCondicionIva
        {
            get
            {
                if (_condicionIva == null)
                {
                    _condicionIva = new Repository<Iva>(_context);
                }

                return _condicionIva;
            }
        }

        public Repository<TipoConcepto> TipoConcepto
        {
            get
            {
                if (_tipoConcepto == null)
                {
                    _tipoConcepto = new Repository<TipoConcepto>(_context);
                }

                return _tipoConcepto;
            }
        }

        public Repository<TipoDocumento> TipoDocumento
        {
            get
            {
                if (_tipoDocumento == null)
                {
                    _tipoDocumento = new Repository<TipoDocumento>(_context);
                }

                return _tipoDocumento;
            }
        }

        public Repository<TipoMoneda> TipoMoneda
        {
            get
            {
                if (_tipoMoneda == null)
                {
                    _tipoMoneda = new Repository<TipoMoneda>(_context);
                }

                return _tipoMoneda;
            }
        }

        public Repository<TipoResponsable> TipoResponsable
        {
            get
            {
                if (_tipoResponsable == null)
                {
                    _tipoResponsable = new Repository<TipoResponsable>(_context);
                }

                return _tipoResponsable;
            }
        }

        public Repository<Tributo> TipoTributo
        {
            get
            {
                if (_tributo == null)
                {
                    _tributo = new Repository<Tributo>(_context);
                }

                return _tributo;
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
