--Query:

SELECT 
    A.Ciudad AS 'Ciudad',
    STUFF((
        SELECT 
            ', ' + M.Nombre
        FROM Ventas V
        INNER JOIN Motos M ON V.IdMoto = M.Id
        INNER JOIN Almacen A2 ON V.IdAlmacen = A2.Id
        WHERE 
            A2.Ciudad = A.Ciudad
        FOR XML PATH(''), TYPE
    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS 'Cantidad de motos vendidas'
FROM Almacen A
WHERE 
    A.Ciudad = 'Bogotá'
GROUP BY A.Ciudad;
	
	
--Resultado:	

Ciudad  Cantidad de motos vendidas
Bogotá	MT03, MT07, MT10