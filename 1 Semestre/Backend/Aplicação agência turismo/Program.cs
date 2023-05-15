string senha = "";
string resposta = "";
string input = "";
int e = 0;
int t = 0;
string[] nome = new string[5];
string[] origem = new string[5];
string[] destino = new string[5];
string[] DataDoVoo = new string[5];



login(senha, resposta);


do {
    Console.ForegroundColor = ConsoleColor.Blue;

    Console.WriteLine(@$"
    _____________________________
    |                           |
    |    0 - Sair               |
    |    1 - Cadastrar passagem |
    |    2 - Listar Passagens   |
    |___________________________|

    ");

    Console.ResetColor();

    resposta = Console.ReadLine();

    if(resposta != "0" && resposta != "1" && resposta != "2") {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Resposta inválida, tente novamente...");
        Console.ResetColor(); 
    }

    else {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Resposta válida");
        Console.ResetColor(); 
    }

} while(resposta != "0" && resposta != "1" && resposta != "2");

switch (resposta) {
    case "0":
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"Saindo do programa...");
    Console.ResetColor();
    Environment.Exit(0);
    break; 

    case "1":
    for (int i = 0; i < 5; i++) {
        do {
            Console.WriteLine($"Insira o nome do(a) {i+1}º passageiro(a)");
            nome[i] = Console.ReadLine();
            
            if (nome[i] == "") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Resposta inválida, tente novamente...");
                Console.ResetColor(); 
            }
            else {
                e++;
            }
        } while (nome[i] == "");
        do {
            Console.WriteLine($"Insira a origem do(a) {i+1}º passageiro(a)");
            origem[i] = Console.ReadLine();
            if (origem[i] == "") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Resposta inválida, tente novamente...\n");
                Console.ResetColor(); 
            }
        }while (origem[i] == "");
        do {
            Console.WriteLine($"Insira a destino do(a) {i+1}º passageiro(a)");
            destino[i] = Console.ReadLine();
            if (destino[i] == "") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Resposta inválida, tente novamente...\n");
                Console.ResetColor(); 
            }
        }while (destino[i] == "");
        do {
            Console.WriteLine($"Insira a data do voo do(a) {i+1}º passageiro(a)");
            DataDoVoo[i] = Console.ReadLine();
            if (DataDoVoo[i] == "") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Resposta inválida, tente novamente...\n");
                Console.ResetColor(); 
            }
        }while (DataDoVoo[i] == "");
        do {
            Console.ForegroundColor = ConsoleColor.Yellow;;
            Console.WriteLine($"Deseja cadastrar mais um usuário... S/N");
            Console.ResetColor(); 
            input = Console.ReadLine().ToUpper();
        } while (input != "S" && input != "N");
        if (input == "N") {
            do {
        Console.ForegroundColor = ConsoleColor.Blue;

        Console.WriteLine(@$"
        _____________________________
        |                           |
        |    0 - Sair               |
        |    1 - Cadastrar passagem |
        |    2 - Listar Passagens   |
        |___________________________|

        ");

        Console.ResetColor();

        resposta = Console.ReadLine();

        if(resposta != "0" && resposta != "1" && resposta != "2") {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Resposta inválida, tente novamente...");
            Console.ResetColor(); 
        }

        else if (resposta == "2") {
            do {
                if(nome[t] != "") {
                    Console.WriteLine($"\nNome do {t+1}º: {nome[t]}");
                    Console.WriteLine($"Origem do {t+1}º: {origem[t]}");
                    Console.WriteLine($"Destino do {t+1}º: {destino[t]}");
                    Console.WriteLine($"Data do voo do {t+1}º: {DataDoVoo[t]}");
                    t++;
                }
                else {
                    break;
                }
                } while (t < e);
                Environment.Exit(0);
            }
        else {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Resposta válida");
            Console.ResetColor(); 
        }

        } while(resposta != "0" && resposta != "1" && resposta != "2");
        }
    }
    break;

    case "2":
    for (int i = 0; i < 5; i++) {
        if(e == 0) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Nenhum valor foi inserido...");
            Console.WriteLine($"Finalizando programa");
            Console.ResetColor();
            break;
        }
    }
    break; 

}








static void Listar() {
   
}

static string login(string senha, string resposta) {
    do {
Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine($"Digite a senha do usuário:");
    Console.ResetColor();
    senha = Console.ReadLine();
    resposta = (senha == "12345") ? $"\nSenha correta\n" : $"\nSenha incorreta, tente novamente...\n";

    if (senha == "12345") {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    
    Console.WriteLine($"{resposta}");

    Console.ResetColor();

} while (resposta != $"\nSenha correta\n");
return resposta;
}