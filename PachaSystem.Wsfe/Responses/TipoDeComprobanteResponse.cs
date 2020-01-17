// <copyright file="TipoDeComprobanteResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "CbteTipoResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class TipoDeComprobanteResponse
    {
        private List<TipoDeComprobante> _tiposDeComprobante;
        private List<Error> _errores;
        private List<Evento> _eventos;

        [DataMember(Name = "ResultGet", Order = 0)]
        public List<TipoDeComprobante> TiposDeComprobante
        {
            get
            {
                return _tiposDeComprobante;
            }

            set
            {
                _tiposDeComprobante = value;
            }
        }

        [DataMember(Name = "Errors", Order = 1)]
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
    }
}