// <copyright file="TiqueAcceso.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
    using PachaSystemERP.Properties;
    using System;
    using System.IO;
    using System.Security.Cryptography.Pkcs;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Xml.Linq;

    public static class RequestAccessTicket
    {
        private static string _userDistinguishedName;
        private static string _destinationDistinguishedName;
        private static uint _id;
        private static DateTime _fechaDeGeneracion;
        private static DateTime _fechaDeExpiracion;
        private static string _servicio;

        public static string Get()
        {
            if (Settings.Default.IsTestingMode)
            {
                _destinationDistinguishedName = Settings.Default.TestingDN;
            }
            else
            {
                _destinationDistinguishedName = Settings.Default.ProductionDN;
            }

            _fechaDeGeneracion = DateTime.Now;
            _fechaDeExpiracion = DateTime.Now.AddHours(+12);
            _servicio = Settings.Default.WebServiceName;

            var tique = Build();
            var ticketFirmado = Sign(tique.ToString());
            return ticketFirmado;
        }

        public static string Get(bool testing, string servicio, string origen)
        {
            if (testing)
            {
                _userDistinguishedName = origen;
                _destinationDistinguishedName = "cn = wsaahomo,o = afip,c = ar,serialNumber = CUIT 33693450239";
                _fechaDeGeneracion = DateTime.Now;
                _fechaDeExpiracion = DateTime.Now.AddHours(+12);
                _servicio = servicio;
            }
            else
            {
                _userDistinguishedName = origen;
                _destinationDistinguishedName = "cn = wsaa,o = afip,c = ar,serialNumber = CUIT 33693450239";
                _fechaDeGeneracion = DateTime.Now;
                _fechaDeExpiracion = DateTime.Now.AddHours(+12);
                _servicio = servicio;
            }

            var ticket = Build();
            var signedTicket = Sign(ticket.ToString());
            return signedTicket;
        }

        private static XDocument Build()
        {
            if (string.IsNullOrWhiteSpace(_userDistinguishedName))
            {
                var xml = new XDocument(
                new XElement(
                    "loginTicketRequest",
                    new XElement("header", new XElement("destination", _destinationDistinguishedName), new XElement("uniqueId", _id), new XElement("generationTime", _fechaDeGeneracion), new XElement("expirationTime", _fechaDeExpiracion)),
                    new XElement("service", _servicio)));
                xml.Element("loginTicketRequest").SetAttributeValue("version", "1.0");
                return xml;
            }
            else
            {
                var xml = new XDocument(
                 new XElement(
                     "loginTicketRequest", new XElement("header", new XElement("source", _userDistinguishedName), new XElement("destination", _destinationDistinguishedName), new XElement("uniqueId", _id), new XElement("generationTime", _fechaDeGeneracion), new XElement("expirationTime", _fechaDeExpiracion)), new XElement("service", _servicio)));
                xml.Element("loginTicketRequest").SetAttributeValue("version", "1.0");
                return xml;
            }
        }

        private static string Sign(string ticket)
        {
            byte[] message = Encoding.UTF8.GetBytes(ticket);

            ContentInfo contentInfo = new ContentInfo(message);

            SignedCms cms = new SignedCms(SubjectIdentifierType.SubjectKeyIdentifier, contentInfo);

            CmsSigner cmsSigner = new CmsSigner(ImportCertificate());
            cmsSigner.IncludeOption = X509IncludeOption.EndCertOnly;

            cms.ComputeSignature(cmsSigner);

            byte[] cmsFirmado = cms.Encode();

            string cmsCodificado = Convert.ToBase64String(cmsFirmado);

            return cmsCodificado;
        }

        private static X509Certificate2 ImportCertificate()
        {
            string password = Configuracion.PasswordCertificado ?? throw new ArgumentNullException(nameof(password));
            string path = Configuracion.RutaCertificado ?? throw new ArgumentNullException(nameof(path));

            if (!File.Exists(Path.GetFullPath(path)))
            {
                throw new FileNotFoundException();
            }
            else
            {
                X509Certificate2 certificate = new X509Certificate2();
                certificate.Import(path, password, X509KeyStorageFlags.DefaultKeySet);

                var distinguishedName = certificate.SubjectName;
                _userDistinguishedName = distinguishedName.Name;

                return certificate;
            }
        }
    }
}