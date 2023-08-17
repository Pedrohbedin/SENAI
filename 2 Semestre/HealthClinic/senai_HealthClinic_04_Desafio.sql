CREATE PROCEDURE procedure_name
AS
SELECT 
Medico.Nome AS Médico,
	Especialidade.Titulo AS Especialidade
FROM Especialidade
	INNER JOIN Medico ON Especialidade.IdEspecialidade = Medico.IdEspecialidade
WHERE Especialidade.Titulo LIKE  'Cirurgião'

EXEC procedure_name;