CREATE FUNCTION IdadePaciente(@dt VARCHAR(50))
RETURNS TABLE
AS
RETURN (Select 
	Paciente.Nome,
	DATEDIFF(YY, Paciente.DataNascimento, GETDATE()) AS Idade
FROM Paciente
WHERE Paciente.Nome LIKE @dt)

SELECT * FROM IdadePaciente('Jose')