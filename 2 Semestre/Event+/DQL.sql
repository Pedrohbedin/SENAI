--DDL Data Definition Lenguage 

CREATE DATABASE [Event+_Tarde]
USE [Event+_Tarde]

--CRIAR AS TABELAS 

CREATE TABLE TiposDeUsuario 
(
	IdTipoDeUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(50) NOT NULL UNIQUE 
)

CREATE TABLE TiposDeEvento
(
	IdTipoDeEvento INT PRIMARY KEY IDENTITY,
	TituloTipoEvento VARCHAR(50) NOT NULL 
)

CREATE TABLE Instituicao
(
	IdInstituicao INT PRIMARY KEY IDENTITY,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	Endereco VARCHAR(200) NOT NULL,
	NomeFantasia VARCHAR(200) NOT NULL
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY, 
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES TiposDeUsuario(IdTipoDeUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR(25) NOT NULL
)

CREATE TABLE Evento 
(
	IdEvento INT PRIMARY KEY IDENTITY,
	IdTipoDeEvento INT FOREIGN KEY REFERENCES TiposDeEvento(IdTipoDeEvento),
	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao),
	Nome VARCHAR(50) NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
	DataEvento DATE NOT NULL,
	HorarioEvento TIME(0) NOT NULL
)


CREATE TABLE PresencasEvento
(
	IdPresencasEvento INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	Situacao BIT DEFAULT(0)
)

CREATE TABLE ComentarioEvento
(
	IdComentarioEvento INT PRIMARY KEY,
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento) NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	Descricao VARCHAR(50) NOT NULL,
	DataComentario DATETIME DEFAULT GETDATE(),
	Exibe BIT NOT NULL
)

SELECT Usuario.Nome, 
TiposDeUsuario.TituloTipoUsuario AS Permições, 
Evento.DataEvento AS [Data do evento],
Evento.HorarioEvento AS [Horario do evento],
CONCAT(Instituicao.Endereco,' - ', Instituicao.NomeFantasia) AS [Edenreço-Nome], 
TiposDeEvento.TituloTipoEvento AS [Tipo de evento],
Evento.Nome AS Evento,
Evento.Descricao AS [Descrição do evento],
ComentarioEvento.Descricao AS Comentario,
CASE WHEN PresencasEvento.Situacao = 0 THEN 'Confirmado' ELSE 'Não Confirmado' END AS Situação
FROM PresencasEvento 
INNER JOIN Usuario on PresencasEvento.IdUsuario = Usuario.IdUsuario
INNER JOIN TiposDeUsuario on Usuario.IdTipoDeUsuario = TiposDeUsuario.IdTipoDeUsuario
INNER JOIN Evento on PresencasEvento.IdEvento = Evento.IdEvento
INNER JOIN Instituicao on Evento.IdInstituicao = Instituicao.IdInstituicao
INNER JOIN TiposDeEvento on Evento.IdTipoDeEvento = TiposDeEvento.IdTipoDeEvento
INNER JOIN ComentarioEvento on Evento.IdEvento = ComentarioEvento.IdEvento
