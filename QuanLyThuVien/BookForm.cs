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
        private BorrowBookDAL _borrowBookDAL = null;
        private CancellationTokenSource _ct = null;
        private CancellationTokenSource _childCt = null;
        private int nPageIndex = 1, nPageSize = 10, nTotalRecord = 36;
        private double nPageCount;
        private List<GroupDescription> grpDes = new List<GroupDescription>();
        private GroupDescription grp = null;
        private List<string> zGroupDes = new List<string>();
        #endregion

        #region Methods
        public BookForm()
        {
            InitializeComponent();
            dtpPublishDate.CustomFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (_bookDAL == null)
                _bookDAL = new BookDAL();

            if (_ct == null)
                _ct = new CancellationTokenSource();

            loadData(nPageIndex, nPageSize,_ct.Token).ContinueWith((_t) =>
            {
                if (_t.IsFaulted)
                {
                    MessageBox.Show(_t.Exception.Message);
                }
                else if (_t.IsCanceled)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                }
                else if (_t.IsCompleted)
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            if (_t.Result != null)
                            {
                                resetSource(_t.Result);
                                //bindingData(dgvBook.DataSource);
                            }
                            applyUIStrings();
                        }));
                    }
                    else
                    {
                        applyUIStrings();
                    }
                }
            });

            Task.WhenAny(loadTypeBook(), loadAuthor(), loadPublishCompany()).ContinueWith((_taskToContinue) =>
            {
                if (_taskToContinue.IsFaulted)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                }
                else if (_taskToContinue.IsCanceled)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                }
            });

            
            btnAccept.Enabled = btnEdit.Enabled = btnCancel.Enabled = false;
            btnAccept.Visible = btnDeny.Visible = false;
        }



        private async Task<DataTable> loadData(int pnPageIndex, int pnPageSize, CancellationToken pCt)
        {
            nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());

            return await _bookDAL.loadDataPagingAsync(pnPageIndex, pnPageSize, pCt);
        }

        private void resetSource(Object pSource)
        {
            pagingCalculation(nPageSize);

            //if (dgvBook.DataSource != null)
            //    dgvBook.DataSource = null;

            //dgvBook.DataSource = pSource;
        }

        private async Task loadBorrowBook()
        {
            if (_borrowBookDAL == null)
                _borrowBookDAL = new BorrowBookDAL();
            
            if (_childCt == null)
            {
                _childCt = new CancellationTokenSource();
                //dgvChild.DataSource = await _borrowBookDAL.loadBorrowBookByCode(getCurrentRow()["Code"].ToString(), _childCt.Token);
            }
            else
            {
                _childCt.Cancel();
                _childCt.Dispose();
                _childCt = null;

                loadBorrowBook();
            }
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

        private void bindingData(object _source)
        {
            txtBookID.DataBindings.Clear();
            txtBookName.DataBindings.Clear();
            cbAuthor.DataBindings.Clear();
            cbPublisher.DataBindings.Clear();
            cbBookType.DataBindings.Clear();
            dtpPublishDate.DataBindings.Clear();
            txtAmout.DataBindings.Clear();

            txtBookID.DataBindings.Add("Text", _source, "Code", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBookName.DataBindings.Add("Text", _source, "Name", true);
            cbAuthor.DataBindings.Add("SelectedValue", _source, "Author ID", true);
            cbPublisher.DataBindings.Add("SelectedValue", _source, "Publish ID", true);
            cbBookType.DataBindings.Add("SelectedValue", _source, "Book Type ID", true);
            dtpPublishDate.DataBindings.Add("Text", _source, "PublishDate", false, DataSourceUpdateMode.OnPropertyChanged);
            txtAmout.DataBindings.Add("Text", _source, "Amount", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private int getCurrentRowIndex()
        {
            var _tb = dgvBook.DataSource as DataTable;

            BindingManagerBase _bm = dgvBook.BindingContext[_tb];
            DataRow _row = ((DataRowView)_bm.Current).Row;

            return _tb.Rows.IndexOf(_row);
        }

        private DataRow getCurrentRow()
        {
            var _tb = dgvBook.DataSource as DataTable;

            BindingManagerBase _bm = dgvBook.BindingContext[_tb];

            return ((DataRowView)_bm.Current).Row;
        }

        private async Task addNew()
        {
            try
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                await _bookDAL.insertBookAsync
                    (getCurrentRow().Field<string>("Code"),
                    getCurrentRow().Field<string>("Name"),
                    getCurrentRow().Field<int>("Publish ID"),
                    getCurrentRow().Field<int>("Author ID"),
                    getCurrentRow().Field<string>("Book Type ID"),
                    getCurrentRow().Field<DateTime>("PublishDate"),
                    getCurrentRow().Field<int>("Amount"),
                    _ct.Token);

                nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());

                _ct.Dispose();
                _ct = null;
            }
            catch (Exception ex)
            {
                _ct.Cancel();
                _ct.Dispose();
                _ct = null;
                MessageBox.Show(ex.Message);
            }
        }

        private async Task edit()
        {
            try
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                await _bookDAL.updateBookAsync
                    (getCurrentRow().Field<string>("Code"),
                    getCurrentRow().Field<string>("Name"),
                    getCurrentRow().Field<int>("Publish ID"),
                    getCurrentRow().Field<int>("Author ID"),
                    getCurrentRow().Field<string>("Book Type ID"),
                    getCurrentRow().Field<DateTime>("PublishDate"),
                    _ct.Token);

                _ct.Dispose();
                _ct = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task delete()
        {
            try
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                await _bookDAL.deleteBookAsync(getCurrentRow().Field<string>("Code"), _ct.Token);

                nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());

                nPageIndex = 1;
                lblPageIndex.Text = nPageIndex.ToString();

                _ct.Dispose();
                _ct = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected  void applyUIStrings()
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
            lblPerpage.Text = QuanLyThuVien.Resource.PerPage;

            if (dgvBook.Columns.Count > 0)
            {
                dgvBook.Columns[1].HeaderText = QuanLyThuVien.Resource.lblNumbericalOrder;
                dgvBook.Columns[2].HeaderText = QuanLyThuVien.Resource.lblBookCode;
                dgvBook.Columns[3].HeaderText = QuanLyThuVien.Resource.lblBookName;
                dgvBook.Columns[4].HeaderText = QuanLyThuVien.Resource.lblAuthorID;
                dgvBook.Columns[5].HeaderText = QuanLyThuVien.Resource.lblAuthorName;
                dgvBook.Columns[6].HeaderText = QuanLyThuVien.Resource.lblPublishID;
                dgvBook.Columns[7].HeaderText = QuanLyThuVien.Resource.lblPublishName;
                dgvBook.Columns[8].HeaderText = QuanLyThuVien.Resource.lblBookTypeID;
                dgvBook.Columns[9].HeaderText = QuanLyThuVien.Resource.lblBookTypeName;
                dgvBook.Columns[10].HeaderText = QuanLyThuVien.Resource.lblPublishDate;
                dgvBook.Columns[11].HeaderText = QuanLyThuVien.Resource.lblInventoryID;
                dgvBook.Columns[12].HeaderText = QuanLyThuVien.Resource.lblAmout;
            }
        }


        DataTable _presentTB = null;
        DataTable _nextTB = null;
        bool _reloadData = false;

        private void cacheAndDisplay(int pnPageIndex)
        {
            if (!chxCacheData.Checked)
            {
                _reloadData = true;
                loadData(pnPageIndex, nPageSize, _ct.Token).ContinueWith((t) =>
                {
                    if (t.IsFaulted)
                    {
                        MessageBox.Show(t.Exception.Message);
                    }
                    else if (t.IsCompleted)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                if (t.Result != null)
                                {
                                    resetSource(t.Result);
                                }
                            }));
                        }
                    }
                });
            }
            else
            {
                _reloadData = false;

                if (_presentTB == null)
                    _presentTB = dgvBook.DataSource as DataTable;

                loadData(pnPageIndex, nPageSize, _ct.Token).ContinueWith((t) =>
                {
                    if (t.IsFaulted)
                    {
                        MessageBox.Show(t.Exception.Message);
                    }
                    else if (t.IsCanceled)
                    {
                        MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                    }
                    else if (t.IsCompleted)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                if (t.Result != null)
                                {
                                    if (_nextTB == null)
                                        _nextTB = t.Result;

                                    _presentTB.Merge(_nextTB);
                                    _nextTB.Dispose();

                                    pagingCalculation(nPageSize);
                                }
                            }));
                        }
                    }
                });
            }

            if (_presentTB != null && _reloadData)
            {
                _presentTB.Dispose();
                _reloadData = false;
            }
        }


        #endregion Methods

        #region Click Event
        private void dgvBook_Click(object sender, EventArgs e)
        {
            loadBorrowBook().ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    MessageBox.Show(t.Exception.Message);
            });
        }

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
            var _tb = dgvBook.DataSource as DataTable;
            DataRow _row = _tb.NewRow();
            _row["Code"] = !Convert.IsDBNull("Code");
            _row["Author ID"] = Convert.IsDBNull("Author ID");
            _row["Publish ID"] = Convert.IsDBNull("Publish ID");
            _row["Book Type ID"] = Convert.IsDBNull("Book Type ID");
            _row["Inventory ID"] = Convert.IsDBNull("Inventory ID");
            _tb.Rows.Add(_row);

            txtBookID.Focus();

            btnAccept.Visible = btnDeny.Visible = true;
            btnAccept.Enabled = btnNew.Enabled
            = btnEdit.Enabled = btnDelete.Enabled
            = btnPrevious.Enabled = btnNew.Enabled
            = btn5.Enabled = btn10.Enabled = btn15.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            addNew().ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                    loadData(nPageIndex, nPageSize, _ct.Token);
                }
                else if (t.IsCanceled)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                    loadData(nPageIndex, nPageSize, _ct.Token);
                }
                else if (t.IsCompleted)
                {
                    if (_ct == null)
                        _ct = new CancellationTokenSource();

                    loadData(nPageIndex, nPageSize, _ct.Token).ContinueWith((_t) =>
                    {
                        if (_t.IsFaulted)
                        {
                            MessageBox.Show(t.Exception.Message);
                        }
                        else if (_t.IsCompleted)
                        {
                            if (InvokeRequired)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    if (_t.Result != null)
                                        resetSource(_t.Result);

                                }));
                            }
                        }
                    }); ;
                }
            });
            btnAccept.Enabled = btnEdit.Enabled = btnCancel.Enabled = false;
            btnAccept.Visible = btnDeny.Visible = false;
            btnDelete.Enabled = btnNew.Enabled = true;
            btnPrevious.Enabled = btnNew.Enabled = btn5.Enabled = btn10.Enabled = btn15.Enabled = true;
            bindingData(dgvBook.DataSource);
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            btnAccept.Visible = btnDeny.Visible = false;

            btnNew.Enabled = btnDelete.Enabled
            = btnPrevious.Enabled = btnNew.Enabled
            = btn5.Enabled = btn10.Enabled = btn15.Enabled = true;

            btnEdit.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            edit().ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                else if (t.IsCanceled)
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                else if (t.IsCompleted)
                {
                    loadData(nPageIndex, nPageSize, _ct.Token).ContinueWith((_t) =>
                    {
                        if (_t.IsFaulted)
                        {
                            MessageBox.Show(t.Exception.Message);
                        }
                        else if (_t.IsCompleted)
                        {
                            if (InvokeRequired)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    if (_t.Result != null)
                                        resetSource(_t.Result);

                                }));
                            }
                        }
                    });
                }
            });
            btnEdit.Enabled = btnCancel.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete().ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                else if (t.IsCanceled)
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                else if (t.IsCompleted)
                {
                    loadData(nPageIndex, nPageSize, _ct.Token).ContinueWith((_t) =>
                    {
                        if (_t.IsFaulted)
                        {
                            MessageBox.Show(t.Exception.Message);
                        }
                        else if (_t.IsCompleted)
                        {
                            if (InvokeRequired)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    if (_t.Result != null)
                                        resetSource(_t.Result);

                                }));
                            }
                        }
                    });
                }
            });
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //BaseControl.Instance.exportToExcel(dgvBook);
        }

        //private void btnExport_Click(object sender, EventArgs e)
        //{
        //    dgvBook.PrintGrid("BookForm", PrintGridFlags.FitToPageWidth | PrintGridFlags.ShowPreviewDialog, "BookForm\t\t" + String.Format(DateTime.Now.ToString(), "d"), "\t\tPage {0} of {1}");
        //    System.Drawing.Printing.PrintDocument pd = dgvBook.PrintParameters.PrintDocument;

        //    // Set up the page (landscape, 1.5" left margin).
        //    pd.DefaultPageSettings.Landscape = true;
        //    pd.DefaultPageSettings.Margins.Left = 150;

        //    // Set up the header and footer fonts.
        //    dgvBook.PrintParameters.HeaderFont = new Font("Arial Black", 14, FontStyle.Bold);
        //    dgvBook.PrintParameters.FooterFont = new Font("Arial Narrow", 8, FontStyle.Italic);
        //}

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
        
        int _nErrorRowIndex = -1;

        private void txtBookID_Validating(object sender, CancelEventArgs e)
        {
            var _tb = dgvBook.DataSource as DataTable;
            if (_tb != null)
            {
                _tb.PrimaryKey = new DataColumn[] { _tb.Columns["Code"] };

                BindingManagerBase _bm = dgvBook.BindingContext[_tb];

                DataRow _row = _tb.Rows.Find(((DataRowView)_bm.Current).Row.Field<string>("Code"));
                Trace.WriteLine(((DataRowView)_bm.Current).Row.Field<string>("Code"));
                if (txtBookID.Modified)
                {
                    if (_row != null)
                    {
                        _row.SetColumnError("Code", "BookCode must be unique.");
                        MessageBox.Show("BookCode must be unique");
                        _nErrorRowIndex = _tb.Rows.IndexOf(_row);
                        e.Cancel = true;
                    }
                    else if (string.IsNullOrEmpty(txtBookID.Text))
                    {
                        e.Cancel = true;
                        MessageBox.Show("BookCode not allow null.");
                    }
                    else if (_row == null && _nErrorRowIndex != -1)
                    {
                        _tb.Rows[_nErrorRowIndex].ClearErrors();
                    }

                    if (string.Compare(txtBookName.Text, string.Empty, false) != 0 && string.Compare(txtAmout.Text, string.Empty, false) != 0)
                        btnAccept.Enabled = true;
                }
            }
        }

        private void txtAmout_Validating(object sender, CancelEventArgs e)
        {
            if (txtAmout.Modified)
                btnEdit.Enabled = true;
            if (string.Compare(txtBookName.Text, string.Empty, false) != 0 && string.Compare(txtBookID.Text, string.Empty, false) != 0 && string.Compare(txtAmout.Text, string.Empty, false) != 0)
                btnAccept.Enabled = true;
        }

        private void txtBookName_Validating(object sender, CancelEventArgs e)
        {
            if (txtBookName.Modified)
                btnEdit.Enabled = true;
            if (string.Compare(txtBookName.Text, string.Empty, false) != 0 && string.Compare(txtBookID.Text, string.Empty, false) != 0 && string.Compare(txtAmout.Text, string.Empty, false) != 0)
                btnAccept.Enabled = true;
        }

        private void dgvBook_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("BookCode must be unique");
                (dgvBook.DataSource as DataTable).Rows[getCurrentRowIndex()].ClearErrors();
            }
        }

        #endregion Validating

        #region Paging
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = false;
            if (nPageIndex != 1)
            {
                btnPrevious.Enabled = true;
            }
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            if (nPageIndex < nPageCount)
            {
                btnNext.Enabled = true;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            nPageIndex = 1;

            var _btn = sender as Button;
            if (_btn == null || !_btn.Name.StartsWith("btn"))
                return;

            _btn.Enabled = btnPrevious.Enabled = btnNext.Enabled = false;
            pagingCalculation(int.Parse(_btn.Name.Substring("btn".Length)));


            loadData(1, int.Parse(_btn.Name.Substring("btn".Length)), _ct.Token).ContinueWith((t) =>
            {
                if (t.IsFaulted)
                {
                    MessageBox.Show("Lỗi khi nhấn chọn page count");
                }
                else if (t.IsCompleted)
                {
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            _btn.Enabled = btnPrevious.Enabled = btnNext.Enabled = true;

                            if (t.Result != null)
                            {
                                resetSource(t.Result);
                                bindingData(t.Result);
                            }
                        }));
                    }
                }
            });
        }

        private void pagingCalculation(int pnPageSize)
        {
            nPageSize = pnPageSize;
            nPageCount = Math.Ceiling((double)((decimal)nTotalRecord / pnPageSize));
            lblTotalRecord.Text = "|  " + nPageCount.ToString();
            lblPageIndex.Text = nPageIndex.ToString();

            if (nPageIndex == 1)
                btnPrevious.Enabled = false;
            else if (nPageIndex >= nPageCount)
                btnNext.Enabled = false;
            else
                btnPrevious.Enabled = btnNext.Enabled = true;
        }

        #endregion Paging
    }
}
