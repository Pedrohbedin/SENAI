--DDL

CREATE DATABASE Exercicio_1_4

USE Exercicio_1_4

CREATE TABLE Artista
(
	IdArtista INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL
)

CREATE TABLE Albuns
(
	IdAlbum INT PRIMARY KEY IDENTITY,
	IdArtista INT FOREIGN KEY REFERENCES Artistas(IdArtista),
	Titulo VARCHAR(20) NOT NULL,
	DataLancamento DATE NOT NULL,
	Localizacao VARCHAR(20) NOT NULL,
	QtdMinutos TIME NOT NULL,
	Ativo BIT NOT NULL
)

CREATE TABLE Estilos
(
	IdEstilo INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL 
)

CREATE TABLE AlbunsEstilos 
(
	IdAlbum INT FOREIGN KEY REFERENCES Albuns(IdAlbum),
	IdEstilo INT FOREIGN KEY REFERENCES Estilos(IdEstilo)
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(20) NOT NULL,
	Email VARCHAR(30) NOT NULL UNIQUE,
	Senha VARCHAR(20) NOT NULL,
	Permisao BIT
)