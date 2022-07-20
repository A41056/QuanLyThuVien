using C1.Win.C1FlexGrid;
using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class TestForm : Form
    {
        private BookTypeDAL bookTypeDAL = null;
        private BookDAL bookDAL = null;

        private CancellationTokenSource _ct;
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async Task loadData()
        {
            if (bookTypeDAL == null)
                bookTypeDAL = new BookTypeDAL();

            if (_ct == null)
                _ct = new CancellationTokenSource();

            if (bookDAL == null)
                bookDAL = new BookDAL();

            var _tb = await bookDAL.loadDataAsync(_ct.Token);
            c1FlexGrid1.DataSource = _tb;

            c1FlexGrid1.AllowAddNew = true;
            c1FlexGrid1.NewRowWatermark = "Add new row";

            c1FlexGrid1.VisualStyle = VisualStyle.System;

            c1FlexGrid1.AutoSizeCol(0);
            c1FlexGrid1.AutoSizeCol(1);

            CellStyle _cs;

            _cs = c1FlexGrid1.Styles.Add("LessThan50");
            _cs.BackColor = Color.Red;


            //Trace.WriteLine(c1FlexGrid1.Rows[11]);
            for (int _i = 1; _i < c1FlexGrid1.Rows.Count; _i++)
            {
                if (Convert.ToInt32(c1FlexGrid1.GetData(_i, 11)) <= 50)
                    c1FlexGrid1.Rows[_i].Style = _cs;  
            }

            DataView _dataView = new DataView(_tb);

            _dataView.
             
        }
    }
}
