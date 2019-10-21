// <copyright file="LoginRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsaa
{
    using System;
    using System.ServiceModel;

    /// <summary>
    /// Representa un mensaje de solicitud de acceso al Web Service de Autenticación y Autorización (WSAA).
    /// </summary>
    [MessageContract(WrapperName = "loginCms", WrapperNamespace = "http://wsaa.view.sua.dvadac.desein.afip.gov")]
    public class LoginRequest
    {
        /// <summary>
        /// Obtiene o establece el ticket de acceso encriptado.
        /// </summary>
        [MessageBodyMember(Name = "in0", Namespace = "http://wsaa.view.sua.dvadac.desein.afip.gov", Order = 0)]
        private string _tique;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="LoginRequest"/>.
        /// </summary>
        /// <param name="ticket">Request Access Ticket</param>
        public LoginRequest(string tique)
        {
            if (string.IsNullOrWhiteSpace(tique))
            {
                throw new ArgumentException("El tique de solicitud de acceso no puede ser nulo", nameof(tique));
            }

            _tique = tique;
        }

        
        //public string Ticket { get; set; }
    }
}