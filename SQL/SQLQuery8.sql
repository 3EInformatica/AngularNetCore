SELECT  *   --seleziono tutti i campi
FROM [Products]
--WHERE ProductName<>'Chang'
--WHERE ProductName LIKE 'ch%'  --inizia con ch
--WHERE ProductName LIKE '%a'  --finisce con a
--WHERE ProductName LIKE '%a%'    --contiene a
--WHERE  ProductName NOT LIKE '%a%'    -- non contiene a
--WHERE NOT CategoryID =2
--WHERE CategoryID=2 OR UnitPrice>10.0
--WHERE CategoryID=1 OR CategoryID=2  OR CategoryID=4
WHERE CategoryID NOT IN (1,2,4)
ORDER BY UnitPrice desc, ProductName  --decrescente per unitprice, crescente per ProductName

SELECT CategoryID , COUNT(1)  Conteggio
FROM Products
WHERE UnitPrice>5
GROUP BY CategoryID
HAVING COUNT(1)>10
ORDER BY 2  --ORDER BY COUNT(1)


SELECT ProductName,UnitPrice*UnitsInStock ValoreMagazzino
FROM Products

SELECT Categories.CategoryName, SUM( UnitPrice*UnitsInStock) ValoreMagazzino
FROM Products
INNER JOIN Categories ON Products.CategoryID=Categories.CategoryID
GROUP BY Categories.CategoryName

SELECT CategoryName, SUM( UnitPrice*UnitsInStock) ValoreMagazzino
FROM Products p
INNER JOIN Categories c ON p.CategoryID=c.CategoryID
GROUP BY c.CategoryName

SELECT *
FROM Products p
INNER JOIN Categories c ON p.CategoryID=c.CategoryID
INNER JOIN Suppliers s ON p.SupplierID=s.SupplierID


SELECT ProductName,CategoryName, CompanyName
FROM Products p
INNER JOIN Categories c ON p.CategoryID=c.CategoryID
INNER JOIN Suppliers s ON p.SupplierID=s.SupplierID
WHERE UnitPrice>10 AND c.CategoryID=2
ORDER BY ProductName

--10248
Customers.CompanyName, ProductName, OrderDetails.QUantity, Products.UnitPrice

SELECT c.CompanyName,p.ProductName,od.Quantity,p.UnitPrice , s.CompanyName
FROM Customers c
INNER JOIN Orders o on c.CustomerID=o.CustomerID
INNER JOIN [Order Details] od on o.OrderID=od.OrderID
INNER JOIN Products p on p.ProductID=od.ProductID
INNER JOIN Shippers s on s.ShipperID=o.ShipVia
WHERE o.OrderID=10248
select * from Orders
--Shippers Name, Numero di ordini
SELECT s.CompanyName,YEAR(o.OrderDate) Anno, COUNT(*) Spedizioni
FROM Shippers s
INNER JOIN Orders o on s.ShipperID=o.ShipVia 
--WHERE o.OrderDate >= '1997-01-01' and o.OrderDate<='1997-12-31'
--WHERE o.OrderDate BETWEEN '1997-01-01' AND '1997-12-31'
--WHERE YEAR(o.OrderDate)=1997
--WHERE DATEPART(year,o.OrderDate)=1997
GROUP BY s.CompanyName, YEAR(o.OrderDate)
--ORDER BY 1,2
ORDER BY s.CompanyName,YEAR(o.OrderDate) desc

SELECT t.OrderID,t.giorniSpedizione,t.media,
CASE 
	WHEN giorniSpedizione>media THEN 'KO'
	WHEN giorniSpedizione=media THEN '--'
	ELSE 'OK'
END
FROM 
(
	select OrderID, 
	OrderDate,
	ShippedDate,
	DATEDIFF(day, OrderDate,ShippedDate) giorniSpedizione,
	(select AVG(DATEDIFF(day, OrderDate,ShippedDate)) FROM Orders) media
	FROM Orders
) t

select MIN(DATEDIFF(day, OrderDate,ShippedDate)) minimo,
MAX(DATEDIFF(day, OrderDate,ShippedDate)) massimo,
AVG(DATEDIFF(day, OrderDate,ShippedDate)) media, 
COUNT(1) numeroOrdini
FROM Orders