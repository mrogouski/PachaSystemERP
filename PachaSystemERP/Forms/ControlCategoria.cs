// <copyright file="ControlCategoria.cs" company="Pacha System">
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

    public partial class ControlDeCategoria : Form
    {
        private PachaSystemContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ControlDeCategoria"/>.
        /// </summary>
        public ControlDeCategoria()
        {
            InitializeComponent();
            _context = new PachaSystemContext();
            _context.ItemCategories.Load();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
        }

        private void ControlDeCategoria_Load(object sender, EventArgs e)
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _context.ItemCategories.Local.ToBindingList();
            dgvCategoria.DataSource = bindingSource;
        }
    }
}
