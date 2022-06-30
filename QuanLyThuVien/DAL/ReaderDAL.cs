using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    public class ReaderDAL
    {
        public ReaderDAL() { }

        public async Task<DataTable> loadData()
        {
            string _zQuery = "dbo.LoadReader";
            return await Task.Run(() => DataProvider.Instance.executeQueryAsync(_zQuery));
        }

        public async Task insertReader(string pzName, string pzAddress, string pzEmail, string pzPhone)
        {
            string _zQuery = "dbo.InsertReader @name , @address , @email , @phone";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { pzName, pzAddress, pzEmail, pzPhone }) );
        }

        public async Task updateReader(int id, string pzName, string pzAddress, string pzEmail, string pzPhone)
        {
            string _zQuery = "dbo.UpdateReader @id , @name , @address , @email , @phone";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { id, pzName, pzAddress, pzEmail, pzPhone }) );
        }
    }
}
