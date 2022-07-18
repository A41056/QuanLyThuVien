using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class AuthorDAL : BaseDAL
    {
        public AuthorDAL() { }

        protected override string zProceduceName { get => "dbo.LoadAuthor"; }

        public override async Task<DataTable> loadDataAsync()
        {
            return await base.loadDataAsync();
        }

        public async Task insertAuthorAsync(string pzName, string pzAddress, string pzEmail, string pzPhone, DateTime pDtpBirth, CancellationToken pCt)
        {
            string _zQuery = "dbo.InsertAuthor @name , @address , @email , @phone , @birth";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt,
                    new object[] { pzName, pzAddress, pzEmail, pzPhone, pDtpBirth });
        }

        public async Task updateAuthorAsync(int id, string pzName, string pzAddress, string pzEmail, string pzPhone, DateTime pDtpBirth, CancellationToken pCt)
        {
            string _zQuery = "dbo.UpdateAuthor @id , @name , @address , @email , @phone , @birth";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt,
                    new object[] { id, pzName, pzAddress, pzEmail, pzPhone, pDtpBirth });
        }
    }
}
