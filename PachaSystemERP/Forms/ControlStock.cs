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
            _context.Producto.Load();
            _context.Iva.Load();
            _context.Rubro.Load();

            bindingSource= new BindingSource();

            bindingSource.DataSource = _context.Producto.Local.ToBindingList();

            DgvArticulos.DataSource = bindingSource;
            DgvArticulos.Columns["ID"].Visible = false;
            DgvArticulos.Columns["CategoriaProductoID"].Visible = false;
            DgvArticulos.Columns["TipoCondicionIvaID"].Visible = false;
            DgvArticulos.Columns["TipoTributoID"].Visible = false;
            DgvArticulos.Columns["FechaBaja"].Visible = false;
            DgvArticulos.Columns["CategoriaProducto"].Visible = false;
            DgvArticulos.Columns["TipoCondicionIva"].Visible = false;
            DgvArticulos.Columns["DetalleComprobante"].Visible = false;

            DataGridViewComboBoxColumn columnIva = new DataGridViewComboBoxColumn();
            columnIva.DataPropertyName = "TipoCondicionIvaID";
            columnIva.Name = "Alicuota IVA";
            columnIva.DataSource = _context.Iva.Local.ToBindingList();
            columnIva.DisplayMember = "Descripcion";
            columnIva.ValueMember = "ID";
            DgvArticulos.Columns.Add(columnIva);

            DataGridViewComboBoxColumn columnCategoria = new DataGridViewComboBoxColumn();
            columnCategoria.DataPropertyName = "CategoriaProductoID";
            columnCategoria.Name = "Categoria";
            columnCategoria.DataSource = _context.Rubro.Local.ToBindingList();
            columnCategoria.DisplayMember = "Descripcion";
            columnCategoria.ValueMember = "ID";
            DgvArticulos.Columns.Add(columnCategoria);
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
