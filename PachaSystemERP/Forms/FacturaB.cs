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
        private ReceiptBuilder _receiptGenerator;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacturaB"/>.
        /// </summary>
        public FacturaB()
        {
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

            lblTotal.DataBindings.Add("Text", _receiptGenerator, "ImporteTotal", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C");
            lblCantidadArticulos.DataBindings.Add("Text", _receiptGenerator, "CantidadTotal", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void Initialize()
        {
            using (var context = new PachaSystemContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var receiptType = unitOfWork.TipoComprobante.Get(x => x.Description == "FACTURA B");
                    _receiptGenerator = new ReceiptBuilder(receiptType.ID);
                }
            }

            LblReceiptNumber.Text = _receiptGenerator.ReceiptNumber;

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
            using (var context = new PachaSystemContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    cbTipoDocumento.DataSource = unitOfWork.TipoDocumento.GetAll();
                    cbTipoDocumento.ValueMember = "ID";
                    cbTipoDocumento.DisplayMember = "Descripcion";
                    cbTipoDocumento.SelectedValue = 99;

                    cbTipoResponsabilidadCliente.DataSource = unitOfWork.TipoResponsable.GetAll();
                    cbTipoResponsabilidadCliente.ValueMember = "ID";
                    cbTipoResponsabilidadCliente.DisplayMember = "Descripcion";
                    cbTipoResponsabilidadCliente.SelectedValue = 5;
                }
            }
        }

        private void CargarDataGridView()
        {
            bindingSource.DataSource = _receiptGenerator.DetalleFacturacion;

            DgvArticles.DataSource = bindingSource;
            DgvArticles.Columns["ProductID"].Visible = false;
            DgvArticles.Columns["VatAliquot"].Visible = false;
            DgvArticles.Columns["VatAmount"].Visible = false;
            DgvArticles.Columns["TaxBase"].Visible = false;
            
        }

        private bool ValidarDatosCliente()
        {
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text)
                && string.IsNullOrWhiteSpace(txtNumeroDeDocumento.Text)
                && string.IsNullOrWhiteSpace(txtDomicilio.Text)
                && cbTipoDocumento.SelectedValue.Equals(99)
                && cbTipoResponsabilidadCliente.SelectedValue.Equals(5))
            {
                return false;
            }
            else
            {
                errorProvider.Clear();
                return true;
            }
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
                        var producto = unitOfWork.Producto.Get(x => x.Code == txtCodigo.Text);

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
            _receiptGenerator.AddItem(txtCodigo.Text, (int)NudCantidad.Value);
            bindingSource.ResetBindings(false);
            txtCodigo.Clear();
            txtDescripcion.Clear();
            NudCantidad.Value = 1;
            NudPrecioUnitario.Value = 0.00M;
            NudSubtotal.Value = 0.00M;
        }

        private void BtnFacturar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosCliente())
            {
                _receiptGenerator.AgregarCliente(txtRazonSocial.Text, (int)cbTipoDocumento.SelectedValue, txtNumeroDeDocumento.Text, (int)cbTipoResponsabilidadCliente.SelectedValue, txtDomicilio.Text);
            }

            using (var context = new PachaSystemContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var query = unitOfWork.TipoConcepto.Get(x => x.Name == "PRODUCTOS");

                    var comprobante = _receiptGenerator.GenerarComprobante(query.ID);
                    if (comprobante == null)
                    {
                        MessageBox.Show("No se pudo generar el comprobante, revise el registro de errores");
                    }
                    else
                    {
                        var form = new ReceiptViewer(comprobante);
                        form.ShowDialog();
                    }
                }
            }

            Initialize();
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            using (var context = new PachaSystemContext())
            {
                using (var unitOfWork = new UnitOfWork(context))
                {
                    var query = unitOfWork.Producto.Get(x => x.Description == txtDescripcion.Text);
                    if (query != null)
                    {
                        txtCodigo.Text = query.Code;
                        NudPrecioUnitario.Value = query.UnitPrice;
                    }
                }
            }
        }
    }
}