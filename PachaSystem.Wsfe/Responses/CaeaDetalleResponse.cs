// <copyright file="CaeaDetalleResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAEADetResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeaDetalleResponse : DetalleResponse
    {
        private string _caea;

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
    }
}