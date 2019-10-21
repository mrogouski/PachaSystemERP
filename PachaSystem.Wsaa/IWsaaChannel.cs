// <copyright file="IWsaaChannel.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsaa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Define el comportamiento de las solicitudes salientes y de los canales de solicitud/respuesta utilizados por el cliente.
    /// </summary>
    public interface IWsaaChannel : IWsaaClient, IClientChannel
    {
    }
}
