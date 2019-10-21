// <copyright file="Facturacion.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using PachaSystemERP.Enums;

    public static class Facturacion
    {
        private static readonly List<TipoDeComprobante> _comprobantesA = new List<TipoDeComprobante>
        {
            TipoDeComprobante.Factura_A,
            TipoDeComprobante.Nota_De_Debito_A,
            TipoDeComprobante.Nota_De_Credito_A,
            TipoDeComprobante.Recibo_A,
            TipoDeComprobante.Nota_De_Venta_Al_Contado_A,
            TipoDeComprobante.Comprobante_A_Del_Apartado_A_Inciso_F_RG_Nro_1415,
            TipoDeComprobante.Otros_Comprobantes_A_Que_Cumplen_Con_La_RG_Nro_1415,
            TipoDeComprobante.Cuenta_De_Venta_Y_Liquido_Producto_A,
            TipoDeComprobante.Liquidaciones_A,
            TipoDeComprobante.Factura_De_Credito_Electronica_MiPyMES_FCE_A,
            TipoDeComprobante.Nota_De_Debito_Electronica_MiPyMES_FCE_A,
            TipoDeComprobante.Nota_De_Credito_Electronica_MiPyMES_FCE_A,
        };

        private static readonly List<TipoDeComprobante> _comprobantesB = new List<TipoDeComprobante>
        {
            TipoDeComprobante.Factura_B,
            TipoDeComprobante.Nota_De_Debito_B,
            TipoDeComprobante.Nota_De_Credito_B,
            TipoDeComprobante.Recibo_B,
            TipoDeComprobante.Nota_De_Venta_Al_Contado_B,
            TipoDeComprobante.Comprobante_B_Del_Anexo_I_Apartado_A_Inciso_F_RG_Nro_1415,
            TipoDeComprobante.Otros_Comprobantes_B_Que_Cumplan_Con_La_RG_Nro_1415,
            TipoDeComprobante.Cuenta_De_Venta_Y_Liquido_Producto_B,
            TipoDeComprobante.Cuenta_De_Venta_Y_Liquido_Producto_B,
            TipoDeComprobante.Factura_De_Credito_Electronica_MiPyMES_FCE_B,
            TipoDeComprobante.Nota_De_Debito_Electronica_MiPyMES_FCE_B,
            TipoDeComprobante.Nota_De_Credito_Electronica_MiPyMES_FCE_B,
        };

        private static readonly List<TipoDeComprobante> _comprobantesC = new List<TipoDeComprobante>
        {
            TipoDeComprobante.Factura_C,
            TipoDeComprobante.Nota_De_Debito_C,
            TipoDeComprobante.Nota_De_Credito_C,
            TipoDeComprobante.Recibo_C,
            TipoDeComprobante.Factura_De_Credito_Electronica_MiPyMES_FCE_C,
            TipoDeComprobante.Nota_De_Debito_Electronica_MiPyMES_FCE_C,
            TipoDeComprobante.Nota_De_Credito_Electronica_MiPyMES_FCE_C,
        };

        private static readonly List<TipoDeComprobante> _comprobantesM = new List<TipoDeComprobante>
        {
            TipoDeComprobante.Factura_M,
            TipoDeComprobante.Nota_De_Debito_M,
            TipoDeComprobante.Nota_De_Credito_M,
            TipoDeComprobante.Recibo_M,
        };

        private static readonly TipoDeComprobante _bienesUsados = TipoDeComprobante.Comprobante_De_Compra_De_Bienes_No_Registrables_A_Consumidores_Finales;

        /// <summary>
        /// Obtiene el listado de comprobantes que se pueden emitir.
        /// </summary>
        /// <param name="responsabilidadCliente"></param>
        /// <returns></returns>
        public static List<TipoDeComprobante> ObtenerListadoDeComprobantesDisponibles(TipoDeResponsabilidadIva responsabilidadCliente)
        {
            var emisor = (TipoDeResponsabilidadIva)Configuracion.Responsabilidad;

            if (emisor == TipoDeResponsabilidadIva.IVA_RESPONSABLE_INSCRIPTO)
            {
                if (emisor == responsabilidadCliente)
                {
                    return _comprobantesA;
                }
                else
                {
                    return _comprobantesB;
                }
            }
            else
            {
                return _comprobantesC;
            }
        }

        /// <summary>
        /// Obtiene el tipo de comprobantes que se pueden emitir.
        /// </summary>
        /// <param name="responsabilidadCliente"></param>
        /// <returns></returns>
        public static int ObtenerTipoDeFactura(int tipoDeResponsabilidadCliente)
        {
            var cliente = (TipoDeResponsabilidadIva)tipoDeResponsabilidadCliente;
            var emisor = (TipoDeResponsabilidadIva)Configuracion.Responsabilidad;
            if (emisor == TipoDeResponsabilidadIva.IVA_RESPONSABLE_INSCRIPTO)
            {
                if (emisor == cliente)
                {
                    return 1;
                }
                else /*if (cliente == TipoDeResponsabilidadIva.IVA_SUJETO_EXENTO || cliente == TipoDeResponsabilidadIva.CONSUMIDOR_FINAL || cliente == TipoDeResponsabilidadIva.RESPONSABLE_MONOTRIBUTO)*/
                {
                    return 6;
                }
            }
            else
            {
                return 11;
            }
        }
    }
}