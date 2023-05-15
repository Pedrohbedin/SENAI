// Ler o ano atual e o ano de nascimento de uma pessoa. Escrever uma mensagem que diga se
// ela poderá ou não votar este ano (não é necessário considerar o mês em que a pessoa nasceu).

Console.WriteLine($"Digite o ano do seu nascimento:");
int nascimento = int.Parse(Console.ReadLine()); 
int data = DateTime.Now.Year;
if (data - nascimento >= 16) {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Você pode votar");
}
else {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Você ainda precisa esperar mais um pouco");
}

Console.ResetColor();