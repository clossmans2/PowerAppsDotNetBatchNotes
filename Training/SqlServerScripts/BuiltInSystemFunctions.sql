SELECT ROUND(125.315, 2);
SELECT ROUND(125.315, 2, 0);
SELECT ROUND(125.315, 2, 1);
SELECT ROUND(125.315, 1);
SELECT ROUND(125.315, 0);
SELECT ROUND(125.315, -1);
SELECT ROUND(125.315, -2);

SELECT CEILING($123.45), CEILING($-123.45), CEILING($0.0);  
SELECT FLOOR($123.45), FLOOR($-123.45), FLOOR($0.0);  


SELECT POWER(3, 3);
SELECT POWER(7, 2);
SELECT POWER(42, 1);
SELECT POWER(75, 6);


SELECT 'SYSDATETIME()      ', SYSDATETIME();  
SELECT 'SYSDATETIMEOFFSET()', SYSDATETIMEOFFSET();  
SELECT 'SYSUTCDATETIME()   ', SYSUTCDATETIME();  
SELECT 'CURRENT_TIMESTAMP  ', CURRENT_TIMESTAMP;  
SELECT 'GETDATE()          ', GETDATE();  
SELECT 'GETUTCDATE()       ', GETUTCDATE(); 

SELECT 'SYSDATETIME()      ', CONVERT (date, SYSDATETIME());  
SELECT 'SYSDATETIMEOFFSET()', CONVERT (date, SYSDATETIMEOFFSET());  
SELECT 'SYSUTCDATETIME()   ', CONVERT (date, SYSUTCDATETIME());  
SELECT 'CURRENT_TIMESTAMP  ', CONVERT (date, CURRENT_TIMESTAMP);  
SELECT 'GETDATE()          ', CONVERT (date, GETDATE());  
SELECT 'GETUTCDATE()       ', CONVERT (date, GETUTCDATE());  

SELECT 'SYSDATETIME()      ', CONVERT (time, SYSDATETIME());  
SELECT 'SYSDATETIMEOFFSET()', CONVERT (time, SYSDATETIMEOFFSET());  
SELECT 'SYSUTCDATETIME()   ', CONVERT (time, SYSUTCDATETIME());  
SELECT 'CURRENT_TIMESTAMP  ', CONVERT (time, CURRENT_TIMESTAMP);  
SELECT 'GETDATE()          ', CONVERT (time, GETDATE());  
SELECT 'GETUTCDATE()       ', CONVERT (time, GETUTCDATE()); 

--SELECT DATEDIFF(datepart, first datetime, second datetime);
SELECT DATEDIFF(day, '04-25-2020 00:00:00.000', GETDATE());
--SELECT DATEADD(datepart to add to, number of that part to add, date time or datetime to add to) 
SELECT DATEADD(year, 150, GETDATE()); 
--datepart	abbreviation
--year	yy, yyyy
--quarter	qq, q
--month	mm, m
--dayofyear	dy, y
--day	dd, d
--week	wk, ww
--hour	hh
--minute	mi, n
--second	ss, s
--millisecond	ms
--microsecond	mcs
--nanosecond	ns

DECLARE @myName VARCHAR(10);
SET @myName = '   Seth  ';
SET @myName = TRIM(@myName);
SELECT @myName; -- 'Seth'
SELECT RTRIM(@myName);
SELECT LTRIM(@myName);
SELECT LTRIM(RTRIM(@myName));
--RTRIM = '   Seth'
--LTRIM = 'Seth  '
--LTRIM(RTRIM('Seth'))
--TRIM = 'Seth'
SELECT CONCAT('Peanut Butter', 'Chocolate', 'Banana', 'Orange');
SELECT CONCAT_WS(' ','Clossman','Seth');
--SELECT 
--STRING_AGG(CONCAT_WS( ',', database_id, recovery_model_desc, containment_desc), char(13)) AS DatabaseInfo
--1,SIMPLE,NONE 2,SIMPLE,NONE 3,FULL,NONE 4,SIMPLE,NONE 5,FULL,NONE 6,SIMPLE,NONE
--FROM sys.databases