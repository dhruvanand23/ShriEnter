create table user_Details
(
	u_id int identity(1,1) primary key not null,
	u_name varchar(50) null,
	u_pass varchar(20) null,
	u_add varchar(100)null,
	u_mob varchar(20)null,
	u_mail varchar(20)null
)