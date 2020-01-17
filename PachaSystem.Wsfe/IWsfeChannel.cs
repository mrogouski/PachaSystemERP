// <copyright file="IWsfeChannel.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe
{
    using System.ServiceModel;

    public interface IWsfeChannel : IWsfeClient, IClientChannel
    {
    }
}