// <copyright file="TipoDeComprobante.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "CbteTipo", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class TipoDeComprobante
    {
        private int _id;
        private string _descripcion;
        private string _vigenteDesde;
        private string _vigenteHasta;

        [DataMember(Name = "Id", Order = 0)]
        public int ID
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

        [DataMember(Name = "FchDesde", Order = 2)]
        public string VigenteDesde
        {
            get
            {
                return _vigenteDesde;
            }

            set
            {
                _vigenteDesde = value;
            }
        }

        [DataMember(Name = "FchHasta", Order = 3)]
        public string VigenteHasta
        {
            get
            {
                return _vigenteHasta;
            }

            set
            {
                _vigenteHasta = value;
            }
        }
    }
}
