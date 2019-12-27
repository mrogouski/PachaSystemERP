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
            this.gbDetalleDeArticulo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DgvArticles = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NudPrecioUnitario = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.NudSubtotal = new System.Windows.Forms.NumericUpDown();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbDatosDelCliente = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumeroDeDocumento = new System.Windows.Forms.TextBox();
            this.cbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbTipoResponsabilidadCliente = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.btnCancelarComprobante = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
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
            this.gbDetalleDeArticulo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPrecioUnitario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSubtotal)).BeginInit();
            this.gbDatosDelCliente.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.gbDetalleDeArticulo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.gbDatosDelCliente, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelarComprobante, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnFacturar, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCantidadArticulos, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label12, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTotal, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.gbDetalleDeComprobante, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // gbDetalleDeArticulo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbDetalleDeArticulo, 4);
            this.gbDetalleDeArticulo.Controls.Add(this.tableLayoutPanel2);
            this.gbDetalleDeArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetalleDeArticulo.Location = new System.Drawing.Point(23, 203);
            this.gbDetalleDeArticulo.Name = "gbDetalleDeArticulo";
            this.gbDetalleDeArticulo.Size = new System.Drawing.Size(738, 265);
            this.gbDetalleDeArticulo.TabIndex = 6;
            this.gbDetalleDeArticulo.TabStop = false;
            this.gbDetalleDeArticulo.Text = "Detalle de Articulos";
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
            this.tableLayoutPanel2.Controls.Add(this.txtDescripcion, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.NudCantidad, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.NudPrecioUnitario, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.NudSubtotal, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCodigo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAceptar, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 5, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(732, 246);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvArticulos
            // 
            this.DgvArticles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel2.SetColumnSpan(this.DgvArticles, 6);
            this.DgvArticles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvArticles.Location = new System.Drawing.Point(3, 73);
            this.DgvArticles.Name = "dgvArticulos";
            this.DgvArticles.ReadOnly = true;
            this.DgvArticles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvArticles.Size = new System.Drawing.Size(726, 170);
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
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDescripcion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDescripcion.Location = new System.Drawing.Point(366, 7);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(115, 20);
            this.txtDescripcion.TabIndex = 5;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
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
            // NudCantidad
            // 
            this.NudCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudCantidad.Location = new System.Drawing.Point(608, 7);
            this.NudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudCantidad.Name = "NudCantidad";
            this.NudCantidad.Size = new System.Drawing.Size(121, 20);
            this.NudCantidad.TabIndex = 10;
            this.NudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudCantidad.ValueChanged += new System.EventHandler(this.NudCantidad_ValueChanged);
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
            // NudPrecioUnitario
            // 
            this.NudPrecioUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudPrecioUnitario.DecimalPlaces = 2;
            this.NudPrecioUnitario.Enabled = false;
            this.NudPrecioUnitario.Location = new System.Drawing.Point(124, 42);
            this.NudPrecioUnitario.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NudPrecioUnitario.Name = "NudPrecioUnitario";
            this.NudPrecioUnitario.Size = new System.Drawing.Size(115, 20);
            this.NudPrecioUnitario.TabIndex = 11;
            this.NudPrecioUnitario.ValueChanged += new System.EventHandler(this.NudPrecioUnitario_ValueChanged);
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
            10000,
            0,
            0,
            0});
            this.NudSubtotal.Name = "NudSubtotal";
            this.NudSubtotal.Size = new System.Drawing.Size(115, 20);
            this.NudSubtotal.TabIndex = 12;
            this.NudSubtotal.ThousandsSeparator = true;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigo.Location = new System.Drawing.Point(124, 7);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(115, 20);
            this.txtCodigo.TabIndex = 15;
            this.txtCodigo.TextChanged += new System.EventHandler(this.TxtCodigo_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptar.Location = new System.Drawing.Point(510, 41);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(68, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(631, 41);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // gbDatosDelCliente
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbDatosDelCliente, 4);
            this.gbDatosDelCliente.Controls.Add(this.tableLayoutPanel3);
            this.gbDatosDelCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDatosDelCliente.Location = new System.Drawing.Point(23, 113);
            this.gbDatosDelCliente.Name = "gbDatosDelCliente";
            this.gbDatosDelCliente.Size = new System.Drawing.Size(738, 84);
            this.gbDatosDelCliente.TabIndex = 7;
            this.gbDatosDelCliente.TabStop = false;
            this.gbDatosDelCliente.Text = "Datos del Cliente";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtRazonSocial, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtNumeroDeDocumento, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.cbTipoDocumento, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbTipoResponsabilidadCliente, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label15, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtDomicilio, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(732, 65);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre o Razon Social";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRazonSocial.Location = new System.Drawing.Point(124, 6);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(115, 20);
            this.txtRazonSocial.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 26);
            this.label8.TabIndex = 9;
            this.label8.Text = "Numero de Documento";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumeroDeDocumento
            // 
            this.txtNumeroDeDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroDeDocumento.Location = new System.Drawing.Point(124, 38);
            this.txtNumeroDeDocumento.Name = "txtNumeroDeDocumento";
            this.txtNumeroDeDocumento.Size = new System.Drawing.Size(115, 20);
            this.txtNumeroDeDocumento.TabIndex = 13;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDocumento.FormattingEnabled = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(608, 5);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this.cbTipoDocumento.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tipo de Documento";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(245, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Tipo de Responsable";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTipoResponsabilidadCliente
            // 
            this.cbTipoResponsabilidadCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTipoResponsabilidadCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoResponsabilidadCliente.FormattingEnabled = true;
            this.cbTipoResponsabilidadCliente.Location = new System.Drawing.Point(366, 5);
            this.cbTipoResponsabilidadCliente.Name = "cbTipoResponsabilidadCliente";
            this.cbTipoResponsabilidadCliente.Size = new System.Drawing.Size(115, 21);
            this.cbTipoResponsabilidadCliente.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(245, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 13);
            this.label15.TabIndex = 16;
            this.label15.Text = "Domicilio";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.txtDomicilio, 3);
            this.txtDomicilio.Location = new System.Drawing.Point(366, 38);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(363, 20);
            this.txtDomicilio.TabIndex = 17;
            // 
            // btnCancelarComprobante
            // 
            this.btnCancelarComprobante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancelarComprobante, 2);
            this.btnCancelarComprobante.Location = new System.Drawing.Point(540, 512);
            this.btnCancelarComprobante.Name = "btnCancelarComprobante";
            this.btnCancelarComprobante.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarComprobante.TabIndex = 8;
            this.btnCancelarComprobante.Text = "Cancelar";
            this.btnCancelarComprobante.UseVisualStyleBackColor = true;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnFacturar, 2);
            this.btnFacturar.Location = new System.Drawing.Point(168, 512);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 1;
            this.btnFacturar.Text = "Generar Comprobante";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.BtnFacturar_Click);
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
            this.lblCantidadArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCantidadArticulos.AutoSize = true;
            this.lblCantidadArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadArticulos.Location = new System.Drawing.Point(209, 471);
            this.lblCantidadArticulos.Name = "lblCantidadArticulos";
            this.lblCantidadArticulos.Size = new System.Drawing.Size(180, 35);
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
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(581, 471);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(180, 35);
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
            // lblNumeroComprobante
            // 
            this.LblReceiptNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblReceiptNumber.AutoSize = true;
            this.LblReceiptNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReceiptNumber.Location = new System.Drawing.Point(552, 26);
            this.LblReceiptNumber.Name = "lblNumeroComprobante";
            this.LblReceiptNumber.Size = new System.Drawing.Size(177, 13);
            this.LblReceiptNumber.TabIndex = 3;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FacturaB
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FacturaB";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuFacturacion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbDetalleDeArticulo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudPrecioUnitario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSubtotal)).EndInit();
            this.gbDatosDelCliente.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbDetalleDeArticulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NudPrecioUnitario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NudSubtotal;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox gbDatosDelCliente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNumeroDeDocumento;
        private System.Windows.Forms.ComboBox cbTipoDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbTipoResponsabilidadCliente;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnCancelarComprobante;
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
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}

