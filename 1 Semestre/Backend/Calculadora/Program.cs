Console.WriteLine($"Informe a operação desejada:\n");
Console.WriteLine
($@"
_______________________
|                     |
|    1 : soma         |
|    2 : subtração    |
|    3 : multiplicação|
|    4 : divisão      |
|_____________________|");  

int resposta = int.Parse(Console.ReadLine());



Console.WriteLine($"\nInforme o primeiro valor");
double n1 = double.Parse(Console.ReadLine());

Console.WriteLine($"\nInforme o segundo valor");
double n2 = double.Parse(Console.ReadLine());

switch (resposta) {
    case 1: 
    Console.WriteLine($"\nO resultado da soma é: {n1+n2}");
    break;
    case 2: 
    Console.WriteLine($"\nO resultado da subtração é: {n1-n2}");
    break;
    case 3: 
    Console.WriteLine($"\nO resultado da multiplicação é: {n1*n2}");
    break;
    case 4: 
    if (n2 == 0) {
        Console.WriteLine($"\nError");
    }
    else {
        Console.WriteLine($"\nO resultado da divisão é: {n1/n2}");
    }
    break;
    default: 
    Console.WriteLine($"\nError");
    break;
}



