using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class BookTypeDAL
    {
        public BookTypeDAL() { }

        public async Task<DataTable> loadData()
        {
            string _zQuery = "dbo.LoadBookType";
            return await Task.Run(() => DataProvider.Instance.executeQueryAsync(_zQuery) );
        }

        public async Task insertBookType(string pzCode, string pzName)
        {
            string _zQuery = "dbo.InsertBookType @code , @name";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] {pzCode, pzName}));
        }

        public async Task updateBookType(string pzCode, string pzName)
        {
            string _zQuery = "dbo.UpdateBookType @code , @name";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] {pzCode, pzName }));
        }

    }
}
