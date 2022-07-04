using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    
    public class LoginDAL
    {
        public LoginDAL(){}

        public async Task<bool> loginAsync(string pzUsername, string pzPassword, CancellationToken pCancellationToken)
        {
            try
            {
                if (pCancellationToken.IsCancellationRequested)
                    return false;

                string _zQuery = "dbo.LoginToAccount @username , @password";
                var _data = await DataProvider.Instance.executeQueryAsync(_zQuery,pCancellationToken ,new object[] { pzUsername, pzPassword });
                try
                {
                    if (_data != null && _data.Rows.Count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
