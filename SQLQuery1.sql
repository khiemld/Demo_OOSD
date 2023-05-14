CREATE DATABASE Book_Demo

CREATE TABLE dbo.Employee(
	u_id int IDENTITY (1,1) NOT NULL,
	u_name nvarchar(30) not null,
	u_address nvarchar(30) not null,
	u_phone nvarchar(10) not null,
	u_email nvarchar(30) not null,
	u_password nvarchar(20) not null
)

CREATE TABLE dbo.Book(
	b_id int IDENTITY (1,1) NOT NULL,
	b_name nvarchar(30) not null,
	b_discription nvarchar(100),
	b_category nvarchar(20) not null,
	b_price int not null,
	b_author nvarchar(30) not null,
	b_date nvarchar(10) not null,
	b_publisher nvarchar(30) not null,
	b_quantity int not null,
)

INSERT INTO dbo.Employee (u_name, u_address, u_phone, u_email, u_password)
VALUES ('Le Duy Khiem', 'Thu Duc', 0123456789, 'khiem@gmail.com', '12345678');

INSERT INTO dbo.Book(b_name, b_discription, b_category, b_price, b_author, b_date, b_publisher, b_quantity)
VALUES ('Gian', 'Sach hay', 'Truyen ngan', 59000, 'Thich Nhat Hanh', '12/02/2002', 'Kim Dong', 50);


Select u_email, u_email from dbo.Employee where u_email = 'khiem@gmail.com' and u_password = '12345678'