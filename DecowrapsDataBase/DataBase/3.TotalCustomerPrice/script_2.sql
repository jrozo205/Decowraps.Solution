--Query:

SELECT 
    Cliente,
    SUM(Precio) AS 'Precio'
FROM 
    Datos1
WHERE 
    Pais = 'COLOMBIA' 
AND Precio > 80
GROUP BY 
    Cliente
HAVING 
    SUM(Precio) > 350
	
	
--Resultado: 
	
Cliente  Precio
GOMEZ	400
RUIZ	681