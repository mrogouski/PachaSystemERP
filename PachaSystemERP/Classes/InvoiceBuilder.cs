using NLog;
using PachaSystem.Data;
using PachaSystem.Data.Helpers;
using PachaSystem.Data.Models;
using PachaSystem.Wsfe.Models;
using PachaSystem.Wsfe.Requests;
using PachaSystemERP.Enums;
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
        private List<ItemDetailsView> _detalleProducto;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private ElectronicInvoicing _electronicInvoicing;
        private Invoice _invoice;
        private int _cantidadTotal;
        private decimal _importeTotal;
        private string _numeroComprobante;

        public InvoiceBuilder(int invoiceTypeId, int conceptTypeId)
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _electronicInvoicing = new ElectronicInvoicing();

            _invoice = new Invoice();
            _invoice.ReceiptNumber = _electronicInvoicing.GetLastReceiptNumber(invoiceTypeId) + 1;
            _invoice.PointOfSale = Configuracion.PuntoVenta;
            _invoice.InvoiceTypeID = invoiceTypeId;
            _invoice.ConceptTypeID = conceptTypeId;
            _invoice.ReceiptDate = DateTime.Now;
            _invoice.CurrencyType = _unitOfWork.TipoMoneda.Get(x => x.Code == "PES");
            _invoice.CurrencyExchangeRate = 1;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<ItemDetailsView> DetalleFacturacion
        {
            get
            {
                if (_detalleProducto == null)
                {
                    _detalleProducto = new List<ItemDetailsView>();
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
            stringBuilder.Append(_invoice.ReceiptNumber.ToString("D8"));
            return stringBuilder.ToString();
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

        public Invoice Build()
        {
            if (_detalleProducto.Count == 0)
            {
                throw new ArgumentException("No se pudo generar el comprobante porque no se cargo ningún producto");
            }
            else
            {
                _invoice.NetAmount = _detalleProducto.Sum(x => x.TaxBase);
                _invoice.NotTaxedNetAmount = 0;
                _invoice.ExemptAmount = 0;
                _invoice.VatTotalAmount = _detalleProducto.Sum(x => x.VatAmount);
                _invoice.TotalAmount = _invoice.NetAmount + _invoice.NotTaxedNetAmount + _invoice.ExemptAmount + _invoice.VatTotalAmount + _invoice.TributeTotalAmount;

                foreach (var item in _detalleProducto)
                {
                    ReceiptDetails details = new ReceiptDetails();
                    details.ReceiptID = _invoice.ID;
                    details.Item = _unitOfWork.Producto.Get(x => x.ID == item.ProductID);
                    details.Quantity = item.Quantity;
                    details.VatAmount = item.VatAmount;
                    details.TaxBase = item.TaxBase;
                    details.Subtotal = item.Subtotal;

                    _invoice.ReceiptDetails.Add(details);
                }

                if (_invoice.Client == null)
                {
                    Client cliente = new Client();
                    cliente = _unitOfWork.Cliente.Get(x => x.BusinessName == "CONSUMIDOR FINAL");
                    _invoice.Client = cliente;
                }

                return _invoice;
            }
        }

        public CaeRequest Build()
        {
            var request = new CaeRequest();
            request.CabeceraRequest.CantidadDeRegistros = 1;
            request.CabeceraRequest.PuntoDeVenta = Configuracion.PuntoVenta;
            request.CabeceraRequest.TipoDeComprobante = _invoice.InvoiceTypeID;

            var invoiceDetails = new CaeDetalleRequest();

            if (_invoice.AssociatedReceipt != null)
            {
                ComprobanteAsociado comprobanteAsociado = new ComprobanteAsociado();
                comprobanteAsociado.TipoDeComprobante = _invoice.AssociatedReceipt.ReceiptTypeID;
                comprobanteAsociado.PuntoDeVenta = _invoice.AssociatedReceipt.PointOfSale;
                comprobanteAsociado.NumeroDeComprobante = long.Parse(_invoice.AssociatedReceipt.ReceiptNumber);
                comprobanteAsociado.Cuit = _invoice.AssociatedReceipt.Cuit.ToString();
                comprobanteAsociado.FechaDeComprobante = _invoice.AssociatedReceipt.ReceiptDate.ToString("yyyyMMdd");
                invoiceDetails.ComprobantesAsociados.Add(comprobanteAsociado);
            }

            if (_invoice.ReceiptDetails != null)
            {
                foreach (var item in _invoice.ReceiptDetails)
                {
                    AlicuotaIva iva = new AlicuotaIva();
                    iva.ID = item.Item.VatID;
                    iva.BaseImponible = (double)item.TaxBase;
                    iva.Importe = (double)item.VatAmount;

                    switch (item.Item.Vat.ID)
                    {
                        case 1:
                            _invoice.NotTaxedNetAmount += item.VatAmount;
                            break;
                        case 2:
                            _invoice.ExemptAmount += item.VatAmount;
                            break;
                        case 3:
                            invoiceDetails.AlicuotaIVA.Add(iva);

                            _invoice.VatTotalAmount += item.VatAmount;
                            break;
                        case 4:
                            invoiceDetails.AlicuotaIVA.Add(iva);

                            _invoice.VatTotalAmount += item.VatAmount;
                            break;
                        case 5:
                            invoiceDetails.AlicuotaIVA.Add(iva);

                            _invoice.VatTotalAmount += item.VatAmount;
                            break;
                        case 6:
                            invoiceDetails.AlicuotaIVA.Add(iva);
                            _invoice.VatTotalAmount += item.VatAmount;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (_invoice.Client.BusinessName.Equals("CONSUMIDOR FINAL"))
            {
                invoiceDetails.TipoDeDocumento = _invoice.Client.DocumentTypeID;
            }
            else
            {
                invoiceDetails.TipoDeDocumento = _invoice.Client.DocumentTypeID;
                invoiceDetails.NumeroDeDocumento = long.Parse(_invoice.Client.DocumentNumber);
            }

            invoiceDetails.Concepto = _invoice.ConceptTypeID;
            invoiceDetails.ComprobanteDesde = _invoice.ReceiptNumber;
            invoiceDetails.ComprobanteHasta = _invoice.ReceiptNumber;
            invoiceDetails.FechaDeComprobante = _invoice.ReceiptDate.ToString("yyyyMMdd");
            invoiceDetails.ImporteTotal = decimal.ToDouble(_invoice.TotalAmount);
            invoiceDetails.ImporteNetoNoGravado = decimal.ToDouble(_invoice.NotTaxedNetAmount);
            invoiceDetails.ImporteNeto = decimal.ToDouble(_invoice.NetAmount);
            invoiceDetails.ImporteExento = decimal.ToDouble(_invoice.ExemptAmount);
            invoiceDetails.ImporteIVA = decimal.ToDouble(_invoice.VatTotalAmount);
            invoiceDetails.ImporteTributo = decimal.ToDouble(_invoice.TributeTotalAmount);
            invoiceDetails.CodigoMoneda = _unitOfWork.TipoMoneda.Get(x => x.ID == _invoice.CurrencyType.ID).Code;
            invoiceDetails.MonedaCotizacion = _invoice.CurrencyExchangeRate;

            request.DetalleRequest.Add(invoiceDetails);

            return request;
        }
    }
}