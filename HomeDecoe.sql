create table tblBrands
(
BrandID int identity(1,1) primary key,
Name   nvarchar(500)
)

create table tblCategory
(
CatID int identity(1,1) primary key,
CatName   nvarchar(MAX)

)

create table tblSubCategory
(
SubCatID int identity(1,1) primary key,
SubCatName   nvarchar(MAX),
MainCatID int null,
Constraint [FK_tblSubCategory_tblCategory] FOREIGN KEY ([MainCatID]) REFERENCES [tblCategory] ([CatID])
)


create table tblProducts
(
PID int identity(1,1) primary key,
PName   nvarchar(MAX),
PPrice money,
PSelPrice money,
PBrandID int,
PCategoryID int,
PSubCatID int,
PDescription nvarchar(MAX),
PProductDetails nvarchar(MAX),
FreeDelivery int,
[30DayRet]  int,
COD       int,
Constraint [FK_tblProducts_ToTable] FOREIGN KEY ([PBrandID]) REFERENCES [tblBrands] ([BrandID]),
Constraint [FK_tblProducts_ToTable1] FOREIGN KEY ([PCategoryID]) REFERENCES [tblCategory] ([CatID]),
Constraint [FK_tblProducts_ToTable2] FOREIGN KEY ([PSubCatID]) REFERENCES [tblSubCategory] ([SubCatID]),

)


Create procedure sp_InsertProduct
(
@PName nvarchar(MAX),
@PSelPrice varchar(MAX),
@PCategoryID int,
@PDescription nvarchar(MAX),
@PProductDetails nvarchar(MAX)
)
AS

insert into tblProducts values(@PName,@PSelPrice,@PCategoryID,@PDescription,@PProductDetails) 
select SCOPE_IDENTITY()
Return 0

select * from tblProducts;

create procedure procBindAllProducts1
AS
select A.*,B.* ,B.Name as ImageName from tblProducts A
cross apply(
select top 1 * from tblProductImages B where B.PID= A.PID order by B.PID desc
)B
order by A.PID desc
Return 0

create table tblContact
(
CID int identity(1,1) primary key,
UName   nvarchar(500),
UAdd   nvarchar(500),
UMoblie   nvarchar(500),
USuggestion   nvarchar(500),
UEmail   nvarchar(500)
)


create table tblQuotationType
(
QID int identity(1,1) primary key,
QType nvarchar(MAX),
Uid int,
FOREIGN KEY (Uid) REFERENCES tblUsers(Uid)
)

create table tblQuotationHome
(
QHomeID int identity(1,1) primary key,
BedRoom int,
LivingRoom int,
Kitchen int,
WholeHouse int,
Others varchar(max),
QID int,
FOREIGN KEY (QID) REFERENCES tblQuotationType(QID)
);

SELECT TOP 1 Uid FROM tblUsers Where Usertype='User' ORDER BY Uid DESC;

create table tblQuotationCom
(
QComID int identity(1,1) primary key,
Office int,
Restaurant int,
Hospital int,
Lobbies int,
Others varchar(max),
QID int,
FOREIGN KEY (QID) REFERENCES tblQuotationType(QID)
);

create table tblSupplier
(
	SupID int identity(1,1) primary key,
	SupName varchar(max),
	SupPhNo varchar(max),
	SupAdd varchar(max),
	SupEmail varchar(max),
	SupGST varchar(max),
	SupBank varchar(max),
	SupAccNo varchar(max),
	SupIFSC varchar(max),
);

create table tblRMaterial
(
RM_ID int identity(1,1) primary key,
RM_Name varchar(max),
RM_Price varchar(max),
RM_Unit varchar(max),
SupID int,
FOREIGN KEY (SupID) REFERENCES tblSupplier(SupID)
);

create table tblPurchaseOrder
(
PO_ID int identity(1,1) primary key,
PO_Date varchar(max),
SupID int,
FOREIGN KEY (SupID) REFERENCES tblSupplier(SupID)
);

create table tblPOItems
(
POItem_ID int identity(1,1) primary key,
RM_ID int,
POItem_Price varchar(max),
POItem_Quantity varchar(max),
PO_ID int,
FOREIGN KEY ([PO_ID]) REFERENCES [tblPurchaseOrder] ([PO_ID]),
FOREIGN KEY ([RM_ID]) REFERENCES [tblRMaterial] ([RM_ID]),
);


create table tblSalesOrder
(
SO_ID int identity(1,1) primary key,
SO_Date varchar(max),
Uid int,
FOREIGN KEY (Uid) REFERENCES tblUsers(Uid)
);

create table tblSOProduct
(
SOPro_ID int identity(1,1) primary key,
PID int,
SOItem_Price varchar(max),
SOItem_Quantity varchar(max),
SO_ID int,
FOREIGN KEY (SO_ID) REFERENCES [tblSalesOrder] ([SO_ID]),
FOREIGN KEY (PID) REFERENCES [tblProducts] (PID),
);