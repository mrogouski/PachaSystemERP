// <copyright file="DetalleResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "FEDetResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class DetalleResponse
    {
        private int _concepto;
        private int _tipoDocumento;
        private long _numeroDocumento;
        private long _numeroComprobanteInicial;
        private long _numeroComprobanteFinal;
        private string _fechaComprobante;
        private string _resultado;
        private List<Observaciones> _observaciones;

        [DataMember(Name = "Concepto", Order = 0)]
        public int Concepto
        {
            get
            {
                return _concepto;
            }

            set
            {
                _concepto = value;
            }
        }

        [DataMember(Name = "DocTipo", Order = 1)]
        public int TipoDocumento
        {
            get
            {
                return _tipoDocumento;
            }

            set
            {
                _tipoDocumento = value;
            }
        }

        [DataMember(Name = "DocNro", Order = 2)]
        public long NumeroDocumento
        {
            get
            {
                return _numeroDocumento;
            }

            set
            {
                _numeroDocumento = value;
            }
        }

        [DataMember(Name = "CbteDesde", Order = 3)]
        public long NumeroComprobanteInicial
        {
            get
            {
                return _numeroComprobanteInicial;
            }

            set
            {
                _numeroComprobanteInicial = value;
            }
        }

        [DataMember(Name = "CbteHasta", Order = 4)]
        public long NumeroComprobanteFinal
        {
            get
            {
                return _numeroComprobanteFinal;
            }

            set
            {
                _numeroComprobanteFinal = value;
            }
        }

        [DataMember(Name = "CbteFch", Order = 5)]
        public string FechaComprobante
        {
            get
            {
                return _fechaComprobante;
            }

            set
            {
                _fechaComprobante = value;
            }
        }

        [DataMember(Name = "Resultado", Order = 6)]
        public string Resultado
        {
            get
            {
                return _resultado;
            }

            set
            {
                _resultado = value;
            }
        }

        [DataMember(Name = "Observaciones", Order = 7)]
        public List<Observaciones> Observaciones
        {
            get
            {
                return _observaciones;
            }

            set
            {
                _observaciones = value;
            }
        }
    }
}