CREATE PROCEDURE procedure_name
AS
SELECT 
Medico.Nome AS M�dico,
	Especialidade.Titulo AS Especialidade
FROM Especialidade
	INNER JOIN Medico ON Especialidade.IdEspecialidade = Medico.IdEspecialidade
WHERE Especialidade.Titulo LIKE  'Cirurgi�o'

EXEC procedure_name;