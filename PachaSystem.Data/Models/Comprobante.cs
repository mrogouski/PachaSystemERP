// <copyright file="Comprobante.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Comprobante
    {
        public Comprobante()
        {
            DetalleComprobante = new HashSet<DetalleComprobante>();
        }

        public int ID { get; set; }

        public int TipoComprobanteID { get; set; }

        public int TipoConceptoID { get; set; }

        public int PuntoVenta { get; set; }

        public int NumeroComprobante { get; set; }

        public string CAE { get; set; }

        public DateTime FechaVencimientoCAE { get; set; }

        public DateTime FechaComprobante { get; set; }

        public decimal ImporteTotal { get; set; }

        public decimal ImporteNetoNoGravado { get; set; }

        public decimal ImporteNeto { get; set; }

        public decimal ImporteExento { get; set; }

        public decimal ImporteTotalTributo { get; set; }

        public decimal ImporteTotalIva { get; set; }

        public DateTime? FechaInicioServicio { get; set; }

        public DateTime? FechaFinalizacionServicio { get; set; }

        public DateTime? FechaVencimientoPago { get; set; }

        public int TipoMonedaID { get; set; }

        public double CotizacionMoneda { get; set; }

        public int ClienteID { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<DetalleComprobante> DetalleComprobante { get; set; }

        public virtual TipoConcepto TipoConcepto { get; set; }

        public virtual TipoComprobante TipoComprobante { get; set; }

        public virtual TipoMoneda TipoMoneda { get; set; }
    }
}
