// <copyright file="ControlTributos.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.Entity;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using PachaSystem.Data;

    public partial class TributeManagement : Form
    {
        private PachaSystemContext _context;

        public TributeManagement()
        {
            InitializeComponent();
            _context = new PachaSystemContext();
            _context.Tributes.Load();
            _context.TributeCategories.Load();
        }

        private void TributeManagement_Load(object sender, EventArgs e)
        {
            var tributoBindingSource = new BindingSource();
            var categoriaBindingSource = new BindingSource();

            tributoBindingSource.DataSource = _context.Tributes.Local.ToBindingList();

            categoriaBindingSource.DataSource = tributoBindingSource;
            categoriaBindingSource.DataMember = "TributeCategoryID";

            dgvTributo.DataSource = tributoBindingSource;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.DataPropertyName = "TributeCategoryID";
            column.Name = "Categoría de Tributo";
            column.DataSource = _context.TributeCategories.Local.ToBindingList();
            column.DisplayMember = "Description";
            column.ValueMember = "ID";
            dgvTributo.Columns.Add(column);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
        }

        private void dgvTributo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Cancel && e.Context != DataGridViewDataErrorContexts.Commit)
            {
                ErrorProvider errorProvider = new ErrorProvider();
                errorProvider.SetError(dgvTributo, e.Exception.Message);
            }
        }
    }
}
