// <copyright file="FacturaElectronica.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
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
    using PachaSystemERP.Enums;

    public class FacturaElectronica
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private static readonly string _servicio = "wsfe";
        private string _token;
        private string _sign;
        private WsaaClient _wsaaClient;
        private WsfeClient _wsfeClient;
        private bool _testing;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacturaElectronica"/>.
        /// </summary>
        public FacturaElectronica()
        {
            if (Configuracion.ModoDeOperacion == ModoOperacion.Homologacion)
            {
                _wsaaClient = new WsaaClient("WsaaHomologacion");
                _wsfeClient = new WsfeClient("WsfeHomologacion");
                _testing = true;
            }
            else if (Configuracion.ModoDeOperacion == ModoOperacion.Produccion)
            {
                _wsaaClient = new WsaaClient("WsaaProduccion");
                _wsfeClient = new WsfeClient("WsfeProduccion");
                _testing = false;
            }

            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        public string SinchronizeReceiptNumber(int receiptTypeId)
        {
            if (receiptTypeId != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(receiptTypeId));
            }

            int receiptNumber = GetLastReceiptNumber(receiptTypeId) + 1;

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
        public CaeResponse GenerateReceipt(Receipt receipt)
        {
            try
            {
                if (receipt == null)
                {
                    throw new ArgumentNullException(nameof(receipt));
                }

                GetCredentials();

                Credentials credentials = new Credentials
                {
                    Cuit = Configuracion.Cuit,
                    Sign = _sign,
                    Token = _token,
                };

                var request = new CaeRequest();
                request.CabeceraRequest.CantidadDeRegistros = 1;
                request.CabeceraRequest.PuntoDeVenta = Configuracion.PuntoVenta;
                request.CabeceraRequest.TipoDeComprobante = receipt.ReceiptTypeID;

                var detalles = new CaeDetalleRequest();

                if (receipt.AssociatedReceipt != null)
                {
                    ComprobanteAsociado comprobanteAsociado = new ComprobanteAsociado();
                    comprobanteAsociado.TipoDeComprobante = receipt.AssociatedReceipt.ReceiptTypeID;
                    comprobanteAsociado.PuntoDeVenta = receipt.AssociatedReceipt.PointOfSale;
                    comprobanteAsociado.NumeroDeComprobante = long.Parse(receipt.AssociatedReceipt.ReceiptNumber);
                    comprobanteAsociado.Cuit = receipt.AssociatedReceipt.Cuit.ToString();
                    comprobanteAsociado.FechaDeComprobante = receipt.AssociatedReceipt.ReceiptDate.ToString("yyyyMMdd");
                    detalles.ComprobantesAsociados.Add(comprobanteAsociado);
                }

                if (receipt.ReceiptDetails != null)
                {
                    foreach (var item in receipt.ReceiptDetails)
                    {
                        AlicuotaIva iva = new AlicuotaIva();
                        iva.ID = item.Item.VatID;
                        iva.BaseImponible = (double)item.TaxBase;
                        iva.Importe = (double)item.VatAmount;

                        switch (item.Item.Vat.ID)
                        {
                            case 1:
                                receipt.NotTaxedNetAmount += item.VatAmount;
                                break;
                            case 2:
                                receipt.ExemptAmount += item.VatAmount;
                                break;
                            case 3:
                                detalles.AlicuotaIVA.Add(iva);

                                receipt.VatTotalAmount += item.VatAmount;
                                break;
                            case 4:
                                detalles.AlicuotaIVA.Add(iva);

                                receipt.VatTotalAmount += item.VatAmount;
                                break;
                            case 5:
                                detalles.AlicuotaIVA.Add(iva);

                                receipt.VatTotalAmount += item.VatAmount;
                                break;
                            case 6:
                                detalles.AlicuotaIVA.Add(iva);
                                receipt.VatTotalAmount += item.VatAmount;
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (receipt.Client.BusinessName.Equals("CONSUMIDOR FINAL"))
                {
                    detalles.TipoDeDocumento = receipt.Client.DocumentTypeID;
                }
                else
                {
                    detalles.TipoDeDocumento = receipt.Client.DocumentTypeID;
                    detalles.NumeroDeDocumento = long.Parse(receipt.Client.DocumentNumber);
                }

                detalles.Concepto = receipt.ConceptTypeID;
                detalles.ComprobanteDesde = receipt.ReceiptNumber;
                detalles.ComprobanteHasta = receipt.ReceiptNumber;
                detalles.FechaDeComprobante = receipt.ReceiptDate.ToString("yyyyMMdd");
                detalles.ImporteTotal = decimal.ToDouble(receipt.TotalAmount);
                detalles.ImporteNetoNoGravado = decimal.ToDouble(receipt.NotTaxedNetAmount);
                detalles.ImporteNeto = decimal.ToDouble(receipt.NetAmount);
                detalles.ImporteExento = decimal.ToDouble(receipt.ExemptAmount);
                detalles.ImporteIVA = decimal.ToDouble(receipt.VatTotalAmount);
                detalles.ImporteTributo = decimal.ToDouble(receipt.TributeTotalAmount);
                detalles.CodigoMoneda = _unitOfWork.TipoMoneda.Get(x => x.ID == receipt.CurrencyType.ID).Code;
                detalles.MonedaCotizacion = receipt.CurrencyExchangeRate;
                request.DetalleRequest.Add(detalles);

                var response = _wsfeClient.SolicitarCae(credentials, request);
                if (response == null)
                {
                    throw new ArgumentNullException("response");
                }
                else
                {
                    if (response.Errores != null)
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

                    return response;
                }
            }
            catch (FaultException)
            {

                throw;
            }
        }

        public TipoDeComprobanteResponse GetReceiptTypes()
        {
            GetCredentials();
            Credentials credentials = new Credentials();
            credentials.Cuit = Configuracion.Cuit;
            credentials.Sign = _sign;
            credentials.Token = _token;

            try
            {
                var response = _wsfeClient.ObtenerTiposDeComprobante(credentials);
                return response;
            }
            catch (FaultException)
            {

                throw;
            }
        }

        public IEnumerable<TipoDeDocumento> ObtenerTiposDeDocumento()
        {
            GetCredentials();
            Credentials credenciales = new Credentials();
            credenciales.Cuit = Configuracion.Cuit;
            credenciales.Sign = _sign;
            credenciales.Token = _token;
            try
            {
                var response = _wsfeClient.ObtenerTiposDeDocumento(credenciales);
                if (response.Errores != null)
                {
                    //throw new WsfeClientException();
                }

                return response.TiposDeDocumento;
            }
            catch (FaultException)
            {

                throw;
            }
        }

        public IList<TipoDeTributo> ObtenerTiposDeTributo()
        {
            GetCredentials();
            Credentials credenciales = new Credentials();
            credenciales.Cuit = Configuracion.Cuit;
            credenciales.Sign = _sign;
            credenciales.Token = _token;
            try
            {
                var response = _wsfeClient.ObtenerTiposDeTributo(credenciales);
                if (response.Errores != null)
                {
                    //throw new WsfeClientException();
                }

                return response.TiposDeTributo;
            }
            catch (FaultException)
            {

                throw;
            }
        }

        public IEnumerable<TipoDeMoneda> ObtenerTiposDeMoneda()
        {
            GetCredentials();

            Credentials credenciales = new Credentials
            {
                Cuit = Configuracion.Cuit,
                Sign = _sign,
                Token = _token
            };

            try
            {
                var response = _wsfeClient.ObtenerTiposDeMoneda(credenciales);
                if (response.Errores != null)
                {
                    //throw new WsfeClientException();
                }

                return response.TiposDeMoneda;
            }
            catch (FaultException)
            {

                throw;
            }
        }

        public int GetLastReceiptNumber(int tipoComprobante)
        {
            GetCredentials();
            Credentials credenciales = new Credentials();
            credenciales.Cuit = Configuracion.Cuit;
            credenciales.Sign = _sign;
            credenciales.Token = _token;

            var puntoDeVenta = Configuracion.PuntoVenta;
            try
            {
                var response = _wsfeClient.ObtenerUltimoComprobante(credenciales, puntoDeVenta, tipoComprobante);
                return response.NumeroDeComprobante;
            }
            catch (FaultException)
            {

                throw;
            }
        }

        public DummyResponse GetConnectionStatus()
        {
            var response = _wsfeClient.ObtenerEstadoDelServicio();
            return response;
        }

        /// <summary>
        /// Solicita la autorizacion de acceso al Web Service especificado.
        /// </summary>
        private void GetCredentials()
        {
            if (LeerCredenciales() == false)
            {
                var resultado = SolicitarAutorizacion();
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(resultado);
                _token = xml.SelectSingleNode("//token").InnerText;
                _sign = xml.SelectSingleNode("//sign").InnerText;
                if (!Directory.Exists(@".\Resources\"))
                {
                    Directory.CreateDirectory(@".\Resources\");
                }

                xml.Save(@".\Resources\Credenciales.xml");
            }
        }

        /// <summary>
        /// Lee las credenciales de acceso al Web Service para obtener el Token y Sign.
        /// </summary>
        /// <returns>Devuelve un valor que indica si se pudo obtener las credenciales o no.</returns>
        private bool LeerCredenciales()
        {
            if (!File.Exists(@".\Resources\Credenciales.xml"))
            {
                return false;
            }
            else
            {
                var xml = new XmlDocument();
                xml.Load(@".\Resources\Credenciales.xml");
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
        private string SolicitarAutorizacion()
        {
            try
            {
                var tique = TiqueAcceso.ObtenerTique(_testing, _servicio);
                var request = new LoginRequest(tique);

                var response = _wsaaClient.Login(request);
                return response.Credenciales;
            }
            catch (FaultException)
            {
                throw;
            }
        }
    }
}