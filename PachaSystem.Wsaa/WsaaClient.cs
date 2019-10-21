// <copyright file="WsaaClient.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsaa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Representa el cliente del Web Service de Autenticación y Autorización (WSAA).
    /// </summary>
    public class WsaaClient : ClientBase<IWsaaClient>, IWsaaClient
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsaaClient"/>.
        /// </summary>
        public WsaaClient()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsaaClient"/> con los parámetros especificados.
        /// </summary>
        /// <param name="endpointConfigurationName">Nombre de la configuración de punto de acceso.</param>
        public WsaaClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsaaClient"/>.
        /// </summary>
        /// <param name="endpointConfigurationName">Nombre de la configuración de punto de acceso.</param>
        /// <param name="remoteAddress">Direccion remota del servicio web.</param>
        public WsaaClient(string endpointConfigurationName, string remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsaaClient"/>.
        /// </summary>
        /// <param name="endpointConfigurationName">Nombre de la configuración de punto de acceso.</param>
        /// <param name="remoteAddress">Proporciona una dirección de red única que usa un cliente para comunicarse con un extremo de servicio.</param>
        public WsaaClient(string endpointConfigurationName, EndpointAddress remoteAddress)
            : base(endpointConfigurationName, remoteAddress)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="WsaaClient"/>.
        /// </summary>
        /// <param name="binding">Contiene los elementos de enlace que especifican los protocolos, transportes y codificadores de mensaje utilizados para la comunicación entre clientes y servicios.</param>
        /// <param name="remoteAddress">Proporciona una dirección de red única que usa un cliente para comunicarse con un extremo de servicio.</param>
        public WsaaClient(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        {
        }

        /// <summary>
        /// Envia una solicitud de logueo al Web Service de Autenticación y Autorización (WSAA).
        /// </summary>
        /// <param name="request">Representa el mensaje de solicitud.</param>
        /// <returns>Un <see cref="LoginResponse"/> representando el resultado de la solicitud.</returns>
        public LoginResponse Login(LoginRequest request)
        {
            return this.Channel.Login(request);
        }

        /// <summary>
        /// Envia una solicitud de logueo asíncrona al Web Service de Autenticación y Autorización (WSAA).
        /// </summary>
        /// <param name="request">Representa el mensaje de solicitud.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            return this.Channel.LoginAsync(request);
        }
    }
}
