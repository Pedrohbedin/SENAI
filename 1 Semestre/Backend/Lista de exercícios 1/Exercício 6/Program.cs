Console.WriteLine($"Insira a frequência do aluno:");
int frequencia= int.Parse(Console.ReadLine()); 

Console.WriteLine($"Insira a média do aluno:");
float media = float.Parse(Console.ReadLine()); 

if (media >= 7.0 && frequencia >= 25) {
    Console.WriteLine($"APROVADO");
}

else {
    if (3 >= media || media < 7.0) {
        if (frequencia >= 25) {
            Console.WriteLine($"RECUPERAÇÃO");
        }
        else {
            Console.WriteLine($"REPROVADO");
        }
    }
    else {
        Console.WriteLine($"REPROVADO");
    }
}

