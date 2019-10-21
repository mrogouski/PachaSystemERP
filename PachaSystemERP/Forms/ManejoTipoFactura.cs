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

    public partial class ManejoDeTipoDeFactura : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ManejoDeTipoDeFactura"/>.
        /// </summary>
        public ManejoDeTipoDeFactura()
        {
            InitializeComponent();
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            BindingSource binding = new BindingSource();
            binding.DataSource = _unitOfWork.TipoComprobante;
            dgvTipoDeComprobante.DataSource = binding;

            dgvTipoDeComprobante.Columns["Id"].Visible = false;
            dgvTipoDeComprobante.Columns["ImpresoraFiscal"].Visible = false;
            dgvTipoDeComprobante.Columns["FacturaElectronica"].Visible = false;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "cbImpresoraFiscal";
            checkBoxColumn.DataPropertyName = "ImpresoraFiscal";
            checkBoxColumn.HeaderText = "Impresora Fiscal";
            dgvTipoDeComprobante.Columns.Insert(2, checkBoxColumn);

            DataGridViewCheckBoxColumn checkBoxColumn2 = new DataGridViewCheckBoxColumn();
            checkBoxColumn2.Name = "cbFacturaElectronica";
            checkBoxColumn2.DataPropertyName = "FacturaElectronica";
            checkBoxColumn2.HeaderText = "Factura Electronica";
            dgvTipoDeComprobante.Columns.Insert(3, checkBoxColumn2);
        }
    }
}
