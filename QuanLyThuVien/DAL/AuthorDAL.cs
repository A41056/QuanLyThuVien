using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    public class AuthorDAL
    {
        public AuthorDAL() { }

        public async Task<DataTable> loadData()
        {
            string _zQuery = "dbo.LoadAuthor";
            try
            {
                return await Task.Run(() => DataProvider.Instance.executeQueryAsync(_zQuery));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public async Task insertAuthorAsync(string pzName, string pzAddress, string pzEmail, string pzPhone, DateTime pDtpBirth)
        {
            string _zQuery = "dbo.InsertAuthor @name , @address , @email , @phone , @birth";
            try
            {
                await Task.Run(
                    () => DataProvider.Instance.executeNonQueryAsync(_zQuery,
                    new object[] { pzName, pzAddress, pzEmail, pzPhone, pDtpBirth }));
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task updateAuthorAsync(int id, string pzName, string pzAddress, string pzEmail, string pzPhone, DateTime pDtpBirth)
        {
            string _zQuery = "dbo.UpdateAuthor @id , @name , @address , @email , @phone , @birth";
            try
            {

                await Task.Run(
                    () => DataProvider.Instance.executeNonQueryAsync(_zQuery,
                    new object[] { id, pzName, pzAddress, pzEmail, pzPhone, pDtpBirth }));
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
