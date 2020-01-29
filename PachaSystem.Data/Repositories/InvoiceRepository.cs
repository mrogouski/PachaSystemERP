// <copyright file="ComprobanteRepository.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystem.Data.Repositories
{
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystem.Data.Views;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class InvoiceRepository : IRepository<Invoice>
    {
        private PachaSystemContext _context;

        public InvoiceRepository(PachaSystemContext context)
        {
            _context = context;
        }

        public void Add(Invoice entidad)
        {
            _context.Invoices.Add(entidad);
        }

        public Invoice Find(int id)
        {
            return _context.Invoices.Find(id);
        }

        public IEnumerable<InvoiceView> Get(int id)
        {
            var query = (from invoice in _context.Invoices
                         join invoiceDetails in _context.InvoiceDetails on invoice.ID equals invoiceDetails.InvoiceID
                         join items in _context.Items on invoiceDetails.ItemID equals items.ID
                         join vat in _context.Vat on items.VatID equals vat.ID
                         join tributeDetails in _context.TributeDetails on invoice.ID equals tributeDetails.InvoiceID
                         join tribute in _context.Tributes on tributeDetails.TributeID equals tribute.ID
                         join tributeCategory in _context.TributeCategories on tribute.TributeCategoryID equals tributeCategory.ID
                         join customer in _context.Customers on invoice.CustomerID equals customer.ID
                         where invoice.ID == id
                         select new InvoiceView
                         {
                             InvoiceID = invoice.ID,
                             InvoiceTypeID = invoice.InvoiceTypeID,
                             PointOfSale = invoice.PointOfSale,
                             InvoiceNumber = invoice.InvoiceNumber,
                             Cae = invoice.Cae,
                             CaeExpirationDate = invoice.CaeExpirationDate,
                             InvoiceDate = invoice.InvoiceDate,
                             TotalAmount = invoice.TotalAmount,
                             NetAmountNotTaxed = invoice.NotTaxedNetAmount,
                             NetAmount = invoice.NetAmount,
                             ExemptAmount = invoice.ExemptAmount,
                             TotalAmountTax = invoice.TributeTotalAmount,
                             TotalAmountVat = invoice.VatTotalAmount,
                             ServiceStartDate = invoice.ServiceStartDate,
                             ServiceEndingDate = invoice.ServiceFinishDate,
                             PaymentExpirationDate = invoice.DueDate,
                             BusinessName = customer.BusinessName,
                             DocumentNumber = customer.DocumentNumber,
                             FiscalCondition = customer.FiscalConditionType.Description,
                             Address = customer.Address,
                             ItemQuantity = invoiceDetails.Quantity,
                             TaxBase = invoiceDetails.TaxBase,
                             Subtotal = invoiceDetails.Subtotal,
                             AmountVat = invoiceDetails.VatAmount,
                             ProductCode = items.Code,
                             ProductName = items.Description,
                             UnitPrice = items.UnitPrice,
                             VatType = vat.Description,
                             VatAliquot = vat.Aliquot
                         });
            return query.ToList();
        }

        public Invoice Get(Expression<Func<Invoice, bool>> filtro)
        {
            var query = (from invoice in _context.Invoices
                         join invoiceDetails in _context.InvoiceDetails on invoice.ID equals invoiceDetails.InvoiceID
                         join items in _context.Items on invoiceDetails.ItemID equals items.ID
                         join vat in _context.Vat on items.VatID equals vat.ID
                         join tributeDetails in _context.TributeDetails on invoice.ID equals tributeDetails.InvoiceID
                         join tribute in _context.Tributes on tributeDetails.TributeID equals tribute.ID
                         join tributeCategory in _context.TributeCategories on tribute.TributeCategoryID equals tributeCategory.ID
                         join customer in _context.Customers on invoice.CustomerID equals customer.ID
                         select invoice)
                         .Where(filtro)
                         .FirstOrDefault();
            return query;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _context.Invoices.ToList();
        }

        public IEnumerable<Invoice> GetAll(Expression<Func<Invoice, bool>> filtro)
        {
            return _context.Invoices.Where(filtro).ToList();
        }

        public void Remove(Invoice entidad)
        {
            _context.Invoices.Remove(entidad);
        }
    }
}