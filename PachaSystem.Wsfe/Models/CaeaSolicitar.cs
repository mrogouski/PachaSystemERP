// <copyright file="CaeaSolicitar.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using PachaSystem.Wsfe.Models;

    [DataContract(Name = "FECAEAGet", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class CaeaSolicitar
    {
        private string _caea;
        private int _periodo;
        private short _orden;
        private string _fechaVigenciaDesde;
        private string _fechaVigenciaHasta;
        private string _fechaTopeDeInforme;
        private string _fechaDeProceso;
        private List<Observaciones> _observaciones;

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

        [DataMember(Name = "Periodo", Order = 1)]
        public int Periodo
        {
            get
            {
                return _periodo;
            }

            set
            {
                _periodo = value;
            }
        }

        [DataMember(Name = "Orden", Order = 2)]
        public short Orden
        {
            get
            {
                return _orden;
            }

            set
            {
                _orden = value;
            }
        }

        [DataMember(Name = "FchVigDesde", Order = 3)]
        public string FechaVigenteDesde
        {
            get
            {
                return _fechaVigenciaDesde;
            }

            set
            {
                _fechaVigenciaDesde = value;
            }
        }

        [DataMember(Name = "FchVigHasta", Order = 4)]
        public string FechaVigenteHasta
        {
            get
            {
                return _fechaVigenciaHasta;
            }

            set
            {
                _fechaVigenciaHasta = value;
            }
        }

        [DataMember(Name = "FchTopeInf", Order = 5)]
        public string FechaTopeDeInforme
        {
            get
            {
                return _fechaTopeDeInforme;
            }

            set
            {
                _fechaTopeDeInforme = value;
            }
        }

        [DataMember(Name = "FchProceso", Order = 6)]
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

        [DataMember(Name = "Observaciones", Order = 7)]
        public List<Observaciones> Observaciones
        {
            get
            {
                return _observaciones;
            }

            set
            {
                _observaciones = value;
            }
        }
    }
}
