using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public class BaseControl
    {
        private static BaseControl _instance = null;
        public static BaseControl Instance
        {
            get
            {
                if (_instance == null) _instance = new BaseControl();
                return _instance;
            }
        }

        private BaseControl() { }

        public void exportToExcel(DataGridView pDgv)
        {
            if (pDgv.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application _excl = new Microsoft.Office.Interop.Excel.Application();
                _excl.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i <= pDgv.Columns.Count; i++)
                {
                    _excl.Cells[1, i] = pDgv.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < pDgv.Rows.Count; i++)
                {
                    for (int j = 0; j < pDgv.Columns.Count; j++)
                    {
                        _excl.Cells[i + 2, j + 1] = pDgv.Rows[i].Cells[j].Value.ToString();
                    }
                }
                _excl.Columns.AutoFit();
                _excl.Visible = true;
            }
        }

        public void runTask(Task _pTask)
        {
            _pTask.ContinueWith(
                (_taskToContinue) =>
                {
                    if (_taskToContinue.IsFaulted)
                    {
                        MessageBox.Show(_taskToContinue.Exception.Message);
                    }
                    else if (_taskToContinue.IsCanceled)
                    {
                        MessageBox.Show("Task is cancelled.");
                    }
                    else
                    {
                        return;
                    }
                });
        }

    }
}
