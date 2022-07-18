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
    public partial class AuthorForm : FormBase
    {
        private AuthorDAL _authorDAL = new AuthorDAL();
        private CancellationTokenSource _ct = null;

        public AuthorForm()
        {
            InitializeComponent();
        }

        private bool checkValid()
        {

            return checkValid();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            btnExcel_Click(sender, e);
        }

        protected override async Task loadData()
        {
            dgvAuthor.DataSource = await _authorDAL.loadDataAsync();
            await base.loadData();
        }

        protected override void bindingData()
        {
            var _tb = dgvAuthor.DataSource as DataTable;

            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtAddress.DataBindings.Clear();

            txtID.DataBindings.Add("Text", _tb, "ID");
            txtName.DataBindings.Add("Text", _tb, "Name");
            txtPhone.DataBindings.Add("Text", _tb, "Phone");
            txtEmail.DataBindings.Add("Text", _tb, "Email");
            txtAddress.DataBindings.Add("Text", _tb, "Address");
            base.bindingData();
        }

        protected override void applyUIStrings()
        {
            lblID.Text = QuanLyThuVien.Resource.lblAuthorID;
            lblName.Text = QuanLyThuVien.Resource.lblName;
            lblAddress.Text = QuanLyThuVien.Resource.lblAddress;
            lblPhone.Text = QuanLyThuVien.Resource.lblPhone;
            lblDateofBirth.Text = QuanLyThuVien.Resource.lblPhone;
            base.applyUIStrings();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                if (int.TryParse(txtPhone.Text, out int _nSdt))
                {
                    _authorDAL.insertAuthorAsync(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, Convert.ToDateTime(dtpDateofBirth.Value), _ct.Token).ContinueWith((t) =>
                    {
                        loadData();
                        
                    });

                }
                else
                {
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
                }
                _ct.Dispose();
                _ct = null;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (checkValid())
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                if (int.TryParse(txtPhone.Text, out int _nSdt))
                {
                    _authorDAL.updateAuthorAsync(Convert.ToInt32(txtID.Text), txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, Convert.ToDateTime(dtpDateofBirth.Value), _ct.Token).ContinueWith((t) =>
                    {
                        loadData();

                        
                    });

                }
                else
                {
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
                }

                _ct.Dispose();
                _ct = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        private void exportToExcel(DataGridView pDgv)
        {
            exportToExcel(pDgv);
        }
    }
}
