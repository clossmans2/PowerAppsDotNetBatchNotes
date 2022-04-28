/**
	Temp Table example
**/
-- Info Gathering
SELECT * FROM [WideWorldImporters].[Warehouse].[StockItems]
SELECT * FROM [WideWorldImporters].[Purchasing].[Suppliers]
SELECT * FROM [WideWorldImporters].[Warehouse].[Colors]

SELECT [SupplierId], COUNT([StockItemName]) as 'Items in Stock'
FROM [WideWorldImporters].[Warehouse].[StockItems]
GROUP BY [SupplierID]


-- Create the Temp Table
SELECT 
	si.[StockItemID],
	sup.[SupplierName],
	si.[StockItemName], 
	col.[ColorName], 
	si.[UnitPrice] 

-- TEMP TABLE CREATION
INTO #WarehouseStockReport -- Temp table always starts with #

FROM [WideWorldImporters].[Warehouse].[StockItems] as si
LEFT JOIN [WideWorldImporters].[Purchasing].[Suppliers] as sup
ON si.[SupplierID] = sup.[SupplierID]
LEFT JOIN [WideWorldImporters].[Warehouse].[Colors] as col
ON si.[ColorID] = col.[ColorID]
SELECT * FROM #WarehouseStockReport;


CREATE TABLE #WarehouseStockReport2 (
	[StockItemID] int NOT NULL,
	[SupplierName] VARCHAR(MAX) NULL,
	[StockItemName] VARCHAR(MAX) NULL, 
	[ColorName] VARCHAR(MAX) NULL, 
	[UnitPrice] MONEY NULL
)

INSERT INTO #WarehouseStockReport2
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
SELECT * FROM #WarehouseStockReport2;


SELECT * FROM [#WarehouseStockReport]
SELECT * FROM [#WarehouseStockReport2]

-- CAN DO THE SAME FOR GLOBAL TEMP TABLES
SELECT 
	si.[StockItemID],
	sup.[SupplierName],
	si.[StockItemName], 
	col.[ColorName], 
	si.[UnitPrice] 

-- GLOBAL TEMP TABLE CREATION
-- Global Temp table always starts with ##
INTO ##WarehouseStockReportGlobal 

FROM [WideWorldImporters].[Warehouse].[StockItems] as si
LEFT JOIN [WideWorldImporters].[Purchasing].[Suppliers] as sup
ON si.[SupplierID] = sup.[SupplierID]
LEFT JOIN [WideWorldImporters].[Warehouse].[Colors] as col
ON si.[ColorID] = col.[ColorID]