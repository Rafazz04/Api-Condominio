SELECT 
	C.Nome AS Condominio,
	COUNT(M.Idade) AS 'Pessoas com 50 anos ou mais'
FROM Morador M
	INNER JOIN Familia F ON F.Id = M.IdFamilia
	INNER JOIN Condominio C ON C.Id = F.IdCondominio
WHERE M.Idade >= 50
group by C.Nome;


