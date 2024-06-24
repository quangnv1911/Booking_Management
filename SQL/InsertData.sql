use Group_5_SE1730_BookingManagement

GO
-- Role
insert into Roles (ID, [Name]) VALUES('ID1', 'admin')
insert into Roles (ID, [Name]) VALUES('ID2', 'user')
-- Role cho các chủ phòng trọ đăng bán
insert into Roles (ID, [Name]) VALUES('ID3', 'partner')

go
-- Guest
insert into dbo.Guest (Id, FirstName, MiddleName, LastName, Gender, Password, Address, City, Country, Status, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values (N'164e9416-8377-436b-8bdb-bb424a693b54', null, null, null, null, null, null, null, null, 1, N'partner@gmail.com', N'PARTNER@GMAIL.COM', N'partner@gmail.com', N'PARTNER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBJb5cCqnHdoh7N5KgOo8hTa8C6OafCkTO2xiNFIYcegDUFoSzWkoEhI61dEorbKgg==', N'UVDNEMPS7Y4S6KID6DPX3WYU43PJ7TCM', N'ffb66bea-28d1-4b16-b839-54bb2b865619', null, 0, 0, null, 1, 0);
insert into dbo.Guest (Id, FirstName, MiddleName, LastName, Gender, Password, Address, City, Country, Status, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values (N'23166d10-0db5-4a61-93b0-237b2ba77136', null, null, null, null, null, null, null, null, 1, N'user@gmail.com', N'USER@GMAIL.COM', N'user@gmail.com', N'USER@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFaCB4rK2vC8EhAXz3sYXtPmDAI1nzXOcMjNWfdY+I4h7+VzlYpeExQj5yiG9pNqLQ==', N'TAQZHGJDQSBBTQ2ZYBSAGVNFFWROXCU5', N'31fdc948-58b6-4116-83e4-f7e2fbb6ea92', null, 0, 0, null, 1, 0);
insert into dbo.Guest (Id, FirstName, MiddleName, LastName, Gender, Password, Address, City, Country, Status, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) values (N'56b0ecf7-d9b7-4a0f-8b80-f534ce516d41', null, null, null, null, null, null, null, null, 1, N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKZO5FyIYGaQ4xGSwTtUw4J4+W6Zg3WPCkBgNY0eqCCXNfkE0eWRvlSLO0jvV9EeSQ==', N'F3OATB6CMGXKL7JNBQWWRVHUZGYD2YYE', N'b308c82c-aea8-402b-a928-e04349ca19f7', null, 0, 0, null, 1, 0);

go
-- Thêm role cho user Admin và Partner
insert into dbo.UserRoles (UserId, RoleId) values (N'164e9416-8377-436b-8bdb-bb424a693b54', N'ID3');
insert into dbo.UserRoles (UserId, RoleId) values (N'23166d10-0db5-4a61-93b0-237b2ba77136', N'ID2');
insert into dbo.UserRoles (UserId, RoleId) values (N'56b0ecf7-d9b7-4a0f-8b80-f534ce516d41', N'ID1');

