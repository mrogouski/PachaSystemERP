// <copyright file="Cotizacion.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Cotizacion", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class Cotizacion
    {
        private string _idMoneda;
        private double _cotizacionMoneda;
        private string _fechaCotizacion;

        [DataMember(Name = "MonId", Order = 0)]
        public string IdMoneda
        {
            get
            {
                return _idMoneda;
            }

            set
            {
                _idMoneda = value;
            }
        }

        [DataMember(Name = "MonCotiz", Order = 1)]
        public double CotizacionMoneda
        {
            get
            {
                return _cotizacionMoneda;
            }

            set
            {
                _cotizacionMoneda = value;
            }
        }

        [DataMember(Name = "FchCotiz", Order = 2)]
        public string FechaCotizacion
        {
            get
            {
                return _fechaCotizacion;
            }

            set
            {
                _fechaCotizacion = value;
            }
        }
    }
}
