--DML

INSERT INTO Raca(Raca)
	VALUES('Pug'),('Shih Tzu')

INSERT INTO TipoDePet(TipoPet)
	VALUES('Cachorro')

INSERT INTO Dono(NomeDono)
	VALUES('Pedro')

INSERT INTO Pets(IdRaca, IdTipoDePet, NomePet, DataDeNascimento)
	VALUES(1, 1, 'Fred', '25/09/2018')

INSERT INTO Clinica(Endereco)
	VALUES('Rua Manoel Eudóxio Pereira')

INSERT INTO Veterinario
	VALUES(1,'Alberto','1234567890')

SELECT * FROM Raca
SELECT * FROM TipoDePet
SELECT * FROM Dono
SELECT * FROM Pets
SELECT * FROM Clinica
SELECT * FROM Atendimento