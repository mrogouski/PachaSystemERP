// <copyright file="TipoDePais.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "PaisTipo", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class TipoDePais
    {
        private short _id;
        private string _descripcion;

        [DataMember(Name = "Id", Order = 0)]
        public short ID
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

        [DataMember(Name = "Desc", Order = 1)]
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }
    }
}