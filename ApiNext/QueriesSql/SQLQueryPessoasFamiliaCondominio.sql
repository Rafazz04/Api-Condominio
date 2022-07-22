SELECT 
	M.Nome AS 'Pessoa',
	F.Nome AS 'Familia',
	C.Nome AS 'Condominio'
FROM Morador M
	INNER JOIN Familia F ON F.Id = M.IdFamilia
	INNER JOIN Condominio C ON C.Id = F.IdCondominio
ORDER BY M.Nome;