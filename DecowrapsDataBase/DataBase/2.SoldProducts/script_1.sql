--Query:

SELECT 
    PL.Name AS 'Línea de Producto',
    P.Name AS 'Producto',
	SUM(SOD.Quantity) AS 'Total Vendido'
FROM 
    SalesOrderDetails SOD
INNER JOIN Products P ON SOD.ProductId = P.id
INNER JOIN ProductLines PL ON P.ProductLineId = PL.Id
INNER JOIN SalesOrders SO ON SOD.SaleOrderId = SO.id
WHERE 
    SO.CreatedOn BETWEEN '2020-01-01' AND '2020-08-31'
GROUP BY 
    PL.Name, P.Name
HAVING 
    SUM(SOD.Quantity) > 20
