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
    public partial class PublishCompanyForm : Form
    {
        private PublishDAL publishDAL;
        public PublishCompanyForm()
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

        private void dgvPublisher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nIndex = e.RowIndex;
            if(nIndex >= 0)
                bindingData(nIndex);
        }

        private bool checkValid()
        {
            if (String.IsNullOrEmpty(txtName.Text) ||
                String.IsNullOrEmpty(txtAddress.Text) ||
                String.IsNullOrEmpty(txtEmail.Text) ||
                String.IsNullOrEmpty(txtPhone.Text))
                return false;
            return true;
        }
        
        private void btnExcel_Click(object sender, EventArgs e)
        {
            BaseControl.Instance.exportToExcel(dgvPublisher);
        }

        private void PublishingCompanyForm_Load(object sender, EventArgs e)
        {
            if (publishDAL == null)
                publishDAL = new PublishDAL();
            BaseControl.Instance.runTask( loadData());
        }

        private async Task loadData()
        {
            dgvPublisher.DataSource = await publishDAL.loadData();
            
            applyUIStrings();
        }

        private void bindingData(int pnIndex)
        {
            DataGridViewRow row = dgvPublisher.Rows[nIndex];
            zID = row.Cells[0].Value.ToString();
            txtID.Text = zID;
            txtName.Text = row.Cells[1].Value.ToString();
            txtAddress.Text = row.Cells[2].Value.ToString();
            txtEmail.Text = row.Cells[3].Value.ToString();
            txtPhone.Text = row.Cells[4].Value.ToString();
        }

        private void dgvPublisher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ++nIndex;
                if (nIndex >= 0 && nIndex <= dgvPublisher.Rows.Count - 1)
                    bindingData(nIndex);
                else if (nIndex > dgvPublisher.Rows.Count - 1)
                {
                    nIndex = dgvPublisher.Rows.Count - 1;
                    bindingData(nIndex);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                --nIndex;
                if (nIndex >= 0 && nIndex <= dgvPublisher.Rows.Count - 1)
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
            lbName.Text = QuanLyThuVien.Resource.lblName;
            lblAddress.Text = QuanLyThuVien.Resource.lblAddress;
            lblPhone.Text = QuanLyThuVien.Resource.lblPhone;

            if (dgvPublisher.Columns.Count > 0)
            {
                dgvPublisher.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
                dgvPublisher.Columns[1].HeaderText = QuanLyThuVien.Resource.lblName;
                dgvPublisher.Columns[2].HeaderText = QuanLyThuVien.Resource.lblAddress;
                dgvPublisher.Columns[3].HeaderText = "Email";
                dgvPublisher.Columns[4].HeaderText = QuanLyThuVien.Resource.lblPhone;
            }
            btnNew.Text = QuanLyThuVien.Resource.btnNew;
            btnEdit.Text = QuanLyThuVien.Resource.btnEdit;
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!checkValid())
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            else
            {
                int _nsdt;
                if (int.TryParse(txtPhone.Text, out _nsdt))
                {
                    BaseControl.Instance.runTask(
                        publishDAL.insertPublisher(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text));
                    BaseControl.Instance.runTask(loadData());
                }
                else
                {
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!checkValid())
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            else
            {
                int _sdt;
                if (int.TryParse(txtPhone.Text, out _sdt))
                {

                    BaseControl.Instance.runTask(
                        publishDAL.updatePublisher(Convert.ToInt32(zID), txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text));
                    BaseControl.Instance.runTask(loadData());
                }
                else
                {
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
                }
            }
        }

    }
}
