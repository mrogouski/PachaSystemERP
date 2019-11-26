// <copyright file="ControlIva.cs" company="Pacha System">
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

    public partial class ControlDeIva : Form
    {
        private PachaSystemContext _context;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ControlDeIva"/>.
        /// </summary>
        public ControlDeIva()
        {
            InitializeComponent();
        }

        private void ControlDeIva_Load(object sender, EventArgs e)
        {
            _context = new PachaSystemContext();
            _context.Iva.Load();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _context.Iva.Local.ToBindingList();
            dgvIva.DataSource = bindingSource;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
        }
    }
}
