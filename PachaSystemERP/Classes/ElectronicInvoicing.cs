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

        public ElectronicInvoicing()
        {
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
            stringBuilder.Append(PachaSystemApplicationConfiguration.PuntoVenta.ToString("D5"));
            stringBuilder.Append(receiptNumber.ToString("D8"));

            return stringBuilder.ToString();
        }

        public CaeResponse  GenerateInvoice(Invoice invoice)
        {
            var credentials = GetCredentials();
            var request = GenerateRequest(invoice);

            var response = _wsfeClient.SolicitarCae(credentials, request);

            if (response.CabeceraResponse != null && response.CabeceraResponse.Resultado == "A")
            {
                return response;
            }
            else
            {
                if (response.CabeceraResponse != null)
                {
                    foreach (var item in response.DetalleResponse)
                    {
                        if (item.Observaciones != null)
                        {
                            foreach (var observation in item.Observaciones)
                            {
                                _logger.Debug(observation.Codigo + observation.Mensaje);
                            }
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

            return null;
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

        private Credenciales GetCredentials()
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

            var credentials = new Credenciales();
            credentials.Cuit = PachaSystemApplicationConfiguration.Cuit;
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
            request.CabeceraRequest.TipoDeComprobante = invoice.InvoiceType.ID;

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

            requestDetails.TipoDeDocumento = invoice.Customer.DocumentType.ID;
            requestDetails.NumeroDeDocumento = invoice.Customer.DocumentNumber;

            foreach (var invoiceDetail in invoice.InvoiceDetails)
            {
                if (invoiceDetail.Product.Vat.ID > 2 && invoice.InvoiceType.ID != 11)
                {
                    requestDetails.AgregarIva(invoiceDetail.Product.VatID.Value, invoiceDetail.TaxBase, invoiceDetail.VatAmount);
                }
            }

            foreach (var item in invoice.TributeDetails)
            {
                requestDetails.AgregarTributo((short)item.Tribute.ID, item.Tribute.Description, item.Tribute.TaxBase, item.Tribute.Aliquot, item.Amount);
            }

            requestDetails.Concepto = invoice.ConceptType.ID;
            requestDetails.ComprobanteDesde = invoice.InvoiceNumber;
            requestDetails.ComprobanteHasta = invoice.InvoiceNumber;
            requestDetails.FechaDeComprobante = invoice.InvoiceDate.ToString("yyyyMMdd");
            requestDetails.ImporteTotal = decimal.ToDouble(invoice.TotalAmount);
            requestDetails.ImporteNetoNoGravado = decimal.ToDouble(invoice.NotTaxedNetAmount);
            requestDetails.ImporteNeto = decimal.ToDouble(invoice.NetAmount);
            requestDetails.ImporteExento = decimal.ToDouble(invoice.ExemptAmount);
            requestDetails.ImporteIVA = decimal.ToDouble(invoice.VatTotalAmount);
            requestDetails.ImporteTributo = decimal.ToDouble(invoice.TributeTotalAmount);
            requestDetails.CodigoMoneda = invoice.CurrencyType.Code;
            requestDetails.MonedaCotizacion = invoice.CurrencyExchangeRate;

            request.DetalleRequest.Add(requestDetails);

            return request;
        }
    }
}