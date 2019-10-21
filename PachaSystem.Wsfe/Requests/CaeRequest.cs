// <copyright file="CaeRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Requests
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAERequest", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeRequest
    {
        private CaeCabeceraRequest _cabeceraRequest;
        private List<CaeDetalleRequest> _detalleRequest;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CaeRequest"/>.
        /// </summary>
        public CaeRequest()
        {
            _cabeceraRequest = new CaeCabeceraRequest();
            _detalleRequest = new List<CaeDetalleRequest>();
        }

        [DataMember(IsRequired = true, Name = "FeCabReq", Order = 0)]
        public CaeCabeceraRequest CabeceraRequest
        {
            get
            {
                return _cabeceraRequest;
            }

            set
            {
                _cabeceraRequest = value;
            }
        }

        [DataMember(IsRequired = true, Name = "FeDetReq", Order = 1)]
        public List<CaeDetalleRequest> DetalleRequest
        {
            get
            {
                return _detalleRequest;
            }

            set
            {
                _detalleRequest = value;
            }
        }
    }
}
