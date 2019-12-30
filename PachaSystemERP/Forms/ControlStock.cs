// <copyright file="ControlStock.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystemERP.Controles;

    public partial class ControlDeStock : Form
    {
        private PachaSystemContext _context;
        private ErrorProvider _errorProvider;
        private CueText _cueText;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ControlDeStock"/>.
        /// </summary>
        public ControlDeStock()
        {
            InitializeComponent();
            _context = new PachaSystemContext();
            _errorProvider = new ErrorProvider();
        }

        private void Inicializar()
        {
            _cueText = new CueText();
            _cueText.SetCueText(TxtBuscar, "Ingrese el nombre o código del producto...");
            CargarArticulos();
        }

        private void CargarArticulos()
        {
            _context.Items.Load();
            _context.Vat.Load();
            _context.ItemCategories.Load();
            _context.MeasureUnits.Load();

            bindingSource= new BindingSource();

            bindingSource.DataSource = _context.Items.Local.ToBindingList();

            DgvArticulos.DataSource = bindingSource;
            DgvArticulos.Columns["ID"].Visible = false;
            DgvArticulos.Columns["CategoriaProductoID"].Visible = false;
            DgvArticulos.Columns["IvaID"].Visible = false;
            DgvArticulos.Columns["CategoriaProducto"].Visible = false;
            DgvArticulos.Columns["Iva"].Visible = false;
            DgvArticulos.Columns["DetalleComprobante"].Visible = false;
            DgvArticulos.Columns["FechaBaja"].Visible = false;

            DataGridViewComboBoxColumn ivaColumn = new DataGridViewComboBoxColumn();
            ivaColumn.DataPropertyName = "IvaID";
            ivaColumn.Name = "Alicuota IVA";
            ivaColumn.DataSource = _context.Vat.Local.ToBindingList();
            ivaColumn.DisplayMember = "Descripcion";
            ivaColumn.ValueMember = "ID";
            DgvArticulos.Columns.Add(ivaColumn);

            DataGridViewComboBoxColumn categoryColumn = new DataGridViewComboBoxColumn();
            categoryColumn.DataPropertyName = "CategoriaProductoID";
            categoryColumn.Name = "Categoría";
            categoryColumn.DataSource = _context.ItemCategories.Local.ToBindingList();
            categoryColumn.DisplayMember = "Descripcion";
            categoryColumn.ValueMember = "ID";
            DgvArticulos.Columns.Add(categoryColumn);
        }

        private void ControlDeStock_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                _context.SaveChanges();
                bindingSource.ResetBindings(false);
            }
            catch (DbEntityValidationException ex)
            {
                _errorProvider.SetError(DgvArticulos, ex.EntityValidationErrors.ToString());
                throw;
            }
        }

        private void DgvArticulos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && (e.Context & DataGridViewDataErrorContexts.Commit) == DataGridViewDataErrorContexts.Commit)
            {
                DgvArticulos[e.ColumnIndex, e.RowIndex].ErrorText = "El valor ingresado es incorrecto";
            }
            else
            {
                DgvArticulos[e.ColumnIndex, e.RowIndex].ErrorText = string.Empty;
            }
        }
    }
}
