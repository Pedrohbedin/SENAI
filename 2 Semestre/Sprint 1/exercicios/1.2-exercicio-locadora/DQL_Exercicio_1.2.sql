--DQL

--listar todos os alugueis mostrando as datas de início e fim, o nome do cliente que alugou e nome do modelo do carro

SELECT 
	Aluguel.DataDeRetiro AS Retirada,
	Aluguel.DataDevolucao AS Devolução, 
	Cliente.Nome AS Nome, 
	Marca.Nome AS Marca
FROM 
	Veiculo, Aluguel, Cliente,Marca 
WHERE 
	Cliente.IdCliente = Aluguel.IdCliente
	AND Veiculo.IdVeiculo = Aluguel.IdVeiculo
	AND Marca.IdMarca = Veiculo.IdMarca

--listar os alugueis de um determinado cliente mostrando seu nome, as datas de início e fim e o nome do modelo do carro

SELECT 
	Aluguel.DataDeRetiro AS Retirada,
	Aluguel.DataDevolucao AS Devolução, 
	Cliente.Nome AS Nome, 
	Marca.Nome AS Marca
FROM 
	Veiculo, Aluguel, Cliente,Marca 
WHERE 
	Cliente.IdCliente = Aluguel.IdCliente
	AND Veiculo.IdVeiculo = Aluguel.IdVeiculo
	AND Marca.IdMarca = Veiculo.IdMarca
ORDER BY Cliente.Nome ASC