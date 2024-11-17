--QUERY:

SELECT 
    B.Vendedor as 'Vendedor',
    B.[Year] as 'Año',
    B.Mes as 'Mes',
    B.Price 'Price',
    B.Price * (
        SELECT TOP 1 A.Price 
        FROM Datos2 A
        WHERE A.Vendedor = B.Vendedor
          AND A.[Year] = B.[Year]
          AND A.Mes < B.Mes
        ORDER BY A.Mes ASC
    ) AS 'Multiplicación'
FROM 
    Datos2 B
ORDER BY 
    B.Vendedor, B.[Year], B.Mes;
	
	
--Resultado:

Vendedor	Año		Mes	Price		Multiplicación
MFA			2019	1	0.0550		NULL
MFA			2019	2	0.1000		0.00550000
MFA			2020	1	0.1280		NULL
MFA			2020	2	0.0911		0.01166080
MFA			2020	3	0.1200		0.01536000
MS			2019	1	2520.0000	NULL
MS			2019	2	600.0000	1512000.00000000
MS			2020	1	455.5000	NULL
MS			2020	2	1080.0000	491940.00000000
MS			2020	3	120.0000	54660.00000000
ZB			2019	1	0.0550		NULL
ZB			2019	2	0.0759		0.00417450
ZB			2020	1	0.1280		NULL
ZB			2020	2	0.0750		0.00960000
ZB			2020	3	0.0750		0.00960000