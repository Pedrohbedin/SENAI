while(true){ 

    Console.WriteLine($"Insira seu nome:");
    string nome = Console.ReadLine();

    if (nome == "")
    {
        Console.WriteLine($"Nome inválido\n");
    }

    else {
        break;
    }
}

while (true) {
    Console.WriteLine($"Insira sua idade:");
    string idade = Console.ReadLine();
    
    if (idade == "") {
        Console.WriteLine($"Nenhuma idade foi inserida\n");
    }

    else {
        int valoridade = int.Parse(idade);

        if (valoridade <= 100 || valoridade > 0) {
        break;
    }

        else {
        Console.WriteLine($"Idade Inválida\n");
        
        }
    }
}

    while (true){
        Console.WriteLine($"Insira o valor do seu salário:");
    float salario = float.Parse(Console.ReadLine());

    if (salario < 1) {
        Console.WriteLine($"Salário inválido\n");
    }

    else {
        break;
    }
    }

while (true) {
    Console.WriteLine($"Insira a letra correspondete ao seu estado civil:");
    Console.WriteLine(@$"
    ________________________
    |                      |
    |   S - Solteiro(a)    |
    |   C - Casado(a)      |
    |   V - Viúvo(a)       |
    |   D - Divorciado(a)  |
    |______________________|
    ");
    Console.WriteLine($"Digite o valor:");
    string estado = Console.ReadLine().ToUpper();

    if (estado != "S")
    {
        Console.WriteLine($"Estado-civil inválido\n");
    }
    
    else {
        break;
        Console.WriteLine($"Valores aceitos");
        
    }

} 
