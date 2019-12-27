namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cliente
    {
        public int ID { get; set; }

        public string RazonSocial { get; set; }

        public int TipoDocumentoID { get; set; }

        public string NumeroDocumento { get; set; }

        public int TipoResponsableID { get; set; }

        public string Domicilio { get; set; }

        public virtual ICollection<Receipt> Comprobante { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }

        public virtual TipoResponsable TipoResponsable { get; set; }
    }
}
