// <copyright file="RecuperarUltimoComprobanteResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using PachaSystem.Wsfe.Models;

    [DataContract(Name = "FERecuperaLastCbteResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class RecuperarUltimoComprobanteResponse
    {
        private int _puntoDeVenta;
        private int _tipoDeComprobante;
        private int _numeroDeComprobante;
        private List<Error> _errores;
        private List<Evento> _eventos;

        [DataMember(Name = "PtoVta", Order = 0)]
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

        [DataMember(Name = "CbteTipo", Order = 1)]
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

        [DataMember(Name = "CbteNro", Order = 2)]
        public int NumeroDeComprobante
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

        [DataMember(Name = "Errors", Order = 3)]
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

        [DataMember(Name = "Events", Order = 4)]
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
