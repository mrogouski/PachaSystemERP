// <copyright file="WsfeClient.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe
{
    using PachaSystem.Wsfe.Requests;
    using PachaSystem.Wsfe.Responses;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading.Tasks;

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

        public CaeResponse SolicitarCae(Credentials autorizacion, CaeRequest request)
        {
            return base.Channel.SolicitarCae(autorizacion, request);
        }

        public Task<CaeResponse> SolicitarCaeAsync(Credentials authorization, CaeRequest request)
        {
            return base.Channel.SolicitarCaeAsync(authorization, request);
        }

        public CantidadMaximaDeRegistrosResponse ObtenerCantidadMaximaDeComprobantes(Credentials autorizacion)
        {
            return base.Channel.ObtenerCantidadMaximaDeComprobantes(autorizacion);
        }

        public Task<CantidadMaximaDeRegistrosResponse> ObtenerCantidadMaximaDeComprobantesAsync(Credentials autorizacion)
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

        public RecuperarUltimoComprobanteResponse ObtenerUltimoComprobante(Credentials autorizacion, int puntoDeVenta, int tipoDeComprobante)
        {
            return base.Channel.ObtenerUltimoComprobante(autorizacion, puntoDeVenta, tipoDeComprobante);
        }

        public Task<RecuperarUltimoComprobanteResponse> ObtenerUltimoComprobanteAsync(Credentials autorizacion, int puntoDeVenta, int tipoDeComprobante)
        {
            return base.Channel.ObtenerUltimoComprobanteAsync(autorizacion, puntoDeVenta, tipoDeComprobante);
        }

        public ConsultaComprobanteResponse ConsultarComprobante(Credentials autorizacion, ConsultaComprobanteRequest request)
        {
            return base.Channel.ConsultarComprobante(autorizacion, request);
        }

        public Task<ConsultaComprobanteResponse> ConsultarComprobanteAsync(Credentials autorizacion, ConsultaComprobanteRequest request)
        {
            return base.Channel.ConsultarComprobanteAsync(autorizacion, request);
        }

        public CaeaResponse RegistroInformativoCaea(Credentials autorizacion, CaeaRequest request)
        {
            return base.Channel.RegistroInformativoCaea(autorizacion, request);
        }

        public Task<CaeaResponse> RegistroInformativoCaeaAsync(Credentials autorizacion, CaeaRequest request)
        {
            return base.Channel.RegistroInformativoCaeaAsync(autorizacion, request);
        }

        public CaeaSolicitarResponse SolicitarCaea(Credentials autorizacion, int periodo, short orden)
        {
            return base.Channel.SolicitarCaea(autorizacion, periodo, orden);
        }

        public Task<CaeaSolicitarResponse> SolicitarCaeaAsync(Credentials autorizacion, int periodo, short orden)
        {
            return base.Channel.SolicitarCaeaAsync(autorizacion, periodo, orden);
        }

        public CaeaSinMovimientosConsultarResponse ConsultarCaeaSinMovimientos(Credentials autorizacion, string caea, int puntoDeVenta)
        {
            return base.Channel.ConsultarCaeaSinMovimientos(autorizacion, caea, puntoDeVenta);
        }

        public Task<CaeaSinMovimientosConsultarResponse> ConsultarCaeaSinMovimientosAsync(Credentials autorizacion, string caea, int puntoDeVenta)
        {
            return base.Channel.ConsultarCaeaSinMovimientosAsync(autorizacion, caea, puntoDeVenta);
        }

        public CaeaSinMovimientoResponse InformarCaeaSinMovimientos(Credentials autorizacion, int puntoDeVenta, string caea)
        {
            return base.Channel.InformarCaeaSinMovimientos(autorizacion, puntoDeVenta, caea);
        }

        public Task<CaeaSinMovimientoResponse> InformarCaeaSinMovimientosAsync(Credentials autorizacion, int puntoDeVenta, string caea)
        {
            return base.Channel.InformarCaeaSinMovimientosAsync(autorizacion, puntoDeVenta, caea);
        }

        public CaeaSolicitarResponse ConsultarCaea(Credentials autorizacion, int periodo, short orden)
        {
            return base.Channel.ConsultarCaea(autorizacion, periodo, orden);
        }

        public Task<CaeaSolicitarResponse> ConsultarCaeaAsync(Credentials autorizacion, int periodo, short orden)
        {
            return base.Channel.ConsultarCaeaAsync(autorizacion, periodo, orden);
        }

        public CotizacionResponse ObtenerCotizacion(Credentials autorizacion, string idMoneda)
        {
            return base.Channel.ObtenerCotizacion(autorizacion, idMoneda);
        }

        public Task<CotizacionResponse> ObtenerCotizacionAsync(Credentials autorizacion, string idMoneda)
        {
            return base.Channel.ObtenerCotizacionAsync(autorizacion, idMoneda);
        }

        public TributoResponse ObtenerTiposDeTributo(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeTributo(autorizacion);
        }

        public Task<TributoResponse> ObtenerTiposDeTributoAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeTributoAsync(autorizacion);
        }

        public TipoDeMonedaResponse ObtenerTiposDeMoneda(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeMoneda(autorizacion);
        }

        public Task<TipoDeMonedaResponse> ObtenerTiposDeMonedaAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeMonedaAsync(autorizacion);
        }

        public TipoDeIvaResponse ObtenerTiposDeIva(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeIva(autorizacion);
        }

        public Task<TipoDeIvaResponse> ObtenerTiposDeIvaAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeIvaAsync(autorizacion);
        }

        public TipoDeOpcionalResponse ObtenesTiposOpcionales(Credentials autorizacion)
        {
            return base.Channel.ObtenesTiposOpcionales(autorizacion);
        }

        public Task<TipoDeOpcionalResponse> ObtenesTiposOpcionalesAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenesTiposOpcionalesAsync(autorizacion);
        }

        public TipoDeConceptoResponse ObtenerTiposDeConcepto(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeConcepto(autorizacion);
        }

        public Task<TipoDeConceptoResponse> ObtenerTiposDeConceptoAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeConceptoAsync(autorizacion);
        }

        public PuntoDeVentaResponse ObtenerPuntosDeVenta(Credentials autorizacion)
        {
            return base.Channel.ObtenerPuntosDeVenta(autorizacion);
        }

        public Task<PuntoDeVentaResponse> ObtenerPuntosDeVentaAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenerPuntosDeVentaAsync(autorizacion);
        }

        public TipoDeComprobanteResponse ObtenerTiposDeComprobante(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeComprobante(autorizacion);
        }

        public Task<TipoDeComprobanteResponse> ObtenerTiposDeComprobanteAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeComprobanteAsync(autorizacion);
        }

        public TipoDeDocumentoResponse ObtenerTiposDeDocumento(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeDocumento(autorizacion);
        }

        public Task<TipoDeDocumentoResponse> ObtenerTiposDeDocumentoAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenerTiposDeDocumentoAsync(autorizacion);
        }

        public TipoDePaisResponse ObtenerListadoDePaises(Credentials autorizacion)
        {
            return base.Channel.ObtenerListadoDePaises(autorizacion);
        }

        public Task<TipoDePaisResponse> ObtenerListadoDePaisesAsync(Credentials autorizacion)
        {
            return base.Channel.ObtenerListadoDePaisesAsync(autorizacion);
        }
    }
}