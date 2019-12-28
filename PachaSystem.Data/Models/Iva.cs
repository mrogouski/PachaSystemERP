namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Iva
    {
        public short ID { get; set; }

        public string Name { get; set; }

        public decimal Alicuota { get; set; }

        public bool ControladorFiscal { get; set; }

        public bool FacturaElectronica { get; set; }

        public virtual ICollection<Item> Productos { get; set; }
    }
}
