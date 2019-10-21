namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ComprobanteCliente
    {
        public int ComprobanteID { get; set; }

        public int ClienteID { get; set; }

        public double PorcentajeTitularidad { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
