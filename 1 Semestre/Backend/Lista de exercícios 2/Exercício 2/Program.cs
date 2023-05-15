// Faça um programa que leia três números e mostre o maior e o menor deles. //

Console.WriteLine($"Escreva o primeiro número:");
float a = float.Parse(Console.ReadLine());

Console.WriteLine($"Escreva o segundo número:");
float b = float.Parse(Console.ReadLine());

Console.WriteLine($"Escreva o terceiro número:");
float c = float.Parse(Console.ReadLine());

if (a > b && a > c) {
    Console.WriteLine($"O maior valor é: {a}");
}

else if (b > a && b > c) {
    Console.WriteLine($"O maior valor é: {b}");
}

else if (c > b && c > a) {
    Console.WriteLine($"O maior valor é: {c}");
}

else {
    Console.WriteLine($"Os três valores são iguais");
}

if (a < b && a < c) {
    Console.WriteLine($"O menor valor é: {a}");
}

else if (b < a && b < c) {
    Console.WriteLine($"O menor valor é: {b}");
}

else if (c < b && c < a) {
    Console.WriteLine($"O menor valor é: {c}");
}
