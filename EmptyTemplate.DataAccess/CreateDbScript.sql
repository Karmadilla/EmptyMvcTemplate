create database EmptyTemplate
go

use EmptyTemplate
go

create table [User]
(
	ID int primary key identity not null,
	Email nvarchar(50) not null,
	Username nvarchar(50) null,
	[Password] nvarchar(50) not null
)

insert into [User] (Email, Username, [Password])
values ('d@d.com', 'd', 'test')

select * from [User]