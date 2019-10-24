// <copyright file="CaeDetalleResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAEDetResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeDetalleResponse : DetalleResponse
    {
        private string _cae;
        private string _fechaVencimientoCAE;

        [DataMember(Name = "CAE", Order = 0)]
        public string CAE
        {
            get
            {
                return _cae;
            }

            set
            {
                _cae = value;
            }
        }

        [DataMember(Name = "CAEFchVto", Order = 1)]
        public string FechaVencimientoCAE
        {
            get
            {
                return _fechaVencimientoCAE;
            }

            set
            {
                _fechaVencimientoCAE = value;
            }
        }
    }
}
