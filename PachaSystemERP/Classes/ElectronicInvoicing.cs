// <copyright file="FacturaElectronica.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Security;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using NLog;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystem.Wsaa;
    using PachaSystem.Wsfe;
    using PachaSystem.Wsfe.Models;
    using PachaSystem.Wsfe.Requests;
    using PachaSystem.Wsfe.Responses;
    using PachaSystemERP.Properties;

    public class ElectronicInvoicing
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private string _token;
        private string _sign;
        private WsaaClient _wsaaClient;
        private WsfeClient _wsfeClient;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ElectronicInvoicing"/>.
        /// </summary>
        public ElectronicInvoicing()
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);

            if (Settings.Default.IsTestingMode == true)
            {
                _wsaaClient = new WsaaClient("WsaaHomologacion");
                _wsfeClient = new WsfeClient("WsfeHomologacion");
            }
            else
            {
                _wsaaClient = new WsaaClient("WsaaProduccion");
                _wsfeClient = new WsfeClient("WsfeProduccion");
            }
        }

        public string SinchronizeInvoiceNumber(int invoiceTypeId)
        {
            if (invoiceTypeId != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(invoiceTypeId));
            }

            int receiptNumber = GetLastReceiptNumber(invoiceTypeId) + 1;

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Configuracion.PuntoVenta.ToString("D5"));
            stringBuilder.Append(receiptNumber.ToString("D8"));

            return stringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public Invoice GenerateInvoice(InvoiceBuilder builder)
        {
            var credentials = GetCredentials();
            var invoice = builder.Build();
            var request = GenerateRequest(invoice);

            var response = _wsfeClient.SolicitarCae(credentials, request);

            if (response.CabeceraResponse != null && response.CabeceraResponse.Resultado == "A")
            {
                foreach (var item in response.DetalleResponse)
                {
                    invoice.Cae = item.CAE;
                    invoice.CaeExpirationDate = DateTime.ParseExact(item.FechaVencimientoCAE, "yyyyMMdd", CultureInfo.CurrentCulture);
                    using (var context = new PachaSystemContext())
                    {
                        using (var unitOfWork = new UnitOfWork(context))
                        {
                            unitOfWork.Invoices.Add(invoice);
                            unitOfWork.SaveChanges();
                        }
                    }
                }
            }
            else if (response.Errores != null)
            {
                foreach (var item in response.Errores)
                {
                    _logger.Debug(item.Codigo + item.Mensaje);
                }
            }
            else if (response.Eventos != null)
            {
                foreach (var item in response.Eventos)
                {
                    _logger.Debug(item.Codigo + item.Mensaje);
                }
            }

            return invoice;
        }

        public TipoDeComprobanteResponse GetReceiptTypes()
        {
            var credentials = GetCredentials();
            var response = _wsfeClient.ObtenerTiposDeComprobante(credentials);

            return response;
        }

        public List<TipoDeDocumento> GetInvoiceTypes()
        {
            var credentials = GetCredentials();
            var response = _wsfeClient.ObtenerTiposDeDocumento(credentials);

            return response.TiposDeDocumento;
        }

        public List<TipoDeTributo> ObtenerTiposDeTributo()
        {
            var credentials = GetCredentials();
            var response = _wsfeClient.ObtenerTiposDeTributo(credentials);

            return response.TiposDeTributo;
        }

        public List<TipoDeMoneda> ObtenerTiposDeMoneda()
        {
            var credentials = GetCredentials();
            var response = _wsfeClient.ObtenerTiposDeMoneda(credentials);

            return response.TiposDeMoneda;
        }

        public int GetLastReceiptNumber(int tipoComprobante)
        {
            var credentials = GetCredentials();
            var puntoDeVenta = Settings.Default.PointOfSale;
            var response = _wsfeClient.ObtenerUltimoComprobante(credentials, puntoDeVenta, tipoComprobante);

            return response.NumeroDeComprobante;
        }

        public DummyResponse GetConnectionStatus()
        {
            var response = _wsfeClient.ObtenerEstadoDelServicio();

            return response;
        }

        /// <summary>
        /// Solicita la autorizacion de acceso al Web Service especificado.
        /// </summary>
        private Credentials GetCredentials()
        {
            if (LoadCredentials() == false)
            {
                var response = RequestAccess();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(response);
                _token = xml.SelectSingleNode("//token").InnerText;
                _sign = xml.SelectSingleNode("//sign").InnerText;
                if (!Directory.Exists(@".\Resources\"))
                {
                    Directory.CreateDirectory(@".\Resources\");
                }

                xml.Save(@".\Resources\Credentials.xml");
            }

            var credentials = new Credentials();
            credentials.Cuit = Configuracion.Cuit;
            credentials.Sign = _sign;
            credentials.Token = _token;

            return credentials;
        }

        /// <summary>
        /// Lee las credenciales de acceso al Web Service para obtener el Token y Sign.
        /// </summary>
        /// <returns>Devuelve un valor que indica si se pudo obtener las credenciales o no.</returns>
        private bool LoadCredentials()
        {
            if (!File.Exists(@".\Resources\Credentials.xml"))
            {
                return false;
            }
            else
            {
                var xml = new XmlDocument();
                xml.Load(@".\Resources\Credentials.xml");
                var fechaExpiracion = DateTime.Parse(xml.SelectSingleNode("//expirationTime").InnerText);
                if (fechaExpiracion < DateTime.Now.AddMinutes(-5))
                {
                    return false;
                }
                else
                {
                    _token = xml.SelectSingleNode("//token").InnerText;
                    _sign = xml.SelectSingleNode("//sign").InnerText;
                    return true;
                }
            }
        }

        /// <summary>
        /// Solicita autorizacion de acceso al Web Service para obtiene el Token y Sign.
        /// </summary>
        /// <returns>Devuelve un texto en formato XML que contiene el Token, Sign, Fecha y Hora.</returns>
        private string RequestAccess()
        {
            try
            {
                var ticket = RequestAccessTicket.Get();
                var request = new LoginRequest(ticket);

                var response = _wsaaClient.Login(request);
                return response.Credentials;
            }
            catch (FaultException)
            {
                throw;
            }
        }

        private CaeRequest GenerateRequest(Invoice invoice)
        {
            var request = new CaeRequest();

            request.CabeceraRequest.CantidadDeRegistros = 1;
            request.CabeceraRequest.PuntoDeVenta = Settings.Default.PointOfSale;
            request.CabeceraRequest.TipoDeComprobante = invoice.InvoiceTypeID;

            var invoiceDetails = new CaeDetalleRequest();

            if (invoice.AssociatedReceipt != null)
            {
                ComprobanteAsociado comprobanteAsociado = new ComprobanteAsociado();
                comprobanteAsociado.TipoDeComprobante = invoice.AssociatedReceipt.InvoiceTypeID;
                comprobanteAsociado.PuntoDeVenta = invoice.AssociatedReceipt.PointOfSale;
                comprobanteAsociado.NumeroDeComprobante = long.Parse(invoice.AssociatedReceipt.InvoiceNumber);
                comprobanteAsociado.Cuit = invoice.AssociatedReceipt.Cuit.ToString();
                comprobanteAsociado.FechaDeComprobante = invoice.AssociatedReceipt.InvoiceDate.ToString("yyyyMMdd");
                invoiceDetails.ComprobantesAsociados.Add(comprobanteAsociado);
            }

            if (invoice.InvoiceDetails != null)
            {
                foreach (var item in invoice.InvoiceDetails)
                {
                    AlicuotaIva iva = new AlicuotaIva();
                    iva.ID = item.Item.VatID;
                    iva.BaseImponible = (double)item.TaxBase;
                    iva.Importe = (double)item.VatAmount;

                    switch (item.Item.Vat.ID)
                    {
                        case 1:
                            invoice.NotTaxedNetAmount += item.VatAmount;
                            break;
                        case 2:
                            invoice.ExemptAmount += item.VatAmount;
                            break;
                        case 3:
                            invoiceDetails.AlicuotaIVA.Add(iva);

                            invoice.VatTotalAmount += item.VatAmount;
                            break;
                        case 4:
                            invoiceDetails.AlicuotaIVA.Add(iva);

                            invoice.VatTotalAmount += item.VatAmount;
                            break;
                        case 5:
                            invoiceDetails.AlicuotaIVA.Add(iva);

                            invoice.VatTotalAmount += item.VatAmount;
                            break;
                        case 6:
                            invoiceDetails.AlicuotaIVA.Add(iva);
                            invoice.VatTotalAmount += item.VatAmount;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (invoice.Client.BusinessName.Equals("CONSUMIDOR FINAL"))
            {
                invoiceDetails.TipoDeDocumento = invoice.Client.DocumentTypeID;
            }
            else
            {
                invoiceDetails.TipoDeDocumento = invoice.Client.DocumentTypeID;
                invoiceDetails.NumeroDeDocumento = long.Parse(invoice.Client.DocumentNumber);
            }

            invoiceDetails.Concepto = invoice.ConceptTypeID;
            invoiceDetails.ComprobanteDesde = invoice.InvoiceNumber;
            invoiceDetails.ComprobanteHasta = invoice.InvoiceNumber;
            invoiceDetails.FechaDeComprobante = invoice.ReceiptDate.ToString("yyyyMMdd");
            invoiceDetails.ImporteTotal = decimal.ToDouble(invoice.TotalAmount);
            invoiceDetails.ImporteNetoNoGravado = decimal.ToDouble(invoice.NotTaxedNetAmount);
            invoiceDetails.ImporteNeto = decimal.ToDouble(invoice.NetAmount);
            invoiceDetails.ImporteExento = decimal.ToDouble(invoice.ExemptAmount);
            invoiceDetails.ImporteIVA = decimal.ToDouble(invoice.VatTotalAmount);
            invoiceDetails.ImporteTributo = decimal.ToDouble(invoice.TributeTotalAmount);
            invoiceDetails.CodigoMoneda = _unitOfWork.CurrencyTypes.Get(x => x.ID == invoice.CurrencyType.ID).Code;
            invoiceDetails.MonedaCotizacion = invoice.CurrencyExchangeRate;

            request.DetalleRequest.Add(invoiceDetails);

            return request;
        }
    }
}