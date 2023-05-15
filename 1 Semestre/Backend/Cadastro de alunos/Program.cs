using Cadastro_de_alunos;

NewClass aluno = new NewClass();
int e = 1;
string resposta = "";


Console.Clear();


    do{
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Digite o nome do aluno");
        Console.ResetColor();
        aluno.nome = Console.ReadLine();
        if (aluno.nome == "") {
            erro();
        }
    } while(aluno.nome == "");

    do {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Insira o curso do aluno");
        Console.ResetColor();
        
        aluno.curso = Console.ReadLine();
        if (aluno.curso == "") {
            erro();
        }
    } while(aluno.curso == "");

    do {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Insira a idade do aluno;");
        Console.ResetColor();

        resposta = Console.ReadLine();
        Console.ResetColor();
        bool isNumber = int.TryParse(resposta, out aluno.idade);
    if (resposta == "" || aluno.idade == 0) {
        erro();
    }
    } while(aluno.idade == 0);

    do {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"O aluno é bolsista? S/N");
        Console.ResetColor();
        resposta = Console.ReadLine().ToUpper();

        if (resposta == "S") {
            aluno.bolsista = true;
        }
        else if (resposta == "N") {	
            aluno.bolsista = false;
        }
        else {
            erro();
        }
    } while (resposta != "S" && resposta != "N");
    
    do{
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Insira o seu RG:");
        Console.ResetColor();
        aluno.RG = Console.ReadLine();
        if(aluno.RG == "" ) {
            erro();
        }
    }while (aluno.RG == "");

    do {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Digite o valor da média final do aluno");
        Console.ResetColor();
        resposta = Console.ReadLine();
        bool isNumber = float.TryParse(resposta, out aluno.mf);
        if(resposta == "" || aluno.mf == 0 || aluno.mf > 10) {
            erro();
        }
    } while (aluno.mf < 0 || aluno.mf > 10 || resposta == "");

    do {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Digite o valor da mensalidade");
        Console.ResetColor();
        resposta = Console.ReadLine();
        bool isNumber = float.TryParse(resposta, out aluno.mensalidade);
        if (resposta  == "" || aluno.mensalidade == 0) {
            erro();
        }
    } while (resposta == "" || aluno.mensalidade == 0);

do {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(@$"
        Digite o valor
    [1] - Valor da mensalidade
    [2] - Média final
    ");
    Console.ResetColor();
    resposta = Console.ReadLine();
    
} while (resposta != "1" && resposta != "2");

if (resposta == "1") {
    Console.WriteLine(aluno.bolsistadesconto());
}
else if (resposta == "2") {
    Console.WriteLine($"A média final do aluno é {aluno.vermediafinal()}");
    
}

static void erro() {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\nResposta inválida, tente novamente...");
    Console.ResetColor();
    
}
