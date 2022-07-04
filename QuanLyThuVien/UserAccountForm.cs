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
    public partial class UserAccountForm : Form
    {
        private UserAccountDAL userAccountDAL;

        public UserAccountForm()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        string zID, zRoleID;
        int nIndex;

        private bool checkValid()
        {
            if (String.IsNullOrEmpty(txtUsername.Text) ||
                String.IsNullOrEmpty(txtPassword.Text))
                return false;
            return true;
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.exportToExcel(dgvAccount);
        }

        private void UserAccountForm_Load(object sender, EventArgs e)
        {
            if (userAccountDAL == null)
                userAccountDAL = new UserAccountDAL();
            BaseControl.Instance.runTask(loadData());
        }
        private async Task loadData()
        {
            dgvAccount.DataSource = await userAccountDAL.loadData();
            
            cbRole.DataSource = await userAccountDAL.loadRole();
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "ID";
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nIndex = e.RowIndex;
            if(nIndex >= 0)
                bindingData(nIndex);
        }

        private void bindingData(int pnIndex)
        {
            DataGridViewRow row = dgvAccount.Rows[pnIndex];
            zID = row.Cells[0].Value.ToString();
            txtID.Text = zID;
            txtUsername.Text = row.Cells[1].Value.ToString();
            txtPassword.Text = row.Cells[2].Value.ToString();
            cbRole.Text = row.Cells[3].Value.ToString();
            row.Dispose();
        }

        private void dgvAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ++nIndex;
                if (nIndex >= 0 && nIndex <= dgvAccount.Rows.Count - 1)
                    bindingData(nIndex);
                else if (nIndex > dgvAccount.Rows.Count - 1)
                {
                    nIndex = dgvAccount.Rows.Count - 1;
                    bindingData(nIndex);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                --nIndex;
                if (nIndex >= 0 && nIndex <= dgvAccount.Rows.Count - 1)
                    bindingData(nIndex);
                else
                {
                    nIndex = 0;
                    bindingData(nIndex);
                }
            }
        }

        private void cbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            zRoleID = cbRole.SelectedValue.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!checkValid())
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            else
            {
                BaseControl.Instance.runTask( userAccountDAL.insertAccount(txtUsername.Text, txtPassword.Text, Convert.ToInt32(zRoleID)));
                BaseControl.Instance.runTask(loadData());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!checkValid())
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            else
            {
                BaseControl.Instance.runTask( userAccountDAL.updateAccount(Convert.ToInt32(zID), txtUsername.Text, txtPassword.Text, Convert.ToInt32(zRoleID)));
                BaseControl.Instance.runTask( loadData());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.runTask( userAccountDAL.deleteAccount(Convert.ToInt32(zID)));
            BaseControl.Instance.runTask(loadData());
        }

        private void applyUIStrings()
        {
            lblID.Text = QuanLyThuVien.Resource.lblID;
            lblName.Text = QuanLyThuVien.Resource.lblUserName;
            lblPassword.Text = QuanLyThuVien.Resource.lblPassword;
            lblRole.Text = QuanLyThuVien.Resource.lblRole;

            if (dgvAccount.Columns.Count > 0)
            {
                dgvAccount.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
                dgvAccount.Columns[1].HeaderText = QuanLyThuVien.Resource.lblUserName;
                dgvAccount.Columns[2].HeaderText = QuanLyThuVien.Resource.lblPassword;
                dgvAccount.Columns[3].HeaderText = QuanLyThuVien.Resource.lblRole;
            }

            btnNew.Text = QuanLyThuVien.Resource.btnNew;
            btnEdit.Text = QuanLyThuVien.Resource.btnEdit;
            btnDelete.Text = QuanLyThuVien.Resource.btnDelete;
        }
    }
}
