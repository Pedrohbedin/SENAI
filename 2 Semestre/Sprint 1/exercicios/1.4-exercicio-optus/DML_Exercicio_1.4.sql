--DML

INSERT INTO Artistas(Nome)
	VALUES('Roberto Carlos')

INSERT INTO Albuns(IdArtista, Titulo, DataLancamento, Localizacao, QtdMinutos, Ativo)
	VALUES(1, 'Só Antigas', '13/11/2022', 'Rua Da Fé', '00:33:25', 1)

INSERT INTO Estilos(Nome)
	VAlUES('MBP')

INSERT INTO AlbunsEstilos
	VALUES(2, 1)

INSERT INTO Usuario(Nome, Email, Senha)
	VALUES('Pedro', 'pedro@gmail.com', '1234')

SELECT * FROM Artistas
SELECT * FROM Albuns
SELECT * FROM Estilos
SELECT * FROM AlbunsEstilos
SELECT * FROM Usuario