USE GameShopDB
BULK
INSERT Place
-- Source file format: UCS-2 Little Endian
FROM 'C:\Users\Szymon\Documents\GitHub\GamesShop\server\src\DB\DB_miejsc_woj\places.csv'
WITH
(
	FIELDTERMINATOR = ';',
	ROWTERMINATOR = '0x0a'
)
GO

-- Delete from table and reset PK index counter to 0
--DELETE FROM Place
--DBCC CHECKIDENT('Place', RESEED, 0)

SELECT * FROM Place
SELECT pl.PLACE_NAME, pr.PROV_NAME FROM Place pl, Province pr WHERE pl.PROV_ID = pr.PROV_ID
AND pl.PLACE_NAME = 'someCityToCheck'