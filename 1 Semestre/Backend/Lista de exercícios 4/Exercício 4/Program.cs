//Faça um programa que leia 10 valores digitados pelo usuário e no final, escreva o maior e o
//menor valor lido.

float[] numero = new float[10]; 
float menor = 0;
float maior = 0;

for (int i = 0; i < 10; i++) {
    Console.WriteLine($"Digite o {i + 1}° valor:");
    numero[i] = float.Parse(Console.ReadLine());

    
    if( i == 0 )
    {
        menor = numero[0];
        maior = numero[0];
    }

    if( numero[i] < menor )
    {
        menor = numero[i];
    }

    if( numero[i] > maior )
    {
        maior = numero[i];
    }
}
Console.WriteLine($"\nO menor valor é {menor}\n");
Console.WriteLine($"O maior valor é {maior}");

