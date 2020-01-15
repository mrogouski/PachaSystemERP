// <copyright file="AlicuotaIva.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Representa una alícuota y sus importes asociados a un comprobante.
    /// </summary>
    [DataContract(Name = "AlicIva", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class AlicuotaIva
    {
        private int _id;
        private double _baseImponible;
        private double _importe;

        [DataMember(EmitDefaultValue = false, IsRequired = true, Name = "Id", Order = 0)]
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(ID));
                }
                else
                {
                    _id = value;
                }
            }
        }

        [DataMember(EmitDefaultValue = false, IsRequired = true, Name = "BaseImp", Order = 1)]
        public double BaseImponible
        {
            get
            {
                return _baseImponible;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(BaseImponible));
                }
                else
                {
                    _baseImponible = value;
                }
            }
        }

        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "Importe", Order = 2)]
        public double Importe
        {
            get
            {
                return _importe;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Importe));
                }
                else
                {
                    _importe = value;
                }
            }
        }
    }
}
