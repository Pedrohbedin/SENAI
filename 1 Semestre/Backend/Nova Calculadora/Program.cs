using Nova_Calculadora;

NewClass calculadora = new NewClass();

string input = "";
string resposta = "";


Console.Clear();

do {
Console.WriteLine($"\nInsira o primeiro valor:");
resposta = Console.ReadLine();

bool isNumber = float.TryParse(resposta, out calculadora.n1);
if (resposta == "") {
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"\nResposta inválida, tente novamente...");
Console.ResetColor();
}
} while (resposta == "");

do {
Console.WriteLine($"\nInsira o segundo valor:");
resposta = Console.ReadLine();

bool isNumber = float.TryParse(resposta, out calculadora.n2);
if (resposta == "") {
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"\nResposta inválida, tente novamente...");
Console.ResetColor();
}
} while (resposta == "");

Console.Clear();

do { 
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(@$"         
   Digite a operação   

    [+] Soma               
    [-] Subtração          
    [/] Divisão            
    [x] Multiplicação     
");
Console.ResetColor();
input = Console.ReadLine();

switch(input) {
    case "+":
    Console.WriteLine(calculadora.somar());
    break;
    case "-":
    Console.WriteLine(calculadora.subtrair());
    break;
    case "/":
    Console.WriteLine(calculadora.dividir());
    break;
    case "x":
    Console.WriteLine(calculadora.multiplicar());
    break;
    default:
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Resposta inválida, tente novamente...");
    Console.ResetColor();
    break;
}

} while (input != "-" && input != "+" && input != "/" && input != "x");


