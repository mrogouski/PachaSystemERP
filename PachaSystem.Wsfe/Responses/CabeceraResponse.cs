// <copyright file="CabeceraResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECabResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CabeceraResponse
    {
        private long _cuit;
        private int _puntoDeVenta;
        private int _tipoDeComprobante;
        private string _fechaDeProceso;
        private int _cantidadDeRegistros;
        private string _resultado;
        private string _reproceso;

        [DataMember(Name = "Cuit", Order = 0)]
        public long CUIT
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

        [DataMember(Name = "CbteTipo", Order = 2)]
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

        [DataMember(Name = "FchProceso", Order = 3)]
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

        [DataMember(Name = "CantReg", Order = 4)]
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

        [DataMember(Name = "Resultado", Order = 5)]
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

        [DataMember(Name = "Reproceso", Order = 6)]
        public string Reproceso
        {
            get
            {
                return _reproceso;
            }

            set
            {
                _reproceso = value;
            }
        }
    }
}