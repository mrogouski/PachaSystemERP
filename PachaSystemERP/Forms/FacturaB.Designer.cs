namespace PachaSystemERP.Forms
{
    partial class FacturaB
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
            this.DgvArticles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NudUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.NudSubtotal = new System.Windows.Forms.NumericUpDown();
            this.TxtItemCode = new System.Windows.Forms.TextBox();
            this.BtnAddItem = new System.Windows.Forms.Button();
            this.BtnCancelItem = new System.Windows.Forms.Button();
            this.BtnCancelInvoice = new System.Windows.Forms.Button();
            this.BtnGenerateInvoice = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCantidadArticulos = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gbDetalleDeComprobante = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.LblReceiptNumber = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.GbItemDetails.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSubtotal)).BeginInit();
            this.gbDetalleDeComprobante.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.BtnCancelInvoice, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.BtnGenerateInvoice, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCantidadArticulos, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTotal, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.gbDetalleDeComprobante, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // GbItemDetails
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.GbItemDetails, 4);
            this.GbItemDetails.Controls.Add(this.tableLayoutPanel2);
            this.GbItemDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbItemDetails.Location = new System.Drawing.Point(23, 113);
            this.GbItemDetails.Name = "GbItemDetails";
            this.GbItemDetails.Size = new System.Drawing.Size(738, 355);
            this.GbItemDetails.TabIndex = 6;
            this.GbItemDetails.TabStop = false;
            this.GbItemDetails.Text = "Detalle de Articulos";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.DgvArticles, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.TxtItemName, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.NudQuantity, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.NudUnitPrice, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.NudSubtotal, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.TxtItemCode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnAddItem, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancelItem, 5, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(732, 336);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // DgvArticles
            // 
            this.DgvArticles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel2.SetColumnSpan(this.DgvArticles, 6);
            this.DgvArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvArticles.Location = new System.Drawing.Point(3, 73);
            this.DgvArticles.Name = "DgvArticles";
            this.DgvArticles.ReadOnly = true;
            this.DgvArticles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvArticles.Size = new System.Drawing.Size(726, 260);
            this.DgvArticles.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Código";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TxtItemName
            // 
            this.TxtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.TxtItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TxtItemName.Location = new System.Drawing.Point(366, 7);
            this.TxtItemName.Name = "TxtItemName";
            this.TxtItemName.Size = new System.Drawing.Size(115, 20);
            this.TxtItemName.TabIndex = 5;
            this.TxtItemName.TextChanged += new System.EventHandler(this.TxtItemName_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Descripción";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudQuantity
            // 
            this.NudQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudQuantity.Location = new System.Drawing.Point(608, 7);
            this.NudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudQuantity.Name = "NudQuantity";
            this.NudQuantity.Size = new System.Drawing.Size(121, 20);
            this.NudQuantity.TabIndex = 10;
            this.NudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudQuantity.ValueChanged += new System.EventHandler(this.NudQuantity_ValueChanged);
            this.NudQuantity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudQuantity_KeyDown);
            this.NudQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NudQuantity_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Precio Unitario";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudUnitPrice
            // 
            this.NudUnitPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudUnitPrice.DecimalPlaces = 2;
            this.NudUnitPrice.Enabled = false;
            this.NudUnitPrice.Location = new System.Drawing.Point(124, 42);
            this.NudUnitPrice.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NudUnitPrice.Name = "NudUnitPrice";
            this.NudUnitPrice.Size = new System.Drawing.Size(115, 20);
            this.NudUnitPrice.TabIndex = 11;
            this.NudUnitPrice.ValueChanged += new System.EventHandler(this.NudUnitPrice_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(245, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Subtotal";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NudSubtotal
            // 
            this.NudSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudSubtotal.DecimalPlaces = 2;
            this.NudSubtotal.Enabled = false;
            this.NudSubtotal.Location = new System.Drawing.Point(366, 42);
            this.NudSubtotal.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.NudSubtotal.Name = "NudSubtotal";
            this.NudSubtotal.Size = new System.Drawing.Size(115, 20);
            this.NudSubtotal.TabIndex = 12;
            this.NudSubtotal.ThousandsSeparator = true;
            // 
            // TxtItemCode
            // 
            this.TxtItemCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtItemCode.Location = new System.Drawing.Point(124, 7);
            this.TxtItemCode.Name = "TxtItemCode";
            this.TxtItemCode.Size = new System.Drawing.Size(115, 20);
            this.TxtItemCode.TabIndex = 15;
            this.TxtItemCode.TextChanged += new System.EventHandler(this.TxtItemCode_TextChanged);
            // 
            // BtnAddItem
            // 
            this.BtnAddItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAddItem.Location = new System.Drawing.Point(510, 41);
            this.BtnAddItem.Name = "BtnAddItem";
            this.BtnAddItem.Size = new System.Drawing.Size(68, 23);
            this.BtnAddItem.TabIndex = 14;
            this.BtnAddItem.Text = "Agregar";
            this.BtnAddItem.UseVisualStyleBackColor = true;
            this.BtnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // BtnCancelItem
            // 
            this.BtnCancelItem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCancelItem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancelItem.Location = new System.Drawing.Point(631, 41);
            this.BtnCancelItem.Name = "BtnCancelItem";
            this.BtnCancelItem.Size = new System.Drawing.Size(74, 23);
            this.BtnCancelItem.TabIndex = 16;
            this.BtnCancelItem.Text = "Cancelar";
            this.BtnCancelItem.UseVisualStyleBackColor = true;
            this.BtnCancelItem.Click += new System.EventHandler(this.BtnCancelItem_Click);
            // 
            // BtnCancelInvoice
            // 
            this.BtnCancelInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.BtnCancelInvoice, 2);
            this.BtnCancelInvoice.Location = new System.Drawing.Point(540, 512);
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
            this.tableLayoutPanel1.SetColumnSpan(this.BtnGenerateInvoice, 2);
            this.BtnGenerateInvoice.Location = new System.Drawing.Point(140, 512);
            this.BtnGenerateInvoice.Name = "BtnGenerateInvoice";
            this.BtnGenerateInvoice.Size = new System.Drawing.Size(132, 23);
            this.BtnGenerateInvoice.TabIndex = 1;
            this.BtnGenerateInvoice.Text = "Generar Comprobante";
            this.BtnGenerateInvoice.UseVisualStyleBackColor = true;
            this.BtnGenerateInvoice.Click += new System.EventHandler(this.BtnGenerateInvoice_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 482);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(180, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Cantidad de Articulos:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCantidadArticulos
            // 
            this.lblCantidadArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadArticulos.AutoSize = true;
            this.lblCantidadArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadArticulos.Location = new System.Drawing.Point(209, 476);
            this.lblCantidadArticulos.Name = "lblCantidadArticulos";
            this.lblCantidadArticulos.Size = new System.Drawing.Size(180, 24);
            this.lblCantidadArticulos.TabIndex = 10;
            this.lblCantidadArticulos.Text = "0";
            this.lblCantidadArticulos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(395, 482);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(180, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Total:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(581, 476);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(180, 24);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "$ 0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbDetalleDeComprobante
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbDetalleDeComprobante, 4);
            this.gbDetalleDeComprobante.Controls.Add(this.tableLayoutPanel4);
            this.gbDetalleDeComprobante.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetalleDeComprobante.Location = new System.Drawing.Point(23, 23);
            this.gbDetalleDeComprobante.Name = "gbDetalleDeComprobante";
            this.gbDetalleDeComprobante.Size = new System.Drawing.Size(738, 84);
            this.gbDetalleDeComprobante.TabIndex = 13;
            this.gbDetalleDeComprobante.TabStop = false;
            this.gbDetalleDeComprobante.Text = "Detalle de Comprobante";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label13, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.LblReceiptNumber, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(732, 65);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(177, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tipo de Comprobante";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(186, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Factura B";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(369, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(177, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Numero de Comprobante";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblReceiptNumber
            // 
            this.LblReceiptNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblReceiptNumber.AutoSize = true;
            this.LblReceiptNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReceiptNumber.Location = new System.Drawing.Point(552, 26);
            this.LblReceiptNumber.Name = "LblReceiptNumber";
            this.LblReceiptNumber.Size = new System.Drawing.Size(177, 13);
            this.LblReceiptNumber.TabIndex = 3;
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
            this.tableLayoutPanel1.PerformLayout();
            this.GbItemDetails.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSubtotal)).EndInit();
            this.gbDetalleDeComprobante.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DgvArticles;
        private System.Windows.Forms.GroupBox GbItemDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtItemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NudUnitPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NudSubtotal;
        private System.Windows.Forms.TextBox TxtItemCode;
        private System.Windows.Forms.Button BtnAddItem;
        private System.Windows.Forms.Button BtnCancelItem;
        private System.Windows.Forms.Button BtnGenerateInvoice;
        private System.Windows.Forms.Button BtnCancelInvoice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCantidadArticulos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox gbDetalleDeComprobante;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label LblReceiptNumber;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}

