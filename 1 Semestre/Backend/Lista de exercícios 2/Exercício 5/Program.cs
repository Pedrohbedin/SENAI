// Faça um programa que verifique se uma letra digitada é vogal ou consoante //

Console.WriteLine($"Digite uma letra:");
string resposta = Console.ReadLine();

if (resposta == "a" || resposta == "e" || resposta == "i" || resposta == "o" || resposta == "u") {
    Console.WriteLine($"Vogal");
}

else {
    Console.WriteLine($"Consoante");
}