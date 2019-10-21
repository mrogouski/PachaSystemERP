// <copyright file="TipoDeComprobante.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Representa un listado de tipos de comprobantas.
    /// </summary>
    public enum TipoDeComprobante
    {
        Factura_A = 1,

        Nota_De_Debito_A = 2,

        Nota_De_Credito_A = 3,

        Recibo_A = 4,

        /// <summary>
        /// Solo disponible en Facturacion Electronica.
        /// </summary>
        Nota_De_Venta_Al_Contado_A = 5,

        Factura_B = 6,

        Nota_De_Debito_B = 7,

        Nota_De_Credito_B = 8,

        Recibo_B = 9,

        /// <summary>
        /// Solo disponible en Facturacion Electronica.
        /// </summary>
        Nota_De_Venta_Al_Contado_B = 10,

        Factura_C = 11,

        Nota_De_Debito_C = 12,

        Nota_De_Credito_C = 13,

        Recibo_C = 15,

        /// <summary>
        /// Comprobante A del Anexo I, Apartado A, Inciso f) R.G. N° 1415, solo disponible en Facturacion Electronica.
        /// </summary>
        Comprobante_A_Del_Apartado_A_Inciso_F_RG_Nro_1415 = 34,

        /// <summary>
        /// Comprobante B del Anexo I, Apartado A, Inciso f) R.G. N° 1415, solo disponible en Facturacion Electronica.
        /// </summary>
        Comprobante_B_Del_Anexo_I_Apartado_A_Inciso_F_RG_Nro_1415 = 35,

        /// <summary>
        /// Otros Comprobantes A que cumplan con la R.G. N° 1415, solo disponible en Facturacion Electronica.
        /// </summary>
        Otros_Comprobantes_A_Que_Cumplen_Con_La_RG_Nro_1415 = 39,

        /// <summary>
        /// Otros Comprobantes B que cumplan con la R.G. N° 1415, solo disponible en Facturacion Electronica.
        /// </summary>
        Otros_Comprobantes_B_Que_Cumplan_Con_La_RG_Nro_1415 = 40,

        /// <summary>
        /// Solo disponible en Facturacion Electronica.
        /// </summary>
        Comprobante_De_Compra_De_Bienes_No_Registrables_A_Consumidores_Finales = 49,

        Factura_M = 51,

        Nota_De_Debito_M = 52,

        Nota_De_Credito_M = 53,

        Recibo_M = 54,

        /// <summary>
        /// Solo disponible en Facturacion Electronica.
        /// </summary>
        Cuenta_De_Venta_Y_Liquido_Producto_A = 60,

        /// <summary>
        /// Solo disponible en Facturacion Electronica.
        /// </summary>
        Cuenta_De_Venta_Y_Liquido_Producto_B = 61,

        Liquidaciones_A = 63,

        Liquidaciones_B = 64,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Factura_A = 81,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Factura_B = 82,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique = 83,

        Remito_R = 91,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Credito = 110,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Factura_C = 111,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Credito_A = 112,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Credito_B = 113,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Credito_C = 114,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Debito_A = 115,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Debito_B = 116,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Debito_C = 117,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Factura_M = 118,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Credito_M = 119,

        /// <summary>
        /// Solo disponible en Impresora Fiscal (rollo).
        /// </summary>
        Tique_Nota_De_Debito_M = 120,

        Factura_De_Credito_Electronica_MiPyMES_FCE_A = 201,

        Nota_De_Debito_Electronica_MiPyMES_FCE_A = 202,

        Nota_De_Credito_Electronica_MiPyMES_FCE_A = 203,

        Factura_De_Credito_Electronica_MiPyMES_FCE_B = 206,

        Nota_De_Debito_Electronica_MiPyMES_FCE_B = 207,

        Nota_De_Credito_Electronica_MiPyMES_FCE_B = 208,

        Factura_De_Credito_Electronica_MiPyMES_FCE_C = 211,

        Nota_De_Debito_Electronica_MiPyMES_FCE_C = 212,

        Nota_De_Credito_Electronica_MiPyMES_FCE_C = 213,

        Remito_X = 901,

        Recibo_X = 902,

        Presupuesto_X = 903,

        Comprobante_Donacion = 907,

        Generico = 910,
    }
}
