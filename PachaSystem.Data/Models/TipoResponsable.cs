﻿namespace PachaSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TipoResponsable
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public bool ControladorFiscal { get; set; }

        public bool FacturaElectronica { get; set; }
    }
}