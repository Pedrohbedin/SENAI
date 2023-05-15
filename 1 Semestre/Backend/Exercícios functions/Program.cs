Console.WriteLine(@$"Digite o número correspondente á operação desejada
______________________
|                    |
|   1 : soma         |
|   2 : divisão      |
|   3 : multiplicação|
|   4 : subtração    |
|____________________|
");
int resposta = int.Parse(Console.ReadLine());

switch (resposta) {
    case 1:
    float n1 = InserirX();
    float n2 = InserirY();
    Console.WriteLine($"O resultado da sua soma é: {n1 + n2}");
    break;
    case 2:
    float n3 = InserirX();
    float n4 = InserirY();
    Console.WriteLine($"O resultado da sua divisão é: {n3 / n4}");
    break;
    case 3:
    float n5 = InserirX();
    float n6 = InserirY();
    Console.WriteLine($"O resultado da sua multiplicação é: {n5 * n6}");
    break;
    case 4:
    float n7 = InserirX();
    float n8 = InserirY();
    Console.WriteLine($"O resultado da sua subtração é: {n7 + n8}");
    break;
}

static float InserirX() {
    Console.WriteLine($"Escreva o primeiro valor");
    float x = float.Parse(Console.ReadLine());

    return x;
}

static float InserirY() { 
        Console.WriteLine($"Escreva o segundo valor");
    float y = float.Parse(Console.ReadLine());

    return y;
}