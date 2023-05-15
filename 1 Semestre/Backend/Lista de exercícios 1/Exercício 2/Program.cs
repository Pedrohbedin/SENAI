Console.WriteLine($"Digite o total de gols de um dos times:");
int gols1 = int.Parse(Console.ReadLine());

Console.WriteLine($"Digite o total de gols do outro time:");
int gols2 = int.Parse(Console.ReadLine());

string vencedor = (gols1 > gols2) ? "O vencedor foi o time 1" : "O vencedor foi o time 2";

if (gols1 == gols2){
    vencedor = "empate";
}

Console.WriteLine(vencedor);