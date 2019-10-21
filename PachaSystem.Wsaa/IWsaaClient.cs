// <copyright file="IWsaaClient.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsaa
{
    using System.ServiceModel;
    using System.Threading.Tasks;

    /// <summary>
    /// Define el comportamiento del canal de solicitud/respuesta del cliente WSAA.
    /// </summary>
    [ServiceContract(Name ="LoginCMS", Namespace = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms")]
    public interface IWsaaClient
    {
        /// <summary>
        /// Envia una solicitud de logueo al Web Service de Autenticación y Autorización (WSAA).
        /// </summary>
        /// <param name="request">Representa el mensaje de solicitud.</param>
        /// <returns>Un <see cref="LoginResponse"/> representando el resultado de la solicitud.</returns>
        [OperationContract(Action ="", ReplyAction ="*")]
        [FaultContract(typeof(LoginFault), Action ="", Name ="fault")]
        LoginResponse Login(LoginRequest request);

        /// <summary>
        /// Envia una solicitud de logueo asíncrona al Web Service de Autenticación y Autorización (WSAA).
        /// </summary>
        /// <param name="request">Representa el mensaje de solicitud.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [OperationContract(Action = "", ReplyAction = "*")]
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
