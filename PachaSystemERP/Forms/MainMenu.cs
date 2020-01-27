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

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PachaSystemMainMenu"/>.
        /// </summary>
        public PachaSystemMainMenu()
        {
            InitializeComponent();
            Configuracion.CargarConfiguracion();
            _context = new PachaSystemContext();
            _context.Database.Initialize(false);
            _unitOfWork = new UnitOfWork(_context);
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            toolStripStatusLabelMenuPrincipal.Text = "Bienvenido";
            toolStripProgressBarMenuPrincipal.Style = ProgressBarStyle.Blocks;
        }

        private void TsmiOpciones_Click(object sender, EventArgs e)
        {
            var form = new ConfigurationMenu();
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

        private void tributosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TributeManagement();
            form.ShowDialog();
        }

        private void FacturaBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var invoiceType = _unitOfWork.InvoiceTypes.Get(x => x.Description == "FACTURA A");
            var form = new FacturaB(invoiceType)
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill,
            };
            pnlPrincipal.Controls.Clear();
            pnlPrincipal.Controls.Add(form);
            form.Show();
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

        private void tsmiVatView_Click(object sender, EventArgs e)
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

        private void ToolStripMenuItemFacturaA_Click(object sender, EventArgs e)
        {
            var invoiceType = _unitOfWork.InvoiceTypes.Get(x => x.Description == "FACTURA A");
            var form = new FacturaB(invoiceType)
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