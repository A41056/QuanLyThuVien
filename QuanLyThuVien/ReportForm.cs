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
    public partial class ReportForm : Form
    {
        private ReportDAL reportDAL = null;
        private CancellationTokenSource _ct;
        public ReportForm()
        {
            InitializeComponent();

            MainForm.onLanguageChanged += MainForm_onLanguageChanged;
        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            if (reportDAL == null)
                reportDAL = new ReportDAL();

            dgvReport.DataSource = reportDAL.getRecordByDate(dtpForm.Value, dtpTo.Value, _ct.Token); 
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //BaseControl.Instance.exportToExcel(dgvReport);
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            loadData();
            applyUIStrings();
        }
        
        private void applyUIStrings()
        {
            lblFrom.Text = QuanLyThuVien.Resource.lblFromDate;
            lblTo.Text = QuanLyThuVien.Resource.lblToDate;

            //if (dgvReport != null)
            //{
            //    dgvReport.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
            //    dgvReport.Columns[1].HeaderText = QuanLyThuVien.Resource.lblTicketDetailsID;
            //    dgvReport.Columns[2].HeaderText = QuanLyThuVien.Resource.lblBookCode;
            //    dgvReport.Columns[3].HeaderText = QuanLyThuVien.Resource.lblAuthorID;
            //    dgvReport.Columns[4].HeaderText = QuanLyThuVien.Resource.lblReaderID;
            //    dgvReport.Columns[5].HeaderText = QuanLyThuVien.Resource.lblAmout;
            //    dgvReport.Columns[6].HeaderText = QuanLyThuVien.Resource.lblBorrowDate;
            //    dgvReport.Columns[7].HeaderText = QuanLyThuVien.Resource.lblReturnDate;
            //}
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
