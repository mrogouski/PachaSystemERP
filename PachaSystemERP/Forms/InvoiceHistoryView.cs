using PachaSystem.Data;
using PachaSystem.Data.Helpers;
using PachaSystem.Data.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PachaSystemERP.Forms
{
    public partial class InvoiceHistoryView : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        public InvoiceHistoryView()
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            InitializeComponent();
        }

        private void InvoiceHistoryView_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            DgvInvoices.DataSource = (from c in _context.Invoices
                                      join dc in _context.InvoiceDetails on c.ID equals dc.InvoiceID
                                      join p in _context.Items on dc.ItemID equals p.ID
                                      join i in _context.Vat on p.VatID equals i.ID
                                      //join dt in _context.DetalleTributo on c.ID equals dt.ComprobanteID
                                      //join t in _context.Tributo on dt.TributoID equals t.ID
                                      //join ct in _context.CategoriaTributo on t.CategoriaTributoID equals ct.ID
                                      join client in _context.Clients on c.CustomerID equals client.ID
                                      select new
                                      {
                                          c.ID,
                                          c.InvoiceTypeID,
                                          c.PointOfSale,
                                          c.InvoiceNumber,
                                          c.Cae,
                                          c.CaeExpirationDate,
                                          c.InvoiceDate,
                                          c.TotalAmount,
                                          c.NotTaxedNetAmount,
                                          c.NetAmount,
                                          c.ExemptAmount,
                                          c.TributeTotalAmount,
                                          c.VatTotalAmount,
                                          c.ServiceStartDate,
                                          c.ServiceFinishDate,
                                          c.DueDate,
                                          client.BusinessName,
                                          client.DocumentNumber,
                                          client.FiscalConditionType.Description,
                                          client.Address,
                                      }).ToList();
        }
    }
}
