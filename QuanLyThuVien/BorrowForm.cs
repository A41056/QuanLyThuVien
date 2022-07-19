using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class BorrowForm : FormBase
    {
        private BorrowBookDAL borrowBookDAL = null;
        private CancellationTokenSource _ct = null;

        public BorrowForm()
        {
            InitializeComponent();
        }

        protected override async Task loadData()
        {
            if (borrowBookDAL == null)
                borrowBookDAL = new BorrowBookDAL();

            if (_ct == null)
                _ct = new CancellationTokenSource();

            dgvBorrow.DataSource = await borrowBookDAL.loadDataAsync(_ct.Token);
            await base.loadData();
        }
        
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //BaseControl.Instance.exportToExcel(dgvBorrow);
        }

        protected override void bindingData()
        {
            txtID.DataBindings.Clear();
            txtBookID.DataBindings.Clear();
            txtReaderID.DataBindings.Clear();
            txtAuthorID.DataBindings.Clear();
            txtTicketDetailsID.DataBindings.Clear();
            txtAmount.DataBindings.Clear();
            dtpReturnDate.DataBindings.Clear();

            txtID.DataBindings.Add("Text", (dgvBorrow.DataSource as DataTable), "ID");
            txtBookID.DataBindings.Add("Text", (dgvBorrow.DataSource as DataTable), "BookCode");
            txtAuthorID.DataBindings.Add("Text", (dgvBorrow.DataSource as DataTable), "IDAuthor");
            txtReaderID.DataBindings.Add("Text", (dgvBorrow.DataSource as DataTable), "IDReader");
            txtTicketDetailsID.DataBindings.Add("Text", (dgvBorrow.DataSource as DataTable), "IDTicket");
            txtAmount.DataBindings.Add("Text", (dgvBorrow.DataSource as DataTable), "Amount");
            dtpReturnDate.DataBindings.Add("Text", (dgvBorrow.DataSource as DataTable), "ReturnDate");

            base.bindingData();
        }

        private bool checkValid()
        {
            if (String.IsNullOrEmpty(txtReaderID.Text) ||
                String.IsNullOrEmpty(txtBookID.Text))
                return false;
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_ct == null)
                _ct = new CancellationTokenSource();

            borrowBookDAL.deleteBorrowBook(Convert.ToInt32(txtID.Text), _ct.Token).ContinueWith((t) => 
            { 
                loadData();
                _ct.Dispose();
                _ct = null;
            });
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

                borrowBookDAL.updateBorrowBook(Convert.ToInt32(txtID.Text), txtBookID.Text, Convert.ToInt32(txtAuthorID.Text), Convert.ToInt32(txtReaderID.Text), Convert.ToInt32(txtAmount.Text), DateTime.Now, dtpReturnDate.Value,_ct.Token).ContinueWith((t) =>
                {
                    loadData();
                    _ct.Dispose();
                    _ct = null;
                });
            }
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

                borrowBookDAL.insertBorrowBook(txtBookID.Text, Convert.ToInt32(txtAuthorID.Text), Convert.ToInt32(txtReaderID.Text), Convert.ToInt32(txtAmount.Text), DateTime.Now, dtpReturnDate.Value,_ct.Token).ContinueWith((t) =>
                {
                    loadData();
                    _ct.Dispose();
                    _ct = null;
                });
            }

        }

        protected override void applyUIStrings()
        {
            lblID.Text = QuanLyThuVien.Resource.lblID;
            lblTicketDetailsID.Text = QuanLyThuVien.Resource.lblTicketDetailsID;
            lblBookID.Text = QuanLyThuVien.Resource.lblBookCode;
            lblAuthorID.Text = QuanLyThuVien.Resource.lblAuthorID;
            lblReaderID.Text = QuanLyThuVien.Resource.lblReaderID;
            lblAmount.Text = QuanLyThuVien.Resource.lblAmout;
            lblReturnDate.Text = QuanLyThuVien.Resource.lblReturnDate;

            if (dgvBorrow.Columns.Count > 0)
            {
                dgvBorrow.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
                dgvBorrow.Columns[1].HeaderText = QuanLyThuVien.Resource.lblTicketDetailsID;
                dgvBorrow.Columns[2].HeaderText = QuanLyThuVien.Resource.lblBookCode;
                dgvBorrow.Columns[3].HeaderText = QuanLyThuVien.Resource.lblAuthorID;
                dgvBorrow.Columns[4].HeaderText = QuanLyThuVien.Resource.lblReaderID;
                dgvBorrow.Columns[5].HeaderText = QuanLyThuVien.Resource.lblAmout;
                dgvBorrow.Columns[6].HeaderText = QuanLyThuVien.Resource.lblReturnDate;
            }

            base.applyUIStrings();
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
