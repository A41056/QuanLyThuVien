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
    public partial class FormBase : Form   
    {
        private CancellationTokenSource _ct = null;
        public FormBase()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }
        
        protected virtual void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }
        
        protected virtual bool checkValid()
        {
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPhone.Text))
                return false;
            return true;
        }

        
        protected virtual void exportToExcel(DataGridView pDgv)
        {
            if (pDgv.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application _excl = new Microsoft.Office.Interop.Excel.Application();
                _excl.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i <= pDgv.Columns.Count; i++)
                {
                    _excl.Cells[1, i] = pDgv.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < pDgv.Rows.Count; i++)
                {
                    for (int j = 0; j < pDgv.Columns.Count; j++)
                    {
                        _excl.Cells[i + 2, j + 1] = pDgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                _excl.Columns.AutoFit();
                _excl.Visible = true;
            }
        }

        protected virtual void btnExcel_Click(object sender, EventArgs e)
        {
            exportToExcel(dgvBase);
        }

        protected virtual async Task loadData()
        {
            await BaseDAL.Instance.loadDataAsync().ContinueWith(t => bindingData(dgvBase));
        }

        protected virtual void FormBase_Load(object sender, EventArgs e)
        {
            loadData().ContinueWith((t) => 
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        bindingData(dgvBase);
                        applyUIStrings();
                    }));
                }
                else
                {
                    bindingData(dgvBase);
                    applyUIStrings();
                }
            });
        }

        protected virtual void bindingData(DataGridView pDgv)
        {
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            dtpDateofBirth.DataBindings.Clear();

            txtID.DataBindings.Add("Text", (pDgv.DataSource as DataTable), "ID", true, DataSourceUpdateMode.Never);
            txtName.DataBindings.Add("Text", (pDgv.DataSource as DataTable), "Name");
            txtEmail.DataBindings.Add("Text", (pDgv.DataSource as DataTable), "Email");
            txtPhone.DataBindings.Add("Text", (pDgv.DataSource as DataTable), "Phone");
            txtAddress.DataBindings.Add("Text", (pDgv.DataSource as DataTable), "Address");
            dtpDateofBirth.DataBindings.Add("Text", (pDgv.DataSource as DataTable), "Birth");
        }


        protected virtual void applyUIStrings()
        {
            lblID.Text = QuanLyThuVien.Resource.lblID;
            lblName.Text = QuanLyThuVien.Resource.lblName;
            lblAddress.Text = QuanLyThuVien.Resource.lblAddress;
            lblPhone.Text = QuanLyThuVien.Resource.lblPhone;
            lblDateofBirth.Text = QuanLyThuVien.Resource.lblDateOfBirth;

            if (dgvBase.Columns.Count > 0)
            {
                dgvBase.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
                dgvBase.Columns[1].HeaderText = QuanLyThuVien.Resource.lblName;
                dgvBase.Columns[2].HeaderText = QuanLyThuVien.Resource.lblAddress;
                dgvBase.Columns[3].HeaderText = "Email";
                dgvBase.Columns[4].HeaderText = QuanLyThuVien.Resource.lblPhone;
                dgvBase.Columns[5].HeaderText = QuanLyThuVien.Resource.lblDateOfBirth;
            }
        }

        protected virtual void btnNew_Click(object sender, EventArgs e)
        {
            //if (checkValid())
            //{
            //    if (_ct == null)
            //        _ct = new CancellationTokenSource();

            //    if (int.TryParse(txtPhone.Text, out int _nSdt))
            //    {
            //        T.insertAuthorAsync(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, Convert.ToDateTime(dtpDateofBirth.Value), _ct.Token).ContinueWith((t) => 
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

        protected virtual void btnEdit_Click(object sender, EventArgs e)
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

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            if (_ct != null)
            {
                _ct.Cancel();
                _ct.Dispose();
                _ct = null;
            }
        }
    }
}
