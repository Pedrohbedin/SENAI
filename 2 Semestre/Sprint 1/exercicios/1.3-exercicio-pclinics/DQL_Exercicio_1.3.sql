--DQL

-- listar todos os veterinários (nome e CRMV) de uma clínica (razão social)

SELECT 
	Veterinario.NomeVeterinario AS Veterinario,
	Veterinario.CRMV AS CRMV,
	Clinica.NomeClinica AS Clinica
FROM 
	 Veterinario
inner join Clinica on Veterinario.IdClinica = Clinica.IdClinica

-- listar todas as raças que começam com a letra S

SELECT
	Raca.NomeRaca AS Raça
FROM
	Raca
WHERE
	Raca.NomeRaca LIKE 'S%'

-- listar todos os tipos de pet que terminam com a letra O

SELECT
	TipoDePet.NomeTipoDePet AS Espécie
FROM
	TipoDePet
WHERE
	TipoDePet.NomeTipoDePet LIKE '%o'

-- listar todos os pets mostrando os nomes dos seus donos

SELECT 
	Pets.NomePet,
	Dono.NomeDono AS Dono
FROM 
	Pets
inner join Dono on Pets.IdDono = Dono.IdDono



-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, 
-- a raça e o tipo do pet que foi atendido, o nome do dono do pet e o nome da clínica onde o pet foi atendido

SELECT
	Veterinario.NomeVeterinario AS Veterinario,
	Pets.NomePet AS Pet,
	Raca.NomeRaca AS Raça,
	TipoDePet.NomeTipoDePet AS Espécie,
	Dono.NomeDono AS Dono
FROM 
	Atendimento
inner join Veterinario on Atendimento.IdVeterinario = Veterinario.IdVeterinario
inner join Pets on Atendimento.IdPets = Pets.IdPets
inner join Raca on Pets.IdRaca = Raca.IdRaca 
inner join TipoDePet on Pets.IdTipoDePet = TipoDePet.IdTipoDePet
inner join Dono on Pets.IdDono = Dono.IdDono
