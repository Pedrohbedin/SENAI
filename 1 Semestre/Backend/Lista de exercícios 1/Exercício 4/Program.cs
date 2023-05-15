string senha = "1234";
Console.WriteLine($"Insira sua senha:");
string valor_escrito = Console.ReadLine();

if (valor_escrito != senha) {
    Console.WriteLine("Acesso Negado");
}

else {
    Console.WriteLine("Acesso Permitido");
}


