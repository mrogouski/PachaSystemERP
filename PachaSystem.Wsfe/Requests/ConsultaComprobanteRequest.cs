// <copyright file="ConsultaComprobanteRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Requests
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECompConsultaReq", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class ConsultaComprobanteRequest
    {
        private int _tipoDeComprobante;
        private long _numerodeComprobante;
        private int _puntoDeVenta;

        [DataMember(Name = "CbteTipo", Order = 0)]
        public int TipoDeComprobante
        {
            get
            {
                return _tipoDeComprobante;
            }

            set
            {
                _tipoDeComprobante = value;
            }
        }

        [DataMember(Name = "CbteNro", Order = 1)]
        public long NumeroDeComprobante
        {
            get
            {
                return _numerodeComprobante;
            }

            set
            {
                _numerodeComprobante = value;
            }
        }

        [DataMember(Name = "PtoVta", Order = 2)]
        public int PuntoDeVenta
        {
            get
            {
                return _puntoDeVenta;
            }

            set
            {
                _puntoDeVenta = value;
            }
        }
    }
}
