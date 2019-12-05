namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Producto
    {
        public int ID { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public decimal PrecioUnitario { get; set; }

        public short IvaID { get; set; }

        public int? RubroID { get; set; }

        public DateTime? FechaBaja { get; set; }

        public virtual Iva Iva { get; set; }

        public virtual Rubro Rubro { get; set; }

        public virtual ICollection<DetalleComprobante> DetalleComprobante { get; set; }
    }
}
