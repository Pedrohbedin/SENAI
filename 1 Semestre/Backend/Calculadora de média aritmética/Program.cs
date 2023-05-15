Console.WriteLine($"Digite a primeira nota:");
float nota1 = float.Parse(Console.ReadLine());

Console.WriteLine($"Digite a segunda nota:");
float nota2 = float.Parse(Console.ReadLine());

Console.WriteLine($"Digite a terceira nota:");
float nota3 = float.Parse(Console.ReadLine());

Console.WriteLine($"Digite a quarta nota:");
float nota4 = float.Parse(Console.ReadLine());

Console.WriteLine($"Digite a quinta nota:");
float nota5 = float.Parse(Console.ReadLine());

float media = (nota1 + nota2 + nota3 + nota4 + nota5)/5;

Console.WriteLine($"Sua média final foi: {Math.Round(media, 2)}");



