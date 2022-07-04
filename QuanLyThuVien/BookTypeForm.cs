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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class BookTypeForm : Form
    {
        private BookTypeDAL bookTypeDAL;
        public BookTypeForm()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        string zID;
        int nIndex;

        private void BookTypeForm_Load(object sender, EventArgs e)
        {
            if (bookTypeDAL == null)
                bookTypeDAL = new BookTypeDAL();
            BaseControl.Instance.runTask(loadData());
        }
        private async Task loadData()
        {
            dgvBookType.DataSource = await bookTypeDAL.loadData();

            applyUIStrings();
        }

        private async Task addNew()
        {
            if (!checkValid())
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            else
            {
                await bookTypeDAL.insertBookType(txtID.Text, txtName.Text);
                await loadData();
            }
        }

        private async Task edit()
        {
            if (!checkValid())
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            else
            {
                await bookTypeDAL.updateBookType(txtID.Text, txtName.Text);
                await loadData();
            }
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
            BaseControl.Instance.exportToExcel(dgvBookType);
        }

        private void bindingData(int pnindex)
        {
            DataGridViewRow row = dgvBookType.Rows[pnindex];
            zID = row.Cells[0].Value.ToString();
            txtID.Text = zID;
            txtName.Text = row.Cells[1].Value.ToString();
        }

        private void dgvBookType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nIndex = e.RowIndex;
            if (nIndex >= 0)
                bindingData(nIndex);
        }

        private void dgvBookType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ++nIndex;
                if (nIndex >= 0 && nIndex <= dgvBookType.Rows.Count - 1)
                    bindingData(nIndex);
                else if (nIndex > dgvBookType.Rows.Count - 1)
                {
                    nIndex = dgvBookType.Rows.Count - 1;
                    bindingData(nIndex);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                --nIndex;
                if (nIndex >= 0 && nIndex <= dgvBookType.Rows.Count - 1)
                    bindingData(nIndex);
                else
                {
                    nIndex = 0;
                    bindingData(nIndex);
                }
            }
        }


        private void applyUIStrings()
        {
            lblID.Text = QuanLyThuVien.Resource.lblID;
            lblName.Text = QuanLyThuVien.Resource.lblName;
            
            if (dgvBookType.Columns.Count > 0)
            {
                dgvBookType.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
                dgvBookType.Columns[1].HeaderText = QuanLyThuVien.Resource.lblName;
            }

            btnNew.Text = QuanLyThuVien.Resource.btnNew;
            btnEdit.Text = QuanLyThuVien.Resource.btnEdit;
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.runTask(addNew());
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.runTask(edit());
        }

    }
}
