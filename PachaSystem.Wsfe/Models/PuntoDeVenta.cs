// <copyright file="PuntoDeVenta.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "PtoVenta", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class PuntoDeVenta
    {
        private int _numero;
        private string _tipoDeEmision;
        private string _bloqueado;
        private string _fechaDeBaja;

        [DataMember(Name = "Nro", Order = 0)]
        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                _numero = value;
            }
        }

        [DataMember(Name = "Emision", Order = 1)]
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

        [DataMember(Name = "Bloqueado", Order = 2)]
        public string Bloqueado
        {
            get
            {
                return _bloqueado;
            }

            set
            {
                _bloqueado = value;
            }
        }

        [DataMember(Name = "FchBaja", Order = 3)]
        public string FechaDeBaja
        {
            get
            {
                return _fechaDeBaja;
            }

            set
            {
                _fechaDeBaja = value;
            }
        }
    }
}