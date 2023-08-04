--DQL

-- listar todos os usuários administradores, sem exibir suas senhas

SELECT 
	Usuario.Nome,
	Usuario.Email
FROM
	Usuario
WHERE 
	Usuario.Permisao = 1

-- listar todos os álbuns lançados após o um determinado ano de lançamento

SELECT 
	Albuns.Titulo
FROM 
	Albuns
WHERE 
	Albuns.DataLancamento > '2017-01-01 00:00:00.000'

-- listar os dados de um usuário através do e-mail e senha

SELECT 
	Usuario.Nome,
	Usuario.Email,
	Usuario.Permisao
FROM
	Usuario AS U
inner join Usuario on Usuario.Email = '' AND Usuario.Senha = ''

-- listar todos os álbuns ativos, mostrando o nome do artista e os estilos do álbum 

SELECT 
	Albuns.Titulo,
	Artistas.Nome,
	Estilos.Nome
FROM 
	AlbunsEstilos AS A
inner join Albuns on Albuns.IdAlbum = A.IdAlbum
inner join Artistas on Albuns.IdArtista = Artistas.IdArtista
inner join Estilos on A.IdEstilo = Estilos.IdEstilo
WHERE 
	Albuns.Ativo = 1

