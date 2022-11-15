using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class MainForm : Form
    {
        public static event EventHandler onLanguageChanged;
        private string zOpeningFormName;
        public MainForm()
        {
            InitializeComponent();
        }

        public Form createForm(string pzFormName)
        {
            Form _frm = null;

            if (string.Compare(pzFormName, nameof(BookForm), false) == 0)
                _frm = new BookForm();
            else if (string.Compare(pzFormName, nameof(BookTypeForm), false) == 0)
                _frm = new BookTypeForm();
            else if (string.Compare(pzFormName, nameof(AuthorForm), false) == 0)
                _frm = new AuthorForm();
            else if (string.Compare(pzFormName, nameof(BorrowForm), false) == 0)
                _frm = new BorrowForm();
            else if (string.Compare(pzFormName, nameof(PublishCompanyForm), false) == 0)
                _frm = new PublishCompanyForm();
            else if (string.Compare(pzFormName, nameof(ReaderForm), false) == 0)
                _frm = new ReaderForm();
            else if (string.Compare(pzFormName, nameof(ReportForm), false) == 0)
                _frm = new ReportForm();
            else if (string.Compare(pzFormName, nameof(UserAccountForm), false) == 0)
                _frm = new UserAccountForm();

            return _frm;
        }

        private void openForm(string pzFormname)
        {
            var _frm = Application.OpenForms.Cast<Form>().FirstOrDefault(
                e => string.Compare(e.Name, pzFormname, false) == 0);
            if (_frm == null)
                _frm = createForm(pzFormname);

            if (_frm == null) return;

            changeChildForm(_frm);
        }

        private void btnBookTypeForm_Click(object sender, EventArgs e)
        {
            // This event is writed to all form button in MainForm
            
            var _btn = sender as Button;
            if (_btn == null || !_btn.Name.StartsWith("btn"))
                return;

            var _zFrmName = _btn.Name.Substring("btn".Length);

            if (string.Compare(_zFrmName, zOpeningFormName, false) == 0)
                return;

            openForm(_zFrmName);

            zOpeningFormName = _zFrmName;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            closeOpenedForm();
        }

        private void closeOpenedForm()
        {
            var _lstOpenedform = Application.OpenForms.Cast<Form>().ToList();

            foreach (Form _zFrm in _lstOpenedform)
            {
                if (_zFrm.InvokeRequired)
                {
                    Invoke((MethodInvoker)(() => _zFrm.Dispose()));
                    _zFrm.Close();
                }
            }
            Application.Restart();
        }

        private void changeChildForm(Form pChildForm)
        {
            panelMain.Show();
            panelMain.Controls.Clear();
            pChildForm.TopLevel = false;
            pChildForm.Dock = DockStyle.Fill;
            pChildForm.FormBorderStyle = FormBorderStyle.None;
            panelMain.Controls.Add(pChildForm);
            mergeToolStrip(pChildForm);
            pChildForm.Show();
        }

        private void mergeToolStrip(Form _pFrm)
        {
            foreach (ToolStripItem item in mainToolStrip.Items)
            {
                item.MergeAction = MergeAction.Append;
                item.MergeIndex = 1;
            }

            ToolStripManager.RevertMerge("mainToolStrip");
            ToolStripManager.Merge((ToolStrip)_pFrm.Controls.Find("childToolStrip", true).FirstOrDefault(), "mainToolStrip");
            _pFrm.Controls.Find("childToolStrip", true).FirstOrDefault().Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BookForm _bookForm = new BookForm();
            changeChildForm(_bookForm);

            zOpeningFormName = _bookForm.Name;

            applyUIStrings();
        }

        private void applyUIStrings()
        {
            Text = QuanLyThuVien.Resource.ApplicationTitle;
            lblTitle.Text = QuanLyThuVien.Resource.lblTitle;
            btnBookForm.Text = QuanLyThuVien.Resource.btnBook;
            btnBookTypeForm.Text = QuanLyThuVien.Resource.btnBookType;
            btnAuthorForm.Text = QuanLyThuVien.Resource.btnAuthor;
            btnReaderForm.Text = QuanLyThuVien.Resource.btnReader;
            btnReportForm.Text = QuanLyThuVien.Resource.btnReport;
            btnUserAccountForm.Text = QuanLyThuVien.Resource.btnAccount;
            btnBorrowForm.Text = QuanLyThuVien.Resource.btnBorrow;
            btnPublishCompanyForm.Text = QuanLyThuVien.Resource.btnPublish;
            btnLogout.Text = QuanLyThuVien.Resource.btnLogout;

            //Raise Event
            onLanguageChanged?.Invoke(this, EventArgs.Empty);
        }

        private void englishToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CultureInfo.CurrentUICulture = new CultureInfo("en");
            applyUIStrings();
        }

        private void vietnameseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CultureInfo.CurrentUICulture = new CultureInfo("vi");
            applyUIStrings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
