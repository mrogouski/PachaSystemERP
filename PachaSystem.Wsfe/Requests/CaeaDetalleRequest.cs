// <copyright file="CaeaDetalleRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Requests
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAEADetRequest", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeaDetalleRequest : DetalleRequest
    {
        private string _caea;
        private string _fechaHoraGeneracionComprobante;

        [DataMember(Name = "CAEA", Order = 0)]
        public string CAEA
        {
            get
            {
                return _caea;
            }

            set
            {
                _caea = value;
            }
        }

        [DataMember(Name = "CbteFchHsGen", Order = 1)]
        public string FechaHoraGeneracionComprobante
        {
            get
            {
                return _fechaHoraGeneracionComprobante;
            }

            set
            {
                _fechaHoraGeneracionComprobante = value;
            }
        }
    }
}