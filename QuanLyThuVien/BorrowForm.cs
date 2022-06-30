using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class BorrowForm : Form
    {
        private BorrowBookDAL borrowBookDAL;
        public BorrowForm()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        string zMaPhieuMuon, zMaThongTin;
        int nIndex;

        private void BorrowForm_Load(object sender, EventArgs e)
        {
            if (borrowBookDAL == null)
                borrowBookDAL = new BorrowBookDAL();
            BaseControl.Instance.runTaskWithCallBack(
                loadData(),
                ex =>{ MessageBox.Show("Error");},
                () =>{return;});
        }

        private async Task loadData()
        {
            dgvBorrow.DataSource = await borrowBookDAL.loadData();
            
            applyUIStrings();
        }
        
        private void dgvBorrow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nIndex = e.RowIndex;
            if(nIndex >= 0)
                bindingData(nIndex);
        }


        private void dgvBorrow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ++nIndex;
                if (nIndex >= 0 && nIndex <= dgvBorrow.Rows.Count - 1)
                {
                    bindingData(nIndex);
                }
                else if (nIndex > dgvBorrow.Rows.Count - 1)
                {
                    nIndex = dgvBorrow.Rows.Count - 1;
                    bindingData(nIndex);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                --nIndex;
                if (nIndex >= 0 && nIndex <= dgvBorrow.Rows.Count - 1)
                {
                    bindingData(nIndex);
                }
                else
                {
                    nIndex = 0;
                    bindingData(nIndex);
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.exportToExcel(dgvBorrow);
        }

        private void bindingData(int pnIndex)
        {
            DataGridViewRow row = dgvBorrow.Rows[pnIndex];
            txtID.Text = row.Cells[0].Value.ToString();
            zMaPhieuMuon = txtID.Text;
            txtTicketDetailsID.Text = row.Cells[1].Value.ToString();
            zMaThongTin = txtTicketDetailsID.Text;
            txtBookID.Text = row.Cells[2].Value.ToString();
            txtAuthorID.Text = row.Cells[3].Value.ToString();
            txtReaderID.Text = row.Cells[4].Value.ToString();
            txtAmount.Text = row.Cells[5].Value.ToString();
            dtpReturnDate.Value = Convert.ToDateTime(row.Cells[6].Value.ToString());
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
            BaseControl.Instance.runTaskWithCallBack(
                borrowBookDAL.deleteBorrowBook(Convert.ToInt32(zMaPhieuMuon)),
                ex => { MessageBox.Show("Error"); },
                () => { return; });
            BaseControl.Instance.runTaskWithCallBack(
                loadData(),
                ex => { MessageBox.Show("Error"); },
                () => { return; });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!checkValid())
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            else
            {
                BaseControl.Instance.runTaskWithCallBack(
                borrowBookDAL.updateBorrowBook(Convert.ToInt32(zMaPhieuMuon), txtBookID.Text, Convert.ToInt32(txtAuthorID.Text), Convert.ToInt32(txtReaderID.Text), Convert.ToInt32(txtAmount.Text), DateTime.Now, dtpReturnDate.Value),
                ex => { MessageBox.Show("Error"); },
                () => { return; });
                BaseControl.Instance.runTaskWithCallBack(
                loadData(),
                ex => { MessageBox.Show("Error"); },
                () => { return; });
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!checkValid())
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            else
            {
                BaseControl.Instance.runTaskWithCallBack(
                borrowBookDAL.insertBorrowBook(txtBookID.Text, Convert.ToInt32(txtAuthorID.Text), Convert.ToInt32(txtReaderID.Text), Convert.ToInt32(txtAmount.Text), DateTime.Now, dtpReturnDate.Value),
                ex => { MessageBox.Show("Error"); },
                () => { return; });
                BaseControl.Instance.runTaskWithCallBack(
                loadData(),
                ex => { MessageBox.Show("Error"); },
                () => { return; });
            }
        }

        private void applyUIStrings()
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

            btnNew.Text = QuanLyThuVien.Resource.btnNew;
            btnEdit.Text = QuanLyThuVien.Resource.btnEdit;
            btnDelete.Text = QuanLyThuVien.Resource.btnDelete;
        }


    }
}
