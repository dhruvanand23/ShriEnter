create table ForgotPass
(
 Id int unique not null,
 Uid int null,
 RequestDateTime DATETIME null,
 Constraint [FK_ForgotPass_user_Details]FOREIGN KEY([Uid])References[user_Details]([u_id])
);

select * from ForgotPass;