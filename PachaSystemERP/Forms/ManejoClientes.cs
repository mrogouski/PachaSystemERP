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

    public partial class ManejoDeClientes : Form
    {
        private BindingSource _bindingSource;
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ManejoDeClientes"/>.
        /// </summary>
        public ManejoDeClientes()
        {
            InitializeComponent();
            _bindingSource = new BindingSource();
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        private void ManejoDeClientes_Load(object sender, EventArgs e)
        {
            _bindingSource.DataSource = _unitOfWork.Cliente.ObtenerTodos();

            if (Configuracion.ModoFacturacion == ModoFacturacion.FacturaElectronica)
            {
                cbTipoDeDocumento.DataSource = _unitOfWork.TipoDocumento.ObtenerTodos(x => x.FacturaElectronica == true);
            }

            cbTipoDeDocumento.ValueMember = "Id";
            cbTipoDeDocumento.DisplayMember = "Descripcion";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            _unitOfWork.Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
