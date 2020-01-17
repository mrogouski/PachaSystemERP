// <copyright file="IWsaaChannel.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsaa
{
    using System.ServiceModel;

    /// <summary>
    /// Define el comportamiento de las solicitudes salientes y de los canales de solicitud/respuesta utilizados por el cliente.
    /// </summary>
    public interface IWsaaChannel : IWsaaClient, IClientChannel
    {
    }
}