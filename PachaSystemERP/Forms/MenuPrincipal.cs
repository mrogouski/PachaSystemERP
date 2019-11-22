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

    public partial class MenuPrincipal : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MenuPrincipal"/>.
        /// </summary>
        public MenuPrincipal()
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
            var form = new MenuConfiguracion();
            form.Show();
        }

        private void TsbStock_Click(object sender, EventArgs e)
        {
            var form = new ControlDeStock
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
            var form = new ControlDeTributos();
            form.ShowDialog();
        }

        private void FacturaBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tipoComprobante = _unitOfWork.TipoComprobante.Obtener(x => x.Descripcion == "FACTURA B");
            var form = new Factura(tipoComprobante)
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
            var form = new ManejoDeClientes
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
