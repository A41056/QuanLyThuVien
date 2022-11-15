using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class UserAccountDAL : BaseDAL
    {
        public UserAccountDAL() { }

        protected override string zProceduceName => "dbo.LoadAccount";

        public override async Task<DataTable> loadDataAsync( CancellationToken pCt)
        {
            return await base.loadDataAsync(pCt);
        }

        public async Task<DataTable> loadRole(CancellationToken pCt)
        {
            string _zQuery = "dbo.LoadRole";
            return await DataProvider.Instance.executeQuerySelectAsync(_zQuery,pCt);
        }

        public async Task insertAccount(string pzUsername, string pzPassword, int pnRoleID, CancellationToken pCt)
        {
            string _zQuery = "dbo.InsertAccount @username , @password , @idrole";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { pzUsername, pzPassword, pnRoleID });
        }

        public async Task updateAccount(int pnId, string pzUsername, string pzPassword, int pnRoleID, CancellationToken pCt)
        {
            string _zQuery = "dbo.EditAccount @id , @username , @password , @idrole";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { pnId, pzUsername, pzPassword, pnRoleID });
        }

        public async Task deleteAccount(int pnId, CancellationToken pCt)
        {
            string _zQuery = "dbo.DeleteAccount @id";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { pnId });
        }
    }
}
