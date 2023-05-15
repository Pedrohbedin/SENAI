// Escreva um algoritmo que permita a leitura dos nomes de 10 pessoas e armazene os nomes
//lidos em um vetor. Após isto, o algoritmo deve permitir a leitura de mais 1 nome qualquer de
//pessoa (para efetuar uma busca) e depois escrever a mensagem ACHEI, se o nome estiver
//entre os 10 nomes lidos anteriormente (guardados no vetor), ou NÃO ACHEI caso contrário.

string[] nome = new string[10];
string nomei = "";
int achei = 0;

for (int i = 0; i < 10; i++) {
    Console.WriteLine($"Digite o {i + 1}° nome:");
    nome[i] = Console.ReadLine();
}

Console.WriteLine($"Insira um nome:");
nomei = Console.ReadLine();


for (int teste = 0; teste < 10; teste++) {
    if (nome[teste].ToUpper() == nomei.ToUpper()) {
        achei++;
    }
}

if (achei > 0) {
    Console.WriteLine($"Achei");
}
else {
    Console.WriteLine($"Não achei");   
}
