using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class BookDAL : BaseDAL
    {
        public BookDAL() { }

        protected override string zProceduceName => "dbo.LoadBook";

        public override async Task<DataTable> loadDataAsync(CancellationToken pCt)
        {
            return await base.loadDataAsync(pCt);
        }

        public async Task<DataTable> getReaderByBookCode(string zBookCode,CancellationToken pCt)
        {
            string _zQuery = "dbo.GetReaderByBookCode @Code";
            return await DataProvider.Instance.executeQueryAsync(_zQuery, new object[] { zBookCode });
        }

        public async Task<DataTable> loadDataPagingAsync(int pnPageIndex, int pnPageSize)
        {
            string _zQuery = "dbo.LoadBookPaging @PageIndex , @PageSize , null";
            return await DataProvider.Instance.executeQueryAsync(_zQuery ,new object[] { pnPageIndex, pnPageSize });
        }

        public async Task<object> getTotalRecord()
        {
            string _zQuery = "dbo.GetNumberRecord";
            return await DataProvider.Instance.executeScalar(_zQuery);
        }

        public async Task insertBookAsync(string pzCode, string pzName, int pnIDPublish, int pnIDAuthor, string pzCodeType, DateTime pdtpPublishDate, int pnAmount, CancellationToken pCT)
        {
            string _zQuery = "dbo.InsertBook @CodeInsert , @Name , @IDPublish , @IDAuthor , @CodeTypeBook , @PublishDate , @Amount";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCT, new object[] { pzCode, pzName, pnIDPublish, pnIDAuthor, pzCodeType, pdtpPublishDate, pnAmount });
        }

        public async Task updateBookAsync(string pzCode, string pzName, int pnIDPublish, int pnIDAuthor, string pzCodeType, DateTime pdtpPublishDate, CancellationToken pCT)
        {
            string _zQuery = "dbo.UpdateBook @Code , @Name , @IDPublish , @IDAuthor , @CodeTypeBook , @PublishDate";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCT, new object[] { pzCode, pzName, pnIDPublish, pnIDAuthor, pzCodeType, pdtpPublishDate });
        }

        public async Task deleteBookAsync(string pzCode, CancellationToken pCT)
        {
            string _zQuery = "dbo.DeleteBook @Code";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCT, new object[] { pzCode });
        }
    }
}
