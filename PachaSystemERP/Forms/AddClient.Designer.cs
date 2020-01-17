namespace PachaSystemERP.Forms
{
    partial class AddClient
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAccept = new System.Windows.Forms.Button();
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CbFiscalCondition = new System.Windows.Forms.ComboBox();
            this.TxtDocumentNumber = new System.Windows.Forms.TextBox();
            this.CbDocumentType = new System.Windows.Forms.ComboBox();
            this.TxtBusinessName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvCustomers = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.BtnNewCustomer = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.BtnCancel, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.BtnAccept, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.TxtAddress, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.CbFiscalCondition, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.TxtDocumentNumber, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.CbDocumentType, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.TxtBusinessName, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.DgvCustomers, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtnNewCustomer, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 440);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(588, 382);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnAccept
            // 
            this.BtnAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnAccept.Location = new System.Drawing.Point(184, 382);
            this.BtnAccept.Name = "BtnAccept";
            this.BtnAccept.Size = new System.Drawing.Size(75, 23);
            this.BtnAccept.TabIndex = 5;
            this.BtnAccept.Text = "Aceptar";
            this.BtnAccept.UseVisualStyleBackColor = true;
            this.BtnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // TxtAddress
            // 
            this.TxtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAddress.Location = new System.Drawing.Point(427, 340);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(398, 20);
            this.TxtAddress.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(398, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Domicilio";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CbFiscalCondition
            // 
            this.CbFiscalCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CbFiscalCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFiscalCondition.FormattingEnabled = true;
            this.CbFiscalCondition.Location = new System.Drawing.Point(427, 295);
            this.CbFiscalCondition.Name = "CbFiscalCondition";
            this.CbFiscalCondition.Size = new System.Drawing.Size(398, 21);
            this.CbFiscalCondition.TabIndex = 13;
            // 
            // TxtDocumentNumber
            // 
            this.TxtDocumentNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDocumentNumber.Location = new System.Drawing.Point(427, 252);
            this.TxtDocumentNumber.Name = "TxtDocumentNumber";
            this.TxtDocumentNumber.Size = new System.Drawing.Size(398, 20);
            this.TxtDocumentNumber.TabIndex = 20;
            // 
            // CbDocumentType
            // 
            this.CbDocumentType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CbDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbDocumentType.FormattingEnabled = true;
            this.CbDocumentType.Location = new System.Drawing.Point(427, 207);
            this.CbDocumentType.Name = "CbDocumentType";
            this.CbDocumentType.Size = new System.Drawing.Size(398, 21);
            this.CbDocumentType.TabIndex = 12;
            // 
            // TxtBusinessName
            // 
            this.TxtBusinessName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBusinessName.Location = new System.Drawing.Point(427, 164);
            this.TxtBusinessName.Name = "TxtBusinessName";
            this.TxtBusinessName.Size = new System.Drawing.Size(398, 20);
            this.TxtBusinessName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(398, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Responsabilidad IVA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DgvCustomers
            // 
            this.DgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.DgvCustomers, 2);
            this.DgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCustomers.Location = new System.Drawing.Point(23, 67);
            this.DgvCustomers.Name = "DgvCustomers";
            this.DgvCustomers.ReadOnly = true;
            this.DgvCustomers.Size = new System.Drawing.Size(802, 38);
            this.DgvCustomers.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(398, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo de Documento";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre y Apellido / Razón Social";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(398, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Número de Documento";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BtnNewCustomer
            // 
            this.BtnNewCustomer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnNewCustomer.Location = new System.Drawing.Point(588, 30);
            this.BtnNewCustomer.Name = "BtnNewCustomer";
            this.BtnNewCustomer.Size = new System.Drawing.Size(75, 23);
            this.BtnNewCustomer.TabIndex = 22;
            this.BtnNewCustomer.Text = "Nuevo Cliente";
            this.BtnNewCustomer.UseVisualStyleBackColor = true;
            // 
            // AddClient
            // 
            this.AcceptButton = this.BtnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(849, 440);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddClient";
            this.ShowIcon = false;
            this.Text = "Agregar Nuevo Cliente";
            this.Load += new System.EventHandler(this.AddNewClient_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnAccept;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TextBox TxtBusinessName;
        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.ComboBox CbDocumentType;
        private System.Windows.Forms.ComboBox CbFiscalCondition;
        private System.Windows.Forms.TextBox TxtDocumentNumber;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridView DgvCustomers;
        private System.Windows.Forms.Button BtnNewCustomer;
    }
}