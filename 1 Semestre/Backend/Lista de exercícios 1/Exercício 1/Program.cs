
Console.WriteLine($"Digite o valor do seu salário:");
float salario = float.Parse(Console.ReadLine());

Console.WriteLine($"Digite o valor do total gasto:");
float gasto = float.Parse(Console.ReadLine());

string resposta = (gasto < salario) ? "Gastos dentro do orçamento" : "Orçamento estourado";

Console.WriteLine($"{resposta}");

