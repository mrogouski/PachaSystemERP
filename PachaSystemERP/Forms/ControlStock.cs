﻿// <copyright file="ControlStock.cs" company="Pacha System">
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
        private BindingSource _articuloBindingSource;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;
        private ErrorProvider _errorProvider;
        private CueText _cueText;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ControlDeStock"/>.
        /// </summary>
        public ControlDeStock()
        {
            InitializeComponent();
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
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
            _context.TipoCondicionIva.Load();
            _context.TipoTributo.Load();
            _context.CategoriaProducto.Load();

            _articuloBindingSource = new BindingSource();
            var ivaBindingSource = new BindingSource();
            var tributoBindingSource = new BindingSource();
            var categoriaBindingSource = new BindingSource();

            _articuloBindingSource.DataSource = _context.Producto.Local.ToBindingList();

            DgvArticulos.DataSource = _articuloBindingSource;
            DgvArticulos.Columns["ID"].Visible = false;
            DgvArticulos.Columns["CategoriaProductoID"].Visible = false;
            DgvArticulos.Columns["TipoCondicionIvaID"].Visible = false;
            DgvArticulos.Columns["TipoTributoID"].Visible = false;
            DgvArticulos.Columns["FechaBaja"].Visible = false;
            DgvArticulos.Columns["CategoriaProducto"].Visible = false;
            DgvArticulos.Columns["TipoCondicionIva"].Visible = false;
            DgvArticulos.Columns["TipoTributo"].Visible = false;
            DgvArticulos.Columns["DetalleComprobante"].Visible = false;

            DataGridViewComboBoxColumn columnIva = new DataGridViewComboBoxColumn();
            columnIva.DataPropertyName = "TipoCondicionIvaID";
            columnIva.Name = "Alicuota IVA";
            columnIva.DataSource = _context.TipoCondicionIva.Local.ToBindingList();
            columnIva.DisplayMember = "Descripcion";
            columnIva.ValueMember = "ID";
            DgvArticulos.Columns.Add(columnIva);

            DataGridViewComboBoxColumn columnTributo = new DataGridViewComboBoxColumn();
            columnTributo.DataPropertyName = "TipoTributoID";
            columnTributo.Name = "Tributo";
            columnTributo.DataSource = _context.TipoTributo.Local.ToBindingList();
            //query.Insert(0, new SistemaDeFacturacion.TipoDocumento { Id = 0, Descripcion = "SELECCIONAR" });
            columnTributo.DisplayMember = "Descripcion";
            columnTributo.ValueMember = "ID";
            DgvArticulos.Columns.Add(columnTributo);

            DataGridViewComboBoxColumn columnCategoria = new DataGridViewComboBoxColumn();
            columnCategoria.DataPropertyName = "CategoriaProductoID";
            columnCategoria.Name = "Categoria";
            columnCategoria.DataSource = _context.CategoriaProducto.Local.ToBindingList();
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
                _articuloBindingSource.ResetBindings(false);
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