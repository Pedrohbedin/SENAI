/* 4. Uma certa empresa fez uma pesquisa de mercado com 10 pessoas para saber se elas gostaram um determinado
produto lançado. Para isso forneceu o sexo do entrevistado e sua resposta (sim ou não). Faça um programa que calcule e imprima:
A.O número de pessoas que responderam SIM.
B.O número de pessoas que responderam NÃO;
C.O número de mulheres que responderam SIM;
D.A porcentagem de homens que responderam NÃO entre todos os homens analisados. */
int m = 0;
int h = 0;
bool mulher = false;
bool homem = false;
int mulhersim = 0;
int homemsim = 0;
int mulhernao = 0;
int homemnao = 0;

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
    
    while(true) 
    {
        Console.WriteLine($"Você gostou do produto? s/n");

        string gostou = Console.ReadLine().ToUpper();

        if (gostou != "S" && gostou != "N") {
            Console.WriteLine($"\nResposta inválida, tente novamente...");
            Console.ReadLine();
        }

        else {
            if(gostou != "S" && mulher == true){
                mulhernao++;
                mulher = false;
            }
            else if (gostou != "N" && mulher == true) {
                mulhersim++;
                mulher = false;
            }

            else if (gostou != "S" && homem == true) {
                homemnao++;
                homem = false;
            }
            else if (gostou != "N" && homem == true) {
                homemsim++;
                homem = false;
            }
            break;
        }
    }
}

    Console.WriteLine($"O número de mulheres que respodeu foi: {m}");
    Console.WriteLine($"O número de homens que respondeu foi: {h}");
    Console.WriteLine($"O número de pessoas que responderam sim foi: {homemsim + mulhersim}");
    Console.WriteLine($"O número de pessoas que respoderam não foi: {homemnao + mulhernao}");
    Console.WriteLine($"O número de mulheres que respondeu sim foi: {mulhersim}");
    Console.WriteLine($"A porcentagem de homens que respondeu não foi: {(homemnao * 100)/h}%");