CREATE PROCEDURE procedure_name
@CampoBusca VARCHAR (50)
AS
Select 
	Paciente.Nome,
	DATEDIFF(YY, Paciente.DataNascimento, GETDATE()) AS Idade
FROM Paciente
WHERE Paciente.Nome LIKE @CampoBusca
WHERE Paciente.Nome = NULL 

DROP PROCEDURE procedure_name

EXEC procedure_name 'Jose'