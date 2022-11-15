Use LibraryManagement
GO

---Login
CREATE PROC [dbo].[LoadRole]
AS
BEGIN
	SELECT * FROM Roles
END
GO

ALTER PROC [dbo].[LoginToAccount]
@username as nvarchar(20), @password as nvarchar(20)
AS
BEGIN
	SELECT ID FROM UserAccount WHERE UserName = @username AND Password = @password;
END
GO

CREATE PROC [dbo].[LoadAccount]
AS
BEGIN
	SELECT * FROM UserAccount;
END
GO

CREATE PROC [dbo].[InsertAccount]
@username as nvarchar(20), @password as nvarchar(20), @idrole as int
AS
BEGIN
	INSERT INTO UserAccount(UserName,Password,IDRole) VALUES (@username,@password,@idrole);
END
GO

CREATE PROC [dbo].[EditAccount]
@id as int, @username as nvarchar(20), @password as nvarchar(20), @idrole as int
AS
BEGIN
	UPDATE UserAccount
	Set UserName = @username, Password = @password, IDRole = @idrole
	WHERE ID = @id
END
GO

CREATE PROC [dbo].[DeleteAccount]
@id as int
AS 
BEGIN
	DELETE FROM UserAccount WHERE ID = @id;
END
GO

---Author
CREATE PROC [dbo].[LoadAuthor]
AS 
BEGIN 
	SELECT * FROM Author
END
GO

CREATE PROC [dbo].[InsertAuthor]
@name as nvarchar(50), @address as nvarchar(30), @email as nvarchar(50), @phone as nchar(11), @birth as datetime
AS
BEGIN
	INSERT INTO Author(Name,Address,Email,Phone,Birth) 
	VALUES (@name,@address,@email,@phone,@birth);
END
GO

CREATE PROC [dbo].[UpdateAuthor]
@id as int,@name as nvarchar(50), @address as nvarchar(30), @email as nvarchar(50), @phone as nchar(11), @birth as datetime
AS
BEGIN
	UPDATE Author 
	SET Name = @name, Address = @address, Email = @email, Phone = @phone, Birth = @birth
	WHERE ID = @id;
END
GO

---Reader
CREATE PROC [dbo].[LoadReader]
AS 
BEGIN 
	SELECT * FROM Reader
END
GO

CREATE PROC [dbo].[InsertReader]
@name as nvarchar(50), @address as nvarchar(30), @email as nvarchar(50), @phone as nchar(11)
AS
BEGIN
	INSERT INTO Reader(Name,Address,Email,Phone) 
	VALUES (@name,@address,@email,@phone);
END
GO

CREATE PROC [dbo].[UpdateReader]
@id as int,@name as nvarchar(50), @address as nvarchar(30), @email as nvarchar(50), @phone as nchar(11)
AS
BEGIN
	UPDATE Reader
	SET Name = @name, Address = @address, Email = @email, Phone = @phone
	WHERE ID = @id;
END
GO

CREATE PROC [dbo].[DeleteReader]
@id as int
AS 
BEGIN
	DELETE FROM Reader WHERE ID = @id
END
GO
---Publish Conpany
CREATE PROC [dbo].[LoadPublisher]
AS 
BEGIN 
	SELECT * FROM PublishCompany
END
GO

CREATE PROC [dbo].[InsertPublisher]
@name as nvarchar(50), @address as nvarchar(30), @email as nvarchar(50), @phone as nchar(11)
AS
BEGIN
	INSERT INTO PublishCompany(Name,Address,Email,Phone) 
	VALUES (@name,@address,@email,@phone);
END
GO

CREATE PROC [dbo].[UpdatePublisher]
@id as int,@name as nvarchar(50), @address as nvarchar(30), @email as nvarchar(50), @phone as nchar(11)
AS
BEGIN
	UPDATE PublishCompany
	SET Name = @name, Address = @address, Email = @email, Phone = @phone
	WHERE ID = @id;
END
GO

CREATE PROC [dbo].[DeletePublisher]
@id as int
AS 
BEGIN
	DELETE FROM Reader WHERE ID = @id
END
GO

---BookType
CREATE PROC [dbo].[LoadBookType]
AS
BEGIN
	SELECT * FROM BookType
END
GO

CREATE PROC [dbo].[InsertBookType]
@code as nchar(5), @name as nvarchar(30)
AS
BEGIN
	INSERT INTO BookType(Code,Name) VALUES (@code, @name);
END
GO

CREATE PROC [dbo].[UpdateBookType]
@code as nchar(5), @name as nvarchar(30)
AS
BEGIN
	UPDATE BookType
	Set Code = @code, Name = @name
	WHERE Code = @code
END
GO

---Borrow Book
CREATE PROC [dbo].[LoadBorrowBook]
AS
BEGIN
	SELECT * FROM BorrowDetail
END
GO

CREATE PROC [dbo].[LoadBorrowBookByCode]
@BookCode as nchar(5)
AS
BEGIN
	SELECT bd.BookCode, bd.IDReader, bd.Amount, bt.BorrowDate, bd.ReturnDate
	FROM BorrowDetails as bd join BorrowTicket as bt on bd.IDTicket = bt.ID 
	WHERE bd.BookCode = @BookCode
END
GO

CREATE PROC [dbo].[InsertBorrowBook]
@BookCode as nchar(5),@IDAuthor as int, @IDReader as int, @Amount as int, @BorrowDate as datetime, @ReturnDate as datetime
AS
BEGIN
	DECLARE @BorrowTicketID as int;
	INSERT INTO BorrowTicket(BorrowDate)
	VALUES (@BorrowDate);
	SET @BorrowTicketID = @@IDENTITY;

	INSERT INTO BorrowDetail(IDTicket,BookCode,IDAuthor,IDReader,Amount,ReturnDate)
	VALUES	(@BorrowTicketID,@BookCode,@IDAuthor,@IDReader,@Amount,@ReturnDate);
END
GO

CREATE PROC [dbo].[UpdateBorrowBook]
@BorrowTicketID as int, @BookCode as nchar(5),@IDAuthor as int, @IDReader as int, @Amount as int, @BorrowDate as datetime, @ReturnDate as datetime
AS 
BEGIN
	UPDATE BorrowTicket
	SET BorrowDate = @BorrowDate
	WHERE ID = @BorrowTicketID
	UPDATE BorrowDetail
	SET BookCode = @BookCode,IDAuthor = @IDAuthor ,IDReader = @IDReader, Amount = @Amount, ReturnDate = @ReturnDate
	WHERE IDTicket = @BorrowTicketID
END
GO

CREATE PROC [dbo].[DeleteBorrowBook]
@BorrowTicketID as int
AS 
BEGIN
	DELETE FROM BorrowDetail WHERE IDTicket = @BorrowTicketID
	DELETE FROM BorrowTicket WHERE ID = @BorrowTicketID
END
GO



---Book

ALTER PROC [dbo].[LoadBookPaging]
@PageIndex as INT,
@PageSize as INT,
@RecordCount INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ROW_NUMBER() OVER (ORDER BY Book.Code ASC) as RowNumber,
			Book.Code,Book.Name,
			Author.ID as [Author ID], Author.Name as [Author Name],   
            PublishCompany.ID as [Publish ID],PublishCompany.Name as [Publish Name],   
	        BookType.Code as [Book Type ID], BookType.Name as [Book Type Name], Book.PublishDate,    
	        Inventory.ID as [Inventory ID], Inventory.Amount INTO AllRecord   
    FROM Book	join Author on Book.IDAuthor = Author.ID    
				join PublishCompany on Book.IDPublish = PublishCompany.ID    
                join BookType on Book.CodeTypeBook = BookType.Code    
                join Inventory on Book.IDInventory = Inventory.ID;

	SELECT * 
	FROM AllRecord
	WHERE RowNumber BETWEEN (@PageIndex - 1) * @PageSize + 1 AND (((@PageIndex - 1)*@PageSize + 1) + @PageSize) - 1;
	DROP TABLE AllRecord
END
GO

CREATE PROC [dbo].[InsertBook]
@CodeInsert as nchar(5), @Name as nvarchar(100), @IDPublish as int, @IDAuthor as int, @CodeTypeBook as nchar(5), @PublishDate as datetime, @Amount as int
AS
BEGIN
	DECLARE @IDInventory as int;
	INSERT INTO Inventory(Amount) VALUES (@Amount);
	SET @IDInventory = @@IDENTITY;

	INSERT INTO Book(Code,Name,IDPublish,IDAuthor,CodeTypeBook,PublishDate,IDInventory)
	VALUES (@CodeInsert,@Name,@IDPublish,@IDAuthor,@CodeTypeBook,@PublishDate,@IDInventory);
END
GO

CREATE PROC [dbo].[UpdateBook]
@Code as nchar(5), @Name as nvarchar(100), @IDPublish as int, @IDAuthor as int, @CodeTypeBook as nchar(5), @PublishDate as datetime
AS
BEGIN
	Update Book
	Set Code = @Code, Name = @Name, IDPublish = @IDPublish, IDAuthor = @IDAuthor, CodeTypeBook = @CodeTypeBook, PublishDate = @PublishDate
	WHERE Code = @Code;
END
GO

CREATE PROC [dbo].[DeleteBook]
@Code as nchar(5)
AS
BEGIN
	DELETE FROM Book WHERE Code = @Code
END
go

CREATE PROC [dbo].[GetNumberRecord]
AS
BEGIN
	SELECT COUNT(Code) FROM Book
END
GO

CREATE PROC [dbo].[GetReaderByBookCode]
@Code as nchar(5)
AS
BEGIN
	
END
GO

CREATE PROC [dbo].[GetReaderByBookCode]
@Code as nchar(5)
AS
BEGIN
	SELECT *
	FROM Reader
	WHERE ID IN (SELECT IDReader	
			FROM BorrowDetails
			WHERE BookCode = @Code) 
END
GO



