// <copyright file="Error.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Err", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class Error
    {
        private int _codigo;
        private string _mensaje;

        [DataMember(Name = "Code")]
        public int Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        [DataMember(Name = "Msg")]
        public string Mensaje
        {
            get
            {
                return _mensaje;
            }

            set
            {
                _mensaje = value;
            }
        }
    }
}