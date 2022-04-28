-- COMMON TABLE EXPRESSIONS & TABLE VARIABLES

/**
	TABLE VARIABLES
	Stored in Tempdb
	Only available till end of batch
**/

DECLARE @ListOfWeekDays TABLE(
	DayNumber INT,
	DayAbbrev VARCHAR(40) ,
	FullDayName VARCHAR(40)
)
 
INSERT INTO @ListOfWeekDays
VALUES 
(1,'Mon','Monday')  ,
(2,'Tue','Tuesday') ,
(3,'Wed','Wednesday') ,
(4,'Thu','Thursday'),
(5,'Fri','Friday'),
(6,'Sat','Saturday'),
(7,'Sun','Sunday')	
SELECT * FROM @ListOfWeekDays
GO

--SELECT * FROM @ListOfWeekDays


WITH WarehouseStockReport3 AS (
	SELECT 
		si.[StockItemID],
		sup.[SupplierName],
		si.[StockItemName], 
		col.[ColorName], 
		si.[UnitPrice] 

	FROM [WideWorldImporters].[Warehouse].[StockItems] as si

	LEFT JOIN [WideWorldImporters].[Purchasing].[Suppliers] as sup
	ON si.[SupplierID] = sup.[SupplierID]
	LEFT JOIN [WideWorldImporters].[Warehouse].[Colors] as col
	ON si.[ColorID] = col.[ColorID]
)

SELECT * FROM WarehouseStockReport3;

