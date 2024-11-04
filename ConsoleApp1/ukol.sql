create database ukol;

use ukol;

create table Customer(
	ID int primary key identity(1,1),
	name varchar(20) unique not null,
	email varchar(50) not null 
	);

create table Orders(
	ID int primary key identity(1,1),
	customer_ID int not null foreign key references Customer(ID),
	deliveryTime DATE not null,
	productName varchar(20) not null,
	vipCustomer BIT not null
);