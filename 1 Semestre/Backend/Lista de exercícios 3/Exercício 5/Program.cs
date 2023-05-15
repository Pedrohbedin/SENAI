int m = 0;
int h = 0;
bool mulher = false;
bool homem= false;
float mediamulher = 0;
float mediahomem = 0;

for (int i = 1; i <= 10; i++) {
    while (true)
    {
        Console.WriteLine(@$"Digite seu gênero para:
        ______________
        |            |
        | m - mulher |
        |            |
        | h - homem  |
        |____________|
        ");

        string genero = Console.ReadLine().ToUpper();

        if (genero != "M" && genero != "H") {
            Console.WriteLine($"\nResposta inválida, tente novamente...");
            Console.ReadLine();
        }

        else {
            if (genero == "M") {
                m++;
                mulher = true;
            }
            else {
                h++;
                homem = true;
            }
            break;
        }
    }

    while (true) {
        Console.WriteLine($"Insira sua idade:");
        int idade = int.Parse(Console.ReadLine());


        
        if (idade > 100 || idade <= 0){
            Console.WriteLine($"Idade inválida, tente novamente...");
            Console.ReadLine();
        }


        else {
            if (mulher) {
                mediamulher += idade;
                mulher = false;
            }
            else {
                mediahomem += idade;
                homem = false;
            }
            break;
        }
    }
}

Console.WriteLine($"O total de homens foi: {h}");
Console.WriteLine($"O total de mulheres foi: {m}");
Console.WriteLine($"A média de idade feminina foi: {Math.Round(mediamulher/m)}");
Console.WriteLine($"A média de idade masculina foi: {Math.Round(mediahomem/h)}");


