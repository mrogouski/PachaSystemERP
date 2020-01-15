namespace PachaSystemERP.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystemERP.Classes;
    using PachaSystemERP.Enums;

    public partial class MainMenu : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MainMenu"/>.
        /// </summary>
        public MainMenu()
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
            var form = new FacturaB()
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
            var form = new AddClient
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
    }
}
