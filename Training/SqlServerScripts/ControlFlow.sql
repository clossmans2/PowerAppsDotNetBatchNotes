USE [MyDealership]
MakeItSo

BEGIN TRANSACTION;

BEGIN TRY
	DELETE FROM [Inventory]
	WHERE Id  IN (SELECT Id FROM [Inventory] WHERE Make = 'Honda')
	--SELECT 1/0;
END TRY
BEGIN CATCH
	SELECT CONCAT(ERROR_NUMBER(), ' :: Line No ', ERROR_LINE(), ' -- ', ERROR_MESSAGE())
	
	IF @@TRANCOUNT > 0
		ROLLBACK TRANSACTION;

	SELECT * FROM [Inventory];
END CATCH;

IF @@TRANCOUNT > 0
	COMMIT TRANSACTION;

ELSE IF ((SELECT HasWheels FROM [Inventory] WHERE Id = 1001) > 0)
	ROLLBACK TRANSACTION;

ELSE IF @@FETCH_STATUS > 1
	SELECT * FROM [Inventory];
	SELECT * FROM [Inventory];
	SELECT * FROM [Inventory];
	SELECT * FROM [Inventory];
	SELECT * FROM [Inventory];
	SELECT * FROM [Inventory];


CASE Make
	
	WHEN 'Honda' 
		THEN UPDATE [Inventory] Set [Trim] = 'SI'
	ELSE
		SELECT 'No Values to Update'


