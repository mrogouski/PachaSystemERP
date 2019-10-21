// <copyright file="TipoDeMonedaResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using PachaSystem.Wsfe.Models;

    [DataContract(Name = "MonedaResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class TipoDeMonedaResponse
    {
        private List<TipoDeMoneda> _tiposDeMoneda;
        private List<Error> _errores;
        private List<Evento> _eventos;

        [DataMember(Name = "ResultGet", Order = 0)]
        public List<TipoDeMoneda> TiposDeMoneda
        {
            get
            {
                return _tiposDeMoneda;
            }

            set
            {
                _tiposDeMoneda = value;
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
        public List<Evento> Events
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
