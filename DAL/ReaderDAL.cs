﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class ReaderDAL : BaseDAL
    {
        public ReaderDAL() { }

        protected override string zProceduceName {get => "dbo.LoadReader";}        
        public override async Task<DataTable> loadDataAsync(CancellationToken pCt)
        {
            return await base.loadDataAsync(pCt);
        }

        public async Task insertReader(string pzName, string pzAddress, string pzEmail, string pzPhone, CancellationToken pCt)
        {
            string _zQuery = "dbo.InsertReader @name , @address , @email , @phone";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { pzName, pzAddress, pzEmail, pzPhone });
        }

        public async Task updateReader(int id, string pzName, string pzAddress, string pzEmail, string pzPhone, CancellationToken pCt)
        {
            string _zQuery = "dbo.UpdateReader @id , @name , @address , @email , @phone";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { id, pzName, pzAddress, pzEmail, pzPhone });
        }
    }
}
