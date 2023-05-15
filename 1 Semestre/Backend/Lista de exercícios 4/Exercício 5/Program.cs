// Escreva um algoritmo que imprima a tabuada (de 1 a 10) para os números de 1 a 10.
// Exemplo: tabuada do 1, tabuada do 2, etc... Dica: utilize um laço dentro do outro.

for(int n1 = 1; n1 <= 10; n1++) {
    for(int n2 = 1; n2 <= 10; n2++){
        Console.WriteLine($"{n1} * {n2} = {n1 * n2}");
        
    }
}