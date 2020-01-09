// <copyright file="Factura.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Forms
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystemERP.Classes;
    using PachaSystemERP.Controles;
    using PachaSystemERP.Enums;

    public partial class FacturaB : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private InvoiceBuilder _invoiceBuilder;
        private ElectronicInvoicing _electronicInvoicing;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacturaB"/>.
        /// </summary>
        public FacturaB()
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _electronicInvoicing = new ElectronicInvoicing();
            InitializeComponent();
        }

        private void MenuFacturacion_Load(object sender, EventArgs e)
        {
            using (var cueText = new CueText())
            {
                cueText.SetCueText(txtRazonSocial, "Consumidor Final");
                cueText.SetCueText(txtNumeroDeDocumento, "Consumidor Final");
            }

            Initialize();

            lblTotal.DataBindings.Add("Text", _invoiceBuilder, "ImporteTotal", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C");
            lblCantidadArticulos.DataBindings.Add("Text", _invoiceBuilder, "CantidadTotal", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Initialize()
        {
            var invoiceType = _unitOfWork.InvoiceTypes.Get(x => x.Description == "FACTURA B");
            var conceptType = _unitOfWork.ConceptTypes.Get(x => x.Name == "Productos");
            var invoiceNumber = _electronicInvoicing.GetLastReceiptNumber(invoiceType.ID) + 1;
            _invoiceBuilder = new InvoiceBuilder(invoiceType.ID, conceptType.ID, invoiceNumber);

            LblReceiptNumber.Text = _invoiceBuilder.ReceiptNumber;

            txtRazonSocial.Clear();
            cbTipoResponsabilidadCliente.SelectedValue = 0;
            cbTipoDocumento.SelectedValue = 0;
            txtNumeroDeDocumento.Clear();
            txtDomicilio.Clear();

            txtCodigo.Clear();
            txtDescripcion.Clear();
            NudCantidad.Value = 1;
            NudPrecioUnitario.Value = 0;
            NudSubtotal.Value = 0;

            CargarComboBox();
            CargarDataGridView();
        }

        private void CargarComboBox()
        {
            cbTipoDocumento.DataSource = _unitOfWork.DocumentTypes.GetAll();
            cbTipoDocumento.ValueMember = "ID";
            cbTipoDocumento.DisplayMember = "Descripcion";
            cbTipoDocumento.SelectedValue = 99;

            cbTipoResponsabilidadCliente.DataSource = _unitOfWork.FiscalConditionTypes.GetAll();
            cbTipoResponsabilidadCliente.ValueMember = "ID";
            cbTipoResponsabilidadCliente.DisplayMember = "Descripcion";
            cbTipoResponsabilidadCliente.SelectedValue = 5;
        }

        private void CargarDataGridView()
        {
            bindingSource.DataSource = _invoiceBuilder.InvoiceDetails;

            DgvArticles.DataSource = bindingSource;
            DgvArticles.Columns["ProductID"].Visible = false;
            DgvArticles.Columns["VatAliquot"].Visible = false;
            DgvArticles.Columns["VatAmount"].Visible = false;
            DgvArticles.Columns["TaxBase"].Visible = false;
        }      

        private void TxtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                using (var context = new PachaSystemContext())
                {
                    using (var unitOfWork = new UnitOfWork(context))
                    {
                        var producto = unitOfWork.Items.Get(x => x.Code == txtCodigo.Text);

                        if (producto != null)
                        {
                            txtDescripcion.Text = producto.Description;
                            NudPrecioUnitario.Value = producto.UnitPrice;
                        }
                    }
                }
            }
            else
            {
                txtDescripcion.Clear();
                NudCantidad.Value = 1;
                NudPrecioUnitario.Value = 0;
                NudSubtotal.Value = 0;
            }
        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void NudCantidad_ValueChanged(object sender, EventArgs e)
        {
            NudSubtotal.Value = decimal.Round(NudCantidad.Value * NudPrecioUnitario.Value, 2, MidpointRounding.ToEven);
        }

        private void NudPrecioUnitario_ValueChanged(object sender, EventArgs e)
        {
            NudSubtotal.Value = decimal.Round(NudCantidad.Value * NudPrecioUnitario.Value, 2, MidpointRounding.ToEven);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            _invoiceBuilder.AddItem(txtCodigo.Text, (int)NudCantidad.Value);
            bindingSource.ResetBindings(false);
            txtCodigo.Clear();
            txtDescripcion.Clear();
            NudCantidad.Value = 1;
            NudPrecioUnitario.Value = 0.00M;
            NudSubtotal.Value = 0.00M;
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            using (var context = new PachaSystemContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    _electronicInvoicing = new ElectronicInvoicing();
                    var invoice = _electronicInvoicing.GenerateInvoice(_invoiceBuilder);
                    if (invoice != null)
                    {
                        var form = new ReceiptViewer(invoice);
                        form.ShowDialog();
                    }
                }
            }

            Initialize();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            var query = _unitOfWork.Items.Get(x => x.Description == txtDescripcion.Text);
            if (query != null)
            {
                txtCodigo.Text = query.Code;
                NudPrecioUnitario.Value = query.UnitPrice;
            }
        }
    }
}