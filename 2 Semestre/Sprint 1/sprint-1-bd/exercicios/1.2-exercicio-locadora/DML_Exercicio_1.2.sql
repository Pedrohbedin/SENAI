--DML

INSERT INTO Empresa(NomeEmpresa)
	VALUES('NomeEmpresa')

DELETE FROM Empresa
	WHERE IdEmpresa = 

INSERT INTO Marca(Marca)
	VALUES('Fiat')


DELETE FROM Marca
	WHERE IdMarca = 

INSERT INTO Modelo(Modelo)
	VALUES('Fiesta')

DELETE FROM Modelo
	WHERE IdModelo = 3

INSERT INTO Veiculo(IdEmpresa, IdMarca, IdModelo, Placa)
	VALUES(1,1,1,'MXT6269'),(1,2,2,'MZK9188')

DELETE FROM Veiculo
	WHERE IdVeiculo = 4

INSERT INTO Cliente(Nome, CPF)
	VALUES('Xamou','73486289071'),('Todos', '85228152083')

DELETE FROM Cliente
	WHERE IdCliente = 5



INSERT INTO Aluguel(IdVeiculo, IdCliente)
	VALUES(3,3)

DELETE FROM Aluguel
	WHERE IdVeiculo = 4

SELECT * FROM Empresa
SELECT * FROM Marca
SELECT * FROM Modelo
SELECT * FROM Veiculo
SELECT * FROM Cliente
SELECT * FROM Aluguel