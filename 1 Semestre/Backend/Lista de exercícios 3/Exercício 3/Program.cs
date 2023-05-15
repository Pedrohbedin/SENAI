/* Faça um programa que receba um número inteiro e mostre a sua tabuada. */


Console.WriteLine($"Insira um valor inteiro:");
int valor = int.Parse(Console.ReadLine());
    
for(int i = 0; i <= 10; i++){
    Console.WriteLine($"{valor} * {i} = {valor * i}");
    
}
    

