using exercicio1;

NewClass elevador = new NewClass();
string resposta = "";

Console.Clear();
Console.WriteLine($"Insira o limite de pessoas do elevador:");
elevador.capacidade = int.Parse(Console.ReadLine()!);
Console.WriteLine($"Insira o total de andares:");
elevador.totalAndares = int.Parse(Console.ReadLine()!);

Console.Clear();

elevador.Inicializa();
Thread.Sleep(5000);
Console.Clear();

do {
    Console.WriteLine(@$"Você está no {elevador.andarAtual}

    Deseja Subir[1], Descer[2] ou Sair[0]
    ");
    resposta = Console.ReadLine()!;

    switch(resposta) {
    case "1":
    elevador.Subir();
    Console.Clear();
    
    break;
    case "2":
    elevador.Descer();
    Console.Clear();
    
    break;
    case "0":
    elevador.Sair();
    Environment.Exit(0);
    
    break;
    default:
    Console.Clear();
    break;
    }
} while (resposta != "3");




