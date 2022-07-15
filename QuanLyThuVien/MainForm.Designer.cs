
namespace QuanLyThuVien
{
    partial class MainForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnUserAccountForm = new System.Windows.Forms.Button();
            this.btnReportForm = new System.Windows.Forms.Button();
            this.btnBorrowForm = new System.Windows.Forms.Button();
            this.btnPublishCompanyForm = new System.Windows.Forms.Button();
            this.btnReaderForm = new System.Windows.Forms.Button();
            this.btnAuthorForm = new System.Windows.Forms.Button();
            this.panelSideContainer = new System.Windows.Forms.TableLayoutPanel();
            this.btnBookForm = new System.Windows.Forms.Button();
            this.btnBookTypeForm = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.tlLanguageDropdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.englishToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vietnameseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.vietnameseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSideContainer.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.panelSideContainer.SetColumnSpan(this.lblTitle, 2);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 10);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 38);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "Thư viện trường";
            // 
            // btnUserAccountForm
            // 
            this.btnUserAccountForm.AutoSize = true;
            this.btnUserAccountForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUserAccountForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnUserAccountForm, 2);
            this.btnUserAccountForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUserAccountForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserAccountForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserAccountForm.Image = global::QuanLyThuVien.Properties.Resources.user2;
            this.btnUserAccountForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserAccountForm.Location = new System.Drawing.Point(3, 453);
            this.btnUserAccountForm.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnUserAccountForm.Name = "btnUserAccountForm";
            this.btnUserAccountForm.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnUserAccountForm.Size = new System.Drawing.Size(220, 50);
            this.btnUserAccountForm.TabIndex = 8;
            this.btnUserAccountForm.Text = "Tài khoản";
            this.btnUserAccountForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUserAccountForm.UseVisualStyleBackColor = false;
            this.btnUserAccountForm.Click += new System.EventHandler(this.btnBookTypeForm_Click);
            // 
            // btnReportForm
            // 
            this.btnReportForm.AutoSize = true;
            this.btnReportForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReportForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnReportForm, 2);
            this.btnReportForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReportForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportForm.Image = global::QuanLyThuVien.Properties.Resources.report1;
            this.btnReportForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportForm.Location = new System.Drawing.Point(3, 397);
            this.btnReportForm.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnReportForm.Name = "btnReportForm";
            this.btnReportForm.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnReportForm.Size = new System.Drawing.Size(220, 50);
            this.btnReportForm.TabIndex = 7;
            this.btnReportForm.Text = "Thống kê";
            this.btnReportForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportForm.UseVisualStyleBackColor = false;
            this.btnReportForm.Click += new System.EventHandler(this.btnBookTypeForm_Click);
            // 
            // btnBorrowForm
            // 
            this.btnBorrowForm.AutoSize = true;
            this.btnBorrowForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBorrowForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnBorrowForm, 2);
            this.btnBorrowForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBorrowForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrowForm.Image = global::QuanLyThuVien.Properties.Resources.borrow2;
            this.btnBorrowForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrowForm.Location = new System.Drawing.Point(3, 341);
            this.btnBorrowForm.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnBorrowForm.Name = "btnBorrowForm";
            this.btnBorrowForm.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnBorrowForm.Size = new System.Drawing.Size(220, 50);
            this.btnBorrowForm.TabIndex = 6;
            this.btnBorrowForm.Text = "Mượn, trả sách";
            this.btnBorrowForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrowForm.UseVisualStyleBackColor = false;
            this.btnBorrowForm.Click += new System.EventHandler(this.btnBookTypeForm_Click);
            // 
            // btnPublishCompanyForm
            // 
            this.btnPublishCompanyForm.AutoSize = true;
            this.btnPublishCompanyForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPublishCompanyForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnPublishCompanyForm, 2);
            this.btnPublishCompanyForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPublishCompanyForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublishCompanyForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublishCompanyForm.Image = global::QuanLyThuVien.Properties.Resources.user;
            this.btnPublishCompanyForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPublishCompanyForm.Location = new System.Drawing.Point(3, 285);
            this.btnPublishCompanyForm.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnPublishCompanyForm.Name = "btnPublishCompanyForm";
            this.btnPublishCompanyForm.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnPublishCompanyForm.Size = new System.Drawing.Size(220, 50);
            this.btnPublishCompanyForm.TabIndex = 5;
            this.btnPublishCompanyForm.Text = "Nhà xuất bản";
            this.btnPublishCompanyForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPublishCompanyForm.UseVisualStyleBackColor = false;
            this.btnPublishCompanyForm.Click += new System.EventHandler(this.btnBookTypeForm_Click);
            // 
            // btnReaderForm
            // 
            this.btnReaderForm.AutoSize = true;
            this.btnReaderForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReaderForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnReaderForm, 2);
            this.btnReaderForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReaderForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReaderForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReaderForm.Image = global::QuanLyThuVien.Properties.Resources.reader1;
            this.btnReaderForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReaderForm.Location = new System.Drawing.Point(3, 229);
            this.btnReaderForm.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnReaderForm.Name = "btnReaderForm";
            this.btnReaderForm.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnReaderForm.Size = new System.Drawing.Size(220, 50);
            this.btnReaderForm.TabIndex = 4;
            this.btnReaderForm.Text = "Độc giả";
            this.btnReaderForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReaderForm.UseVisualStyleBackColor = false;
            this.btnReaderForm.Click += new System.EventHandler(this.btnBookTypeForm_Click);
            // 
            // btnAuthorForm
            // 
            this.btnAuthorForm.AutoSize = true;
            this.btnAuthorForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAuthorForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnAuthorForm, 2);
            this.btnAuthorForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAuthorForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthorForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAuthorForm.Image = global::QuanLyThuVien.Properties.Resources.author1;
            this.btnAuthorForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthorForm.Location = new System.Drawing.Point(3, 173);
            this.btnAuthorForm.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnAuthorForm.Name = "btnAuthorForm";
            this.btnAuthorForm.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnAuthorForm.Size = new System.Drawing.Size(220, 50);
            this.btnAuthorForm.TabIndex = 3;
            this.btnAuthorForm.Text = "Tác giả";
            this.btnAuthorForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAuthorForm.UseVisualStyleBackColor = false;
            this.btnAuthorForm.Click += new System.EventHandler(this.btnBookTypeForm_Click);
            // 
            // panelSideContainer
            // 
            this.panelSideContainer.AutoSize = true;
            this.panelSideContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelSideContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.ColumnCount = 2;
            this.panelSideContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSideContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelSideContainer.Controls.Add(this.btnBookForm, 2, 3);
            this.panelSideContainer.Controls.Add(this.lblTitle, 1, 2);
            this.panelSideContainer.Controls.Add(this.btnBookTypeForm, 0, 5);
            this.panelSideContainer.Controls.Add(this.btnAuthorForm, 0, 6);
            this.panelSideContainer.Controls.Add(this.btnReaderForm, 0, 7);
            this.panelSideContainer.Controls.Add(this.btnPublishCompanyForm, 0, 8);
            this.panelSideContainer.Controls.Add(this.btnBorrowForm, 0, 9);
            this.panelSideContainer.Controls.Add(this.btnReportForm, 0, 10);
            this.panelSideContainer.Controls.Add(this.btnUserAccountForm, 0, 13);
            this.panelSideContainer.Controls.Add(this.btnLogout, 0, 14);
            this.panelSideContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideContainer.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSideContainer.Location = new System.Drawing.Point(0, 27);
            this.panelSideContainer.Name = "panelSideContainer";
            this.panelSideContainer.RowCount = 16;
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.panelSideContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSideContainer.Size = new System.Drawing.Size(226, 939);
            this.panelSideContainer.TabIndex = 0;
            // 
            // btnBookForm
            // 
            this.btnBookForm.AutoSize = true;
            this.btnBookForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBookForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnBookForm, 2);
            this.btnBookForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBookForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookForm.Image = global::QuanLyThuVien.Properties.Resources.book1;
            this.btnBookForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookForm.Location = new System.Drawing.Point(3, 61);
            this.btnBookForm.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnBookForm.Name = "btnBookForm";
            this.btnBookForm.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnBookForm.Size = new System.Drawing.Size(220, 50);
            this.btnBookForm.TabIndex = 1;
            this.btnBookForm.Text = "Sách";
            this.btnBookForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookForm.UseVisualStyleBackColor = false;
            this.btnBookForm.Click += new System.EventHandler(this.btnBookTypeForm_Click);
            // 
            // btnBookTypeForm
            // 
            this.btnBookTypeForm.AutoSize = true;
            this.btnBookTypeForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBookTypeForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnBookTypeForm, 2);
            this.btnBookTypeForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBookTypeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookTypeForm.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookTypeForm.Image = global::QuanLyThuVien.Properties.Resources.booktype1;
            this.btnBookTypeForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookTypeForm.Location = new System.Drawing.Point(3, 117);
            this.btnBookTypeForm.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnBookTypeForm.Name = "btnBookTypeForm";
            this.btnBookTypeForm.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnBookTypeForm.Size = new System.Drawing.Size(220, 50);
            this.btnBookTypeForm.TabIndex = 2;
            this.btnBookTypeForm.Text = "Loại sách";
            this.btnBookTypeForm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookTypeForm.UseVisualStyleBackColor = false;
            this.btnBookTypeForm.Click += new System.EventHandler(this.btnBookTypeForm_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = true;
            this.btnLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(204)))), ((int)(((byte)(145)))));
            this.panelSideContainer.SetColumnSpan(this.btnLogout, 2);
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Image = global::QuanLyThuVien.Properties.Resources.logout2;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(3, 509);
            this.btnLogout.MinimumSize = new System.Drawing.Size(160, 48);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.btnLogout.Size = new System.Drawing.Size(220, 50);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.BackColor = System.Drawing.Color.White;
            this.mainToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlLanguageDropdown});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(1747, 27);
            this.mainToolStrip.TabIndex = 20;
            this.mainToolStrip.Text = "mainToolStrip";
            // 
            // tlLanguageDropdown
            // 
            this.tlLanguageDropdown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlLanguageDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlLanguageDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem1,
            this.vietnameseToolStripMenuItem1});
            this.tlLanguageDropdown.Image = global::QuanLyThuVien.Properties.Resources.language1;
            this.tlLanguageDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlLanguageDropdown.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.tlLanguageDropdown.Name = "tlLanguageDropdown";
            this.tlLanguageDropdown.Size = new System.Drawing.Size(34, 24);
            this.tlLanguageDropdown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tlLanguageDropdown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // englishToolStripMenuItem1
            // 
            this.englishToolStripMenuItem1.Image = global::QuanLyThuVien.Properties.Resources.comi;
            this.englishToolStripMenuItem1.Name = "englishToolStripMenuItem1";
            this.englishToolStripMenuItem1.Size = new System.Drawing.Size(169, 26);
            this.englishToolStripMenuItem1.Text = "English";
            this.englishToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.englishToolStripMenuItem1.Click += new System.EventHandler(this.englishToolStripMenuItem1_Click);
            // 
            // vietnameseToolStripMenuItem1
            // 
            this.vietnameseToolStripMenuItem1.Image = global::QuanLyThuVien.Properties.Resources.quocky;
            this.vietnameseToolStripMenuItem1.Name = "vietnameseToolStripMenuItem1";
            this.vietnameseToolStripMenuItem1.Size = new System.Drawing.Size(169, 26);
            this.vietnameseToolStripMenuItem1.Text = "Vietnamese";
            this.vietnameseToolStripMenuItem1.Click += new System.EventHandler(this.vietnameseToolStripMenuItem1_Click);
            // 
            // vietnameseToolStripMenuItem
            // 
            this.vietnameseToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.vietnameseToolStripMenuItem.Name = "vietnameseToolStripMenuItem";
            this.vietnameseToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.AutoSize = false;
            this.englishToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.englishToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.englishToolStripMenuItem.Image = global::QuanLyThuVien.Properties.Resources.comi;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(32, 32);
            this.englishToolStripMenuItem.Text = "english";
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(226, 27);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1521, 939);
            this.panelMain.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1747, 966);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSideContainer);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thư viện";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelSideContainer.ResumeLayout(false);
            this.panelSideContainer.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPublishCompanyForm;
        private System.Windows.Forms.Button btnReaderForm;
        private System.Windows.Forms.Button btnAuthorForm;
        private System.Windows.Forms.Button btnBookTypeForm;
        private System.Windows.Forms.Button btnReportForm;
        private System.Windows.Forms.Button btnBorrowForm;
        private System.Windows.Forms.Button btnUserAccountForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel panelSideContainer;
        private System.Windows.Forms.Button btnBookForm;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ToolStripDropDownButton tlLanguageDropdown;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vietnameseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vietnameseToolStripMenuItem1;
        public System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.Panel panelMain;
    }
}

