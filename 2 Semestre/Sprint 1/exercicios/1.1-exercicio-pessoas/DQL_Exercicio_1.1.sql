--DQL

--listar as pessoas em ordem alfabética reversa, mostrando seus telefones, seus e-mails e suas CNHs

--Script sem usar JOIN

SELECT 
	P.Nome, 
	Telefone.Numero AS Telefone, 
	Email.Endereco AS Email, 
	P.CNH
FROM 
	Pessoa AS P, EMAIL, Telefone
WHERE 
	P.IdPessoa = EMAIL.IdPessoa 
	AND P.IdPessoa = Telefone.IdPessoa
ORDER BY 
	Nome DESC