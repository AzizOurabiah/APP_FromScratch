--Création de database
create database EmployeeDB2
go

use EmployeeDB2
go

--création des tables
create table dbo.Department(
DepartmentId int identity(1,1),
DepartmentName varchar(500)
)

select * from dbo.Department

insert into dbo.Department values ('Support')
insert into dbo.Department values ('IT')

drop table dbo.Employee

create table dbo.Employee(
EmployeeId int identity(1,1),
EmployeeName varchar(500),
Department varchar(500),
DateOfJoining date,
PhotoFileName varchar(500)
)
insert into dbo.Employee values('Sam', 'It', '2020-06-01', 'anonymous.png')

select * from Employee


