--Query:	
	
	SELECT 
  --Titulo as 'titulo',
    Autor AS 'autor', 
    AVG(PalabraAvg) AS 'palabra_avg'
FROM 
    Libros
WHERE 
    PalabraAvg > 120000
GROUP BY 
--Titulo,
    Autor
--PalabraAvg
ORDER BY 
    Palabra_avg DESC;
	
	
--Resultado:

autor           palabra_avg
Gabriel García	151666
Laura Restrepo	145000