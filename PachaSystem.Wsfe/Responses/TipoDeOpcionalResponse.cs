// <copyright file="TipoDeOpcionalResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "OpcionalTipoResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class TipoDeOpcionalResponse
    {
        private List<TipoDeOpcional> _tiposDeOpcional;
        private List<Error> _errores;
        private List<Evento> _eventos;

        [DataMember(Name = "ResultGet", Order = 0)]
        public List<TipoDeOpcional> TiposDeOpcional
        {
            get
            {
                return _tiposDeOpcional;
            }

            set
            {
                _tiposDeOpcional = value;
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