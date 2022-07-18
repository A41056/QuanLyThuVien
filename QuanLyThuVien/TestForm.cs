using C1.Win.C1FlexGrid;
using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class TestForm : Form
    {
        private BookTypeDAL bookTypeDAL = null;
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

            c1FlexGrid1.DataSource = await bookTypeDAL.loadData();

            var idColumn = c1FlexGrid1.Cols["Code"];
            idColumn.EditorValidation.Add(new RequiredRule());
            idColumn.EditorValidation.Add(new StringLengthRule()
            {
                MinimumLength = 5
            });

            var _tb = c1FlexGrid1.DataSource as DataTable;
            _tb.Columns["Code"].Unique = true;

            c1FlexGrid1.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            c1FlexGrid1.AutoSearchDelay = 2;
        }
    }
}
