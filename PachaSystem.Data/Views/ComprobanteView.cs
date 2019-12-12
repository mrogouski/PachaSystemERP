using PachaSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PachaSystem.Data.Views
{
    public class ComprobanteView
    {
        /* Datos del Comprobante */
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
        /* Datos del Cliente */
        public string RazonSocial { get; set; }

        public string NumeroDocumento { get; set; }

        public string TipoResponsable { get; set; }

        public string Domicilio { get; set; }

        /* Detalle del Comprobante */
        public int Cantidad { get; set; }

        public decimal BaseImponible { get; set; }

        public decimal Subtotal { get; set; }

        public decimal ImporteIva { get; set; }
        /* Datos del Producto */
        public IEnumerable<Producto> Productos { get; set; }

        public string Codigo { get; set; }

        public string DescripcionProductoServicio { get; set; }

        public decimal PrecioUnitario { get; set; }

        public string DescripcionIva { get; set; }

        public decimal AlicuotaIva { get; set; }
    }
}
