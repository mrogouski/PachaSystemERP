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

        public short TipoCondicionIvaID { get; set; }

        public int? TipoTributoID { get; set; }

        public int? CategoriaProductoID { get; set; }

        public DateTime? FechaBaja { get; set; }

        public virtual TipoCondicionIva TipoCondicionIva { get; set; }

        public virtual Tributo TipoTributo { get; set; }

        public virtual CategoriaProducto CategoriaProducto { get; set; }

        public virtual ICollection<DetalleComprobante> DetalleComprobante { get; set; }
    }
}
