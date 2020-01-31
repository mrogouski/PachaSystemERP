// <copyright file="ControlStock.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Forms
{
    using PachaSystem.Data;
    using PachaSystemERP.Controles;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Windows.Forms;

    public partial class StockManagement : Form
    {
        private PachaSystemContext _context;

        public StockManagement()
        {
            InitializeComponent();
            _context = new PachaSystemContext();
        }

        private void Initialize()
        {
            LoadItems();
        }

        private void LoadItems()
        {
            _context.Products.Load();
            _context.Vat.Load();
            _context.ProductCategories.Load();
            _context.MeasureUnits.Load();

            bindingSource.DataSource = _context.Products.Local.ToBindingList();

            DgvArticulos.DataSource = bindingSource;
            DgvArticulos.Columns["ID"].Visible = false;
            DgvArticulos.Columns["ProductCategoryID"].Visible = false;
            DgvArticulos.Columns["VatID"].Visible = false;
            DgvArticulos.Columns["ProductCategory"].Visible = false;
            DgvArticulos.Columns["Vat"].Visible = false;
            DgvArticulos.Columns["InvoiceDetails"].Visible = false;

            DataGridViewComboBoxColumn vatColumn = new DataGridViewComboBoxColumn();
            vatColumn.DataPropertyName = "VatID";
            vatColumn.Name = "Alicuota IVA";
            vatColumn.DataSource = _context.Vat.Local.ToBindingList();
            vatColumn.DisplayMember = "Description";
            vatColumn.ValueMember = "ID";
            DgvArticulos.Columns.Add(vatColumn);

            DataGridViewComboBoxColumn categoryColumn = new DataGridViewComboBoxColumn();
            categoryColumn.DataPropertyName = "ItemCategoryID";
            categoryColumn.Name = "Categoría";
            categoryColumn.DataSource = _context.ProductCategories.Local.ToBindingList();
            categoryColumn.DisplayMember = "Name";
            categoryColumn.ValueMember = "ID";
            DgvArticulos.Columns.Add(categoryColumn);
        }

        private void ControlDeStock_Load(object sender, EventArgs e)
        {
            using (var cueText = new CueText())
            {
                cueText.SetCueText(TxtBuscar, "Ingrese el nombre o código del producto...");
            }

            Initialize();
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
                errorProvider.SetError(DgvArticulos, ex.EntityValidationErrors.ToString());
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