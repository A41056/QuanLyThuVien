using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.DAL
{
    public class PublishDAL
    {
        public PublishDAL() { }

        public  async Task<DataTable> loadData()
        {
            string _zQuery = "dbo.LoadPublisher";
            return await Task.Run(() => DataProvider.Instance.executeQueryAsync(_zQuery) );
        }

        public async Task insertPublisher(string pzName, string pzAddress, string pzEmail, string pzPhone)
        {
            string _zQuery = "dbo.InsertPublisher @name , @address , @email , @phone";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { pzName, pzAddress, pzEmail, pzPhone }) );
        }

        public async Task updatePublisher(int id, string pzName, string pzAddress, string pzEmail, string pzPhone)
        {
            string _zQuery = "dbo.UpdatePublisher @id , @name , @address , @email , @phone";
            await Task.Run(() => DataProvider.Instance.executeNonQueryAsync(_zQuery, new object[] { id, pzName, pzAddress, pzEmail, pzPhone }) );
        }
    }
}
