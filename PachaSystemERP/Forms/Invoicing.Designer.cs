namespace PachaSystemERP.Forms
{
    partial class Invoicing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GbItemDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtProductCode = new System.Windows.Forms.TextBox();
            this.TxtProductDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvItems = new System.Windows.Forms.DataGridView();
            this.NudProductQuantity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.NudUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.NudSubtotal = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnCancelItem = new System.Windows.Forms.Button();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.BtnCancelInvoice = new System.Windows.Forms.Button();
            this.BtnGenerateInvoice = new System.Windows.Forms.Button();
            this.GbInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.LblInvoiceType = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCantidadArticulos = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LblReceiptNumber = new System.Windows.Forms.Label();
            this.GbCustomer = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtCustomerCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtCustomerName = new System.Windows.Forms.TextBox();
            this.BtnSelectCustomer = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.GbItemDetails.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudProductQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSubtotal)).BeginInit();
            this.GbInvoiceDetails.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.GbCustomer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.GbItemDetails, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtnCancelInvoice, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnGenerateInvoice, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.GbInvoiceDetails, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.GbCustomer, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // GbItemDetails
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.GbItemDetails, 4);
            this.GbItemDetails.Controls.Add(this.tableLayoutPanel2);
            this.GbItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbItemDetails.Location = new System.Drawing.Point(23, 123);
            this.GbItemDetails.Name = "GbItemDetails";
            this.GbItemDetails.Size = new System.Drawing.Size(738, 285);
            this.GbItemDetails.TabIndex = 6;
            this.GbItemDetails.TabStop = false;
            this.GbItemDetails.Text = "Detalle de Articulos";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtProductCode, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtProductDescription, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.DgvItems, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.NudProductQuantity, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.NudUnitPrice, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.NudSubtotal, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancelItem, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.BtnAddItem, 1, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(732, 266);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtItemCode
            // 
            this.TxtProductCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtProductCode.Location = new System.Drawing.Point(585, 12);
            this.TxtProductCode.Name = "TxtItemCode";
            this.TxtProductCode.Size = new System.Drawing.Size(144, 20);
            this.TxtProductCode.TabIndex = 15;
            this.TxtProductCode.TextChanged += new System.EventHandler(this.TxtItemCode_TextChanged);
            // 
            // TxtItemName
            // 
            this.TxtProductDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtProductDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtProductDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtProductDescription.Location = new System.Drawing.Point(585, 56);
            this.TxtProductDescription.Name = "TxtItemName";
            this.TxtProductDescription.Size = new System.Drawing.Size(144, 20);
            this.TxtProductDescription.TabIndex = 5;
            this.TxtProductDescription.TextChanged += new System.EventHandler(this.TxtItemName_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Descripción";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DgvArticles
            // 
            this.DgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvItems.Location = new System.Drawing.Point(3, 3);
            this.DgvItems.Name = "DgvArticles";
            this.DgvItems.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.DgvItems, 6);
            this.DgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvItems.Size = new System.Drawing.Size(426, 260);
            this.DgvItems.TabIndex = 2;
            // 
            // NudQuantity
            // 
            this.NudProductQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudProductQuantity.Location = new System.Drawing.Point(585, 100);
            this.NudProductQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudProductQuantity.Name = "NudQuantity";
            this.NudProductQuantity.Size = new System.Drawing.Size(144, 20);
            this.NudProductQuantity.TabIndex = 10;
            this.NudProductQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudProductQuantity.ValueChanged += new System.EventHandler(this.NudQuantity_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudUnitPrice
            // 
            this.NudUnitPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudUnitPrice.DecimalPlaces = 2;
            this.NudUnitPrice.Enabled = false;
            this.NudUnitPrice.Location = new System.Drawing.Point(585, 144);
            this.NudUnitPrice.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NudUnitPrice.Name = "NudUnitPrice";
            this.NudUnitPrice.Size = new System.Drawing.Size(144, 20);
            this.NudUnitPrice.TabIndex = 11;
            this.NudUnitPrice.ValueChanged += new System.EventHandler(this.NudUnitPrice_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Precio Unitario";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudSubtotal
            // 
            this.NudSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudSubtotal.DecimalPlaces = 2;
            this.NudSubtotal.Enabled = false;
            this.NudSubtotal.Location = new System.Drawing.Point(585, 188);
            this.NudSubtotal.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NudSubtotal.Name = "NudSubtotal";
            this.NudSubtotal.Size = new System.Drawing.Size(144, 20);
            this.NudSubtotal.TabIndex = 12;
            this.NudSubtotal.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Subtotal";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnCancelItem
            // 
            this.BtnCancelItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCancelItem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelItem.Location = new System.Drawing.Point(619, 231);
            this.BtnCancelItem.Name = "BtnCancelItem";
            this.BtnCancelItem.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelItem.TabIndex = 16;
            this.BtnCancelItem.Text = "Cancelar";
            this.BtnCancelItem.UseVisualStyleBackColor = true;
            this.BtnCancelItem.Click += new System.EventHandler(this.BtnCancelItem_Click);
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAddItem.Location = new System.Drawing.Point(469, 231);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(75, 23);
            this.BtnAddItem.TabIndex = 14;
            this.BtnAddItem.Text = "Agregar";
            this.BtnAddItem.UseVisualStyleBackColor = true;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // BtnCancelInvoice
            // 
            this.BtnCancelInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCancelInvoice.Location = new System.Drawing.Point(633, 514);
            this.BtnCancelInvoice.Name = "BtnCancelInvoice";
            this.BtnCancelInvoice.Size = new System.Drawing.Size(75, 23);
            this.BtnCancelInvoice.TabIndex = 8;
            this.BtnCancelInvoice.Text = "Cancelar";
            this.BtnCancelInvoice.UseVisualStyleBackColor = true;
            this.BtnCancelInvoice.Click += new System.EventHandler(this.BtnCancelInvoice_Click);
            // 
            // BtnGenerateInvoice
            // 
            this.BtnGenerateInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGenerateInvoice.Location = new System.Drawing.Point(447, 514);
            this.BtnGenerateInvoice.Name = "BtnGenerateInvoice";
            this.BtnGenerateInvoice.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerateInvoice.TabIndex = 1;
            this.BtnGenerateInvoice.Text = "Emitir";
            this.BtnGenerateInvoice.UseVisualStyleBackColor = true;
            this.BtnGenerateInvoice.Click += new System.EventHandler(this.BtnGenerateInvoice_Click);
            // 
            // GbInvoiceDetails
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.GbInvoiceDetails, 4);
            this.GbInvoiceDetails.Controls.Add(this.tableLayoutPanel4);
            this.GbInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbInvoiceDetails.Location = new System.Drawing.Point(23, 414);
            this.GbInvoiceDetails.Name = "GbInvoiceDetails";
            this.GbInvoiceDetails.Size = new System.Drawing.Size(738, 94);
            this.GbInvoiceDetails.TabIndex = 13;
            this.GbInvoiceDetails.TabStop = false;
            this.GbInvoiceDetails.Text = "Detalle de Comprobante";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.LblInvoiceType, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblTotal, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblCantidadArticulos, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.LblReceiptNumber, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(732, 75);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tipo de Comprobante:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblInvoiceType
            // 
            this.LblInvoiceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblInvoiceType.AutoSize = true;
            this.LblInvoiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInvoiceType.Location = new System.Drawing.Point(186, 12);
            this.LblInvoiceType.Name = "LblInvoiceType";
            this.LblInvoiceType.Size = new System.Drawing.Size(177, 13);
            this.LblInvoiceType.TabIndex = 1;
            this.LblInvoiceType.Text = "[InvoiceType]";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(369, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(177, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Numero de Comprobante:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(552, 49);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(177, 13);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "[TotalAmount]";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(369, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Total:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCantidadArticulos
            // 
            this.lblCantidadArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadArticulos.AutoSize = true;
            this.lblCantidadArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadArticulos.Location = new System.Drawing.Point(186, 49);
            this.lblCantidadArticulos.Name = "lblCantidadArticulos";
            this.lblCantidadArticulos.Size = new System.Drawing.Size(177, 13);
            this.lblCantidadArticulos.TabIndex = 10;
            this.lblCantidadArticulos.Text = "[TotalItemQuantity]";
            this.lblCantidadArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cantidad de Articulos:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblReceiptNumber
            // 
            this.LblReceiptNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblReceiptNumber.AutoSize = true;
            this.LblReceiptNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReceiptNumber.Location = new System.Drawing.Point(552, 12);
            this.LblReceiptNumber.Name = "LblReceiptNumber";
            this.LblReceiptNumber.Size = new System.Drawing.Size(177, 13);
            this.LblReceiptNumber.TabIndex = 3;
            this.LblReceiptNumber.Text = "[InvoiceNumber]";
            // 
            // GbCustomer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.GbCustomer, 4);
            this.GbCustomer.Controls.Add(this.tableLayoutPanel3);
            this.GbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbCustomer.Location = new System.Drawing.Point(23, 23);
            this.GbCustomer.Name = "GbCustomer";
            this.GbCustomer.Size = new System.Drawing.Size(738, 94);
            this.GbCustomer.TabIndex = 14;
            this.GbCustomer.TabStop = false;
            this.GbCustomer.Text = "Cliente";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TxtCustomerCode, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.TxtCustomerName, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.BtnSelectCustomer, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(732, 75);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtCustomerCode
            // 
            this.TxtCustomerCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCustomerCode.Location = new System.Drawing.Point(186, 8);
            this.TxtCustomerCode.Name = "TxtCustomerCode";
            this.TxtCustomerCode.Size = new System.Drawing.Size(177, 20);
            this.TxtCustomerCode.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(369, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nombre y Apellido / Razón Social";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtCustomerName
            // 
            this.TxtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCustomerName.Location = new System.Drawing.Point(552, 8);
            this.TxtCustomerName.Name = "TxtCustomerName";
            this.TxtCustomerName.Size = new System.Drawing.Size(177, 20);
            this.TxtCustomerName.TabIndex = 3;
            // 
            // BtnSelectCustomer
            // 
            this.BtnSelectCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSelectCustomer.Location = new System.Drawing.Point(54, 44);
            this.BtnSelectCustomer.Name = "BtnSelectCustomer";
            this.BtnSelectCustomer.Size = new System.Drawing.Size(75, 23);
            this.BtnSelectCustomer.TabIndex = 4;
            this.BtnSelectCustomer.Text = "Seleccionar";
            this.BtnSelectCustomer.UseVisualStyleBackColor = true;
            this.BtnSelectCustomer.Click += new System.EventHandler(this.BtnSelectCustomer_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FacturaB
            // 
            this.AcceptButton = this.BtnAddItem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancelItem;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FacturaB";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuFacturacion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.GbItemDetails.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudProductQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSubtotal)).EndInit();
            this.GbInvoiceDetails.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.GbCustomer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DgvItems;
        private System.Windows.Forms.GroupBox GbItemDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtProductDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudProductQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NudUnitPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NudSubtotal;
        private System.Windows.Forms.TextBox TxtProductCode;
        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.Button BtnCancelItem;
        private System.Windows.Forms.Button BtnGenerateInvoice;
        private System.Windows.Forms.Button BtnCancelInvoice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCantidadArticulos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox GbInvoiceDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LblInvoiceType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label LblReceiptNumber;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.GroupBox GbCustomer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtCustomerCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtCustomerName;
        private System.Windows.Forms.Button BtnSelectCustomer;
    }
}

