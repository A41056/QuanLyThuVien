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
    public partial class BookForm : Form
    {
        #region Properties
        private BookDAL _bookDAL = null;
        private AuthorDAL _authorDAL = null;
        private BookTypeDAL _bookTypeDAL = null;
        private PublishDAL _publishDAL = null;
        private int _nErrorRowIndex;
        private bool _isValidate = false;
        private CancellationTokenSource _ct = null;

        private int nPageIndex = 1, nPageSize = 10, nTotalRecord = 36;
        private double nPageCount;
        #endregion
        public BookForm()
        {
            InitializeComponent();
            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
            dtpPublishDate.CustomFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
        }

        #region Methods
        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (_bookDAL == null)
                _bookDAL = new BookDAL();


            updateControlState();

            try
            {
                loadData(nPageIndex, nPageSize).ContinueWith(async (_taskToContinue) =>
                {
                    if (dgvBook != null)
                        (dgvBook.DataSource as DataTable).Columns[0].Unique = true;

                    //nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());

                    loadAuthor();
                    loadPublishCompany();
                    loadTypeBook();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private async Task loadData(int pnPageIndex, int pnPageSize)
        {
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;

            var _tb = await _bookDAL.loadDataPagingAsync(pnPageIndex, pnPageSize);
            dgvBook.DataSource = _tb;

            btnPrevious.Enabled = true;
            btnNext.Enabled = true;

            pagingCalculation(nPageSize);
            bindingData(_tb);
            applyUIStrings();
        }

        private async Task loadTypeBook()
        {
            if (_bookTypeDAL == null)
                _bookTypeDAL = new BookTypeDAL();

            cbBookType.DataSource = await _bookTypeDAL.loadData();
            cbBookType.DisplayMember = "Name";
            cbBookType.ValueMember = "Code";
        }

        private async Task loadAuthor()
        {
            if (_authorDAL == null)
                _authorDAL = new AuthorDAL();

            cbAuthor.DataSource = await _authorDAL.loadDataAsync();
            cbAuthor.DisplayMember = "Name";
            cbAuthor.ValueMember = "ID";
        }

        private async Task loadPublishCompany()
        {
            if (_publishDAL == null)
                _publishDAL = new PublishDAL();

            cbPublisher.DataSource = await _publishDAL.loadData();
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
            cbAuthor.DataBindings.Add("Text", pDataSource, "Author Name", true, DataSourceUpdateMode.Never);
            cbPublisher.DataBindings.Add("Text", pDataSource, "Publish Name", true, DataSourceUpdateMode.Never);
            cbBookType.DataBindings.Add("Text", pDataSource, "Book Type Name", true, DataSourceUpdateMode.Never);
            dtpPublishDate.DataBindings.Add("Text", pDataSource, "PublishDate", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAmout.DataBindings.Add("Text", pDataSource, "Amount", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public async Task addNew()
        {
            var _tb = dgvBook.DataSource as DataTable;

            if (checkValid())
            {
                try
                {
                    if (_ct == null)
                        _ct = new CancellationTokenSource();

                    await _bookDAL.insertBookAsync
                        (_tb.Rows[dgvBook.CurrentCell.RowIndex].Field<string>("Code"),
                        _tb.Rows[dgvBook.CurrentCell.RowIndex].Field<string>("Name"),
                        Convert.ToInt32(cbPublisher.SelectedValue.ToString()),
                        Convert.ToInt32(cbAuthor.SelectedValue.ToString()),
                        cbBookType.SelectedValue.ToString(),
                        _tb.Rows[dgvBook.CurrentCell.RowIndex].Field<DateTime>("PublishDate"),
                        _tb.Rows[dgvBook.CurrentCell.RowIndex].Field<int>("Amount"),
                        _ct.Token);
                    nTotalRecord = Convert.ToInt32( await _bookDAL.getTotalRecord());
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
                        (_tb.Rows[dgvBook.CurrentCell.RowIndex].Field<string>("Code"),
                        _tb.Rows[dgvBook.CurrentCell.RowIndex].Field<string>("Name"),
                        Convert.ToInt32(cbPublisher.SelectedValue.ToString()),
                        Convert.ToInt32(cbAuthor.SelectedValue.ToString()),
                        cbBookType.SelectedValue.ToString(),
                        _tb.Rows[dgvBook.CurrentCell.RowIndex].Field<DateTime>("PublishDate"),
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

                await _bookDAL.deleteBookAsync(_tb.Rows[dgvBook.CurrentCell.RowIndex].Field<string>("Code"), _ct.Token);
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

        public bool checkValid()
        {
            if (string.IsNullOrEmpty(txtBookID.Text) ||
                string.IsNullOrEmpty(txtBookName.Text) ||
                string.IsNullOrEmpty(txtAmout.Text))
                return false;

            return true;
        }

        private void applyUIStrings()
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

            DataRow _row = _tb.AsEnumerable().Where(x => x.Field<string>("Code") == txtBookID.Text).FirstOrDefault();

            if (txtBookID.Modified)
            {
                _nErrorRowIndex = _tb.Rows.IndexOf(_row);
                
                if (_row != null)
                {
                    _isValidate = false;
                    _tb.Rows[_nErrorRowIndex].SetColumnError("Code", "BookCode must be unique.");
                    e.Cancel = true;
                }
                else if (string.IsNullOrEmpty(txtBookID.Text.Trim()))
                {
                    _nErrorRowIndex = dgvBook.CurrentCell.RowIndex;
                    _tb.Rows[_nErrorRowIndex].SetColumnError("Code", "BookCode was required.");
                    _isValidate = false;
                    e.Cancel = true;
                }
                else
                {
                    if (_nErrorRowIndex != -1)
                    {
                        _tb.Rows[_nErrorRowIndex].ClearErrors();
                        _isValidate = true;
                        e.Cancel = false;
                    }
                }

                updateControlState();
            }
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
                (dgvBook.DataSource as DataTable).Rows[_nErrorRowIndex].ClearErrors();
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
                return;
            else
                updatePaging(--nPageIndex, nPageSize);
        }
            
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (nPageIndex >= nPageCount)
                return;
            else
                updatePaging(++nPageIndex, nPageSize);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            nPageIndex = 1;
            updatePaging(1, 5);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            nPageIndex = 1;
            updatePaging(1, 10);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            nPageIndex = 1;
            updatePaging(1, 15);
        }

        private void pagingCalculation(int pnPageSize)
        {
            nPageSize = pnPageSize;
            nPageCount = Math.Ceiling((double)((decimal)nTotalRecord / pnPageSize));
            lblTotalRecord.Text = "|  " + nPageCount.ToString();
        }

        private void updatePaging(int pnPageIndex, int pnPageSize)
        {
            nPageSize = pnPageSize;

            lblPageIndex.Text = pnPageIndex.ToString();

            pagingCalculation(nPageSize);
            loadData(pnPageIndex, nPageSize);
        }
        #endregion Paging
    }
}
