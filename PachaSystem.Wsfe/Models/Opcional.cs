// <copyright file="Opcional.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Opcional", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class Opcional
    {
        private string _id;
        private string _valor;

        [DataMember(Name = "Id", Order = 0)]
        public string ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        [DataMember(Name = "Valor", Order = 1)]
        public string Valor
        {
            get
            {
                return _valor;
            }

            set
            {
                _valor = value;
            }
        }
    }
}