// <copyright file="CaeaSinMovimiento.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "FECAEASinMov", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeaSinMovimiento
    {
        private string _caea;
        private string _fechaDeProceso;
        private int _puntoDeVenta;

        [DataMember(Name = "CAEA", Order = 0)]
        public string CAEA
        {
            get
            {
                return _caea;
            }

            set
            {
                _caea = value;
            }
        }

        [DataMember(Name = "FchProceso", Order = 1)]
        public string FechaDeProceso
        {
            get
            {
                return _fechaDeProceso;
            }

            set
            {
                _fechaDeProceso = value;
            }
        }

        [DataMember(Name = "PtoVta", Order = 2)]
        public int PuntoDeVenta
        {
            get
            {
                return _puntoDeVenta;
            }

            set
            {
                _puntoDeVenta = value;
            }
        }
    }
}
