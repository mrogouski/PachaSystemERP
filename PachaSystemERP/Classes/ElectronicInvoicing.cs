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

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ElectronicInvoicing"/>.
        /// </summary>
        public ElectronicInvoicing()
        {
            _wsaaClient = new WsaaClient();
            _wsfeClient = new WsfeClient();

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
        public CaeResponse GenerateInvoice(CaeRequest request)
        {
            var credentials = GetCredentials();

            var response = _wsfeClient.SolicitarCae(credentials, request);

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
            var puntoDeVenta = Configuracion.PuntoVenta;
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
    }
}