using Microsoft.Win32;
using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
    public partial class BookForm : FormBase
    {
        #region Properties
        private BookDAL _bookDAL = null;
        private AuthorDAL _authorDAL = null;
        private BookTypeDAL _bookTypeDAL = null;
        private PublishDAL _publishDAL = null;
        private bool _isValidate = false;
        private CancellationTokenSource _ct = null;

        private int nPageIndex = 1, nPageSize = 10, nTotalRecord = 36;
        private double nPageCount;
        #endregion


        #region Methods
        public BookForm()
        {
            InitializeComponent();
            dtpPublishDate.CustomFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (_bookDAL == null)
                _bookDAL = new BookDAL();

            updateControlState();

            Task.WhenAll(loadData(nPageIndex, nPageSize), loadTypeBook(), loadAuthor(), loadPublishCompany()).ContinueWith((_taskToContinue) =>
            {
                if (_taskToContinue.IsFaulted)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                }
                else if (_taskToContinue.IsCanceled)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                }
                else
                {
                    return;
                }
            });
        }

        private async Task loadData(int pnPageIndex, int pnPageSize)
        {
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;

            if (_ct == null)
                _ct = new CancellationTokenSource();

            var _tb = await _bookDAL.loadDataPagingAsync(pnPageIndex, pnPageSize, _ct.Token);
            dgvBook.DataSource = _tb;

            nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());

            btnPrevious.Enabled = true;
            btnNext.Enabled = true;

            pagingCalculation(pnPageSize);
            bindingData(_tb);
            applyUIStrings();
        }

        private async Task loadTypeBook()
        {
            if (_bookTypeDAL == null)
                _bookTypeDAL = new BookTypeDAL();

            cbBookType.DataSource = await _bookTypeDAL.loadData(_ct.Token);
            cbBookType.DisplayMember = "Name";
            cbBookType.ValueMember = "Code";
        }

        private async Task loadAuthor()
        {
            if (_authorDAL == null)
                _authorDAL = new AuthorDAL();

            cbAuthor.DataSource = await _authorDAL.loadDataAsync(_ct.Token);
            cbAuthor.DisplayMember = "Name";
            cbAuthor.ValueMember = "ID";
        }

        private async Task loadPublishCompany()
        {
            if (_publishDAL == null)
                _publishDAL = new PublishDAL();

            cbPublisher.DataSource = await _publishDAL.loadDataAsync(_ct.Token);
            cbPublisher.DisplayMember = "Name";
            cbPublisher.ValueMember = "ID";
        }

        private void bindingData(DataTable pDataSource)
        {
            txtBookID.DataBindings.Clear();
            txtBookName.DataBindings.Clear();
            cbAuthor.DataBindings.Clear();
            cbPublisher.DataBindings.Clear();
            cbBookType.DataBindings.Clear();
            dtpPublishDate.DataBindings.Clear();
            txtAmout.DataBindings.Clear();

            txtBookID.DataBindings.Add("Text", pDataSource, "Code", true, DataSourceUpdateMode.OnValidation);
            txtBookName.DataBindings.Add("Text", pDataSource, "Name", true);
            cbAuthor.DataBindings.Add("Text", pDataSource, "Author Name", true);
            cbPublisher.DataBindings.Add("Text", pDataSource, "Publish Name", true);
            cbBookType.DataBindings.Add("Text", pDataSource, "Book Type Name", true);
            dtpPublishDate.DataBindings.Add("Text", pDataSource, "PublishDate", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAmout.DataBindings.Add("Text", pDataSource, "Amount", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private int getCurrentRow()
        {
            var _tb = dgvBook.DataSource as DataTable;

            BindingManagerBase _bm = dgvBook.BindingContext[dgvBook.DataSource];

            DataRow _row = ((DataRowView)_bm.Current).Row;

            int _nRowIndex = _tb.Rows.IndexOf(_row);

            return _nRowIndex;
        }

        private async Task addNew()
        {
            var _tb = dgvBook.DataSource as DataTable;
            BindingManagerBase _bm = dgvBook.BindingContext[dgvBook.DataSource];
            DataRow _row = ((DataRowView)_bm.Current).Row;

            if (checkValid())
            {
                try
                {
                    if (_ct == null)
                        _ct = new CancellationTokenSource();
                    
                    await _bookDAL.insertBookAsync
                        (_row.Field<string>("Code"),
                        _row.Field<string>("Name"),
                        Convert.ToInt32(cbPublisher.SelectedValue.ToString()),
                        Convert.ToInt32(cbAuthor.SelectedValue.ToString()),
                        cbBookType.SelectedValue.ToString(),
                        _row.Field<DateTime>("PublishDate"),
                        _row.Field<int>("Amount"),
                        _ct.Token);

                    nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());

                    await loadData(nPageIndex, nPageSize);

                    _ct.Dispose();
                    _ct = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async Task edit()
        {
            var _tb = dgvBook.DataSource as DataTable;

            if (checkValid())
            {
                try
                {
                    if (_ct == null)
                        _ct = new CancellationTokenSource();

                    await _bookDAL.updateBookAsync
                        (_tb.Rows[getCurrentRow()].Field<string>("Code"),
                        _tb.Rows[getCurrentRow()].Field<string>("Name"),
                        Convert.ToInt32(cbPublisher.SelectedValue.ToString()),
                        Convert.ToInt32(cbAuthor.SelectedValue.ToString()),
                        cbBookType.SelectedValue.ToString(),
                        _tb.Rows[getCurrentRow()].Field<DateTime>("PublishDate"),
                        _ct.Token);
                    await loadData(nPageIndex, nPageSize);

                    _ct.Dispose();
                    _ct = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async Task delete()
        {
            var _tb = dgvBook.DataSource as DataTable;

            try
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                await _bookDAL.deleteBookAsync(_tb.Rows[getCurrentRow()].Field<string>("Code"), _ct.Token);

                nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());

                nPageIndex = 1;
                lblPageIndex.Text = nPageIndex.ToString();

                await loadData(1, nPageSize);

                _ct.Dispose();
                _ct = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool checkValid()
        {
            if (string.IsNullOrEmpty(txtBookID.Text) ||
                string.IsNullOrEmpty(txtBookName.Text) ||
                string.IsNullOrEmpty(txtAmout.Text))
                return false;

            return true;
        }

        protected override void applyUIStrings()
        {
            lblID.Text = QuanLyThuVien.Resource.lblBookCode;
            lblName.Text = QuanLyThuVien.Resource.lblName;
            lblPublish.Text = QuanLyThuVien.Resource.lblPublishName;
            lblAuthor.Text = QuanLyThuVien.Resource.lblAuthorName;
            lblBookType.Text = QuanLyThuVien.Resource.lblBookTypeName;
            lblPublishDate.Text = QuanLyThuVien.Resource.lblPublishDate;
            lblAmount.Text = QuanLyThuVien.Resource.lblAmout;
            btnPrevious.Text = QuanLyThuVien.Resource.btnPrevious;
            btnNext.Text = QuanLyThuVien.Resource.btnNext;

            if (dgvBook.Columns.Count > 0)
            {
                dgvBook.Columns[0].HeaderText = QuanLyThuVien.Resource.lblNumbericalOrder;
                dgvBook.Columns[1].HeaderText = QuanLyThuVien.Resource.lblBookCode;
                dgvBook.Columns[2].HeaderText = QuanLyThuVien.Resource.lblBookName;
                dgvBook.Columns[3].HeaderText = QuanLyThuVien.Resource.lblAuthorID;
                dgvBook.Columns[4].HeaderText = QuanLyThuVien.Resource.lblAuthorName;
                dgvBook.Columns[5].HeaderText = QuanLyThuVien.Resource.lblPublishID;
                dgvBook.Columns[6].HeaderText = QuanLyThuVien.Resource.lblPublishName;
                dgvBook.Columns[7].HeaderText = QuanLyThuVien.Resource.lblBookTypeID;
                dgvBook.Columns[8].HeaderText = QuanLyThuVien.Resource.lblBookTypeName;
                dgvBook.Columns[9].HeaderText = QuanLyThuVien.Resource.lblPublishDate;
                dgvBook.Columns[10].HeaderText = QuanLyThuVien.Resource.lblInventoryID;
                dgvBook.Columns[11].HeaderText = QuanLyThuVien.Resource.lblAmout;
            }
            base.applyUIStrings();
        }

        #endregion Methods

        #region Click Event
        private void cbPublisher_Click(object sender, EventArgs e)
        {
            cbPublisher.DataSource = null;
            loadPublishCompany();
        }

        private void cbAuthor_Click(object sender, EventArgs e)
        {
            cbAuthor.DataSource = null;
            loadAuthor();
        }

        private void cbBookType_Click(object sender, EventArgs e)
        {
            cbBookType.DataSource = null;
            loadTypeBook();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            addNew().ContinueWith(t => loadData(nPageIndex, nPageSize));
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            edit().ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                else if (t.IsCanceled)
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                else
                    return;
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete().ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                else if (t.IsCanceled)
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                else
                    return;
            });
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //BaseControl.Instance.exportToExcel(dgvBook);
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

        #endregion Click Event

        #region Validating
        private void txtBookID_Validating(object sender, CancelEventArgs e)
        {
            var _tb = dgvBook.DataSource as DataTable;

            _tb.PrimaryKey = new DataColumn[] { _tb.Columns["Code"] };
            _tb.Columns[0].Unique = true;

            BindingManagerBase _bm = dgvBook.BindingContext[dgvBook.DataSource];

            DataRow _row = _tb.Rows.Find(((DataRowView)_bm.Current).Row.ItemArray[1]);

            int _nRowIndex = _tb.Rows.IndexOf(_row);

            if (txtBookID.Modified)
            {
                if (_row != null)
                {
                    _isValidate = false;
                    _tb.Rows[_nRowIndex].SetColumnError("Code", "BookCode must be unique.");
                    e.Cancel = true;
                    _row = null;
                }
                else if (string.IsNullOrEmpty(txtBookID.Text.Trim()))
                {
                    _nRowIndex = dgvBook.CurrentCell.RowIndex;
                    _tb.Rows[_nRowIndex].SetColumnError("Code", "BookCode was required.");
                    _isValidate = false;
                    e.Cancel = true;
                }
                else if (_row == null)
                {
                    if (_nRowIndex != -1)
                    {
                        _tb.Rows[_nRowIndex].ClearErrors();
                        _isValidate = true;
                        e.Cancel = false;
                    }
                }
            }
            updateControlState();

            _tb.Dispose();
        }

        private void updateControlState()
        {
            if (_isValidate)
                btnNew.Enabled = btnEdit.Enabled = true;
            else
                btnNew.Enabled = btnEdit.Enabled = false;
        }

        private void dgvBook_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("BookCode must be unique");
                (dgvBook.DataSource as DataTable).Rows[getCurrentRow()].ClearErrors();
            }
        }

        private void txtBookName_Validating(object sender, CancelEventArgs e)
        {
            if (txtBookName.Modified)
            {
                if (string.IsNullOrEmpty(txtBookName.Text))
                {
                    _isValidate = false;
                    updateControlState();
                }
                else
                {
                    _isValidate = true;
                    updateControlState();
                }
            }
        }

        private void txtAmout_Validating(object sender, CancelEventArgs e)
        {
            if (txtAmout.Modified)
            {
                if (string.IsNullOrEmpty(txtAmout.Text) || !int.TryParse(txtAmout.Text, out int _sdt))
                {
                    _isValidate = false;
                    updateControlState();
                }
                else
                {
                    _isValidate = true;
                    updateControlState();
                }
            }
        }
        
        #endregion Validating

        #region Paging
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (nPageIndex == 1)
            { 
                return;
            }
            else
            {
                nPageIndex--;
                pagingCalculation(nPageSize);
                loadData(nPageIndex, nPageSize);
            }
        }
            
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (nPageIndex >= nPageCount)
            {
                return;
            }
            else
            {
                nPageIndex++;
                pagingCalculation(nPageSize);
                loadData(nPageIndex, nPageSize);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestForm testForm = new TestForm();
            testForm.ShowDialog();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var _testFrm = new TestForm();
            _testFrm.ShowDialog();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            nPageIndex = 1;

            var _btn = sender as Button;
            if (_btn == null || !_btn.Name.StartsWith("btn"))
                return;

            pagingCalculation(int.Parse(_btn.Name.Substring("btn".Length)));
            loadData(1, int.Parse(_btn.Name.Substring("btn".Length)));
        }

        private void pagingCalculation(int pnPageSize)
        {
            nPageSize = pnPageSize;
            nPageCount = Math.Ceiling((double)((decimal)nTotalRecord / pnPageSize));
            lblTotalRecord.Text = "|  " + nPageCount.ToString();
            lblPageIndex.Text = nPageIndex.ToString();
        }

        #endregion Paging
    }
}
