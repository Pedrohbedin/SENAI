using Projeto_Produto_Interface;

Carrinho carrinho = new Carrinho();

string input;
int codigo = 0;
string nome;
float preco;
int quantidadeDeProdutos;
int codigoInserido;
Produto produto;

do {

Console.WriteLine(@$"
[1] Adicionar produto
[2] Remover produto
[3] Listar produtos
[4] Sair do programa
");
carrinho.TotalCarrinho();
input = Console.ReadLine()!;
switch (input) {
    case "1":
    Console.WriteLine($"Insira a quantidade de produtos que vc deseja cadastrar:");
quantidadeDeProdutos = int.Parse(Console.ReadLine()!);

for (int i = 0; i < quantidadeDeProdutos; i++) {
    
    Console.Clear();
    codigo++;

    Console.WriteLine($"Insira o nome do {i+1}º item:");
    nome = Console.ReadLine()!;

    Console.WriteLine($"Insira o preco do {i+1}º item:");
    preco = float.Parse(Console.ReadLine()!);
    produto = new Produto(codigo, nome, preco);

    carrinho.Adicionar(produto);
}
    break;
    case "2":
    Console.WriteLine($"Insira o código do produto q vc deseja remover");
    codigoInserido = int.Parse(Console.ReadLine()!);
    carrinho.Remover(codigoInserido);
    break;
    case "3":
    carrinho.Listar();
    Console.ReadLine();
    break;
    case "4":
    break;
}
} while (input != "4");
