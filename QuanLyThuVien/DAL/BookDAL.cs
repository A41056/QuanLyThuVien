using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    public class BookDAL
    {
        public BookDAL() { }

        public async Task<DataTable> loadDataAsync()
        {
            string _zQuery = "dbo.LoadBook";
            try
            {
                return await Task.Run(() => DataProvider.Instance.executeQueryAsync(_zQuery));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task insertBookAsync(string pzCode, string pzName, int pnIDPublish, int pnIDAuthor, string pzCodeType, DateTime pdtpPublishDate, int pnAmount)
        {
            string _zQuery = "dbo.InsertBook @CodeInsert , @Name , @IDPublish , @IDAuthor , @CodeTypeBook , @PublishDate , @Amount";
            try
            {
                await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { pzCode, pzName, pnIDPublish, pnIDAuthor, pzCodeType, pdtpPublishDate, pnAmount }));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task updateBookAsync(string pzCode, string pzName, int pnIDPublish, int pnIDAuthor, string pzCodeType, DateTime pdtpPublishDate)
        {
            string _zQuery = "dbo.UpdateBook @Code , @Name , @IDPublish , @IDAuthor , @CodeTypeBook , @PublishDate";
            try
            {
                await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { pzCode, pzName, pnIDPublish, pnIDAuthor, pzCodeType, pdtpPublishDate }));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task deleteBookAsync(string pzCode)
        {
            string _zQuery = "dbo.DeleteBook @Code";
            try
            {
                await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { pzCode }));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
