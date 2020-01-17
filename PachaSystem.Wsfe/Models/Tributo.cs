// <copyright file="Tributo.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Tributo", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class Tributo
    {
        private short _id;
        private string _descripcion;
        private double _baseImponible;
        private double _alicuota;
        private double _importe;

        [DataMember(Name = "Id", Order = 0)]
        public short ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        [DataMember(Name = "Desc", Order = 1)]
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                _descripcion = value;
            }
        }

        [DataMember(Name = "BaseImp", Order = 2)]
        public double BaseImponible
        {
            get
            {
                return _baseImponible;
            }

            set
            {
                _baseImponible = value;
            }
        }

        [DataMember(Name = "Alic", Order = 3)]
        public double Alicuota
        {
            get
            {
                return _alicuota;
            }

            set
            {
                _alicuota = value;
            }
        }

        [DataMember(Name = "Importe", Order = 4)]
        public double Importe
        {
            get
            {
                return _importe;
            }

            set
            {
                _importe = value;
            }
        }
    }
}