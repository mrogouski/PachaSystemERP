// <copyright file="TipoDeResponsabilidad.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Tipo de Responsabilidades de IVA.
    /// </summary>
    public enum TipoDeResponsabilidadIva
    {
        IVA_RESPONSABLE_INSCRIPTO = 1,
        IVA_RESPONSABLE_NO_INSCRIPTO = 2,
        IVA_NO_RESPONSABLE = 3,
        IVA_SUJETO_EXENTO = 4,
        CONSUMIDOR_FINAL = 5,
        RESPONSABLE_MONOTRIBUTO = 6,
        SUJETO_NO_CATEGORIZADO = 7,
        PROVEEDOR_DEL_EXTERIOR = 8,
        CLIENTE_DEL_EXTERIOR = 9,
        IVA_LIBERADO_LEY_N_19640 = 10,
        IVA_RESPONSABLE_INSCRIPTO_AGENTE_DE_PERCEPCION = 11,
        PEQUEÑO_CONTRIBUYENTE_EVENTUAL = 12,
        MONOTRIBUTISTA_SOCIAL = 13,
        PEQUEÑO_CONTRIBUYENTE_EVENTUAL_SOCIAL = 14,
    }
}
