// <copyright file="TipoDeIvaResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "IvaTipoResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class TipoDeIvaResponse
    {
        private List<TipoDeIva> _tiposDeIva;
        private List<Error> _errores;
        private List<Evento> _eventos;

        [DataMember(Name = "ResultGet", Order = 0)]
        public List<TipoDeIva> TiposDeIva
        {
            get
            {
                return _tiposDeIva;
            }

            set
            {
                _tiposDeIva = value;
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