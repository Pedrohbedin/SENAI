--DML

INSERT INTO Artista(Nome)
	VALUES('Roberto Carlos')

INSERT INTO Albuns(IdArtista, Titulo, DataLancamento, Localizacao, QtdMinutos, Ativo)
	VALUES(1, 'Só Antigas', '13/11/2022', 'Rua Da Fé', '00:33:25', 1)

INSERT INTO Estilo(Nome)
	VAlUES('MBP')

INSERT INTO AlbunsEstilos(IdAlbum, IdEstilo)
	VALUES(1, 1)

INSERT INTO Usuarios(Nome, Email, Senha)
	VALUES('Pedro', 'pedro@gmail.com', '1234')

SELECT * FROM Artista
SELECT * FROM Albuns
SELECT * FROM Estilo
SELECT * FROM AlbunsEstilos
SELECT * FROM Usuarios