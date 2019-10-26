﻿// <copyright file="FacturaElectronica.cs" company="Pacha System">
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
            if (Configuracion.ModoDeOperacion == ModoDeOperacion.Homologacion)
            {
                _wsaaClient = new WsaaClient("WsaaHomologacion");
                _wsfeClient = new WsfeClient("WsfeHomologacion");
                _testing = true;
            }
            else if (Configuracion.ModoDeOperacion == ModoDeOperacion.Produccion)
            {
                _wsaaClient = new WsaaClient("WsaaProduccion");
                _wsfeClient = new WsfeClient("WsfeProduccion");
                _testing = false;
            }

            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comprobante"></param>
        /// <returns></returns>
        public CaeResponse GenerarComprobante(Comprobante comprobante)
        {
            try
            {
                if (comprobante == null)
                {
                    throw new ArgumentNullException(nameof(comprobante));
                }

                ObtenerCredenciales();
                Credenciales autorizacion = new Credenciales
                {
                    Cuit = _cuit,
                    Sign = _sign,
                    Token = _token,
                };

                var request = new CaeRequest();
                request.CabeceraRequest.CantidadDeRegistros = 1;
                request.CabeceraRequest.PuntoDeVenta = Configuracion.PuntoVenta;
                request.CabeceraRequest.TipoDeComprobante = comprobante.TipoComprobanteID;

                var detalles = new CaeDetalleRequest();
                detalles.Concepto = comprobante.TipoConceptoID;
                detalles.ComprobanteDesde = comprobante.NumeroComprobante;
                detalles.ComprobanteHasta = comprobante.NumeroComprobante;
                detalles.FechaDeComprobante = comprobante.FechaComprobante.ToString("yyyyMMdd");
                detalles.ImporteTotal = decimal.ToDouble(comprobante.ImporteTotal);
                detalles.ImporteNetoNoGravado = decimal.ToDouble(comprobante.ImporteNetoNoGravado);
                detalles.ImporteNeto = decimal.ToDouble(comprobante.ImporteNeto);
                detalles.ImporteExento = decimal.ToDouble(comprobante.ImporteExento);
                detalles.ImporteIVA = decimal.ToDouble(comprobante.ImporteTotalIva);
                detalles.ImporteTributo = decimal.ToDouble(comprobante.ImporteTotalTributo);
                detalles.CodigoMoneda = _unitOfWork.TipoMoneda.Obtener(x => x.ID == comprobante.TipoMonedaID).Codigo;
                detalles.MonedaCotizacion = comprobante.CotizacionMoneda;

                //if (comprobante.ComprobantesAsociados != null)
                //{
                //    foreach (var item in comprobante.ComprobantesAsociados)
                //    {
                //        detalles.AgregarComprobanteAsociado(item.TipoComprobanteID, item.PuntoDeVenta, item.NumeroDocumento, item.Cuit, item.FechaComprobante.ToString("yyyyMMdd"));
                //    }
                //}

                if (comprobante.DetalleComprobante != null)
                {
                    foreach (var item in comprobante.DetalleComprobante)
                    {
                        detalles.AgregarIVA(item.Producto.TipoCondicionIvaID, item.BaseImponible, item.ImporteIva);
                        if (item.ImporteTributo > 0)
                        {
                            detalles.AgregarTributo(item.Producto.TipoTributo.CategoriaTributoID, item.Producto.TipoTributo.Descripcion, item.Producto.TipoTributo.Alicuota, item.BaseImponible, item.ImporteTributo);
                        }
                    }
                }

                foreach (var item in comprobante.ComprobanteCliente)
                {
                    if (item.Cliente.RazonSocial.Equals("CONSUMIDOR FINAL"))
                    {
                        detalles.TipoDeDocumento = item.Cliente.TipoDocumentoID;
                    }
                    else
                    {
                        detalles.TipoDeDocumento = item.Cliente.TipoDocumentoID;
                        detalles.NumeroDeDocumento = long.Parse(item.Cliente.NumeroDocumento);
                        detalles.AgregarComprador(item.Cliente.TipoDocumentoID, item.Cliente.NumeroDocumento, item.PorcentajeTitularidad);
                    }
                }

                request.DetalleRequest.Add(detalles);

                var response = _wsfeClient.SolicitarCae(autorizacion, request);
                if (response == null)
                {
                    throw new ArgumentNullException("response");
                }
                else
                {
                    //if (response.Errores.Count > 0 && response.Eventos.Count > 0)
                    //{
                    //    throw new ArgumentException();
                    //}

                    return response;
                }
            }
            catch (FaultException)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comprobante"></param>
        /// <returns></returns>
        public async Task GenerarComprobanteAsync(Comprobante comprobante)
        {
            try
            {
                using (var password = new SecureString())
                {
                    ObtenerCredenciales();

                    Credenciales autorizacion = new Credenciales();
                    autorizacion.Cuit = _cuit;
                    autorizacion.Sign = _sign;
                    autorizacion.Token = _token;

                    CaeRequest request = new CaeRequest();

                    //request.CabeceraRequest.CantidadDeRegistros = comprobante.CantidadDeComprobantes;
                    //request.CabeceraRequest.PuntoDeVenta = comprobante.PuntoDeVenta;
                    //request.CabeceraRequest.TipoDeComprobante = comprobante.TipoDeComprobante;

                    CaeDetalleRequest detalles = new CaeDetalleRequest();
                    detalles.Concepto = (int)Concepto.Productos;
                    detalles.TipoDeDocumento = 99;
                    detalles.NumeroDeDocumento = 0;
                    detalles.ComprobanteDesde = 2;
                    detalles.ComprobanteHasta = 2;
                    detalles.FechaDeComprobante = DateTime.Now.ToString("yyyyMMdd");
                    detalles.ImporteTotal = 165.75;
                    detalles.ImporteNetoNoGravado = 0;
                    detalles.ImporteNeto = 150;
                    detalles.ImporteExento = 0;
                    detalles.ImporteIVA = 15.75;
                    detalles.ImporteTributo = 0;
                    detalles.CodigoMoneda = "PES";
                    detalles.MonedaCotizacion = 1;

                    AlicuotaIva iva = new AlicuotaIva();
                    iva.ID = 4;
                    iva.BaseImponible = 165.75;
                    iva.Importe = 15.75;

                    detalles.AlicuotaIVA.Add(iva);

                    request.DetalleRequest.Add(detalles);

                    var response = await _wsfeClient.SolicitarCaeAsync(autorizacion, request);
                }
            }
            catch (FaultException)
            {

                throw;
            }
        }

        public TipoDeComprobanteResponse ObtenerTiposDeComprobante()
        {
            ObtenerCredenciales();
            Credenciales credenciales = new Credenciales();
            credenciales.Cuit = _cuit;
            credenciales.Sign = _sign;
            credenciales.Token = _token;
            try
            {
                var response = _wsfeClient.ObtenerTiposDeComprobante(credenciales);
                return response;
            }
            catch (FaultException)
            {

                throw;
            }
        }

        public IList<PachaSystem.Wsfe.Models.TipoDeDocumento> ObtenerTiposDeDocumento()
        {
            ObtenerCredenciales();
            Credenciales credenciales = new Credenciales();
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
            ObtenerCredenciales();
            Credenciales credenciales = new Credenciales();
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

        public IList<TipoDeMoneda> ObtenerTiposDeMoneda()
        {
            ObtenerCredenciales();
            Credenciales credenciales = new Credenciales();
            credenciales.Cuit = _cuit;
            credenciales.Sign = _sign;
            credenciales.Token = _token;
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
            ObtenerCredenciales();
            Credenciales credenciales = new Credenciales();
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

        public List<string> ObtenerEstadoDeConexion()
        {
            var response = _wsfeClient.ObtenerEstadoDelServicio();
            List<string> list = new List<string>
            {
                response.AppServer,
                response.AuthServer,
                response.DbServer
            };
            return list;
        }

        /// <summary>
        /// Solicita la autorizacion de acceso al Web Service especificado.
        /// </summary>
        private void ObtenerCredenciales()
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