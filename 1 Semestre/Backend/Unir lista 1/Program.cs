string input = "";
do {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"\nDigite o valor número do exercício desejado\n");
    Console.ResetColor();
    
    for (int i = 0; i < 6; i++) {
        Console.WriteLine($"{i+1}º exercício");
        
    }
    input = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"\nIniciando o exercício {input}\n");
    Console.ResetColor();
    

    switch (input) {
    case "1":
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow; 
    Console.WriteLine($"Iniciando exercício 1...");
    Console.ResetColor();

    Console.WriteLine($"Digite o valor do seu salário:");
    float salario = float.Parse(Console.ReadLine());

    Console.WriteLine($"Digite o valor do total gasto:");
    float gasto = float.Parse(Console.ReadLine());

    string resposta = (gasto < salario) ? "\nGastos dentro do orçamento" : "\nOrçamento estourado";

    Console.WriteLine($"{resposta}");
    
    break;

    case "2":
    Console.WriteLine($"Digite o total de gols de um dos times:");
    int gols1 = int.Parse(Console.ReadLine());

    Console.WriteLine($"Digite o total de gols do outro time:");
    int gols2 = int.Parse(Console.ReadLine());

    if (gols1 == gols2){
        Console.WriteLine($"Empate");
        break;
    }

    Console.WriteLine((gols1 > gols2) ? "O vencedor foi o 1º time" : "O vencedor foi o 2º time");
    break;

    case "3":
        Console.WriteLine($"A ordem dos lados não interfere no resultado");
    Console.WriteLine($"Pressioe qualquer tecla para continuar...");
    Console.ReadLine();


    Console.WriteLine($"Digite a medida do lado a");
    float a = float.Parse(Console.ReadLine());

    Console.WriteLine($"Digite a medida do lado b");
    float b = float.Parse(Console.ReadLine());

    Console.WriteLine($"Digite a medida do lado c");
    float c = float.Parse(Console.ReadLine());

    if (a + b > c && a + c > b && b + c > a)
    {
        // Verifica o tipo do triângulo
        if (a == b && b == c)
        {
            Console.WriteLine("O triângulo é Equilátero.");
        }
        else if (a == b || a == c || b == c)
        {
            Console.WriteLine("O triângulo é Isósceles.");
        }
        else
        {
            Console.WriteLine("O triângulo é Escaleno.");
        }
    }
    else
    {
        Console.WriteLine("As medidas informadas não formam um triângulo válido.");
    }

    break;

    default:
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\nValor incorreto tente novamente...");
    Console.ResetColor();
    Console.ReadLine();
    
    break;
}
} while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6");



Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Fim do programa...");
    Console.ResetColor();