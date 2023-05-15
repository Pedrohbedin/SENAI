// Escreva um programa que pergunte o dia, mês e ano do aniversário de uma pessoa e diga se a data é válida ou não. Caso não seja, diga o motivo. Suponha que todos os meses tem 31 dias e que estejamos no ano de 2013. //


Console.WriteLine($"Diga o dia do seu aniversário:");
int dia = int.Parse(Console.ReadLine());
Console.WriteLine($"Diga o mês do seu aniversário:");
int mes = int.Parse(Console.ReadLine());
Console.WriteLine($"Diga o ano do seu aniversário:");
int ano = int.Parse(Console.ReadLine());

if (dia > 31)
{
    Console.WriteLine($"Dia invalido");
    
}

if (mes > 12)
{
    Console.WriteLine($"Mês invalido");
    
}

if (ano > 2013)
{
    Console.WriteLine($"Ano invalido");
    
}

if (dia < 31 && mes < 12 && ano < 2013) {
    Console.WriteLine($"Data válida");
}

