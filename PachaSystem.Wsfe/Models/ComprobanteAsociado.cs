// <copyright file="ComprobanteAsociado.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "CbteAsoc", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class ComprobanteAsociado
    {
        private int _tipoDeComprobante;
        private int _puntoDeVenta;
        private long _numeroDeComprobante;
        private string _cuit;
        private string _fechaDeComprobante;

        [DataMember(Name = "Tipo", Order = 0)]
        public int TipoDeComprobante
        {
            get
            {
                return _tipoDeComprobante;
            }

            set
            {
                _tipoDeComprobante = value;
            }
        }

        [DataMember(Name = "PtoVta", Order = 1)]
        public int PuntoDeVenta
        {
            get
            {
                return _puntoDeVenta;
            }

            set
            {
                _puntoDeVenta = value;
            }
        }

        [DataMember(Name = "Nro", Order = 2)]
        public long NumeroDeComprobante
        {
            get
            {
                return _numeroDeComprobante;
            }

            set
            {
                _numeroDeComprobante = value;
            }
        }

        [DataMember(Name = "Cuit", Order = 3)]
        public string Cuit
        {
            get
            {
                return _cuit;
            }

            set
            {
                _cuit = value;
            }
        }

        [DataMember(Name = "CbteFech", Order = 4)]
        public string FechaDeComprobante
        {
            get
            {
                return _fechaDeComprobante;
            }

            set
            {
                _fechaDeComprobante = value;
            }
        }
    }
}