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

    public partial class ControlDeTributos : Form
    {
        private PachaSystemContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ControlDeTributos"/>.
        /// </summary>
        public ControlDeTributos()
        {
            InitializeComponent();
            _context = new PachaSystemContext();
            _context.TipoTributo.Load();
            _context.CategoriaTributo.Load();
        }

        private void ControlDeTributos_Load(object sender, EventArgs e)
        {
            var tributoBindingSource = new BindingSource();
            var categoriaBindingSource = new BindingSource();

            tributoBindingSource.DataSource = _context.TipoTributo.Local.ToBindingList();

            categoriaBindingSource.DataSource = tributoBindingSource;
            categoriaBindingSource.DataMember = "CategoriaTributoID";

            dgvTributo.DataSource = tributoBindingSource;

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            column.DataPropertyName = "CategoriaTributoID";
            column.Name = "Categoría de Tributo";
            column.DataSource = _context.CategoriaTributo.Local.ToBindingList();
            column.DisplayMember = "Descripcion";
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
