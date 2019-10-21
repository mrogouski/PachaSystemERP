namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TipoTributo
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public decimal Alicuota { get; set; }

        public short CategoriaTributoID { get; set; }

        public virtual CategoriaTributo CategoriaTributo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
