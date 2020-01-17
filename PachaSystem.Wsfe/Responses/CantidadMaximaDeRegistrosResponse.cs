// <copyright file="CantidadMaximaDeRegistrosResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "FERegXReqResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CantidadMaximaDeRegistrosResponse
    {
        private int _cantidadMaximaDeRegistros;
        private List<Error> _errores;
        private List<Evento> _eventos;

        [DataMember(Name = "RegxReq", Order = 0)]
        public int CantidadMaximaDeRegistros
        {
            get
            {
                return _cantidadMaximaDeRegistros;
            }

            set
            {
                _cantidadMaximaDeRegistros = value;
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