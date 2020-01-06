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
        private Receipt _receipt;
        private List<ProductDetailsView> _detalleProducto;
        private int _cantidadTotal;
        private decimal _importeTotal;
        private string _numeroComprobante;

        public ReceiptGenerator(int tipoComprobanteId)
        {
            _facturaElectronica = new FacturaElectronica();
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _receipt = new Receipt();
            _receipt.ReceiptNumber = _facturaElectronica.GetLastReceiptNumber(tipoComprobanteId) + 1;
            _receipt.PointOfSale = Configuracion.PuntoVenta;
            _receipt.ReceiptTypeID = tipoComprobanteId;
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
            stringBuilder.Append(_receipt.ReceiptNumber.ToString("D8"));
            return stringBuilder.ToString();
        }

        public void AgregarProducto(string codigoProducto, int cantidad)
        {
            var query = _unitOfWork.Producto.Get(x => x.Code == codigoProducto);

            ProductDetailsView detalle = new ProductDetailsView();
            detalle.ProductID = query.ID;
            detalle.Code = query.Code;
            detalle.Name = query.Description;
            detalle.Quantity = cantidad;
            detalle.UnitPrice = query.UnitPrice;
            detalle.VatAliquot = query.Vat.Aliquot;

            _detalleProducto.Add(detalle);
            CantidadTotal = _detalleProducto.Sum(x => x.Quantity);
            ImporteTotal = _detalleProducto.Sum(x => x.Subtotal);
        }

        public void AgregarCliente(string razonSocial, int tipoDocumentoID, string numeroDocumento, int tipoResponsableID, string domicilio)
        {
            Client cliente = new Client();
            cliente.BusinessName = razonSocial;
            cliente.DocumentTypeID = tipoDocumentoID;
            cliente.DocumentNumber = numeroDocumento;
            cliente.FiscalConditionID = tipoResponsableID;
            cliente.Address = domicilio;
            _receipt.Client = cliente;
        }

        public Receipt GenerarComprobante(int conceptTypeId)
        {
            if (_detalleProducto.Count == 0)
            {
                throw new ArgumentException("No se pudo generar el comprobante porque no se cargo ningún producto");
            }
            else
            {
                _receipt.ConceptTypeID = conceptTypeId;
                _receipt.ReceiptDate = DateTime.Now;
                _receipt.CurrencyType = _unitOfWork.TipoMoneda.Get(x => x.ID == 2);
                _receipt.CurrencyExchangeRate = 1;
                _receipt.NetAmount = _detalleProducto.Sum(x => x.TaxBase);
                _receipt.NotTaxedNetAmount = 0;
                _receipt.ExemptAmount = 0;
                _receipt.VatTotalAmount = _detalleProducto.Sum(x => x.VatAmount);
                _receipt.TotalAmount = _receipt.NetAmount + _receipt.NotTaxedNetAmount + _receipt.ExemptAmount + _receipt.VatTotalAmount + _receipt.TributeTotalAmount;

                foreach (var item in _detalleProducto)
                {
                    ReceiptDetails details = new ReceiptDetails();
                    details.ReceiptID = _receipt.ID;
                    details.Item = _unitOfWork.Producto.Get(x => x.ID == item.ProductID);
                    details.Quantity = item.Quantity;
                    details.VatAmount = item.VatAmount;
                    details.TaxBase = item.TaxBase;
                    details.Subtotal = item.Subtotal;

                    _receipt.ReceiptDetails.Add(details);
                }

                if (_receipt.Client == null)
                {
                    Client cliente = new Client();
                    cliente = _unitOfWork.Cliente.Get(x => x.BusinessName == "CONSUMIDOR FINAL");
                    _receipt.Client = cliente;
                }

                var response = _facturaElectronica.GenerateReceipt(_receipt);

                if (response.CabeceraResponse.Resultado != "A")
                {
                    foreach (var item in response.DetalleResponse)
                    {
                        item.Observaciones.ForEach(s => _logger.Debug(s.Mensaje));
                    }

                    if (response.Errores != null)
                    {
                        response.Errores.ForEach(s => _logger.Debug(s));
                    }
                    
                    return null;
                }
                else
                {
                    _receipt.Cae = response.DetalleResponse.Select(x => x.CAE).First();
                    _receipt.CaeExpirationDate = DateTime.ParseExact(response.DetalleResponse.Select(x => x.FechaVencimientoCAE).First(), "yyyyMMdd", CultureInfo.CurrentCulture);
                    _unitOfWork.Receipt.Add(_receipt);
                    _unitOfWork.SaveChanges();
                    return _receipt;
                }
            }
        }

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
