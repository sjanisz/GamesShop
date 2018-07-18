USE GameShopDB
BULK
INSERT Province
-- Source file format: UCS-2 Little Endian
FROM 'C:\Users\Szymon\Documents\GitHub\GamesShop\server\src\DB\DB_miejsc_woj\provinces.csv'
WITH
(
	FIELDTERMINATOR = ';',
	ROWTERMINATOR = '0x0a'
)
GO

-- Delete from table and reset PK index counter to 0
--DELETE FROM Province
--DBCC CHECKIDENT('Province', RESEED, 0)

SELECT * FROM Province