using Celular;

NewClass celular = new NewClass();

Console.Clear();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"\nLigando...");
Thread.Sleep(1000);
Console.ResetColor();

do {
    Console.Clear();
    celular.Menu();

    switch(celular.escolha) {
    case "1":
    Console.ForegroundColor = ConsoleColor.Red; 
    Console.WriteLine($"\nDesligando...");
    Console.ResetColor();
    Thread.Sleep(1000);
    
    celular.ligado = false;
    break;
    case "2":
    Console.Clear();
    celular.ligar();
    switch(celular.opcao) {
        case "3":
            celular.escolha = "";
        break;
        default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Valor incorreto tente novamente...");
        Console.ResetColor();
        celular.opcao = "";
        
        break;
    }
    break;
    case"3":
    celular.mensagem();
    switch (celular.opcao1) {
        case"3":
        celular.escolha = ""; 
        break;  
        default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Valor incorreto tente novamente...");
        Console.ResetColor();
        celular.opcao1 = "";
        
        break;
    }
    break;
    default:
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Valor incorreto tente novamente...");
    Console.ResetColor();
    celular.escolha = "";
    
    break;
}
}while (celular.ligado == true && celular.escolha != "1" && celular.escolha != "2" && celular.escolha != "3" && celular.escolha != "4" && celular.escolha == "");


