USE Filmes_Tarde

INSERT INTO Genero
VALUES
(
	'A��o'
)

INSERT INTO Filme 
VALUES 
(
2,'Carros'
)

SELECT 
Genero.Nome,
Filme.Titulo
FROM Filme
INNER JOIN Genero ON Filme.IdGenero = Genero.IdGenero
