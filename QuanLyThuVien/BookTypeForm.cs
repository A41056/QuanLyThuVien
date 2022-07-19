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
    public partial class BookTypeForm : FormBase
    {
        private BookTypeDAL bookTypeDAL;
        private CancellationTokenSource _ct = null;

        public BookTypeForm()
        {
            InitializeComponent();
        }

        protected override async Task loadData()
        {
            if (bookTypeDAL == null)
                bookTypeDAL = new BookTypeDAL();

            if (_ct == null)
                _ct = new CancellationTokenSource();

            dgvBookType.DataSource = await bookTypeDAL.loadData(_ct.Token);
            await base.loadData();
        }

        private bool checkValid()
        {
            if (String.IsNullOrEmpty(txtName.Text) ||
                String.IsNullOrEmpty(txtID.Text))
                return false;
            return true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //BaseControl.Instance.exportToExcel(dgvBookType);
        }

        protected override void bindingData()
        {
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();

            txtID.DataBindings.Add("Text", (dgvBookType.DataSource as DataTable), "Code");
            txtName.DataBindings.Add("Text", (dgvBookType.DataSource as DataTable), "Name");
            base.bindingData();
        }


        protected override void applyUIStrings()
        {
            lblID.Text = QuanLyThuVien.Resource.lblID;
            lblName.Text = QuanLyThuVien.Resource.lblName;
            
            if (dgvBookType.Columns.Count > 0)
            {
                dgvBookType.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
                dgvBookType.Columns[1].HeaderText = QuanLyThuVien.Resource.lblName;
            }
            base.applyUIStrings();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!checkValid())
            {
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            }
            else
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                bookTypeDAL.insertBookType(txtID.Text, txtName.Text, _ct.Token).ContinueWith((t) => 
                { 
                    loadData();
                    _ct.Dispose();
                    _ct = null;
                });
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!checkValid())
            {
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            }
            else
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                bookTypeDAL.updateBookType(txtID.Text, txtName.Text,_ct.Token).ContinueWith((t) =>
                {
                    loadData();
                    _ct.Dispose();
                    _ct = null;
                });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
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
