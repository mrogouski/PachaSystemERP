// <copyright file="FacturaElectronica.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
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
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.ServiceModel;
    using System.Text;
    using System.Xml;

    public class ElectronicInvoicing
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private string _token;
        private string _sign;
        private WsaaClient _wsaaClient;
        private WsfeClient _wsfeClient;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

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

        public Invoice GenerateInvoice(InvoiceBuilder builder)
        {
            var credentials = GetCredentials();
            var invoice = builder.GetInvoiceData();
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
            else
            {
                if (response.CabeceraResponse != null)
                {
                    foreach (var item in response.DetalleResponse)
                    {
                        foreach (var observation in item.Observaciones)
                        {
                            _logger.Debug(observation.Codigo + observation.Mensaje);
                        }
                    }
                }
                if (response.Errores != null)
                {
                    foreach (var item in response.Errores)
                    {
                        _logger.Debug(item.Codigo + item.Mensaje);
                    }
                }
                if (response.Eventos != null)
                {
                    foreach (var item in response.Eventos)
                    {
                        _logger.Debug(item.Codigo + item.Mensaje);
                    }
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

        public List<TipoDeTributo> GetTributeTypes()
        {
            var credentials = GetCredentials();
            var response = _wsfeClient.ObtenerTiposDeTributo(credentials);

            return response.TiposDeTributo;
        }

        public List<TipoDeMoneda> GetCurrencyTypes()
        {
            var credentials = GetCredentials();
            var response = _wsfeClient.ObtenerTiposDeMoneda(credentials);

            return response.TiposDeMoneda;
        }

        public List<TipoDeIva> GetVatTypes()
        {
            var credentials = GetCredentials();
            var response = _wsfeClient.ObtenerTiposDeIva(credentials);

            return response.TiposDeIva;
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

            var requestDetails = new CaeDetalleRequest();

            if (invoice.AssociatedReceipt != null)
            {
                ComprobanteAsociado comprobanteAsociado = new ComprobanteAsociado();
                comprobanteAsociado.TipoDeComprobante = invoice.AssociatedReceipt.InvoiceTypeID;
                comprobanteAsociado.PuntoDeVenta = invoice.AssociatedReceipt.PointOfSale;
                comprobanteAsociado.NumeroDeComprobante = invoice.AssociatedReceipt.InvoiceNumber;
                comprobanteAsociado.Cuit = invoice.AssociatedReceipt.Cuit.ToString();
                comprobanteAsociado.FechaDeComprobante = invoice.AssociatedReceipt.InvoiceDate.ToString("yyyyMMdd");
                requestDetails.ComprobantesAsociados.Add(comprobanteAsociado);
            }

            var client = _unitOfWork.Customers.Get(x => x.ID == invoice.ClientID);
            requestDetails.TipoDeDocumento = client.DocumentTypeID;
            requestDetails.NumeroDeDocumento = client.DocumentNumber;

            foreach (var invoiceDetail in invoice.InvoiceDetails)
            {
                var query = _unitOfWork.Items.Get(x => x.ID == invoiceDetail.ItemID);
                if (query.VatID > 2)
                {
                    requestDetails.AgregarIva(query.VatID.Value, invoiceDetail.TaxBase, invoiceDetail.VatAmount);
                }
            }

            foreach (var item in invoice.TributeDetails)
            {
                var query = _unitOfWork.Tributes.Get(x => x.ID == item.TributeID);
                requestDetails.AgregarTributo((short)query.ID, query.Description, query.TaxBase, query.Aliquot, item.Amount);
            }

            requestDetails.Concepto = invoice.ConceptTypeID;
            requestDetails.ComprobanteDesde = invoice.InvoiceNumber;
            requestDetails.ComprobanteHasta = invoice.InvoiceNumber;
            requestDetails.FechaDeComprobante = invoice.InvoiceDate.ToString("yyyyMMdd");
            requestDetails.ImporteTotal = decimal.ToDouble(invoice.TotalAmount);
            requestDetails.ImporteNetoNoGravado = decimal.ToDouble(invoice.NotTaxedNetAmount);
            requestDetails.ImporteNeto = decimal.ToDouble(invoice.NetAmount);
            requestDetails.ImporteExento = decimal.ToDouble(invoice.ExemptAmount);
            requestDetails.ImporteIVA = decimal.ToDouble(invoice.VatTotalAmount);
            requestDetails.ImporteTributo = decimal.ToDouble(invoice.TributeTotalAmount);
            requestDetails.CodigoMoneda = _unitOfWork.CurrencyTypes.Get(x => x.ID == invoice.CurrencyTypeID).Code;
            requestDetails.MonedaCotizacion = invoice.CurrencyExchangeRate;

            request.DetalleRequest.Add(requestDetails);

            return request;
        }
    }
}