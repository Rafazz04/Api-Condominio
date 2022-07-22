SELECT 
	C.Nome AS Bairro,
	AVG(M.Idade) AS 'Media Idade'
FROM Morador M
	INNER JOIN Familia F ON F.Id = M.IdFamilia
	INNER JOIN Condominio C ON C.Id = F.IdCondominio
GROUP BY C.Nome;