--DQL

--listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro

SELECT 
	Aluguel.DataDeRetiro AS Retirada,
	Aluguel.DataDevolucao AS Devolução, 
	Cliente.Nome AS Nome, 
	Marca.Nome AS Marca
FROM 
	Aluguel
inner join Cliente on Aluguel.IdCliente = Cliente.IdCliente
inner join Veiculo as V on Aluguel.IdVeiculo = V.IdVeiculo
inner join Marca on V.IdMarca = Marca.IdMarca


--listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT 
	Aluguel.DataDeRetiro AS Retirada,
	Aluguel.DataDevolucao AS Devolução, 
	Cliente.Nome AS Nome, 
	Modelo.Nome AS Modelo
FROM 
	Aluguel
inner join Cliente on Aluguel.IdCliente = Cliente.IdCliente
inner join Veiculo AS V on Aluguel.IdVeiculo = V.IdVeiculo
inner join Modelo on V.IdModelo = Modelo.IdModelo
ORDER BY Cliente.Nome ASC