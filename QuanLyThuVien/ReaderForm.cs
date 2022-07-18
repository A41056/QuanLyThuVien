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
    public partial class ReaderForm : FormBase
    {
        private ReaderDAL readerDAL = new ReaderDAL();
        private CancellationTokenSource _ct = null;

        public ReaderForm()
        {
            InitializeComponent();
        }
        protected override async Task loadData()
        {
            if (readerDAL == null)
                readerDAL = new ReaderDAL();
            dgvReader.DataSource = await readerDAL.loadData();
            await base.loadData();
        }

        protected override void bindingData()
        {
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtAddress.DataBindings.Clear();

            txtID.DataBindings.Add("Text", (dgvReader.DataSource as DataTable), "ID");
            txtName.DataBindings.Add("Text", (dgvReader.DataSource as DataTable), "Name");
            txtPhone.DataBindings.Add("Text", (dgvReader.DataSource as DataTable), "Phone");
            txtEmail.DataBindings.Add("Text", (dgvReader.DataSource as DataTable), "Email");
            txtAddress.DataBindings.Add("Text", (dgvReader.DataSource as DataTable), "Address");
            base.bindingData();        
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
            //BaseControl.Instance.exportToExcel(dgvReader);
        }
        
        protected override void applyUIStrings()
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
            base.applyUIStrings();
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

                readerDAL.insertReader(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, _ct.Token).ContinueWith((t) => 
                { 
                    loadData();
                    _ct.Dispose();
                    _ct = null;
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

                readerDAL.updateReader(Convert.ToInt32(txtID.Text), txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text,_ct.Token).ContinueWith((t) =>
                {
                    loadData();
                    _ct.Dispose();
                    _ct = null;
                });

            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtPhone.Text, out int _nPhone))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPhone, "Phone must be number.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.Clear();
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
