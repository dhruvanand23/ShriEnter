create table ForgotPass
(
Id varchar(500) not null,
Uid int null,
RequestDateTime DATETIME null,
Constraint [FK_ForgotPass_user_Details] Foreign key([Uid]) References[user_Details]([u_id])
);