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
    public partial class BookForm : FormBase
    {
        #region Properties
        private BookDAL _bookDAL = null;
        private AuthorDAL _authorDAL = null;
        private BookTypeDAL _bookTypeDAL = null;
        private PublishDAL _publishDAL = null;
        private CancellationTokenSource _ct = null;
        private DataTable _cacheTB = null;
        private DataTable _displayTB = null;

        private int nPageIndex = 1, nPageSize = 10, nTotalRecord = 36;
        private double nPageCount;
        private CellStyle _cs;
        private List<GroupDescription> grpDes = new List<GroupDescription>();
        private GroupDescription grp = null;
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

            if (_ct == null)
                _ct = new CancellationTokenSource();

            Task.WhenAll(loadData(nPageIndex, nPageSize),loadTypeBook(), loadAuthor(), loadPublishCompany()).ContinueWith((_taskToContinue) =>
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
                    if (InvokeRequired)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            bindingData(dgvBook.DataSource as DataTable);
                            applyUIStrings();
                        }));
                    }
                    else
                    {
                        bindingData(dgvBook.DataSource as DataTable);
                        applyUIStrings();
                    }
                }
            });
            
            _cs = dgvBook.Styles.Add("LessThan50");
            _cs.BackColor = Color.Red;

            btnAccept.Enabled = btnEdit.Enabled = false;
            btnAccept.Visible = btnDeny.Visible = false;
            customizeGridView();
        }

        private void customizeGridView()
        {
            dgvBook.AutoSizeCols();
            dgvBook.AutoSizeRows();
            dgvBook.AllowEditing = false;
            dgvBook.AllowFiltering = true;
            dgvBook.SelectionMode = SelectionModeEnum.Row;
            dgvBook.ColumnPickerInfo.ShowToolButton = true;
            dgvBook.DrawMode = DrawModeEnum.OwnerDraw;
            dgvBook.ColumnContextMenuEnabled = true;
            dgvBook.Subtotal(AggregateEnum.Sum, 0, 1, 12, "Total amount: {0}");


            searchPanel.SetC1FlexGridSearchPanel(dgvBook, searchPanel);
            searchPanel.HighlightSearchResults = true;
            searchPanel.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always;
            searchPanel.Watermark = "Type to search...";
            searchPanel.SearchDelay = 2;
        }

        private async Task loadData(int pnPageIndex, int pnPageSize)
        {
            btnPrevious.Enabled = btnNext.Enabled = false;

            if (_ct == null)
                _ct = new CancellationTokenSource();

            var _tb = await _bookDAL.loadDataPagingAsync(pnPageIndex, pnPageSize);

            dgvBook.DataSource = _tb;

            btnPrevious.Enabled = btnNext.Enabled = true;

            dgvBook.Cols[1].Visible = dgvBook.Cols[4].Visible = dgvBook.Cols[6].Visible = dgvBook.Cols[8].Visible = false;
            nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());
            pagingCalculation(pnPageSize);
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

            txtBookID.DataBindings.Add("Text", pDataSource, "Code", true, DataSourceUpdateMode.OnPropertyChanged);
            txtBookName.DataBindings.Add("Text", pDataSource, "Name", true);
            cbAuthor.DataBindings.Add("SelectedValue", pDataSource, "Author ID", true);
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
                        _row.Field<int>("Author ID"),
                        Convert.ToInt32(cbAuthor.SelectedValue.ToString()),
                        cbBookType.SelectedValue.ToString(),
                        _row.Field<DateTime>("PublishDate"),
                        _row.Field<int>("Amount"),
                        _ct.Token);

                    nTotalRecord = Convert.ToInt32(await _bookDAL.getTotalRecord());

                    await loadData(nPageIndex, nPageSize);
                    await Task.Delay(200);

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
            BindingManagerBase _bm = dgvBook.BindingContext[dgvBook.DataSource];

            DataRow _row = ((DataRowView)_bm.Current).Row;
            if (checkValid())
            {
                try
                {
                    if (_ct == null)
                        _ct = new CancellationTokenSource();

                    await _bookDAL.updateBookAsync
                        (_row.Field<string>("Code"),
                        _row.Field<string>("Name"),
                        Convert.ToInt32(cbPublisher.SelectedValue.ToString()),
                        _row.Field<int>("Author ID"),
                        cbBookType.SelectedValue.ToString(),
                        _row.Field<DateTime>("PublishDate"),
                        _ct.Token);
                    
                    await loadData(nPageIndex, nPageSize);
                    await Task.Delay(200);

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
            lblPerpage.Text = QuanLyThuVien.Resource.PerPage;

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
            base.applyUIStrings();
        }

        private void dgvBook_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            if ((e.Row >= dgvBook.Rows.Fixed) & (e.Col == (dgvBook.Cols.Fixed - 1))) // Draw Fixed Row Number
            {
                e.Text = ((e.Row - dgvBook.Rows.Fixed) + 1).ToString();
            }

            if (dgvBook.Cols[10].Index == e.Col && e.Row >= dgvBook.Rows.Fixed) // Draw Publish Date Display
            {
                if (dgvBook[e.Row, e.Col] != null)
                    e.Text = "PublishDate: " + dgvBook[e.Row, e.Col].ToString();
            }

            if (dgvBook.Cols[12].Index == e.Col && e.Row >= dgvBook.Rows.Fixed) //DrawCell on Condition
            {
                DataRowView _drv = (DataRowView)dgvBook.Rows[e.Row].DataSource;
                if (_drv == null) return;
                DataRow _dr = _drv.Row;
                
                if (Convert.ToInt32(_dr.ItemArray[11]) <= 50)
                {
                    e.Style = _cs;
                    dgvBook.Rows[e.Row].Style = e.Style; // Không đúng lắm...
                    e.DrawCell(DrawCellFlags.Background);
                    e.DrawCell(DrawCellFlags.Content);
                    e.Handled = true;
                }
            }
        }

        private void chxPublishID_CheckedChanged(object sender, EventArgs e)
        {
            groupByColumn(chxPublishID, "Publish ID");
        }
        
        private void groupByColumn(CheckBox pChx, string pzColumnName)
        {
            if (pChx.Checked)
            {
                if (grpDes.Find(g => g.PropertyName == pzColumnName) == null)
                {
                    grp = new GroupDescription(pzColumnName, ListSortDirection.Descending, true);
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

        private void chxBookTypeCode_CheckedChanged(object sender, EventArgs e)
        {
            groupByColumn(chxBookTypeCode, dgvBook.Cols[8].Name);
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
            txtBookName.Text = txtAmout.Text = cbAuthor.Text = cbBookType.Text = cbPublisher.Text = string.Empty;    
            txtBookID.Focus();

            btnAccept.Visible = btnDeny.Visible = true;
            btnAccept.Enabled = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            addNew().ContinueWith((t) =>
            {
                if (t.IsFaulted)
                    MessageBox.Show(QuanLyThuVien.Resource.IsFaulted);
                else if (t.IsCanceled)
                    MessageBox.Show(QuanLyThuVien.Resource.IsCanceled);
                else
                    loadData(nPageIndex, nPageSize);
            });
            btnEdit.Enabled = false;
            btnAccept.Enabled = btnEdit.Enabled = false;
            btnAccept.Visible = btnDeny.Visible = false;
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            bindingData();
            btnAccept.Visible = btnDeny.Visible = false;
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
                    loadData(nPageIndex, nPageSize);
            });
            btnEdit.Enabled = false;
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
                    loadData(nPageIndex, nPageSize);
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
                btnEdit.Enabled = true;

                if (_row !=null)
                {
                    _tb.Rows[_nRowIndex].SetColumnError("Code", "BookCode must be unique.");
                    MessageBox.Show("BookCode must be unique.");
                    _tb.Rows[_nRowIndex].ClearErrors();
                    e.Cancel = true;
                }
                else if (string.IsNullOrEmpty(txtBookID.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("BookCode not allow null.");
                }

                if (string.Compare(txtBookName.Text,string.Empty,false) != 0 && string.Compare(txtAmout.Text,string.Empty,false) != 0)
                    btnAccept.Enabled = true;
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
                (dgvBook.DataSource as DataTable).Rows[getCurrentRow()].ClearErrors();
            }
        }
        
        #endregion Validating

        #region Paging
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (nPageIndex == 1)
                return;
            else
                cacheAndDisplay(--nPageIndex);
        }
            
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (nPageIndex >= nPageCount)
                return;
            else
                cacheAndDisplay(++nPageIndex);
        }

        private void cacheAndDisplay(int pnPageIndex)
        {
            if (!chxCacheData.Checked)
            {
                if (dgvBook.GroupDescriptions != null)
                    dgvBook.GroupDescriptions.Clear();
                chxBookTypeCode.Checked = chxPublishID.Checked = false;
                pagingCalculation(nPageSize);
                loadData(pnPageIndex, nPageSize);
            }
            else
            {
                if (dgvBook.GroupDescriptions != null)
                    dgvBook.GroupDescriptions.Clear();
                chxBookTypeCode.Checked = chxPublishID.Checked = false;

                _cacheTB = dgvBook.DataSource as DataTable;

                pagingCalculation(nPageSize);
                loadData(pnPageIndex, nPageSize).ContinueWith((t) =>
                {
                    if (t.IsCompleted)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                _displayTB = dgvBook.DataSource as DataTable;
                                dgvBook.Cols[1].Visible = dgvBook.Cols[4].Visible = dgvBook.Cols[6].Visible = dgvBook.Cols[8].Visible = false;
                                _displayTB.Merge(_cacheTB);
                                _displayTB.DefaultView.Sort = "RowNumber ASC";
                                dgvBook.DataSource = _displayTB;
                                dgvBook.Refresh();
                            }));
                        }
                    }
                });
            }
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
