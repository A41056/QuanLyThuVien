
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
            this.panelButton = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDeny = new System.Windows.Forms.Button();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.childToolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chxCacheData = new System.Windows.Forms.CheckBox();
            this.panelContainer.SuspendLayout();
            this.PagingNavigation.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
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
            this.lblID.Size = new System.Drawing.Size(154, 23);
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
            this.txtBookID.Size = new System.Drawing.Size(144, 30);
            this.txtBookID.TabIndex = 1;
            // 
            // txtBookName
            // 
            this.txtBookName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookName.Location = new System.Drawing.Point(169, 38);
            this.txtBookName.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.txtBookName.MaxLength = 100;
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(144, 30);
            this.txtBookName.TabIndex = 2;
            this.txtBookName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBookName_Validating);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(169, 5);
            this.lblName.Margin = new System.Windows.Forms.Padding(5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Tên sách";
            // 
            // txtAmout
            // 
            this.txtAmout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmout.Location = new System.Drawing.Point(1198, 38);
            this.txtAmout.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.txtAmout.Name = "txtAmout";
            this.txtAmout.Size = new System.Drawing.Size(158, 30);
            this.txtAmout.TabIndex = 7;
            this.txtAmout.Validating += new System.ComponentModel.CancelEventHandler(this.txtAmout_Validating);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(1198, 5);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(5);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(112, 23);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Số lượng còn";
            // 
            // cbPublisher
            // 
            this.cbPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPublisher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbPublisher.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPublisher.FormattingEnabled = true;
            this.cbPublisher.Location = new System.Drawing.Point(333, 38);
            this.cbPublisher.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.cbPublisher.Name = "cbPublisher";
            this.cbPublisher.Size = new System.Drawing.Size(144, 31);
            this.cbPublisher.TabIndex = 3;
            this.cbPublisher.Click += new System.EventHandler(this.cbPublisher_Click);
            // 
            // lblPublish
            // 
            this.lblPublish.AutoSize = true;
            this.lblPublish.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublish.Location = new System.Drawing.Point(333, 5);
            this.lblPublish.Margin = new System.Windows.Forms.Padding(5);
            this.lblPublish.Name = "lblPublish";
            this.lblPublish.Size = new System.Drawing.Size(115, 23);
            this.lblPublish.TabIndex = 7;
            this.lblPublish.Text = "Nhà xuất bản";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(497, 5);
            this.lblAuthor.Margin = new System.Windows.Forms.Padding(5);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(62, 23);
            this.lblAuthor.TabIndex = 9;
            this.lblAuthor.Text = "Tác giả";
            // 
            // cbAuthor
            // 
            this.cbAuthor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAuthor.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAuthor.FormattingEnabled = true;
            this.cbAuthor.Location = new System.Drawing.Point(497, 38);
            this.cbAuthor.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.cbAuthor.Name = "cbAuthor";
            this.cbAuthor.Size = new System.Drawing.Size(144, 31);
            this.cbAuthor.TabIndex = 4;
            this.cbAuthor.Click += new System.EventHandler(this.cbAuthor_Click);
            // 
            // lblBookType
            // 
            this.lblBookType.AutoSize = true;
            this.lblBookType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookType.Location = new System.Drawing.Point(661, 5);
            this.lblBookType.Margin = new System.Windows.Forms.Padding(5);
            this.lblBookType.Name = "lblBookType";
            this.lblBookType.Size = new System.Drawing.Size(80, 23);
            this.lblBookType.TabIndex = 11;
            this.lblBookType.Text = "Loại sách";
            // 
            // cbBookType
            // 
            this.cbBookType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBookType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBookType.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBookType.FormattingEnabled = true;
            this.cbBookType.Location = new System.Drawing.Point(661, 38);
            this.cbBookType.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.cbBookType.Name = "cbBookType";
            this.cbBookType.Size = new System.Drawing.Size(144, 31);
            this.cbBookType.TabIndex = 5;
            this.cbBookType.Click += new System.EventHandler(this.cbBookType_Click);
            // 
            // dtpPublishDate
            // 
            this.dtpPublishDate.CustomFormat = "MM.dd.yyyy";
            this.dtpPublishDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPublishDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPublishDate.Location = new System.Drawing.Point(907, 38);
            this.dtpPublishDate.Margin = new System.Windows.Forms.Padding(5, 5, 15, 5);
            this.dtpPublishDate.Name = "dtpPublishDate";
            this.dtpPublishDate.Size = new System.Drawing.Size(271, 30);
            this.dtpPublishDate.TabIndex = 6;
            // 
            // lblPublishDate
            // 
            this.lblPublishDate.AutoSize = true;
            this.lblPublishDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublishDate.Location = new System.Drawing.Point(907, 5);
            this.lblPublishDate.Margin = new System.Windows.Forms.Padding(5);
            this.lblPublishDate.Name = "lblPublishDate";
            this.lblPublishDate.Size = new System.Drawing.Size(124, 23);
            this.lblPublishDate.TabIndex = 13;
            this.lblPublishDate.Text = "Ngày xuất bản";
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
            this.panelContainer.Controls.Add(this.PagingNavigation, 1, 7);
            this.panelContainer.Controls.Add(this.panelButton, 8, 2);
            this.panelContainer.Controls.Add(this.dgvBook, 1, 4);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.RowCount = 8;
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelContainer.Size = new System.Drawing.Size(1668, 917);
            this.panelContainer.TabIndex = 23;
            // 
            // PagingNavigation
            // 
            this.panelContainer.SetColumnSpan(this.PagingNavigation, 5);
            this.PagingNavigation.Controls.Add(this.btnPrevious);
            this.PagingNavigation.Controls.Add(this.lblPageIndex);
            this.PagingNavigation.Controls.Add(this.lblTotalRecord);
            this.PagingNavigation.Controls.Add(this.btnNext);
            this.PagingNavigation.Controls.Add(this.btn5);
            this.PagingNavigation.Controls.Add(this.btn10);
            this.PagingNavigation.Controls.Add(this.btn15);
            this.PagingNavigation.Controls.Add(this.lblPerpage);
            this.PagingNavigation.Controls.Add(this.chxCacheData);
            this.PagingNavigation.Location = new System.Drawing.Point(3, 868);
            this.PagingNavigation.Name = "PagingNavigation";
            this.PagingNavigation.Size = new System.Drawing.Size(896, 58);
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
            this.btnPrevious.TabIndex = 14;
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
            this.lblTotalRecord.Size = new System.Drawing.Size(33, 49);
            this.lblTotalRecord.TabIndex = 3;
            this.lblTotalRecord.Text = "|  2";
            this.lblTotalRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(159, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(58, 43);
            this.btnNext.TabIndex = 15;
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
            this.btn5.Location = new System.Drawing.Point(227, 7);
            this.btn5.Margin = new System.Windows.Forms.Padding(7);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(31, 35);
            this.btn5.TabIndex = 16;
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
            this.btn10.Location = new System.Drawing.Point(272, 7);
            this.btn10.Margin = new System.Windows.Forms.Padding(7);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(40, 35);
            this.btn10.TabIndex = 17;
            this.btn10.Text = "10";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn15
            // 
            this.btn15.AutoSize = true;
            this.btn15.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn15.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn15.Location = new System.Drawing.Point(326, 7);
            this.btn15.Margin = new System.Windows.Forms.Padding(7);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(40, 35);
            this.btn15.TabIndex = 18;
            this.btn15.Text = "15";
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btn5_Click);
            // 
            // lblPerpage
            // 
            this.lblPerpage.AutoSize = true;
            this.lblPerpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPerpage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPerpage.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerpage.Location = new System.Drawing.Point(380, 7);
            this.lblPerpage.Margin = new System.Windows.Forms.Padding(7);
            this.lblPerpage.Name = "lblPerpage";
            this.lblPerpage.Size = new System.Drawing.Size(77, 35);
            this.lblPerpage.TabIndex = 7;
            this.lblPerpage.Text = "Per page";
            this.lblPerpage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButton
            // 
            this.panelButton.AutoSize = true;
            this.panelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelButton.Controls.Add(this.btnAccept);
            this.panelButton.Controls.Add(this.btnDeny);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButton.Location = new System.Drawing.Point(1374, 36);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(291, 46);
            this.panelButton.TabIndex = 15;
            // 
            // btnAccept
            // 
            this.btnAccept.AutoSize = true;
            this.btnAccept.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Image = global::QuanLyThuVien.Properties.Resources.accept;
            this.btnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Location = new System.Drawing.Point(3, 3);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(91, 40);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnDeny
            // 
            this.btnDeny.AutoSize = true;
            this.btnDeny.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDeny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeny.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeny.Image = global::QuanLyThuVien.Properties.Resources.deny;
            this.btnDeny.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeny.Location = new System.Drawing.Point(100, 3);
            this.btnDeny.Name = "btnDeny";
            this.btnDeny.Size = new System.Drawing.Size(90, 40);
            this.btnDeny.TabIndex = 1;
            this.btnDeny.Text = "Cancel";
            this.btnDeny.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeny.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeny.UseVisualStyleBackColor = true;
            // 
            // dgvBook
            // 
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.panelContainer.SetColumnSpan(this.dgvBook, 8);
            this.dgvBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBook.Location = new System.Drawing.Point(3, 88);
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.RowHeadersWidth = 51;
            this.dgvBook.RowTemplate.Height = 24;
            this.dgvBook.Size = new System.Drawing.Size(1662, 774);
            this.dgvBook.TabIndex = 16;
            // 
            // childToolStrip
            // 
            this.childToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.childToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnCancel,
            this.btnExport});
            this.childToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.childToolStrip.Location = new System.Drawing.Point(0, 0);
            this.childToolStrip.Name = "childToolStrip";
            this.childToolStrip.Size = new System.Drawing.Size(1668, 27);
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
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = global::QuanLyThuVien.Properties.Resources.edit1;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(29, 24);
            this.btnEdit.Text = "Edit";
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::QuanLyThuVien.Properties.Resources.delete2;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 24);
            this.btnDelete.Text = "Delete";
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
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnExport.Image = global::QuanLyThuVien.Properties.Resources.printer;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(29, 24);
            this.btnExport.Text = "toolStripButton1";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // chxCacheData
            // 
            this.chxCacheData.AutoSize = true;
            this.chxCacheData.Location = new System.Drawing.Point(467, 3);
            this.chxCacheData.Name = "chxCacheData";
            this.chxCacheData.Size = new System.Drawing.Size(100, 20);
            this.chxCacheData.TabIndex = 17;
            this.chxCacheData.Text = "Cache Data";
            this.chxCacheData.UseVisualStyleBackColor = true;
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1668, 917);
            this.Controls.Add(this.childToolStrip);
            this.Controls.Add(this.panelContainer);
            this.Name = "BookForm";
            this.Text = "1";
            this.Load += new System.EventHandler(this.BookForm_Load);
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            this.PagingNavigation.ResumeLayout(false);
            this.PagingNavigation.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.panelButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel panelContainer;
        private System.Windows.Forms.ToolStrip childToolStrip;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.FlowLayoutPanel panelButton;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDeny;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.FlowLayoutPanel PagingNavigation;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPageIndex;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Label lblPerpage;
        private System.Windows.Forms.DataGridView dgvBook;
        private System.Windows.Forms.CheckBox chxCacheData;
    }
}