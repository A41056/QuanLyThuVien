using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class AuthorForm : Form
    {
        private AuthorDAL _authorDAL = null;
        private CancellationTokenSource _ct = null;

        public AuthorForm()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        private bool checkValid()
        {
            return true;
            //return base.checkValid();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            exportToExcel(dgvAuthor);
        }

        private async Task loadData()
        {
            await _authorDAL.loadDataAsync();
        }

        private void AuthorForm_Load(object sender, EventArgs e)
        {
            if (_authorDAL == null)
                _authorDAL = new AuthorDAL();

            loadData().ContinueWith((t) =>
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        bindingData(dgvAuthor);
                        applyUIStrings();
                    }));
                }
                else
                {
                    bindingData(dgvAuthor);
                    applyUIStrings();
                }
            });
        }

        private void bindingData(DataGridView pDgv)
        {
            //base.bindingData(dgvAuthor);
        }


        private void applyUIStrings()
        {
            //base.applyUIStrings();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //if (checkValid())
            //{
            //    if (_ct == null)
            //        _ct = new CancellationTokenSource();

            //    if (int.TryParse(txtPhone.Text, out int _nSdt))
            //    {
            //        _authorDAL.insertAuthorAsync(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, Convert.ToDateTime(dtpDateofBirth.Value), _ct.Token).ContinueWith((t) => 
            //        {
            //            loadData();
            //            _ct.Dispose();
            //            _ct = null;
            //        });

            //    }
            //    else
            //    {
            //        MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
            //    }
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (checkValid())
            //{
            //    if (_ct == null)
            //        _ct = new CancellationTokenSource();

            //    if (int.TryParse(txtPhone.Text, out int _nSdt))
            //    {
            //        _authorDAL.updateAuthorAsync(Convert.ToInt32(txtID.Text), txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, Convert.ToDateTime(dtpDateofBirth.Value), _ct.Token).ContinueWith((t) =>
            //        {
            //            loadData();
            //            _ct.Dispose();
            //            _ct = null;
            //        });

            //    }
            //    else
            //    {
            //        MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
            //    }
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //base.btnCancel_Click(sender, e);
        }

        private void exportToExcel(DataGridView pDgv)
        {
            //base.exportToExcel(pDgv);
        }
    }
}
