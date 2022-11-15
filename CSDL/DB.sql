CREATE DATABASE LibraryManagement
GO

USE LibraryManagement
GO

CREATE TABLE Roles
(
	ID int identity(1,1) primary key,
	Name nvarchar(20)
)
GO

INSERT INTO Roles(Name)
VALUES	(N'GIÁO VIÊN'),
		(N'SINH VIÊN')
GO
CREATE TABLE UserAccount
(
	ID	int identity(1,1) primary key,
	UserName	nvarchar(20) unique,
	Password	nvarchar(20),
	IDRole		int,

	FOREIGN KEY(IDRole) REFERENCES Roles(ID)
)
GO

INSERT INTO UserAccount(UserName,Password,IDRole)
VALUES	(N'giaovien001',N'123',1),
		(N'giaovien002',N'123',1),
		(N'giaovien003',N'123',1),
		(N'giaovien004',N'123',1),
		(N'giaovien005',N'123',1),
		(N'sinhvien001',N'123',2),
		(N'sinhvien002',N'123',2),
		(N'sinhvien003',N'123',2),
		(N'sinhvien004',N'123',2),
		(N'sinhvien005',N'123',2),
		(N'sinhvien006',N'123',2),
		(N'sinhvien007',N'123',2),
		(N'sinhvien008',N'123',2),
		(N'sinhvien009',N'123',2)
GO
CREATE TABLE BookType
(
	Code nchar(5) primary key,
	Name	nvarchar(30)

)
GO

INSERT INTO BookType(Code,Name)
VALUES	(N'KD',N'Kinh dị'),
		(N'TL',N'Tâm lý'),
		(N'XH',N'Xã hội'),
		(N'CN',N'Chuyên ngành')
GO
CREATE TABLE Author
(
	ID int identity(1,1) primary key,
	Name nvarchar(50),
	Birth datetime,
	Address nvarchar(30),
	Email nvarchar(50),
	Phone nchar(11)
)
GO

INSERT INTO Author(Name,Birth,Address,Email,Phone)
VALUES	(N'Phạm Văn A','1980-01-01 00:00:00:000',N'Hải Phòng',N'phamvana@gmail.com','09876543211'),
		(N'Phạm Văn B','1981-09-03 00:00:00:000',N'Hải Dương',N'phamvanb@gmail.com','09876543212'),
		(N'Phạm Văn C','1982-05-09 00:00:00:000',N'Hà Nội',N'phamvanc@gmail.com','09876543213'),
		(N'Phạm Văn D','1983-08-10 00:00:00:000',N'Bắc Ninhh',N'phamvand@gmail.com','09876543214')

GO

CREATE TABLE PublishCompany
(
	ID	int identity(1,1) primary key,
	Name	nvarchar(30),
	Address	nvarchar(50),
	Email	nvarchar(30),
	Phone nchar(11)
)
GO

INSERT INTO PublishCompany(Name,Address,Email,Phone)
VALUES	(N'Kim Đồng',N'Hà Nội',N'nxbkimdong@gmail.com','09009988770'),
		(N'Kim Đồng 2',N'Hà Nội',N'nxbkimdong2@gmail.com','09009988771'),
		(N'Hà Nội',N'Hà Nội',N'nxbhanoi@gmail.com','09009988772'),
		(N'Tuổi Trẻ',N'Hà Nội',N'nxbtuoitre@gmail.com','09009988773')

GO

CREATE TABLE Inventory
(
	ID int identity(1,1) primary key,
	Amount int
)
GO

INSERT INTO Inventory(Amount)
VALUES	(100),
		(100),
		(100),
		(100),
		(100),
		(100),
		(100),
		(100),
		(100),
		(100),
		(100),
		(100),
		(100)
GO

CREATE TABLE Book
(
	Code nchar(5) primary key,
	Name nvarchar(100),
	IDPublish int,
	IDAuthor int,
	CodeTypeBook nchar(5),
	PublishDate datetime,
	IDInventory int,

	FOREIGN KEY(IDPublish) REFERENCES PublishCompany(ID),
	FOREIGN KEY(IDAuthor) REFERENCES Author(ID),
	FOREIGN KEY(CodeTypeBook) REFERENCES BookType(Code),
	FOREIGN KEY(IDInventory) REFERENCES Inventory(ID)

)
GO

INSERT INTO Book(Code,Name,IDPublish,IDAuthor,CodeTypeBook,PublishDate,IDInventory)
VALUES	(N'KD001',N'Trở về từ cõi chết',1,1,N'KD','2019-01-01 00:00:00:000',1),
		(N'KD002',N'Ngôi nhà ma ám',1,1,N'KD','2019-01-01 00:00:00:000',2),
		(N'KD003',N'Đám cưới ma',1,1,N'KD','2019-01-01 00:00:00:000',3),
		(N'TL001',N'Tâm lý học',2,2,N'TL','2019-01-01 00:00:00:000',4),
		(N'XH001',N'Những vấn đề trong xã hội',1,3,N'XH','2019-01-01 00:00:00:000',5),
		(N'CN001',N'Lập trình căn bản',1,1,N'CN','2019-01-01 00:00:00:000',6),
		(N'CN002',N'Marketing căn bản',1,1,N'CN','2019-01-01 00:00:00:000',7),
		(N'CN003',N'Lập trình C#',1,1,N'CN','2019-01-01 00:00:00:000',8),
		(N'CN004',N'Lập trình hướng đối tượng',1,1,N'CN','2019-01-01 00:00:00:000',9),
		(N'CN005',N'Kinh tế chính trị',1,1,N'CN','2019-01-01 00:00:00:000',10),
		(N'CN006',N'Tư tưởng Hồ Chí Minh',1,1,N'CN','2019-01-01 00:00:00:000',11),
		(N'CN007',N'Giải tích 1',1,1,N'CN','2019-01-01 00:00:00:000',12),
		(N'CN008',N'Giải tích 2',1,1,N'CN','2019-01-01 00:00:00:000',13)

GO

CREATE TABLE Reader
(
	ID int identity(1,1) primary key,
	Name nvarchar(30),
	Email nvarchar(30),
	Phone nchar(11),
	Address nvarchar(30)
)
GO

INSERT INTO Reader(Name,Email,Phone,Address)
VALUES	(N'Nguyễn Văn T',N'nguyenvant@gmail.com','09123124110',N'Hà Nội')

GO

CREATE TABLE BorrowTicket
(
	ID int identity(1,1) primary key,
	BorrowDate datetime
)
GO

CREATE TABLE BorrowDetails
(
	ID int identity(1,1) primary key,
	IDTicket int,
	BookCode nchar(5),
	IDAuthor int,
	IDReader int,
	Amount int,
	ReturnDate datetime,

	FOREIGN KEY(IDTicket) REFERENCES BorrowTicket(ID),
	FOREIGN KEY(BookCode) REFERENCES Book(Code),
	FOREIGN KEY(IDAuthor) REFERENCES Author(ID),
	FOREIGN KEY(IDReader) REFERENCES Reader(ID)
)
GO

