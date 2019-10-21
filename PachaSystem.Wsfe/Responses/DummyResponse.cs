// <copyright file="DummyResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Runtime.Serialization;

    [DataContract(Name = "DummyResponse", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class DummyResponse
    {
        private string _appServer;
        private string _dbServer;
        private string _authServer;

        [DataMember(Name = "AppServer", Order = 0)]
        public string AppServer
        {
            get
            {
                return _appServer;
            }

            set
            {
                _appServer = value;
            }
        }

        [DataMember(Name = "DbServer", Order = 1)]
        public string DbServer
        {
            get
            {
                return _dbServer;
            }

            set
            {
                _dbServer = value;
            }
        }

        [DataMember(Name = "AuthServer", Order = 2)]
        public string AuthServer
        {
            get
            {
                return _authServer;
            }

            set
            {
                _authServer = value;
            }
        }
    }
}
