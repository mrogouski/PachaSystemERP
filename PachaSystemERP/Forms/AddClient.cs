// <copyright file="ManejoClientes.cs" company="Pacha System">
// Copyright (c) Pacha System. All rights reserved.
// </copyright>

namespace PachaSystemERP.Forms
{
    using PachaSystem.Data;
    using PachaSystem.Data.Helpers;
    using PachaSystem.Data.Models;
    using System;
    using System.Windows.Forms;

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
            DgvCustomers.DataSource = _unitOfWork.Clients.GetAll();

            CbDocumentType.DataSource = _unitOfWork.DocumentTypes.GetAll();
            CbDocumentType.ValueMember = "Id";
            CbDocumentType.DisplayMember = "Descripcion";
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidateEntry())
            {
                Customer customer = new Customer();
                customer.BusinessName = TxtBusinessName.Text;
                customer.DocumentTypeID = (int)CbDocumentType.SelectedValue;
                customer.DocumentNumber = long.Parse(TxtDocumentNumber.Text);
                customer.FiscalConditionTypeID = (int)CbFiscalCondition.SelectedValue;
                customer.Address = TxtAddress.Text;
                _unitOfWork.Clients.Add(customer);
                _unitOfWork.SaveChanges();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidateEntry()
        {
            if (string.IsNullOrWhiteSpace(TxtBusinessName.Text))
            {
                errorProvider.SetError(TxtBusinessName, "Este campo no debe estar vacío");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtDocumentNumber.Text))
            {
                errorProvider.SetError(TxtDocumentNumber, "Este campo no debe estar vacío");
                return false;
            }
            if (string.IsNullOrWhiteSpace(TxtAddress.Text))
            {
                errorProvider.SetError(TxtAddress, "Este campo no debe estar vacío");
                return false;
            }
            if (CbDocumentType.SelectedValue.Equals(99))
            {
                errorProvider.SetError(CbDocumentType, "El valor ingresado es incorrecto");
                return false;
            }
            if (CbFiscalCondition.SelectedValue.Equals(5))
            {
                errorProvider.SetError(CbFiscalCondition, "El valor ingresado es incorrecto");
                return false;
            }
            else
            {
                errorProvider.Clear();
                return true;
            }
        }
    }
}