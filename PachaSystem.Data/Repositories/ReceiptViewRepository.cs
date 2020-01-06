using PachaSystem.Data.Helpers;
using PachaSystem.Data.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PachaSystem.Data.Repositories
{
    public class ReceiptViewRepository
    {
        public IEnumerable<ReceiptView> Get(int id)
        {
            using (var context = new PachaSystemContext())
            {
                var query = (from c in context.Receipts
                             join dc in context.ReceiptDetails on c.ID equals dc.ReceiptID
                             join p in context.Items on dc.ItemID equals p.ID
                             join i in context.Vat on p.VatID equals i.ID
                             //join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                             //join t in _context.Tributo on dt.TributoID equals t.ID
                             //join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                             join client in context.Clients on c.ClientID equals client.ID
                             where c.ID == id
                             select new ReceiptView
                             {
                                 ReceiptID = c.ID,
                                 ReceiptTypeID = c.ReceiptTypeID,
                                 PointOfSale = c.PointOfSale,
                                 ReceiptNumber = c.ReceiptNumber,
                                 Cae = c.Cae,
                                 CaeExpirationDate = c.CaeExpirationDate,
                                 ReceiptDate = c.ReceiptDate,
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
