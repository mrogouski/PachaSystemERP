namespace PachaSystem.Data.Migrations
{
    using PachaSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PachaSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PachaSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<TipoConcepto> tipoConcepto = new List<TipoConcepto>
            {
                new TipoConcepto { ID = 1, Descripcion = "PRODUCTOS" },
                new TipoConcepto { ID = 2, Descripcion = "SERVICIOS" },
                new TipoConcepto { ID = 3, Descripcion = "PRODUCTOS Y SERVICIOS" },
                new TipoConcepto { ID = 4, Descripcion = "OTROS" }
            };
            context.TipoConcepto.AddRange(tipoConcepto);

            List<Iva> tipoCondicionIva = new List<Iva>()
            {
                new Iva { ID = 1, Descripcion = "NO GRAVADO", Alicuota = 0M, ControladorFiscal = true, FacturaElectronica = true },
                new Iva { ID = 2, Descripcion = "EXENTO", Alicuota = 0M, ControladorFiscal = true, FacturaElectronica = true },
                new Iva { ID = 3, Descripcion = "0%", Alicuota = 0M, ControladorFiscal = true, FacturaElectronica = true },
                new Iva { ID = 4, Descripcion = "10.5%", Alicuota = 10.5M, ControladorFiscal = true, FacturaElectronica = true },
                new Iva { ID = 5, Descripcion = "21%", Alicuota = 21M, ControladorFiscal = true, FacturaElectronica = true },
                new Iva { ID = 6, Descripcion = "27%", Alicuota = 27M, ControladorFiscal = true, FacturaElectronica = true }
            };
            context.Iva.AddRange(tipoCondicionIva);

            List<CategoriaTributo> categoriaTributo = new List<CategoriaTributo>()
            {
                new CategoriaTributo { ID = 1, Descripcion = "Impuestos Nacionales", ControladorFiscal = false, FacturaElectronica = true },
                new CategoriaTributo { ID = 2, Descripcion = "Impuestos Provinciales", ControladorFiscal = false, FacturaElectronica = true },
                new CategoriaTributo { ID = 3, Descripcion = "Impuestos Municipales", ControladorFiscal = false, FacturaElectronica = true },
                new CategoriaTributo { ID = 4, Descripcion = "Impuestos Internos", ControladorFiscal = false, FacturaElectronica = true },
                new CategoriaTributo { ID = 99, Descripcion = "Otros", ControladorFiscal = false, FacturaElectronica = true }
            };
            context.CategoriaTributo.AddRange(categoriaTributo);

            List<TipoResponsable> tipoResponsable = new List<TipoResponsable>
            {
                new TipoResponsable { ID = 1, Descripcion = "IVA RESPONSABLE INSCRIPTO", ControladorFiscal = true, FacturaElectronica = true },
                new TipoResponsable { ID = 2, Descripcion = "IVA RESPONSABLE NO INSCRIPTO", ControladorFiscal = false, FacturaElectronica = true },
                new TipoResponsable { ID = 3, Descripcion = "IVA NO RESPONSABLE", ControladorFiscal = true, FacturaElectronica = true },
                new TipoResponsable { ID = 4, Descripcion = "IVA SUJETO EXENTO", ControladorFiscal = true, FacturaElectronica = true },
                new TipoResponsable { ID = 5, Descripcion = "CONSUMIDOR FINAL", ControladorFiscal = true, FacturaElectronica = true },
                new TipoResponsable { ID = 6, Descripcion = "RESPONSABLE MONOTRIBUTO", ControladorFiscal = true, FacturaElectronica = true },
                new TipoResponsable { ID = 7, Descripcion = "SUJETO NO CATEGORIZADO", ControladorFiscal = true, FacturaElectronica = true },
                new TipoResponsable { ID = 8, Descripcion = "PROVEEDOR DEL EXTERIOR", ControladorFiscal = false, FacturaElectronica = true },
                new TipoResponsable { ID = 9, Descripcion = "CLIENTE DEL EXTERIOR", ControladorFiscal = false, FacturaElectronica = true },
                new TipoResponsable { ID = 10, Descripcion = "IVA LIBERADO – LEY Nº 19.640", ControladorFiscal = false, FacturaElectronica = true },
                new TipoResponsable { ID = 11, Descripcion = "IVA RESPONSABLE INSCRIPTO – AGENTE DE PERCEPCION", ControladorFiscal = false, FacturaElectronica = true },
                new TipoResponsable { ID = 12, Descripcion = "PEQUEÑO CONTRIBUYENTE EVENTUAL", ControladorFiscal = true, FacturaElectronica = true },
                new TipoResponsable { ID = 13, Descripcion = "MONOTRIBUTISTA SOCIAL", ControladorFiscal = true, FacturaElectronica = true },
                new TipoResponsable { ID = 14, Descripcion = "PEQUEÑO CONTRIBUYENTE EVENTUAL SOCIAL", ControladorFiscal = true, FacturaElectronica = true }
            };
            context.TipoResponsable.AddRange(tipoResponsable);

            List<TipoDocumento> tipoDocumento = new List<TipoDocumento>
            {
                new TipoDocumento { ID = 0, Descripcion = "CI POLICIA FEDERAL", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 1, Descripcion = "CI BUENOS AIRES", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 2, Descripcion = "CI CATAMARCA", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 3, Descripcion = "CI CORDOBA", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 4, Descripcion = "CI CORRIENTES", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 5, Descripcion = "CI ENTRE RIOS", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 6, Descripcion = "CI JUJUY", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 7, Descripcion = "CI MENDOZA", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 8, Descripcion = "CI LA RIOJA", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 9, Descripcion = "CI SALTA", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 10, Descripcion = "CI SAN JUAN", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 11, Descripcion = "CI SAN LUIS", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 12, Descripcion = "CI SANTA FE", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 13, Descripcion = "CI SANTIAGO DEL ESTERO", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 14, Descripcion = "CI TUCUMAN", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 16, Descripcion = "CI CHACO", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 17, Descripcion = "CI CHUBUT", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 18, Descripcion = "CI FORMOSA", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 19, Descripcion = "CI MISIONES", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 20, Descripcion = "CI NEUQUEN", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 21, Descripcion = "CI LA PAMPA", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 22, Descripcion = "CI RIO NEGRO", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 23, Descripcion = "CI SANTA CRUZ", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 24, Descripcion = "CI TIERRA DEL FUEGO", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 80, Descripcion = "CUIT", ControladorFiscal = true, FacturaElectronica = true },
                new TipoDocumento { ID = 86, Descripcion = "CUIL", ControladorFiscal = true, FacturaElectronica = true },
                new TipoDocumento { ID = 87, Descripcion = "CDI", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 89, Descripcion = "LE", ControladorFiscal = true, FacturaElectronica = true },
                new TipoDocumento { ID = 90, Descripcion = "LC", ControladorFiscal = true, FacturaElectronica = true },
                new TipoDocumento { ID = 91, Descripcion = "CI EXTRANJERA", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 92, Descripcion = "EN TRAMITE", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 93, Descripcion = "ACTA DE NACIMIENTO", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 94, Descripcion = "PASAPORTE", ControladorFiscal = true, FacturaElectronica = true },
                new TipoDocumento { ID = 95, Descripcion = "CI BUENOS AIRES RNP", ControladorFiscal = false, FacturaElectronica = true },
                new TipoDocumento { ID = 96, Descripcion = "DNI", ControladorFiscal = true, FacturaElectronica = true },
                new TipoDocumento { ID = 99, Descripcion = "SIN IDENTIFICAR", ControladorFiscal = true, FacturaElectronica = true }
            };
            context.TipoDocumento.AddRange(tipoDocumento);

            List<TipoMoneda> tipoMoneda = new List<TipoMoneda>
            {
                new TipoMoneda { ID = 1, Codigo = "000", Descripcion = "OTRAS MONEDAS" },
                new TipoMoneda { ID = 2, Codigo = "PES", Descripcion = "PESOS" },
                new TipoMoneda { ID = 3, Codigo = "DOL", Descripcion = "DOLAR ESTADOUNIDENSE" },
                new TipoMoneda { ID = 4, Codigo = "002", Descripcion = "DOLAR EEUU LIBRE" },
                new TipoMoneda { ID = 5, Codigo = "003", Descripcion = "FRANCOS FRANCESES" },
                new TipoMoneda { ID = 6, Codigo = "004", Descripcion = "LIRAS ITALIANAS" },
                new TipoMoneda { ID = 7, Codigo = "005", Descripcion = "PESETAS" },
                new TipoMoneda { ID = 8, Codigo = "006", Descripcion = "MARCOS ALEMANES" },
                new TipoMoneda { ID = 9, Codigo = "007", Descripcion = "FLORINES HOLANDESES" },
                new TipoMoneda { ID = 10, Codigo = "008", Descripcion = "FRANCOS BELGAS" },
                new TipoMoneda { ID = 11, Codigo = "009", Descripcion = "FRANCOS SUIZOS" },
                new TipoMoneda { ID = 12, Codigo = "010", Descripcion = "PESOS MEJICANOS" },
                new TipoMoneda { ID = 13, Codigo = "011", Descripcion = "PESOS URUGUAYOS" },
                new TipoMoneda { ID = 14, Codigo = "012", Descripcion = "REAL" },
                new TipoMoneda { ID = 15, Codigo = "013", Descripcion = "ESCUDOS PORTUGUESES" },
                new TipoMoneda { ID = 16, Codigo = "014", Descripcion = "CORONAS DANESAS" },
                new TipoMoneda { ID = 17, Codigo = "015", Descripcion = "CORONAS NORUEGAS" },
                new TipoMoneda { ID = 18, Codigo = "016", Descripcion = "CORONAS SUECAS" },
                new TipoMoneda { ID = 19, Codigo = "017", Descripcion = "CHELINES AUTRIACOS" },
                new TipoMoneda { ID = 20, Codigo = "018", Descripcion = "DOLAR CANADIENSE" },
                new TipoMoneda { ID = 21, Codigo = "019", Descripcion = "YENES" },
                new TipoMoneda { ID = 22, Codigo = "021", Descripcion = "LIBRA ESTERLINA" },
                new TipoMoneda { ID = 23, Codigo = "022", Descripcion = "MARCOS FINLANDESES" },
                new TipoMoneda { ID = 24, Codigo = "023", Descripcion = "BOLIVAR (VENEZOLANO)" },
                new TipoMoneda { ID = 25, Codigo = "024", Descripcion = "CORONA CHECA" },
                new TipoMoneda { ID = 26, Codigo = "025", Descripcion = "DINAR (YUGOSLAVO)" },
                new TipoMoneda { ID = 27, Codigo = "026", Descripcion = "DOLAR AUSTRALIANO" },
                new TipoMoneda { ID = 28, Codigo = "027", Descripcion = "DRACMA (GRIEGO)" },
                new TipoMoneda { ID = 29, Codigo = "028", Descripcion = "FLORIN (ANTILLAS HOLA)" },
                new TipoMoneda { ID = 30, Codigo = "029", Descripcion = "GUARANI" },
                new TipoMoneda { ID = 31, Codigo = "030", Descripcion = "SHEKEL (ISRAEL)" },
                new TipoMoneda { ID = 32, Codigo = "031", Descripcion = "PESO BOLIVIANO" },
                new TipoMoneda { ID = 33, Codigo = "032", Descripcion = "PESO COLOMBIANO" },
                new TipoMoneda { ID = 34, Codigo = "033", Descripcion = "PESO CHILENO" },
                new TipoMoneda { ID = 35, Codigo = "034", Descripcion = "RAND (SUDAFRICANO)" },
                new TipoMoneda { ID = 36, Codigo = "035", Descripcion = "NUEVO SOL PERUANO" },
                new TipoMoneda { ID = 37, Codigo = "036", Descripcion = "SUCRE (ECUATORIANO)" },
                new TipoMoneda { ID = 38, Codigo = "040", Descripcion = "LEI RUMANOS" },
                new TipoMoneda { ID = 39, Codigo = "041", Descripcion = "DERECHOS ESPECIALES DE GIRO" },
                new TipoMoneda { ID = 40, Codigo = "042", Descripcion = "PESOS DOMINICANOS" },
                new TipoMoneda { ID = 41, Codigo = "043", Descripcion = "BALBOAS PANAMEÑAS" },
                new TipoMoneda { ID = 42, Codigo = "044", Descripcion = "CORDOBAS NICARAGÛENSES" },
                new TipoMoneda { ID = 43, Codigo = "045", Descripcion = "DIRHAM MARROQUÍES" },
                new TipoMoneda { ID = 44, Codigo = "046", Descripcion = "LIBRAS EGIPCIAS" },
                new TipoMoneda { ID = 45, Codigo = "047", Descripcion = "RIYALS SAUDITAS" },
                new TipoMoneda { ID = 46, Codigo = "048", Descripcion = "BRANCOS BELGAS FINANCIERAS" },
                new TipoMoneda { ID = 47, Codigo = "049", Descripcion = "GRAMOS DE ORO FINO" },
                new TipoMoneda { ID = 48, Codigo = "050", Descripcion = "LIBRAS IRLANDESAS" },
                new TipoMoneda { ID = 49, Codigo = "051", Descripcion = "DOLAR DE HONG KONG" },
                new TipoMoneda { ID = 50, Codigo = "052", Descripcion = "DOLAR DE SINGAPUR" },
                new TipoMoneda { ID = 51, Codigo = "053", Descripcion = "DOLAR DE JAMAICA" },
                new TipoMoneda { ID = 52, Codigo = "054", Descripcion = "DOLAR DE TAIWAN" },
                new TipoMoneda { ID = 53, Codigo = "055", Descripcion = "QUETZAL (GUATEMALTECOS)" },
                new TipoMoneda { ID = 54, Codigo = "056", Descripcion = "FORINT (HUNGRIA)" },
                new TipoMoneda { ID = 55, Codigo = "057", Descripcion = "BAHT (TAILANDIA)" },
                new TipoMoneda { ID = 56, Codigo = "058", Descripcion = "ECU" },
                new TipoMoneda { ID = 57, Codigo = "059", Descripcion = "DINAR KUWAITI" },
                new TipoMoneda { ID = 58, Codigo = "060", Descripcion = "EURO" },
                new TipoMoneda { ID = 59, Codigo = "061", Descripcion = "ZLTYS POLACOS" },
                new TipoMoneda { ID = 60, Codigo = "062", Descripcion = "RUPIAS HINDÚES" },
                new TipoMoneda { ID = 61, Codigo = "063", Descripcion = "LEMPIRAS HONDUREÑAS" },
                new TipoMoneda { ID = 62, Codigo = "064", Descripcion = "YUAN (REPUBLICA POPULAR CHINA)" }
            };
            context.TipoMoneda.AddRange(tipoMoneda);

            List<TipoComprobante> tipoComprobante = new List<TipoComprobante>
            {
                new TipoComprobante { ID = 1, Descripcion = "FACTURA A", Clase = "A", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 2, Descripcion = "NOTA DE DEBITO A", Clase = "A", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 3, Descripcion = "NOTA DE CREDITO A", Clase = "A", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 4, Descripcion = "RECIBO A", Clase = "A", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 5, Descripcion = "NOTA DE VENTA AL CONTADO A", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 6, Descripcion = "FACTURA B", Clase = "B", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 7, Descripcion = "NOTA DE DEBITO B", Clase = "B", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 8, Descripcion = "NOTA DE CREDITO B", Clase = "B", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 9, Descripcion = "RECIBO B", Clase = "B", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 10, Descripcion = "NOTA DE VENTA AL CONTADO B", Clase = "B", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 11, Descripcion = "FACTURA C", Clase = "C", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 12, Descripcion = "NOTA DE DEBITO C", Clase = "C", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 13, Descripcion = "NOTA DE CREDITO C", Clase = "C", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 15, Descripcion = "RECIBO C", Clase = "C", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 34, Descripcion = "COMPROBANTES A DEL ANEXO I, APARTADO A  INCISO F)  R.G. N° 1415", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 35, Descripcion = "COMPROBANTES B DEL ANEXO I, APARTADO A, INCISO F), R.G. N° 1415", Clase = "B", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 39, Descripcion = "OTROS COMPROBANTES A QUE CUMPLEN CON LA R G  N° 1415", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 40, Descripcion = "OTROS COMPROBANTES B QUE CUMPLAN CON LA R.G. N° 1415", Clase = "B", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 49, Descripcion = "COMPROBANTE DE COMPRA DE BIENES NO REGISTRABLES A CONSUMIDORES FINALES", Clase = "Bienes Usados", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 51, Descripcion = "FACTURA M", Clase = "M", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 52, Descripcion = "NOTA DE DEBITO M", Clase = "M", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 53, Descripcion = "NOTA DE CREDITO M", Clase = "M", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 54, Descripcion = "RECIBO M", Clase = "M", ControladorFiscal = true, FacturaElectronica = true },
                new TipoComprobante { ID = 60, Descripcion = "CUENTA DE VENTA Y LIQUIDO PRODUCTO A", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 61, Descripcion = "CUENTA DE VENTA Y LIQUIDO PRODUCTO B", Clase = "B", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 63, Descripcion = "LIQUIDACIONES A", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 64, Descripcion = "LIQUIDACIONES B", Clase = "B", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 81, Descripcion = "TIQUE FACTURA A", Clase = "A", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 82, Descripcion = "TIQUE FACTURA B", Clase = "B", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 83, Descripcion = "TIQUE", Clase = "Otros", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 91, Descripcion = "REMITO R", Clase = "R", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 110, Descripcion = "TIQUE NOTA DE CREDITO", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 111, Descripcion = "TIQUE FACTURA C", Clase = "C", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 112, Descripcion = "TIQUE NOTA DE CREDITO A", Clase = "A", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 113, Descripcion = "TIQUE NOTA DE CREDITO B", Clase = "B", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 114, Descripcion = "TIQUE NOTA DE CREDITO C", Clase = "C", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 115, Descripcion = "TIQUE NOTA DE DEBITO A", Clase = "A", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 116, Descripcion = "TIQUE NOTA DE DEBITO B", Clase = "B", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 117, Descripcion = "TIQUE NOTA DE DEBITO C", Clase = "C", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 118, Descripcion = "TIQUE FACTURA M", Clase = "M", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 119, Descripcion = "TIQUE NOTA DE CREDITO M", Clase = "M", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 120, Descripcion = "TIQUE NOTA DE DEBITO M", Clase = "M", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 201, Descripcion = "FACTURA DE CREDITO ELECTRONICA MIPYMES (FCE) A", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 202, Descripcion = "NOTA DE DEBITO ELECTRONICA MIPYMES (FCE) A", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 203, Descripcion = "NOTA DE CREDITO ELECTRONICA MIPYMES (FCE) A", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 206, Descripcion = "FACTURA DE CREDITO ELECTRONICA MIPYMES (FCE) B", Clase = "A", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 207, Descripcion = "NOTA DE DEBITO ELECTRONICA MIPYMES (FCE) B", Clase = "B", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 208, Descripcion = "NOTA DE CREDITO ELECTRONICA MIPYMES (FCE) B", Clase = "B", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 211, Descripcion = "FACTURA DE CREDITO ELECTRONICA MIPYMES (FCE) C", Clase = "C", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 212, Descripcion = "NOTA DE DEBITO ELECTRONICA MIPYMES (FCE) C", Clase = "C", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 213, Descripcion = "NOTA DE CREDITO ELECTRONICA MIPYMES (FCE) C", Clase = "C", ControladorFiscal = false, FacturaElectronica = true },
                new TipoComprobante { ID = 901, Descripcion = "REMITO X", Clase = "X", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 902, Descripcion = "RECIBO X", Clase = "X", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 903, Descripcion = "PRESUPUESTO X", Clase = "X", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 907, Descripcion = "COMPROBANTE DONACION", Clase = "Otros", ControladorFiscal = true, FacturaElectronica = false },
                new TipoComprobante { ID = 910, Descripcion = "GENERICO", Clase = "Otros", ControladorFiscal = true, FacturaElectronica = false }
            };
            context.TipoComprobante.AddRange(tipoComprobante);

            List<UnidadMedida> unidadMedida = new List<UnidadMedida>
            {
            new UnidadMedida { ID = 00, Descripcion = "SIN DESCRIPCION" },
            new UnidadMedida { ID = 01, Descripcion = "KILOGRAMO" },
            new UnidadMedida { ID = 02, Descripcion = "Metros" },
            new UnidadMedida { ID = 03, Descripcion = "Metro Cuadrado" },
            new UnidadMedida { ID = 04, Descripcion = "Metro Cúbico" },
            new UnidadMedida { ID = 05, Descripcion = "Litros" },
            new UnidadMedida { ID = 06, Descripcion = "1000 Kilowatt Hora" },
            new UnidadMedida { ID = 07, Descripcion = "Unidad" },
            new UnidadMedida { ID = 08, Descripcion = "Par" },
            new UnidadMedida { ID = 09, Descripcion = "Docena" },
            new UnidadMedida { ID = 10, Descripcion = "Quilate" },
            new UnidadMedida { ID = 11, Descripcion = "Millar" },
            new UnidadMedida { ID = 12, Descripcion = "MEGA U. INTER.ACT.ANTIB" },
            new UnidadMedida { ID = 13, Descripcion = "UNIDAD INT. ACT.INMUNG" },
            new UnidadMedida { ID = 14, Descripcion = "GRAMO" },
            new UnidadMedida { ID = 15, Descripcion = "MILIMETRO" },
            new UnidadMedida { ID = 16, Descripcion = "MILIMETRO CUBICO" },
            new UnidadMedida { ID = 17, Descripcion = "KILOMETRO" },
            new UnidadMedida { ID = 18, Descripcion = "HECTOLITRO" },
            new UnidadMedida { ID = 19, Descripcion = "MEGA UNIDAD INT.ACT.INMUNG" },
            new UnidadMedida { ID = 20, Descripcion = "CENTIMETRO" },
            new UnidadMedida { ID = 21, Descripcion = "KILOGRAMO ACTIVO" },
            new UnidadMedida { ID = 22, Descripcion = "GRAMO ACTIVO" },
            new UnidadMedida { ID = 23, Descripcion = "GRAMO BASE" },
            new UnidadMedida { ID = 24, Descripcion = "UIACTHOR" },
            new UnidadMedida { ID = 25, Descripcion = "JGO.PQT.MAZO NAIPES" },
            new UnidadMedida { ID = 26, Descripcion = "MUIACTHOR" },
            new UnidadMedida { ID = 27, Descripcion = "CENTIMETRO CUBICO" },
            new UnidadMedida { ID = 28, Descripcion = "UIACTANT" },
            new UnidadMedida { ID = 29, Descripcion = "TONELADA" },
            new UnidadMedida { ID = 30, Descripcion = "DECAMETRO CUBICO" },
            new UnidadMedida { ID = 31, Descripcion = "HECTOMETRO CUBICO" },
            new UnidadMedida { ID = 32, Descripcion = "KILOMETRO CUBICO" },
            new UnidadMedida { ID = 33, Descripcion = "MICROGRAMO" },
            new UnidadMedida { ID = 34, Descripcion = "NANOGRAMO" },
            new UnidadMedida { ID = 35, Descripcion = "PICOGRAMO" },
            new UnidadMedida { ID = 36, Descripcion = "MUIACTANT" },
            new UnidadMedida { ID = 37, Descripcion = "UIACTIG" },
            new UnidadMedida { ID = 41, Descripcion = "MILIGRAMO" },
            new UnidadMedida { ID = 47, Descripcion = "MILILITRO" },
            new UnidadMedida { ID = 48, Descripcion = "CURIE" },
            new UnidadMedida { ID = 49, Descripcion = "MILICURIE" },
            new UnidadMedida { ID = 50, Descripcion = "MICROCURIE" },
            new UnidadMedida { ID = 51, Descripcion = "U.INTER.ACT.HORMONAL" },
            new UnidadMedida { ID = 52, Descripcion = "MEGA U. INTER.ACT.HOR." },
            new UnidadMedida { ID = 53, Descripcion = "KILOGRAMO BASE" },
            new UnidadMedida { ID = 54, Descripcion = "GRUESA" },
            new UnidadMedida { ID = 55, Descripcion = "MUIACTIG" },
            new UnidadMedida { ID = 61, Descripcion = "KILOGRAMO BRUTO" },
            new UnidadMedida { ID = 62, Descripcion = "PACK" },
            new UnidadMedida { ID = 63, Descripcion = "HORMA" },
            new UnidadMedida { ID = 97, Descripcion = "SEÑAS / ANTICIPOS" },
            new UnidadMedida { ID = 98, Descripcion = "OTRAS UNIDADES" },
            new UnidadMedida { ID = 99, Descripcion = "BONIFICACION" },
            };
            context.UnidadMedida.AddRange(unidadMedida);

            context.Cliente.Add(
                new Cliente { ID = 1, RazonSocial = "CONSUMIDOR FINAL", TipoDocumentoID = 99, NumeroDocumento = string.Empty, TipoResponsableID = 5, Domicilio = string.Empty });

            base.Seed(context);
        }
    }
}
