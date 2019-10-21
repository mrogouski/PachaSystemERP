// <copyright file="CaeResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using PachaSystem.Wsfe.Models;

    [DataContract(Name = "FECAEResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeResponse
    {
        private CaeCabeceraResponse _cabeceraResponse;
        private List<CaeDetalleResponse> _detalleResponse;
        private List<Evento> _eventos;
        private List<Error> _errores;

        [DataMember(Name = "FeCabResp", Order = 0)]
        public CaeCabeceraResponse CabeceraResponse
        {
            get
            {
                return _cabeceraResponse;
            }

            set
            {
                _cabeceraResponse = value;
            }
        }

        [DataMember(Name = "FeDetResp", Order = 1)]
        public List<CaeDetalleResponse> DetalleResponse
        {
            get
            {
                return _detalleResponse;
            }

            set
            {
                _detalleResponse = value;
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
