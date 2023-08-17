CREATE FUNCTION IdadePaciente(@Especialidade VARCHAR(50))
RETURNS TABLE
AS
RETURN (SELECT 
Medico.Nome AS M�dico,
	Especialidade.Titulo AS Especialidade
FROM Especialidade
	INNER JOIN Medico ON Especialidade.IdEspecialidade = Medico.IdEspecialidade
WHERE Especialidade.Titulo LIKE  @Especialidade)

SELECT * FROM IdadePaciente('Cirurgi�o')