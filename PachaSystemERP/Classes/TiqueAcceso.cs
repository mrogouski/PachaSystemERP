// <copyright file="TiqueAcceso.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
    using System;
    using System.Security.Cryptography.Pkcs;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Representa un Request Access Ticket (TRA).
    /// </summary>
    public static class TiqueAcceso
    {
        /// <summary>
        /// DN del usuario que genero el Request Access Ticket (Opcional).
        /// </summary>
        private static string _origen;

        /// <summary>
        /// DN del Web Service (Opcional).
        /// </summary>
        private static string _destino;

        /// <summary>
        /// ID unico que identifica al pedido de acceso.
        /// </summary>
        private static uint _id;

        /// <summary>
        /// Fecha y hora en la que se genero el pedido de acceso.
        /// </summary>
        private static DateTime _fechaDeGeneracion;

        /// <summary>
        /// Fecha y hora de expiracion del pedido de acceso.
        /// </summary>
        private static DateTime _fechaDeExpiracion;

        /// <summary>
        /// Nombre del Web Service al que se quiere acceder.
        /// </summary>
        private static string _servicio;

        /// <summary>
        /// Metodo que permite obtener el tique de solicitud de acceso firmado.
        /// </summary>
        /// <param name="testing">Valor que indica si se esta utilizando en el entorno de testeo o produccion.</param>
        /// <param name="servicio">Nombre de identificacion del Web Service.</param>
        /// <returns>Devuelve un tique de solicitud de acceso firmado.</returns>
        public static string ObtenerTique(bool testing, string servicio)
        {
            if (testing)
            {
                _destino = "cn = wsaahomo,o = afip,c = ar,serialNumber = CUIT 33693450239";
                _fechaDeGeneracion = DateTime.Now;
                _fechaDeExpiracion = DateTime.Now.AddHours(+12);
                _servicio = servicio;
            }
            else
            {
                _destino = "cn = wsaa,o = afip,c = ar,serialNumber = CUIT 33693450239";
                _fechaDeGeneracion = DateTime.Now;
                _fechaDeExpiracion = DateTime.Now.AddHours(+12);
                _servicio = servicio;
            }

            var tique = GenerarTique();
            var ticketFirmado = FirmarTicket(tique.ToString());
            return ticketFirmado;
        }

        /// <summary>
        /// Metodo que permite obtener el tique de solicitud de acceso firmado.
        /// </summary>
        /// <param name="testing">Valor que indica si se esta utilizando en el entorno de testeo o produccion.</param>
        /// <param name="servicio">Nombre de identificacion del Web Service.</param>
        /// <param name="origen">DN del usuario que genero el Request Access Ticket.</param>
        /// <returns>Devuelve un tique de solicitud de acceso firmado.</returns>
        public static string ObtenerTique(bool testing, string servicio, string origen)
        {
            if (testing)
            {
                _origen = origen;
                _destino = "cn = wsaahomo,o = afip,c = ar,serialNumber = CUIT 33693450239";
                _fechaDeGeneracion = DateTime.Now;
                _fechaDeExpiracion = DateTime.Now.AddHours(+12);
                _servicio = servicio;
            }
            else
            {
                _origen = origen;
                _destino = "cn = wsaa,o = afip,c = ar,serialNumber = CUIT 33693450239";
                _fechaDeGeneracion = DateTime.Now;
                _fechaDeExpiracion = DateTime.Now.AddHours(+12);
                _servicio = servicio;
            }

            var tique = GenerarTique();
            var ticketFirmado = FirmarTicket(tique.ToString());
            return ticketFirmado;
        }

        /// <summary>
        /// Genera un Request Access Ticket en formato XML.
        /// </summary>
        /// <returns>Devuelve un XML con los datos sumninistrados.</returns>
        private static XDocument GenerarTique()
        {
            if (string.IsNullOrWhiteSpace(_origen))
            {
                var xml = new XDocument(
                new XElement(
                    "loginTicketRequest",
                    new XElement("header", new XElement("destination", _destino), new XElement("uniqueId", _id), new XElement("generationTime", _fechaDeGeneracion), new XElement("expirationTime", _fechaDeExpiracion)),
                    new XElement("service", _servicio)));
                xml.Element("loginTicketRequest").SetAttributeValue("version", "1.0");
                return xml;
            }
            else
            {
                var xml = new XDocument(
                 new XElement(
                     "loginTicketRequest", new XElement("header", new XElement("source", _origen), new XElement("destination", _destino), new XElement("uniqueId", _id), new XElement("generationTime", _fechaDeGeneracion), new XElement("expirationTime", _fechaDeExpiracion)), new XElement("service", _servicio)));
                xml.Element("loginTicketRequest").SetAttributeValue("version", "1.0");
                return xml;
            }
        }

        /// <summary>
        /// Firma digitalmente el Request Access Ticket.
        /// </summary>
        /// <returns>Un string codificado en Base64.</returns>
        private static string FirmarTicket(string tique)
        {
            byte[] mensaje = Encoding.UTF8.GetBytes(tique);

            ContentInfo contenido = new ContentInfo(mensaje);

            SignedCms cms = new SignedCms(SubjectIdentifierType.SubjectKeyIdentifier, contenido);

            CmsSigner firmanteCMS = new CmsSigner(CertificadoX509.Importar());
            firmanteCMS.IncludeOption = X509IncludeOption.EndCertOnly;

            cms.ComputeSignature(firmanteCMS);

            byte[] cmsFirmado = cms.Encode();

            string cmsCodificado = Convert.ToBase64String(cmsFirmado);

            return cmsCodificado;
        }
    }
}
