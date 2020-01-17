// <copyright file="LoginFault.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsaa
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Representa un fallo del Web Service de Autenticacion y Autorizacion (WSAA).
    /// </summary>
    [Serializable]
    [DataContract(Name = "LoginFault", Namespace = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms")]
    public class LoginFault : IExtensibleDataObject
    {
        [NonSerialized]
        public ExtensionDataObject _extensionData;

        public ExtensionDataObject ExtensionData { get => _extensionData; set => _extensionData = value; }
    }
}