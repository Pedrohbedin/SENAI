using Projeto_Cartao_Interface;

Agenda agenda = new Agenda();
ContatoComercial contato;
string nome;
string telefone;
string email;
int quantidadeSalvos;
string registroPessoa;

string resposta;
do {
    Console.Clear();
    Console.WriteLine(@$"
Escolha a opção desejada

[1] Criar contato
[2] Listar contatos 
[3] Excluir contato
[4] Sair do programa
");
resposta = Console.ReadLine()!;
switch (resposta) {
    case"1":
    Console.Clear();
    
    Console.WriteLine($"Quantos contatos serão salvos");
    quantidadeSalvos = int.Parse(Console.ReadLine()!);
    Console.Clear();
    
    for (int i = 0; i < quantidadeSalvos; i++) {
    Console.WriteLine($"Insira o nome");
    nome = Console.ReadLine()!;
    do {
    Console.WriteLine($"Insira o telefone");
    telefone = Console.ReadLine()!;
    } while (telefone.Length != 11);
    Console.WriteLine($"Insira o email");
    email = Console.ReadLine()!;
    do {
        Console.WriteLine($"Insira o CPF/CNPJ");
        registroPessoa = Console.ReadLine()!;
    } while(registroPessoa.Length != 11 && registroPessoa.Length != 14);

    contato = new ContatoComercial(nome, telefone, email, registroPessoa);
    agenda.Adicionar(contato);
    }
    
    break;
    case"2":
    Console.Clear();
    agenda.Listar();
    Console.WriteLine($"\nPressione qualquer tecla para continuar");
    
    Console.ReadLine();
    break;
    case"3":
    break;
    case"4":
    break;
}
} while (resposta != "4");
