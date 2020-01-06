// <copyright file="ManejoClientes.cs" company="Pacha System">
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
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using PachaSystemERP.Classes;
    using PachaSystemERP.Enums;

    public partial class AddClient : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AddClient"/>.
        /// </summary>
        public AddClient()
        {
            InitializeComponent();
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        private void AddNewClient_Load(object sender, EventArgs e)
        {
            cbTipoDeDocumento.DataSource = _unitOfWork.TipoDocumento.GetAll();
            cbTipoDeDocumento.ValueMember = "Id";
            cbTipoDeDocumento.DisplayMember = "Descripcion";
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            _unitOfWork.SaveChanges();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
