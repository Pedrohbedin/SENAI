Console.WriteLine("0 - Tomate");
Console.WriteLine("1 - Cenoura");
Console.WriteLine("2 - Melância");
Console.WriteLine("3 - Maçã");
Console.WriteLine("4 - Laranja");
Console.WriteLine("5 - Alface");

Console.WriteLine($"Digite o número correspondente ao seu alimento:");
int i = int.Parse(Console.ReadLine());

float Preco_Por_Kilo = 0;

Console.WriteLine($"Digite o peso comprado em kilos:");
float peso = float.Parse(Console.ReadLine());

if (i == 0) {
    Preco_Por_Kilo =+ 3.26f;
}

if (i == 1) {
    Preco_Por_Kilo =+ 2.61f;
}

if (i == 2) {
    Preco_Por_Kilo =+ 2.40f;
}

if (i == 3) {
    Preco_Por_Kilo =+ 5.97f;
}

if (i == 4) {
    Preco_Por_Kilo =+ 2.60f;
}

if (i == 5) {
    Preco_Por_Kilo =+ 2.75f;
}

float Valor_Da_Compra = Preco_Por_Kilo * peso;

Console.WriteLine($"Valor da compra: {Math.Round(Valor_Da_Compra, 2)}");






