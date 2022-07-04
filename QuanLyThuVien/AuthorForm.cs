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
    public partial class AuthorForm : Form
    {
        private string zID;
        private int nIndex = 0;

        private AuthorDAL _authorDAL = null;
        public AuthorForm()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }
        
        private void dgvAuthor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nIndex = e.RowIndex;

            if (nIndex >= 0)
                bindingData(nIndex);
        }

        private async Task addNew()
        {
            if (checkValid())
            {
                int _nSdt;

                if (int.TryParse(txtPhone.Text, out _nSdt))
                {
                    await _authorDAL.insertAuthorAsync(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, Convert.ToDateTime(dtpDateofBirth.Value));
                    await loadData();
                }
                else
                {
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
                }
            }
        }
        
        private async Task edit()
        {
            if (checkValid())
            {
                int _nsdt;
                if (int.TryParse(txtPhone.Text, out _nsdt))
                {
                    await _authorDAL.updateAuthorAsync(Convert.ToInt32(zID),txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, Convert.ToDateTime(dtpDateofBirth.Value));
                    await loadData();
                }
                else
                {
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
                }
            }
        }

        private bool checkValid()
        {
            if (string.IsNullOrEmpty(txtName.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtPhone.Text))
                return false;
            return true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.exportToExcel(dgvAuthor);
        }

        private async Task loadData()
        {
            dgvAuthor.DataSource = await _authorDAL.loadData();
        }

        private void AuthorForm_Load_1(object sender, EventArgs e)
        {
            if (_authorDAL == null)
                _authorDAL = new AuthorDAL();
            BaseControl.Instance.runTask(loadData());
        }

        private void dgvAuthor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ++nIndex;
                if (nIndex >= 0 && nIndex <= dgvAuthor.Rows.Count - 1)
                    bindingData(nIndex);
                else if (nIndex > dgvAuthor.Rows.Count - 1)
                {
                    nIndex = dgvAuthor.Rows.Count - 1;
                    bindingData(nIndex);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                --nIndex;
                if (nIndex >= 0 && nIndex <= dgvAuthor.Rows.Count - 1)
                    bindingData(nIndex);
                else
                {
                    nIndex = 0;
                    bindingData(nIndex);
                }
            }
        }

        private void bindingData(int pnindex)
        {
            DataGridViewRow row = dgvAuthor.Rows[pnindex];
            zID = row.Cells[0].Value.ToString();
            txtID.Text = zID;
            txtName.Text = row.Cells[1].Value.ToString();
            txtAddress.Text = row.Cells[3].Value.ToString();
            txtEmail.Text = row.Cells[4].Value.ToString();
            txtPhone.Text = row.Cells[5].Value.ToString();
            dtpDateofBirth.Value = Convert.ToDateTime(row.Cells[2].Value.ToString());
        }


        private void applyUIStrings()
        {
            lblID.Text = QuanLyThuVien.Resource.lblID;
            lblName.Text = QuanLyThuVien.Resource.lblName;
            lblAddress.Text = QuanLyThuVien.Resource.lblAddress;
            lblPhone.Text = QuanLyThuVien.Resource.lblPhone;
            lblDateofBirth.Text = QuanLyThuVien.Resource.lblDateOfBirth;

            if (dgvAuthor.Columns.Count > 0)
            {
                dgvAuthor.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
                dgvAuthor.Columns[1].HeaderText = QuanLyThuVien.Resource.lblName;
                dgvAuthor.Columns[2].HeaderText = QuanLyThuVien.Resource.lblAddress;
                dgvAuthor.Columns[3].HeaderText = "Email";
                dgvAuthor.Columns[4].HeaderText = QuanLyThuVien.Resource.lblPhone;
                dgvAuthor.Columns[5].HeaderText = QuanLyThuVien.Resource.lblDateOfBirth;
            }
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
