use practice;

select * from UserTbl;

create table BusCustomerDetails(UserId int Identity(1001,1) Primary Key, UserName varchar(20) Unique, Password varchar(20))
create table BusAdminDetails(UserId int Identity(1001,1) Primary Key, UserName varchar(20) Unique, Password varchar(20))
create table JourneyDetails(JourneyId int Identity(2001,1) Primary Key, BusId int Unique, NoOfSeats int, DeptStation varchar(20), DestStation varchar(20), DeptDate DateTime, RetDate DateTime)
create table BusTicketDetails(TicketId int Identity(3001,1) Primary Key, BusId int Foreign Key references JourneyDetails(BusId), CustomerId int Foreign Key references BusCustomerDetails(UserId), DeptStation varchar(20), DestStation varchar(20), DeptDate DateTime, RetDate DateTime, NoOfPassesngers int, TicketType int, BookingDate DateTime DEFAULT GETDATE(), TicketStatus varchar(10), PaymentStatus varchar(15))

select * from JourneyDetails
	
insert into BusTicketDetails values(67890,1001,'Hisar','Gurugram',15/02/2023,18/02/2023,3,'one way',GETDATE(),'Active','Not Paid'); SELECT CAST(scope_identity()) AS int