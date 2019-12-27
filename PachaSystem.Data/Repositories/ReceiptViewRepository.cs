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
                var query = (from c in context.Comprobante
                             join dc in context.DetalleComprobante on c.ID equals dc.ComprobanteID
                             join p in context.Producto on dc.ProductoID equals p.ID
                             join i in context.Iva on p.IvaID equals i.ID
                             //join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                             //join t in _context.Tributo on dt.TributoID equals t.ID
                             //join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                             join client in context.Cliente on c.clientID equals client.ID
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
                                 BusinessName = client.RazonSocial,
                                 DocumentNumber = client.NumeroDocumento,
                                 FiscalCondition = client.TipoResponsable.Descripcion,
                                 Address = client.Domicilio,
                                 ItemQuantity = dc.Cantidad,
                                 TaxBase = dc.BaseImponible,
                                 Subtotal = dc.Subtotal,
                                 AmountVat = dc.ImporteIva,
                                 ProductCode = p.Codigo,
                                 ProductName = p.Descripcion,
                                 UnitPrice = p.PrecioUnitario,
                                 VatType = i.Descripcion,
                                 VatAliquot = i.Alicuota
                             }).ToList();
                return query;
            }
        }
    }
}
