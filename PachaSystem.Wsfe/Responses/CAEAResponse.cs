// <copyright file="CaeaResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAEAResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeaResponse
    {
        private CaeaCabeceraResponse _caeaCabeceraResponse;
        private List<CaeaDetalleResponse> _caeaDetalleResponse;
        private List<Evento> _eventos;
        private List<Error> _errores;

        [DataMember(Name = "FeCabResp", Order = 0)]
        public CaeaCabeceraResponse CaeaCabeceraResponse
        {
            get
            {
                return _caeaCabeceraResponse;
            }

            set
            {
                _caeaCabeceraResponse = value;
            }
        }

        [DataMember(Name = "FeDetResp", Order = 1)]
        public List<CaeaDetalleResponse> CaeaDetalleResponse
        {
            get
            {
                return _caeaDetalleResponse;
            }

            set
            {
                _caeaDetalleResponse = value;
            }
        }

        [DataMember(Name = "Events", Order = 2)]
        public List<Evento> Eventos
        {
            get
            {
                return _eventos;
            }

            set
            {
                _eventos = value;
            }
        }

        [DataMember(Name = "Errors", Order = 3)]
        public List<Error> Errores
        {
            get
            {
                return _errores;
            }

            set
            {
                _errores = value;
            }
        }
    }
}