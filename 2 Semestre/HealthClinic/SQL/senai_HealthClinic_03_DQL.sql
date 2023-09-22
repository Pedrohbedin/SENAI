--DQL 

USE HealthClinic_Tarde

--Exibe todos os dados de uma ou mais consultas 

SELECT
Consultas.IdConsulta,
Consultas.DataAgendamento AS [Data],
Clinica.Nome AS Clinica,
Paciente.Nome AS Paciente,
Medico.Nome AS M�dico,
Especialidade.Titulo Especialidade,
Consultas.Descricao AS Descri��o,
Medico.CRM AS CRM,
CASE WHEN Situacao.Situacao = 0 THEN 'Confirmada' ELSE 'N�o Confirmada' END AS Situa��o
FROM Consultas
INNER JOIN Medico ON Consultas.IdMedico = Medico.IdMedico
INNER JOIN Especialidade ON Medico.IdEspecialidade = Especialidade.IdEspecialidade
INNER JOIN Paciente ON Consultas.IdPaciente = Paciente.IdPaciente
INNER JOIN Situacao ON Consultas.IdSituacao = Situacao.IdSituacao
INNER JOIN Clinica ON Medico.IdClinica = Clinica.IdClinica

--Determina os medicos de uma especialidade

SELECT 
Medico.Nome AS M�dico,
	Especialidade.Titulo AS Especialidade
FROM Especialidade
	INNER JOIN Medico ON Especialidade.IdEspecialidade = Medico.IdEspecialidade
WHERE Especialidade.Titulo LIKE  'Cirurgi�o';

-- Determina a idade de um paciente em espec�fico