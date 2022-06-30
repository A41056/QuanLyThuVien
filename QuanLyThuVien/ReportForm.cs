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
    public partial class ReportForm : Form
    {
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
            //var query = from ms in DB.BorrowDetails
            //            join bt in DB.BorrowTickets
            //            on ms.IDTicket equals bt.ID
            //            where bt.BorrowDate >= dtpForm.Value
            //            && bt.BorrowDate <= dtpTo.Value
            //            select new
            //            {
            //                maphieu = ms.BorrowTicket.ID,
            //                mathongtin = ms.ID,
            //                masach = ms.BookCode,
            //                madocgia = ms.IDAuthor,
            //                ngaymuon = bt.BorrowDate,
            //                ngaytra = ms.ReturnDate
            //            };
            //dgvReport.DataSource = query;
            //dgvReport.Columns[0].HeaderText = QuanLyThuVien.Resource.lblID;
            //dgvReport.Columns[1].HeaderText = QuanLyThuVien.Resource.lblTicketDetailsID;
            //dgvReport.Columns[2].HeaderText = QuanLyThuVien.Resource.lblBookCode;
            //dgvReport.Columns[3].HeaderText = QuanLyThuVien.Resource.lblReaderID;
            //dgvReport.Columns[4].HeaderText = QuanLyThuVien.Resource.lblBorrowDate;
            //dgvReport.Columns[5].HeaderText = QuanLyThuVien.Resource.lblReturnDate;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excl = new Microsoft.Office.Interop.Excel.Application();
                excl.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i <= dgvReport.Columns.Count; i++)
                {
                    excl.Cells[1, i] = dgvReport.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgvReport.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvReport.Columns.Count; j++)
                    {
                        excl.Cells[i + 2, j + 1] = dgvReport.Rows[i].Cells[j].Value.ToString();
                    }
                }
                excl.Columns.AutoFit();
                excl.Visible = true;
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        
        private void applyUIStrings()
        {
            lblFrom.Text = QuanLyThuVien.Resource.lblFromDate;
            lblTo.Text = QuanLyThuVien.Resource.lblToDate;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
