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

    public partial class Factura : Form
    {
        private ErrorProvider _errorProvider;
        private CueText _cueText;
        private BindingSource _bindingSource;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private GeneradorComprobante _generador;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Factura"/>.
        /// </summary>
        public Factura(TipoComprobante tipoComprobante)
        {
            if (tipoComprobante == null)
            {
                throw new ArgumentNullException(nameof(tipoComprobante));
            }

            InitializeComponent();
            _errorProvider = new ErrorProvider();
            _cueText = new CueText();
            _bindingSource = new BindingSource();
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            _generador = new GeneradorComprobante(tipoComprobante);
        }

        private void MenuFacturacion_Load(object sender, EventArgs e)
        {
            _cueText = new CueText();
            _cueText.SetCueText(txtRazonSocial, "Consumidor Final");
            _cueText.SetCueText(txtNumeroDeDocumento, "Consumidor Final");

            lblNumeroComprobante.Text = _generador.NumeroComprobante;

            lblTotal.DataBindings.Add("Text", _generador, "ImporteTotal", true, DataSourceUpdateMode.OnPropertyChanged, 0, "C");
            lblCantidadArticulos.DataBindings.Add("Text", _generador, "CantidadTotal", true, DataSourceUpdateMode.OnPropertyChanged);

            CargarComboBox();
            CargarDataGridView();
        }

        private void Inicializar()
        {
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
        }

        private void CargarComboBox()
        {
            if (Configuracion.ModoFacturacion == ModoFacturacion.FacturaElectronica)
            {
                cbTipoDocumento.DataSource = _unitOfWork.TipoDocumento.ObtenerTodos(x => x.FacturaElectronica == true);
                cbTipoDocumento.ValueMember = "ID";
                cbTipoDocumento.DisplayMember = "Descripcion";
                cbTipoDocumento.SelectedValue = 99;

                cbTipoResponsabilidadCliente.DataSource = _unitOfWork.TipoResponsable.ObtenerTodos(x => x.FacturaElectronica == true);
                cbTipoResponsabilidadCliente.ValueMember = "ID";
                cbTipoResponsabilidadCliente.DisplayMember = "Descripcion";
                cbTipoResponsabilidadCliente.SelectedValue = 5;
            }
        }

        private void CargarDataGridView()
        {
            _bindingSource.DataSource = _generador.DetalleFacturacion;

            dgvArticulos.DataSource = _bindingSource;
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
                _errorProvider.Clear();
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
                var producto = _unitOfWork.Producto.Obtener(x => x.Codigo == txtCodigo.Text);

                if (producto != null)
                {
                    txtDescripcion.Text = producto.Descripcion;
                    NudPrecioUnitario.Value = producto.PrecioUnitario;
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
            _generador.AgregarProducto(txtCodigo.Text, (int)NudCantidad.Value);
            _bindingSource.ResetBindings(false);
            txtCodigo.Clear();
            txtDescripcion.Clear();
            NudCantidad.Value = 1;
            NudPrecioUnitario.Value = 0.00M;
            NudSubtotal.Value = 0.00M;
        }

        private async void BtnFacturar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosCliente())
            {
                _generador.AgregarCliente(txtRazonSocial.Text, (int)cbTipoDocumento.SelectedValue, txtNumeroDeDocumento.Text, (int)cbTipoResponsabilidadCliente.SelectedValue, txtDomicilio.Text);
            }

            var concepto = _unitOfWork.TipoConcepto.Obtener(x => x.Descripcion == "PRODUCTOS");

            var form = new VisorFactura(_generador.GenerarComprobante(concepto));
            var dialogResult = form.ShowDialog();

            Inicializar();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            var query = _unitOfWork.Producto.Obtener(x => x.Descripcion == txtDescripcion.Text);
            if (query != null)
            {
                txtCodigo.Text = query.Codigo;
                NudPrecioUnitario.Value = query.PrecioUnitario;
            }
        }
    }
}