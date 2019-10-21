// <copyright file="Evento.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Wsfe.Models
{
    using System.Runtime.Serialization;

    [DataContract(Name = "Evt", Namespace = "http://ar.gov.afip.dif.FEV1/")]
    public class Evento
    {
        private int _codigo;
        private string _mensaje;

        [DataMember(Name = "Code", Order = 0)]
        public int Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        [DataMember(Name = "Msg", Order = 1)]
        public string Mensaje
        {
            get
            {
                return _mensaje;
            }

            set
            {
                _mensaje = value;
            }
        }
    }
}
