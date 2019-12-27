namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using NLog;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystemERP.Enums;

    public class ReceiptGenerator : INotifyPropertyChanged
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private FacturaElectronica _facturaElectronica;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private Receipt _comprobante;
        private List<ProductDetailsView> _detalleProducto;
        private int _cantidadTotal;
        private decimal _importeTotal;
        private string _numeroComprobante;

        public ReceiptGenerator(int tipoComprobanteId)
        {
            _facturaElectronica = new FacturaElectronica();
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _comprobante = new Receipt();
            _comprobante.ReceiptNumber = _facturaElectronica.ObtenerNumeroUltimoComprobante(tipoComprobanteId) + 1;
            _comprobante.PointOfSale = Configuracion.PuntoVenta;
            _comprobante.ReceiptTypeID = tipoComprobanteId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<ProductDetailsView> DetalleFacturacion
        {
            get
            {
                if (_detalleProducto == null)
                {
                    _detalleProducto = new List<ProductDetailsView>();
                }

                return _detalleProducto;
            }

            set
            {
                _detalleProducto = value;
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
                _numeroComprobante = FormatearNumeroComprobante();
                return _numeroComprobante;
            }
        }

        private string FormatearNumeroComprobante()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Configuracion.PuntoVenta.ToString("D5"));
            stringBuilder.Append(_comprobante.ReceiptNumber.ToString("D8"));
            return stringBuilder.ToString();
        }

        public void AgregarProducto(string codigoProducto, int cantidad)
        {
            var query = _unitOfWork.Producto.Get(x => x.Codigo == codigoProducto);
            ProductDetailsView detalle = new ProductDetailsView();
            detalle.ProductID = query.ID;
            detalle.Code = query.Codigo;
            detalle.Name = query.Descripcion;
            detalle.Quantity = cantidad;
            detalle.UnitPrice = query.PrecioUnitario;
            detalle.VatAliquot = query.Iva.Alicuota;

            _detalleProducto.Add(detalle);
            CantidadTotal = _detalleProducto.Sum(x => x.Quantity);
            ImporteTotal = _detalleProducto.Sum(x => x.Subtotal);
        }

        public void AgregarCliente(string razonSocial, int tipoDocumentoID, string numeroDocumento, int tipoResponsableID, string domicilio)
        {
            Cliente cliente = new Cliente();
            cliente.RazonSocial = razonSocial;
            cliente.TipoDocumentoID = tipoDocumentoID;
            cliente.NumeroDocumento = numeroDocumento;
            cliente.TipoResponsableID = tipoResponsableID;
            cliente.Domicilio = domicilio;
            _comprobante.Client = cliente;
        }

        public Receipt GenerarComprobante(int conceptTypeId)
        {
            if (_detalleProducto.Count == 0)
            {
                throw new ArgumentException("No se pudo generar el comprobante porque no se cargo ningún producto");
            }
            else
            {
                _comprobante.ConceptTypeID = conceptTypeId;
                _comprobante.ReceiptDate = DateTime.Now;
                _comprobante.CurrencyType = _unitOfWork.TipoMoneda.Get(x => x.ID == 2);
                _comprobante.CurrencyExchangeRate = 1;
                _comprobante.NetAmount = _detalleProducto.Sum(x => x.TaxBase);
                _comprobante.NotTaxedNetAmount = 0;
                _comprobante.ExemptAmount = 0;
                _comprobante.VatTotalAmount = _detalleProducto.Sum(x => x.VatAmount);
                _comprobante.TotalAmount = _comprobante.NetAmount + _comprobante.NotTaxedNetAmount + _comprobante.ExemptAmount + _comprobante.VatTotalAmount + _comprobante.TributeTotalAmount;

                foreach (var item in _detalleProducto)
                {
                    ReceiptDetails details = new ReceiptDetails();
                    details.ComprobanteID = _comprobante.ID;
                    details.Producto = _unitOfWork.Producto.Get(x => x.ID == item.ProductID);
                    details.Cantidad = item.Quantity;
                    details.ImporteIva = item.VatAmount;
                    details.BaseImponible = item.TaxBase;
                    details.Subtotal = item.Subtotal;

                    _comprobante.ReceiptDetails.Add(details);
                }

                if (_comprobante.Client == null)
                {
                    Cliente cliente = new Cliente();
                    cliente = _unitOfWork.Cliente.Get(x => x.RazonSocial == "CONSUMIDOR FINAL");
                    _comprobante.Client = cliente;
                }

                var response = _facturaElectronica.GenerarComprobante(_comprobante);

                if (response.CabeceraResponse.Resultado != "A")
                {
                    foreach (var item in response.DetalleResponse)
                    {
                        item.Observaciones.ForEach(s => _logger.Debug(s.Mensaje));
                    }

                    response.Errores.ForEach(s => _logger.Debug(s));
                    return null;
                }
                else
                {
                    _comprobante.Cae = response.DetalleResponse.Select(x => x.CAE).First();
                    _comprobante.CaeExpirationDate = DateTime.ParseExact(response.DetalleResponse.Select(x => x.FechaVencimientoCAE).First(), "yyyyMMdd", CultureInfo.CurrentCulture);
                    _unitOfWork.Receipt.Add(_comprobante);
                    _unitOfWork.SaveChanges();
                    return _comprobante;
                }
            }
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
