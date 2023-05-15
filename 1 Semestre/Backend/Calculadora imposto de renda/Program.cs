//faça um método para calcular imposto sobre a renda

//regras de negócio
//tabela de imposto vs renda
//até $1500 - isento
//de $1501 até $3500 - 20% de imposto
//de $3501 até $6000 - 25% de imposto
//acima de $6000 - 35% de imposto


//receber o renda via console
//chamar o método passando a renda como parâmetro
//exibir o valor do imposto referente á renda

using System.Globalization;

Console.WriteLine($"Insira sua renda:");
float renda = float.Parse(Console.ReadLine());
Console.WriteLine(Calcular(renda));

static string Calcular(float renda) {
    string resposta = "";
    float imposto = 0;
    if (renda < 1501) {
        Console.ForegroundColor = ConsoleColor.Green;
        resposta = $"\nVocê está insento";
    }
    else if (renda > 1500 && renda < 3501 )
    {
        imposto = renda * 0.2f;
        resposta = $"\nVocê precisa pagar R${Math.Round(imposto, 2)} de imposto";
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else if(renda > 3500 && renda < 6001) {
        imposto = renda * 0.25f;
        resposta = $"\nVocê precisa pagar R${Math.Round(imposto, 2)} de imposto";
        Console.ForegroundColor = ConsoleColor.DarkYellow;
    }
    else {
        imposto = renda * 0.35f;
        resposta = $"\nVocê precisa pagar R${Math.Round(imposto, 2)} de imposto";
        Console.ForegroundColor = ConsoleColor.Red;
    }
    return resposta;
}
Console.ResetColor();