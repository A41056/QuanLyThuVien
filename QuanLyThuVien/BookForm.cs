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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class BookForm : Form
    {
        private BookDAL bookDAL = null;
        private AuthorDAL authorDAL = null;
        private BookTypeDAL bookTypeDAL = null;
        private PublishDAL publishDAL = null;

        private string zBookID, zBookTypeID, zAuthorID, zPublishID;
        private int nInventoryID, nIndex;

        public BookForm()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        
        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (bookDAL == null)
                bookDAL = new BookDAL();

            BaseControl.Instance.runTaskWithCallBack(
                loadData(),
                ex =>
                {
                    MessageBox.Show("Run Task Error");
                },
                () =>
                {
                    return;
                });
            BaseControl.Instance.runTaskWithCallBack(
                loadAuthor(),
                ex =>
                {
                    MessageBox.Show("Run Task Error");
                },
                () =>
                {
                    return;
                });
            BaseControl.Instance.runTaskWithCallBack(
                loadPublishCompany(),
                ex =>
                {
                    MessageBox.Show("Run Task Error");
                },
                () =>
                {
                    return;
                });
            BaseControl.Instance.runTaskWithCallBack(
                loadTypeBook(),
                ex =>
                {
                    MessageBox.Show("Run Task Error");
                },
                () =>
                {
                    return;
                });

        }

        private async Task loadData()
        {
            dgvBook.DataSource = await bookDAL.loadDataAsync();
        }
        private void clearData()
        {
            txtBookID.Text = string.Empty;
            txtBookName.Text = string.Empty;
            txtAmout.Text = string.Empty;
        }
        private async Task loadTypeBook()
        {
            if (bookTypeDAL == null)
                bookTypeDAL = new BookTypeDAL();
            cbBookType.DataSource = await bookTypeDAL.loadData();
            cbBookType.DisplayMember = "Name";
            cbBookType.ValueMember = "Code";
           
        }

        private async Task loadAuthor()
        {
            if (authorDAL == null)
                authorDAL = new AuthorDAL();
            cbAuthor.DataSource = await authorDAL.loadData();
            cbAuthor.DisplayMember = "Name";
            cbAuthor.ValueMember = "ID";
        }

        private async Task loadPublishCompany()
        {
            if (publishDAL == null)
                publishDAL = new PublishDAL();
            cbPublisher.DataSource = await publishDAL.loadData();
            cbPublisher.DisplayMember = "Name";
            cbPublisher.ValueMember = "ID";
        }
        
        private void bindingData(int pnindex)
        {
            DataGridViewRow row = dgvBook.Rows[pnindex];

            zBookID = row.Cells[0].Value.ToString();
            txtBookID.Text = zBookID;
            txtBookName.Text = row.Cells[1].Value.ToString();
            zAuthorID = row.Cells[2].Value.ToString();
            cbAuthor.Text = row.Cells[3].Value.ToString();
            zPublishID = row.Cells[4].Value.ToString();
            cbPublisher.Text = row.Cells[5].Value.ToString();
            zBookTypeID = row.Cells[6].Value.ToString();
            cbBookType.Text = row.Cells[7].Value.ToString();
            dtpPublishDate.Value = Convert.ToDateTime(row.Cells[8].Value.ToString());
            nInventoryID = Convert.ToInt32(row.Cells[9].Value.ToString());
            txtAmout.Text = row.Cells[10].Value.ToString();
        }

        public async Task addNew()
        {
            if (checkValid())
            {
                await bookDAL.insertBookAsync(txtBookID.Text, txtBookName.Text, Convert.ToInt32(zPublishID), Convert.ToInt32(zAuthorID), zBookTypeID, dtpPublishDate.Value, Convert.ToInt32(txtAmout.Text));
                await loadData();
                clearData();
            }
        }

        private async Task edit()
        {
            if (checkValid())
            {
                await bookDAL.updateBookAsync(txtBookID.Text, txtBookName.Text, Convert.ToInt32(zPublishID), Convert.ToInt32(zAuthorID), zBookTypeID, dtpPublishDate.Value);
                await loadData();
                clearData();
            }
        }

        private async Task delete()
        {
            await bookDAL.deleteBookAsync(txtBookID.Text);
            await loadData();
            clearData();
        }

        public bool checkValid()
        {
            if (string.IsNullOrEmpty(txtBookID.Text) ||
                string.IsNullOrEmpty(txtBookName.Text) ||
                string.IsNullOrEmpty(txtAmout.Text))
                return false;
            return true;
        }

        private void dgvBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ++nIndex;
                if (nIndex >= 0 && nIndex <= dgvBook.Rows.Count - 1)
                    bindingData(nIndex);
                else if (nIndex > dgvBook.Rows.Count - 1)
                {
                    nIndex = dgvBook.Rows.Count - 1;
                    bindingData(nIndex);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                --nIndex;
                if (nIndex >= 0 && nIndex <= dgvBook.Rows.Count - 1)
                    bindingData(nIndex);
                else
                {
                    nIndex = 0;
                    bindingData(nIndex);
                }
            }
        }

        private void cbPublisher_Click(object sender, EventArgs e)
        {
            cbPublisher.DataSource = null;
            BaseControl.Instance.runTask(loadPublishCompany());
        }

        private void cbAuthor_Click(object sender, EventArgs e)
        {
            cbAuthor.DataSource = null;
            BaseControl.Instance.runTask(loadAuthor());
        }

        private void cbBookType_Click(object sender, EventArgs e)
        {
            cbBookType.DataSource = null;
            BaseControl.Instance.runTask(loadTypeBook());
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.runTask(addNew());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.runTask(edit());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.runTask(delete());
        }

        private void cbPublisher_SelectionChangeCommitted(object sender, EventArgs e)
        {
            zAuthorID = cbAuthor.SelectedValue.ToString();
            zBookTypeID = cbBookType.SelectedValue.ToString();
            zPublishID = cbPublisher.SelectedValue.ToString();
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nIndex = e.RowIndex;
            if (nIndex >= 0)
                bindingData(nIndex);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.exportToExcel(dgvBook);
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

            if (dgvBook.Columns.Count > 0)
            {
                dgvBook.Columns[0].HeaderText = QuanLyThuVien.Resource.lblBookCode;
                dgvBook.Columns[1].HeaderText = QuanLyThuVien.Resource.lblBookName;
                dgvBook.Columns[2].HeaderText = QuanLyThuVien.Resource.lblAuthorID;
                dgvBook.Columns[3].HeaderText = QuanLyThuVien.Resource.lblAuthorName;
                dgvBook.Columns[4].HeaderText = QuanLyThuVien.Resource.lblPublishID;
                dgvBook.Columns[5].HeaderText = QuanLyThuVien.Resource.lblPublishName;
                dgvBook.Columns[6].HeaderText = QuanLyThuVien.Resource.lblBookTypeID;
                dgvBook.Columns[7].HeaderText = QuanLyThuVien.Resource.lblBookTypeName;
                dgvBook.Columns[8].HeaderText = QuanLyThuVien.Resource.lblPublishDate;
                dgvBook.Columns[9].HeaderText = QuanLyThuVien.Resource.lblInventoryID;
                dgvBook.Columns[10].HeaderText = QuanLyThuVien.Resource.lblAmout;
            }

        }

    }
}
