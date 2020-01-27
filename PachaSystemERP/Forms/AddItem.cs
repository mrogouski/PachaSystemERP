using PachaSystem.Data;
using PachaSystem.Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PachaSystemERP.Forms
{
    public partial class AddItem : Form
    {
        private PachaSystemContext _context;
        private UnitOfWork _unitOfWork;

        public AddItem()
        {
            _context = new PachaSystemContext();
            _unitOfWork = new UnitOfWork(_context);
            InitializeComponent();
        }

        private void Initialize()
        {
            CbVat.DataSource = _unitOfWork.Vat.GetAll();
            CbVat.DisplayMember = "Description";
            CbVat.ValueMember = "ID";

            CbMeasureUnit.DataSource = _unitOfWork.MeasureUnit.GetAll();
            CbMeasureUnit.DisplayMember = "Description";
            CbMeasureUnit.ValueMember = "ID";
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            Initialize();
        }
    }
}
