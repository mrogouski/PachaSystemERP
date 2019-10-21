// <copyright file="DetalleResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using PachaSystem.Wsfe.Models;

    [DataContract(Name = "FEDetResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class DetalleResponse
    {
        private int _concepto;
        private int _tipoDeDocumento;
        private long _numeroDeDocumento;
        private long _comprobanteDesde;
        private long _comprobanteHasta;
        private string _comprobanteFecha;
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
        public int TipoDeDocumento
        {
            get
            {
                return _tipoDeDocumento;
            }

            set
            {
                _tipoDeDocumento = value;
            }
        }

        [DataMember(Name = "DocNro", Order = 2)]
        public long NumeroDeDocumento
        {
            get
            {
                return _numeroDeDocumento;
            }

            set
            {
                _numeroDeDocumento = value;
            }
        }

        [DataMember(Name = "CbteDesde", Order = 3)]
        public long ComprobanteDesde
        {
            get
            {
                return _comprobanteDesde;
            }

            set
            {
                _comprobanteDesde = value;
            }
        }

        [DataMember(Name = "CbteHasta", Order = 4)]
        public long ComprobanteHasta
        {
            get
            {
                return _comprobanteHasta;
            }

            set
            {
                _comprobanteHasta = value;
            }
        }

        [DataMember(Name = "CbteFch", Order = 5)]
        public string ComprobanteFecha
        {
            get
            {
                return _comprobanteFecha;
            }

            set
            {
                _comprobanteFecha = value;
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
