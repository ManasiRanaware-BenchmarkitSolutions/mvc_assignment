create database EFDBDDoctorPatient
go

use EFDBDDoctorPatient
go

create table Doctor(
DoctorID bigint primary key identity(1,1),
DoctorName varchar(50),
Specialization varchar(50),
Address varchar(50),
Contact varchar(50))
go

create table Patient(
PatientID bigint primary key identity(1,1),
PatientName varchar(50),
Gender varchar(50),
Age int,
Address varchar(50),
Contact varchar(50),
DOA datetime,
DoctorID bigint references Doctor(DoctorID) on delete set null)
go

insert into Doctor values('Dr.Kalyani Joshi','Psychiatrist', 'Pune', '9898987665')

insert into Patient values('Parth Jog','Male',10,'Pune', '9090987665','2020-1-12',1)

alter table Doctor add Photo varchar(max)
alter table Patient add Photo varchar(max)

select * from Patient
select * from Doctor
