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
