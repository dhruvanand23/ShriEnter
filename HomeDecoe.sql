create table tblProductImages
(
PIMGID int identity(1,1) primary key,
PID   int,
Name nvarchar(MAX),
Extention nvarchar(500),
Constraint [FK_tblProductImages_ToTable] FOREIGN KEY ([PID]) REFERENCES [tblProducts] ([PID]),
)
