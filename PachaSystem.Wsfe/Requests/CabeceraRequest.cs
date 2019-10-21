// <copyright file="CabeceraRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Requests
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECabRequest", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CabeceraRequest
    {
        private int _cantidadDeRegistros;
        private int _puntoDeVenta;
        private int _tipoDeComprobante;

        [DataMember(IsRequired = true, Name = "CantReg", Order = 0)]
        public int CantidadDeRegistros
        {
            get
            {
                return _cantidadDeRegistros;
            }

            set
            {
                _cantidadDeRegistros = value;
            }
        }

        [DataMember(IsRequired = true, Name = "PtoVta", Order = 1)]
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

        [DataMember(IsRequired = true, Name = "CbteTipo", Order = 2)]
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
    }
}
