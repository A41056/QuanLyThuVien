using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

        public override async Task<DataTable> loadDataAsync(CancellationToken pCt)
        {
            return await base.loadDataAsync(pCt);
        }

        public async Task insertAsync( string pzName, string pzAddress, string pzEmail, string pzPhone, CancellationToken pCt)
        {
            var _zProceduceName = "dbo.InsertAuthor @name , @address , @email , @phone";
            await DataProvider.Instance.executeNonQueryAsync(_zProceduceName, pCt, new object[] { pzName, pzAddress, pzEmail, pzPhone });
        }
        
        public async Task updateAsync(int pnID, string pzName, string pzAddress, string pzEmail, string pzPhone, CancellationToken pCt)
        {
            var _zProceduceName = "dbo.UpdateAuthor @id , @name , @address , @email , @phone";
            await DataProvider.Instance.executeNonQueryAsync(_zProceduceName, pCt, new object[] { pnID, pzName, pzAddress, pzEmail, pzPhone });
        }
    }
}
