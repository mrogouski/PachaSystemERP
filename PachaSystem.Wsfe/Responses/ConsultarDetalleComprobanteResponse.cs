// <copyright file="ConsultarComprobanteResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using PachaSystem.Wsfe.Models;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(Name = "FECompConsResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class ConsultarDetalleComprobanteResponse : CaeDetalleResponse
    {
        private string _resultado;
        private string _codigoAutorizacion;
        private string _tipoEmision;
        private string _fechaVencimiento;
        private string _fechaProceso;
        private List<Observaciones> _observaciones;
        private int _puntoVenta;
        private int _tipoComprobante;

        [DataMember(Name = "Resultado", Order = 0)]
        public new string Resultado
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

        [DataMember(Name = "CodAutorizacion", Order = 1)]
        public string CodigoAutorizacion
        {
            get
            {
                return _codigoAutorizacion;
            }

            set
            {
                _codigoAutorizacion = value;
            }
        }

        [DataMember(Name = "EmisionTipo", Order = 2)]
        public string TipoEmision
        {
            get
            {
                return _tipoEmision;
            }

            set
            {
                _tipoEmision = value;
            }
        }

        [DataMember(Name = "FchVto", Order = 3)]
        public string FechaVencimiento
        {
            get
            {
                return _fechaVencimiento;
            }

            set
            {
                _fechaVencimiento = value;
            }
        }

        [DataMember(Name = "FchProceso", Order = 4)]
        public string FechaProceso
        {
            get
            {
                return _fechaProceso;
            }

            set
            {
                _fechaProceso = value;
            }
        }

        [DataMember(Name = "Observaciones", Order = 5)]
        public new List<Observaciones> Observaciones
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

        [DataMember(Name = "PtoVta", Order = 6)]
        public int PuntoVenta
        {
            get
            {
                return _puntoVenta;
            }

            set
            {
                _puntoVenta = value;
            }
        }

        [DataMember(Name = "CbteTipo", Order = 7)]
        public int TipoComprobante
        {
            get
            {
                return _tipoComprobante;
            }

            set
            {
                _tipoComprobante = value;
            }
        }
    }
}