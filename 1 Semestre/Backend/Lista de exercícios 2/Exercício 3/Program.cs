// Escreva um programa que pergunte o raio de uma circunferência, e sem seguida mostre o diâmetro, comprimento e área da circunferência. //

Console.WriteLine($"Escreva o raio da circunferência:");
float raio = float.Parse(Console.ReadLine());

float diametro = 2 * raio;
double comprimentro = Math.Round((2 * Math.PI * raio), 2);
double area = 3.14 * Math.Pow(raio, 2);

Console.WriteLine($"\nO diametro da sua circunferência é: {diametro}");
Console.WriteLine($"\nO comprimento da sua circunferência é: {comprimentro}");
Console.WriteLine($"\nA área da sua circunferência é: {area}");

