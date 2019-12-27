namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ComprobanteAsociado
    {
        public int ID { get; set; }

        public int TipoComprobanteID { get; set; }

        public int PuntoDeVenta { get; set; }

        public string NumeroComprobante { get; set; }

        public long Cuit { get; set; }

        public DateTime FechaComprobante { get; set; }

        public int ComprobanteID { get; set; }

        public virtual TipoComprobante TipoComprobante { get; set; }

        public virtual Receipt Comprobante { get; set; }
    }
}
