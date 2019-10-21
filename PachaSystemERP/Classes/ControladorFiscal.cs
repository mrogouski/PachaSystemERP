// <copyright file="ControladorFiscal.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using hfl.argentina;

    public class ControladorFiscal
    {
        private void Example()
        {
            bool z = false;
            bool factura = false;
            bool cancelar = false;
            bool dnf = false;
            bool estado = true;
            Console.Out.WriteLine("Hasar SAIC");
            Console.Out.WriteLine("Version del protocolo fiscal: " + 0);
            HasarImpresoraFiscalRG3561 p = new HasarImpresoraFiscalRG3561();
            p.conectar("10.0.7.56");
            p.establecerTiempoDeEspera(10000);
            p.establecerTiempoDeEsperaLecturaEscritura(25000);
            p.archivoRegistro("C:\\Temp\\VCSharp\\ConsoleApplication1.log");
            p.eventoImpresora += new hfl.argentina.HasarImpresoraFiscalRG3561.setStatusPinter(p_eventoImpresora); // getstatus
            p.eventoComandoEnProceso += new hfl.argentina.HasarImpresoraFiscalRG3561.setComandoEnProceso(p_eventoComandoEnProceso);
            p.eventoComandoProcesado += new hfl.argentina.HasarImpresoraFiscalRG3561.setComandoProcesado(p_eventoComandoProcesado);

            if (estado)
            {
                try
                {
                    HasarImpresoraFiscalRG3561.RespuestaConsultarEstado r = p.ConsultarEstado();
                    Console.Out.WriteLine("Modo Entrenamiento:        " + r.EstadoAuxiliar.getModoEntrenamiento());
                    Console.Out.WriteLine("Estado Interno:            " + r.getEstadoInterno());
                    Console.Out.WriteLine("Cantidad Cancelados:       " + r.getCantidadCancelados());
                    Console.Out.WriteLine("Cantidad Emitidos:         " + r.getCantidadEmitidos());
                    Console.Out.WriteLine("Codigo Comprobante:        " + r.getCodigoComprobante());
                    Console.Out.WriteLine("Comprobante en Curso:      " + r.getComprobanteEnCurso());
                    Console.Out.WriteLine("Numero Ultimo Comprobante: " + r.getNumeroUltimoComprobante());
                }
                catch (HasarException e)
                {
                    Console.Out.WriteLine(e.getMessage());
                }
            }

            if (cancelar)
            {
                try
                {
                    p.Cancelar();
                }
                catch (HasarException e)
                {
                    Console.Out.WriteLine(e.getMessage());
                }
            }

            if (dnf)
            {
                try
                {
                    hfl.argentina.Hasar_Funcs.AtributosDeTexto atrr = new hfl.argentina.Hasar_Funcs.AtributosDeTexto();
                    atrr.setCentrado(true);

                    hfl.argentina.HasarImpresoraFiscalRG3561.RespuestaAbrirDocumento r = p.AbrirDocumento(hfl.argentina.HasarImpresoraFiscalRG3561.TiposComprobante.GENERICO);
                    Console.Out.WriteLine("Numero de comprobante: " + r.getNumeroComprobante());
                    p.ImprimirTextoGenerico(atrr, "Prueba 3");
                    hfl.argentina.HasarImpresoraFiscalRG3561.RespuestaCerrarDocumento rcd = p.CerrarDocumento();
                    Console.Out.WriteLine("Numero de comprobante: " + rcd.getNumeroComprobante());
                    Console.Out.WriteLine("Cantidad de paginas:   " + rcd.getCantidadDePaginas());
                }
                catch (HasarException e)
                {
                    Console.Out.WriteLine(e.getMessage());
                }
            }

            if (factura)
            {
                try
                {
                    p.AbrirDocumento(hfl.argentina.HasarImpresoraFiscalRG3561.TiposComprobante.FACTURA_B);
                    hfl.argentina.Hasar_Funcs.AtributosDeTexto atrr = new hfl.argentina.Hasar_Funcs.AtributosDeTexto();
                    atrr.setNegrita(true);
                    atrr.setDobleAncho(true);
                    atrr.setCentrado(true);
                    p.ImprimirTextoFiscal(atrr, "Texto Fiscal 1");
                    p.ImprimirItem("PLU 2015", 1.0, 5.40, hfl.argentina.HasarImpresoraFiscalRG3561.CondicionesIVA.GRAVADO, 21.0, hfl.argentina.HasarImpresoraFiscalRG3561.ModosDeMonto.MODO_SUMA_MONTO, hfl.argentina.HasarImpresoraFiscalRG3561.ModosDeImpuestosInternos.II_FIJO_KIVA, 0.0, hfl.argentina.HasarImpresoraFiscalRG3561.ModosDeDisplay.DISPLAY_NO, hfl.argentina.HasarImpresoraFiscalRG3561.ModosDePrecio.MODO_PRECIO_TOTAL, "123");
                    p.ImprimirPago("Efectivo ya", 20.50, hfl.argentina.HasarImpresoraFiscalRG3561.ModosDePago.PAGAR);
                    p.CerrarDocumento();
                }
                catch (HasarException e)
                {
                    Console.Out.WriteLine(e.getMessage());
                }

            }

            if (z)
            {
                try
                {
                    hfl.argentina.HasarImpresoraFiscalRG3561.RespuestaCerrarJornadaFiscal r = p.CerrarJornadaFiscal(hfl.argentina.HasarImpresoraFiscalRG3561.TipoReporte.REPORTE_Z);// .ConsultarEstado();
                    Console.Out.WriteLine("Fecha:                     " + r.Z.getFecha());
                    Console.Out.WriteLine("Informe nro.:              " + r.Z.getNumero());
                    Console.Out.WriteLine("DF Cantidad de cancelados: " + r.Z.getDF_CantidadCancelados());
                    Console.Out.WriteLine("DF Cantidad de emitidos:   " + r.Z.getDF_CantidadEmitidos());
                    Console.Out.WriteLine("DF Total:                  " + r.Z.getDF_Total());
                    Console.Out.WriteLine("DF Total Exento:           " + r.Z.getDF_TotalExento());
                    Console.Out.WriteLine("DF Total Gravado:          " + r.Z.getDF_TotalGravado());
                    Console.Out.WriteLine("DF Total IVA:              " + r.Z.getDF_TotalIVA());
                    Console.Out.WriteLine("DF Total No Gravado:       " + r.Z.getDF_TotalNoGravado());
                    Console.Out.WriteLine("DF Total Tributo:          " + r.Z.getDF_TotalTributos());
                    Console.Out.WriteLine("DNFH Cantidad de emitidos: " + r.Z.getDNFH_CantidadEmitidos());
                    Console.Out.WriteLine("DNFH Total:                " + r.Z.getDNFH_Total());
                    Console.Out.WriteLine("NC Cantidad de cancelados: " + r.Z.getNC_CantidadCancelados());
                    Console.Out.WriteLine("NC Cantidad de emitidos:   " + r.Z.getNC_CantidadEmitidos());
                    Console.Out.WriteLine("NC Total:                  " + r.Z.getNC_Total());
                    Console.Out.WriteLine("NC Total Exento:           " + r.Z.getNC_TotalExento());
                    Console.Out.WriteLine("NC Total Gravado:          " + r.Z.getNC_TotalGravado());
                    Console.Out.WriteLine("NC Total IVA:              " + r.Z.getNC_TotalIVA());
                    Console.Out.WriteLine("NC Total No Gravado:       " + r.Z.getNC_TotalNoGravado());
                    Console.Out.WriteLine("NC Total Tributo:          " + r.Z.getNC_TotalTributos());
                }
                catch (HasarException e)
                {
                    Console.Out.WriteLine(e.getMessage());
                }
            }

            Console.ReadKey();
        }

        static void p_eventoComandoProcesado()
        {
            Console.Out.WriteLine("Comando procesado");
        }

        static void p_eventoComandoEnProceso()
        {
            Console.Out.WriteLine("Comando en proceso");
        }

        static void p_eventoImpresora(hfl.argentina.Estados_Fiscales_RG3561.EstadoImpresora printer)
        {
            Console.Out.WriteLine("Cajon abierto:      " + printer.getCajonAbierto());
            Console.Out.WriteLine("Error impresora:    " + printer.getErrorImpresora());
            Console.Out.WriteLine("Papel Journal:      " + printer.getFaltaPapelJournal());
            Console.Out.WriteLine("Papel Receipt:      " + printer.getFaltaPapelReceipt());
            Console.Out.WriteLine("Impresora ocupada:  " + printer.getImpresoraOcupada());
            Console.Out.WriteLine("Impresora off line: " + printer.getImpresoraOffLine());
            Console.Out.WriteLine("Tapa abierta:       " + printer.getTapaAbierta());
            Console.Out.WriteLine("Or logico:          " + printer.getOrLogico());
        }

        //hfl.argentina.HasarImpresoraFiscalRG3561 p = new hfl.argentina.HasarImpresoraFiscalRG3561();
        //p.conectar("10.0.7.26");
        //try
        //{
        //    p.Cancelar();
        //    p.CerrarJornadaFiscal(hfl.argentina.HasarImpresoraFiscalRG3561.TipoReporte.REPORTE_X);
        //}
        //catch (HasarException e)
        //{
        //    Console.Out.WriteLine(e.getMessage());
        //}

        //Console.ReadKey();
        //}
    }
}
