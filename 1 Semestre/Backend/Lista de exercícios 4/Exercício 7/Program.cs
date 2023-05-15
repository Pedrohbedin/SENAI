//Faça um algoritmo para ler 15 números e armazenar em um vetor. Após a leitura total dos
//15 números, o algoritmo deve escrever esses 15 números lidos na ordem inversa da qual foi
//declarado.
float[] x = new float[15];

for (int i = 0; i < 15; i++) {
    Console.WriteLine($"Escreva o {i+1}° valor");
    x[i] = float.Parse(Console.ReadLine());
}

for (int y = 14; y != -1; y--) {
    Console.WriteLine($"O {y+1}° termo é {x[y]}");
}