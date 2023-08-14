--DDL

CREATE DATABASE [Event+]

USE [Event+]

CREATE TABLE TipoUsuario 
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(20) NOT NULL UNIQUE 
)

CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTiposUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
	Email VARCHAR(50),
	Senha VARCHAR(25)
)

CREATE TABLE Paciente 
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	Nome VARCHAR(50) NOT NULL,
	DataNascimento DATE NOT NULL,
	Telefone CHAR(11) NOT NULL UNIQUE,
	RG CHAR(9) NOT NULL UNIQUE,
	CPF CHAR(11) NOT NULL UNIQUE,

)

