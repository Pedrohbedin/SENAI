Console.WriteLine($"1 : Domingo");
Console.WriteLine($"2 : Segunda");
Console.WriteLine($"3 : Terça");
Console.WriteLine($"4 : Quarta");
Console.WriteLine($"5 : Quinta");
Console.WriteLine($"6 : Sexta");
Console.WriteLine($"7 : Sábado\n");
Console.WriteLine($"Digite o número correspondente ao dia da semana:");
int DiaDaSemana = int.Parse(Console.ReadLine());

switch (DiaDaSemana) {
    case 1: 
    Console.WriteLine($"Domingo");
    break;
    case 2: 
    Console.WriteLine($"Segunda");
    break;
    case 3: 
    Console.WriteLine($"Terça");
    break;
    case 4: 
    Console.WriteLine($"Quarta");
    break;
    case 5: 
    Console.WriteLine($"Quinta");
    break;
    case 6: 
    Console.WriteLine($"Sexta");
    break;
    case 7: 
    Console.WriteLine($"Sábado");
    break;
    default:
    Console.WriteLine($"O dia informado não corresponde a nenhm dia da semana");
    break;
    
}


