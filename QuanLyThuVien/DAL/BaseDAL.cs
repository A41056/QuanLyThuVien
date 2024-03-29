﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class BaseDAL
    {
        public BaseDAL() { }

        private static BaseDAL _instance = null;

        public static BaseDAL Instance
        {
            get
            {
                if (_instance == null) _instance = new BaseDAL();
                return _instance;
            }
        }

        protected virtual string zProceduceName { get; }

        public virtual async Task<DataTable> loadDataAsync(CancellationToken pCt)
        {
            Trace.WriteLine(zProceduceName);
            return await DataProvider.Instance.executeQuerySelectAsync(zProceduceName, pCt);
        }
    }
}
