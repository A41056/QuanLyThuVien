using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class UserAccountForm : Form
    {
        private UserAccountDAL userAccountDAL;
        private CancellationTokenSource _ct = null;

        public UserAccountForm()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        private bool checkValid()
        {
            if (String.IsNullOrEmpty(txtUsername.Text) ||
                String.IsNullOrEmpty(txtPassword.Text))
                return false;
            return true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //BaseControl.Instance.exportToExcel(dgvAccount);
        }

        private void UserAccountForm_Load(object sender, EventArgs e)
        {
            if (userAccountDAL == null)
                userAccountDAL = new UserAccountDAL();

            loadData().ContinueWith((t) =>
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        bindingData();
                        applyUIStrings();
                    }));
                }
                else
                {
                    bindingData();
                    applyUIStrings();
                }
            });
        }
        private async Task loadData()
        {
            dgvAccount.DataSource = await userAccountDAL.loadData();

            cbRole.DataSource = await userAccountDAL.loadRole();
            cbRole.DisplayMember = "Name";
            cbRole.ValueMember = "ID";
        }


        private void bindingData()
        {
            txtID.DataBindings.Clear();
            txtUsername.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            cbRole.DataBindings.Clear();

            txtID.DataBindings.Add("Text", (dgvAccount.DataSource as DataTable), "ID");
            txtUsername.DataBindings.Add("Text", (dgvAccount.DataSource as DataTable), "UserName");
            txtPassword.DataBindings.Add("Text", (dgvAccount.DataSource as DataTable), "Password");
            //cbRole.DataBindings.Add("Text", (dgvAccount.DataSource as DataTable), "RoleName");
        }

        string zRoleID;

        private void cbRole_SelectedValueChanged(object sender, EventArgs e)
        {
            zRoleID = cbRole.SelectedValue.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!checkValid())
            {
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            }
            else
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                userAccountDAL.insertAccount(txtUsername.Text, txtPassword.Text, Convert.ToInt32(zRoleID), _ct.Token).ContinueWith((t) =>
                {
                    loadData();
                });
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!checkValid())
            {
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            }
            else
            {
                if (_ct == null)
                    _ct = new CancellationTokenSource();

                userAccountDAL.updateAccount(Convert.ToInt32(txtID.Text), txtUsername.Text, txtPassword.Text, Convert.ToInt32(zRoleID), _ct.Token).ContinueWith((t) =>
                {
                    loadData();
                });
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_ct == null)
                _ct = new CancellationTokenSource();

            userAccountDAL.deleteAccount(Convert.ToInt32(txtID.Text),_ct.Token).ContinueWith((t) =>
            {
                loadData();
            });
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
    }
}
