USE GameShopDB;

-- Delete from table and reset PK index counter to 0 (reseting id counter)
--DELETE FROM "User";
--DBCC CHECKIDENT('User', RESEED, 0)

-- CHECK FOR DUPLICATED PLACES IN SAME PROVINCE
--SELECT place.PLACE_NAME, prov.PROV_NAME, COUNT(*) FROM Place as place LEFT JOIN Province as prov
--ON place.PROV_ID = prov.PROV_ID
--GROUP BY place.PLACE_NAME, prov.PROV_NAME HAVING COUNT(*) > 1

-- CHECK FOR DUPLICATED PLACES IN WHOLE COUNTRY
--SELECT place.PLACE_NAME, prov.PROV_NAME FROM Place as place LEFT JOIN Province as prov
--ON place.PROV_ID = prov.PROV_ID
--WHERE place.PLACE_NAME IN (SELECT PLACE_NAME FROM Place GROUP BY PLACE_NAME HAVING COUNT(*) > 1)


SELECT * FROM Province
SELECT * FROM Place