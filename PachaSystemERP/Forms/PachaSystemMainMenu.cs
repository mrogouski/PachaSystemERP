namespace PachaSystemERP.Forms
{
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystemERP.Classes;
    using System;
    using System.Windows.Forms;

    public partial class PachaSystemMainMenu : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        public PachaSystemMainMenu()
        {
            InitializeComponent();
            Configuracion.CargarConfiguracion();
            _context = new PachaSystemContext();
            _context.Database.Initialize(false);
            _unitOfWork = new UnitOfWork(_context);
        }

        private void PachaSystemMainMenu_Load(object sender, EventArgs e)
        {
            toolStripStatusLabelMenuPrincipal.Text = "Bienvenido";
        }

        private void TsbClientes_Click(object sender, EventArgs e)
        {
            var form = new CustomerManagement
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(form);
            form.Show();
        }

        private void TsbInvoicesHistory_Click(object sender, EventArgs e)
        {
            var form = new InvoiceHistoryView
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(form);
            form.Show();
        }

        private void TsbStock_Click(object sender, EventArgs e)
        {
            var form = new StockManagement
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(form);
            form.Show();
        }

        private void TsmiFacturaA_Click(object sender, EventArgs e)
        {
            var invoiceType = _unitOfWork.InvoiceTypes.Get(x => x.Description == "FACTURA A");
            var form = new Invoicing(invoiceType)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(form);
            form.Show();
        }

        private void TsmiFacturaB_Click(object sender, EventArgs e)
        {
            var invoiceType = _unitOfWork.InvoiceTypes.Get(x => x.Description == "FACTURA B");
            var form = new Invoicing(invoiceType)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(form);
            form.Show();
        }

        private void TsmiFacturaC_Click(object sender, EventArgs e)
        {
            var invoiceType = _unitOfWork.InvoiceTypes.Get(x => x.Description == "FACTURA C");
            var form = new Invoicing(invoiceType)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(form);
            form.Show();
        }

        private void TsmiNotaDeDébito_Click(object sender, EventArgs e)
        {

        }

        private void TsmiOpciones_Click(object sender, EventArgs e)
        {
            var form = new ConfigurationMenu();
            form.Show();
        }

        private void TsmiTributos_Click(object sender, EventArgs e)
        {
            var form = new TributeManagement();
            form.ShowDialog();
        }

        private void TsmiVatView_Click(object sender, EventArgs e)
        {
            var form = new VatTypeView
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(form);
            form.Show();
        }
    }
}