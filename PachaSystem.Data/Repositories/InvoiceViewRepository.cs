using PachaSystem.Data.Views;
using System.Collections.Generic;
using System.Linq;

namespace PachaSystem.Data.Repositories
{
    public class InvoiceViewRepository
    {
        public IEnumerable<ReceiptView> Get(int id)
        {
            using (var context = new PachaSystemContext())
            {
                var query = (from c in context.Invoices
                             join dc in context.InvoiceDetails on c.ID equals dc.InvoiceID
                             join p in context.Items on dc.ItemID equals p.ID
                             join i in context.Vat on p.VatID equals i.ID
                             //join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                             //join t in _context.Tributo on dt.TributoID equals t.ID
                             //join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                             join client in context.Clients on c.CustomerID equals client.ID
                             where c.ID == id
                             select new ReceiptView
                             {
                                 ReceiptID = c.ID,
                                 ReceiptTypeID = c.InvoiceTypeID,
                                 PointOfSale = c.PointOfSale,
                                 ReceiptNumber = c.InvoiceNumber,
                                 Cae = c.Cae,
                                 CaeExpirationDate = c.CaeExpirationDate,
                                 ReceiptDate = c.InvoiceDate,
                                 TotalAmount = c.TotalAmount,
                                 NetAmountNotTaxed = c.NotTaxedNetAmount,
                                 NetAmount = c.NetAmount,
                                 ExemptAmount = c.ExemptAmount,
                                 TotalAmountTax = c.TributeTotalAmount,
                                 TotalAmountVat = c.VatTotalAmount,
                                 ServiceStartDate = c.ServiceStartDate,
                                 ServiceEndingDate = c.ServiceFinishDate,
                                 PaymentExpirationDate = c.DueDate,
                                 BusinessName = client.BusinessName,
                                 DocumentNumber = client.DocumentNumber,
                                 FiscalCondition = client.FiscalConditionType.Description,
                                 Address = client.Address,
                                 ItemQuantity = dc.Quantity,
                                 TaxBase = dc.TaxBase,
                                 Subtotal = dc.Subtotal,
                                 AmountVat = dc.VatAmount,
                                 ProductCode = p.Code,
                                 ProductName = p.Description,
                                 UnitPrice = p.UnitPrice,
                                 VatType = i.Description,
                                 VatAliquot = i.Aliquot
                             }).ToList();
                return query;
            }
        }
    }
}