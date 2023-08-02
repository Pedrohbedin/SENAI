--DML

INSERT INTO Raca(Raca)
	VALUES('Pug'),('Shih Tzu')

INSERT INTO TipoPet(TipoPet)
	VALUES('Cachorro')

INSERT INTO Dono(NomeDono)
	VALUES('Carlos'), ('Edu')

INSERT INTO Pet(IdRaca, IdTipoPet, IdDono, Nome, DataDeNascimento)
	VALUES(1, 1, 1, 'Bob', '25/09/2019')

INSERT INTO Clinica(Endereco)
	VALUES('Rua Manoel Eudóxio Pereira')

SELECT * FROM Raca
SELECT * FROM TipoPet
SELECT * FROM Dono
SELECT * FROM Pet
SELECT * FROM Clinica