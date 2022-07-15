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
    public partial class PublishCompanyForm : Form
    {
        private PublishDAL publishDAL;
        private CancellationTokenSource _ct = null;

        public PublishCompanyForm()
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
            if (String.IsNullOrEmpty(txtName.Text) ||
                String.IsNullOrEmpty(txtAddress.Text) ||
                String.IsNullOrEmpty(txtEmail.Text) ||
                String.IsNullOrEmpty(txtPhone.Text))
                return false;
            return true;
        }
        
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //BaseControl.Instance.exportToExcel(dgvPublisher);
        }

        private void PublishingCompanyForm_Load(object sender, EventArgs e)
        {
            if (publishDAL == null)
                publishDAL = new PublishDAL();

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
            dgvPublisher.DataSource = await publishDAL.loadData();
        }

        private void bindingData()
        {
            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtAddress.DataBindings.Clear();

            txtID.DataBindings.Add("Text", (dgvPublisher.DataSource as DataTable), "ID");
            txtName.DataBindings.Add("Text", (dgvPublisher.DataSource as DataTable), "Name");
            txtPhone.DataBindings.Add("Text", (dgvPublisher.DataSource as DataTable), "Phone");
            txtEmail.DataBindings.Add("Text", (dgvPublisher.DataSource as DataTable), "Email");
            txtAddress.DataBindings.Add("Text", (dgvPublisher.DataSource as DataTable), "Address");
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
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            if (!checkValid())
            {
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            }
            else
            {
                if (int.TryParse(txtPhone.Text, out int _nsdt))
                {
                    if (_ct == null)
                        _ct = new CancellationTokenSource();

                    publishDAL.insertPublisher(txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, _ct.Token).ContinueWith((t) => 
                    { 
                        loadData();
                        _ct.Dispose();
                        _ct = null;
                    });
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
            {
                MessageBox.Show(QuanLyThuVien.Resource.FillAllBlank);
            }
            else
            {
                if (int.TryParse(txtPhone.Text, out int _nsdt))
                {
                    if (_ct == null)
                        _ct = new CancellationTokenSource();

                    publishDAL.updatePublisher(Convert.ToInt32(txtID.Text), txtName.Text, txtAddress.Text, txtEmail.Text, txtPhone.Text, _ct.Token).ContinueWith((t) =>
                    {
                        loadData();
                        _ct.Dispose();
                        _ct = null;
                    });
                }
                else
                {
                    MessageBox.Show(QuanLyThuVien.Resource.InvalidValue);
                }
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
