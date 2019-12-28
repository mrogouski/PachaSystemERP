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
        private long _cuit;
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
            if (Configuracion.ModoFacturacion != ModoFacturacion.FacturaElectronica)
            {
                throw new ArgumentException("Configuración de la aplicacion inválida.");
            }

            _cuit = Configuracion.Cuit;
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

        public string SincronizarNumeroComprobante(int receiptTypeId)
        {
            if (receiptTypeId != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(receiptTypeId));
            }

            int numeroComprobante = ObtenerNumeroUltimoComprobante(receiptTypeId) + 1;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Configuracion.PuntoVenta.ToString("D5"));
            stringBuilder.Append(numeroComprobante.ToString("D8"));
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receipt"></param>
        /// <returns></returns>
        public CaeResponse GenerarComprobante(Receipt receipt)
        {
            try
            {
                if (receipt == null)
                {
                    throw new ArgumentNullException(nameof(receipt));
                }

                GetCredentials();
                Credentials autorizacion = new Credentials
                {
                    Cuit = _cuit,
                    Sign = _sign,
                    Token = _token,
                };

                var request = new CaeRequest();
                request.CabeceraRequest.CantidadDeRegistros = 1;
                request.CabeceraRequest.PuntoDeVenta = Configuracion.PuntoVenta;
                request.CabeceraRequest.TipoDeComprobante = receipt.ReceiptTypeID;

                var detalles = new CaeDetalleRequest();


                //if (comprobante.ComprobantesAsociados != null)
                //{
                //    foreach (var item in comprobante.ComprobantesAsociados)
                //    {
                //        detalles.AgregarComprobanteAsociado(item.TipoComprobanteID, item.PuntoDeVenta, item.NumeroDocumento, item.Cuit, item.FechaComprobante.ToString("yyyyMMdd"));
                //    }
                //}

                if (receipt.ReceiptDetails != null)
                {
                    foreach (var item in receipt.ReceiptDetails)
                    {
                        switch (item.Item.Vat.Name)
                        {
                            case "IVA 21%":
                                detalles.AgregarIVA(item.Item.VatID, item.TaxBase, item.VatAmount);

                                break;
                            default:
                                break;
                        }

                    }
                }

                if (receipt.Client.RazonSocial.Equals("CONSUMIDOR FINAL"))
                {
                    detalles.TipoDeDocumento = receipt.Client.TipoDocumentoID;
                }
                else
                {
                    detalles.TipoDeDocumento = receipt.Client.TipoDocumentoID;
                    detalles.NumeroDeDocumento = long.Parse(receipt.Client.NumeroDocumento);
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
                detalles.CodigoMoneda = _unitOfWork.TipoMoneda.Get(x => x.ID == receipt.CurrencyType.ID).Codigo;
                detalles.MonedaCotizacion = receipt.CurrencyExchangeRate;
                request.DetalleRequest.Add(detalles);

                var response = _wsfeClient.SolicitarCae(autorizacion, request);
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

        public TipoDeComprobanteResponse ObtenerTiposDeComprobante()
        {
            GetCredentials();
            Credentials credentials = new Credentials();
            credentials.Cuit = _cuit;
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
            credenciales.Cuit = _cuit;
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
            credenciales.Cuit = _cuit;
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
                Cuit = _cuit,
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

        public int ObtenerNumeroUltimoComprobante(int tipoComprobante)
        {
            GetCredentials();
            Credentials credenciales = new Credentials();
            credenciales.Cuit = _cuit;
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