using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    
    public class LoginDAL
    {
        public LoginDAL() { }

        public async Task<bool> loginAsync(string pzUsername, string pzPassword)
        {
            try
            {
                return await Task.Run(() =>
                {
                    string _zQuery = "dbo.LoginToAccount @username , @password";
                    var _data = DataProvider.Instance.executeQueryAsync(_zQuery, new object[] { pzUsername, pzPassword });
                    if (_data != null && _data.GetAwaiter().GetResult().Rows.Count == 1)
                        return true;
                    else
                        return false;
                });

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
