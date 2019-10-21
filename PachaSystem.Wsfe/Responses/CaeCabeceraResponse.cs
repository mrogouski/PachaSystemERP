// <copyright file="CaeCabeceraResponse.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Responses
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAECabResponse", Namespace ="http://ar.gov.afip.dif.FEV1/")]
    public class CaeCabeceraResponse : CabeceraResponse
    {
    }
}
