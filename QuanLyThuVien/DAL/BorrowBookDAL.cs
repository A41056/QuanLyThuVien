using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyThuVien.DAL
{
    public class BorrowBookDAL
    {
        public BorrowBookDAL() { }

        public async Task<DataTable> loadData()
        {
            string _zQuery = "dbo.LoadBorrowBook";
            return await DataProvider.Instance.executeQueryAsync(_zQuery);
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
