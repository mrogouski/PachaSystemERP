// <copyright file="CaeaRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Requests
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAEARequest", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeaRequest
    {
        private CaeaCabeceraRequest _caeaCabeceraRequest;
        private List<CaeaDetalleRequest> _caeaDetalleRequest;

        [DataMember(Name = "FeCabReq", Order = 0)]
        public CaeaCabeceraRequest CabeceraRequest
        {
            get
            {
                return _caeaCabeceraRequest;
            }

            set
            {
                _caeaCabeceraRequest = value;
            }
        }

        [DataMember(Name = "FeDetReq", Order = 1)]
        public List<CaeaDetalleRequest> DetalleRequest
        {
            get
            {
                return _caeaDetalleRequest;
            }

            set
            {
                _caeaDetalleRequest = value;
            }
        }
    }
}
