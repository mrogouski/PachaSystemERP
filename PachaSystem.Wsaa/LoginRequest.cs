// <copyright file="LoginRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsaa
{
    using System;
    using System.ServiceModel;

    [MessageContract(WrapperName = "loginCms", WrapperNamespace = "http://wsaa.view.sua.dvadac.desein.afip.gov")]
    public class LoginRequest
    {
        [MessageBodyMember(Name = "in0", Namespace = "http://wsaa.view.sua.dvadac.desein.afip.gov", Order = 0)]
        private string _ticket;

        public LoginRequest(string ticket)
        {
            if (string.IsNullOrWhiteSpace(ticket))
            {
                throw new ArgumentNullException(nameof(ticket));
            }

            _ticket = ticket;
        }
    }
}