using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class BookTypeDAL : BaseDAL
    {
        public BookTypeDAL() { }

        protected override string zProceduceName => "dbo.LoadBookType";
        public async Task<DataTable> loadData(CancellationToken pCt)
        {
            await DataProvider.Instance.executeQuerySelectAsync(zProceduceName, pCt);
            return await base.loadDataAsync(pCt);
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
