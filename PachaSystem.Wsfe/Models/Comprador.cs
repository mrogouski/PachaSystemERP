// <copyright file="Comprador.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Comprador", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class Comprador
    {
        private int _tipoDeDocumento;
        private string _numeroDeDocumento;
        private double _porcentaje;

        [DataMember(Name = "DocTipo", Order = 0)]
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

        [DataMember(Name = "DocNro", Order = 1)]
        public string NumeroDeDocumento
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

        [DataMember(Name = "Porcentaje", Order = 2)]
        public double PorcentajeTitularidad
        {
            get
            {
                return _porcentaje;
            }

            set
            {
                _porcentaje = value;
            }
        }
    }
}