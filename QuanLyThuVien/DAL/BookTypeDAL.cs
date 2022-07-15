using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class BookTypeDAL
    {
        public BookTypeDAL() { }

        public async Task<DataTable> loadData()
        {
            string _zQuery = "dbo.LoadBookType";
            return await DataProvider.Instance.executeQueryAsync(_zQuery);
        }

        public async Task insertBookType(string pzCode, string pzName, CancellationToken pCt)
        {
            string _zQuery = "dbo.InsertBookType @code , @name";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] {pzCode, pzName});
        }

        public async Task updateBookType(string pzCode, string pzName, CancellationToken pCt)
        {
            string _zQuery = "dbo.UpdateBookType @code , @name";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] {pzCode, pzName });
        }

    }
}
