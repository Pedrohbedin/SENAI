--DQL 

SELECT
Consultas.IdConsulta,
Consultas.DataAgendamento AS [Data],
Clinica.Nome AS Clinica,
Paciente.Nome AS Paciente,
Medico.Nome AS Médico,
Especialidade.Titulo Especialidade,
Consultas.Descricao AS Descrição,
Medico.CRM AS CRM,
CASE WHEN Situacao.Situacao = 0 THEN 'Confirmada' ELSE 'Não Confirmada' END AS Situação
FROM Consultas
INNER JOIN Medico ON Consultas.IdMedico = Medico.IdMedico
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Paciente ON Consultas.IdPaciente = Paciente.IdPaciente
INNER JOIN Situacao ON Consultas.IdSituacao = Situacao.IdSituacao
INNER JOIN Clinica ON Medico.IdClinica = Clinica.IdClinica

--Criar função que determina os médicos de uma determinada especialidade

SELECT 
Medico.Nome AS Médico,
	Especialidade.Titulo AS Especialidade
FROM Especialidade
	INNER JOIN Medico ON Especialidade.IdEspecialidade = Medico.IdEspecialidade
WHERE Especialidade.Titulo LIKE  'Cirurgião';

-- Criar procedure para retornar a idade de um determinado usuário  

Select 
	Paciente.Nome,
	DATEDIFF(YY, Paciente.DataNascimento, GETDATE()) AS Idade
FROM Paciente
	

