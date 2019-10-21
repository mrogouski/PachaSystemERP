// <copyright file="ConsultarComprobanteResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using PachaSystem.Wsfe.Models;

    [DataContract(Name = "FECompConsResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class ConsultarComprobanteResponse : CaeDetalleResponse
    {
        private string _resultado;
        private string _codigoDeAutorizacion;
        private string _tipoDeEmision;
        private string _fechaDeVencimiento;
        private string _fechaDeProceso;
        private List<Observaciones> _observaciones;
        private int _puntoDeVenta;
        private int _tipoDeComprobante;

        [DataMember(Name = "Resultado", Order = 0)]
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

        [DataMember(Name = "CodAutorizacion", Order = 1)]
        public string CodigoDeAutorizacion
        {
            get
            {
                return _codigoDeAutorizacion;
            }

            set
            {
                _codigoDeAutorizacion = value;
            }
        }

        [DataMember(Name = "EmisionTipo", Order = 2)]
        public string TipoDeEmision
        {
            get
            {
                return _tipoDeEmision;
            }

            set
            {
                _tipoDeEmision = value;
            }
        }

        [DataMember(Name = "FchVto", Order = 3)]
        public string FechaDeVencimiento
        {
            get
            {
                return _fechaDeVencimiento;
            }

            set
            {
                _fechaDeVencimiento = value;
            }
        }

        [DataMember(Name = "FchProceso", Order = 4)]
        public string FechaDeProceso
        {
            get
            {
                return _fechaDeProceso;
            }

            set
            {
                _fechaDeProceso = value;
            }
        }

        [DataMember(Name = "Observaciones", Order = 5)]
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

        [DataMember(Name = "PtoVta", Order = 6)]
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

        [DataMember(Name = "CbteTipo", Order = 7)]
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
