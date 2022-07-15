﻿
namespace QuanLyThuVien
{
    partial class BookForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblID = new System.Windows.Forms.Label();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtAmout = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cbPublisher = new System.Windows.Forms.ComboBox();
            this.lblPublish = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.cbAuthor = new System.Windows.Forms.ComboBox();
            this.lblBookType = new System.Windows.Forms.Label();
            this.cbBookType = new System.Windows.Forms.ComboBox();
            this.dtpPublishDate = new System.Windows.Forms.DateTimePicker();
            this.lblPublishDate = new System.Windows.Forms.Label();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.panelContainer = new System.Windows.Forms.TableLayoutPanel();
            this.PagingNavigation = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblPageIndex = new System.Windows.Forms.Label();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.lblPerpage = new System.Windows.Forms.Label();
            this.childToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.PagingNavigation.SuspendLayout();
            this.childToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(5, 5);
            this.lblID.Margin = new System.Windows.Forms.Padding(5);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(195, 23);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Mã sách";
            // 
            // txtBookID
            // 
            this.txtBookID.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookID.Location = new System.Drawing.Point(5, 38);
            this.txtBookID.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.txtBookID.MaxLength = 5;
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(185, 30);
            this.txtBookID.TabIndex = 1;
            this.txtBookID.Validating += new System.ComponentModel.CancelEventHandler(this.txtBookID_Validating);
            // 
            // txtBookName
            // 
            this.txtBookName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookName.Location = new System.Drawing.Point(210, 38);
            this.txtBookName.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.txtBookName.MaxLength = 100;
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(185, 30);
            this.txtBookName.TabIndex = 2;
            this.txtBookName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBookName_Validating);
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(210, 5);
            this.lblName.Margin = new System.Windows.Forms.Padding(5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(195, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Tên sách";
            // 
            // txtAmout
            // 
            this.txtAmout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmout.Location = new System.Drawing.Point(1235, 38);
            this.txtAmout.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.txtAmout.Name = "txtAmout";
            this.txtAmout.Size = new System.Drawing.Size(199, 30);
            this.txtAmout.TabIndex = 7;
            this.txtAmout.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmout_Validating);
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(1235, 5);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(5);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(209, 23);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Số lượng còn";
            // 
            // cbPublisher
            // 
            this.cbPublisher.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPublisher.FormattingEnabled = true;
            this.cbPublisher.Location = new System.Drawing.Point(415, 38);
            this.cbPublisher.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.cbPublisher.Name = "cbPublisher";
            this.cbPublisher.Size = new System.Drawing.Size(185, 31);
            this.cbPublisher.TabIndex = 3;
            this.cbPublisher.Click += new System.EventHandler(this.cbPublisher_Click);
            // 
            // lblPublish
            // 
            this.lblPublish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublish.AutoSize = true;
            this.lblPublish.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublish.Location = new System.Drawing.Point(415, 5);
            this.lblPublish.Margin = new System.Windows.Forms.Padding(5);
            this.lblPublish.Name = "lblPublish";
            this.lblPublish.Size = new System.Drawing.Size(195, 23);
            this.lblPublish.TabIndex = 7;
            this.lblPublish.Text = "Nhà xuất bản";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(620, 5);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(5);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(195, 23);
            this.lblAuthor.TabIndex = 9;
            this.lblAuthor.Text = "Tác giả";
            // 
            // cbAuthor
            // 
            this.cbAuthor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAuthor.FormattingEnabled = true;
            this.cbAuthor.Location = new System.Drawing.Point(620, 38);
            this.cbAuthor.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(185, 31);
            this.cbAuthor.TabIndex = 4;
            this.cbAuthor.Click += new System.EventHandler(this.cbAuthor_Click);
            // 
            // lblBookType
            // 
            this.lblBookType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBookType.AutoSize = true;
            this.lblBookType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookType.Location = new System.Drawing.Point(825, 5);
            this.lblBookType.Margin = new System.Windows.Forms.Padding(5);
            this.lblBookType.Name = "lblBookType";
            this.lblBookType.Size = new System.Drawing.Size(195, 23);
            this.lblBookType.TabIndex = 11;
            this.lblBookType.Text = "Loại sách";
            // 
            // cbBookType
            // 
            this.cbBookType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBookType.FormattingEnabled = true;
            this.cbBookType.Location = new System.Drawing.Point(825, 38);
            this.cbBookType.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.cbBookType.Name = "cbBookType";
            this.cbBookType.Size = new System.Drawing.Size(185, 31);
            this.cbBookType.TabIndex = 5;
            this.cbBookType.Click += new System.EventHandler(this.cbBookType_Click);
            // 
            // dtpPublishDate
            // 
            this.dtpPublishDate.CustomFormat = "MM.dd.yyyy";
            this.dtpPublishDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPublishDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPublishDate.Location = new System.Drawing.Point(1030, 38);
            this.dtpPublishDate.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.dtpPublishDate.Name = "dtpPublishDate";
            this.dtpPublishDate.Size = new System.Drawing.Size(185, 30);
            this.dtpPublishDate.TabIndex = 6;
            // 
            // lblPublishDate
            // 
            this.lblPublishDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPublishDate.AutoSize = true;
            this.lblPublishDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublishDate.Location = new System.Drawing.Point(1030, 5);
            this.lblPublishDate.Margin = new System.Windows.Forms.Padding(5);
            this.lblPublishDate.Name = "lblPublishDate";
            this.lblPublishDate.Size = new System.Drawing.Size(195, 23);
            this.lblPublishDate.TabIndex = 13;
            this.lblPublishDate.Text = "Ngày xuất bản";
            // 
            // dgvBook
            // 
            this.dgvBook.AllowUserToDeleteRows = false;
            this.dgvBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBook.BackgroundColor = System.Drawing.Color.White;
            this.dgvBook.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelContainer.SetColumnSpan(this.dgvBook, 8);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBook.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBook.EnableHeadersVisualStyles = false;
            this.dgvBook.Location = new System.Drawing.Point(5, 79);
            this.dgvBook.Margin = new System.Windows.Forms.Padding(5);
            this.dgvBook.Name = "dgvBook";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBook.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBook.RowHeadersVisible = false;
            this.dgvBook.RowHeadersWidth = 51;
            this.dgvBook.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvBook.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvBook.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightGray;
            this.dgvBook.RowTemplate.Height = 24;
            this.dgvBook.RowTemplate.ReadOnly = true;
            this.dgvBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBook.Size = new System.Drawing.Size(1658, 731);
            this.dgvBook.TabIndex = 8;
            this.dgvBook.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBook_DataError);
            // 
            // panelContainer
            // 
            this.panelContainer.AutoSize = true;
            this.panelContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContainer.ColumnCount = 9;
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelContainer.Controls.Add(this.lblAmount, 7, 1);
            this.panelContainer.Controls.Add(this.txtAmout, 7, 2);
            this.panelContainer.Controls.Add(this.dgvBook, 1, 4);
            this.panelContainer.Controls.Add(this.txtBookName, 2, 2);
            this.panelContainer.Controls.Add(this.dtpPublishDate, 6, 2);
            this.panelContainer.Controls.Add(this.cbPublisher, 3, 2);
            this.panelContainer.Controls.Add(this.txtBookID, 1, 2);
            this.panelContainer.Controls.Add(this.lblID, 1, 1);
            this.panelContainer.Controls.Add(this.cbBookType, 5, 2);
            this.panelContainer.Controls.Add(this.cbAuthor, 4, 2);
            this.panelContainer.Controls.Add(this.lblPublishDate, 6, 1);
            this.panelContainer.Controls.Add(this.lblName, 2, 1);
            this.panelContainer.Controls.Add(this.lblBookType, 5, 1);
            this.panelContainer.Controls.Add(this.lblPublish, 3, 1);
            this.panelContainer.Controls.Add(this.lblAuthor, 4, 1);
            this.panelContainer.Controls.Add(this.PagingNavigation, 1, 5);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.RowCount = 8;
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelContainer.Size = new System.Drawing.Size(1645, 917);
            this.panelContainer.TabIndex = 23;
            // 
            // PagingNavigation
            // 
            this.panelContainer.SetColumnSpan(this.PagingNavigation, 3);
            this.PagingNavigation.Controls.Add(this.btnPrevious);
            this.PagingNavigation.Controls.Add(this.lblPageIndex);
            this.PagingNavigation.Controls.Add(this.lblTotalRecord);
            this.PagingNavigation.Controls.Add(this.btnNext);
            this.PagingNavigation.Controls.Add(this.btn5);
            this.PagingNavigation.Controls.Add(this.btn10);
            this.PagingNavigation.Controls.Add(this.btn15);
            this.PagingNavigation.Controls.Add(this.lblPerpage);
            this.PagingNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagingNavigation.Location = new System.Drawing.Point(3, 818);
            this.PagingNavigation.Name = "PagingNavigation";
            this.PagingNavigation.Size = new System.Drawing.Size(609, 70);
            this.PagingNavigation.TabIndex = 14;
            // 
            // btnPrevious
            // 
            this.btnPrevious.AutoSize = true;
            this.btnPrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(3, 3);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(86, 43);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblPageIndex
            // 
            this.lblPageIndex.AutoSize = true;
            this.lblPageIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPageIndex.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageIndex.Location = new System.Drawing.Point(95, 0);
            this.lblPageIndex.Name = "lblPageIndex";
            this.lblPageIndex.Size = new System.Drawing.Size(19, 49);
            this.lblPageIndex.TabIndex = 1;
            this.lblPageIndex.Text = "1";
            this.lblPageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTotalRecord.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.Location = new System.Drawing.Point(120, 0);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(31, 49);
            this.lblTotalRecord.TabIndex = 3;
            this.lblTotalRecord.Text = "/ 2";
            this.lblTotalRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(157, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(58, 43);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btn5
            // 
            this.btn5.AutoSize = true;
            this.btn5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(225, 7);
            this.btn5.Margin = new System.Windows.Forms.Padding(7);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(31, 35);
            this.btn5.TabIndex = 4;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn10
            // 
            this.btn10.AutoSize = true;
            this.btn10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.Location = new System.Drawing.Point(270, 7);
            this.btn10.Margin = new System.Windows.Forms.Padding(7);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(40, 35);
            this.btn10.TabIndex = 5;
            this.btn10.Text = "10";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btn10_Click);
            // 
            // btn15
            // 
            this.btn15.AutoSize = true;
            this.btn15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn15.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn15.Location = new System.Drawing.Point(324, 7);
            this.btn15.Margin = new System.Windows.Forms.Padding(7);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(40, 35);
            this.btn15.TabIndex = 6;
            this.btn15.Text = "15";
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btn15_Click);
            // 
            // lblPerpage
            // 
            this.lblPerpage.AutoSize = true;
            this.lblPerpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPerpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPerpage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerpage.Location = new System.Drawing.Point(378, 7);
            this.lblPerpage.Margin = new System.Windows.Forms.Padding(7);
            this.lblPerpage.Name = "lblPerpage";
            this.lblPerpage.Size = new System.Drawing.Size(77, 35);
            this.lblPerpage.TabIndex = 7;
            this.lblPerpage.Text = "Per page";
            this.lblPerpage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // childToolStrip
            // 
            this.childToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.childToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnCancel});
            this.childToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.childToolStrip.Location = new System.Drawing.Point(0, 0);
            this.childToolStrip.Name = "childToolStrip";
            this.childToolStrip.Size = new System.Drawing.Size(1645, 27);
            this.childToolStrip.TabIndex = 24;
            this.childToolStrip.Text = "toolStrip1";
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::QuanLyThuVien.Properties.Resources.add;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(29, 24);
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::QuanLyThuVien.Properties.Resources.edit1;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(29, 24);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::QuanLyThuVien.Properties.Resources.delete2;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 24);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCancel.Image = global::QuanLyThuVien.Properties.Resources.cancel;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(29, 24);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1645, 917);
            this.Controls.Add(this.childToolStrip);
            this.Controls.Add(this.panelContainer);
            this.Name = "BookForm";
            this.Text = "1";
            this.Load += new System.EventHandler(this.BookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.PagingNavigation.ResumeLayout(false);
            this.PagingNavigation.PerformLayout();
            this.childToolStrip.ResumeLayout(false);
            this.childToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtAmout;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ComboBox cbPublisher;
        private System.Windows.Forms.Label lblPublish;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.ComboBox cbAuthor;
        private System.Windows.Forms.Label lblBookType;
        private System.Windows.Forms.ComboBox cbBookType;
        private System.Windows.Forms.DateTimePicker dtpPublishDate;
        private System.Windows.Forms.Label lblPublishDate;
        private System.Windows.Forms.DataGridView dgvBook;
        private System.Windows.Forms.TableLayoutPanel panelContainer;
        private System.Windows.Forms.ToolStrip childToolStrip;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.FlowLayoutPanel PagingNavigation;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPageIndex;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Label lblPerpage;
    }
}