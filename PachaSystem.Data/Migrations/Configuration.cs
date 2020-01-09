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
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(PachaSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.ConceptTypes.Count() != 4)
            {
                context.ConceptTypes.AddOrUpdate(x => x.ID,
                    new ConceptType { ID = 1, Name = "Productos" },
                    new ConceptType { ID = 2, Name = "Servicios" },
                    new ConceptType { ID = 3, Name = "Productos y Servicios" },
                    new ConceptType { ID = 4, Name = "Otros" });
            }

            if (context.Vat.Count() != 6)
            {
                context.Vat.AddOrUpdate(x => x.ID,
                    new Vat { ID = 1, Description = "No Gravado", Aliquot = 0M },
                    new Vat { ID = 2, Description = "Exento", Aliquot = 0M },
                    new Vat { ID = 3, Description = "0%", Aliquot = 0M },
                    new Vat { ID = 4, Description = "10,5%", Aliquot = 10.5M },
                    new Vat { ID = 5, Description = "21%", Aliquot = 21M },
                    new Vat { ID = 6, Description = "27%", Aliquot = 27M });
            }

            if (context.TributeCategories.Count() != 5)
            {
                context.TributeCategories.AddOrUpdate(x => x.ID,
                    new TributeCategory { ID = 1, Name = "Impuestos Nacionales" },
                    new TributeCategory { ID = 2, Name = "Impuestos Provinciales" },
                    new TributeCategory { ID = 3, Name = "Impuestos Municipales" },
                    new TributeCategory { ID = 4, Name = "Impuestos Internos" },
                    new TributeCategory { ID = 99, Name = "Otros" });
            }

            if (context.FiscalConditionTypes.Count() != 14)
            {
                context.FiscalConditionTypes.AddOrUpdate(x => x.ID,
                    new FiscalConditionType { ID = 1, Description = "IVA RESPONSABLE INSCRIPTO" },
                    new FiscalConditionType { ID = 2, Description = "IVA RESPONSABLE NO INSCRIPTO" },
                    new FiscalConditionType { ID = 3, Description = "IVA NO RESPONSABLE" },
                    new FiscalConditionType { ID = 4, Description = "IVA SUJETO EXENTO" },
                    new FiscalConditionType { ID = 5, Description = "CONSUMIDOR FINAL" },
                    new FiscalConditionType { ID = 6, Description = "RESPONSABLE MONOTRIBUTO" },
                    new FiscalConditionType { ID = 7, Description = "SUJETO NO CATEGORIZADO" },
                    new FiscalConditionType { ID = 8, Description = "PROVEEDOR DEL EXTERIOR" },
                    new FiscalConditionType { ID = 9, Description = "CLIENTE DEL EXTERIOR" },
                    new FiscalConditionType { ID = 10, Description = "IVA LIBERADO – LEY Nº 19.640" },
                    new FiscalConditionType { ID = 11, Description = "IVA RESPONSABLE INSCRIPTO – AGENTE DE PERCEPCION" },
                    new FiscalConditionType { ID = 12, Description = "PEQUEÑO CONTRIBUYENTE EVENTUAL" },
                    new FiscalConditionType { ID = 13, Description = "MONOTRIBUTISTA SOCIAL" },
                    new FiscalConditionType { ID = 14, Description = "PEQUEÑO CONTRIBUYENTE EVENTUAL SOCIAL" });
            }

            if (context.DocumentTypes.Count() != 36)
            {
                context.DocumentTypes.AddOrUpdate(x => x.ID,
                    new DocumentType { ID = 0, Description = "Cédula de Identidad Policia Federal" },
                    new DocumentType { ID = 1, Description = "Cédula de Identidad Buenos Aires" },
                    new DocumentType { ID = 2, Description = "Cédula de Identidad Catamarca" },
                    new DocumentType { ID = 3, Description = "Cédula de Identidad Cordoba" },
                    new DocumentType { ID = 4, Description = "Cédula de Identidad Corrientes" },
                    new DocumentType { ID = 5, Description = "Cédula de Identidad Entre Rios" },
                    new DocumentType { ID = 6, Description = "Cédula de Identidad Jujuy" },
                    new DocumentType { ID = 7, Description = "Cédula de Identidad Mendoza" },
                    new DocumentType { ID = 8, Description = "Cédula de Identidad La Rioja" },
                    new DocumentType { ID = 9, Description = "Cédula de Identidad Salta" },
                    new DocumentType { ID = 10, Description = "Cédula de Identidad San Juan" },
                    new DocumentType { ID = 11, Description = "Cédula de Identidad San Luis" },
                    new DocumentType { ID = 12, Description = "Cédula de Identidad Santa Fe" },
                    new DocumentType { ID = 13, Description = "Cédula de Identidad Santiago Del Estero" },
                    new DocumentType { ID = 14, Description = "Cédula de Identidad Tucuman" },
                    new DocumentType { ID = 16, Description = "Cédula de Identidad Chaco" },
                    new DocumentType { ID = 17, Description = "Cédula de Identidad Chubut" },
                    new DocumentType { ID = 18, Description = "Cédula de Identidad Formosa" },
                    new DocumentType { ID = 19, Description = "Cédula de Identidad Misiones" },
                    new DocumentType { ID = 20, Description = "Cédula de Identidad Nuequen" },
                    new DocumentType { ID = 21, Description = "Cédula de Identidad La Pampa" },
                    new DocumentType { ID = 22, Description = "Cédula de Identidad Rio Negro" },
                    new DocumentType { ID = 23, Description = "Cédula de Identidad Santa Cruz" },
                    new DocumentType { ID = 24, Description = "Cédula de Identidad Tierra Del Fuego" },
                    new DocumentType { ID = 80, Description = "CUIT" },
                    new DocumentType { ID = 86, Description = "CUIL" },
                    new DocumentType { ID = 87, Description = "CDI" },
                    new DocumentType { ID = 89, Description = "Libreta de Enrolamiento" },
                    new DocumentType { ID = 90, Description = "Libreta Cívica" },
                    new DocumentType { ID = 91, Description = "Cédula de Identidad Extranjera" },
                    new DocumentType { ID = 92, Description = "En Trámite" },
                    new DocumentType { ID = 93, Description = "Acta De Nacimiento" },
                    new DocumentType { ID = 94, Description = "Pasaporte" },
                    new DocumentType { ID = 95, Description = "Cédula de Identidad Buenos Aires RNP" },
                    new DocumentType { ID = 96, Description = "DNI" },
                    new DocumentType { ID = 99, Description = "Sin Identificar" });
            }

            if (context.CurrencyTypes.Count() != 62)
            {
                context.CurrencyTypes.AddOrUpdate(x => x.ID,
                    new CurrencyType { ID = 1, Code = "000", Description = "OTRAS MONEDAS" },
                    new CurrencyType { ID = 2, Code = "PES", Description = "PESOS" },
                    new CurrencyType { ID = 3, Code = "DOL", Description = "DOLAR ESTADOUNIDENSE" },
                    new CurrencyType { ID = 4, Code = "002", Description = "DOLAR EEUU LIBRE" },
                    new CurrencyType { ID = 5, Code = "003", Description = "FRANCOS FRANCESES" },
                    new CurrencyType { ID = 6, Code = "004", Description = "LIRAS ITALIANAS" },
                    new CurrencyType { ID = 7, Code = "005", Description = "PESETAS" },
                    new CurrencyType { ID = 8, Code = "006", Description = "MARCOS ALEMANES" },
                    new CurrencyType { ID = 9, Code = "007", Description = "FLORINES HOLANDESES" },
                    new CurrencyType { ID = 10, Code = "008", Description = "FRANCOS BELGAS" },
                    new CurrencyType { ID = 11, Code = "009", Description = "FRANCOS SUIZOS" },
                    new CurrencyType { ID = 12, Code = "010", Description = "PESOS MEJICANOS" },
                    new CurrencyType { ID = 13, Code = "011", Description = "PESOS URUGUAYOS" },
                    new CurrencyType { ID = 14, Code = "012", Description = "REAL" },
                    new CurrencyType { ID = 15, Code = "013", Description = "ESCUDOS PORTUGUESES" },
                    new CurrencyType { ID = 16, Code = "014", Description = "CORONAS DANESAS" },
                    new CurrencyType { ID = 17, Code = "015", Description = "CORONAS NORUEGAS" },
                    new CurrencyType { ID = 18, Code = "016", Description = "CORONAS SUECAS" },
                    new CurrencyType { ID = 19, Code = "017", Description = "CHELINES AUTRIACOS" },
                    new CurrencyType { ID = 20, Code = "018", Description = "DOLAR CANADIENSE" },
                    new CurrencyType { ID = 21, Code = "019", Description = "YENES" },
                    new CurrencyType { ID = 22, Code = "021", Description = "LIBRA ESTERLINA" },
                    new CurrencyType { ID = 23, Code = "022", Description = "MARCOS FINLANDESES" },
                    new CurrencyType { ID = 24, Code = "023", Description = "BOLIVAR (VENEZOLANO)" },
                    new CurrencyType { ID = 25, Code = "024", Description = "CORONA CHECA" },
                    new CurrencyType { ID = 26, Code = "025", Description = "DINAR (YUGOSLAVO)" },
                    new CurrencyType { ID = 27, Code = "026", Description = "DOLAR AUSTRALIANO" },
                    new CurrencyType { ID = 28, Code = "027", Description = "DRACMA (GRIEGO)" },
                    new CurrencyType { ID = 29, Code = "028", Description = "FLORIN (ANTILLAS HOLA)" },
                    new CurrencyType { ID = 30, Code = "029", Description = "GUARANI" },
                    new CurrencyType { ID = 31, Code = "030", Description = "SHEKEL (ISRAEL)" },
                    new CurrencyType { ID = 32, Code = "031", Description = "PESO BOLIVIANO" },
                    new CurrencyType { ID = 33, Code = "032", Description = "PESO COLOMBIANO" },
                    new CurrencyType { ID = 34, Code = "033", Description = "PESO CHILENO" },
                    new CurrencyType { ID = 35, Code = "034", Description = "RAND (SUDAFRICANO)" },
                    new CurrencyType { ID = 36, Code = "035", Description = "NUEVO SOL PERUANO" },
                    new CurrencyType { ID = 37, Code = "036", Description = "SUCRE (ECUATORIANO)" },
                    new CurrencyType { ID = 38, Code = "040", Description = "LEI RUMANOS" },
                    new CurrencyType { ID = 39, Code = "041", Description = "DERECHOS ESPECIALES DE GIRO" },
                    new CurrencyType { ID = 40, Code = "042", Description = "PESOS DOMINICANOS" },
                    new CurrencyType { ID = 41, Code = "043", Description = "BALBOAS PANAMEÑAS" },
                    new CurrencyType { ID = 42, Code = "044", Description = "CORDOBAS NICARAGÛENSES" },
                    new CurrencyType { ID = 43, Code = "045", Description = "DIRHAM MARROQUÍES" },
                    new CurrencyType { ID = 44, Code = "046", Description = "LIBRAS EGIPCIAS" },
                    new CurrencyType { ID = 45, Code = "047", Description = "RIYALS SAUDITAS" },
                    new CurrencyType { ID = 46, Code = "048", Description = "BRANCOS BELGAS FINANCIERAS" },
                    new CurrencyType { ID = 47, Code = "049", Description = "GRAMOS DE ORO FINO" },
                    new CurrencyType { ID = 48, Code = "050", Description = "LIBRAS IRLANDESAS" },
                    new CurrencyType { ID = 49, Code = "051", Description = "DOLAR DE HONG KONG" },
                    new CurrencyType { ID = 50, Code = "052", Description = "DOLAR DE SINGAPUR" },
                    new CurrencyType { ID = 51, Code = "053", Description = "DOLAR DE JAMAICA" },
                    new CurrencyType { ID = 52, Code = "054", Description = "DOLAR DE TAIWAN" },
                    new CurrencyType { ID = 53, Code = "055", Description = "QUETZAL (GUATEMALTECOS)" },
                    new CurrencyType { ID = 54, Code = "056", Description = "FORINT (HUNGRIA)" },
                    new CurrencyType { ID = 55, Code = "057", Description = "BAHT (TAILANDIA)" },
                    new CurrencyType { ID = 56, Code = "058", Description = "ECU" },
                    new CurrencyType { ID = 57, Code = "059", Description = "DINAR KUWAITI" },
                    new CurrencyType { ID = 58, Code = "060", Description = "EURO" },
                    new CurrencyType { ID = 59, Code = "061", Description = "ZLTYS POLACOS" },
                    new CurrencyType { ID = 60, Code = "062", Description = "RUPIAS HINDÚES" },
                    new CurrencyType { ID = 61, Code = "063", Description = "LEMPIRAS HONDUREÑAS" },
                    new CurrencyType { ID = 62, Code = "064", Description = "YUAN (REPUBLICA POPULAR CHINA)" });
            }

            context.ReceiptTypes.AddOrUpdate(x => x.ID,
                    new InvoiceType { ID = 1, Description = "FACTURA A", Class = "A" },
                    new InvoiceType { ID = 2, Description = "NOTA DE DEBITO A", Class = "A" },
                    new InvoiceType { ID = 3, Description = "NOTA DE CREDITO A", Class = "A" },
                    new InvoiceType { ID = 4, Description = "RECIBO A", Class = "A" },
                    new InvoiceType { ID = 5, Description = "NOTA DE VENTA AL CONTADO A", Class = "A" },
                    new InvoiceType { ID = 6, Description = "FACTURA B", Class = "B" },
                    new InvoiceType { ID = 7, Description = "NOTA DE DEBITO B", Class = "B" },
                    new InvoiceType { ID = 8, Description = "NOTA DE CREDITO B", Class = "B" },
                    new InvoiceType { ID = 9, Description = "RECIBO B", Class = "B" },
                    new InvoiceType { ID = 10, Description = "NOTA DE VENTA AL CONTADO B", Class = "B" },
                    new InvoiceType { ID = 11, Description = "FACTURA C", Class = "C" },
                    new InvoiceType { ID = 12, Description = "NOTA DE DEBITO C", Class = "C" },
                    new InvoiceType { ID = 13, Description = "NOTA DE CREDITO C", Class = "C" },
                    new InvoiceType { ID = 15, Description = "RECIBO C", Class = "C" },
                    new InvoiceType { ID = 34, Description = "COMPROBANTES A DEL ANEXO I, APARTADO A  INCISO F)  R.G. N° 1415", Class = "A" },
                    new InvoiceType { ID = 35, Description = "COMPROBANTES B DEL ANEXO I, APARTADO A, INCISO F), R.G. N° 1415", Class = "B" },
                    new InvoiceType { ID = 39, Description = "OTROS COMPROBANTES A QUE CUMPLEN CON LA R G  N° 1415", Class = "A" },
                    new InvoiceType { ID = 40, Description = "OTROS COMPROBANTES B QUE CUMPLAN CON LA R.G. N° 1415", Class = "B" },
                    new InvoiceType { ID = 51, Description = "FACTURA M", Class = "M" },
                    new InvoiceType { ID = 52, Description = "NOTA DE DEBITO M", Class = "M" },
                    new InvoiceType { ID = 53, Description = "NOTA DE CREDITO M", Class = "M" },
                    new InvoiceType { ID = 54, Description = "RECIBO M", Class = "M" },
                    new InvoiceType { ID = 60, Description = "CUENTA DE VENTA Y LIQUIDO PRODUCTO A", Class = "A" },
                    new InvoiceType { ID = 61, Description = "CUENTA DE VENTA Y LIQUIDO PRODUCTO B", Class = "B" },
                    new InvoiceType { ID = 63, Description = "LIQUIDACIONES A", Class = "A" },
                    new InvoiceType { ID = 64, Description = "LIQUIDACIONES B", Class = "B" },
                    new InvoiceType { ID = 201, Description = "FACTURA DE CREDITO ELECTRONICA MIPYMES (FCE) A", Class = "A" },
                    new InvoiceType { ID = 202, Description = "NOTA DE DEBITO ELECTRONICA MIPYMES (FCE) A", Class = "A" },
                    new InvoiceType { ID = 203, Description = "NOTA DE CREDITO ELECTRONICA MIPYMES (FCE) A", Class = "A" },
                    new InvoiceType { ID = 206, Description = "FACTURA DE CREDITO ELECTRONICA MIPYMES (FCE) B", Class = "A" },
                    new InvoiceType { ID = 207, Description = "NOTA DE DEBITO ELECTRONICA MIPYMES (FCE) B", Class = "B" },
                    new InvoiceType { ID = 208, Description = "NOTA DE CREDITO ELECTRONICA MIPYMES (FCE) B", Class = "B" },
                    new InvoiceType { ID = 211, Description = "FACTURA DE CREDITO ELECTRONICA MIPYMES (FCE) C", Class = "C" },
                    new InvoiceType { ID = 212, Description = "NOTA DE DEBITO ELECTRONICA MIPYMES (FCE) C", Class = "C" },
                    new InvoiceType { ID = 213, Description = "NOTA DE CREDITO ELECTRONICA MIPYMES (FCE) C", Class = "C" });

            if (context.MeasureUnits.Count() != 54)
            {
                context.MeasureUnits.AddOrUpdate(x => x.ID,
                    new MeasureUnit { ID = 00, Description = "Sin Descripcion" },
                    new MeasureUnit { ID = 01, Description = "Kilogramo" },
                    new MeasureUnit { ID = 02, Description = "Metro" },
                    new MeasureUnit { ID = 03, Description = "Metro Cuadrado" },
                    new MeasureUnit { ID = 04, Description = "Metro Cúbico" },
                    new MeasureUnit { ID = 05, Description = "Litro" },
                    new MeasureUnit { ID = 06, Description = "1000 Kilowatt Hora" },
                    new MeasureUnit { ID = 07, Description = "Unidad" },
                    new MeasureUnit { ID = 08, Description = "Par" },
                    new MeasureUnit { ID = 09, Description = "Docena" },
                    new MeasureUnit { ID = 10, Description = "Quilate" },
                    new MeasureUnit { ID = 11, Description = "Millar" },
                    new MeasureUnit { ID = 14, Description = "Gramo" },
                    new MeasureUnit { ID = 15, Description = "Milimetro" },
                    new MeasureUnit { ID = 16, Description = "Milimetro Cúbico" },
                    new MeasureUnit { ID = 17, Description = "Kilometro" },
                    new MeasureUnit { ID = 18, Description = "Hectolitro" },
                    new MeasureUnit { ID = 20, Description = "Centimetro" },
                    new MeasureUnit { ID = 24, Description = "Unidad Internacional De Actividad Hormonal" },
                    new MeasureUnit { ID = 25, Description = "Juego, Paquete, Mazo de Naipes" },
                    new MeasureUnit { ID = 27, Description = "Centimetro Cúbico" },
                    new MeasureUnit { ID = 29, Description = "Tonelada" },
                    new MeasureUnit { ID = 30, Description = "Decametro Cúbico" },
                    new MeasureUnit { ID = 31, Description = "Hectometro Cúbico" },
                    new MeasureUnit { ID = 32, Description = "Kilometro Cúbico" },
                    new MeasureUnit { ID = 33, Description = "Microgramo" },
                    new MeasureUnit { ID = 34, Description = "Nanogramo" },
                    new MeasureUnit { ID = 35, Description = "Picogramo" },
                    new MeasureUnit { ID = 41, Description = "Miligramo" },
                    new MeasureUnit { ID = 47, Description = "Mililitro" },
                    new MeasureUnit { ID = 48, Description = "Curie" },
                    new MeasureUnit { ID = 49, Description = "Milicurie" },
                    new MeasureUnit { ID = 50, Description = "Microcurie" },
                    new MeasureUnit { ID = 51, Description = "Unidad Internacional De Actividad Hormonal" },
                    new MeasureUnit { ID = 52, Description = "Mega Unidad Internacional De Actividad Hormonal" },
                    new MeasureUnit { ID = 53, Description = "Kilogramo Base" },
                    new MeasureUnit { ID = 54, Description = "Gruesa" },
                    new MeasureUnit { ID = 61, Description = "Kilogramo Bruto" },
                    new MeasureUnit { ID = 62, Description = "Unidad Internacional De Actividad Para Antibioticos" },
                    new MeasureUnit { ID = 63, Description = "Mega Unidad Internacional De Actividad Para Antibioticos" },
                    new MeasureUnit { ID = 64, Description = "Unidad Internacional De Actividad Para Inmunoglobulinas" },
                    new MeasureUnit { ID = 65, Description = "Mega Unidad Internacional De Actividad Para Inmunoglobulinas" },
                    new MeasureUnit { ID = 66, Description = "Kilogramo Activo" },
                    new MeasureUnit { ID = 67, Description = "Gramo Activo" },
                    new MeasureUnit { ID = 68, Description = "Gramo Base" },
                    new MeasureUnit { ID = 96, Description = "Pack" },
                    //new UnidadMedida { ID = 63, Descripcion = "Horma" },
                    new MeasureUnit { ID = 97, Description = "Señas / Anticipos" },
                    new MeasureUnit { ID = 98, Description = "Otras Unidades" },
                    new MeasureUnit { ID = 99, Description = "Bonificación" });
            }

            if (context.Clients.Count() == 0)
            {
                context.Clients.AddOrUpdate(
                    new Client { ID = 1, BusinessName = "Consumidor Final", DocumentTypeID = 99, DocumentNumber = string.Empty, FiscalConditionID = 5, Address = string.Empty });
            }

            base.Seed(context);
        }
    }
}