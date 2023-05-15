Console.WriteLine($"Escreva o número de maçãs compradas:");
int compradas = int.Parse(Console.ReadLine());

float preco;

if (compradas < 12) {
    preco = 0.30f;
}
else {
    preco = 0.25f;
}

float valor = preco * compradas;

Console.WriteLine($"Pague: {Math.Round(valor, 2)}");

