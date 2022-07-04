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
    public partial class ReaderForm : Form
    {
        private ReaderDAL readerDAL;
        public ReaderForm()
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

        private void ReaderForm_Load(object sender, EventArgs e)
        {
            if (readerDAL == null)
                readerDAL = new ReaderDAL();
            BaseControl.Instance.runTask( loadData());
        }
        private async Task loadData()
        {
            dgvReader.DataSource = await readerDAL.loadData();

            applyUIStrings();
        }

        private void bindingData(int pnIndex)
        {
            DataGridViewRow row = dgvReader.Rows[pnIndex];
            zID = row.Cells[0].Value.ToString();
            txtID.Text = zID;
            txtName.Text = row.Cells[1].Value.ToString();
            txtAddress.Text = row.Cells[4].Value.ToString();
            txtEmail.Text = row.Cells[2].Value.ToString();
            txtPhone.Text = row.Cells[3].Value.ToString();
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
            BaseControl.Instance.exportToExcel(dgvReader);
        }
        
        private void dgvReader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nIndex = e.RowIndex;
            if(nIndex >= 0)
                bindingData(nIndex);
        }

        private void dgvReader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                ++nIndex;
                if (nIndex >= 0 && nIndex <= dgvReader.Rows.Count - 1)
                    bindingData(nIndex);
                else if (nIndex > dgvReader.Rows.Count - 1)
                {
                    nIndex = dgvReader.Rows.Count - 1;
                    bindingData(nIndex);
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                --nIndex;
                if (nIndex >= 0 && nIndex <= dgvReader.Rows.Count - 1)
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
            lblAddress.Text = QuanLyThuVien.Resource.lblAddress;
            lblPhone.Text = QuanLyThuVien.Resource.lblPhone;

            if (dgvReader.Columns.Count > 0)
            {
                dgvReader.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
                dgvReader.Columns[1].HeaderText = QuanLyThuVien.Resource.lblName;
                dgvReader.Columns[4].HeaderText = QuanLyThuVien.Resource.lblAddress;
                dgvReader.Columns[2].HeaderText = "Email";
                dgvReader.Columns[3].HeaderText = QuanLyThuVien.Resource.lblPhone;
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
                int _sdt;
                if (int.TryParse(txtPhone.Text, out _sdt))
                {
                    BaseControl.Instance.runTask( readerDAL.insertReader(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text));
                    BaseControl.Instance.runTask( loadData());
                }
                else
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
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
                    BaseControl.Instance.runTask( readerDAL.updateReader(Convert.ToInt32(zID), txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text));
                    BaseControl.Instance.runTask(loadData());
                }
                else
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
            }
        }
    }
}
