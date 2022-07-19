using C1.Win.C1FlexGrid;
using QuanLyThuVien.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            c1FlexGrid1.DataSource = await bookTypeDAL.loadData(_ct.Token);
        }

        private void c1FlexGrid1_Validating(object sender, CancelEventArgs e)
        {
            var idColumn = c1FlexGrid1.Cols[1];
            idColumn.EditorValidation.Add(new RequiredRule());
            idColumn.EditorValidation.Add(new StringLengthRule()
            {
                MinimumLength = 5,
                MaximumLength = 30,
                ErrorMessage = "String Length Error"
            });
            idColumn.EditorValidation.Add(new CompareRule()
            {
                OtherProperty = "CN"
            });

            var _tb = c1FlexGrid1.DataSource as DataTable;
            _tb.Columns[1].Unique = true;

            c1FlexGrid1.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromCursor;
            c1FlexGrid1.AutoSearchDelay = 2;
        }

        private void c1FlexGrid1_ValidateEdit(object sender, ValidateEditEventArgs e)
        {
            var idColumn = c1FlexGrid1.Cols["Code"];
            idColumn.EditorValidation.Add(new RequiredRule());
            idColumn.EditorValidation.Add(new StringLengthRule()
            {
                MinimumLength = 5,
                MaximumLength = 30,
                ErrorMessage = "String Length Error"
            });
        }

        private void c1FlexGrid1_SelChange(object sender, EventArgs e)
        {
            var text = string.Empty;
            if (!c1FlexGrid1.Selection.IsSingleCell)
            {
                text = "Phạm Quang Giáp";
            }
        }
    }
}
