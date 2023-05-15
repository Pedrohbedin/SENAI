/* Faça um programa que leia um nome de usuário e a sua senha e não aceite a senha igual ao nome do usuário, mostrando uma mensagem de erro e voltando a pedir as informações. */

while (true) {
    Console.WriteLine($"Insira o nome do usuário:");
    string nome = Console.ReadLine();
    Console.WriteLine($"Insira sua senha:");
    string senha = Console.ReadLine();

    if (nome == "" || nome == senha || senha == ""){
        Console.WriteLine($"Valores invalidos, tente novamente...");
        Console.ReadLine();
    }
    else {
        Console.WriteLine($"Bem-vindo(a) {nome}");
        
        break;
    }
}
