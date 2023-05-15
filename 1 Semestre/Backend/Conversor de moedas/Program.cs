using Conversor_de_moedas;
using System.Globalization;


float valorReal;
float valorDolar;
float output;
string resposta = "";
string input = "";

do{
Console.WriteLine(@$"
___________________________________
|                                 |
|    Escolha a opção desejada     |
|_________________________________|
|                                 |
|   [1] Dolar para real           |
|                                 |
|   [2] Real para dolar           |
|                                 |
|   [3] Exit                      |
|_________________________________|
");

resposta = Console.ReadLine()!;

switch (resposta) {
    case "1":
    do{
        Console.Clear();
        Console.WriteLine($"Insira o valor:");
        input = Console.ReadLine()!;
        bool isNumeric = float.TryParse(input, out valorReal);
        output = NewClass.ConverterParaDolar(valorReal);
    } while (valorReal == 0);
    Console.WriteLine($"\nO valor da conversão é {output.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");
    break;

    case "2":
    do{
        Console.Clear();
        Console.WriteLine($"Insira o valor:");
        input = Console.ReadLine()!;
        bool isNumeric = float.TryParse(input, out valorDolar);
        output = NewClass.ConverterParaReais(valorDolar);
    } while (valorDolar == 0);
    Console.WriteLine($"\nO valor convertido é {output.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");
    break;
    case"3":
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Finalizando o programa...");
    Console.ResetColor();
    break;
    default:
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Resposta inválida, tente novamente...");
    Console.ResetColor();
    break;
}

} while(resposta != "3");
