--DML

INSERT INTO TipoUsuario
	VALUES('Paciente')


INSERT INTO Usuario
	VALUES(4, 'Jose@gmail.com', '1234')

INSERT INTO Paciente
	VALUES(2, 'Jose','2005/01/01', 11234567890, 123456789, 12345678901, 12345678, 'Avenida Goias')

INSERT INTO Especialidade 
	VALUES('Cirurgião')

INSERT INTO Clinica
	VALUES('HClinic', 12345678901234, 'HealthClinic', '08:30:00', '20:00:00', 'Manoel COelho 328')

INSERT INTO Medico
	VALUES(2,1,1,'Pedro','123456a')

INSERT INTO Situacao
	VALUES(0)
	
INSERT INTO Consultas
	VALUES(2, 3, '2023/08/23', 'Retirada do apêndice', 1)

SELECT * FROM TipoUsuario
SELECT * FROM Usuario
SELECT * FROM Paciente
SELECT * FROM Especialidade
SELECT * FROM Clinica
SELECT * FROM Medico
SELECT * FROM Consultas





