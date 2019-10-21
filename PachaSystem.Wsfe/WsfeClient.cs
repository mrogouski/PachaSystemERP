// <copyright file="WsfeClient.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe
{
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading.Tasks;
    using PachaSystem.Wsfe.Models;
    using PachaSystem.Wsfe.Requests;
    using PachaSystem.Wsfe.Responses;

    /// <summary>
    /// Representa el cliente del servicio web de factura electronica.
    /// </summary>
    public class WsfeClient : ClientBase<IWsfeClient>, IWsfeClient
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsfeClient"/>.
        /// </summary>
        public WsfeClient()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsfeClient"/>.
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        public WsfeClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsfeClient"/>.
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="remoteAddress"></param>
        public WsfeClient(string endpointConfigurationName, string remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsfeClient"/>.
        /// </summary>
        /// <param name="endpointConfigurationName"></param>
        /// <param name="remoteAddress"></param>
        public WsfeClient(string endpointConfigurationName, EndpointAddress remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsfeClient"/>.
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="remoteAddress"></param>
        public WsfeClient(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        {
        }

        public CaeResponse SolicitarCae(Credenciales autorizacion, CaeRequest request)
        {
            return base.Channel.SolicitarCae(autorizacion, request);
        }

        public Task<CaeResponse> SolicitarCaeAsync(Credenciales authorization, CaeRequest request)
        {
            return base.Channel.SolicitarCaeAsync(authorization, request);
        }

        public CantidadMaximaDeRegistrosResponse ObtenerCantidadMaximaDeComprobantes(Credenciales autorizacion)
        {
            return base.Channel.ObtenerCantidadMaximaDeComprobantes(autorizacion);
        }

        public Task<CantidadMaximaDeRegistrosResponse> ObtenerCantidadMaximaDeComprobantesAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerCantidadMaximaDeComprobantesAsync(autorizacion);
        }

        public DummyResponse ObtenerEstadoDelServicio()
        {
            return base.Channel.ObtenerEstadoDelServicio();
        }

        public Task<DummyResponse> ObtenerEstadoDelServicioAsync()
        {
            return base.Channel.ObtenerEstadoDelServicioAsync();
        }

        public RecuperarUltimoComprobanteResponse ObtenerUltimoComprobante(Credenciales autorizacion, int puntoDeVenta, int tipoDeComprobante)
        {
            return base.Channel.ObtenerUltimoComprobante(autorizacion, puntoDeVenta, tipoDeComprobante);
        }

        public Task<RecuperarUltimoComprobanteResponse> ObtenerUltimoComprobanteAsync(Credenciales autorizacion, int puntoDeVenta, int tipoDeComprobante)
        {
            return base.Channel.ObtenerUltimoComprobanteAsync(autorizacion, puntoDeVenta, tipoDeComprobante);
        }

        public ConsultaComprobanteResponse ConsultarComprobante(Credenciales autorizacion, ConsultaComprobanteRequest request)
        {
            return base.Channel.ConsultarComprobante(autorizacion, request);
        }

        public Task<ConsultaComprobanteResponse> ConsultarComprobanteAsync(Credenciales autorizacion, ConsultaComprobanteRequest request)
        {
            return base.Channel.ConsultarComprobanteAsync(autorizacion, request);
        }

        public CaeaResponse RegistroInformativoCaea(Credenciales autorizacion, CaeaRequest request)
        {
            return base.Channel.RegistroInformativoCaea(autorizacion, request);
        }

        public Task<CaeaResponse> RegistroInformativoCaeaAsync(Credenciales autorizacion, CaeaRequest request)
        {
            return base.Channel.RegistroInformativoCaeaAsync(autorizacion, request);
        }

        public CaeaSolicitarResponse SolicitarCaea(Credenciales autorizacion, int periodo, short orden)
        {
            return base.Channel.SolicitarCaea(autorizacion, periodo, orden);
        }

        public Task<CaeaSolicitarResponse> SolicitarCaeaAsync(Credenciales autorizacion, int periodo, short orden)
        {
            return base.Channel.SolicitarCaeaAsync(autorizacion, periodo, orden);
        }

        public CaeaSinMovimientosConsultarResponse ConsultarCaeaSinMovimientos(Credenciales autorizacion, string caea, int puntoDeVenta)
        {
            return base.Channel.ConsultarCaeaSinMovimientos(autorizacion, caea, puntoDeVenta);
        }

        public Task<CaeaSinMovimientosConsultarResponse> ConsultarCaeaSinMovimientosAsync(Credenciales autorizacion, string caea, int puntoDeVenta)
        {
            return base.Channel.ConsultarCaeaSinMovimientosAsync(autorizacion, caea, puntoDeVenta);
        }

        public CaeaSinMovimientoResponse InformarCaeaSinMovimientos(Credenciales autorizacion, int puntoDeVenta, string caea)
        {
            return base.Channel.InformarCaeaSinMovimientos(autorizacion, puntoDeVenta, caea);
        }

        public Task<CaeaSinMovimientoResponse> InformarCaeaSinMovimientosAsync(Credenciales autorizacion, int puntoDeVenta, string caea)
        {
            return base.Channel.InformarCaeaSinMovimientosAsync(autorizacion, puntoDeVenta, caea);
        }

        public CaeaSolicitarResponse ConsultarCaea(Credenciales autorizacion, int periodo, short orden)
        {
            return base.Channel.ConsultarCaea(autorizacion, periodo, orden);
        }

        public Task<CaeaSolicitarResponse> ConsultarCaeaAsync(Credenciales autorizacion, int periodo, short orden)
        {
            return base.Channel.ConsultarCaeaAsync(autorizacion, periodo, orden);
        }

        public CotizacionResponse ObtenerCotizacion(Credenciales autorizacion, string idMoneda)
        {
            return base.Channel.ObtenerCotizacion(autorizacion, idMoneda);
        }

        public Task<CotizacionResponse> ObtenerCotizacionAsync(Credenciales autorizacion, string idMoneda)
        {
            return base.Channel.ObtenerCotizacionAsync(autorizacion, idMoneda);
        }

        public TributoResponse ObtenerTiposDeTributo(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeTributo(autorizacion);
        }

        public Task<TributoResponse> ObtenerTiposDeTributoAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeTributoAsync(autorizacion);
        }

        public TipoDeMonedaResponse ObtenerTiposDeMoneda(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeMoneda(autorizacion);
        }

        public Task<TipoDeMonedaResponse> ObtenerTiposDeMonedaAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeMonedaAsync(autorizacion);
        }

        public TipoDeIvaResponse ObtenerTiposDeIva(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeIva(autorizacion);
        }

        public Task<TipoDeIvaResponse> ObtenerTiposDeIvaAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeIvaAsync(autorizacion);
        }

        public TipoDeOpcionalResponse ObtenesTiposOpcionales(Credenciales autorizacion)
        {
            return base.Channel.ObtenesTiposOpcionales(autorizacion);
        }

        public Task<TipoDeOpcionalResponse> ObtenesTiposOpcionalesAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenesTiposOpcionalesAsync(autorizacion);
        }

        public TipoDeConceptoResponse ObtenerTiposDeConcepto(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeConcepto(autorizacion);
        }

        public Task<TipoDeConceptoResponse> ObtenerTiposDeConceptoAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeConceptoAsync(autorizacion);
        }

        public PuntoDeVentaResponse ObtenerPuntosDeVenta(Credenciales autorizacion)
        {
            return base.Channel.ObtenerPuntosDeVenta(autorizacion);
        }

        public Task<PuntoDeVentaResponse> ObtenerPuntosDeVentaAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerPuntosDeVentaAsync(autorizacion);
        }

        public TipoDeComprobanteResponse ObtenerTiposDeComprobante(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeComprobante(autorizacion);
        }

        public Task<TipoDeComprobanteResponse> ObtenerTiposDeComprobanteAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeComprobanteAsync(autorizacion);
        }

        public TipoDeDocumentoResponse ObtenerTiposDeDocumento(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeDocumento(autorizacion);
        }

        public Task<TipoDeDocumentoResponse> ObtenerTiposDeDocumentoAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerTiposDeDocumentoAsync(autorizacion);
        }

        public TipoDePaisResponse ObtenerListadoDePaises(Credenciales autorizacion)
        {
            return base.Channel.ObtenerListadoDePaises(autorizacion);
        }

        public Task<TipoDePaisResponse> ObtenerListadoDePaisesAsync(Credenciales autorizacion)
        {
            return base.Channel.ObtenerListadoDePaisesAsync(autorizacion);
        }
    }
}
