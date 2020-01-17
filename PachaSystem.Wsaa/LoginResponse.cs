// <copyright file="LoginResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsaa
{
    using System.ServiceModel;

    /// <summary>
    /// Representa un mensaje de respuesta del Web Service de Autenticación y Autorización (WSAA).
    /// </summary>
    [MessageContract(WrapperName = "loginCmsResponse", WrapperNamespace = "http://wsaa.view.sua.dvadac.desein.afip.gov")]
    public class LoginResponse
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="LoginResponse"/>.
        /// </summary>
        public LoginResponse()
        {
        }

        /// <summary>
        /// Obtiene o establece las credenciales obtenidas del Web Service.
        /// </summary>
        [MessageBodyMember(Name = "loginCmsReturn", Namespace = "http://wsaa.view.sua.dvadac.desein.afip.gov", Order = 0)]
        public string Credentials { get; set; }
    }
}