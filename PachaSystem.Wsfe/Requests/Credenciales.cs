// <copyright file="Credenciales.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Requests
{
    using System;
    using System.Runtime.Serialization;

    [DataContract(Name = "FEAuthRequest", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class Credenciales
    {
        private string _token;
        private string _sign;
        private long _cuit;

        [DataMember(Name = "Token")]
        public string Token
        {
            get
            {
                return _token;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Token");
                }
                else
                {
                    _token = value;
                }
            }
        }

        [DataMember(Name = "Sign")]
        public string Sign
        {
            get
            {
                return _sign;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Sign");
                }
                else
                {
                    _sign = value;
                }
            }
        }

        [DataMember(Name = "Cuit")]
        public long Cuit
        {
            get
            {
                return _cuit;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Cuit");
                }
                else
                {
                    _cuit = value;
                }
            }
        }
    }
}
