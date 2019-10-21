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
    using PachaSystem.Data.Repository;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PachaSystemContext _context;
        private Repository<CategoriaProducto> _categoriaProducto;
        private Repository<CategoriaTributo> _categoriaTributo;
        private Repository<Cliente> _cliente;
        private ComprobanteRepository _comprobante;
        private ComprobanteClienteRepository _comprobanteCliente;
        private DetalleComprobanteRepository _detalleComprobante;
        private Repository<TipoCondicionIva> _condicionIva;
        private Repository<Producto> _producto;
        private Repository<DetalleComprobante> _productoComprobante;
        private Repository<TipoComprobante> _tipoComprobante;
        private Repository<TipoConcepto> _tipoConcepto;
        private Repository<TipoDocumento> _tipoDocumento;
        private Repository<TipoMoneda> _tipoMoneda;
        private Repository<TipoResponsable> _tipoResponsable;
        private Repository<TipoTributo> _tributo;

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

        public ComprobanteRepository Comprobante
        {
            get
            {
                if (_comprobante == null)
                {
                    _comprobante = new ComprobanteRepository(_context);
                }

                return _comprobante;
            }
        }

        public ComprobanteClienteRepository ComprobanteCliente
        {
            get
            {
                if (_comprobanteCliente == null)
                {
                    _comprobanteCliente = new ComprobanteClienteRepository(_context);
                }

                return _comprobanteCliente;
            }
        }

        public DetalleComprobanteRepository DetalleComprobante
        {
            get
            {
                if (_detalleComprobante == null)
                {
                    _detalleComprobante = new DetalleComprobanteRepository(_context);
                }

                return _detalleComprobante;
            }
        }

        public Repository<Producto> Producto
        {
            get
            {
                if (_producto == null)
                {
                    _producto = new Repository<Producto>(_context);
                }

                return _producto;
            }
        }

        public Repository<DetalleComprobante> ProductoComprobante
        {
            get
            {
                if (_productoComprobante == null)
                {
                    _productoComprobante = new Repository<DetalleComprobante>(_context);
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

        public Repository<TipoCondicionIva> TipoCondicionIva
        {
            get
            {
                if (_condicionIva == null)
                {
                    _condicionIva = new Repository<TipoCondicionIva>(_context);
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

        public Repository<TipoTributo> TipoTributo
        {
            get
            {
                if (_tributo == null)
                {
                    _tributo = new Repository<TipoTributo>(_context);
                }

                return _tributo;
            }
        }

        public void Guardar()
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
