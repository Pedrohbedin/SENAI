USE Exercicio_1_1

--Inserindo valores as colunas 

INSERT INTO Pessoa(Nome, CNH) 
VALUES 
	('Gabriel', '125235657'),
	('Vininicius', '123452341'),
	('Vitória', '123534512'),
	('Gustavo', '9113456')

INSERT INTO Email(IdPessoa, Endereco) VALUES (4,'casa232@gmail.com')

INSERT INTO Telefone(IdPessoa, Numero) VALUES (4, '4931242613')


SELECT * FROM 
	Email,
	Pessoa,
	Telefone