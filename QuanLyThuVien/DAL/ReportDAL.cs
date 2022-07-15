using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class ReportDAL
    {
        public ReportDAL() { }

        public async Task<DataTable> getRecordByDate(DateTime pDtpStartDate, DateTime pDtpEndDate)
        {
            string _zQuery = "dbo.SearchByDate @startDate , @endDate";
            return await DataProvider.Instance.executeQueryAsync(_zQuery, new object[] { pDtpStartDate, pDtpEndDate });
        }
    }
}
