USE [Event+_Tarde]

--DML

INSERT INTO TiposDeUsuario(TituloTipoUsuario) 
VALUES
(
	'Comum'
);

SELECT * FROM TiposDeUsuario

INSERT INTO TiposDeEvento(TituloTipoEvento) VALUES
(
		'Code'
);

SELECT * FROM TiposDeEvento

INSERT INTO Instituicao(CNPJ, Endereco, NomeFantasia)
VALUES('93093847561789', 'Rua Wintere', 'Gamer Club')

SELECT * FROM Instituicao

INSERT INTO Usuario(IdTipoDeUsuario, Nome, Email, Senha)
VALUES
(
2,'Felipe', 'felipe@gmail.com', '123'
)

SELECT * FROM Usuario

INSERT INTO Evento(IdTipoDeEvento, IdInstituicao, Nome, Descricao, DataEvento, HorarioEvento)
VALUES
(
2, 2, 'Dia Gamer', 'Hoje faremos games', '2023-09-10', '12:00:00'
)

SELECT * FROM Evento

INSERT INTO PresencasEvento(IdUsuario, IdEvento)
VALUES
(
	2,4
)

INSERT INTO ComentarioEvento(IdEvento, IdUsuario, Descricao, Exibe)
VALUES(4,2,'Não Gostei muito', 0)


