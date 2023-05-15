int[] valor = new int[6];
int par = 0;
int impar = 0;

for(int i = 0; i < valor.Length; i++) {
    Console.WriteLine($"Digite o {i + 1}º valor:");
    valor[i] = int.Parse(Console.ReadLine());
    if (valor[i] % 2 == 0) {
        par++;
    }
    else{
        impar++;
    }
}

Console.WriteLine($"O número de valores ímpares é: {impar}");
Console.WriteLine($"O número de valores pares é: {par}");

