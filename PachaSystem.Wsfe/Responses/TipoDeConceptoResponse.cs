// <copyright file="TipoDeConceptoResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "ConceptoTipoResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class TipoDeConceptoResponse
    {
        private List<TipoDeConcepto> _tiposDeConcepto;
        private List<Error> _errores;
        private List<Evento> _eventos;

        [DataMember(Name = "ResultGet")]
        public List<TipoDeConcepto> TiposDeConcepto
        {
            get
            {
                return _tiposDeConcepto;
            }

            set
            {
                _tiposDeConcepto = value;
            }
        }

        [DataMember(Name = "Errors")]
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

        [DataMember(Name = "Events")]
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