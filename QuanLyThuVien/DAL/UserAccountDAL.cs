using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    public class UserAccountDAL
    {
        public UserAccountDAL() { }

        public async Task<DataTable> loadData()
        {
            string _zQuery = "dbo.LoadAccount";
            return await Task.Run(() => DataProvider.Instance.executeQueryAsync(_zQuery));
        }

        public async Task<DataTable> loadRole()
        {
            string _zQuery = "dbo.LoadRole";
            return await Task.Run(() => DataProvider.Instance.executeQueryAsync(_zQuery));
        }

        public async Task insertAccount(string pzUsername, string pzPassword, int pnRoleID)
        {
            string _zQuery = "dbo.InsertAccount @username , @password , @idrole";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { pzUsername,pzPassword,pnRoleID }));
        }

        public async Task updateAccount(int pnId,string pzUsername, string pzPassword, int pnRoleID)
        {
            string _zQuery = "dbo.EditAccount @id , @username , @password , @idrole";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] {pnId, pzUsername, pzPassword, pnRoleID }));
        }

        public async Task deleteAccount(int pnId)
        {
            string _zQuery = "dbo.DeleteAccount @id";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { pnId }));
        }
    }
}
