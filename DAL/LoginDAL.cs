using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    
    public class LoginDAL
    {
        public LoginDAL(){}

        public async Task<bool> loginAsync(string pzUsername, string pzPassword, CancellationToken pCancellationToken)
        {
            if (pCancellationToken.IsCancellationRequested)
                return false;

            string _zQuery = "dbo.LoginToAccount @username , @password";
            return await DataProvider.Instance.executeQueryAsync(_zQuery,pCancellationToken ,new object[] { pzUsername, pzPassword });
        }
    }
}
