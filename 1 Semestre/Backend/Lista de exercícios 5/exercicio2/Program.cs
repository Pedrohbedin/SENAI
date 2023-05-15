using exercicio2;

NewClass Menucafe = new NewClass();
string resposta = "";


Console.WriteLine($"-=- Bem Vindo -=-");
do {
Console.WriteLine(@$"
_________________________
|                       |
|   [1] Café com açúcar |
|   [2] Café sem açúcar |
|   [3] Sair            |
|_______________________|
");
resposta = Console.ReadLine()!;
switch (resposta) {
    case "1":
    Menucafe.acucar = true;
    Menucafe.fazerCafe();
    Environment.Exit(0);
    break;
    case "2":
    Menucafe.acucar = false;
    Menucafe.fazerCafe();
    Environment.Exit(0);
    break;
    case "3":
    Environment.Exit(0);
    break;
    default:
    break;
}
} while(resposta != "3");
