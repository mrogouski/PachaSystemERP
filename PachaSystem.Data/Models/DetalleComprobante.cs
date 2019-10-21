// <copyright file="DetalleComprobante.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DetalleComprobante
    {
        public int ComprobanteID { get; set; }

        public int ProductoID { get; set; }

        public int Cantidad { get; set; }

        public decimal BaseImponible { get; set; }

        public decimal Subtotal { get; set; }

        public decimal ImporteIva { get; set; }

        public decimal ImporteTributo { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public Producto Producto { get; set; }
    }
}
