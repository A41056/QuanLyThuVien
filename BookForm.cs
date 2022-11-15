using C1.Win.C1FlexGrid;
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
using GroupDescription = C1.Win.C1FlexGrid.GroupDescription;

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
        private int nPageIndex = 1, nPageSize = 10, nTotalRecord = 36;
        private double nPageCount;
        private CellStyle _cs;
        private CellStyle _afterMerge;
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

            Task.WhenAll(loadTypeBook(), loadAuthor(), loadPublishCompany()).ContinueWith((_taskToContinue) =>
            {
                if (_taskToContinue.IsFaulted)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                }
                else if (_taskToContinue.IsCanceled)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                }
                else if (_taskToContinue.IsCompleted)
                {
                    loadData(nPageIndex, nPageSize).ContinueWith((_t) =>
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
                                        bindingData(_t.Result);
                                    }
                                    applyUIStrings();
                                }));
                            }
                            else
                            {
                                bindingData(_t.Result);
                                applyUIStrings();
                            }
                        }
                    });
                }
            });
            _cs = dgvBook.Styles.Add("LessThan50");
            _cs.BackColor = Color.Red;
            
            _afterMerge = dgvBook.Styles.Add("AfterMerge");
            _afterMerge.BackColor = Color.Blue;

            btnAccept.Enabled = btnEdit.Enabled = btnCancel.Enabled = false;
            btnAccept.Visible = btnDeny.Visible = false;
            customizeGridView();
        }

        private void customizeGridView()
        {
            dgvBook.AutoSizeCols();
            dgvBook.AutoSizeRows();
            dgvBook.AllowEditing =  false;
            dgvBook.AllowFiltering = true;
            dgvBook.SelectionMode = dgvChild.SelectionMode = SelectionModeEnum.Row;
            dgvBook.ColumnPickerInfo.ShowToolButton = true;
            dgvBook.DrawMode = DrawModeEnum.OwnerDraw;
            dgvBook.ColumnContextMenuEnabled = true;
            dgvBook.Subtotal(AggregateEnum.Sum, 0, 1, 12, "Total amount: {0}");
            dgvBook.HideGroupedColumns = true;
            dgvBook.AllowMerging = AllowMergingEnum.Custom;

            searchPanel.SetC1FlexGridSearchPanel(dgvBook, searchPanel);
            searchPanel.HighlightSearchResults = true;
            searchPanel.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always;
            searchPanel.Watermark = "Type to search...";
            searchPanel.SearchDelay = 2;
        }

        private async Task<DataTable> loadData(int pnPageIndex, int pnPageSize)
        {
            if (_ct == null)
                _ct = new CancellationTokenSource();

            var _tb = await _bookDAL.loadDataPagingAsync(pnPageIndex, pnPageSize);

            nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());
            return _tb;
        }

        private void resetSource(Object pSource)
        {
            pagingCalculation(nPageSize);

            btnPrevious.Enabled = btnNew.Enabled = false;

            dgvBook.DataSource = pSource;

            if (nPageIndex != 1)
                btnPrevious.Enabled = true;
            else if (nPageIndex < nPageCount)
                btnNext.Enabled = true;

            btnNew.Enabled = btnDelete.Enabled = true;
        }

        private async Task loadBorrowBook()
        {
            if (_borrowBookDAL == null)
                _borrowBookDAL = new BorrowBookDAL();
            
            if (_ct == null)
                _ct = new CancellationTokenSource();

            var _tb = await _borrowBookDAL.loadBorrowBookByCode(getCurrentRow()["Code"].ToString(),_ct.Token);

            dgvChild.DataSource = _tb;
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
            BindingManagerBase _bm = dgvBook.BindingContext[dgvBook.DataSource];
            DataRow _row = ((DataRowView)_bm.Current).Row;

            try
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                await _bookDAL.insertBookAsync
                    (_row.Field<string>("Code"),
                    _row.Field<string>("Name"),
                    _row.Field<int>("Publish ID"),
                    _row.Field<int>("Author ID"),
                    _row.Field<string>("Book Type ID"),
                    _row.Field<DateTime>("PublishDate"),
                    _row.Field<int>("Amount"),
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
                await loadData(nPageIndex, nPageSize);
            }
        }

        private async Task edit()
        {
            BindingManagerBase _bm = dgvBook.BindingContext[dgvBook.DataSource];
            DataRow _row = ((DataRowView)_bm.Current).Row;

            try
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                await _bookDAL.updateBookAsync
                    (_row.Field<string>("Code"),
                    _row.Field<string>("Name"),
                    _row.Field<int>("Publish ID"),
                    _row.Field<int>("Author ID"),
                    _row.Field<string>("Book Type ID"),
                    _row.Field<DateTime>("PublishDate"),
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
            BindingManagerBase _bm = dgvBook.BindingContext[dgvBook.DataSource];
            DataRow _row = ((DataRowView)_bm.Current).Row;

            try
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                await _bookDAL.deleteBookAsync(_row.Field<string>("Code"), _ct.Token);

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
            chxPublishID.Text = QuanLyThuVien.Resource.chxPublishID;
            chxCacheData.Text = QuanLyThuVien.Resource.chxCacheData;
            chxBookTypeCode.Text = QuanLyThuVien.Resource.chxBookTypeCode;
            chxAuthor.Text = QuanLyThuVien.Resource.chxAuthor;

            if (dgvBook.Cols.Count > 0)
            {
                dgvBook.Cols[1].Caption = QuanLyThuVien.Resource.lblNumbericalOrder;
                dgvBook.Cols[2].Caption = QuanLyThuVien.Resource.lblBookCode;
                dgvBook.Cols[3].Caption = QuanLyThuVien.Resource.lblBookName;
                dgvBook.Cols[4].Caption = QuanLyThuVien.Resource.lblAuthorID;
                dgvBook.Cols[5].Caption = QuanLyThuVien.Resource.lblAuthorName;
                dgvBook.Cols[6].Caption = QuanLyThuVien.Resource.lblPublishID;
                dgvBook.Cols[7].Caption = QuanLyThuVien.Resource.lblPublishName;
                dgvBook.Cols[8].Caption = QuanLyThuVien.Resource.lblBookTypeID;
                dgvBook.Cols[9].Caption = QuanLyThuVien.Resource.lblBookTypeName;
                dgvBook.Cols[10].Caption = QuanLyThuVien.Resource.lblPublishDate;
                dgvBook.Cols[11].Caption = QuanLyThuVien.Resource.lblInventoryID;
                dgvBook.Cols[12].Caption = QuanLyThuVien.Resource.lblAmout;
            }
        }


        private void dgvBook_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            if ((e.Row >= dgvBook.Rows.Fixed) & (e.Col == (dgvBook.Cols.Fixed - 1)) && !dgvBook.Rows[e.Row].IsNode) // Draw Fixed Row Number
            {
                e.Text = ((e.Row - dgvBook.Rows.Fixed) + 1).ToString();
            }

            if (dgvBook.Cols["PublishDate"] != null && dgvBook.Cols["PublishDate"].Index == e.Col && e.Row >= dgvBook.Rows.Fixed) // Draw Publish Date Display
            {
                if (dgvBook[e.Row, e.Col] != null)
                    e.Text = "PublishDate: " + dgvBook[e.Row, e.Col].ToString();
            }

            if (dgvBook.Cols["Amount"] != null && dgvBook.Cols["Amount"].Index == e.Col && e.Row >= dgvBook.Rows.Fixed) //Draw Red Cell
            {
                DataRowView _drv = (DataRowView)dgvBook.Rows[e.Row].DataSource;
                if (_drv == null) return;
                DataRow _dr = _drv.Row;

                if (_dr["Amount"] != null && !Convert.IsDBNull(_dr["Amount"]) && Convert.ToInt32(_dr["Amount"]) <= 50)
                    e.Style = _cs;
            }
        }

        private void groupByColumn(CheckBox pChx, string pzColumnName)
        {
            if (pChx.Checked)
            {
                if (grpDes.Find(g => g.PropertyName == pzColumnName) == null)
                {
                    grp = new GroupDescription(pzColumnName, ListSortDirection.Ascending, true);
                    grpDes.Add(grp);
                    grp = null;
                }

                dgvBook.GroupDescriptions = grpDes;
                dgvBook.Cols["Amount"].GroupExpression = "=Sum([Amount])";
            }
            else
            {
                var _found = grpDes.Find(g => g.PropertyName == pzColumnName);

                if (_found != null)
                    grpDes.Remove(_found);

                dgvBook.GroupDescriptions = grpDes;
            }
        }

        private void chxPublishID_CheckedChanged(object sender, EventArgs e)
        {
            groupByColumn(chxPublishID, dgvBook.Cols["Publish ID"].Name);
        }
        
        private void chxBookTypeCode_CheckedChanged(object sender, EventArgs e)
        {
            groupByColumn(chxBookTypeCode, dgvBook.Cols["Book Type ID"].Name);
        }

        private void chxAuthor_CheckedChanged(object sender, EventArgs e)
        {
            groupByColumn(chxAuthor, dgvBook.Cols["Author ID"].Name);
        }

        private void reGrouping()
        {
            foreach (string _item in zGroupDes)
            {
                if (string.Compare(_item, "Publish ID", false) == 0)
                {
                    chxPublishID.Checked = true;
                    groupByColumn(chxPublishID, dgvBook.Cols["Publish ID"].Name);
                }
                else if (string.Compare(_item, "Author ID", false) == 0)
                {
                    chxAuthor.Checked = true;
                    groupByColumn(chxAuthor, dgvBook.Cols["Author ID"].Name);
                }
                else if (string.Compare(_item, "Book Type ID", false) == 0)
                {
                    chxBookTypeCode.Checked = true;
                    groupByColumn(chxBookTypeCode, dgvBook.Cols["Book Type ID"].Name);
                }
            }
        }

        private void cacheAndDisplay(int pnPageIndex)
        {
            chxAuthor.Checked = chxBookTypeCode.Checked = chxPublishID.Checked = false;

            DataTable _presentTB = null;
            DataTable _nextTB = null;

            if (!chxCacheData.Checked)
            {
                loadData(pnPageIndex, nPageSize).ContinueWith((t) => 
                {
                    if (t.IsFaulted)
                    {
                        MessageBox.Show(t.Exception.Message);
                    }else if (t.IsCompleted)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                if (t.Result != null)
                                    resetSource(t.Result);

                                reGrouping();
                                if (_presentTB != null && _nextTB != null)
                                {
                                    _presentTB.Dispose();
                                    _nextTB.Dispose();
                                }
                            }));
                        }
                    }
                });
            }
            else
            {
                if (_presentTB == null)
                    _presentTB = dgvBook.DataSource as DataTable;

                loadData(pnPageIndex, nPageSize).ContinueWith((t) =>
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
                                    if (_nextTB == null)
                                        _nextTB = t.Result;

                                    _presentTB.Merge(_nextTB);
                                    
                                    resetSource(_presentTB);
                                    bindingData(_presentTB);
                                    reGrouping();
                                }
                            }));
                        }
                    }
                });
            }
        }

        private void chxMerge_CheckedChanged(object sender, EventArgs e)
        {
            dgvBook.CustomMerging = chxMerge.Checked;
        }
        #endregion Methods

        #region Click Event
        private void dgvBook_Click(object sender, EventArgs e)
        {
            loadBorrowBook().ContinueWith((t) => 
            {
                if (t.IsFaulted)
                    MessageBox.Show(t.Exception.Message);
                else if (t.IsCompleted)
                    return;
                else if (t.IsCanceled)
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
            dgvBook.BeginUpdate();
            DataRow _row = _tb.NewRow();
            _row["Code"] = "Enter bookcode...";
            _tb.Rows.Add(_row);
            dgvBook.EndUpdate();

            dgvBook.Select(dgvBook.Rows.Count - 1 - dgvBook.Rows.Fixed, 1);
            bindingData(dgvBook.DataSource);
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
                    loadData(nPageIndex, nPageSize);
                }
                else if (t.IsCanceled)
                {
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                    loadData(nPageIndex, nPageSize);
                }
                else if (t.IsCompleted)
                {
                    loadData(nPageIndex, nPageSize).ContinueWith((_t) =>
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

                                    reGrouping();
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
            dgvBook.BeginUpdate();
            dgvBook.Rows.Remove(dgvBook.Rows.Count - 1 - dgvBook.Rows.Fixed);
            dgvBook.EndUpdate();

            bindingData(dgvBook.DataSource);
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
                    loadData(nPageIndex, nPageSize).ContinueWith((_t) =>
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

                                    reGrouping();
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
                    loadData(nPageIndex, nPageSize).ContinueWith((_t) =>
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

                                    reGrouping();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            dgvBook.PrintGrid("BookForm", PrintGridFlags.FitToPageWidth | PrintGridFlags.ShowPreviewDialog, "BookForm\t\t" + String.Format(DateTime.Now.ToString(), "d"), "\t\tPage {0} of {1}");
            System.Drawing.Printing.PrintDocument pd = dgvBook.PrintParameters.PrintDocument;

            // Set up the page (landscape, 1.5" left margin).
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.Margins.Left = 150;

            // Set up the header and footer fonts.
            dgvBook.PrintParameters.HeaderFont = new Font("Arial Black", 14, FontStyle.Bold);
            dgvBook.PrintParameters.FooterFont = new Font("Arial Narrow", 8, FontStyle.Italic);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_ct != null)
            {
                _ct.Cancel();
                _ct.Dispose();
                _ct = null;
                bindingData(dgvBook.DataSource);
            }
        }

        #endregion Click Event

        #region Validating
        private void txtBookID_Validating(object sender, CancelEventArgs e)
        {
            var _tb = dgvBook.DataSource as DataTable;

            if (_tb != null)
            {
                _tb.PrimaryKey = new DataColumn[] { _tb.Columns["Code"] };

                BindingManagerBase _bm = dgvBook.BindingContext[_tb];

                DataRow _row = _tb.Rows.Find(((DataRowView)_bm.Current).Row.ItemArray[1]);

                if (txtBookID.Modified)
                {
                    if (_row != null)
                    {
                        _row.SetColumnError("Code", "BookCode must be unique.");
                        MessageBox.Show("BookCode must be unique");
                        e.Cancel = true;
                    }
                    else if (string.IsNullOrEmpty(txtBookID.Text))
                    {
                        e.Cancel = true;
                        MessageBox.Show("BookCode not allow null.");
                        bindingData(dgvBook.DataSource);
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
                foreach (GroupDescription _item in grpDes)
                {
                    zGroupDes.Add(_item.PropertyName);
                }
                grpDes.Clear();
                cacheAndDisplay(--nPageIndex);
                btnPrevious.Enabled = true;
            }
        }
            
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            if (nPageIndex < nPageCount)
            {   
                foreach (GroupDescription _item in grpDes)
                {
                    zGroupDes.Add(_item.PropertyName);
                }
                grpDes.Clear();
                cacheAndDisplay(++nPageIndex);
                btnNext.Enabled = true;
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            nPageIndex = 1;

            var _btn = sender as Button;
            if (_btn == null || !_btn.Name.StartsWith("btn"))
                return;

            _btn.Enabled = false;
            btnPrevious.Enabled = btnNew.Enabled = false;
            pagingCalculation(int.Parse(_btn.Name.Substring("btn".Length)));

            foreach (GroupDescription _item in grpDes)
            {
                zGroupDes.Add(_item.PropertyName);
            }
            grpDes.Clear();

            loadData(1, int.Parse(_btn.Name.Substring("btn".Length))).ContinueWith((t) =>
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
                            _btn.Enabled = true;
                            btnPrevious.Enabled = btnNew.Enabled = true;
                            resetSource(t.Result);
                            reGrouping();
                            bindingData(t.Result);
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
        }

        #endregion Paging
    }
}
