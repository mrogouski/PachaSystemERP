// <copyright file="IWsfeClient.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe
{
    using PachaSystem.Wsfe.Requests;
    using PachaSystem.Wsfe.Responses;
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract(Name = "ServiceSoap", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public interface IWsfeClient
    {
        [OperationContract(Name = "FECAESolicitar", Action = "http://ar.gov.afip.dif.FEV1/FECAESolicitar", ReplyAction = "*")]
        CaeResponse SolicitarCae([MessageParameter(Name = "Auth")]Credentials autorizacion, [MessageParameter(Name = "FeCAEReq")]CaeRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="request"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECAESolicitar", Action = "http://ar.gov.afip.dif.FEV1/FECAESolicitar", ReplyAction = "*")]
        Task<CaeResponse> SolicitarCaeAsync(Credentials autorizacion, CaeRequest request);

        [OperationContract(Name = "FECompTotXRequest", Action = "http://ar.gov.afip.dif.FEV1/FECompTotXRequest", ReplyAction = "*")]
        CantidadMaximaDeRegistrosResponse ObtenerCantidadMaximaDeComprobantes([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECompTotXRequest", Action = "http://ar.gov.afip.dif.FEV1/FECompTotXRequest", ReplyAction = "*")]
        Task<CantidadMaximaDeRegistrosResponse> ObtenerCantidadMaximaDeComprobantesAsync(Credentials autorizacion);

        [OperationContract(Name = "FEDummy", Action = "http://ar.gov.afip.dif.FEV1/FEDummy", ReplyAction = "*")]
        DummyResponse ObtenerEstadoDelServicio();

        /// <summary>
        ///
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEDummy", Action = "http://ar.gov.afip.dif.FEV1/FEDummy", ReplyAction = "*")]
        Task<DummyResponse> ObtenerEstadoDelServicioAsync();

        [OperationContract(Name = "FECompUltimoAutorizado", Action = "http://ar.gov.afip.dif.FEV1/FECompUltimoAutorizado", ReplyAction = "*")]
        RecuperarUltimoComprobanteResponse ObtenerUltimoComprobante([MessageParameter(Name = "Auth")]Credentials autorizacion, [MessageParameter(Name = "PtoVta")]int puntoDeVenta, [MessageParameter(Name = "CbteTipo")]int tipoDeComprobante);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="puntoDeVenta"></param>
        /// <param name="tipoDeComprobante"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECompUltimoAutorizado", Action = "http://ar.gov.afip.dif.FEV1/FECompUltimoAutorizado", ReplyAction = "*")]
        Task<RecuperarUltimoComprobanteResponse> ObtenerUltimoComprobanteAsync(Credentials autorizacion, int puntoDeVenta, int tipoDeComprobante);

        [OperationContract(Name = "FECompConsultar", Action = "http://ar.gov.afip.dif.FEV1/FECompConsultar", ReplyAction = "*")]
        ConsultaComprobanteResponse ConsultarComprobante([MessageParameter(Name = "Auth")]Credentials autorizacion, [MessageParameter(Name = "FeCompConsReq")]ConsultaComprobanteRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="request"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECompConsultar", Action = "http://ar.gov.afip.dif.FEV1/FECompConsultar", ReplyAction = "*")]
        Task<ConsultaComprobanteResponse> ConsultarComprobanteAsync(Credentials autorizacion, ConsultaComprobanteRequest request);

        [OperationContract(Name = "FECAEAReg", Action = "http://ar.gov.afip.dif.FEV1/FECAEARegInformativo", ReplyAction = "*")]
        CaeaResponse RegistroInformativoCaea([MessageParameter(Name = "Auth")]Credentials autorizacion, CaeaRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="request"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECAEARegInformativo", Action = "http://ar.gov.afip.dif.FEV1/FECAEARegInformativo", ReplyAction = "*")]
        Task<CaeaResponse> RegistroInformativoCaeaAsync(Credentials autorizacion, CaeaRequest request);

        [OperationContract(Name = "FECAEASolicitar", Action = "http://ar.gov.afip.dif.FEV1/FECAEASolicitar", ReplyAction = "*")]
        CaeaSolicitarResponse SolicitarCaea([MessageParameter(Name = "Auth")]Credentials autorizacion, [MessageParameter(Name = "Periodo")]int periodo, [MessageParameter(Name = "Orden")]short orden);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="periodo"></param>
        /// <param name="orden"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECAEASolicitar", Action = "http://ar.gov.afip.dif.FEV1/FECAEASolicitar", ReplyAction = "*")]
        Task<CaeaSolicitarResponse> SolicitarCaeaAsync(Credentials autorizacion, int periodo, short orden);

        [OperationContract(Name = "FECAEASinMovmientoConsultar", Action = "http://ar.gov.afip.dif.FEV1/FECAEASinMovimientoConsultar", ReplyAction = "*")]
        CaeaSinMovimientosConsultarResponse ConsultarCaeaSinMovimientos([MessageParameter(Name = "Auth")]Credentials autorizacion, [MessageParameter(Name = "CAEA")]string caea, [MessageParameter(Name = "PtoVta")]int puntoDeVenta);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="caea"></param>
        /// <param name="puntoDeVenta"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECAEASinMovimientoConsultar", Action = "http://ar.gov.afip.dif.FEV1/FECAEASinMovimientoConsultar", ReplyAction = "*")]
        Task<CaeaSinMovimientosConsultarResponse> ConsultarCaeaSinMovimientosAsync(Credentials autorizacion, string caea, int puntoDeVenta);

        [OperationContract(Name = "FECAEASinMovimientoInformar", Action = "http://ar.gov.afip.dif.FEV1/FECAEASinMovimientoInformar", ReplyAction = "*")]
        CaeaSinMovimientoResponse InformarCaeaSinMovimientos([MessageParameter(Name = "Auth")]Credentials autorizacion, [MessageParameter(Name = "PtoVta")]int puntoDeVenta, [MessageParameter(Name = "CAEA")]string caea);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="puntoDeVenta"></param>
        /// <param name="caea"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECAEASinMovimientoInformar", Action = "http://ar.gov.afip.dif.FEV1/FECAEASinMovimientoInformar", ReplyAction = "*")]
        Task<CaeaSinMovimientoResponse> InformarCaeaSinMovimientosAsync(Credentials autorizacion, int puntoDeVenta, string caea);

        [OperationContract(Name = "FECAEAConsultar", Action = "http://ar.gov.afip.dif.FEV1/FECAEAConsultar", ReplyAction = "*")]
        CaeaSolicitarResponse ConsultarCaea([MessageParameter(Name = "Auth")]Credentials autorizacion, [MessageParameter(Name = "Periodo")]int periodo, [MessageParameter(Name = "Orden")]short orden);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="periodo"></param>
        /// <param name="orden"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FECAEAConsultar", Action = "http://ar.gov.afip.dif.FEV1/FECAEAConsultar", ReplyAction = "*")]
        Task<CaeaSolicitarResponse> ConsultarCaeaAsync(Credentials autorizacion, int periodo, short orden);

        [OperationContract(Name = "FEParamGetCotizacion", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetCotizacion", ReplyAction = "*")]
        CotizacionResponse ObtenerCotizacion([MessageParameter(Name = "Auth")]Credentials autorizacion, [MessageParameter(Name = "MonId")]string idMoneda);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <param name="idMoneda"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetCotizacion", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetCotizacion", ReplyAction = "*")]
        Task<CotizacionResponse> ObtenerCotizacionAsync(Credentials autorizacion, string idMoneda);

        [OperationContract(Name = "FEParamGetTiposTributos", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposTributos", ReplyAction = "*")]
        TributoResponse ObtenerTiposDeTributo([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetTiposTributos", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposTributos", ReplyAction = "*")]
        Task<TributoResponse> ObtenerTiposDeTributoAsync(Credentials autorizacion);

        [OperationContract(Name = "FEParamGetTiposMonedas", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposMonedas", ReplyAction = "*")]
        TipoDeMonedaResponse ObtenerTiposDeMoneda([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetTiposMonedas", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposMonedas", ReplyAction = "*")]
        Task<TipoDeMonedaResponse> ObtenerTiposDeMonedaAsync(Credentials autorizacion);

        [OperationContract(Name = "FEParamGetTiposIva", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposIva", ReplyAction = "*")]
        TipoDeIvaResponse ObtenerTiposDeIva([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetTiposIva", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposIva", ReplyAction = "*")]
        Task<TipoDeIvaResponse> ObtenerTiposDeIvaAsync(Credentials autorizacion);

        [OperationContract(Name = "FEParamGetTiposOpcional", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposOpcional", ReplyAction = "*")]
        TipoDeOpcionalResponse ObtenesTiposOpcionales([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetTiposOpcional", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposOpcional", ReplyAction = "*")]
        Task<TipoDeOpcionalResponse> ObtenesTiposOpcionalesAsync(Credentials autorizacion);

        [OperationContract(Name = "FEParamGetTiposConcepto", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposConcepto", ReplyAction = "*")]
        TipoDeConceptoResponse ObtenerTiposDeConcepto([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetTiposConcepto", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposConcepto", ReplyAction = "*")]
        Task<TipoDeConceptoResponse> ObtenerTiposDeConceptoAsync(Credentials autorizacion);

        [OperationContract(Name = "FEParamGetPtosVenta", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetPtosVenta", ReplyAction = "*")]
        PuntoDeVentaResponse ObtenerPuntosDeVenta([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetPtosVenta", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetPtosVenta", ReplyAction = "*")]
        Task<PuntoDeVentaResponse> ObtenerPuntosDeVentaAsync(Credentials autorizacion);

        [OperationContract(Name = "FEParamGetTiposCbte", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposCbte", ReplyAction = "*")]
        TipoDeComprobanteResponse ObtenerTiposDeComprobante([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetTiposCbte", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposCbte", ReplyAction = "*")]
        Task<TipoDeComprobanteResponse> ObtenerTiposDeComprobanteAsync(Credentials autorizacion);

        [OperationContract(Name = "FEParamGetTiposDoc", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposDoc", ReplyAction = "*")]
        TipoDeDocumentoResponse ObtenerTiposDeDocumento([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetTiposDoc", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposDoc", ReplyAction = "*")]
        Task<TipoDeDocumentoResponse> ObtenerTiposDeDocumentoAsync(Credentials autorizacion);

        [OperationContract(Name = "FEParamGetTiposPaises", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposPaises", ReplyAction = "*")]
        TipoDePaisResponse ObtenerListadoDePaises([MessageParameter(Name = "Auth")]Credentials autorizacion);

        /// <summary>
        ///
        /// </summary>
        /// <param name="autorizacion"></param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Name = "FEParamGetTiposPaises", Action = "http://ar.gov.afip.dif.FEV1/FEParamGetTiposPaises", ReplyAction = "*")]
        Task<TipoDePaisResponse> ObtenerListadoDePaisesAsync(Credentials autorizacion);
    }
}