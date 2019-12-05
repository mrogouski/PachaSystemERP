namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CategoriaProducto
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
