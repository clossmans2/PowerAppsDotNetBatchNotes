insert into dbo.Inventory (Make, Model, Trim, Color, CurrentMileage, Year, Price, CreatedDate, HasWheels, ModifiedDate) 
values 
	('Honda', 'Civic', 'SI', 'Grey', 234875, 2010, 24000, GETDATE(), 1, GETDATE()),
	('Ferrari', 'Enzo', 'SI', 'Red', 20000, 2020, 100000, GETDATE(), 1, GETDATE()),
	('Infiniti', 'QX70', 'AWD', 'Black', 85000, 2015, 34000, GETDATE(), 1, GETDATE()),
	('Toyota', 'Camry', 'EX', 'Grey', 106843, 2010, 8000, GETDATE(), 1, GETDATE()),
	('Hyundai', 'Palisade', 'SE', 'Silver', 5000, 2022, 46000, GETDATE(), 1, GETDATE()),
	('Lamborghini', 'Murcielago', 'LP670-4 Coupe', 'Blue', 100000, 2010, 450000, GETDATE(), 1, GETDATE()),
	('Bat Mobile', 'Vengance', 'Wayne', 'Black', 100000, 1939, 10000000, GETDATE(), 1, GETDATE()),
	('Toyota', 'Corolla', 'Coupe', 'Black', 90000, 1996, 200, GETDATE(), 1, GETDATE()),
	('Volkswagon', 'LT 40', 'Mystery Machine', 'Tie Dye', 100000, 1978, 10000, GETDATE(), 1, GETDATE()),
	('DeLorean', 'DMC-12', 'FC', 'Silver', 52148, 1981, 69950, GETDATE(), 1, GETDATE());

exec dbo.QuickViewInventory;

EXEC dbo.InsertVehicleWithWheels 
		@make='Invisible Boat Mobile', 
		@model='Bikini Bottom', 
		@trim='none', 
		@color='none', 
		@currentMileage=100, 
		@year=2000, 
		@price=1000;

EXEC dbo.InsertVehicleWithoutWHeels
	@make='Bat Boat', 
	@model='Vengance', 
	@trim='Wayne', 
	@color='Blue', 
	@currentMileage=23485, 
	@year=1966, 
	@price=1000000.99;

/*
	How SQL runs queries
	ACID transactions

	Atomicity - transactions occur as a single unit, which either succeeds completely or fails completely
	Consistency - each transaction can only move the database from one valid state to another
	Isolation - Running queries concurrently is the same as running them one at a time
	Durability - Once a transation is committed it is saved permenatly even in the case of system failure
*/


Select * from dbo.Inventory;

Begin tran T1;
Update dbo.Inventory set Make = 'Something' Where Color = 'Grey';
Update dbo.Inventory set Model = 'Random' Where Id in (1001, 1005, 1010, 1012);

select * from dbo.Inventory;

rollback tran T1;

select * from dbo.Inventory;

Begin tran T2;
Update dbo.Inventory set Price = 124300.99 where Color = 'Grey';
Update dbo.Inventory set Trim = 'All Wheel Drive' Where Id = 1002;

select * from dbo.Inventory;

commit tran T2;

select * from dbo.Inventory;
