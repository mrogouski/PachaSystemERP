// <copyright file="CaeDetalleRequest.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Requests
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAEDetRequest", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeDetalleRequest : DetalleRequest
    {
    }
}