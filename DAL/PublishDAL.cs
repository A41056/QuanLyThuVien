using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class PublishDAL : BaseDAL
    {
        public PublishDAL() { }

        protected override string zProceduceName => "dbo.LoadPublisher";

        public override async Task<DataTable> loadDataAsync(CancellationToken pCt)
        {
            return await base.loadDataAsync(pCt);
        }

        public async Task insertPublisher(string pzName, string pzAddress, string pzEmail, string pzPhone, CancellationToken pCt)
        {
            string _zQuery = "dbo.InsertPublisher @name , @address , @email , @phone";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { pzName, pzAddress, pzEmail, pzPhone });
        }

        public async Task updatePublisher(int id, string pzName, string pzAddress, string pzEmail, string pzPhone, CancellationToken pCt)
        {
            string _zQuery = "dbo.UpdatePublisher @id , @name , @address , @email , @phone";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { id, pzName, pzAddress, pzEmail, pzPhone });
        }
    }
}
