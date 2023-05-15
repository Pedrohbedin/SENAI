/* Faça um programa que peça uma nota, entre zero e dez. Mostre uma mensagem caso o valor seja inválido e continue pedindo até que o usuário informe um valor válido. */

while (true) {
Console.WriteLine($"Insira sua nota:");
float nota = float.Parse(Console.ReadLine());

if (nota <= 10 && nota >= 0) {
    Console.WriteLine($"Nota válida");
    
    break;
}

else {
    Console.WriteLine($"Nota inválida\n");
}
}
