using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class BorrowBookDAL : BaseDAL
    {
        public BorrowBookDAL() { }

        protected override string zProceduceName { get => "dbo.LoadBorrowBook"; }

        public override async Task<DataTable> loadDataAsync(CancellationToken pCt)
        {
            return await base.loadDataAsync(pCt);
        }

        public async Task<DataTable> loadBorrowBookByCode(string pzBookCode, CancellationToken pCt)
        {
            string _zQuery = "dbo.LoadBorrowBookByCode @BookCode";
            return await DataProvider.Instance.executeQuerySelectAsync(_zQuery, pCt, new object[] { pzBookCode });
        }

        public async Task insertBorrowBook(string pzBookCode,int pnIDAuthor, int pnIDReader, int pnAmount, DateTime pdtpBorrowDate, DateTime pdtpReturnDate, CancellationToken pCt)
        {
            string _zQuery = "dbo.InsertBorrowBook @BookCode , @IDAuthor , @IDReader , @Amount , @BorrowDate , @ReturnDate";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { pzBookCode,pnIDAuthor, pnIDReader, pnAmount, pdtpBorrowDate, pdtpReturnDate });
        }

        public async Task updateBorrowBook(int pnTicketID,string pzBookCode,int pnIDAuthor ,int pnIDReader, int pnAmount, DateTime pdtpBorrowDate, DateTime pdtpReturnDate, CancellationToken pCt)
        {
            string _zQuery = "dbo.UpdateBorrowBook @BorrowTicketID , @BookCode , @IDAuthor , @IDReader , @Amount , @BorrowDate , @ReturnDate";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] {pnTicketID, pzBookCode,pnIDAuthor ,pnIDReader, pnAmount, pdtpBorrowDate, pdtpReturnDate });
        }

        public async Task deleteBorrowBook(int pnTicketID, CancellationToken pCt)
        {
            string _zQuery = "dbo.DeleteBorrowBook @BorrowTicketID";
            await DataProvider.Instance.executeNonQueryAsync(_zQuery, pCt, new object[] { pnTicketID });
        }
    }
}
